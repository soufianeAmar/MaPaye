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
        [DefaultProperty("Service_Lib_Fr")]
    [DefaultClassOptions]
    public class Service : BaseObject
    {
        private string fCod_ser; 
        [Size(30)]
        public string Cod_ser
        {
            get { return fCod_ser; }
            set { SetPropertyValue<string>("Cod_ser", ref fCod_ser, value); }
        }

        private string fService_Lib_Fr; 
        public string Service_Lib_Fr
        {
            get { return fService_Lib_Fr; }
            set { SetPropertyValue<string>("Service_Lib_Fr", ref fService_Lib_Fr, value); }
        }

        //private string fService_Lib_Ar;
        //public string Service_Lib_Ar
        //{
        //    get { return fService_Lib_Ar; }
        //    set { SetPropertyValue<string>("Service_Lib_Ar", ref fService_Lib_Ar, value); }
        //}

        public Service(Session session)
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
