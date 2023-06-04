using DevExpress.ExpressApp.Actions;

namespace TP.Shell.XAF.Module.Win.Controllers
{
    partial class MultiEditViewController
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
            this.MultiEditAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // MultiEditAction
            // 
            this.MultiEditAction.Caption = "Edit (Multi Record)";
            this.MultiEditAction.Category = "RecordEdit";
            this.MultiEditAction.Id = "28086fd6-c877-474c-ab70-9f064c815d2f";
            this.MultiEditAction.ImageName = "Documents Edit 2";
            this.MultiEditAction.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireMultipleObjects;
            this.MultiEditAction.Tag = null;
            this.MultiEditAction.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.MultiEditAction.ToolTip = "Shows editor for the selected property";
            this.MultiEditAction.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.MultiEditAction.SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects;
            this.MultiEditAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.MultiEditAction_Execute);
            // 
            // MultiEditViewController
            // 
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.Activated += new System.EventHandler(this.MultiEditViewController_Activated);
            this.Deactivated += new System.EventHandler(this.MultiEditViewController_Deactivating);

        }

        #endregion

        public DevExpress.ExpressApp.Actions.SimpleAction MultiEditAction;
    }
}