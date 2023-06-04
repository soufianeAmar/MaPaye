using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using System.Windows.Forms;
using DevExpress.ExpressApp.DC; 

namespace MaPaye.Module
{  
    public enum InclusBrutNet { Net, Brut, Sans }
    public enum ModeCalculIRG { [XafDisplayName("Sur Barême")]Sur_Barême, [XafDisplayName("Sur Taux")] Sur_Taux, Aucun };
     
     
    [DefaultClassOptions]
    [System.ComponentModel.DefaultProperty("Cod_indem")]

    public class Indem : BaseObject
    {
        [Association("Indem-Indem_Personnes", typeof(Indem_Personne))]
        public XPCollection Indem_Personnes
        {
            get { return GetCollection("Indem_Personnes"); }
        }

        [Association("Indem-Indem_Fonctions", typeof(Indem_Fonction))]
        public XPCollection Indem_Fonctions
        {
            get { return GetCollection("Indem_Fonctions"); }
        }

        private string fCode;
        public string Code
        {
            get { return fCode; }
            set { SetPropertyValue<string>("Code", ref fCode, value); }
        } 

        private string fCod_indem_interne;
        public string Cod_indem_interne
        {
            get { return fCod_indem_interne; }
            set { SetPropertyValue<string>("Cod_indem_interne", ref fCod_indem_interne, value); }
        } 
         
        private string fCod_indem; 
        public string Cod_indem
        {
            get { return fCod_indem; }
            set { SetPropertyValue<string>("Cod_indem", ref fCod_indem, value); }
        }

        private string fCod_Rubrique;
        public string Cod_Rubrique
        {
            get { return fCod_Rubrique; }
            set { SetPropertyValue<string>("Cod_Rubrique", ref fCod_Rubrique, value); }
        }
         
        private string fLib_indem;
        public string Lib_indem
        {
            get { return fLib_indem; }
            set { SetPropertyValue<string>("Lib_indem", ref fLib_indem, value); }
        }

        //private string fLib_indem_Ar;
        //public string Lib_indem_Ar
        //{
        //    get { return fLib_indem_Ar; }
        //    set { SetPropertyValue<string>("Lib_indem_Ar", ref fLib_indem_Ar, value); }
        //}

        private string fLib_indem_cour;
        public string Lib_indem_cour
        {
            get { return fLib_indem_cour; }
            set { SetPropertyValue<string>("Lib_indem_cour", ref fLib_indem_cour, value); }
        }

        private string fForm_cal;
        public string Form_cal
        {
            get { return fForm_cal; }
            set { SetPropertyValue<string>("Form_cal", ref fForm_cal, value); }
        }

        private bool fCotisable;
        public bool Cotisable
        {
            get { return fCotisable; }
            set { SetPropertyValue<bool>("Cotisable", ref fCotisable, value); }
        }

        private bool fImposable;
        public bool Imposable
        {
            get { return fImposable; }
            set { SetPropertyValue<bool>("Imposable", ref fImposable, value); }
        }

        private string fCondition1;
        public string Condition1
        {
            get { return fCondition1; }
            set { SetPropertyValue<string>("Condition1", ref fCondition1, value); }
        }

        private string fForm_base;
        public string Form_base
        {
            get { return fForm_base; }
            set { SetPropertyValue<string>("Form_base", ref fForm_base, value); }
        }

        private string fForm_nbr;
        public string Form_nbr
        {
            get { return fForm_nbr; }
            set { SetPropertyValue<string>("Form_nbr", ref fForm_nbr, value); }
        }

        private string fForm_taux;
        public string Form_taux
        {
            get { return fForm_taux; }
            set { SetPropertyValue<string>("Form_taux", ref fForm_taux, value); }
        }

        private bool fPour_tous;
        public bool Pour_tous
        {
            get { return fPour_tous; }
            set { SetPropertyValue<bool>("Pour_tous", ref fPour_tous, value); }
        }

        private bool fTaux_par_pou;
        public bool Taux_par_pou
        {
            get { return fTaux_par_pou; }
            set { SetPropertyValue<bool>("Taux_par_pou", ref fTaux_par_pou, value); }
        }

        private int fnbr_dec;
        public int nbr_dec
        {
            get { return fnbr_dec; }
            set { SetPropertyValue<int>("nbr_dec", ref fnbr_dec, value); }
        }

        private int fOrdre_Affichage;
        public int Ordre_Affichage
        {
            get { return fOrdre_Affichage; }
            set { SetPropertyValue<int>("Ordre_Affichage", ref fOrdre_Affichage, value); }
        }

