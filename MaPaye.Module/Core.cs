using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.ExpressApp;
using Microsoft.SqlServer.Management.Smo;
using DevExpress.Xpo.DB.Exceptions;
using MaPayeAdmin.Module;
using DevExpress.Data.Filtering;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Sql;
using MaPayeAdmin;
using System.Data.Common;
using System.Data.SqlClient; 
using System.Data.SQLite;
using DevExpress.Xpo.Exceptions;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.ExpressApp.Reports;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.Win;
using DevExpress.XtraReports.UI;
using System.Collections;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.Native.Sql;

namespace MaPaye.Module
{
    public class Core
    {
        public static Session CoreSession = new Session();
        public static string Exercice = "";
        public static string Dossier = "";

        public static IList selectedObjects;

        public static void UpdateMaPayeAdminDB()
        {
            string connectionString = string.Empty;
            if (lsactvtn.ActivationClass.réseau)
                connectionString = string.Format("Integrated Security=false;Pooling=false;Data Source=" +
                   "{0}{1};Initial Catalog=MaPayeAdmin;User ID=sa;Password=58206670", Helper.serverName, Helper.instanceName);
            else
                connectionString = string.Format(@"XpoProvider=SQLite;Data Source={0}\MaPayeAdmin", GetApplicationPath());
            IDataLayer dl = null;
            try
            {
                dl = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            }
            catch (UnableToOpenDatabaseException)
            {
                if (lsactvtn.ActivationClass.réseau)
                {
                    Server server = new Server(string.Format("{0}{1}", Helper.serverName, Helper.instanceName));
                    Database MaPayeAdmin = new Database(server, "MaPayeAdmin");
                    MaPayeAdmin.Create();
                    dl = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
                }
            }
            catch (CannotFindAppropriateConnectionProviderException)
            {
                if (!File.Exists(string.Format(@"{0}\MaPayeAdmin", GetApplicationPath())))
                    File.Create(string.Format(@"{0}\MaPayeAdmin", GetApplicationPath()));
                dl = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            }
            if (dl != null)
                using (Session session = new Session(dl))
                {
                    dl.UpdateSchema(false, session.GetClassInfo(typeof(Dossier)), session.GetClassInfo(typeof(Exercice)));
                    session.CreateObjectTypeRecords(typeof(Dossier).Assembly);
                }
        }

        public static void CreateUserAdmin(IObjectSpace ObjectSpace)
        {
            SecuritySystemRole role = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "Administrateur"));
            if (role == null)
            {
                role = ObjectSpace.CreateObject<SecuritySystemRole>();
                role.Name = "Administrateur";
                //Create permissions and assign them to the role
                role.IsAdministrative = true;
                role.Save();
            }

