//#define PROTECTION 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp;
using System.Windows.Forms;
using DevExpress.ExpressApp.Xpo;
using System.Data.SqlClient;
using MaPayeAdmin.Module;
using System.Configuration;
using DevExpress.Data.Filtering;
using MaPaye.Module;
using MaPayeAdmin;
using System.Data.SQLite;
using System.Data.Common;

namespace MaPaye.Win
{
#if PROTECTION
    public partial class MaPayeWindowsFormsApplication : LSWinApplication
#else
    public partial class MaPayeWindowsFormsApplication : WinApplication
#endif
    {
        public MaPayeWindowsFormsApplication()
        {
            InitializeComponent();
            InitializeComponentLS();
            DelayedViewItemsInitialization = true;
        }

        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args)
        {
            args.ObjectSpaceProvider = new XPObjectSpaceProvider(args.ConnectionString, args.Connection);
        }

        private void MaPayeWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e)
        {
#if EASYTEST
			e.Updater.Update();
			e.Handled = true;
#else
            //if (System.Diagnostics.Debugger.IsAttached)
            //{
            e.Updater.Update();
            e.Handled = true;

            IObjectSpace objectSpace = ((WinApplication)sender).ObjectSpaceProvider.CreateObjectSpace(); 
            //}
            //else
            //{
            //    throw new InvalidOperationException(
            //        "The application cannot connect to the specified database, because the latter doesn't exist or its version is older than that of the application.\r\n" +
            //        "This error occurred  because the automatic database update was disabled when the application was started without debugging.\r\n" +
            //        "To avoid this error, you should either start the application under Visual Studio in debug mode, or modify the " +
            //        "source code of the 'DatabaseVersionMismatch' event handler to enable automatic database update, " +
            //        "or manually create a database using the 'DBUpdater' tool.\r\n" +
            //        "Anyway, refer to the 'Update Application and Database Versions' help topic at http://www.devexpress.com/Help/?document=ExpressApp/CustomDocument2795.htm " +
            //        "for more detailed information. If this doesn't help, please contact our Support Team at http://www.devexpress.com/Support/Center/");
            //} 
#endif

        }

        public static T GetSetting<T>(string SettingName)
        {
            return (T)Properties.Settings.Default[SettingName];
        }

        public static void SetSetting<T>(string SettingName, T SettingValue)
        {
            Properties.Settings.Default[SettingName] = SettingValue;
            Properties.Settings.Default.Save();
        }

        //private void application_CreateCustomLogonWindowObjectSpace(object sender, CreateCustomLogonWindowObjectSpaceEventArgs e)
        //{
        //    if (e.LogonParameters != null)
        //        if (e.LogonParameters.GetType() == typeof(CustomLogonParameter))
        //        {
        //            XPObjectSpaceProvider objectspaceprovider = new XPObjectSpaceProvider(string.Format("Integrated Security=false;Pooling=false;Data Source=" +
        //            "{0}{1};Initial Catalog=LSAdmin;User ID=sa;Password=58206670", Helper.serverName, Helper.instanceName), new SqlConnection());
        //            e.ObjectSpace = (XPObjectSpace)objectspaceprovider.CreateObjectSpace();
        //            ((CustomLogonParameter)e.LogonParameters).objectspace = e.ObjectSpace;
        //        }
        //}

        private void application_CreateCustomLogonWindowObjectSpace(object sender, CreateCustomLogonWindowObjectSpaceEventArgs e)
        {
            if (e.LogonParameters != null)
                if (e.LogonParameters.GetType() == typeof(CustomLogonParameter))
                {
                    string maPayAdminCS = string.Empty;
                    DbConnection connection = null;
                    if (lsactvtn.ActivationClass.réseau)
                    {
                        maPayAdminCS = string.Format("Integrated Security=false;Pooling=false;Data Source={0}{1};" +
                            "Initial Catalog=MaPayeAdmin;User ID=sa;Password=58206670", Helper.serverName, Helper.instanceName);
                        connection = new SqlConnection();
                    }
                    else
                    {
                        maPayAdminCS = string.Format("XpoProvider=SQLite;Data Source={0}\\MaPayeAdmin", Core.GetApplicationPath());
                        connection = new SQLiteConnection();
                    }
                    XPObjectSpaceProvider objectspaceprovider = new XPObjectSpaceProvider(maPayAdminCS, connection);

                    e.ObjectSpace = (XPObjectSpace)objectspaceprovider.CreateObjectSpace();
                    ((CustomLogonParameter)e.LogonParameters).objectspace = e.ObjectSpace;
                }
        }

        protected override void OnCreateCustomObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args)
        {
            args.ObjectSpaceProvider = new DevExpress.ExpressApp.Xpo.XPObjectSpaceProvider(args.ConnectionString, args.Connection);
        }

        static void AddConnectionString(string connection_string)
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringsSection connectionStringsSection = configuration.ConnectionStrings;
            if (connectionStringsSection.ConnectionStrings["ConnectionString"] == null)
                connectionStringsSection.ConnectionStrings.Add(new ConnectionStringSettings("ConnectionString", connection_string));
            else
                connectionStringsSection.ConnectionStrings["ConnectionString"].ConnectionString = connection_string;
            configuration.Save(ConfigurationSaveMode.Minimal);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        private void winApplication_LoggingOn(object sender, LogonEventArgs e)
        { 
            if (e.LogonParameters != null)
            {
                if (e.LogonParameters.GetType() == typeof(CustomLogonParameter))
                {
                    Exercice database = ((CustomLogonParameter)((WinApplication)sender).Security.LogonParameters).database;
                    if (database != null)
                    {
                        if (lsactvtn.ActivationClass.réseau)
                            AddConnectionString(string.Format("Integrated Security=false;Pooling=false;Data Source={0}{1};Initial Catalog={2};User ID=sa;Password=58206670",
                                Helper.serverName, Helper.instanceName, database));
                        else
                            AddConnectionString(string.Format(@"XpoProvider=SQLite;Data Source={0}\Data\{1}\{2}", Core.GetApplicationPath(), database.dossier.code_dossier, database.db_name));
                        ((WinApplication)sender).ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    }
                    else
                    {
                        if (lsactvtn.ActivationClass.réseau)
                            ((WinApplication)sender).ConnectionString = string.Format("Integrated Security=false;Pooling=false;Data Source={0}{1};Initial Catalog=MaPaye;User ID=sa;Password=58206670",
                                Helper.serverName, Helper.instanceName);
                        else
                            ((WinApplication)sender).ConnectionString = string.Format(@"XpoProvider=SQLite;Data Source={0}\MaPaye", Core.GetApplicationPath());
                    }
                }
            }
        }

        public override IObjectSpace GetObjectSpaceToShowDetailViewFrom(Frame sourceFrame, Type objectType)
        { 
            IObjectSpace objectspace = null;
            if (sourceFrame.View.ObjectTypeInfo.Type == typeof(Dossier) || sourceFrame.View.ObjectTypeInfo.Type == typeof(Exercice))
            {
                string maPayAdminCS = string.Empty;
                DbConnection connection = null;
                if (lsactvtn.ActivationClass.réseau)
                {
                    maPayAdminCS = string.Format("Integrated Security=false;Pooling=false;Data Source={0}{1};" +
                        "Initial Catalog=MaPayeAdmin;User ID=sa;Password=58206670", Helper.serverName, Helper.instanceName);
                    connection = new SqlConnection();
                }
                else
                {
                    maPayAdminCS = string.Format("XpoProvider=SQLite;Data Source={0}\\MaPayeAdmin", Core.GetApplicationPath());
                    connection = new SQLiteConnection();
                }
                XPObjectSpaceProvider objectspaceprovider = new XPObjectSpaceProvider(maPayAdminCS, connection);
                objectspace = objectspaceprovider.CreateObjectSpace();
            }
            else
                objectspace = base.GetObjectSpaceToShowDetailViewFrom(sourceFrame, objectType);
            return objectspace;
        }

        protected override void OnListViewCreating(ListViewCreatingEventArgs args)
        { 
            base.OnListViewCreating(args);
            if (((args.IsRoot) && (args.ViewID == "Dossier_ListView")) |
                ((!args.IsRoot) && (args.ViewID == "Dossier_LookupListView")) |
                ((args.IsRoot) && (args.ViewID == "Exercice_ListView")) |
                ((!args.IsRoot) && (args.ViewID == "Exercice_LookupListView")))
            {
                bool IsMaPayeAdmin = false;
                if(lsactvtn.ActivationClass.réseau)
                    IsMaPayeAdmin = (((XPObjectSpace)args.ObjectSpace).Connection.Database == "MaPayeAdmin" && lsactvtn.ActivationClass.réseau);
                else
                    IsMaPayeAdmin = (((SQLiteConnection)((XPObjectSpace)args.ObjectSpace).Connection).DataSource == "MaPayeAdmin" && !(lsactvtn.ActivationClass.réseau));

                if (!IsMaPayeAdmin)
                {
                    string maPayAdminCS = string.Empty;
                    DbConnection connection = null;
                    if (lsactvtn.ActivationClass.réseau)
                    {
                        maPayAdminCS = string.Format("Integrated Security=false;Pooling=false;Data Source={0}{1};" +
                            "Initial Catalog=MaPayeAdmin;User ID=sa;Password=58206670", Helper.serverName, Helper.instanceName);
                        connection = new SqlConnection();
                    }
                    else
                    {
                        maPayAdminCS = string.Format("XpoProvider=SQLite;Data Source={0}\\MaPayeAdmin", Core.GetApplicationPath());
                        connection = new SQLiteConnection();
                    }
                    XPObjectSpaceProvider objectspaceprovider = new XPObjectSpaceProvider(maPayAdminCS, connection);
                    XPObjectSpace objectspace = (XPObjectSpace)objectspaceprovider.CreateObjectSpace();
                    if ((args.ViewID == "Dossier_ListView") | (args.ViewID == "Exercice_ListView"))
                    {
                        args.View = CreateListView(objectspace, args.CollectionSource.ObjectTypeInfo.Type, false);
                        args.View.IsRoot = true;
                    }
                    else
                    {
                        args.View = CreateListView(objectspace, args.CollectionSource.ObjectTypeInfo.Type, true);
                        args.View.IsRoot = false;
                        args.View.AllowNew.SetItemValue("", false);
                    }
                }
            }
        }

        private void LSWinApplication_LastLogonParametersRead(object sender, LastLogonParametersReadEventArgs e)
        {
            if (e.LogonObject != null)
                if (e.LogonObject.GetType() == typeof(CustomLogonParameter))
                {
                    Exercice last_db = ((CustomLogonParameter)e.LogonObject).objectspace.FindObject<Exercice>(CriteriaOperator.Parse("db_name=?",
                        e.SettingsStorage.LoadOption("", "database")));
                    ((CustomLogonParameter)e.LogonObject).database = last_db;
                }
        }

        private void WinApplication_LastLogonParametersWriting(object sender, LastLogonParametersWritingEventArgs e)
        {
            if (e.LogonObject != null)
                if (e.LogonObject.GetType() == typeof(CustomLogonParameter))
                {
                    Exercice last_db = ((CustomLogonParameter)e.LogonObject).database;
                    if (last_db != null)
                        e.SettingsStorage.SaveOption("", "database", last_db.db_name);
                }
        }

        public bool serverReachable = false, stopTrying = false, modeleRestored = false;

        protected override void OnLoggedOn(LogonEventArgs args)
        {
            if (!lsactvtn.ActivationClass.Demo)
            {
                base.OnLoggedOn(args);
                if (((CustomLogonParameter)Security.LogonParameters).database != null)
                    Model.Application.Title = "MaPaye - " + ((CustomLogonParameter)Security.LogonParameters).database.db_name;
                else
                    Model.Application.Title = "MaPaye";
            }
            else
            {
                base.OnLoggedOn(args);
                Model.Application.Title = "MaPaye - Exercice Modele";
            }
        }

    }
}
