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
    public class BaremePMG : BaseObject
    {
        private double fBorneInférieure; 
        public double BorneInférieure
        {
            get { return fBorneInférieure; }
            set { SetPropertyValue<double>("BorneInférieure", ref fBorneInférieure, value); }
        }

        private double fBorneSupérieure; 
        public double BorneSupérieure
        {
            get { return fBorneSupérieure; }
            set { SetPropertyValue<double>("BorneSupérieure", ref fBorneSupérieure, value); }
        }

        private decimal fMontant;
        public decimal Montant
        {
            get { return fMontant; }
            set { SetPropertyValue<decimal>("Montant", ref fMontant, value); }
        }
 
        public BaremePMG(Session session)
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
