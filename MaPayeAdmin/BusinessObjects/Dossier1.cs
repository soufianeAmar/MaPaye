using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace MaPayeAdmin.Module
{
    [DefaultClassOptions, NavigationItem("Administration"), ImageName("dossier"), DefaultProperty("code_dossier"), CreatableItem(false)]
    public class Dossier : BaseObject
    {
        #region Propriétés
        string _code_dossier;
        [DevExpress.Xpo.DisplayName("Code dossier")]
        public string code_dossier
        {
            get { return _code_dossier; }
            set { SetPropertyValue("nom", ref _code_dossier, value); }
        }
        string _description;
        [DevExpress.Xpo.DisplayName("Description")]
        public string description
        {
            get { return _description; }
            set { SetPropertyValue("description", ref _description, value); }
        }
        string _chemin;
        [DevExpress.Xpo.DisplayName("Chemin de la base de données"), Browsable(false)]
        public string chemin
        {
            get { return _chemin; }
            set { SetPropertyValue("chemin", ref _chemin, value); }
        }
        #endregion
        public Dossier(Session session)
            : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here or place it only when the IsLoading property is false:
            // if (!IsLoading){
            //    It is now OK to place your initialization code here.
            // }
            // or as an alternative, move your initialization code into the AfterConstruction method.
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }
    }

}
