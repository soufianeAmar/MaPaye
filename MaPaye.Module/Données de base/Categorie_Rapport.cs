using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation; 


namespace MaPaye.Module
{ 
    [DefaultClassOptions]
    public class Categorie_Rapport : BaseObject
    {
        private string fCode_Categorie; 
        public string Code_Categorie
        {
            get { return fCode_Categorie; }
            set { SetPropertyValue<string>("Code_Categorie", ref fCode_Categorie, value); }
        }

        private string fCategorie_Fr; 
        public string Categorie_Fr
        {
            get { return fCategorie_Fr; }
            set { SetPropertyValue<string>("Categorie_Fr", ref fCategorie_Fr, value); }
        }

        //private string fCategorie_Ar; 
        //public string Categorie_Ar
        //{
        //    get { return fCategorie_Ar; }
        //    set { SetPropertyValue<string>("Categorie_Ar", ref fCategorie_Ar, value); }
        //}
         
        public Categorie_Rapport(Session session)
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
