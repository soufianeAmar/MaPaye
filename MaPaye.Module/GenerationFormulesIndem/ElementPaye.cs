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
using DevExpress.XtraEditors.Controls;

namespace MaPaye.Module
{
    public partial class ElementPaye : Form
    {
        Session Session;
        public string Element { get; set; }

        public ElementPaye(Session session)
        {
            InitializeComponent(); 
            //XPCollection xpCollectionCategories = new XPCollection(typeof(Indem));
            Session = session;
        }

        private void ElementPaye_Load(object sender, EventArgs e)
        {
            string requete = ""; 
             
            DataTable dt = new DataTable();

            if (lsactvtn.ActivationClass.réseau)
            {
                requete = string.Format(@"select
                               syscolumns.name as [ElementPaye] 
                            from 
                               sysobjects, syscolumns 
                            where sysobjects.id = syscolumns.id
                            and   sysobjects.xtype = 'U'
                            and   sysobjects.name = 'Paye'
                            order by syscolumns.name asc");

                dt = Core.FetchData("", requete, (SqlConnection)Session.Connection, true);
            }
            else
            {
                requete = string.Format(@"PRAGMA   table_info(Paye)");
                dt = Core.FetchData("", requete, (SQLiteConnection)Session.Connection, false);
                dt.DefaultView.Sort = "name ASC";
            }


            PremierOperateur2.Properties.DataSource = dt;
             
            PremierOperateur2.Properties.DisplayMember = "name";
            PremierOperateur2.Properties.PopulateColumns();
            if (!lsactvtn.ActivationClass.réseau)
            {
                PremierOperateur2.Properties.Columns[0].Visible = false;
                PremierOperateur2.Properties.Columns[2].Visible = false;
                PremierOperateur2.Properties.Columns[3].Visible = false;
                PremierOperateur2.Properties.Columns[4].Visible = false;
                PremierOperateur2.Properties.Columns[5].Visible = false;
            }
            //LookUpColumnInfo columnInfo = PremierOperateur2.Properties.Columns[1];
            //columnInfo.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            //int visibleIndex = PremierOperateur2.Properties.Columns.IndexOf(columnInfo);
            //PremierOperateur2.Properties.SortColumnIndex = visibleIndex;

            PremierOperateur2.Properties.ShowHeader = false;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Element = PremierOperateur2.Text;
            Close(); 
        }
    }
}
