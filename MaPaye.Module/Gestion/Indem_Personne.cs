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
    public class Indem_Personne : BaseObject
    {
        private string fIndemPersonne; 
        public string IndemPersonne
        {
            get
            {
                if (Personne != null && Indem != null)
                    fIndemPersonne = Personne.ToString() + Indem.ToString();
                return fIndemPersonne;
            }
        }
        private Personne personne;
        //Tadjou One to many 
        [Association("Personnes-Indem_Personnes", typeof(Personne))]
        public Personne Personne
        {
            get { return personne; }
            set { SetPropertyValue("Personne", ref personne, value); }
        }

       
        private Indem findem;
        [Association("Indem-Indem_Personnes", typeof(Indem))]
        public Indem Indem
        {
            get { return findem; }
            set { SetPropertyValue("Indem", ref findem, value); }
        }

        private decimal fMontant;
        public decimal Montant
        {
            get { return fMontant; }
            set { SetPropertyValue<decimal>("Montant", ref fMontant, value); }
        }
        private decimal fBase;
        public decimal Base
        {
            get { return fBase; }
            set { SetPropertyValue<decimal>("Base", ref fBase, value); }
        }
        private double fTaux;
        public double Taux
        {
            get { return fTaux; }
            set { SetPropertyValue<double>("Taux", ref fTaux, value); }
        } 

        private double fINbr;
        public double INbr
        {
            get { return fINbr; }
            set { SetPropertyValue<double>("INbr", ref fINbr, value); }
        }

        private bool fModifSpecial;
        public bool ModifSpecial
        {
            get { return fModifSpecial; }
            set { SetPropertyValue<bool>("ModifSpecial", ref fModifSpecial, value); }
        }

        //private bool fDivise_Par_2;
        //public bool Divise_Par_2
        //{
        //    get { return fDivise_Par_2; }
        //    set { SetPropertyValue<bool>("Divise_Par_2", ref fDivise_Par_2, value); }
        //}


        public Indem_Personne(Session session)
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
