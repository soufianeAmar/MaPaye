using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Xml;
using Microsoft.SqlServer.Management.Common;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using System.Windows.Forms;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Persistent.BaseImpl;
using System.Reflection;
using DevExpress.Data.Filtering;
using System.Data.OleDb;

namespace LSWinModule
{
    public enum SGBD { SQLSERVER, MSACCESS }

    public class Core
    {
        public enum Logiciel
        {
            EUREKA = 1, LSPAYE, LSCOMPTA, KIRAA, PERSO, WINPARC, RATEB, GDS, CLASTOU, SCOLARITE, INSEMINATEUR, EVIREMENT, PROLIGUE,
            IMPRIMCHEQUE, KADAYA, NOTAIRE, BUDGET
        }

        public enum TypeExercice { Année, Désignation }

        public class ApplicationSettings
        {
            public string ServerName;
            public string Instance;
            public SGBD sgbd;
            public Logiciel logiciel;
            public TypeExercice type_exercice = TypeExercice.Année;
            public string reference_client;
            public string version;
            public int nombre_LAC;
            public int nombre_dossiers;
            public int exercices_par_dossier = -1;
            public int nombre_enregistrement;
            public DateTime expiration_contrat;
            public ApplicationSettings(string serverResponse, Logiciel logicielApp, string Serveur, string instance, SGBD typeSGBD)
            {
                ServerName = Serveur;
                Instance = instance;
                sgbd = typeSGBD;
                logiciel = logicielApp;
                string[] responselist = serverResponse.Split('#');
                reference_client = responselist[0];
                version = responselist[1];
                nombre_LAC = Convert.ToInt32(responselist[2]);
                nombre_dossiers = Convert.ToInt32(responselist[3]);
                nombre_enregistrement = Convert.ToInt32(responselist[4]);
                expiration_contrat = DateTime.Today;
                //expiration_contrat = DateTime.Parse(string.Format("01/{0}/{1}", responselist[5].Substring(0, 2), 
                //    responselist[5].Substring(2,2)));

            }
            public ApplicationSettings(string serverResponse, Logiciel logicielApp, string Serveur, string instance, SGBD typeSGBD, 
                TypeExercice type_exercice)
            {
                ServerName = Serveur;
                Instance = instance;
                sgbd = typeSGBD;
                logiciel = logicielApp;
                this.type_exercice = type_exercice;
                string[] responselist = serverResponse.Split('#');
                reference_client = responselist[0];
                version = responselist[1];
                nombre_LAC = Convert.ToInt32(responselist[2]);
                nombre_dossiers = Convert.ToInt32(responselist[3]);
                nombre_enregistrement = Convert.ToInt32(responselist[4]);
                expiration_contrat = DateTime.Today;
            }
            public ApplicationSettings(string serverResponse, int nombre_exercice, Logiciel logicielApp, string Serveur, 
                string instance, SGBD typeSGBD)
            {
                ServerName = Serveur;
                Instance = instance;
                sgbd = typeSGBD;
                logiciel = logicielApp;
                string[] responselist = serverResponse.Split('#');
                reference_client = responselist[0];
                version = responselist[1];
                nombre_LAC = Convert.ToInt32(responselist[2]);
                nombre_dossiers = Convert.ToInt32(responselist[3]);
                nombre_enregistrement = Convert.ToInt32(responselist[4]);
                expiration_contrat = DateTime.Today;
                exercices_par_dossier = nombre_exercice;
            }
            public ApplicationSettings(string serverResponse, int nombre_exercice, Logiciel logicielApp, string Serveur, 
                string instance, SGBD typeSGBD, TypeExercice type_exercice)
            {
                ServerName = Serveur;
                Instance = instance;
                sgbd = typeSGBD;
                logiciel = logicielApp;
                this.type_exercice = type_exercice;
                string[] responselist = serverResponse.Split('#');
                reference_client = responselist[0];
                version = responselist[1];
                nombre_LAC = Convert.ToInt32(responselist[2]);
                nombre_dossiers = Convert.ToInt32(responselist[3]);
                nombre_enregistrement = Convert.ToInt32(responselist[4]);
                expiration_contrat = DateTime.Today;
                exercices_par_dossier = nombre_exercice;
            }
        }

