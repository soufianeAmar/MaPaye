using System;
using System.Collections.Generic;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.Demos;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;

namespace TP.Shell.XAF.Module.Win.Controllers
{
    public abstract class LongOperationController : ViewController {
        private IProgressControl progressControl;
        private AsyncOperation waitLongOperationCompleted;
        public List<string> ChangedProps = new List<string>();

        private void DoWork(LongOperation longOperation) {
            try {
                DoWorkCore(longOperation);
            }
            catch(Exception) {
                longOperation.TerminateAsync();
                progressControl.Dispose();
                throw;
                
            }
        }
        private void WorkCompleted(object state) {
            OnOperationCompleted();
        }
        private void LongOperation_CancellingTimeoutExpired(object sender, EventArgs e) {
            ((LongOperation)sender).TerminateAsync();
        }
        protected void LongOperation_Completed(object sender, LongOperationCompletedEventArgs e) {
            progressControl.Dispose();
            progressControl = null;
            ((LongOperation)sender).CancellingTimeoutExpired -= LongOperation_CancellingTimeoutExpired;
            ((LongOperation)sender).Completed -= LongOperation_Completed;
            ((LongOperation)sender).Dispose();

            waitLongOperationCompleted.PostOperationCompleted(WorkCompleted, null);
            waitLongOperationCompleted = null;
        }

        protected abstract void DoWorkCore(LongOperation longOperation);

        protected abstract IProgressControl CreateProgressControl();

        protected virtual void OnOperationStarted() {
            if(OperationStarted != null) {
                OperationStarted(this, EventArgs.Empty);
            }
        }
        protected virtual void OnOperationCompleted() {
            View.ObjectSpace.Refresh();
            if(OperationCompleted != null) {
                OperationCompleted(this, EventArgs.Empty);
            }
        }
        protected void StartLongOperation(List<string> strings) {
            
            waitLongOperationCompleted = AsyncOperationManager.CreateOperation(null);
            var longOperation = new LongOperation(DoWork) {CancellingTimeoutMilliSeconds = 2000};
            longOperation.CancellingTimeoutExpired += LongOperation_CancellingTimeoutExpired;
            longOperation.Completed += LongOperation_Completed;
            
            ChangedProps = strings;
            progressControl = CreateProgressControl();
            progressControl.ShowProgress(longOperation);
            longOperation.StartAsync();
            OnOperationStarted();
        }
        public event EventHandler OperationStarted;
        public event EventHandler OperationCompleted;

        #region Session struff

        public UnitOfWork CreateUpdatingSession()
        {
            var session = new UnitOfWork(((XPObjectSpace)ObjectSpace).Session.DataLayer);
            OnUpdatingSessionCreated(session);
            return session;
        }

        public void CommitUpdatingSession(UnitOfWork session)
        {
            session.CommitChanges();
            OnUpdatingSessionCommitted(session);
        }

        protected virtual void OnUpdatingSessionCommitted(UnitOfWork session)
        {
            if (UpdatingSessionCommitted != null)
            {
                UpdatingSessionCommitted(this, new SessionEventArgs(session));
            }
        }

        protected virtual void OnUpdatingSessionCreated(UnitOfWork session)
        {
            if (UpdatingSessionCreated != null)
            {
                UpdatingSessionCreated(this, new SessionEventArgs(session));
            }
        }

        public event EventHandler<SessionEventArgs> UpdatingSessionCommitted;
        public event EventHandler<SessionEventArgs> UpdatingSessionCreated;

        #endregion

    }

    public class LongOperationTerminateException : Exception { }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class BatchCreationOptionsAttribute : Attribute {
        public BatchCreationOptionsAttribute(int objectsCount) {
            ObjectsCount = objectsCount;
        }
        public BatchCreationOptionsAttribute(int objectsCount, int commitInterval) : this(objectsCount) {
            CommitInterval = commitInterval;
        }

        public int? ObjectsCount { get; private set; }

        public int? CommitInterval { get; private set; }
    }

    public interface IObjectPropertiesInitializer {
        void InitializeObject(int index);
    }

    public interface IProgressControl : IDisposable {
        void ShowProgress(LongOperation longOperation);
    }
}