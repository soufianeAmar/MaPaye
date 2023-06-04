using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using Microsoft.SqlServer.Management.Smo.Broker;
using DevExpress.Xpo; 
namespace MaPayeAdmin
{
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
    public partial class ObjectsCountViewController : ViewController
    {
        public ObjectsCountViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void ObjectsCountViewController_FrameAssigned(object sender, EventArgs e)
        {
            NewObjectViewController newobjectVC = Frame.GetController<NewObjectViewController>();
            newobjectVC.ObjectCreating += countlimit_objectCreating;
        }

        private void countlimit_objectCreating(object sender, ObjectCreatingEventArgs e)
        { 
                if (IsLimited(e.ObjectType))
                    CheckMaximumObject(e);
        }

        public static bool IsLimited(Type type)
        {
            LimitedAttribute IsLimitedAttrib = (LimitedAttribute)Attribute.GetCustomAttribute(type, typeof(LimitedAttribute));
            return (IsLimitedAttrib != null);
        }

        private static void CheckMaximumObject(ObjectCreatingEventArgs e)
        {
            bool error = e.ObjectSpace.GetObjectsCount(e.ObjectType, null) >= lsactvtn.ActivationClass.nombreEnregistrements;
            e.Cancel = error;
            throw new Exception("Nombre d'employés maximum atteint !");
        }

    }
}
