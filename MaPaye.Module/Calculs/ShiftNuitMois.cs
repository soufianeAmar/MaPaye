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
    public class ShiftNuitMois : BaseObject
    { 
        private PrimeShiftNuit primeShiftNuit;
        [Association("PrimeShiftNuit-ShiftNuitMois", typeof(PrimeShiftNuit))]
        public PrimeShiftNuit PrimeShiftNuit
        {
            get { return primeShiftNuit; }
            set
            {
                SetPropertyValue("PrimeShiftNuit", ref primeShiftNuit, value);

            } 
        }

        private decimal fMontant;
        public decimal Montant
        {
            get { return fMontant; }
            set { SetPropertyValue<decimal>("Montant", ref fMontant, value); }
        }

        private double fNbr;
        public double Nbr
        {
            get { return fNbr; }
            set { SetPropertyValue<double>("Nbr", ref fNbr, value); }
        }

        private int fJourMois;
        public int JourMois
        {
            get { return fJourMois; }
            set { SetPropertyValue<int>("JourMois", ref fJourMois, value); }
        }

        private bool fJrsCongCalcule;
        public bool JrsCongCalcule
        {
            get { return fJrsCongCalcule; }
            set { SetPropertyValue<bool>("JrsCongCalcule", ref fJrsCongCalcule, value); }
        }

        public ShiftNuitMois(Session session)
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
