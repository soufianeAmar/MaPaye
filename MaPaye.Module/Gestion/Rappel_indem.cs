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
    public class Rappel_indem : BaseObject
    {
        //Tadjou One to many 
        private Rappel rappel;
        [Association("Rappel-Rappel_indems", typeof(Rappel))]
        public Rappel Rappel
        {
            get { return rappel; }
            set
            {
                SetPropertyValue("Rappel", ref rappel, value); 
               
            }

        }

        private Indem fIndemnite;
        public Indem Indemnite
        {
            get { return fIndemnite; }
            set { SetPropertyValue<Indem>("Indem", ref fIndemnite, value); }
        }

        private string fCod_indem;
        public string Cod_indem
        {
            get { return fCod_indem; }
            set { SetPropertyValue<string>("Cod_indem", ref fCod_indem, value); }
        }

        private string fCod_indem_interne;
        public string Cod_indem_interne
        {
            get { return fCod_indem_interne; }
            set { SetPropertyValue<string>("Cod_indem_interne", ref fCod_indem_interne, value); }
        }

        private string fCod_Rappel;
        public string Cod_Rappel
        {
            get { return fCod_Rappel; }
            set { SetPropertyValue<string>("Cod_Rappel", ref fCod_Rappel, value); }
        }

        private decimal fMontant_Ancien;
        public decimal Montant_Ancien
        {
            get { return fMontant_Ancien; }
            set { SetPropertyValue<decimal>("Montant_Ancien", ref fMontant_Ancien, value); }
        }

        private decimal fMontant_Nouveau;
        public decimal Montant_Nouveau
        {
            get { return fMontant_Nouveau; }
            set { SetPropertyValue<decimal>("Montant_Nouveau", ref fMontant_Nouveau, value); }
        }

        private decimal fMontant_Dif;
        public decimal Montant_Dif
        {
            get { return fMontant_Dif; }
            set { SetPropertyValue<decimal>("Montant__Dif", ref fMontant_Dif, value); }
        }
         
        private decimal fMontant_Mois;
        public decimal Montant_Mois
        {
            get { return fMontant_Mois; }
            set { SetPropertyValue<decimal>("Montant_Mois", ref fMontant_Mois, value); }
        }



        //private int fFeuillet;
        //public int Feuillet
        //{
        //    get { return fFeuillet; }
        //    set { SetPropertyValue<int>("Feuillet", ref fFeuillet, value); }
        //}

        //private decimal fIBase;
        //public decimal IBase
        //{
        //    get { return fIBase; }
        //    set { SetPropertyValue<decimal>("IBase", ref fIBase, value); }
        //}
        //private double fITaux;
        //public double ITaux
        //{
        //    get { return fITaux; }
        //    set { SetPropertyValue<double>("ITaux", ref fITaux, value); }
        //}
        //private double fINbr;
        //public double INbr
        //{
        //    get { return fINbr; }
        //    set { SetPropertyValue<double>("INbr", ref fINbr, value); }
        //}

        //private decimal fMontant_Absence;
        //public decimal Montant_Absence
        //{
        //    get { return fMontant_Absence; }
        //    set { SetPropertyValue<decimal>("Montant_Absence", ref fMontant_Absence, value); }
        //}

        //private int fOrdre_Affichage;
        //public int Ordre_Affichage
        //{
        //    get { return fOrdre_Affichage; }
        //    set { SetPropertyValue<int>("Ordre_Affichage", ref fOrdre_Affichage, value); }
        //}

        public Rappel_indem(Session session)
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

            //Cod_indem = Indemnite.Cod_indem;
        }

        


    }

}
