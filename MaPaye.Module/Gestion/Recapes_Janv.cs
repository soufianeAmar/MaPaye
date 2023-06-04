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
    public class Recapes_Janv : BaseObject
    {

        private Recape_Annuelle recape_Annuelle_Janv;
        [Association("Recape_Annuelle_Janv-Recapes_Janv", typeof(Recape_Annuelle))]
        public Recape_Annuelle Recape_Annuelle_Janv
        {
            get { return recape_Annuelle_Janv; }
            set
            {
                SetPropertyValue("Recape_Annuelle_Janv", ref recape_Annuelle_Janv, value);
            }

        }
 

        private CategorieCloture fCategorie;
        public CategorieCloture Categorie
        {
            get { return fCategorie; }
            set { SetPropertyValue<CategorieCloture>("Categorie", ref fCategorie, value); }
        }


        private decimal fBrut_Impo_Taux;
        public decimal Brut_Impo_Taux
        {
            get { return fBrut_Impo_Taux; }
            set { SetPropertyValue<decimal>("Brut_Impo_Taux", ref fBrut_Impo_Taux, value); }
        }

        private decimal fIRG_Taux;
        public decimal IRG_Taux
        {
            get { return fIRG_Taux; }
            set { SetPropertyValue<decimal>("IRG_Taux", ref fIRG_Taux, value); }
        }

        private decimal fBrut_Impo_Bareme;
        public decimal Brut_Impo_Bareme
        {
            get { return fBrut_Impo_Bareme; }
            set { SetPropertyValue<decimal>("Brut_Impo_Bareme", ref fBrut_Impo_Bareme, value); }
        }

        private decimal fIRG_Bareme;
        public decimal IRG_Bareme
        {
            get { return fIRG_Bareme; }
            set { SetPropertyValue<decimal>("IRG_Bareme", ref fIRG_Bareme, value); }
        }

        private decimal fBrut_Cotis;
        public decimal Brut_Cotis
        {
            get { return fBrut_Cotis; }
            set { SetPropertyValue<decimal>("Brut_Cotis", ref fBrut_Cotis, value); }
        }

        private decimal fSS;
        public decimal SS
        {
            get { return fSS; }
            set { SetPropertyValue<decimal>("SS", ref fSS, value); }
        }

        private decimal fBrut_Impo;
        public decimal Brut_Impo
        {
            get { return fBrut_Impo; }
            set { SetPropertyValue<decimal>("Brut_Impo", ref fBrut_Impo, value); }
        }

        private decimal fIRG;
        public decimal IRG
        {
            get { return fIRG; }
            set { SetPropertyValue<decimal>("IRG", ref fIRG, value); }
        }

        private decimal fNET;
        public decimal NET
        {
            get { return fNET; }
            set { SetPropertyValue<decimal>("NET", ref fNET, value); }
        }

        private int fNbr_jour_abs;
        public int Nbr_jour_abs
        {
            get { return fNbr_jour_abs; }
            set { SetPropertyValue<int>("Nbr_jour_abs", ref fNbr_jour_abs, value); }
        }

        private double fJour_Abs;
        public double Jour_Abs
        {
            get
            { 
                return fJour_Abs;
            }
            set { SetPropertyValue<double>("Jour_Abs", ref fJour_Abs, value); }
        }

        private int fNbr_jour_ouv;
        public int Nbr_jour_ouv
        {
            get { return fNbr_jour_ouv; }
            set { SetPropertyValue<int>("Nbr_jour_ouv", ref fNbr_jour_ouv, value); }
        }


        private double fTaux_pp1;
        public double Taux_pp1
        {
            get { return fTaux_pp1; }
            set { SetPropertyValue<double>("Taux_pp1", ref fTaux_pp1, value); }
        }

        private double fTaux_pp2;
        public double Taux_pp2
        {
            get { return fTaux_pp2; }
            set { SetPropertyValue<double>("Taux_pp2", ref fTaux_pp2, value); }
        }

        private double fTaux_pp3;
        public double Taux_pp3
        {
            get { return fTaux_pp3; }
            set { SetPropertyValue<double>("Taux_pp3", ref fTaux_pp3, value); }
        }

        private decimal fPP1;
        public decimal PP1
        {
            get { return fPP1; }
            set { SetPropertyValue<decimal>("PP1", ref fPP1, value); }
        }

        private decimal fPP2;
        public decimal PP2
        {
            get { return fPP2; }
            set { SetPropertyValue<decimal>("PP2", ref fPP2, value); }
        }

        private decimal fPP3;
        public decimal PP3
        {
            get { return fPP3; }
            set { SetPropertyValue<decimal>("PP3", ref fPP3, value); }
        }

        private MoisdelAnnee fMois; 
        public MoisdelAnnee Mois
        {
            get { return fMois; }
            set { SetPropertyValue<MoisdelAnnee>("Mois", ref fMois, value); }
        }


        private parametre fparametres;
        public parametre parametres
        {
            get { return fparametres; }
            set { SetPropertyValue<parametre>("parametres", ref fparametres, value); }
        }



        public Recapes_Janv(Session session)
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

            parametre Parametres = Session.FindObject<parametre>(null); 
            parametres = Parametres; 
        }

        protected override void OnDeleting()
        {
          

        }




    }


}
