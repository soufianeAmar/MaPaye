namespace MaPaye.Module
{
    partial class ViewController2
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
            this.components = new System.ComponentModel.Container();
            this.ArchiverBDD = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.ImporterDonneesExercicePrecedent = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.aConvertV2 = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.aExportV2 = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // ArchiverBDD
            // 
            this.ArchiverBDD.Caption = "Archiver BDD";
            this.ArchiverBDD.Category = "Tools";
            this.ArchiverBDD.ConfirmationMessage = null;
            this.ArchiverBDD.Id = "ArchiverBDD";
            this.ArchiverBDD.ImageName = "BakupDataBase2";
            this.ArchiverBDD.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.ArchiverBDD.ToolTip = null;
            this.ArchiverBDD.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.ArchiverBDD_Execute);
            // 
            // ImporterDonneesExercicePrecedent
            // 
            this.ImporterDonneesExercicePrecedent.Caption = "Importer Donnees Exercice Precedent";
            this.ImporterDonneesExercicePrecedent.ConfirmationMessage = null;
            this.ImporterDonneesExercicePrecedent.Id = "ImporterDonneesExercicePrecedent";
            this.ImporterDonneesExercicePrecedent.TargetObjectType = typeof(MaPaye.Module.ExcelReader);
            this.ImporterDonneesExercicePrecedent.ToolTip = null;
            this.ImporterDonneesExercicePrecedent.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.ImporterDonneesExercicePrecedent_Execute);
            // 
            // aConvertV2
            // 
            this.aConvertV2.Caption = "Convert V2";
            this.aConvertV2.Category = "V2Convert";
            this.aConvertV2.ConfirmationMessage = null;
            this.aConvertV2.Id = "Convert V2";
            this.aConvertV2.ToolTip = null;
            this.aConvertV2.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.aConvertV2_Execute);
            // 
            // aExportV2
            // 
            this.aExportV2.Caption = "Export V2";
            this.aExportV2.Category = "V2Export";
            this.aExportV2.ConfirmationMessage = null;
            this.aExportV2.Id = "Export V2";
            this.aExportV2.ToolTip = null;
            this.aExportV2.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.aExportV2_Execute);
            // 
            // ViewController2
            // 
            this.Actions.Add(this.ArchiverBDD);
            this.Actions.Add(this.ImporterDonneesExercicePrecedent);
            this.Actions.Add(this.aConvertV2);
            this.Actions.Add(this.aExportV2);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction ImporterDonneesExercicePrecedent;
        private DevExpress.ExpressApp.Actions.SimpleAction ArchiverBDD;
        private DevExpress.ExpressApp.Actions.SimpleAction aConvertV2;
        private DevExpress.ExpressApp.Actions.SimpleAction aExportV2;
    }
}
