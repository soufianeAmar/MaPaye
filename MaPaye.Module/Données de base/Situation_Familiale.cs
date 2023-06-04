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
    public enum Sit_Fam_FR { Celibataire, [XafDisplayName("Marié(e) Sans Enfants")] Marie_Sans_Enfants,[XafDisplayName("Marié(e) Avec Enfants")] Marie_Avec_Enfants,[XafDisplayName("Divorsé(e)")] Divorsé,[XafDisplayName("Veuf(ve)")] Veuf }
    public enum Sit_Fam_Ar { أعزب,[XafDisplayName("متزوج(ة) بدون أطفال")] متزوج_بدون_أطفال,[XafDisplayName("متزوج(ة) بأطفال")] متزوج_بأطفال,[XafDisplayName("(مطلق(ة")] مطلق,[XafDisplayName("(أرمل(ة")] أرمل }

        [DefaultProperty("Sit_Fam_Lib_Fr")]
    [DefaultClassOptions]
    public class Situation_Familiale : BaseObject
    {
        string fSit_Fam_Lib_Pour_Etat;
        public string Sit_Fam_Lib_Pour_Etat
        {
            get { return fSit_Fam_Lib_Pour_Etat; }
            set { SetPropertyValue<string>("Sit_Fam_Lib_Pour_Etat", ref fSit_Fam_Lib_Pour_Etat, value); }
        }

        //Sit_Fam_Ar fSit_Fam_Lib_Ara;
        //public Sit_Fam_Ar Sit_Fam_Lib_Ara
        //{
        //    get { return fSit_Fam_Lib_Ara; }
        //    set { SetPropertyValue<Sit_Fam_Ar>("Sit_Fam_Lib_Ara", ref fSit_Fam_Lib_Ara, value); }
        //}

        Sit_Fam_FR fSit_Fam_Lib_Fr;
        public Sit_Fam_FR Sit_Fam_Lib_Fr
        {
            get { return fSit_Fam_Lib_Fr; }
            set { SetPropertyValue<Sit_Fam_FR>("Sit_Fam_Lib_Fr", ref fSit_Fam_Lib_Fr, value); }
        }

        public Situation_Familiale(Session session)
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
