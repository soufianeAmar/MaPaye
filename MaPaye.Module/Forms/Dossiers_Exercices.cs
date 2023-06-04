using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaPayeAdmin;
using DevExpress.XtraEditors.Repository;

namespace MaPaye.Module
{
    public partial class Dossiers_Exercices : Form
    {
        Session Session;
        bool prIndem = false;
        public List<string> dossiers = new List<string>();
        public List<string> exercices = new List<string>();
        public List<string> parametresIndem = new List<string>();
        public List<bool> valeures = new List<bool>();
        bool optionsAvancees = false;
        string dbName = "";

        public Dossiers_Exercices(Session session, bool pourIndem, string db_name)
        {
            InitializeComponent();
            Session = session;
            prIndem = pourIndem;
            dbName = db_name; 
        }

        private void Dossiers_Exercices_Load(object sender, EventArgs e)
        {
            if (!prIndem)
                button2.Visible = false;
            else
                button2.Visible = true;

            CreateNodes(treeList1);
            treeList1.ExpandAll();
            treeList1.OptionsBehavior.EnableFiltering = true;
            FilterCondition fc = new FilterCondition(FilterConditionEnum.Equals, treeList1.Columns[1], dbName); 
            treeList1.FilterConditions.Add(fc); 
            checkBox1.Checked = true;
 
        }
         
        private void CreateNodes(TreeList tl)
        {
            tl.BeginUnboundLoad();

            string requeteDossier = "";
            DataTable dtDossier = new DataTable();

            if (lsactvtn.ActivationClass.réseau)
            {
                string ConnectionString = string.Format("Integrated Security=false;Pooling=false;Data Source=" +
                   "{0}{1};Initial Catalog=MaPayeAdmin;User ID=sa;Password=58206670", Helper.serverName, Helper.instanceName);

                SqlConnection Connection = new SqlConnection(ConnectionString);


                requeteDossier = string.Format(@"SELECT  [Oid], [code_dossier]  
                                                       FROM [MaPayeAdmin].[dbo].[Dossier]
                                                       where gcrecord is null");

                dtDossier = Core.FetchData("", requeteDossier, (SqlConnection)Connection, true);
                dtDossier.DefaultView.Sort = "code_dossier ASC";

                DataTable dtExercice = new DataTable();

                foreach (DataRow drDossier in dtDossier.Rows)
                {
                    TreeListNode parentForRootNodes = null;
                    TreeListNode rootNode = tl.AppendNode(new object[] { "",drDossier["code_dossier"].ToString(), "" }, parentForRootNodes);

                    string requeteExercice = string.Format(@"SELECT   [exercice]  
                                                                      FROM [Exercice]
                                                                      where gcrecord is null
                                                                       and dossier ='{0}'", drDossier["Oid"]);
                    dtExercice = Core.FetchData("", requeteExercice, (SqlConnection)Connection, true);
                    dtExercice.DefaultView.Sort = "exercice ASC";

                    foreach (DataRow drExercice in dtExercice.Rows)
                    {
                        tl.AppendNode(new object[] {true, drDossier["code_dossier"].ToString(), drExercice["exercice"].ToString() }, rootNode);
                    }
                }
                tl.EndUnboundLoad();
            } 
            else
            {
                string ConnectionString = string.Format("XpoProvider=SQLite;Data Source={0}\\MaPayeAdmin", Core.GetApplicationPath());
                DbConnection Connection = new SQLiteConnection(ConnectionString);

                requeteDossier = string.Format(@"SELECT  [Oid],[code_dossier]  
                                                       FROM  [Dossier]
                                                       where gcrecord is null");
                dtDossier = Core.FetchData("", requeteDossier, (SQLiteConnection)Connection, false);
                dtDossier.DefaultView.Sort = "code_dossier ASC";

                DataTable dtExercice = new DataTable();

                foreach (DataRow drDossier in dtDossier.Rows)
                {
                    TreeListNode parentForRootNodes = null;
                    TreeListNode rootNode = tl.AppendNode(new object[] {"", drDossier["code_dossier"].ToString(), "" }, parentForRootNodes);

                    string requeteExercice = string.Format(@"SELECT   [exercice]  
                                                                      FROM [Exercice]
                                                                      where gcrecord is null
                                                                       and dossier ='{0}'", drDossier["Oid"]);
                    dtExercice = Core.FetchData("", requeteExercice, (SQLiteConnection)Connection, false);
                    dtExercice.DefaultView.Sort = "exercice ASC";

                    foreach (DataRow drExercice in dtExercice.Rows)
                    {
                        tl.AppendNode(new object[] {true, drDossier["code_dossier"].ToString(), drExercice["exercice"].ToString() }, rootNode);
                    }
                }
            }
            tl.EndUnboundLoad();
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (TreeListNode node in treeList1.Nodes)
                foreach (TreeListNode childNode in node.Nodes)
                {
                    bool checkedNode = Convert.ToBoolean(childNode.GetValue(treeList1.Columns[0]));
                    if (checkedNode)
                    {
                        string dossier = childNode.GetValue(treeList1.Columns[1]).ToString();
                        dossiers.Add(dossier);
                        string exercice = childNode.GetValue(treeList1.Columns[2]).ToString();
                        exercices.Add(exercice);
                    }
                }
  
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                foreach (TreeListNode node in treeList1.Nodes)
                    foreach(TreeListNode childNode in node.Nodes) 
                            childNode.SetValue(0, true);
            }
            else
            {
                foreach (TreeListNode node in treeList1.Nodes)
                    foreach(TreeListNode childNode in node.Nodes) 
                            childNode.SetValue(0, false);
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var ParametressIndems = new ParamètresIndemnité(Session))
            {
                var result = ParametressIndems.ShowDialog();
                if (result == DialogResult.OK)
                {
                    parametresIndem = ParametressIndems.parametresIndem;
                    valeures = ParametressIndems.valeures;
                    optionsAvancees = true;
                }
            }
        }
    }
}