        public static ApplicationSettings app_settings;

        public static string GetFilePath(string FileName)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(FileName);
            if (fi != null)
            {
                if (fi.DirectoryName.EndsWith("\\"))
                    return fi.DirectoryName;
                else
                    return string.Format("{0}\\", fi.DirectoryName);
            }
            else
                return null;
        }

        public static void CreateDatabase(string database)
        {
            Server server = new Server();
            Database db = new Database(server, database);
            if (!server.Databases.Contains(database))
                db.Create();
            else
                throw new Exception("Base de données existante !");
        }

        public static void CreateServerDatabase(string serverName, string database)
        {
            Server server = new Server(serverName);
            Database db = new Database(server, database);
            if (!server.Databases.Contains(database))
                db.Create();
            else
                throw new Exception("Base de données existante !");
        }

        public static void CreateDatabaseFromBackup(string database, string bkfileName)
        {
            Server server = new Server();
            Database db = new Database(server, database);
            if (!server.Databases.Contains(database))
            {
                Restore restore = new Restore()
                {
                    Database = database,
                    Action = RestoreActionType.Database,
                    ReplaceDatabase = true,
                };
                restore.Devices.Add(new BackupDeviceItem(bkfileName, DeviceType.File));
                server.KillAllProcesses(database);
                restore.SqlRestore(server);
            }
        }

        public static void CreateServerDatabaseFromBackup(string serverName, string database, string bkfileName)
        {
            Server server = new Server(serverName);
            Database db = new Database(server, database);
            if (!server.Databases.Contains(database))
            {
                Restore restore = new Restore()
                {
                    Database = database,
                    Action = RestoreActionType.Database,
                    ReplaceDatabase = true,
                };
                restore.Devices.Add(new BackupDeviceItem(bkfileName, DeviceType.File));
                server.KillAllProcesses(database);
                restore.SqlRestore(server);
            }
        }

        public static void CreateDatabaseInPath(string database, string dataPath)
        {
            Server server = new Server();
            Database db = new Database(server, database);
            if (!server.Databases.Contains(database))
            {
                db.AutoShrink = false;
                db.FileGroups.Add(new FileGroup(db, "PRIMARY"));
                db.FileGroups[0].Files.Add(new DataFile(db.FileGroups[0], database, string.Format("{0}{1}.mdf", dataPath, database)) { Growth = 10, GrowthType = FileGrowthType.Percent });
                db.LogFiles.Add(new LogFile(db, string.Format("{0}_log", database), string.Format("{0}{1}_log.ldf", dataPath, database)) { Growth = 10, GrowthType = FileGrowthType.Percent });
                var script = db.Script();
                db.Create();
            }
            else
                throw new Exception("Base de données existante !");
        }

        public static void CreateServerDatabaseInPath(string serverName, string database, string dataPath)
        {
            Server server = new Server(serverName);
            Database db = new Database(server, database);
            if (!server.Databases.Contains(database))
            {
                db.AutoShrink = false;
                db.FileGroups.Add(new FileGroup(db, "PRIMARY"));
                db.FileGroups[0].Files.Add(new DataFile(db.FileGroups[0], database, string.Format("{0}{1}.mdf", dataPath, database)) { Growth = 10, GrowthType = FileGrowthType.Percent });
                db.LogFiles.Add(new LogFile(db, string.Format("{0}_log", database), string.Format("{0}{1}_log.ldf", dataPath, database)) { Growth = 10, GrowthType = FileGrowthType.Percent });
                var script = db.Script();
                db.Create();
            }
            else
                throw new Exception("Base de données existante !");
        }

