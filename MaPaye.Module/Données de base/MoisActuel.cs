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
    //[DefaultClassOptions]
    public class MoisActuel : BaseObject
    {
        private int fMois1;
      
        public int Mois1
        {
            get { return fMois1; }
            set { SetPropertyValue<int>("Mois1", ref fMois1, value); }
        }
        private string fMois;
        [Size(2)]
        public string Mois
        {
            get { return fMois; }
            set { SetPropertyValue<string>("Mois", ref fMois, value); }
        }
        private string fDes_f;
        [Size(50)]
        public string Des_f
        {
            get { return fDes_f; }
            set { SetPropertyValue<string>("Des_f", ref fDes_f, value); }
        }
        public MoisActuel(Session session)
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
