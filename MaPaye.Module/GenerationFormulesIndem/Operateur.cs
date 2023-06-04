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

namespace MaPaye.Module
{
    public partial class Operateur : Form
    {
        Session Session;
        public string Opr { get; set; }

        public Operateur(Session session)
        {
            InitializeComponent();
            Session = session;
        }

        private void Operateur_Load(object sender, EventArgs e)
        {

        }
         
        private void OK_Click(object sender, EventArgs e)
        {
            Opr = PremierOperateur.Text;
            Close();
        }


        
    }
}
