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
    //[DefaultProperty("CATEG")]
    [DefaultClassOptions]
    public class BaremeShiftNuit : BaseObject
    {
        private TimeSpan fBorneInférieure; 
        public TimeSpan BorneInférieure
        {
            get { return fBorneInférieure; }
            set { SetPropertyValue<TimeSpan>("BorneInférieure", ref fBorneInférieure, value); }
        }

        private int fBorneInférieureDay;
        public int BorneInférieureDay
        {
            get { return fBorneInférieureDay; }
            set { SetPropertyValue<int>("BorneInférieureDay", ref fBorneInférieureDay, value); }
        }

        private TimeSpan fBorneSupérieure; 
        public TimeSpan BorneSupérieure
        {
            get { return fBorneSupérieure; }
            set { SetPropertyValue<TimeSpan>("BorneSupérieure", ref fBorneSupérieure, value); }
        }

        private int fBorneSupérieureDay; 
        public int BorneSupérieureDay
        {
            get { return fBorneSupérieureDay; }
            set { SetPropertyValue<int>("BorneSupérieureDay", ref fBorneSupérieureDay, value); }
        }

        //private double fNbr;
        //public double Nbr
        //{
        //    get
        //    {
        //        if (BorneSupérieure >= BorneInférieure)
        //            fNbr = (double)(BorneSupérieure.Hours - BorneInférieure.Hours);
        //        return fNbr;
        //    }
        //    //set { SetPropertyValue<double>("Nbr", ref fNbr, value); }
        //}

        private decimal fMontant;
        public decimal Montant
        {
            get { return fMontant; }
            set { SetPropertyValue<decimal>("Montant", ref fMontant, value); }
        }

        public BaremeShiftNuit(Session session)
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
