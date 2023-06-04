using System;
using DevExpress.Xpo;

namespace TP.Shell.XAF.Module.Win.Controllers
{
    public class SessionEventArgs : EventArgs
    {
        public SessionEventArgs(UnitOfWork session)
        {
            Session = session;
        }

        public UnitOfWork Session { get; private set; }
    }
}