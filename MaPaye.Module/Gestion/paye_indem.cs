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
    public class paye_indem : BaseObject
    {
        //Tadjou One to many 
        private Paye paye;
        [Association("Paye-paye_indems", typeof(Paye))]
        public Paye Paye
        {
            get { return paye; }
            set
            {
                SetPropertyValue("Paye", ref paye, value);

            }

        }

        private Indem fIndemnite;
        public Indem Indemnite
        {
            get { return fIndemnite; }
            set { SetPropertyValue<Indem>("Indem", ref fIndemnite, value); }
        }


        private decimal fMontant;
        public decimal Montant
        {
            get { return fMontant; }
            set { SetPropertyValue<decimal>("Montant", ref fMontant, value); }
        }

        private decimal fIBase;
        public decimal IBase
        {
            get { return fIBase; }
            set { SetPropertyValue<decimal>("IBase", ref fIBase, value); }
        }
        private double fITaux;
        public double ITaux
        {
            get { return fITaux; }
            set { SetPropertyValue<double>("ITaux", ref fITaux, value); }
        }
        private double fINbr;
        public double INbr
        {
            get { return fINbr; }
            set { SetPropertyValue<double>("INbr", ref fINbr, value); }
        }

        private decimal fMontant_Absence;
        public decimal Montant_Absence
        {
            get { return fMontant_Absence; }
            set { SetPropertyValue<decimal>("Montant_Absence", ref fMontant_Absence, value); }
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

        private parametre fparametres;
        public parametre parametres
        {
            get { return fparametres; }
            set { SetPropertyValue<parametre>("parametres", ref fparametres, value); }
        }

        private decimal fMontant_Debit;
        public decimal Montant_Debit
        {
            get { return fMontant_Debit; }
            set { SetPropertyValue<decimal>("Montant_Debit", ref fMontant_Debit, value); }
        }

        private decimal fMontant_Credit;
        public decimal Montant_Credit
        {
            get { return fMontant_Credit; }
            set { SetPropertyValue<decimal>("Montant_Credit", ref fMontant_Credit, value); }
        }
         
 

        public paye_indem(Session session)
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
            //Ordre_Affichage = Indemnite.Ordre_Affichage;
        }

        protected override void OnDeleting()
        {
            //string ind = Indemnite.Cod_indem_interne.ToString();
            decimal zero = (decimal)0;
            this.Paye.AffectationIndemniteLignesAuColonnes(zero, this);
            base.OnDeleting();

        }

        protected override void OnSaving()
        {
            base.OnSaving();

            Montant_Credit = 0;
            Montant_Debit = 0;

            if (Indemnite != null)
            {
                if (Indemnite.Compte_Debit == true)
                    Montant_Debit = Montant_Absence;

                if (Indemnite.Compte_Credit == true)
                    Montant_Credit = Montant_Absence;
            }
             
        }



    }


}
