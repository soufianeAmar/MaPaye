using System;
using System.ComponentModel;
using System.Collections.Generic;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.Security;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using MaPayeAdmin.Module;

namespace MaPaye.Module
{
    [NonPersistent, System.ComponentModel.DisplayName("Connexion"), DefaultProperty("password")]
    public class CustomLogonParameter : AuthenticationStandardLogonParameters
    {
        #region Propri�t�s
        IObjectSpace _objectspace;
        [Browsable(false)]
        public IObjectSpace objectspace
        {
            get { return _objectspace; }
            set { _objectspace = value; }
        }
        Exercice _database;
        [DevExpress.Xpo.DisplayName("Dossier")]
        [DataSourceProperty("databases")]
        public Exercice database
        {
            get { return _database; }
            set { _database = value; }
        }
        [Browsable(false)]
        public ReadOnlyCollection<Exercice> databases
        {
            get
            {
                XPCollection<Exercice> databasecollection = new XPCollection<Exercice>(((XPObjectSpace)objectspace).Session);
                 
                return Core.GetReadOnlyCollection(databasecollection);
            }
        }
        #endregion

        #region M�thodes
        public void Reset()
        {
            objectspace.Dispose();
        }
        #endregion
    }
}