using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo; 
using System.Data.SqlClient; 
using System.Data;
using System.Reflection;
using DevExpress.XtraReports.Design.Commands;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Reports;
using System.Windows.Forms;
using DevExpress.Xpo.DB;
using System.Collections;
using DevExpress.Data;
using System.Data.SQLite;

namespace MaPaye.Module
{
    public partial class Pointeuses : Form
    {
        Session Session; 

        public Pointeuses(Session session)
        {
            InitializeComponent(); 

            Session = session;
        }
         
         
    }
}