            SecuritySystemUser user = ObjectSpace.FindObject<SecuritySystemUser>(new BinaryOperator("UserName", "Admin"));
            if (user == null)
            {
                user = ObjectSpace.CreateObject<SecuritySystemUser>();
                user.UserName = "Admin";
                // Make the user an administrator
                user.Roles.Add(role);
                // Set a password if the standard authentication type is used
                user.SetPassword("123");
                // Save the user to the database
                user.Save();
            }
            ObjectSpace.CommitChanges();
        }

        public static ReadOnlyCollection<T> GetReadOnlyCollection<T>(DevExpress.Xpo.XPCollection<T> xpcollection)
        {
            List<T> list = new List<T>();
            foreach (T obj in xpcollection)
                list.Add(obj);
            return list.AsReadOnly();
        }

        public static DataTable GetAvailableSQLServers()
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            DataTable dt = instance.GetDataSources();
            return dt;
        }

        public static DataTable FetchData(string tablename,string query, IDbConnection connection, bool network)
        {
            DataTable result = new DataTable(tablename);
            if (network)
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, (SqlConnection)connection);
                adapter.FillSchema(result, SchemaType.Source);
                adapter.Fill(result);
            }
            else
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, (SQLiteConnection)connection);
                adapter.FillSchema(result, SchemaType.Source);
                adapter.Fill(result);
            }
            return result;
        }

        public static IDbConnection GetAppConnection(bool network)
        {
           
            if (network)
            {
                string database = ((SqlConnection)CoreSession.Connection).Database; 
                string ConnectionString = string.Format("Integrated Security=false;Pooling=false;Data Source=" +
                   "{0}{1};Initial Catalog={2};User ID=sa;Password=58206670", Helper.serverName, Helper.instanceName, database);

                SqlConnection Connection = new SqlConnection(ConnectionString);
                return Connection;
            }
            else
            {
                string database = ((SQLiteConnection)CoreSession.Connection).DataSource;
                string dossier = database.Substring(0, database.Length - 4);
                string ConnectionString = string.Format("XpoProvider=SQLite;Data Source={0}\\{1}\\{2}", Core.GetApplicationPath(),dossier, database);
                DbConnection Connection = new SQLiteConnection(ConnectionString);
                return Connection;
            }
        }

        public static string GetApplicationPath()
        {
            string applicationPath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            return applicationPath;
        }

        private static void ImportBaremes(DataSet DS, SQLiteConnection connection, Session session)
        {
            DataTable DT = new DataTable();
            DT = DS.Tables[0];
            DataColumnCollection columns = DT.Columns;

            foreach (DataRow dr in DT.Rows)
            {
                CriteriaOperator condition1 = CriteriaOperator.Parse("CATEG=?", dr["CATEG"].ToString());
                Bareme Barem = session.FindObject<Bareme>(PersistentCriteriaEvaluationBehavior.InTransaction,
                    CriteriaOperator.And(condition1));

                if (Barem == null)
                {
                    Bareme Bareme = new Bareme(session);
                    foreach (PropertyInfo PropertyDs in typeof(Bareme).GetProperties())
                    {
                        if (PropertyDs.PropertyType != typeof(XPCollection) && PropertyDs.PropertyType != typeof(parametre))
                            if (columns.Contains(PropertyDs.Name))
                                if (!(dr[PropertyDs.Name] is DBNull))
                                    if (PropertyDs.Name != "CATEG")
                                        Bareme.SetMemberValue(PropertyDs.Name, dr[PropertyDs.Name]);
                                    else
                                        Bareme.SetMemberValue(PropertyDs.Name, dr[PropertyDs.Name].ToString());
                    }
                    Bareme.Save();
                }
            }
            session.CommitTransaction();
        }

        private static void ImportSitFam(DataSet DS, SQLiteConnection connection, Session session)
        {
            DataTable DT = new DataTable();
            DT = DS.Tables[1];
            DataColumnCollection columns = DT.Columns;

            foreach (DataRow dr in DT.Rows)
            {
                CriteriaOperator condition1 = CriteriaOperator.Parse("Sit_Fam_Lib_Fr=?", dr["Sit_Fam_Lib_Fr"].ToString());
                Situation_Familiale Sit = session.FindObject<Situation_Familiale>(PersistentCriteriaEvaluationBehavior.InTransaction,
                    CriteriaOperator.And(condition1));

                if (Sit == null)
                {
                    Situation_Familiale SitFam = new Situation_Familiale(session);
                    foreach (PropertyInfo PropertyDs in typeof(Situation_Familiale).GetProperties())
                    {
                        if (PropertyDs.PropertyType != typeof(XPCollection) && PropertyDs.PropertyType != typeof(parametre))
                            if (columns.Contains(PropertyDs.Name))
                                if (!(dr[PropertyDs.Name] is DBNull))
                                    SitFam.SetMemberValue(PropertyDs.Name, dr[PropertyDs.Name]);
                    }
                    SitFam.Save();
                }
            }
            session.CommitTransaction();
        }

        private static void ImportSitConj(DataSet DS, SQLiteConnection connection, Session session)
        {
            DataTable DT = new DataTable();
            DT = DS.Tables[2];
            DataColumnCollection columns = DT.Columns;

            foreach (DataRow dr in DT.Rows)
            {
                CriteriaOperator condition1 = CriteriaOperator.Parse("Sit_Conj_Lib_Fr=?", dr["Sit_Conj_Lib_Fr"].ToString());
                Situation_Conjoint Sit = session.FindObject<Situation_Conjoint>(PersistentCriteriaEvaluationBehavior.InTransaction,
                    CriteriaOperator.And(condition1));

                if (Sit == null)
                {
                    Situation_Conjoint SitConj = new Situation_Conjoint(session);
                    foreach (PropertyInfo PropertyDs in typeof(Situation_Conjoint).GetProperties())
                    {
                        if (PropertyDs.PropertyType != typeof(XPCollection) && PropertyDs.PropertyType != typeof(parametre))
                            if (columns.Contains(PropertyDs.Name))
                                if (!(dr[PropertyDs.Name] is DBNull))
                                    SitConj.SetMemberValue(PropertyDs.Name, dr[PropertyDs.Name]);
                    }
                    SitConj.Save();
                }
            }
            session.CommitTransaction();
        }

        private static void ImportSitEmp(DataSet DS, SQLiteConnection connection, Session session)
        {
            DataTable DT = new DataTable();
            DT = DS.Tables[3];
            DataColumnCollection columns = DT.Columns;

            foreach (DataRow dr in DT.Rows)
            {
                CriteriaOperator condition1 = CriteriaOperator.Parse("Sit_Emp_Lib_Fr=?", dr["Sit_Emp_Lib_Fr"].ToString());
                Situation_Employe Sit = session.FindObject<Situation_Employe>(PersistentCriteriaEvaluationBehavior.InTransaction,
                    CriteriaOperator.And(condition1));

                if (Sit == null)
                {
                    Situation_Employe SitEmp = new Situation_Employe(session);
                    foreach (PropertyInfo PropertyDs in typeof(Situation_Employe).GetProperties())
                    {
                        if (PropertyDs.PropertyType != typeof(XPCollection) && PropertyDs.PropertyType != typeof(parametre))
                            if (columns.Contains(PropertyDs.Name))
                                if (!(dr[PropertyDs.Name] is DBNull))
                                    SitEmp.SetMemberValue(PropertyDs.Name, dr[PropertyDs.Name]);
                    }
                    SitEmp.Save();
                }
            }
            session.CommitTransaction();
        }

        private static void ImportTypeAbs(DataSet DS, SQLiteConnection connection, Session session)
        {
            DataTable DT = new DataTable();
            DT = DS.Tables[4];
            DataColumnCollection columns = DT.Columns;

            foreach (DataRow dr in DT.Rows)
            {
                CriteriaOperator condition1 = CriteriaOperator.Parse("Type_Abs_Lib_Fr=?", dr["Type_Abs_Lib_Fr"].ToString());
                Type_Absence Type = session.FindObject<Type_Absence>(PersistentCriteriaEvaluationBehavior.InTransaction,
                    CriteriaOperator.And(condition1));

                if (Type == null)
                {
                    Type_Absence Type_Absence = new Type_Absence(session);
                    foreach (PropertyInfo PropertyDs in typeof(Type_Absence).GetProperties())
                    {
                        if (PropertyDs.PropertyType != typeof(XPCollection) && PropertyDs.PropertyType != typeof(parametre))
                            if (columns.Contains(PropertyDs.Name))
                                if (!(dr[PropertyDs.Name] is DBNull))
                                    Type_Absence.SetMemberValue(PropertyDs.Name, dr[PropertyDs.Name]);
                    }
                    Type_Absence.Save();
                }
            }
            session.CommitTransaction();
        }

        private static void ImportSexe(DataSet DS, SQLiteConnection connection, Session session)
        {
            DataTable DT = new DataTable();
            DT = DS.Tables[5];
            DataColumnCollection columns = DT.Columns;

            foreach (DataRow dr in DT.Rows)
            {
                CriteriaOperator condition1 = CriteriaOperator.Parse("Sexe_Lib_Fr=?", dr["Sexe_Lib_Fr"].ToString());
                Sexe sexe = session.FindObject<Sexe>(PersistentCriteriaEvaluationBehavior.InTransaction,
                    CriteriaOperator.And(condition1));

                if (sexe == null)
                {
                    Sexe Sexe = new Sexe(session);
                    foreach (PropertyInfo PropertyDs in typeof(Sexe).GetProperties())
                    {
                        if (PropertyDs.PropertyType != typeof(XPCollection) && PropertyDs.PropertyType != typeof(parametre))
                            if (columns.Contains(PropertyDs.Name))
                                if (!(dr[PropertyDs.Name] is DBNull))
                                    Sexe.SetMemberValue(PropertyDs.Name, dr[PropertyDs.Name]);
                    }
                    Sexe.Save();
                }
            }
            session.CommitTransaction();
        }

        private static void ImportIndemnites(DataSet DS, SQLiteConnection connection, Session session)
        {
            parametre Parametre = session.FindObject<parametre>(null);
            DataTable DT = new DataTable();
            DT = DS.Tables[6];
            DataColumnCollection columns = DT.Columns;

            foreach (DataRow dr in DT.Rows)
            {
                CriteriaOperator condition1 = CriteriaOperator.Parse("Cod_indem_interne=?", dr["Cod_indem_interne"].ToString());
                Indem Indem = session.FindObject<Indem>(PersistentCriteriaEvaluationBehavior.InTransaction,
                    CriteriaOperator.And(condition1));

                if (Indem == null)
                {
                    Indem Indemnite = new Indem(session);
                    foreach (PropertyInfo PropertyDs in typeof(Indem).GetProperties())
                    {
                        if (PropertyDs.PropertyType != typeof(XPCollection) && PropertyDs.PropertyType != typeof(parametre))
                            if (columns.Contains(PropertyDs.Name))
                                if (!(dr[PropertyDs.Name] is DBNull))
                                    Indemnite.SetMemberValue(PropertyDs.Name, dr[PropertyDs.Name]);
                    }
                    Indemnite.parametres = Parametre;
                    Indemnite.Save();
                }
            }
            session.CommitTransaction();
        }

        private static void ImportFonction(DataSet DS, SQLiteConnection connection, Session session)
        {
            DataTable DT = new DataTable();
            DT = DS.Tables[7];
            DataColumnCollection columns = DT.Columns;

            foreach (DataRow dr in DT.Rows)
            {
                CriteriaOperator condition1 = CriteriaOperator.Parse("Fct_Lib_Fr=?", dr["Fct_Lib_Fr"].ToString());
                Fonction Fnct = session.FindObject<Fonction>(PersistentCriteriaEvaluationBehavior.InTransaction,
                    CriteriaOperator.And(condition1));

                if (Fnct == null)
                {
                    Fonction Fonction = new Fonction(session);
                    foreach (PropertyInfo PropertyDs in typeof(Fonction).GetProperties())
                    {
                        if (PropertyDs.PropertyType != typeof(XPCollection) && PropertyDs.PropertyType != typeof(parametre))
                            if (columns.Contains(PropertyDs.Name))
                                if (!(dr[PropertyDs.Name] is DBNull))
                                    Fonction.SetMemberValue(PropertyDs.Name, dr[PropertyDs.Name]);
                    }
                    Fonction.Save();
                }
            }
            session.CommitTransaction();
        }

        private static void ImportModePaiement(DataSet DS, SQLiteConnection connection, Session session)
        {
            DataTable DT = new DataTable();
            DT = DS.Tables[9];
            DataColumnCollection columns = DT.Columns;

            foreach (DataRow dr in DT.Rows)
            {
                CriteriaOperator condition1 = CriteriaOperator.Parse("Type_Paiment_Lib_Fr=?", dr["Type_Paiment_Lib_Fr"].ToString());
                //CriteriaOperator condition2 = CriteriaOperator.Parse("ObjectTypeName=?", dr["ObjectTypeName"].ToString());
                Mode_Paiement mode = session.FindObject<Mode_Paiement>(PersistentCriteriaEvaluationBehavior.InTransaction,
                    CriteriaOperator.And(condition1));

                if (mode == null)
                {
                    Mode_Paiement Mode_Paiement = new Mode_Paiement(session);
                    foreach (PropertyInfo PropertyDs in typeof(Mode_Paiement).GetProperties())
                    {
                        if (PropertyDs.PropertyType != typeof(XPCollection) && PropertyDs.PropertyType != typeof(parametre))
                            if (columns.Contains(PropertyDs.Name))
                                if (!(dr[PropertyDs.Name] is DBNull))
                                    Mode_Paiement.SetMemberValue(PropertyDs.Name, dr[PropertyDs.Name]);
                    }
                    Mode_Paiement.Save();
                }
            }
            session.CommitTransaction();
        }

        public static void ImportData(Session session, Assembly assembly)
        {
            SQLiteConnection connection = new SQLiteConnection((SQLiteConnection)session.Connection);

            using (DataSet MaPayeDS = new DataSet("MaPayeData"))
            {
                using (Stream s = assembly.GetManifestResourceStream("MaPaye.Module.MaPayeData.xml"))
                {
                    MaPayeDS.ReadXml(s);
                    if (MaPayeDS != null)
                    {
                        ImportBaremes(MaPayeDS, connection, session);
                        ImportSitConj(MaPayeDS, connection, session);
                        ImportSitFam(MaPayeDS, connection, session);
                        ImportSitEmp(MaPayeDS, connection, session);
                        ImportSexe(MaPayeDS, connection, session);
                        ImportTypeAbs(MaPayeDS, connection, session);
                        ImportIndemnites(MaPayeDS, connection, session);
                        ImportFonction(MaPayeDS, connection, session);
                        ImportModePaiement(MaPayeDS, connection, session);
                    }
                }
            }
        }
         
        public static void ImportReports(Session session, Assembly assembly)
        { 
            List<string> resourceNames = new List<string>(assembly.GetManifestResourceNames());

            foreach (string s in resourceNames)
            {
                if (s.StartsWith("MaPaye.Module.Reports."))
                {
                    using (Stream S = assembly.GetManifestResourceStream(s))
                    {
                        XafReport rep = new XafReport();
                        rep.LoadLayout(S);

                        CriteriaOperator condition1 = CriteriaOperator.Parse("Name=?", rep.ReportName);
                        ReportData report = session.FindObject<ReportData>(PersistentCriteriaEvaluationBehavior.InTransaction,
                        CriteriaOperator.And(condition1));

                        if (report == null)
                        {

                            ReportData reportdata = new ReportData(session);
                            reportdata.SaveReport(rep);
                            reportdata.IsInplaceReport = true;
                            reportdata.Save();
                            session.CommitTransaction();
                        }
                    }
                }
            }
        }

        //public static void CreateReport(string Oid)
        //{

        //    //List<object> source = new List<object>();
        //    //Recape_Annuelle recape = CoreSession.FindObject<Recape_Annuelle>(CriteriaOperator.Parse("Oid==?", Oid));
        //    //source.Add(recape);

        //    XPCollection<Recape_Annuelle> recapes = new XPCollection<Recape_Annuelle>(CoreSession, CriteriaOperator.Parse("Oid=?", Oid));
        //    recapes.Load();

        //    ATS_P1 atsP1 = new ATS_P1();
        //    atsP1.Recape.Session = CoreSession;
        //    atsP1.DataSource = recapes;
        //    atsP1.CreateDocument();

        //    ATS_P2 atsP2 = new ATS_P2();
        //    atsP2.Recape.Session = CoreSession;
        //    atsP2.DataSource = recapes;
        //    atsP2.CreateDocument();

        //    //atsP1.Pages.AddRange(atsP2.Pages);
        //    ATS ats = new ATS();
        //    ats.CreateDocument();
        //    ats.DataSource = recapes;
        //    ats.Pages.AddRange(atsP1.Pages);
        //    ats.Pages.AddRange(atsP2.Pages);

          
        //    //ats.ShowPreview();
        //    string path = string.Format("D:\\ATS.repx");
        //    //{0}\\ATS.repx", Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath));
            
        //    ats.SaveLayout(path);
        //    ats.ClosePreview();
        //    //return ats;
        //}
    }
}
