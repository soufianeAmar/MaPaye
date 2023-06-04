namespace MaPaye.Module
{
    partial class OutilsBDD
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
            this.RestaurerBD = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.SauvgarderBD = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // RestaurerBD
            // 
            this.RestaurerBD.Caption = "Restaurer Une Base de Données";
            this.RestaurerBD.ConfirmationMessage = null;
            this.RestaurerBD.Id = "RestaurerBD";
            this.RestaurerBD.ImageName = null;
            this.RestaurerBD.Shortcut = null;
            this.RestaurerBD.Tag = null;
            this.RestaurerBD.TargetObjectsCriteria = null;
            this.RestaurerBD.TargetObjectType = typeof(MaPaye.Module.ExcelReader);
            this.RestaurerBD.TargetViewId = null;
            this.RestaurerBD.ToolTip = null;
            this.RestaurerBD.TypeOfView = typeof(DevExpress.ExpressApp.View);
            this.RestaurerBD.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.RestaurerBD_Execute);
            // 
            // SauvgarderBD
            // 
            this.SauvgarderBD.Caption = "Archiver la Base de Données";
            this.SauvgarderBD.ConfirmationMessage = null;
            this.SauvgarderBD.Id = "SauvgarderBD";
            this.SauvgarderBD.ImageName = null;
            this.SauvgarderBD.Shortcut = null;
            this.SauvgarderBD.Tag = null;
            this.SauvgarderBD.TargetObjectsCriteria = null;
            this.SauvgarderBD.TargetObjectType = typeof(MaPaye.Module.ExcelReader);
            this.SauvgarderBD.TargetViewId = null;
            this.SauvgarderBD.ToolTip = null;
            this.SauvgarderBD.TypeOfView = typeof(DevExpress.ExpressApp.View);
            this.SauvgarderBD.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.SauvgarderBD_Execute);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction RestaurerBD;
        private DevExpress.ExpressApp.Actions.SimpleAction SauvgarderBD;
    }
}