        public static void CreateDatabaseFromBackupInPath(string database, string dataPath, string bkfileName)
        {
            Server server = new Server();
            Database db = new Database(server, database);
            if (!server.Databases.Contains(database))
            {
                Restore restore = new Restore()
                {
                    Database = database,
                    Action = RestoreActionType.Database,
                    ReplaceDatabase = true,
                };
                restore.Devices.Add(new BackupDeviceItem(bkfileName, DeviceType.File));
                DataTable dtFileList = restore.ReadFileList(server);
                string dbLogicalName = dtFileList.Rows[0][0].ToString();
                string dbPhysicalName = dtFileList.Rows[0][1].ToString();
                string logLogicalName = dtFileList.Rows[1][0].ToString();
                string logPhysicalName = dtFileList.Rows[1][1].ToString();
                restore.RelocateFiles.Add(new RelocateFile(dbLogicalName, string.Format("{0}{1}.mdf", dataPath, database)));
                restore.RelocateFiles.Add(new RelocateFile(logLogicalName, string.Format("{0}{1}_log.ldf", dataPath, database)));
                server.KillAllProcesses(database);
                restore.SqlRestore(server);
            }
        }

        public static void CreateServerDatabaseFromBackupInPath(string serverName, string database, string dataPath, string bkfileName)
        {
            Server server = new Server(serverName);
            Database db = new Database(server, database);
            if (!server.Databases.Contains(database))
            {
                Restore restore = new Restore()
                {
                    Database = database,
                    Action = RestoreActionType.Database,
                    ReplaceDatabase = true,
                };
                restore.Devices.Add(new BackupDeviceItem(bkfileName, DeviceType.File));
                DataTable dtFileList = restore.ReadFileList(server);
                string dbLogicalName = dtFileList.Rows[0][0].ToString();
                string dbPhysicalName = dtFileList.Rows[0][1].ToString();
                string logLogicalName = dtFileList.Rows[1][0].ToString();
                string logPhysicalName = dtFileList.Rows[1][1].ToString();
                restore.RelocateFiles.Add(new RelocateFile(dbLogicalName, string.Format("{0}{1}.mdf", dataPath, database)));
                restore.RelocateFiles.Add(new RelocateFile(logLogicalName, string.Format("{0}{1}_log.ldf", dataPath, database)));
                server.KillAllProcesses(database);
                restore.SqlRestore(server);
            }
        }

        public static void BackupDatabase(string serverName, string database, string fileName)
        {
            Backup backup = new Backup()
            {
                Database = database,
                Action = BackupActionType.Database,
                Initialize = true
            };
            backup.Devices.Add(new BackupDeviceItem(fileName, DeviceType.File));
            Server server = new Server(serverName);
            backup.SqlBackup(server);
        }

        public static void RestoreDatabase(string serverName, string database, string fileName)
        {
            Restore restore = new Restore()
            {
                Database = database,
                Action = RestoreActionType.Database,
                ReplaceDatabase = true,
            };
            restore.Devices.Add(new BackupDeviceItem(fileName, DeviceType.File));
            Server server = new Server(serverName);
            Database db = server.Databases[database];
            DataTable dtFileList = restore.ReadFileList(server);
            string dbLogicalName = dtFileList.Rows[0][0].ToString();
            string dbPhysicalName = dtFileList.Rows[0][1].ToString();
            string logLogicalName = dtFileList.Rows[1][0].ToString();
            string logPhysicalName = dtFileList.Rows[1][1].ToString();

            restore.RelocateFiles.Add(new RelocateFile(dbLogicalName, db.FileGroups[0].Files[0].FileName));
            restore.RelocateFiles.Add(new RelocateFile(logLogicalName, db.LogFiles[0].FileName));
            server.KillAllProcesses(database);
            restore.SqlRestore(server);
        }

        public static ReadOnlyCollection<T> GetReadOnlyCollection<T>(DevExpress.Xpo.XPCollection<T> xpcollection)
        {
            List<T> list = new List<T>();
            foreach (T obj in xpcollection)
                list.Add(obj);
            return list.AsReadOnly();
        }