        private ModeCalculIRG fMod_cal_irg;
        public ModeCalculIRG Mod_cal_irg
        {
            get { return fMod_cal_irg; }
            set { SetPropertyValue<ModeCalculIRG>("Mod_cal_irg", ref fMod_cal_irg, value); }
        }

        private parametre fparametres;
        public parametre parametres
        {
            get { return fparametres; }
            set {  SetPropertyValue<parametre>("parametres", ref fparametres, value); }
        }

        private string fObservation;
        public string Observation
        {
            get { return fObservation; }
            set { SetPropertyValue<string>("Observation", ref fObservation, value); }
        }


        private InclusBrutNet fBrut_Net_Incluse;
        public InclusBrutNet Brut_Net_Incluse
        {
            get { return fBrut_Net_Incluse; }
            set { SetPropertyValue<InclusBrutNet>("Brut_Net_Incluse", ref fBrut_Net_Incluse, value); }
        }

        private bool fRetenue;
        public bool Retenue
        {
            get { return fRetenue; }
            set { SetPropertyValue<bool>("Retenue", ref fRetenue, value); }
        }
 
        //private bool fRappelPrime;
        //public bool RappelPrime
        //{
        //    get { return fRappelPrime; }
        //    set { SetPropertyValue<bool>("RappelPrime", ref fRappelPrime, value); }
        //}
 
        /// <summary>
        /// Par défaut 30 / peut être 22
        /// et si 0 alors ne pas calculer absence tel que AF
        /// </summary>
        private int fMode_Calcul_Absence;
        public int Mode_Calcul_Absence
        {
            get { return fMode_Calcul_Absence; }
            set { SetPropertyValue<int>("Mode_Calcul_Absence", ref fMode_Calcul_Absence, value); }
        }

        //private string fCod_Comptable_Debit;
        //public string Cod_Comptable_Debit
        //{
        //    get { return fCod_Comptable_Debit; }
        //    set { SetPropertyValue<string>("Cod_Comptable_Debit", ref fCod_Comptable_Debit, value); }
        //}

        //private string fCod_Comptable_Credit;
        //public string Cod_Comptable_Credit
        //{
        //    get { return fCod_Comptable_Credit; }
        //    set { SetPropertyValue<string>("Cod_Comptable_Credit", ref fCod_Comptable_Credit, value); }
        //}

        private string fCompte_Comptable;
        public string Compte_Comptable
        {
            get { return fCompte_Comptable; }
            set { SetPropertyValue<string>("Compte_Comptable", ref fCompte_Comptable, value); }
        }

        private bool fCompte_Debit;
        public bool Compte_Debit
        {
            get { return fCompte_Debit; }
            set { SetPropertyValue<bool>("Compte_Debit", ref fCompte_Debit, value); }
        }

        private bool fCompte_Credit;
        public bool Compte_Credit
        {
            get { return fCompte_Credit; }
            set { SetPropertyValue<bool>("Compte_Credit", ref fCompte_Credit, value); }
        }

        private decimal fValeur_Min;
        public decimal Valeur_Min
        {
            get { return fValeur_Min; }
            set { SetPropertyValue<decimal>("Valeur_Min", ref fValeur_Min, value); }
        }

        private decimal fValeur_Max;
        public decimal Valeur_Max
        {
            get { return fValeur_Max; }
            set { SetPropertyValue<decimal>("Valeur_Max", ref fValeur_Max, value); }
        }


        private bool fValeur_Minimale;
        public bool Valeur_Minimale
        {
            get { return fValeur_Minimale; }
            set { SetPropertyValue<bool>("Valeur_Minimale", ref fValeur_Minimale, value); }
        }

        private bool fValeur_Maximale;
        public bool Valeur_Maximale
        {
            get { return fValeur_Maximale; }
            set { SetPropertyValue<bool>("Valeur_Maximale", ref fValeur_Maximale, value); }
        }
        public Indem(Session session)
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


            parametres = parametre.GetInstance(Session);

            //parametres = Parametres;
            // Place here your initialization code.
        }

        protected override void OnSaved()
        {
            base.OnSaved();

            //if (Mode_Calcul_Absence != parametres.Nbr_jour_tra && Mode_Calcul_Absence != 0)
            //    MessageBox.Show("Le mode calcul absence est différent du nombre de jours de travail, les absences ne vont pas être calculé correctement sur cette indemnité !");
        }

        protected override void OnLoading()
        {
            base.OnLoading();

            if (parametres != null)
                if (Mode_Calcul_Absence != parametres.Nbr_jour_tra && Mode_Calcul_Absence != 0)
                    Mode_Calcul_Absence = parametres.Nbr_jour_tra;
        }
    }


}
