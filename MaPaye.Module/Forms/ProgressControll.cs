using DevExpress.ExpressApp.Demos;
using TP.Shell.XAF.Module.Win.Controllers;
using System.Windows.Forms;

namespace TP.Shell.XAF.Module.Win.Forms
{
    class ProgressControll : IProgressControl
    {
        public ProgressControll(string caption, int recordCount, string message)
        {
            CreateProgressForm(caption, recordCount, message);
        }

        private ProgressForm form;
        private LongOperation longOperation;

        private delegate void UpdateProgressFormDelegate(int value, string message);

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            longOperation.ProgressChanged -= LongOperation_ProgressChanged;
            longOperation.Completed -= LongOperation_Completed;
            longOperation = null;
            if (form != null)
            {
                form.Invoke(new MethodInvoker(form.Dispose));
                form = null;
            }
        }

        public void ShowProgress(LongOperation longOperation)
        {
            form.Show();
            this.longOperation = longOperation;
            this.longOperation.ProgressChanged += LongOperation_ProgressChanged;
            this.longOperation.Completed += LongOperation_Completed;

        }

        #endregion
        private void LongOperation_Completed(object sender, LongOperationCompletedEventArgs e)
        {
            if (form != null)
            {
                form.Invoke(new MethodInvoker(form.Close));
            }
        }
        private void UpdateProgressForm(int value, string message)
        {
           if (form != null)
                  form.DoProgress();
        }

        private void LongOperation_ProgressChanged(object sender, LongOperationProgressChangedEventArgs e)
        {
            
            if (form != null)
            {
                form.Invoke(new UpdateProgressFormDelegate(UpdateProgressForm), new object[] { 0, e.Message });
            }
            
            //try
            //{
            //    if (form != null)
            //        form.DoProgress();
            //}
            //catch
            //{
                
            //}
        }


        private void CreateProgressForm(string caption, int recordCount, string message)
        {
            form = new ProgressForm(caption, recordCount, message);
        }
    }
}