        public static bool IsLimited(Type type)
        {
            LimitedAttribute IsLimitedAttrib = (LimitedAttribute)Attribute.GetCustomAttribute(type, typeof(LimitedAttribute));
            return (IsLimitedAttrib != null);
        }

        public static void AddProjectSettingsAsString(string SettingName, string SettingValue, bool overwrite)
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            UserSettingsGroup usg = (UserSettingsGroup)configuration.SectionGroups["userSettings"];
            if (usg == null)
            {
                usg = new UserSettingsGroup();
                configuration.SectionGroups.Add("userSettings", usg);
            }
            var userSettingsSectionName = string.Format("{0}.Properties.Settings", System.Windows.Forms.Application.ProductName);
            ClientSettingsSection userSettings = (ClientSettingsSection)usg.Sections[userSettingsSectionName];
            if (userSettings == null)
            {
                userSettings = new ClientSettingsSection();
                usg.Sections.Add(userSettingsSectionName, userSettings);
            }
            SettingElement se = userSettings.Settings.Get(SettingName);
            if (se == null)
            {
                se = new SettingElement(SettingName, SettingsSerializeAs.String);
                se.Value = new SettingValueElement();
                var xmlDoc = new XmlDocument();
                se.Value.ValueXml = xmlDoc.CreateElement("value");
                se.Value.ValueXml.InnerXml = SettingValue;
                userSettings.Settings.Add(se);
            }
            else
                if (overwrite)
                    se.Value.ValueXml.InnerXml = SettingValue;
            userSettings.SectionInformation.ForceSave = true;
            configuration.Save(ConfigurationSaveMode.Minimal);
        }
        public static DialogResult dialogResult;
        private static void dc_Accepting(object sender, DialogControllerAcceptingEventArgs e)
        {
            dialogResult = DialogResult.OK;
        }
        public static DialogResult ShowDialog(XafApplication application, IObjectSpace os, object obj)
        {
            ShowViewParameters svp = new ShowViewParameters();
            svp.CreatedView = application.CreateDetailView(os, obj, false);
            svp.TargetWindow = TargetWindow.NewModalWindow;
            svp.Context = TemplateContext.PopupWindow;
            svp.CreateAllControllers = true;
            DialogController dc = application.CreateController<DialogController>();
            svp.Controllers.Add(dc);
            dc.Accepting += dc_Accepting;
            dialogResult = DialogResult.Cancel;
            application.ShowViewStrategy.ShowView(svp, new ShowViewSource(null, null));
            return dialogResult;
        }
        public static IObjectSpace CreateObjectSpace(string filename)
        {
            XPObjectSpaceProvider objectspaceprovider = new XPObjectSpaceProvider(string.Format("XpoProvider=XmlDataSet;Data Source={0};Read Only=false", filename), new OleDbConnection());
            return objectspaceprovider.CreateObjectSpace();
        }
        public static IObjectSpace CreateObjectSpace(string server, string database)
        {
            XPObjectSpaceProvider objectspaceprovider = new XPObjectSpaceProvider(string.Format("Integrated Security=false;Pooling=false;Data Source={0};Initial Catalog={1};User ID=sa;Password=58206670",
            server, database), new SqlConnection());
            return objectspaceprovider.CreateObjectSpace();
        }
        public static IObjectSpace CreateObjectSpace(string filename, bool Header, bool MixedData)
        {
            string HDR = Header ? "HDR=Yes;" : "HDR=No;";
            string IMEX = MixedData ? "Imex=2;" : "Imex=1;";
            XPObjectSpaceProvider objectspaceprovider = new XPObjectSpaceProvider(string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Excel 8.0;{1}{2}", filename, HDR, IMEX), 
                new OleDbConnection());
            return objectspaceprovider.CreateObjectSpace();
        }
        public static string GetObjectIDMember(Type ObjectType)
        {
            var MemberInfoArray = ObjectType.GetMembers();
            int i = 0;
            bool found = false;
            while ((i < MemberInfoArray.Length) && (! found))
            {
                IDAttribute a = (IDAttribute)Attribute.GetCustomAttribute(MemberInfoArray[i], typeof(IDAttribute));
                found = a != null;
                if (!found)
                    i++;
            }
            if (found)
                return MemberInfoArray[i].Name;
            else
                return string.Empty;
        }
        public static object GetObjectByID(Session session, Type ObjectType, object value)
        {
            //var MemberInfoArray = ObjectType.GetMembers();
            //int i = 0;
            //bool found = false;
            object obj = null;
            //while ((i < MemberInfoArray.Length) && (!found))
            //{
            //    IDAttribute a = (IDAttribute)Attribute.GetCustomAttribute(MemberInfoArray[i], typeof(IDAttribute));
            //    found = a != null;
            //    if (!found)
            //        i++;
            //}
            //if (found)
            var IDName = GetObjectIDMember(ObjectType);
            if (IDName != null)
                obj = session.FindObject(ObjectType, CriteriaOperator.Parse(string.Format("{0} = ?", IDName), value));
            return obj;
        }
        public static void ImporterObjet<T>(string db_source, string db_destination)
        {
            XPObjectSpace os_source = (XPObjectSpace)CreateObjectSpace(string.Format("{0}{1}",
                app_settings.ServerName, app_settings.Instance), db_source);
            XPObjectSpace os_destination = (XPObjectSpace)CreateObjectSpace(string.Format("{0}{1}",
                app_settings.ServerName, app_settings.Instance), db_destination);
            XPCollection<T> collection = new XPCollection<T>(os_source.Session);
            foreach (T element in collection)
            {
                var obj = os_destination.CreateObject(typeof(T));
                foreach (XPMemberInfo mi in ((BaseObject)obj).ClassInfo.PersistentProperties)
                {
                    if (((BaseObject)((object)element)).ClassInfo.GetPersistentMember(mi.Name) != null)
                    {
                        if (mi.Name != "oid")
                        {
                            if (!mi.MemberType.IsSubclassOf(typeof(BaseObject)))
                                mi.SetValue(obj, mi.GetValue(element));
                            else
                            {
                                string IDName = GetObjectIDMember(mi.MemberType);
                                //if (IDName != string.Empty)
                                //{
                                //    var sourceMemberValue = mi.GetValue(element);
                                //    if (sourceMemberValue != null)
                                //    {
                                //        var destinationMemberValue = os_destination.FindObject(mi.MemberType,
                                //             CriteriaOperator.Parse(string.Format("{0} = ?", IDName),
                                //             ((BaseObject)sourceMemberValue).GetMemberValue(IDName)));
                                //        mi.SetValue(obj, destinationMemberValue);
                                //    }
                                //}
                                if ((IDName != string.Empty) && (mi.GetValue(element) != null))
                                    mi.SetValue(obj, GetObjectByID(os_destination.Session, mi.MemberType,
                                        ((BaseObject)mi.GetValue(element)).GetMemberValue(IDName)));
                            }
                        }
                    }
                }
                ((BaseObject)obj).Save();
            }
            os_destination.CommitChanges();
        }
        public static void ImporterObjet<T>(string db_source, string db_destination, CriteriaOperator criteria)
        {
            XPObjectSpace os_source = (XPObjectSpace)CreateObjectSpace(string.Format("{0}{1}",
                app_settings.ServerName, app_settings.Instance), db_source);
            XPObjectSpace os_destination = (XPObjectSpace)CreateObjectSpace(string.Format("{0}{1}",
                app_settings.ServerName, app_settings.Instance), db_destination);
            XPCollection<T> collection = new XPCollection<T>(os_source.Session, criteria);
            foreach (T element in collection)
            {
                var obj = os_destination.CreateObject(typeof(T));
                foreach (XPMemberInfo mi in ((BaseObject)obj).ClassInfo.PersistentProperties)
                {
                    if (((BaseObject)((object)element)).ClassInfo.GetPersistentMember(mi.Name) != null)
                    {
                        //if (((BaseObject)((object)element)).ClassInfo.GetPersistentMember(mi.Name).MemberType == mi.MemberType)
                        if (mi.Name != "oid")
                        {
                            if (!mi.MemberType.IsSubclassOf(typeof(BaseObject)))
                                mi.SetValue(obj, mi.GetValue(element));
                            else
                            {
                                string IDName = GetObjectIDMember(mi.MemberType);
                                //if (IDName != string.Empty)
                                //{
                                //    var sourceMemberValue = mi.GetValue(element);
                                //    if (sourceMemberValue != null)
                                //    {
                                //        var destinationMemberValue = os_destination.FindObject(mi.MemberType,
                                //            CriteriaOperator.Parse(string.Format("{0} = ?", IDName),
                                //            ((BaseObject)sourceMemberValue).GetMemberValue(IDName)));
                                //        mi.SetValue(obj, destinationMemberValue);
                                //    }
                                //}
                                if ((IDName != string.Empty) && (mi.GetValue(element) != null))
                                    mi.SetValue(obj, GetObjectByID(os_destination.Session, mi.MemberType,
                                        ((BaseObject)mi.GetValue(element)).GetMemberValue(IDName)));
                            }
                        }
                    }
                }
                ((BaseObject)obj).Save();
            }
            os_destination.CommitChanges();
        }
        public static void ImporterObjet<T>(XPObjectSpace os_source, XPObjectSpace os_destination, CriteriaOperator criteria)
        {
            XPCollection<T> collection = new XPCollection<T>(os_source.Session, criteria);
            foreach (T element in collection)
            {
                var obj = os_destination.CreateObject(typeof(T));
                foreach (XPMemberInfo mi in ((BaseObject)obj).ClassInfo.PersistentProperties)
                {
                    if (((BaseObject)((object)element)).ClassInfo.GetPersistentMember(mi.Name) != null)
                    {
                        //if (((BaseObject)((object)element)).ClassInfo.GetPersistentMember(mi.Name).MemberType == mi.MemberType)
                        if (mi.Name != "oid")
                        {
                            if (!mi.MemberType.IsSubclassOf(typeof(BaseObject)))
                                mi.SetValue(obj, mi.GetValue(element));
                            else
                            {
                                string IDName = GetObjectIDMember(mi.MemberType);
                                if ((IDName != string.Empty) && (mi.GetValue(element) != null))
                                    mi.SetValue(obj, GetObjectByID(os_destination.Session, mi.MemberType,
                                        ((BaseObject)mi.GetValue(element)).GetMemberValue(IDName)));
                            }
                        }
                    }
                }
                ((BaseObject)obj).Save();
            }
            os_destination.CommitChanges();
        }
        public static object CreateObject<T>(XPObjectSpace os_destination, T source)
        {
            object obj = os_destination.CreateObject<T>();
            foreach (XPMemberInfo mi in ((BaseObject)obj).ClassInfo.PersistentProperties)
            {
                if (((BaseObject)((object)source)).ClassInfo.GetPersistentMember(mi.Name) != null)
                {
                    //if (((BaseObject)((object)source)).ClassInfo.GetPersistentMember(mi.Name).MemberType == mi.MemberType)
                    if (mi.Name != "oid")
                    {
                        if (!mi.MemberType.IsSubclassOf(typeof(BaseObject)))
                            mi.SetValue(obj, mi.GetValue(source));
                        else
                        {
                            string IDName = GetObjectIDMember(mi.MemberType);
                            if ((IDName != string.Empty) && (mi.GetValue(source) != null))
                                mi.SetValue(obj, GetObjectByID(os_destination.Session, mi.MemberType,
                                    ((BaseObject)mi.GetValue(source)).GetMemberValue(IDName)));
                        }
                    }
                }
            }
            return obj;
        }
    }
}
