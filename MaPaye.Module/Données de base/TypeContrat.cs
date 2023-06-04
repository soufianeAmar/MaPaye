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

        [DefaultProperty("Type_Contrat_Fr")]
    [DefaultClassOptions]
    public class TypeContrat : BaseObject
    {
        private string fCodeType; 
        public string CodeType
        {
            get { return fCodeType; }
            set { SetPropertyValue<string>("CodeType", ref fCodeType, value); }
        }

        //private string fType_Contrat_Ar;
        //public string Type_Contrat_Ar
        //{
        //    get { return fType_Contrat_Ar; }
        //    set { SetPropertyValue<string>("Type_Contrat_Ar", ref fType_Contrat_Ar, value); }
        //}

        private string fType_Contrat_Fr;
        public string Type_Contrat_Fr
        {
            get { return fType_Contrat_Fr; }
            set { SetPropertyValue<string>("Type_Contrat_Fr", ref fType_Contrat_Fr, value); }
        }
 

        public TypeContrat(Session session)
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
