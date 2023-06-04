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
    public enum Sexe_FR { Masculin, Feminin }
    //public enum Sexe_Ar { ذكر, أنثى }

        [DefaultProperty("Sexe_Lib_Fr")]
    [DefaultClassOptions]
    public class Sexe : BaseObject
    {
        //private Sexe_Ar fSexe_Lib_Ar;
        //public Sexe_Ar Sexe_Lib_Ar
        //{
        //    get { return fSexe_Lib_Ar; }
        //    set { SetPropertyValue<Sexe_Ar>("Sexe_Lib_Ar", ref fSexe_Lib_Ar, value); }
        //}

        private Sexe_FR fSexe_Lib_Fr;
        public Sexe_FR Sexe_Lib_Fr
        {
            get { return fSexe_Lib_Fr; }
            set { SetPropertyValue<Sexe_FR>("Sexe_Lib_Fr", ref fSexe_Lib_Fr, value); }
        }
       

        public Sexe(Session session)
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
