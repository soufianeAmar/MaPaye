namespace MaPaye.Module
{
    partial class Exportation
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
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem25 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem26 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem27 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem28 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem29 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem30 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem31 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem32 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem33 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem34 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem35 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem36 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem37 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem38 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem39 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem40 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem41 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem42 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem43 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem44 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem45 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem46 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem47 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem48 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            this.ExportBanque = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.ExporterDonn�esEDICCPRappel = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.ExportParametres_Paye = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.ExporterDonn�esEDICCP = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            this.ExporterDonn�esEDICCPBordereau = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            this.ExportData = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.ImportSqlData = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // ExportBanque
            // 
            this.ExportBanque.Caption = "Export Banque";
            this.ExportBanque.ConfirmationMessage = null;
            this.ExportBanque.Id = "ExportBanque";
            this.ExportBanque.ImageName = null;
            this.ExportBanque.Shortcut = null;
            this.ExportBanque.Tag = null;
            this.ExportBanque.TargetObjectsCriteria = null;
            this.ExportBanque.TargetObjectType = typeof(MaPaye.Module.ExcelReader);
            this.ExportBanque.TargetViewId = null;
            this.ExportBanque.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.ExportBanque.ToolTip = null;
            this.ExportBanque.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.ExportBanque.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.ExportBanque_Execute);
            // 
            // ExporterDonn�esEDICCPRappel
            // 
            this.ExporterDonn�esEDICCPRappel.Caption = "Exporter Donn�es EDI/CCP Rappel";
            this.ExporterDonn�esEDICCPRappel.ConfirmationMessage = null;
            this.ExporterDonn�esEDICCPRappel.Id = "ExporterDonn�esEDICCPRappel";
            this.ExporterDonn�esEDICCPRappel.ImageName = null;
            this.ExporterDonn�esEDICCPRappel.Shortcut = null;
            this.ExporterDonn�esEDICCPRappel.Tag = null;
            this.ExporterDonn�esEDICCPRappel.TargetObjectsCriteria = null;
            this.ExporterDonn�esEDICCPRappel.TargetObjectType = typeof(MaPaye.Module.Rappel);
            this.ExporterDonn�esEDICCPRappel.TargetViewId = null;
            this.ExporterDonn�esEDICCPRappel.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.ExporterDonn�esEDICCPRappel.ToolTip = null;
            this.ExporterDonn�esEDICCPRappel.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.ExporterDonn�esEDICCPRappel.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.ExporterDonn�esEDICCPRappel_Execute);
            // 
            // ExportParametres_Paye
            // 
            this.ExportParametres_Paye.Caption = "ExporterDonn�esEDI/CCP";
            this.ExportParametres_Paye.ConfirmationMessage = null;
            this.ExportParametres_Paye.Id = "ExporterDonn�esEDI/CCP";
            this.ExportParametres_Paye.ImageName = null;
            this.ExportParametres_Paye.Shortcut = null;
            this.ExportParametres_Paye.Tag = null;
            this.ExportParametres_Paye.TargetObjectsCriteria = null;
            this.ExportParametres_Paye.TargetObjectType = typeof(MaPaye.Module.ExcelReader);
            this.ExportParametres_Paye.TargetViewId = null;
            this.ExportParametres_Paye.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.ExportParametres_Paye.ToolTip = null;
            this.ExportParametres_Paye.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.ExportParametres_Paye.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.ExportPaye_Execute);
            // 
            // ExporterDonn�esEDICCP
            // 
            this.ExporterDonn�esEDICCP.Caption = "Exporter Donn�es EDI/CCP";
            this.ExporterDonn�esEDICCP.ConfirmationMessage = null;
            this.ExporterDonn�esEDICCP.Id = "ExporterDonn�esEDICCP";
            this.ExporterDonn�esEDICCP.ImageName = null;
            choiceActionItem25.Caption = "Janvier";
            choiceActionItem25.Data = "1";
            choiceActionItem25.ImageName = null;
            choiceActionItem25.Shortcut = null;
            choiceActionItem26.Caption = "F�vrier";
            choiceActionItem26.Data = "2";
            choiceActionItem26.ImageName = null;
            choiceActionItem26.Shortcut = null;
            choiceActionItem27.Caption = "Mars";
            choiceActionItem27.Data = "3";
            choiceActionItem27.ImageName = null;
            choiceActionItem27.Shortcut = null;
            choiceActionItem28.Caption = "Avril";
            choiceActionItem28.Data = "4";
            choiceActionItem28.ImageName = null;
            choiceActionItem28.Shortcut = null;
            choiceActionItem29.Caption = "Mai";
            choiceActionItem29.Data = "5";
            choiceActionItem29.ImageName = null;
            choiceActionItem29.Shortcut = null;
            choiceActionItem30.Caption = "Juin";
            choiceActionItem30.Data = "6";
            choiceActionItem30.ImageName = null;
            choiceActionItem30.Shortcut = null;
            choiceActionItem31.Caption = "Juillet";
            choiceActionItem31.Data = "7";
            choiceActionItem31.ImageName = null;
            choiceActionItem31.Shortcut = null;
            choiceActionItem32.Caption = "Aout";
            choiceActionItem32.Data = "8";
            choiceActionItem32.ImageName = null;
            choiceActionItem32.Shortcut = null;
            choiceActionItem33.Caption = "Septembre";
            choiceActionItem33.Data = "9";
            choiceActionItem33.ImageName = null;
            choiceActionItem33.Shortcut = null;
            choiceActionItem34.Caption = "Octobre";
            choiceActionItem34.Data = "10";
            choiceActionItem34.ImageName = null;
            choiceActionItem34.Shortcut = null;
            choiceActionItem35.Caption = "Novembre";
            choiceActionItem35.Data = "11";
            choiceActionItem35.ImageName = null;
            choiceActionItem35.Shortcut = null;
            choiceActionItem36.Caption = "D�cembre";
            choiceActionItem36.Data = "12";
            choiceActionItem36.ImageName = null;
            choiceActionItem36.Shortcut = null;
            this.ExporterDonn�esEDICCP.Items.Add(choiceActionItem25);
            this.ExporterDonn�esEDICCP.Items.Add(choiceActionItem26);
            this.ExporterDonn�esEDICCP.Items.Add(choiceActionItem27);
            this.ExporterDonn�esEDICCP.Items.Add(choiceActionItem28);
            this.ExporterDonn�esEDICCP.Items.Add(choiceActionItem29);
            this.ExporterDonn�esEDICCP.Items.Add(choiceActionItem30);
            this.ExporterDonn�esEDICCP.Items.Add(choiceActionItem31);
            this.ExporterDonn�esEDICCP.Items.Add(choiceActionItem32);
            this.ExporterDonn�esEDICCP.Items.Add(choiceActionItem33);
            this.ExporterDonn�esEDICCP.Items.Add(choiceActionItem34);
            this.ExporterDonn�esEDICCP.Items.Add(choiceActionItem35);
            this.ExporterDonn�esEDICCP.Items.Add(choiceActionItem36);
            this.ExporterDonn�esEDICCP.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation;
            this.ExporterDonn�esEDICCP.Shortcut = null;
            this.ExporterDonn�esEDICCP.Tag = null;
            this.ExporterDonn�esEDICCP.TargetObjectsCriteria = null;
            this.ExporterDonn�esEDICCP.TargetObjectType = typeof(MaPaye.Module.Paye);
            this.ExporterDonn�esEDICCP.TargetViewId = null;
            this.ExporterDonn�esEDICCP.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.ExporterDonn�esEDICCP.ToolTip = null;
            this.ExporterDonn�esEDICCP.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.ExporterDonn�esEDICCP.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.ExporterDonn�esEDICCP_Execute);
            // 
            // ExporterDonn�esEDICCPBordereau
            // 
            this.ExporterDonn�esEDICCPBordereau.Caption = "Exporter Donn�es EDI/CCP Bordereau";
            this.ExporterDonn�esEDICCPBordereau.ConfirmationMessage = null;
            this.ExporterDonn�esEDICCPBordereau.Id = "ExporterDonn�esEDICCPBordereau";
            this.ExporterDonn�esEDICCPBordereau.ImageName = null;
            choiceActionItem37.Caption = "Janvier";
            choiceActionItem37.Data = "1";
            choiceActionItem37.ImageName = null;
            choiceActionItem37.Shortcut = null;
            choiceActionItem38.Caption = "F�vrier";
            choiceActionItem38.Data = "2";
            choiceActionItem38.ImageName = null;
            choiceActionItem38.Shortcut = null;
            choiceActionItem39.Caption = "Mars";
            choiceActionItem39.Data = "3";
            choiceActionItem39.ImageName = null;
            choiceActionItem39.Shortcut = null;
            choiceActionItem40.Caption = "Avril";
            choiceActionItem40.Data = "4";
            choiceActionItem40.ImageName = null;
            choiceActionItem40.Shortcut = null;
            choiceActionItem41.Caption = "Mai";
            choiceActionItem41.Data = "5";
            choiceActionItem41.ImageName = null;
            choiceActionItem41.Shortcut = null;
            choiceActionItem42.Caption = "Juin";
            choiceActionItem42.Data = "6";
            choiceActionItem42.ImageName = null;
            choiceActionItem42.Shortcut = null;
            choiceActionItem43.Caption = "Juillet";
            choiceActionItem43.Data = "7";
            choiceActionItem43.ImageName = null;
            choiceActionItem43.Shortcut = null;
            choiceActionItem44.Caption = "Aout";
            choiceActionItem44.Data = "8";
            choiceActionItem44.ImageName = null;
            choiceActionItem44.Shortcut = null;
            choiceActionItem45.Caption = "Septembre";
            choiceActionItem45.Data = "9";
            choiceActionItem45.ImageName = null;
            choiceActionItem45.Shortcut = null;
            choiceActionItem46.Caption = "Octobre";
            choiceActionItem46.Data = "10";
            choiceActionItem46.ImageName = null;
            choiceActionItem46.Shortcut = null;
            choiceActionItem47.Caption = "Novembre";
            choiceActionItem47.Data = "11";
            choiceActionItem47.ImageName = null;
            choiceActionItem47.Shortcut = null;
            choiceActionItem48.Caption = "D�cembre";
            choiceActionItem48.Data = "12";
            choiceActionItem48.ImageName = null;
            choiceActionItem48.Shortcut = null;
            this.ExporterDonn�esEDICCPBordereau.Items.Add(choiceActionItem37);
            this.ExporterDonn�esEDICCPBordereau.Items.Add(choiceActionItem38);
            this.ExporterDonn�esEDICCPBordereau.Items.Add(choiceActionItem39);
            this.ExporterDonn�esEDICCPBordereau.Items.Add(choiceActionItem40);
            this.ExporterDonn�esEDICCPBordereau.Items.Add(choiceActionItem41);
            this.ExporterDonn�esEDICCPBordereau.Items.Add(choiceActionItem42);
            this.ExporterDonn�esEDICCPBordereau.Items.Add(choiceActionItem43);
            this.ExporterDonn�esEDICCPBordereau.Items.Add(choiceActionItem44);
            this.ExporterDonn�esEDICCPBordereau.Items.Add(choiceActionItem45);
            this.ExporterDonn�esEDICCPBordereau.Items.Add(choiceActionItem46);
            this.ExporterDonn�esEDICCPBordereau.Items.Add(choiceActionItem47);
            this.ExporterDonn�esEDICCPBordereau.Items.Add(choiceActionItem48);
            this.ExporterDonn�esEDICCPBordereau.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation;
            this.ExporterDonn�esEDICCPBordereau.Shortcut = null;
            this.ExporterDonn�esEDICCPBordereau.Tag = null;
            this.ExporterDonn�esEDICCPBordereau.TargetObjectsCriteria = null;
            this.ExporterDonn�esEDICCPBordereau.TargetObjectType = typeof(MaPaye.Module.Bordereau);
            this.ExporterDonn�esEDICCPBordereau.TargetViewId = null;
            this.ExporterDonn�esEDICCPBordereau.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.ExporterDonn�esEDICCPBordereau.ToolTip = null;
            this.ExporterDonn�esEDICCPBordereau.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.ExporterDonn�esEDICCPBordereau.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.ExporterDonn�esEDICCPBordereau_Execute);
            // 
            // ExportData
            // 
            this.ExportData.Caption = "Export Data";
            this.ExportData.Category = "Tools";
            this.ExportData.ConfirmationMessage = null;
            this.ExportData.Id = "ExportData";
            this.ExportData.ImageName = null;
            this.ExportData.Shortcut = null;
            this.ExportData.Tag = null;
            this.ExportData.TargetObjectsCriteria = null;
            this.ExportData.TargetObjectType = typeof(MaPaye.Module.parametre);
            this.ExportData.TargetViewId = null;
            this.ExportData.ToolTip = null;
            this.ExportData.TypeOfView = typeof(DevExpress.ExpressApp.View);
            this.ExportData.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.ExportData_Execute);
            // 
            // ImportSqlData
            // 
            this.ImportSqlData.Caption = "Import Sql Data";
            this.ImportSqlData.Category = "Tools";
            this.ImportSqlData.ConfirmationMessage = null;
            this.ImportSqlData.Id = "ImportSqlData";
            this.ImportSqlData.ImageName = null;
            this.ImportSqlData.Shortcut = null;
            this.ImportSqlData.Tag = null;
            this.ImportSqlData.TargetObjectsCriteria = null;
            this.ImportSqlData.TargetObjectType = typeof(MaPaye.Module.parametre);
            this.ImportSqlData.TargetViewId = null;
            this.ImportSqlData.ToolTip = null;
            this.ImportSqlData.TypeOfView = null; 

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction ExportBanque;
        private DevExpress.ExpressApp.Actions.SimpleAction ExporterDonn�esEDICCPRappel;
        private DevExpress.ExpressApp.Actions.SimpleAction ExportParametres_Paye;
        private DevExpress.ExpressApp.Actions.SingleChoiceAction ExporterDonn�esEDICCP;
        private DevExpress.ExpressApp.Actions.SingleChoiceAction ExporterDonn�esEDICCPBordereau;
        private DevExpress.ExpressApp.Actions.SimpleAction ExportData;
        private DevExpress.ExpressApp.Actions.SimpleAction ImportSqlData;
    }
}
