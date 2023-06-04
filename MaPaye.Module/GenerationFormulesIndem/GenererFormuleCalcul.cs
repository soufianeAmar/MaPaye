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
    public partial class GenererFormuleCalculForm : Form
    {
        Session Session;
        public string FormuleIndem { get; set; }
        int Choix;
         
        public GenererFormuleCalculForm(Session session, int choix)
        {
            InitializeComponent();  
            Session = session;
            Choix = choix;
        }
 
         
        private void AddOperator_Click(object sender, EventArgs e)
        {
            using (var Operateur = new Operateur(Session))
            {
                var result = Operateur.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (Choix == 2 || Choix == 3 || Choix == 4)
                        Formule.Text += Operateur.Opr;// + "*1.00";
                    else
                        Formule.Text += Operateur.Opr;
                }
            } 
        }
         
        private void AddPayeElement_Click(object sender, EventArgs e)
        {
            using (var ElementPaye = new ElementPaye(Session))
            {
                var result = ElementPaye.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (Choix == 2 || Choix == 3 || Choix == 4)
                        Formule.Text += ElementPaye.Element;// + "*1.00";
                    else
                        Formule.Text += ElementPaye.Element;
                }
            }  
        }

        private void AddIndem_Click(object sender, EventArgs e)
        {
            using (var Indemnite = new Indemnite(Session))
            {
                var result = Indemnite.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (Choix == 2 || Choix == 3 || Choix == 4)
                        Formule.Text += Indemnite.Indem;// + "*1.00";
                    else
                        Formule.Text += Indemnite.Indem;
                }
            } 
        }

        private void OK_Click(object sender, EventArgs e)
        {
            FormuleIndem = Formule.Text;
            Close();
        }

         
         
    }
}
