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
using System.Data.SqlClient;
using System.Data.SQLite; 

namespace MaPaye.Module
{
    public class Core
    {
        public static void UpdateMaPayeAdminDB()
        {
            string connectionString = string.Format("Integrated Security=false;Pooling=false;Data Source=" +
                "{0}{1};Initial Catalog=LSAdmin;User ID=sa;Password=58206670", Helper.serverName, Helper.instanceName);
            IDataLayer dl;
            try
            {
                dl = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            }
            catch (UnableToOpenDatabaseException ex)
            {
                Server server = new Server(string.Format("{0}{1}", Helper.serverName, Helper.instanceName));
                Database MaPayeAdmin = new Database(server, "LSAdmin");
                MaPayeAdmin.Create();
                dl = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            }
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

        public static DataTable FetchData(string query, IDbConnection connection, bool network)
        {
            DataTable result = new DataTable();
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
            result.Select("name <> 'GCRecord' And  name <> 'Oid' And name <> 'OptimisticLockField'", "name");
            return result;
        }

    }
}
