using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text; 
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.SystemModule;

namespace MaPaye.Module
{
    public partial class CustomizeWindowController : WindowController
    {
        //WindowTemplateController controller;
        public CustomizeWindowController()
        {
            InitializeComponent();
            RegisterActions(components);

            TargetWindowType = WindowType.Main;
            //Activated += CustomizeWindowController_Activated;
        }

        //void CustomizeWindowController_Activated(object sender, EventArgs e)
        //{
        //    controller = Frame.GetController<WindowTemplateController>();
        //    controller.CustomizeWindowCaption += controller_CustomizeWindowCaption; 
        //}

        void controller_CustomizeWindowCaption(object sender, CustomizeWindowCaptionEventArgs e)
        {
            //e.WindowCaption.Text = "My Custom Caption";
            //e.WindowCaption.Separator = ": ";
            //e.WindowCaption.SecondPart = ":)";
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            WindowTemplateController controller = Frame.GetController<WindowTemplateController>();
            controller.CustomizeWindowCaption += controller_CustomizeWindowCaption;
            //controller.CustomizeWindowStatusMessages += controller_CustomizeWindowStatusMessages;
        }
    } 
}