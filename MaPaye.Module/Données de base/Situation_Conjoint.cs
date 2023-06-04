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
    public enum Sit_Conj_FR { Tavail, Chomeur, Sans }
    public enum Sit_Conj_Ar { عامل, عاطل, لاشيئ }

        [DefaultProperty("Sit_Conj_Lib_Fr")]
    [DefaultClassOptions]
    public class Situation_Conjoint : BaseObject
    {

        //Sit_Conj_Ar fSit_Conj_Lib_Ara;
        //public Sit_Conj_Ar Sit_Conj_Lib_Ara
        //{
        //    get { return fSit_Conj_Lib_Ara; }
        //    set { SetPropertyValue<Sit_Conj_Ar>("Sit_Conj_Lib_Ara", ref fSit_Conj_Lib_Ara, value); }
        //}

        Sit_Conj_FR fSit_Conj_Lib_Fr;
        public Sit_Conj_FR Sit_Conj_Lib_Fr
        {
            get { return fSit_Conj_Lib_Fr; }
            set { SetPropertyValue<Sit_Conj_FR>("Sit_Conj_Lib_Fr", ref fSit_Conj_Lib_Fr, value); }
        }

        public Situation_Conjoint(Session session)
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
