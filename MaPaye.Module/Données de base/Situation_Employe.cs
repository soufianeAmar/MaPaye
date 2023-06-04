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
    public enum Sit_Emp_Fr { Actif, Maternité, Maladie, Disponibilité, Retraite,[XafDisplayName("Non Actif")] Non_Actif }
    public enum Sit_Emp_Ar { يعمل, أمومة, مريض, إستداع, تقاعد,   [XafDisplayName("لا يعمل")] لا_يعمل }

        [DefaultProperty("Sit_Emp_Lib_Fr")]
    [DefaultClassOptions]
    public class Situation_Employe : BaseObject
    {
        Sit_Emp_Fr fSit_Emp_Lib_Fr;
        public Sit_Emp_Fr Sit_Emp_Lib_Fr
        {
            get { return fSit_Emp_Lib_Fr; }
            set { SetPropertyValue<Sit_Emp_Fr>("Sit_Emp_Lib_Fr", ref fSit_Emp_Lib_Fr, value); }
        }

        //Sit_Emp_Ar fSit_Emp_Lib_Ar;
        //public Sit_Emp_Ar Sit_Emp_Lib_Ar
        //{
        //    get { return fSit_Emp_Lib_Ar; }
        //    set { SetPropertyValue<Sit_Emp_Ar>("Sit_Emp_Lib_Ar", ref fSit_Emp_Lib_Ar, value); }
        //}
        

        public Situation_Employe(Session session)
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
