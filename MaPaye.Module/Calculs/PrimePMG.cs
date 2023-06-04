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
    public class PrimePMG : BaseObject
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

        [Association("PrimePMG-PMGMois", typeof(PMGMois))]
        public XPCollection pMGMois
        {
            get { return GetCollection("pMGMois"); }
        }


        //private double fPMG1; 
        //public double PMG1
        //{
        //    get { return fPMG1; }
        //    set { SetPropertyValue<double>("PMG1", ref fPMG1, value); }
        //}
         
        //private double fPMG2; 
        //public double PMG2
        //{
        //    get { return fPMG2; }
        //    set { SetPropertyValue<double>("PMG2", ref fPMG2, value); }
        //}
          
        //private double fPMG3; 
        //public double PMG3
        //{
        //    get { return fPMG3; }
        //    set { SetPropertyValue<double>("PMG3", ref fPMG3, value); }
        //}
          
        //private double fPMG4; 
        //public double PMG4
        //{
        //    get { return fPMG4; }
        //    set { SetPropertyValue<double>("PMG4", ref fPMG4, value); }
        //}
          
        //private double fPMG5; 
        //public double PMG5
        //{
        //    get { return fPMG5; }
        //    set { SetPropertyValue<double>("PMG5", ref fPMG5, value); }
        //}
          
        //private double fPMG6; 
        //public double PMG6
        //{
        //    get { return fPMG6; }
        //    set { SetPropertyValue<double>("PMG6", ref fPMG6, value); }
        //}
          
        //private double fPMG7; 
        //public double PMG7
        //{
        //    get { return fPMG7; }
        //    set { SetPropertyValue<double>("PMG7", ref fPMG7, value); }
        //}
          
        //private double fPMG8; 
        //public double PMG8
        //{
        //    get { return fPMG8; }
        //    set { SetPropertyValue<double>("PMG8", ref fPMG8, value); }
        //}
          
        //private double fPMG9; 
        //public double PMG9
        //{
        //    get { return fPMG9; }
        //    set { SetPropertyValue<double>("PMG9", ref fPMG9, value); }
        //}
          
        //private double fPMG10; 
        //public double PMG10
        //{
        //    get { return fPMG10; }
        //    set { SetPropertyValue<double>("PMG10", ref fPMG10, value); }
        //}
          
        //private double fPMG11; 
        //public double PMG11
        //{
        //    get { return fPMG11; }
        //    set { SetPropertyValue<double>("PMG11", ref fPMG11, value); }
        //}
          
        //private double fPMG12; 
        //public double PMG12
        //{
        //    get { return fPMG12; }
        //    set { SetPropertyValue<double>("PMG12", ref fPMG12, value); }
        //}
          
        //private double fPMG13; 
        //public double PMG13
        //{
        //    get { return fPMG13; }
        //    set { SetPropertyValue<double>("PMG13", ref fPMG13, value); }
        //}
          
        //private double fPMG14; 
        //public double PMG14
        //{
        //    get { return fPMG14; }
        //    set { SetPropertyValue<double>("PMG14", ref fPMG14, value); }
        //}
          
        //private double fPMG15; 
        //public double PMG15
        //{
        //    get { return fPMG15; }
        //    set { SetPropertyValue<double>("PMG15", ref fPMG15, value); }
        //}
          
        //private double fPMG16; 
        //public double PMG16
        //{
        //    get { return fPMG16; }
        //    set { SetPropertyValue<double>("PMG16", ref fPMG16, value); }
        //}
          
        //private double fPMG17; 
        //public double PMG17
        //{
        //    get { return fPMG17; }
        //    set { SetPropertyValue<double>("PMG17", ref fPMG17, value); }
        //}
          
        //private double fPMG18; 
        //public double PMG18
        //{
        //    get { return fPMG18; }
        //    set { SetPropertyValue<double>("PMG18", ref fPMG18, value); }
        //}
          
        //private double fPMG19; 
        //public double PMG19
        //{
        //    get { return fPMG19; }
        //    set { SetPropertyValue<double>("PMG19", ref fPMG19, value); }
        //}
          
        //private double fPMG20; 
        //public double PMG20
        //{
        //    get { return fPMG20; }
        //    set { SetPropertyValue<double>("PMG20", ref fPMG20, value); }
        //}
          
        //private double fPMG21; 
        //public double PMG21
        //{
        //    get { return fPMG21; }
        //    set { SetPropertyValue<double>("PMG21", ref fPMG21, value); }
        //}
          
        //private double fPMG22; 
        //public double PMG22
        //{
        //    get { return fPMG22; }
        //    set { SetPropertyValue<double>("PMG22", ref fPMG22, value); }
        //}
          
        //private double fPMG23; 
        //public double PMG23
        //{
        //    get { return fPMG23; }
        //    set { SetPropertyValue<double>("PMG23", ref fPMG23, value); }
        //}
          
        //private double fPMG24; 
        //public double PMG24
        //{
        //    get { return fPMG24; }
        //    set { SetPropertyValue<double>("PMG24", ref fPMG24, value); }
        //}
          
        //private double fPMG25; 
        //public double PMG25
        //{
        //    get { return fPMG25; }
        //    set { SetPropertyValue<double>("PMG25", ref fPMG25, value); }
        //}
          
        //private double fPMG26; 
        //public double PMG26
        //{
        //    get { return fPMG26; }
        //    set { SetPropertyValue<double>("PMG26", ref fPMG26, value); }
        //}
          
        //private double fPMG27; 
        //public double PMG27
        //{
        //    get { return fPMG27; }
        //    set { SetPropertyValue<double>("PMG27", ref fPMG27, value); }
        //}
          
        //private double fPMG28; 
        //public double PMG28
        //{
        //    get { return fPMG28; }
        //    set { SetPropertyValue<double>("PMG28", ref fPMG28, value); }
        //}
          
        //private double fPMG29; 
        //public double PMG29
        //{
        //    get { return fPMG29; }
        //    set { SetPropertyValue<double>("PMG29", ref fPMG29, value); }
        //}
          
        //private double fPMG30; 
        //public double PMG30
        //{
        //    get { return fPMG30; }
        //    set { SetPropertyValue<double>("PMG30", ref fPMG30, value); }
        //}
           
        //private double fPMG31; 
        //public double PMG31
        //{
        //    get { return fPMG31; }
        //    set { SetPropertyValue<double>("PMG31", ref fPMG31, value); }
        //}
         
        public PrimePMG(Session session)
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
