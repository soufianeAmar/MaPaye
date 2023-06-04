using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.DC;

namespace MaPaye.Module
{
    public enum Raison_Sortie_FR { DÈcÈ, Demission,[XafDisplayName("RÈsiliation Contrat")] RÈsiliation_Contrat, TransfËre }
    public enum Raison_Sortie_Ar { Ê›«…, ≈” ﬁ«·…,[XafDisplayName("›”Œ «·⁄ﬁœ")] ›”Œ_«·⁄ﬁœ,  ÕÊÌ· }

         [DefaultProperty("Raison_Sortie_Fr")]
    [DefaultClassOptions]
    public class Raison_Sortie : BaseObject
    {

        //string fRaison_Sortie_Ara;
        //public string Raison_Sortie_Ara
        //{
        //    get { return fRaison_Sortie_Ara; }
        //    set { SetPropertyValue<string>("Raison_Sortie_Ara", ref fRaison_Sortie_Ara, value); }
        //}


        string fRaison_Sortie_Fr;
        public string Raison_Sortie_Fr
        {
            get { return fRaison_Sortie_Fr; }
            set { SetPropertyValue<string>("Raison_Sortie_Fr", ref fRaison_Sortie_Fr, value); }
        }
        //**********************************************
       
        public Raison_Sortie(Session session)
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
