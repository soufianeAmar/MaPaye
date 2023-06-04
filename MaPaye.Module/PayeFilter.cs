using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

namespace MaPaye.Module
{
    public partial class PayeFilter : ViewController
    {
        public PayeFilter()
        {
            InitializeComponent();
            RegisterActions(components);
        }
    }
}
