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
    [DefaultClassOptions]
    public class PrimeShiftNuit : BaseObject
    {
        private Personne fEmploye;
        public Personne Employe
        {
            get { return fEmploye; }
            set { SetPropertyValue<Personne>("Employe", ref fEmploye, value); }
        }

        private MoisdelAnnee fMois;
        public MoisdelAnnee Mois
        {
            get { return fMois; }
            set { SetPropertyValue<MoisdelAnnee>("Mois", ref fMois, value); }
        }

        [Association("PrimeShiftNuit-ShiftNuitMois", typeof(ShiftNuitMois))]
        public XPCollection shiftNuitMois
        {
            get { return GetCollection("shiftNuitMois"); }
        }

        //private double fShiftNuit1; 
        //public double ShiftNuit1
        //{
        //    get { return fShiftNuit1; }
        //    set { SetPropertyValue<double>("ShiftNuit1", ref fShiftNuit1, value); }
        //}
         
        //private double fShiftNuit2; 
        //public double ShiftNuit2
        //{
        //    get { return fShiftNuit2; }
        //    set { SetPropertyValue<double>("ShiftNuit2", ref fShiftNuit2, value); }
        //}
          
        //private double fShiftNuit3; 
        //public double ShiftNuit3
        //{
        //    get { return fShiftNuit3; }
        //    set { SetPropertyValue<double>("ShiftNuit3", ref fShiftNuit3, value); }
        //}
          
        //private double fShiftNuit4; 
        //public double ShiftNuit4
        //{
        //    get { return fShiftNuit4; }
        //    set { SetPropertyValue<double>("ShiftNuit4", ref fShiftNuit4, value); }
        //}
          
        //private double fShiftNuit5; 
        //public double ShiftNuit5
        //{
        //    get { return fShiftNuit5; }
        //    set { SetPropertyValue<double>("ShiftNuit5", ref fShiftNuit5, value); }
        //}
          
        //private double fShiftNuit6; 
        //public double ShiftNuit6
        //{
        //    get { return fShiftNuit6; }
        //    set { SetPropertyValue<double>("ShiftNuit6", ref fShiftNuit6, value); }
        //}
          
        //private double fShiftNuit7; 
        //public double ShiftNuit7
        //{
        //    get { return fShiftNuit7; }
        //    set { SetPropertyValue<double>("ShiftNuit7", ref fShiftNuit7, value); }
        //}
          
        //private double fShiftNuit8; 
        //public double ShiftNuit8
        //{
        //    get { return fShiftNuit8; }
        //    set { SetPropertyValue<double>("ShiftNuit8", ref fShiftNuit8, value); }
        //}
          
        //private double fShiftNuit9; 
        //public double ShiftNuit9
        //{
        //    get { return fShiftNuit9; }
        //    set { SetPropertyValue<double>("ShiftNuit9", ref fShiftNuit9, value); }
        //}
          
        //private double fShiftNuit10; 
        //public double ShiftNuit10
        //{
        //    get { return fShiftNuit10; }
        //    set { SetPropertyValue<double>("ShiftNuit10", ref fShiftNuit10, value); }
        //}
          
        //private double fShiftNuit11; 
        //public double ShiftNuit11
        //{
        //    get { return fShiftNuit11; }
        //    set { SetPropertyValue<double>("ShiftNuit11", ref fShiftNuit11, value); }
        //}
          
        //private double fShiftNuit12; 
        //public double ShiftNuit12
        //{
        //    get { return fShiftNuit12; }
        //    set { SetPropertyValue<double>("ShiftNuit12", ref fShiftNuit12, value); }
        //}
          
        //private double fShiftNuit13; 
        //public double ShiftNuit13
        //{
        //    get { return fShiftNuit13; }
        //    set { SetPropertyValue<double>("ShiftNuit13", ref fShiftNuit13, value); }
        //}
          
        //private double fShiftNuit14; 
        //public double ShiftNuit14
        //{
        //    get { return fShiftNuit14; }
        //    set { SetPropertyValue<double>("ShiftNuit14", ref fShiftNuit14, value); }
        //}
          
        //private double fShiftNuit15; 
        //public double ShiftNuit15
        //{
        //    get { return fShiftNuit15; }
        //    set { SetPropertyValue<double>("ShiftNuit15", ref fShiftNuit15, value); }
        //}
          
        //private double fShiftNuit16; 
        //public double ShiftNuit16
        //{
        //    get { return fShiftNuit16; }
        //    set { SetPropertyValue<double>("ShiftNuit16", ref fShiftNuit16, value); }
        //}
          
        //private double fShiftNuit17; 
        //public double ShiftNuit17
        //{
        //    get { return fShiftNuit17; }
        //    set { SetPropertyValue<double>("ShiftNuit17", ref fShiftNuit17, value); }
        //}
          
        //private double fShiftNuit18; 
        //public double ShiftNuit18
        //{
        //    get { return fShiftNuit18; }
        //    set { SetPropertyValue<double>("ShiftNuit18", ref fShiftNuit18, value); }
        //}
          
        //private double fShiftNuit19; 
        //public double ShiftNuit19
        //{
        //    get { return fShiftNuit19; }
        //    set { SetPropertyValue<double>("ShiftNuit19", ref fShiftNuit19, value); }
        //}
          
        //private double fShiftNuit20; 
        //public double ShiftNuit20
        //{
        //    get { return fShiftNuit20; }
        //    set { SetPropertyValue<double>("ShiftNuit20", ref fShiftNuit20, value); }
        //}
          
        //private double fShiftNuit21; 
        //public double ShiftNuit21
        //{
        //    get { return fShiftNuit21; }
        //    set { SetPropertyValue<double>("ShiftNuit21", ref fShiftNuit21, value); }
        //}
          
        //private double fShiftNuit22; 
        //public double ShiftNuit22
        //{
        //    get { return fShiftNuit22; }
        //    set { SetPropertyValue<double>("ShiftNuit22", ref fShiftNuit22, value); }
        //}
          
        //private double fShiftNuit23; 
        //public double ShiftNuit23
        //{
        //    get { return fShiftNuit23; }
        //    set { SetPropertyValue<double>("ShiftNuit23", ref fShiftNuit23, value); }
        //}
          
        //private double fShiftNuit24; 
        //public double ShiftNuit24
        //{
        //    get { return fShiftNuit24; }
        //    set { SetPropertyValue<double>("ShiftNuit24", ref fShiftNuit24, value); }
        //}
          
        //private double fShiftNuit25; 
        //public double ShiftNuit25
        //{
        //    get { return fShiftNuit25; }
        //    set { SetPropertyValue<double>("ShiftNuit25", ref fShiftNuit25, value); }
        //}
          
        //private double fShiftNuit26; 
        //public double ShiftNuit26
        //{
        //    get { return fShiftNuit26; }
        //    set { SetPropertyValue<double>("ShiftNuit26", ref fShiftNuit26, value); }
        //}
          
        //private double fShiftNuit27; 
        //public double ShiftNuit27
        //{
        //    get { return fShiftNuit27; }
        //    set { SetPropertyValue<double>("ShiftNuit27", ref fShiftNuit27, value); }
        //}
          
        //private double fShiftNuit28; 
        //public double ShiftNuit28
        //{
        //    get { return fShiftNuit28; }
        //    set { SetPropertyValue<double>("ShiftNuit28", ref fShiftNuit28, value); }
        //}
          
        //private double fShiftNuit29; 
        //public double ShiftNuit29
        //{
        //    get { return fShiftNuit29; }
        //    set { SetPropertyValue<double>("ShiftNuit29", ref fShiftNuit29, value); }
        //}
          
        //private double fShiftNuit30; 
        //public double ShiftNuit30
        //{
        //    get { return fShiftNuit30; }
        //    set { SetPropertyValue<double>("ShiftNuit30", ref fShiftNuit30, value); }
        //}
           
        //private double fShiftNuit31; 
        //public double ShiftNuit31
        //{
        //    get { return fShiftNuit31; }
        //    set { SetPropertyValue<double>("ShiftNuit31", ref fShiftNuit31, value); }
        //}

        public PrimeShiftNuit(Session session)
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
