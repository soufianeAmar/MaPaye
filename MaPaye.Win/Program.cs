using System;
using System.Configuration;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security; 
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.SystemModule;
using System.Data.SqlClient;
using System.Data;
using DevExpress.ExpressApp.Xpo;
using MaPaye.Module;
using MaPaye.Module.Win;

namespace MaPaye.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static string VersionGUID = "5ce82a42547d901a6164c4.10622957";
        [STAThread]
        static void Main(string[] argv)
        {
#if EASYTEST
			DevExpress.ExpressApp.EasyTest.WinAdapter.RemotingRegistration.Register(4100);
#endif

            //string nom_serveur = MaPayeWindowsFormsApplication.GetSetting<string>("ServerName");
            //bool ResetServer = false;
            if (Array.Exists<string>(argv, arg => arg == "/ResetServer"))
                ResetServer = true;
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached;

                Properties.Settings.Default.Reload();
                lsactvtn.ActivationClass.UpdateSilently();

                lsactvtn.ActivationClass.CheckTrialAndActivation(VersionGUID);
                if (!lsactvtn.ActivationClass.IsActivated(VersionGUID))
                {
                    throw new Exception(string.Empty);
                }


                {

                    Properties.Settings.Default.Reload();

                    MaPayeWindowsFormsApplication winApplication = new MaPayeWindowsFormsApplication();
                    //winApplication.CreateCustomTemplate += Application_CreateCustomTemplate;
                    winApplication.CreateCustomTemplate += delegate(object sender, CreateCustomTemplateEventArgs e)
                    {
                        if (e.Context == TemplateContext.ApplicationWindow)
                        {
                            e.Template = new MainRibbonForm();
                        }
                        else if (e.Context == TemplateContext.View)
                        {
                            e.Template = new DetailRibbonForm();
                        }
                    };
#if EASYTEST
			if(ConfigurationManager.ConnectionStrings["EasyTestConnectionString"] != null) {
				winApplication.ConnectionString = ConfigurationManager.ConnectionStrings["EasyTestConnectionString"].ConnectionString;
			}
#endif
                    //if (ConfigurationManager.ConnectionStrings["ConnectionString"] != null)
                    //{
                    //    winApplication.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    //}
                    try
                    {
                        winApplication.SplashScreen = new MySplash();
                        winApplication.Setup();

                        if (!lsactvtn.ActivationClass.réseau)
                        {
                            XPObjectSpace os = ((XPObjectSpace)winApplication.CreateObjectSpace());
                            os.Session.ExecuteNonQuery("PRAGMA case_sensitive_like = OFF");
                        }

                        if (!lsactvtn.ActivationClass.Demo)
                        {
                            Core.UpdateMaPayeAdminDB();
                            XPObjectSpace os = ((XPObjectSpace)winApplication.CreateObjectSpace());
                            Core.CreateUserAdmin(os); 
                        }

                        Core.UpdateMaPayeAdminDB();
                        winApplication.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.GridControlLocalizer));
                        
                        winApplication.Start();
                    }
                    catch (Exception e)
                    {
                        winApplication.HandleException(e);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message != string.Empty)
                    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool ResetServer = false;
    }
}
