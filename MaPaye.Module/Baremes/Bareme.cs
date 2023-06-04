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
    [DefaultProperty("CATEG")]
    [DefaultClassOptions]
    public class Bareme : BaseObject
    {
        private string fCATSEC; 
        public string CATEG
        {
            get { return fCATSEC; }
            set { SetPropertyValue<string>("CATEG", ref fCATSEC, value); }
        }

        private double fSDB;
        public double SDB
        {
            get { return fSDB; }
            set { SetPropertyValue<double>("SDB", ref fSDB, value); }
        }

        private double fECH;
        public double ECH
        {
            get { return fECH; }
            set { SetPropertyValue<double>("ECH", ref fECH, value); }
        }

        //double fECH2;
        //public double ECH2
        //{
        //    get { return fECH2; }
        //    set { SetPropertyValue<double>("ECH2", ref fECH2, value); }
        //}
        //double fECH3;
        //public double ECH3
        //{
        //    get { return fECH3; }
        //    set { SetPropertyValue<double>("ECH3", ref fECH3, value); }
        //}
        //double fECH4;
        //public double ECH4
        //{
        //    get { return fECH4; }
        //    set { SetPropertyValue<double>("ECH4", ref fECH4, value); }
        //}
        //double fECH5;
        //public double ECH5
        //{
        //    get { return fECH5; }
        //    set { SetPropertyValue<double>("ECH5", ref fECH5, value); }
        //}
        //double fECH6;
        //public double ECH6
        //{
        //    get { return fECH6; }
        //    set { SetPropertyValue<double>("ECH6", ref fECH6, value); }
        //}
        //double fECH7;
        //public double ECH7
        //{
        //    get { return fECH7; }
        //    set { SetPropertyValue<double>("ECH7", ref fECH7, value); }
        //}
        //double fECH8;
        //public double ECH8
        //{
        //    get { return fECH8; }
        //    set { SetPropertyValue<double>("ECH8", ref fECH8, value); }
        //}
        //double fECH9;
        //public double ECH9
        //{
        //    get { return fECH9; }
        //    set { SetPropertyValue<double>("ECH9", ref fECH9, value); }
        //}
        //double fECH10;
        //public double ECH10
        //{
        //    get { return fECH10; }
        //    set { SetPropertyValue<double>("ECH10", ref fECH10, value); }
        //}
        //double fECH11;
        //public double ECH11
        //{
        //    get { return fECH11; }
        //    set { SetPropertyValue<double>("ECH11", ref fECH11, value); }
        //}
        //double fECH12;
        //public double ECH12
        //{
        //    get { return fECH12; }
        //    set { SetPropertyValue<double>("ECH12", ref fECH12, value); }
        //}
        
        public Bareme(Session session)
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
