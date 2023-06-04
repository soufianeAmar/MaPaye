//#define PROTECTION

using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security; 
using DevExpress.ExpressApp.Xpo;
using System.Data.SqlClient;
using System.Data; 
using System.Reflection;
using DevExpress.ExpressApp.Reports;
using DevExpress.Xpo.Metadata;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace MaPaye.Module
{
    public class Updater : ModuleUpdater
    {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion)
            : base(objectSpace, currentDBVersion) { }
  
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();

            parametre.GetInstance(((XPObjectSpace)ObjectSpace).Session);

            if (!lsactvtn.ActivationClass.Demo)
                Core.CreateUserAdmin(ObjectSpace);

            if (!lsactvtn.ActivationClass.réseau)
            {
                Assembly assembly = GetType().Assembly;

                Core.ImportData(((XPObjectSpace)ObjectSpace).Session, assembly);
                Core.ImportReports(((XPObjectSpace)ObjectSpace).Session, assembly);
            }
        }
    }
}
