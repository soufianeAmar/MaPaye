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
using DevExpress.Data;
using DevExpress.XtraEditors.Controls;

namespace MaPaye.Module
{
    public partial class Indemnite : Form
    {
        Session Session;
        public string Indem { get; set; }
        public Indemnite(Session session)
        {
            InitializeComponent();  
            Session = session;
        }

        private void Indemnite_Load(object sender, EventArgs e)
        { 
            XPCollection<Indem> xpCollectionIndems = new XPCollection<Indem>(Session);
            xpCollectionIndems.Load();
            xpCollectionIndems.DisplayableProperties = "Cod_indem_interne;Lib_indem;"; 
            xpCollectionIndems.Sorting.Add(new SortProperty("Cod_indem_interne", SortingDirection.Ascending));
              
            PremierOperateur2.Properties.DataSource = xpCollectionIndems;
            PremierOperateur2.Properties.DisplayMember = "Cod_indem_interne";
            PremierOperateur2.Properties.ValueMember = "Cod_indem_interne"; 
            PremierOperateur2.Properties.ShowHeader = false; 
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Indem = PremierOperateur2.Text;
            Close(); 
        }

    }
}
