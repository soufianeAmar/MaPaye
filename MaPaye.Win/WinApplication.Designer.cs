using MaPaye.Module;
using System.Windows.Forms;
using System.IO;
using System;
using MaPayeAdmin;
using DevExpress.Persistent.BaseImpl;
namespace MaPaye.Win
{
    partial class MaPayeWindowsFormsApplication
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null; 

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
            this.module2 = new DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule();
            this.module5 = new DevExpress.ExpressApp.Validation.ValidationModule();
            this.module6 = new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule();
            this.module7 = new DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule();
            this.securityModule1 = new DevExpress.ExpressApp.Security.SecurityModule();
            this.reportsWindowsFormsModule1 = new DevExpress.ExpressApp.Reports.Win.ReportsWindowsFormsModule();
            this.reportsModule1 = new DevExpress.ExpressApp.Reports.ReportsModule();
            this.fileAttachmentsWindowsFormsModule1 = new DevExpress.ExpressApp.FileAttachments.Win.FileAttachmentsWindowsFormsModule();
            this.conditionalAppearanceModule1 = new DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.systemModule1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
            this.systemModule2 = new DevExpress.ExpressApp.SystemModule.SystemModule();
            this.securityModule3 = new DevExpress.ExpressApp.Security.SecurityModule();
            this.module3 = new MaPaye.Module.MaPayeModule();
            this.module4 = new MaPaye.Module.Win.MaPayeWindowsFormsModule();
            this.securityStrategyComplex1 = new DevExpress.ExpressApp.Security.SecurityStrategyComplex();
            this.authenticationStandard1 = new DevExpress.ExpressApp.Security.AuthenticationStandard();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // module5
            // 
            this.module5.AllowValidationDetailsAccess = true;
            this.module5.IgnoreWarningAndInformationRules = false;
            // 
            // reportsModule1
            // 
            this.reportsModule1.EnableInplaceReports = true;
            this.reportsModule1.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.ReportData);
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // securityStrategyComplex1
            // 
            this.securityStrategyComplex1.Authentication = this.authenticationStandard1;
            this.securityStrategyComplex1.RoleType = typeof(DevExpress.ExpressApp.Security.Strategy.SecuritySystemRole);
            this.securityStrategyComplex1.UserType = typeof(DevExpress.ExpressApp.Security.Strategy.SecuritySystemUser);
            // 
            // authenticationStandard1
            // 
            this.authenticationStandard1.LogonParametersType = typeof(DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters);
            // 
            // MaPayeWindowsFormsApplication
            // 
            this.ApplicationName = "MaPaye";
            this.Connection = this.sqlConnection1;
            this.Modules.Add(this.module1);
            this.Modules.Add(this.module2);
            this.Modules.Add(this.module6);
            this.Modules.Add(this.module5);
            this.Modules.Add(this.conditionalAppearanceModule1);
            this.Modules.Add(this.module3);
            this.Modules.Add(this.module4);
            this.Modules.Add(this.module7);
            this.Modules.Add(this.securityModule1);
            this.Modules.Add(this.reportsModule1);
            this.Modules.Add(this.reportsWindowsFormsModule1);
            this.Modules.Add(this.fileAttachmentsWindowsFormsModule1);
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.GridControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.LayoutControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.NavBarControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.BarControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.RichEditControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.TreeListControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.VerticalGridControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.XtraEditorsLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.LargeStringEditFindFormLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.MainFormTemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.DetailViewFormTemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.NestedFrameTemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.LookupControlTemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.PopupFormTemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Reports.Win.ReportControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.MainRibbonFormV2TemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.DetailRibbonFormV2TemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.MainFormV2TemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.DetailFormV2TemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.DocumentManagerControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.DockManagerLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Security.ServerDataLogLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Localization.PreviewControlLocalizer));
            this.Security = this.securityStrategyComplex1;
            this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.MaPayeWindowsFormsApplication_DatabaseVersionMismatch);
            this.LastLogonParametersRead += new System.EventHandler<DevExpress.ExpressApp.LastLogonParametersReadEventArgs>(this.LSWinApplication_LastLogonParametersRead);
            this.LastLogonParametersWriting += new System.EventHandler<DevExpress.ExpressApp.LastLogonParametersWritingEventArgs>(this.WinApplication_LastLogonParametersWriting);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion
  
        void InitializeComponentLS()
        {

            if (lsactvtn.ActivationClass.Demo)
            {
                this.securityStrategyComplex1.Authentication = null;
            }
            else
            {
                this.authenticationStandard1.LogonParametersType = typeof(CustomLogonParameter);
            } 

            string path = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            //this.sqLiteConnection1.ConnectionString = string.Format("Data Source={0}\\MaPaye", path);
            //this.sqLiteConnection1.DefaultTimeout = 30;
            if (lsactvtn.ActivationClass.réseau)
            {
                string serverName = string.Empty;
                string instanceName = string.Empty;
                bool isServer = false, isLAC = false;
                if (Program.ResetServer)
                {
                    serverName = "";// "SERVEUR";
                    instanceName = @"\LEADERSOFT1";
                }
                else
                {
                    serverName = GetSetting<string>("ServerName");
                    if (string.IsNullOrEmpty(serverName))
                        serverName = System.Net.Dns.GetHostName();
                    instanceName = GetSetting<string>("InstanceName");
                }
                this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
        
                {
                    while ((!serverReachable) && (!stopTrying))
                    {
                        try
                        {
                            isServer = ((lsactvtn.ActivationClass.isServer) && ((serverName.Equals(System.Net.Dns.GetHostName(), StringComparison.OrdinalIgnoreCase) ||
                                (serverName == "") || (serverName == ".")))) || lsactvtn.ActivationClass.Demo;
                                isLAC = ((!lsactvtn.ActivationClass.isServer) && (!serverName.Equals(System.Net.Dns.GetHostName(), StringComparison.OrdinalIgnoreCase) &&
                                (serverName != "") && (serverName != ".")));
                            if (!isServer && !isLAC)
                                throw new Exception("Le serveur et / ou l'instance SQL Server spécifiés ne sont pas valides!");
                            this.sqlConnection1.ConnectionString = string.
                                Format("Integrated Security=false;Pooling=false;Data Source={0}{1};Initial Catalog=master;User ID=sa;Password=58206670",
                                serverName, instanceName);
                             this.sqlConnection1.Open();
                            serverReachable = true;
                            this.sqlConnection1.Close();
                            this.sqlConnection1.ConnectionString = string.
                                Format("Integrated Security=false;Pooling=false;Data Source={0}{1};Initial Catalog=MaPaye;User ID=sa;Password=58206670",
                                serverName, instanceName);
                            SetSetting<string>("ServerName", serverName);
                            SetSetting<string>("InstanceName", instanceName);
                            Helper.serverName = serverName;
                            Helper.instanceName = instanceName;
                            try
                            {
                                //CreateServerDatabaseFromBackup(serverName + instanceName, "WinParc", System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\Modele\modele.bak");
                                modeleRestored = true;
                            }
                            catch (Exception ex)
                            {
                                if (!serverName.Equals(System.Net.Dns.GetHostName(), StringComparison.OrdinalIgnoreCase))
                                    MessageBox.Show("Pour la première exécution du logiciel, veuillez le lancer sur le serveur", "Erreur de création du modèle",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                    MessageBox.Show(ex.Message, "Erreur de création du modèle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                modeleRestored = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(string.Format("La connexion au serveur a échoué à cause de l'erreur suivante : \"{0}\"", ex.Message),
                                "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            stopTrying = !GetServer(ref serverName, ref instanceName);
                        }
                    }
                }
                //this.authenticationStandard1.LogonParametersType = typeof(CustomLogonParameter);
                this.Connection = sqlConnection1;
            }
            else
            {
                this.sqLiteConnection1 = new System.Data.SQLite.SQLiteConnection(string.Format("Data Source={0}\\MaPaye",
                Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath)));
                this.Connection = this.sqLiteConnection1;
                if (lsactvtn.ActivationClass.Demo)
                    this.Security = null;
            }
            //this.LastLogonParametersRead += new System.EventHandler<DevExpress.ExpressApp.LastLogonParametersReadEventArgs>(this.LSWinApplication_LastLogonParametersRead);
            this.CreateCustomLogonWindowObjectSpace += new System.EventHandler<DevExpress.ExpressApp.CreateCustomLogonWindowObjectSpaceEventArgs>(this.application_CreateCustomLogonWindowObjectSpace);
            this.LoggingOn += new System.EventHandler<DevExpress.ExpressApp.LogonEventArgs>(this.winApplication_LoggingOn); 

            //else
            //{
            //    this.sqLiteConnection1 = new System.Data.SQLite.SQLiteConnection(string.Format("Data Source={0}\\winParc",
            //    Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath)));
            //    this.Connection = this.sqLiteConnection1;
            //}
        }

        private bool GetServer(ref string serverName, ref string instanceName)
        {
            string _instanceName = ((string.IsNullOrEmpty(instanceName)) ? string.Empty : instanceName.Substring(1));
            FindServerDlg fsd = new FindServerDlg(serverName, _instanceName);
            if (fsd.ShowDialog() == DialogResult.OK)
            {
                serverName = fsd.ServerName;
                instanceName = fsd.InstanceName;
                return true;
            }
            else
                return false;
        }

        private DevExpress.ExpressApp.SystemModule.SystemModule module1;
        private DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule module2;
        private MaPaye.Module.MaPayeModule module3;
        private MaPaye.Module.Win.MaPayeWindowsFormsModule module4;
        private DevExpress.ExpressApp.Validation.ValidationModule module5;
        private DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule module6;
        private DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule module7;
        private DevExpress.ExpressApp.Security.SecurityModule securityModule1;
        private DevExpress.ExpressApp.Reports.Win.ReportsWindowsFormsModule reportsWindowsFormsModule1;
        private DevExpress.ExpressApp.Reports.ReportsModule reportsModule1;
        //private DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule printingWindowsFormsModule1;
        private DevExpress.ExpressApp.FileAttachments.Win.FileAttachmentsWindowsFormsModule fileAttachmentsWindowsFormsModule1; 
        private DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule conditionalAppearanceModule1;
        private System.Data.SqlClient.SqlConnection sqlConnection1; 
        private DevExpress.ExpressApp.SystemModule.SystemModule systemModule1;
        //private DevExpress.ExpressApp.Security.SecurityModule securityModule2; 
        private DevExpress.ExpressApp.SystemModule.SystemModule systemModule2;
        private DevExpress.ExpressApp.Security.SecurityModule securityModule3; 
        private System.Data.SQLite.SQLiteConnection sqLiteConnection1;
        private DevExpress.ExpressApp.Security.SecurityStrategyComplex securityStrategyComplex1;
        private DevExpress.ExpressApp.Security.AuthenticationStandard authenticationStandard1;
    }
}
