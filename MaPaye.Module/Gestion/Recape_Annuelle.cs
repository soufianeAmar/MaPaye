using System;

using DevExpress.Xpo;

using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Data.Filtering;
using System.Windows.Forms;

namespace MaPaye.Module
{
    [DefaultClassOptions]
    public class Recape_Annuelle : BaseObject
    {

        private string fCod_Recape;
        public string Cod_Recape
        {
            get { return fCod_Recape; }
            set { SetPropertyValue<string>("Cod_Recape", ref fCod_Recape, value); }
        }

        private Personne fpersonne;
        public Personne personne
        {
            get { return fpersonne; }
            set { SetPropertyValue<Personne>("personne", ref fpersonne, value); }
        }

        private int fAnnee;
        public int Annee
        {
            get { return fAnnee; }
            set { SetPropertyValue<int>("Annee", ref fAnnee, value); }
        }

        private Unite fUnite;
        public Unite Unite
        {
            get { return fUnite; }
            set { SetPropertyValue<Unite>("Unite", ref fUnite, value); }
        }


        private string fNumEmployeur;
        [Size(50)]
        public string NumEmployeur
        {
            get
            { 
                return fNumEmployeur;
            }
            set { SetPropertyValue<string>("NumEmployeur", ref fNumEmployeur, value); }
        }

        /***************************************** Janvier *********************************************/
        [Association("Recape_Annuelle_Janv-Recapes_Janv", typeof(Recapes_Janv))]
        //[Association("Recape_Annuelle-Recapes", typeof(Recapes))]
        public XPCollection recapes_Janv
        {
            get { return GetCollection("recapes_Janv"); }
        }

        private decimal fBrut_Impo_Taux_Janv;
        public decimal Brut_Impo_Taux_Janv
        {
            get { return fBrut_Impo_Taux_Janv; }
            set { SetPropertyValue<decimal>("Brut_Impo_Taux_Janv", ref fBrut_Impo_Taux_Janv, value); }
        }

        private decimal fIRG_Taux_Janv;
        public decimal IRG_Taux_Janv
        {
            get { return fIRG_Taux_Janv; }
            set { SetPropertyValue<decimal>("IRG_Taux_Janv", ref fIRG_Taux_Janv, value); }
        }

        private decimal fBrut_Impo_Bareme_Janv;
        public decimal Brut_Impo_Bareme_Janv
        {
            get { return fBrut_Impo_Bareme_Janv; }
            set { SetPropertyValue<decimal>("Brut_Impo_Bareme_Janv", ref fBrut_Impo_Bareme_Janv, value); }
        }

        private decimal fIRG_Bareme_Janv;
        public decimal IRG_Bareme_Janv
        {
            get { return fIRG_Bareme_Janv; }
            set { SetPropertyValue<decimal>("IRG_Bareme_Janv", ref fIRG_Bareme_Janv, value); }
        }

        private decimal fBrut_Cotis_Janv;
        public decimal Brut_Cotis_Janv
        {
            get { return fBrut_Cotis_Janv; }
            set { SetPropertyValue<decimal>("Brut_Cotis_Janv", ref fBrut_Cotis_Janv, value); }
        }

        private decimal fSS_Janv;
        public decimal SS_Janv
        {
            get { return fSS_Janv; }
            set { SetPropertyValue<decimal>("SS_Janv", ref fSS_Janv, value); }
        }

        private decimal fBrut_Impo_Janv;
        public decimal Brut_Impo_Janv
        {
            get { return fBrut_Impo_Janv; }
            set { SetPropertyValue<decimal>("Brut_Impo_Janv", ref fBrut_Impo_Janv, value); }
        }

        private decimal fIRG_Janv;
        public decimal IRG_Janv
        {
            get { return fIRG_Janv; }
            set { SetPropertyValue<decimal>("IRG_Janv", ref fIRG_Janv, value); }
        }

        private decimal fNET_Janv;
        public decimal NET_Janv
        {
            get { return fNET_Janv; }
            set { SetPropertyValue<decimal>("NET_Janv", ref fNET_Janv, value); }
        }

        private int fEntree_Janv;
        public int Entree_Janv
        {
            get { return fEntree_Janv; }
            set { SetPropertyValue<int>("Entree_Janv", ref fEntree_Janv, value); }
        }

        private int fSortie_Janv;
        public int Sortie_Janv
        {
            get { return fSortie_Janv; }
            set { SetPropertyValue<int>("Sortie_Janv", ref fSortie_Janv, value); }
        }

        private double fTaux_pp1_Janv;
        public double Taux_pp1_Janv
        {
            get { return fTaux_pp1_Janv; }
            set { SetPropertyValue<double>("Taux_pp1_Janv", ref fTaux_pp1_Janv, value); }
        }

        private double fTaux_pp2_Janv;
        public double Taux_pp2_Janv
        {
            get { return fTaux_pp2_Janv; }
            set { SetPropertyValue<double>("Taux_pp2_Janv", ref fTaux_pp2_Janv, value); }
        }

        private double fTaux_pp3_Janv;
        public double Taux_pp3_Janv
        {
            get { return fTaux_pp3_Janv; }
            set { SetPropertyValue<double>("Taux_pp3_Janv", ref fTaux_pp3_Janv, value); }
        }

        private decimal fPP1_Janv;
        public decimal PP1_Janv
        {
            get { return fPP1_Janv; }
            set { SetPropertyValue<decimal>("PP1_Janv", ref fPP1_Janv, value); }
        }

        private decimal fPP2_Janv;
        public decimal PP2_Janv
        {
            get { return fPP2_Janv; }
            set { SetPropertyValue<decimal>("PP2_Janv", ref fPP2_Janv, value); }
        }

        private decimal fPP3_Janv;
        public decimal PP3_Janv
        {
            get { return fPP3_Janv; }
            set { SetPropertyValue<decimal>("PP3_Janv", ref fPP3_Janv, value); }
        }

        private int fEff_Janv;
        public int Eff_Janv
        {
            get { return fEff_Janv; }
            set { SetPropertyValue<int>("Eff_Janv", ref fEff_Janv, value); }
        }

        private double fJour_Abs_Janv;
        public double Jour_Abs_Janv
        {
            get
            {
                return fJour_Abs_Janv;
            }
            set { SetPropertyValue<double>("Jour_Abs_Janv", ref fJour_Abs_Janv, value); }
        }

        private int fNbr_jour_abs_Janv;
        public int Nbr_jour_abs_Janv
        {
            get
            {
                return fNbr_jour_abs_Janv;
            }
            set { SetPropertyValue<int>("Nbr_jour_abs_Janv", ref fNbr_jour_abs_Janv, value); }
        }

        private int fNbr_jour_ouv_Janv;
        public int Nbr_jour_ouv_Janv
        {
            get { return fNbr_jour_ouv_Janv; }
            set { SetPropertyValue<int>("Nbr_jour_ouv_Janv", ref fNbr_jour_ouv_Janv, value); }
        }

        private double fNbr_jour_cong_Janv;
        public double Nbr_jour_cong_Janv
        {
            get { return fNbr_jour_cong_Janv; }
            set { SetPropertyValue<double>("Nbr_jour_cong_Janv", ref fNbr_jour_cong_Janv, value); }
        }

        /***************************************** Février *********************************************/

        [Association("Recape_Annuelle_Fev-Recapes_Fev", typeof(Recapes_Fev))]
        public XPCollection recapes_Fev
        {
            get { return GetCollection("recapes_Fev"); }
        }

        private decimal fBrut_Impo_Taux_Fev;
        public decimal Brut_Impo_Taux_Fev
        {
            get { return fBrut_Impo_Taux_Fev; }
            set { SetPropertyValue<decimal>("Brut_Impo_Taux_Fev", ref fBrut_Impo_Taux_Fev, value); }
        }

        private decimal fIRG_Taux_Fev;
        public decimal IRG_Taux_Fev
        {
            get { return fIRG_Taux_Fev; }
            set { SetPropertyValue<decimal>("IRG_Taux_Fev", ref fIRG_Taux_Fev, value); }
        }

        private decimal fBrut_Impo_Bareme_Fev;
        public decimal Brut_Impo_Bareme_Fev
        {
            get { return fBrut_Impo_Bareme_Fev; }
            set { SetPropertyValue<decimal>("Brut_Impo_Bareme_Fev", ref fBrut_Impo_Bareme_Fev, value); }
        }

        private decimal fIRG_Bareme_Fev;
        public decimal IRG_Bareme_Fev
        {
            get { return fIRG_Bareme_Fev; }
            set { SetPropertyValue<decimal>("IRG_Bareme_Fev", ref fIRG_Bareme_Fev, value); }
        }

        private decimal fBrut_Cotis_Fev;
        public decimal Brut_Cotis_Fev
        {
            get { return fBrut_Cotis_Fev; }
            set { SetPropertyValue<decimal>("Brut_Cotis_Fev", ref fBrut_Cotis_Fev, value); }
        }

        private decimal fSS_Fev;
        public decimal SS_Fev
        {
            get { return fSS_Fev; }
            set { SetPropertyValue<decimal>("SS_Fev", ref fSS_Fev, value); }
        }

        private decimal fBrut_Impo_Fev;
        public decimal Brut_Impo_Fev
        {
            get { return fBrut_Impo_Fev; }
            set { SetPropertyValue<decimal>("Brut_Impo_Fev", ref fBrut_Impo_Fev, value); }
        }

        private decimal fIRG_Fev;
        public decimal IRG_Fev
        {
            get { return fIRG_Fev; }
            set { SetPropertyValue<decimal>("IRG_Fev", ref fIRG_Fev, value); }
        }

        private decimal fNET_Fev;
        public decimal NET_Fev
        {
            get { return fNET_Fev; }
            set { SetPropertyValue<decimal>("NET_Fev", ref fNET_Fev, value); }
        }

        private int fEntree_Fev;
        public int Entree_Fev
        {
            get { return fEntree_Fev; }
            set { SetPropertyValue<int>("Entree_Fev", ref fEntree_Fev, value); }
        }

        private int fSortie_Fev;
        public int Sortie_Fev
        {
            get { return fSortie_Fev; }
            set { SetPropertyValue<int>("Sortie_Fev", ref fSortie_Fev, value); }
        }

        private double fTaux_pp1_Fev;
        public double Taux_pp1_Fev
        {
            get { return fTaux_pp1_Fev; }
            set { SetPropertyValue<double>("Taux_pp1_Fev", ref fTaux_pp1_Fev, value); }
        }

        private double fTaux_pp2_Fev;
        public double Taux_pp2_Fev
        {
            get { return fTaux_pp2_Fev; }
            set { SetPropertyValue<double>("Taux_pp2_Fev", ref fTaux_pp2_Fev, value); }
        }

        private double fTaux_pp3_Fev;
        public double Taux_pp3_Fev
        {
            get { return fTaux_pp3_Fev; }
            set { SetPropertyValue<double>("Taux_pp3_Fev", ref fTaux_pp3_Fev, value); }
        }

        private decimal fPP1_Fev;
        public decimal PP1_Fev
        {
            get { return fPP1_Fev; }
            set { SetPropertyValue<decimal>("PP1_Fev", ref fPP1_Fev, value); }
        }

        private decimal fPP2_Fev;
        public decimal PP2_Fev
        {
            get { return fPP2_Fev; }
            set { SetPropertyValue<decimal>("PP2_Fev", ref fPP2_Fev, value); }
        }

        private decimal fPP3_Fev;
        public decimal PP3_Fev
        {
            get { return fPP3_Fev; }
            set { SetPropertyValue<decimal>("PP3_Fev", ref fPP3_Fev, value); }
        }
         
        private int fEff_Fev;
        public int Eff_Fev
        {
            get { return fEff_Fev; }
            set { SetPropertyValue<int>("Eff_Fev", ref fEff_Fev, value); }
        }

        private double fJour_Abs_Fev;
        public double Jour_Abs_Fev
        {
            get
            {
                return fJour_Abs_Fev;
            }
            set { SetPropertyValue<double>("Jour_Abs_Fev", ref fJour_Abs_Fev, value); }
        }

        private int fNbr_jour_abs_Fev;
        public int Nbr_jour_abs_Fev
        {
            get
            {
                return fNbr_jour_abs_Fev;
            }
            set { SetPropertyValue<int>("Nbr_jour_abs_Fev", ref fNbr_jour_abs_Fev, value); }
        }

        private int fNbr_jour_ouv_Fev;
        public int Nbr_jour_ouv_Fev
        {
            get { return fNbr_jour_ouv_Fev; }
            set { SetPropertyValue<int>("Nbr_jour_ouv_Fev", ref fNbr_jour_ouv_Fev, value); }
        }


        private double fNbr_jour_cong_Fev;
        public double Nbr_jour_cong_Fev
        {
            get { return fNbr_jour_cong_Fev; }
            set { SetPropertyValue<double>("Nbr_jour_cong_Fev", ref fNbr_jour_cong_Fev, value); }
        }

        /***************************************** Mars *********************************************/
        [Association("Recape_Annuelle_Mars-Recapes_Mars", typeof(Recapes_Mars))]
        public XPCollection recapes_Mars
        {
            get { return GetCollection("recapes_Mars"); }
        }

        private decimal fBrut_Impo_Taux_Mars;
        public decimal Brut_Impo_Taux_Mars
        {
            get { return fBrut_Impo_Taux_Mars; }
            set { SetPropertyValue<decimal>("Brut_Impo_Taux_Mars", ref fBrut_Impo_Taux_Mars, value); }
        }

        private decimal fIRG_Taux_Mars;
        public decimal IRG_Taux_Mars
        {
            get { return fIRG_Taux_Mars; }
            set { SetPropertyValue<decimal>("IRG_Taux_Mars", ref fIRG_Taux_Mars, value); }
        }

        private decimal fBrut_Impo_Bareme_Mars;
        public decimal Brut_Impo_Bareme_Mars
        {
            get { return fBrut_Impo_Bareme_Mars; }
            set { SetPropertyValue<decimal>("Brut_Impo_Bareme_Mars", ref fBrut_Impo_Bareme_Mars, value); }
        }

        private decimal fIRG_Bareme_Mars;
        public decimal IRG_Bareme_Mars
        {
            get { return fIRG_Bareme_Mars; }
            set { SetPropertyValue<decimal>("IRG_Bareme_Mars", ref fIRG_Bareme_Mars, value); }
        }

        private decimal fBrut_Cotis_Mars;
        public decimal Brut_Cotis_Mars
        {
            get { return fBrut_Cotis_Mars; }
            set { SetPropertyValue<decimal>("Brut_Cotis_Mars", ref fBrut_Cotis_Mars, value); }
        }

        private decimal fSS_Mars;
        public decimal SS_Mars
        {
            get { return fSS_Mars; }
            set { SetPropertyValue<decimal>("SS_Mars", ref fSS_Mars, value); }
        }

        private decimal fBrut_Impo_Mars;
        public decimal Brut_Impo_Mars
        {
            get { return fBrut_Impo_Mars; }
            set { SetPropertyValue<decimal>("Brut_Impo_Mars", ref fBrut_Impo_Mars, value); }
        }

        private decimal fIRG_Mars;
        public decimal IRG_Mars
        {
            get { return fIRG_Mars; }
            set { SetPropertyValue<decimal>("IRG_Mars", ref fIRG_Mars, value); }
        }

        private decimal fNET_Mars;
        public decimal NET_Mars
        {
            get { return fNET_Mars; }
            set { SetPropertyValue<decimal>("NET_Mars", ref fNET_Mars, value); }
        }

        private int fEntree_Mars;
        public int Entree_Mars
        {
            get { return fEntree_Mars; }
            set { SetPropertyValue<int>("Entree_Mars", ref fEntree_Mars, value); }
        }

        private int fSortie_Mars;
        public int Sortie_Mars
        {
            get { return fSortie_Mars; }
            set { SetPropertyValue<int>("Sortie_Mars", ref fSortie_Mars, value); }
        }

        private double fTaux_pp1_Mars;
        public double Taux_pp1_Mars
        {
            get { return fTaux_pp1_Mars; }
            set { SetPropertyValue<double>("Taux_pp1_Mars", ref fTaux_pp1_Mars, value); }
        }

        private double fTaux_pp2_Mars;
        public double Taux_pp2_Mars
        {
            get { return fTaux_pp2_Mars; }
            set { SetPropertyValue<double>("Taux_pp2_Mars", ref fTaux_pp2_Mars, value); }
        }

        private double fTaux_pp3_Mars;
        public double Taux_pp3_Mars
        {
            get { return fTaux_pp3_Mars; }
            set { SetPropertyValue<double>("Taux_pp3_Mars", ref fTaux_pp3_Mars, value); }
        }

        private decimal fPP1_Mars;
        public decimal PP1_Mars
        {
            get { return fPP1_Mars; }
            set { SetPropertyValue<decimal>("PP1_Mars", ref fPP1_Mars, value); }
        }

        private decimal fPP2_Mars;
        public decimal PP2_Mars
        {
            get { return fPP2_Mars; }
            set { SetPropertyValue<decimal>("PP2_Mars", ref fPP2_Mars, value); }
        }

        private decimal fPP3_Mars;
        public decimal PP3_Mars
        {
            get { return fPP3_Mars; }
            set { SetPropertyValue<decimal>("PP3_Mars", ref fPP3_Mars, value); }
        }

        private int fEff_Mars;
        public int Eff_Mars
        {
            get { return fEff_Mars; }
            set { SetPropertyValue<int>("Eff_Mars", ref fEff_Mars, value); }
        }

        private int fNbr_jour_abs_Mars;
        public int Nbr_jour_abs_Mars
        {
            get
            {
                return fNbr_jour_abs_Mars;
            }
            set { SetPropertyValue<int>("Nbr_jour_abs_Mars", ref fNbr_jour_abs_Mars, value); }
        }

        private double fJour_Abs_Mars;
        public double Jour_Abs_Mars
        {
            get
            {
                return fJour_Abs_Mars;
            }
            set { SetPropertyValue<double>("Jour_Abs_Mars", ref fJour_Abs_Mars, value); }
        }
        private int fNbr_jour_ouv_Mars;
        public int Nbr_jour_ouv_Mars
        {
            get { return fNbr_jour_ouv_Mars; }
            set { SetPropertyValue<int>("Nbr_jour_ouv_Mars", ref fNbr_jour_ouv_Mars, value); }
        }

        private double fNbr_jour_cong_Mars;
        public double Nbr_jour_cong_Mars
        {
            get { return fNbr_jour_cong_Mars; }
            set { SetPropertyValue<double>("Nbr_jour_cong_Mars", ref fNbr_jour_cong_Mars, value); }
        }

        /***************************************** Avril *********************************************/
        [Association("Recape_Annuelle_Avr-Recapes_Avr", typeof(Recapes_Avr))]
        public XPCollection recapes_Avr
        {
            get { return GetCollection("recapes_Avr"); }
        }

        private decimal fBrut_Impo_Taux_Avr;
        public decimal Brut_Impo_Taux_Avr
        {
            get { return fBrut_Impo_Taux_Avr; }
            set { SetPropertyValue<decimal>("Brut_Impo_Taux_Avr", ref fBrut_Impo_Taux_Avr, value); }
        }

        private decimal fIRG_Taux_Avr;
        public decimal IRG_Taux_Avr
        {
            get { return fIRG_Taux_Avr; }
            set { SetPropertyValue<decimal>("IRG_Taux_Avr", ref fIRG_Taux_Avr, value); }
        }

        private decimal fBrut_Impo_Bareme_Avr;
        public decimal Brut_Impo_Bareme_Avr
        {
            get { return fBrut_Impo_Bareme_Avr; }
            set { SetPropertyValue<decimal>("Brut_Impo_Bareme_Avr", ref fBrut_Impo_Bareme_Avr, value); }
        }

        private decimal fIRG_Bareme_Avr;
        public decimal IRG_Bareme_Avr
        {
            get { return fIRG_Bareme_Avr; }
            set { SetPropertyValue<decimal>("IRG_Bareme_Avr", ref fIRG_Bareme_Avr, value); }
        }

        private decimal fBrut_Cotis_Avr;
        public decimal Brut_Cotis_Avr
        {
            get { return fBrut_Cotis_Avr; }
            set { SetPropertyValue<decimal>("Brut_Cotis_Avr", ref fBrut_Cotis_Avr, value); }
        }

        private decimal fSS_Avr;
        public decimal SS_Avr
        {
            get { return fSS_Avr; }
            set { SetPropertyValue<decimal>("SS_Avr", ref fSS_Avr, value); }
        }

        private decimal fBrut_Impo_Avr;
        public decimal Brut_Impo_Avr
        {
            get { return fBrut_Impo_Avr; }
            set { SetPropertyValue<decimal>("Brut_Impo_Avr", ref fBrut_Impo_Avr, value); }
        }

        private decimal fIRG_Avr;
        public decimal IRG_Avr
        {
            get { return fIRG_Avr; }
            set { SetPropertyValue<decimal>("IRG_Avr", ref fIRG_Avr, value); }
        }

        private decimal fNET_Avr;
        public decimal NET_Avr
        {
            get { return fNET_Avr; }
            set { SetPropertyValue<decimal>("NET_Avr", ref fNET_Avr, value); }
        }

        private int fEntree_Avr;
        public int Entree_Avr
        {
            get { return fEntree_Avr; }
            set { SetPropertyValue<int>("Entree_Avr", ref fEntree_Avr, value); }
        }

        private int fSortie_Avr;
        public int Sortie_Avr
        {
            get { return fSortie_Avr; }
            set { SetPropertyValue<int>("Sortie_Avr", ref fSortie_Avr, value); }
        }

        private double fTaux_pp1_Avr;
        public double Taux_pp1_Avr
        {
            get { return fTaux_pp1_Avr; }
            set { SetPropertyValue<double>("Taux_pp1_Avr", ref fTaux_pp1_Avr, value); }
        }

        private double fTaux_pp2_Avr;
        public double Taux_pp2_Avr
        {
            get { return fTaux_pp2_Avr; }
            set { SetPropertyValue<double>("Taux_pp2_Avr", ref fTaux_pp2_Avr, value); }
        }

        private double fTaux_pp3_Avr;
        public double Taux_pp3_Avr
        {
            get { return fTaux_pp3_Avr; }
            set { SetPropertyValue<double>("Taux_pp3_Avr", ref fTaux_pp3_Avr, value); }
        }

        private decimal fPP1_Avr;
        public decimal PP1_Avr
        {
            get { return fPP1_Avr; }
            set { SetPropertyValue<decimal>("PP1_Avr", ref fPP1_Avr, value); }
        }

        private decimal fPP2_Avr;
        public decimal PP2_Avr
        {
            get { return fPP2_Avr; }
            set { SetPropertyValue<decimal>("PP2_Avr", ref fPP2_Avr, value); }
        }

        private decimal fPP3_Avr;
        public decimal PP3_Avr
        {
            get { return fPP3_Avr; }
            set { SetPropertyValue<decimal>("PP3_Avr", ref fPP3_Avr, value); }
        }


        private int fEff_Avr;
        public int Eff_Avr
        {
            get { return fEff_Avr; }
            set { SetPropertyValue<int>("Eff_Avr", ref fEff_Avr, value); }
        }

        private int fNbr_jour_abs_Avr;
        public int Nbr_jour_abs_Avr
        {
            get
            {
                return fNbr_jour_abs_Avr;
            }
            set { SetPropertyValue<int>("Nbr_jour_abs_Avr", ref fNbr_jour_abs_Avr, value); }
        }

        private double fJour_Abs_Avr;
        public double Jour_Abs_Avr
        {
            get
            {
                return fJour_Abs_Avr;
            }
            set { SetPropertyValue<double>("Jour_Abs_Avr", ref fJour_Abs_Avr, value); }
        }

        private int fNbr_jour_ouv_Avr;
        public int Nbr_jour_ouv_Avr
        {
            get { return fNbr_jour_ouv_Avr; }
            set { SetPropertyValue<int>("Nbr_jour_ouv_Avr", ref fNbr_jour_ouv_Avr, value); }
        }

        private double fNbr_jour_cong_Avr;
        public double Nbr_jour_cong_Avr
        {
            get { return fNbr_jour_cong_Avr; }
            set { SetPropertyValue<double>("Nbr_jour_cong_Avr", ref fNbr_jour_cong_Avr, value); }
        }

        /***************************************** Mai *********************************************/
        [Association("Recape_Annuelle_Mai-Recapes_Mai", typeof(Recapes_Mai))]
        public XPCollection recapes_Mai
        {
            get { return GetCollection("recapes_Mai"); }
        }

        private decimal fBrut_Impo_Taux_Mai;
        public decimal Brut_Impo_Taux_Mai
        {
            get { return fBrut_Impo_Taux_Mai; }
            set { SetPropertyValue<decimal>("Brut_Impo_Taux_Mai", ref fBrut_Impo_Taux_Mai, value); }
        }

        private decimal fIRG_Taux_Mai;
        public decimal IRG_Taux_Mai
        {
            get { return fIRG_Taux_Mai; }
            set { SetPropertyValue<decimal>("IRG_Taux_Mai", ref fIRG_Taux_Mai, value); }
        }

        private decimal fBrut_Impo_Bareme_Mai;
        public decimal Brut_Impo_Bareme_Mai
        {
            get { return fBrut_Impo_Bareme_Mai; }
            set { SetPropertyValue<decimal>("Brut_Impo_Bareme_Mai", ref fBrut_Impo_Bareme_Mai, value); }
        }

        private decimal fIRG_Bareme_Mai;
        public decimal IRG_Bareme_Mai
        {
            get { return fIRG_Bareme_Mai; }
            set { SetPropertyValue<decimal>("IRG_Bareme_Mai", ref fIRG_Bareme_Mai, value); }
        }

        private decimal fBrut_Cotis_Mai;
        public decimal Brut_Cotis_Mai
        {
            get { return fBrut_Cotis_Mai; }
            set { SetPropertyValue<decimal>("Brut_Cotis_Mai", ref fBrut_Cotis_Mai, value); }
        }

        private decimal fSS_Mai;
        public decimal SS_Mai
        {
            get { return fSS_Mai; }
            set { SetPropertyValue<decimal>("SS_Mai", ref fSS_Mai, value); }
        }

        private decimal fBrut_Impo_Mai;
        public decimal Brut_Impo_Mai
        {
            get { return fBrut_Impo_Mai; }
            set { SetPropertyValue<decimal>("Brut_Impo_Mai", ref fBrut_Impo_Mai, value); }
        }

        private decimal fIRG_Mai;
        public decimal IRG_Mai
        {
            get { return fIRG_Mai; }
            set { SetPropertyValue<decimal>("IRG_Mai", ref fIRG_Mai, value); }
        }

        private decimal fNET_Mai;
        public decimal NET_Mai
        {
            get { return fNET_Mai; }
            set { SetPropertyValue<decimal>("NET_Mai", ref fNET_Mai, value); }
        }

        private int fEntree_Mai;
        public int Entree_Mai
        {
            get { return fEntree_Mai; }
            set { SetPropertyValue<int>("Entree_Mai", ref fEntree_Mai, value); }
        }

        private int fSortie_Mai;
        public int Sortie_Mai
        {
            get { return fSortie_Mai; }
            set { SetPropertyValue<int>("Sortie_Mai", ref fSortie_Mai, value); }
        }

        private double fTaux_pp1_Mai;
        public double Taux_pp1_Mai
        {
            get { return fTaux_pp1_Mai; }
            set { SetPropertyValue<double>("Taux_pp1_Mai", ref fTaux_pp1_Mai, value); }
        }

        private double fTaux_pp2_Mai;
        public double Taux_pp2_Mai
        {
            get { return fTaux_pp2_Mai; }
            set { SetPropertyValue<double>("Taux_pp2_Mai", ref fTaux_pp2_Mai, value); }
        }

        private double fTaux_pp3_Mai;
        public double Taux_pp3_Mai
        {
            get { return fTaux_pp3_Mai; }
            set { SetPropertyValue<double>("Taux_pp3_Mai", ref fTaux_pp3_Mai, value); }
        }

        private decimal fPP1_Mai;
        public decimal PP1_Mai
        {
            get { return fPP1_Mai; }
            set { SetPropertyValue<decimal>("PP1_Mai", ref fPP1_Mai, value); }
        }

        private decimal fPP2_Mai;
        public decimal PP2_Mai
        {
            get { return fPP2_Mai; }
            set { SetPropertyValue<decimal>("PP2_Mai", ref fPP2_Mai, value); }
        }

        private decimal fPP3_Mai;
        public decimal PP3_Mai
        {
            get { return fPP3_Mai; }
            set { SetPropertyValue<decimal>("PP3_Mai", ref fPP3_Mai, value); }
        }

        private int fEff_Mai;
        public int Eff_Mai
        {
            get { return fEff_Mai; }
            set { SetPropertyValue<int>("Eff_Mai", ref fEff_Mai, value); }
        }

        private int fNbr_jour_abs_Mai;
        public int Nbr_jour_abs_Mai
        {
            get
            {
                return fNbr_jour_abs_Mai;
            }
            set { SetPropertyValue<int>("Nbr_jour_abs_Mai", ref fNbr_jour_abs_Mai, value); }
        }

        private double fJour_Abs_Mai;
        public double Jour_Abs_Mai
        {
            get
            {
                return fJour_Abs_Mai;
            }
            set { SetPropertyValue<double>("Jour_Abs_Mai", ref fJour_Abs_Mai, value); }
        }

        private int fNbr_jour_ouv_Mai;
        public int Nbr_jour_ouv_Mai
        {
            get { return fNbr_jour_ouv_Mai; }
            set { SetPropertyValue<int>("Nbr_jour_ouv_Mai", ref fNbr_jour_ouv_Mai, value); }
        }

        private double fNbr_jour_cong_Mai;
        public double Nbr_jour_cong_Mai
        {
            get { return fNbr_jour_cong_Mai; }
            set { SetPropertyValue<double>("Nbr_jour_cong_Mai", ref fNbr_jour_cong_Mai, value); }
        }

        /***************************************** Juin *********************************************/
        [Association("Recape_Annuelle_Juin-Recapes_Juin", typeof(Recapes_Juin))]
        public XPCollection recapes_Juin
        {
            get { return GetCollection("recapes_Juin"); }
        }

        private decimal fBrut_Impo_Taux_Juin;
        public decimal Brut_Impo_Taux_Juin
        {
            get { return fBrut_Impo_Taux_Juin; }
            set { SetPropertyValue<decimal>("Brut_Impo_Taux_Juin", ref fBrut_Impo_Taux_Juin, value); }
        }

        private decimal fIRG_Taux_Juin;
        public decimal IRG_Taux_Juin
        {
            get { return fIRG_Taux_Juin; }
            set { SetPropertyValue<decimal>("IRG_Taux_Juin", ref fIRG_Taux_Juin, value); }
        }

        private decimal fBrut_Impo_Bareme_Juin;
        public decimal Brut_Impo_Bareme_Juin
        {
            get { return fBrut_Impo_Bareme_Juin; }
            set { SetPropertyValue<decimal>("Brut_Impo_Bareme_Juin", ref fBrut_Impo_Bareme_Juin, value); }
        }

        private decimal fIRG_Bareme_Juin;
        public decimal IRG_Bareme_Juin
        {
            get { return fIRG_Bareme_Juin; }
            set { SetPropertyValue<decimal>("IRG_Bareme_Juin", ref fIRG_Bareme_Juin, value); }
        }

        private decimal fBrut_Cotis_Juin;
        public decimal Brut_Cotis_Juin
        {
            get { return fBrut_Cotis_Juin; }
            set { SetPropertyValue<decimal>("Brut_Cotis_Juin", ref fBrut_Cotis_Juin, value); }
        }

        private decimal fSS_Juin;
        public decimal SS_Juin
        {
            get { return fSS_Juin; }
            set { SetPropertyValue<decimal>("SS_Juin", ref fSS_Juin, value); }
        }

        private decimal fBrut_Impo_Juin;
        public decimal Brut_Impo_Juin
        {
            get { return fBrut_Impo_Juin; }
            set { SetPropertyValue<decimal>("Brut_Impo_Juin", ref fBrut_Impo_Juin, value); }
        }

        private decimal fIRG_Juin;
        public decimal IRG_Juin
        {
            get { return fIRG_Juin; }
            set { SetPropertyValue<decimal>("IRG_Juin", ref fIRG_Juin, value); }
        }

        private decimal fNET_Juin;
        public decimal NET_Juin
        {
            get { return fNET_Juin; }
            set { SetPropertyValue<decimal>("NET_Juin", ref fNET_Juin, value); }
        }

        private int fEntree_Juin;
        public int Entree_Juin
        {
            get { return fEntree_Juin; }
            set { SetPropertyValue<int>("Entree_Juin", ref fEntree_Juin, value); }
        }

        private int fSortie_Juin;
        public int Sortie_Juin
        {
            get { return fSortie_Juin; }
            set { SetPropertyValue<int>("Sortie_Juin", ref fSortie_Juin, value); }
        }

        private double fTaux_pp1_Juin;
        public double Taux_pp1_Juin
        {
            get { return fTaux_pp1_Juin; }
            set { SetPropertyValue<double>("Taux_pp1_Juin", ref fTaux_pp1_Juin, value); }
        }

        private double fTaux_pp2_Juin;
        public double Taux_pp2_Juin
        {
            get { return fTaux_pp2_Juin; }
            set { SetPropertyValue<double>("Taux_pp2_Juin", ref fTaux_pp2_Juin, value); }
        }

        private double fTaux_pp3_Juin;
        public double Taux_pp3_Juin
        {
            get { return fTaux_pp3_Juin; }
            set { SetPropertyValue<double>("Taux_pp3_Juin", ref fTaux_pp3_Juin, value); }
        }

        private decimal fPP1_Juin;
        public decimal PP1_Juin
        {
            get { return fPP1_Juin; }
            set { SetPropertyValue<decimal>("PP1_Juin", ref fPP1_Juin, value); }
        }

        private decimal fPP2_Juin;
        public decimal PP2_Juin
        {
            get { return fPP2_Juin; }
            set { SetPropertyValue<decimal>("PP2_Juin", ref fPP2_Juin, value); }
        }

        private decimal fPP3_Juin;
        public decimal PP3_Juin
        {
            get { return fPP3_Juin; }
            set { SetPropertyValue<decimal>("PP3_Juin", ref fPP3_Juin, value); }
        }

        private int fEff_Juin;
        public int Eff_Juin
        {
            get { return fEff_Juin; }
            set { SetPropertyValue<int>("Eff_Juin", ref fEff_Juin, value); }
        }

        private int fNbr_jour_abs_Juin;
        public int Nbr_jour_abs_Juin
        {
            get
            {
                return fNbr_jour_abs_Juin;
            }
            set { SetPropertyValue<int>("Nbr_jour_abs_Juin", ref fNbr_jour_abs_Juin, value); }
        }

        private double fJour_Abs_Juin;
        public double Jour_Abs_Juin
        {
            get
            {
                return fJour_Abs_Juin;
            }
            set { SetPropertyValue<double>("Jour_Abs_Juin", ref fJour_Abs_Juin, value); }
        }

        private int fNbr_jour_ouv_Juin;
        public int Nbr_jour_ouv_Juin
        {
            get { return fNbr_jour_ouv_Juin; }
            set { SetPropertyValue<int>("Nbr_jour_ouv_Juin", ref fNbr_jour_ouv_Juin, value); }
        }

        private double fNbr_jour_cong_Juin;
        public double Nbr_jour_cong_Juin
        {
            get { return fNbr_jour_cong_Juin; }
            set { SetPropertyValue<double>("Nbr_jour_cong_Juin", ref fNbr_jour_cong_Juin, value); }
        }

        /***************************************** Juillet *********************************************/
        [Association("Recape_Annuelle_Juill-Recapes_Juill", typeof(Recapes_Juill))]
        public XPCollection recapes_Juill
        {
            get { return GetCollection("recapes_Juill"); }
        }

        private decimal fBrut_Impo_Taux_Juill;
        public decimal Brut_Impo_Taux_Juill
        {
            get { return fBrut_Impo_Taux_Juill; }
            set { SetPropertyValue<decimal>("Brut_Impo_Taux_Juill", ref fBrut_Impo_Taux_Juill, value); }
        }

        private decimal fIRG_Taux_Juill;
        public decimal IRG_Taux_Juill
        {
            get { return fIRG_Taux_Juill; }
            set { SetPropertyValue<decimal>("IRG_Taux_Juill", ref fIRG_Taux_Juill, value); }
        }

        private decimal fBrut_Impo_Bareme_Juill;
        public decimal Brut_Impo_Bareme_Juill
        {
            get { return fBrut_Impo_Bareme_Juill; }
            set { SetPropertyValue<decimal>("Brut_Impo_Bareme_Juill", ref fBrut_Impo_Bareme_Juill, value); }
        }

        private decimal fIRG_Bareme_Juill;
        public decimal IRG_Bareme_Juill
        {
            get { return fIRG_Bareme_Juill; }
            set { SetPropertyValue<decimal>("IRG_Bareme_Juill", ref fIRG_Bareme_Juill, value); }
        }

        private decimal fBrut_Cotis_Juill;
        public decimal Brut_Cotis_Juill
        {
            get { return fBrut_Cotis_Juill; }
            set { SetPropertyValue<decimal>("Brut_Cotis_Juill", ref fBrut_Cotis_Juill, value); }
        }

        private decimal fSS_Juill;
        public decimal SS_Juill
        {
            get { return fSS_Juill; }
            set { SetPropertyValue<decimal>("SS_Juill", ref fSS_Juill, value); }
        }

        private decimal fBrut_Impo_Juill;
        public decimal Brut_Impo_Juill
        {
            get { return fBrut_Impo_Juill; }
            set { SetPropertyValue<decimal>("Brut_Impo_Juill", ref fBrut_Impo_Juill, value); }
        }

        private decimal fIRG_Juill;
        public decimal IRG_Juill
        {
            get { return fIRG_Juill; }
            set { SetPropertyValue<decimal>("IRG_Juill", ref fIRG_Juill, value); }
        }

        private decimal fNET_Juill;
        public decimal NET_Juill
        {
            get { return fNET_Juill; }
            set { SetPropertyValue<decimal>("NET_Juill", ref fNET_Juill, value); }
        }

        private int fEntree_Juill;
        public int Entree_Juill
        {
            get { return fEntree_Juill; }
            set { SetPropertyValue<int>("Entree_Juill", ref fEntree_Juill, value); }
        }

        private int fSortie_Juill;
        public int Sortie_Juill
        {
            get { return fSortie_Juill; }
            set { SetPropertyValue<int>("Sortie_Juill_Juill", ref fSortie_Juill, value); }
        }

        private double fTaux_pp1_Juill;
        public double Taux_pp1_Juill
        {
            get { return fTaux_pp1_Juill; }
            set { SetPropertyValue<double>("Taux_pp1_Juill", ref fTaux_pp1_Juill, value); }
        }

        private double fTaux_pp2_Juill;
        public double Taux_pp2_Juill
        {
            get { return fTaux_pp2_Juill; }
            set { SetPropertyValue<double>("Taux_pp2_Juill", ref fTaux_pp2_Juill, value); }
        }

        private double fTaux_pp3_Juill;
        public double Taux_pp3_Juill
        {
            get { return fTaux_pp3_Juill; }
            set { SetPropertyValue<double>("Taux_pp3_Juill", ref fTaux_pp3_Juill, value); }
        }

        private decimal fPP1_Juill;
        public decimal PP1_Juill
        {
            get { return fPP1_Juill; }
            set { SetPropertyValue<decimal>("PP1_Juill", ref fPP1_Juill, value); }
        }

        private decimal fPP2_Juill;
        public decimal PP2_Juill
        {
            get { return fPP2_Juill; }
            set { SetPropertyValue<decimal>("PP2_Juill", ref fPP2_Juill, value); }
        }

        private decimal fPP3_Juill;
        public decimal PP3_Juill
        {
            get { return fPP3_Juill; }
            set { SetPropertyValue<decimal>("PP3_Juill", ref fPP3_Juill, value); }
        }
         
        private int fEff_Juill;
        public int Eff_Juill
        {
            get { return fEff_Juill; }
            set { SetPropertyValue<int>("Eff_Juill", ref fEff_Juill, value); }
        }

        private int fNbr_jour_abs_Juill;
        public int Nbr_jour_abs_Juill
        {
            get
            {
                return fNbr_jour_abs_Juill;
            }
            set { SetPropertyValue<int>("Nbr_jour_abs_Juill", ref fNbr_jour_abs_Juill, value); }
        }

        private double fJour_Abs_Juill;
        public double Jour_Abs_Juill
        {
            get
            {
                return fJour_Abs_Juill;
            }
            set { SetPropertyValue<double>("Jour_Abs_Juill", ref fJour_Abs_Juill, value); }
        }

        private int fNbr_jour_ouv_Juill;
        public int Nbr_jour_ouv_Juill
        {
            get { return fNbr_jour_ouv_Juill; }
            set { SetPropertyValue<int>("Nbr_jour_ouv_Juill", ref fNbr_jour_ouv_Juill, value); }
        }

        private double fNbr_jour_cong_Juill;
        public double Nbr_jour_cong_Juill
        {
            get { return fNbr_jour_cong_Juill; }
            set { SetPropertyValue<double>("Nbr_jour_cong_Juill", ref fNbr_jour_cong_Juill, value); }
        }

        /***************************************** Aout *********************************************/
        [Association("Recape_Annuelle_Aout-Recapes_Aout", typeof(Recapes_Aout))]
        public XPCollection recapes_Aout
        {
            get { return GetCollection("recapes_Aout"); }
        }

        private decimal fBrut_Impo_Taux_Aout;
        public decimal Brut_Impo_Taux_Aout
        {
            get { return fBrut_Impo_Taux_Aout; }
            set { SetPropertyValue<decimal>("Brut_Impo_Taux_Aout", ref fBrut_Impo_Taux_Aout, value); }
        }

        private decimal fIRG_Taux_Aout;
        public decimal IRG_Taux_Aout
        {
            get { return fIRG_Taux_Aout; }
            set { SetPropertyValue<decimal>("IRG_Taux_Aout", ref fIRG_Taux_Aout, value); }
        }

        private decimal fBrut_Impo_Bareme_Aout;
        public decimal Brut_Impo_Bareme_Aout
        {
            get { return fBrut_Impo_Bareme_Aout; }
            set { SetPropertyValue<decimal>("Brut_Impo_Bareme_Aout", ref fBrut_Impo_Bareme_Aout, value); }
        }

        private decimal fIRG_Bareme_Aout;
        public decimal IRG_Bareme_Aout
        {
            get { return fIRG_Bareme_Aout; }
            set { SetPropertyValue<decimal>("IRG_Bareme_Aout", ref fIRG_Bareme_Aout, value); }
        }

        private decimal fBrut_Cotis_Aout;
        public decimal Brut_Cotis_Aout
        {
            get { return fBrut_Cotis_Aout; }
            set { SetPropertyValue<decimal>("Brut_Cotis_Aout", ref fBrut_Cotis_Aout, value); }
        }

        private decimal fSS_Aout;
        public decimal SS_Aout
        {
            get { return fSS_Aout; }
            set { SetPropertyValue<decimal>("SS_Aout", ref fSS_Aout, value); }
        }

        private decimal fBrut_Impo_Aout;
        public decimal Brut_Impo_Aout
        {
            get { return fBrut_Impo_Aout; }
            set { SetPropertyValue<decimal>("Brut_Impo_Aout", ref fBrut_Impo_Aout, value); }
        }

        private decimal fIRG_Aout;
        public decimal IRG_Aout
        {
            get { return fIRG_Aout; }
            set { SetPropertyValue<decimal>("IRG_Aout", ref fIRG_Aout, value); }
        }

        private decimal fNET_Aout;
        public decimal NET_Aout
        {
            get { return fNET_Aout; }
            set { SetPropertyValue<decimal>("NET_Aout", ref fNET_Aout, value); }
        }

        private int fEntree_Aout;
        public int Entree_Aout
        {
            get { return fEntree_Aout; }
            set { SetPropertyValue<int>("Entree_Aout", ref fEntree_Aout, value); }
        }

        private int fSortie_Aout;
        public int Sortie_Aout
        {
            get { return fSortie_Aout; }
            set { SetPropertyValue<int>("Sortie_Aout", ref fSortie_Aout, value); }
        }

        private double fTaux_pp1_Aout;
        public double Taux_pp1_Aout
        {
            get { return fTaux_pp1_Aout; }
            set { SetPropertyValue<double>("Taux_pp1_Aout", ref fTaux_pp1_Aout, value); }
        }

        private double fTaux_pp2_Aout;
        public double Taux_pp2_Aout
        {
            get { return fTaux_pp2_Aout; }
            set { SetPropertyValue<double>("Taux_pp2_Aout", ref fTaux_pp2_Aout, value); }
        }

        private double fTaux_pp3_Aout;
        public double Taux_pp3_Aout
        {
            get { return fTaux_pp3_Aout; }
            set { SetPropertyValue<double>("Taux_pp3_Aout", ref fTaux_pp3_Aout, value); }
        }

        private decimal fPP1_Aout;
        public decimal PP1_Aout
        {
            get { return fPP1_Aout; }
            set { SetPropertyValue<decimal>("PP1_Aout", ref fPP1_Aout, value); }
        }

        private decimal fPP2_Aout;
        public decimal PP2_Aout
        {
            get { return fPP2_Aout; }
            set { SetPropertyValue<decimal>("PP2_Aout", ref fPP2_Aout, value); }
        }

        private decimal fPP3_Aout;
        public decimal PP3_Aout
        {
            get { return fPP3_Aout; }
            set { SetPropertyValue<decimal>("PP3_Aout", ref fPP3_Aout, value); }
        }

        private int fEff_Aout;
        public int Eff_Aout
        {
            get { return fEff_Aout; }
            set { SetPropertyValue<int>("Eff_Aout", ref fEff_Aout, value); }
        }

        private int fNbr_jour_abs_Aout;
        public int Nbr_jour_abs_Aout
        {
            get
            {
                return fNbr_jour_abs_Aout;
            }
            set { SetPropertyValue<int>("Nbr_jour_abs_Aout", ref fNbr_jour_abs_Aout, value); }
        }

        private double fJour_Abs_Aout;
        public double Jour_Abs_Aout
        {
            get
            {
                return fJour_Abs_Aout;
            }
            set { SetPropertyValue<double>("Jour_Abs_Aout", ref fJour_Abs_Aout, value); }
        }

        private int fNbr_jour_ouv_Aout;
        public int Nbr_jour_ouv_Aout
        {
            get { return fNbr_jour_ouv_Aout; }
            set { SetPropertyValue<int>("Nbr_jour_ouv_Aout", ref fNbr_jour_ouv_Aout, value); }
        }

        private double fNbr_jour_cong_Aout;
        public double Nbr_jour_cong_Aout
        {
            get { return fNbr_jour_cong_Aout; }
            set { SetPropertyValue<double>("Nbr_jour_cong_Aout", ref fNbr_jour_cong_Aout, value); }
        }

        /***************************************** Septembre *********************************************/
        [Association("Recape_Annuelle_Sept-Recapes_Sept", typeof(Recapes_Sept))]
        public XPCollection recapes_Sept
        {
            get { return GetCollection("recapes_Sept"); }
        }

        private decimal fBrut_Impo_Taux_Sept;
        public decimal Brut_Impo_Taux_Sept
        {
            get { return fBrut_Impo_Taux_Sept; }
            set { SetPropertyValue<decimal>("Brut_Impo_Taux_Sept", ref fBrut_Impo_Taux_Sept, value); }
        }

        private decimal fIRG_Taux_Sept;
        public decimal IRG_Taux_Sept
        {
            get { return fIRG_Taux_Sept; }
            set { SetPropertyValue<decimal>("IRG_Taux_Sept", ref fIRG_Taux_Sept, value); }
        }

        private decimal fBrut_Impo_Bareme_Sept;
        public decimal Brut_Impo_Bareme_Sept
        {
            get { return fBrut_Impo_Bareme_Sept; }
            set { SetPropertyValue<decimal>("Brut_Impo_Bareme_Sept", ref fBrut_Impo_Bareme_Sept, value); }
        }

        private decimal fIRG_Bareme_Sept;
        public decimal IRG_Bareme_Sept
        {
            get { return fIRG_Bareme_Sept; }
            set { SetPropertyValue<decimal>("IRG_Bareme_Sept", ref fIRG_Bareme_Sept, value); }
        }

        private decimal fBrut_Cotis_Sept;
        public decimal Brut_Cotis_Sept
        {
            get { return fBrut_Cotis_Sept; }
            set { SetPropertyValue<decimal>("Brut_Cotis_Sept", ref fBrut_Cotis_Sept, value); }
        }

        private decimal fSS_Sept;
        public decimal SS_Sept
        {
            get { return fSS_Sept; }
            set { SetPropertyValue<decimal>("SS_Sept", ref fSS_Sept, value); }
        }

        private decimal fBrut_Impo_Sept;
        public decimal Brut_Impo_Sept
        {
            get { return fBrut_Impo_Sept; }
            set { SetPropertyValue<decimal>("Brut_Impo_Sept", ref fBrut_Impo_Sept, value); }
        }

        private decimal fIRG_Sept;
        public decimal IRG_Sept
        {
            get { return fIRG_Sept; }
            set { SetPropertyValue<decimal>("IRG_Sept", ref fIRG_Sept, value); }
        }

        private decimal fNET_Sept;
        public decimal NET_Sept
        {
            get { return fNET_Sept; }
            set { SetPropertyValue<decimal>("NET_Sept", ref fNET_Sept, value); }
        }

        private int fEntree_Sept;
        public int Entree_Sept
        {
            get { return fEntree_Sept; }
            set { SetPropertyValue<int>("Entree_Sept", ref fEntree_Sept, value); }
        }

        private int fSortie_Sept;
        public int Sortie_Sept
        {
            get { return fSortie_Sept; }
            set { SetPropertyValue<int>("Sortie_Sept", ref fSortie_Sept, value); }
        }

        private double fTaux_pp1_Sept;
        public double Taux_pp1_Sept
        {
            get { return fTaux_pp1_Sept; }
            set { SetPropertyValue<double>("Taux_pp1_Sept", ref fTaux_pp1_Sept, value); }
        }

        private double fTaux_pp2_Sept;
        public double Taux_pp2_Sept
        {
            get { return fTaux_pp2_Sept; }
            set { SetPropertyValue<double>("Taux_pp2_Sept", ref fTaux_pp2_Sept, value); }
        }

        private double fTaux_pp3_Sept;
        public double Taux_pp3_Sept
        {
            get { return fTaux_pp3_Sept; }
            set { SetPropertyValue<double>("Taux_pp3_Sept", ref fTaux_pp3_Sept, value); }
        }

        private decimal fPP1_Sept;
        public decimal PP1_Sept
        {
            get { return fPP1_Sept; }
            set { SetPropertyValue<decimal>("PP1_Sept", ref fPP1_Sept, value); }
        }

        private decimal fPP2_Sept;
        public decimal PP2_Sept
        {
            get { return fPP2_Sept; }
            set { SetPropertyValue<decimal>("PP2_Sept", ref fPP2_Sept, value); }
        }

        private decimal fPP3_Sept;
        public decimal PP3_Sept
        {
            get { return fPP3_Sept; }
            set { SetPropertyValue<decimal>("PP3_Sept", ref fPP3_Sept, value); }
        }

        private int fEff_Sept;
        public int Eff_Sept
        {
            get { return fEff_Sept; }
            set { SetPropertyValue<int>("Eff_Sept", ref fEff_Sept, value); }
        }

        private int fNbr_jour_abs_Sept;
        public int Nbr_jour_abs_Sept
        {
            get
            {
                return fNbr_jour_abs_Sept;
            }
            set { SetPropertyValue<int>("Nbr_jour_abs_Sept", ref fNbr_jour_abs_Sept, value); }
        }

        private double fJour_Abs_Sept;
        public double Jour_Abs_Sept
        {
            get
            {
                return fJour_Abs_Sept;
            }
            set { SetPropertyValue<double>("Jour_Abs_Sept", ref fJour_Abs_Sept, value); }
        }

        private int fNbr_jour_ouv_Sept;
        public int Nbr_jour_ouv_Sept
        {
            get { return fNbr_jour_ouv_Sept; }
            set { SetPropertyValue<int>("Nbr_jour_ouv_Sept", ref fNbr_jour_ouv_Sept, value); }
        }

        private double fNbr_jour_cong_Sept;
        public double Nbr_jour_cong_Sept
        {
            get { return fNbr_jour_cong_Sept; }
            set { SetPropertyValue<double>("Nbr_jour_cong_Sept", ref fNbr_jour_cong_Sept, value); }
        }

        /***************************************** Octobre *********************************************/
        [Association("Recape_Annuelle_Oct-Recapes_Oct", typeof(Recapes_Oct))]
        public XPCollection recapes_Oct
        {
            get { return GetCollection("recapes_Oct"); }
        }

        private decimal fBrut_Impo_Taux_Oct;
        public decimal Brut_Impo_Taux_Oct
        {
            get { return fBrut_Impo_Taux_Oct; }
            set { SetPropertyValue<decimal>("Brut_Impo_Taux_Oct", ref fBrut_Impo_Taux_Oct, value); }
        }

        private decimal fIRG_Taux_Oct;
        public decimal IRG_Taux_Oct
        {
            get { return fIRG_Taux_Oct; }
            set { SetPropertyValue<decimal>("IRG_Taux_Oct", ref fIRG_Taux_Oct, value); }
        }

        private decimal fBrut_Impo_Bareme_Oct;
        public decimal Brut_Impo_Bareme_Oct
        {
            get { return fBrut_Impo_Bareme_Oct; }
            set { SetPropertyValue<decimal>("Brut_Impo_Bareme_Oct", ref fBrut_Impo_Bareme_Oct, value); }
        }

        private decimal fIRG_Bareme_Oct;
        public decimal IRG_Bareme_Oct
        {
            get { return fIRG_Bareme_Oct; }
            set { SetPropertyValue<decimal>("IRG_Bareme_Oct", ref fIRG_Bareme_Oct, value); }
        }

        private decimal fBrut_Cotis_Oct;
        public decimal Brut_Cotis_Oct
        {
            get { return fBrut_Cotis_Oct; }
            set { SetPropertyValue<decimal>("Brut_Cotis_Oct", ref fBrut_Cotis_Oct, value); }
        }

        private decimal fSS_Oct;
        public decimal SS_Oct
        {
            get { return fSS_Oct; }
            set { SetPropertyValue<decimal>("SS_Oct", ref fSS_Oct, value); }
        }

        private decimal fBrut_Impo_Oct;
        public decimal Brut_Impo_Oct
        {
            get { return fBrut_Impo_Oct; }
            set { SetPropertyValue<decimal>("Brut_Impo_Oct", ref fBrut_Impo_Oct, value); }
        }

        private decimal fIRG_Oct;
        public decimal IRG_Oct
        {
            get { return fIRG_Oct; }
            set { SetPropertyValue<decimal>("IRG_Oct", ref fIRG_Oct, value); }
        }

        private decimal fNET_Oct;
        public decimal NET_Oct
        {
            get { return fNET_Oct; }
            set { SetPropertyValue<decimal>("NET_Oct", ref fNET_Oct, value); }
        }

        private int fEntree_Oct;
        public int Entree_Oct
        {
            get { return fEntree_Oct; }
            set { SetPropertyValue<int>("Entree_Oct", ref fEntree_Oct, value); }
        }

        private int fSortie_Oct;
        public int Sortie_Oct
        {
            get { return fSortie_Oct; }
            set { SetPropertyValue<int>("Sortie_Oct", ref fSortie_Oct, value); }
        }

        private double fTaux_pp1_Oct;
        public double Taux_pp1_Oct
        {
            get { return fTaux_pp1_Oct; }
            set { SetPropertyValue<double>("Taux_pp1_Oct", ref fTaux_pp1_Oct, value); }
        }

        private double fTaux_pp2_Oct;
        public double Taux_pp2_Oct
        {
            get { return fTaux_pp2_Oct; }
            set { SetPropertyValue<double>("Taux_pp2_Oct", ref fTaux_pp2_Oct, value); }
        }

        private double fTaux_pp3_Oct;
        public double Taux_pp3_Oct
        {
            get { return fTaux_pp3_Oct; }
            set { SetPropertyValue<double>("Taux_pp3_Oct", ref fTaux_pp3_Oct, value); }
        }

        private decimal fPP1_Oct;
        public decimal PP1_Oct
        {
            get { return fPP1_Oct; }
            set { SetPropertyValue<decimal>("PP1_Oct", ref fPP1_Oct, value); }
        }

        private decimal fPP2_Oct;
        public decimal PP2_Oct
        {
            get { return fPP2_Oct; }
            set { SetPropertyValue<decimal>("PP2_Oct", ref fPP2_Oct, value); }
        }

        private decimal fPP3_Oct;
        public decimal PP3_Oct
        {
            get { return fPP3_Oct; }
            set { SetPropertyValue<decimal>("PP3_Oct", ref fPP3_Oct, value); }
        }

        private int fEff_Oct;
        public int Eff_Oct
        {
            get { return fEff_Oct; }
            set { SetPropertyValue<int>("Eff_Oct", ref fEff_Oct, value); }
        }

        private int fNbr_jour_abs_Oct;
        public int Nbr_jour_abs_Oct
        {
            get
            {
                return fNbr_jour_abs_Oct;
            }
            set { SetPropertyValue<int>("Nbr_jour_abs_Oct", ref fNbr_jour_abs_Oct, value); }
        }

        private double fJour_Abs_Oct;
        public double Jour_Abs_Oct
        {
            get
            {
                return fJour_Abs_Oct;
            }
            set { SetPropertyValue<double>("Jour_Abs_Oct", ref fJour_Abs_Oct, value); }
        }

        private int fNbr_jour_ouv_Oct;
        public int Nbr_jour_ouv_Oct
        {
            get { return fNbr_jour_ouv_Oct; }
            set { SetPropertyValue<int>("Nbr_jour_ouv_Oct", ref fNbr_jour_ouv_Oct, value); }
        }

        private double fNbr_jour_cong_Oct;
        public double Nbr_jour_cong_Oct
        {
            get { return fNbr_jour_cong_Oct; }
            set { SetPropertyValue<double>("Nbr_jour_cong_Oct", ref fNbr_jour_cong_Oct, value); }
        }

        /***************************************** Nouvembre *********************************************/
        [Association("Recape_Annuelle_Nouv-Recapes_Nouv", typeof(Recapes_Nouv))]
        public XPCollection recapes_Nouv
        {
            get { return GetCollection("recapes_Nouv"); }
        }

        private decimal fBrut_Impo_Taux_Nouv;
        public decimal Brut_Impo_Taux_Nouv
        {
            get { return fBrut_Impo_Taux_Nouv; }
            set { SetPropertyValue<decimal>("Brut_Impo_Taux_Nouv", ref fBrut_Impo_Taux_Nouv, value); }
        }

        private decimal fIRG_Taux_Nouv;
        public decimal IRG_Taux_Nouv
        {
            get { return fIRG_Taux_Nouv; }
            set { SetPropertyValue<decimal>("IRG_Taux_Nouv", ref fIRG_Taux_Nouv, value); }
        }

        private decimal fBrut_Impo_Bareme_Nouv;
        public decimal Brut_Impo_Bareme_Nouv
        {
            get { return fBrut_Impo_Bareme_Nouv; }
            set { SetPropertyValue<decimal>("Brut_Impo_Bareme_Nouv", ref fBrut_Impo_Bareme_Nouv, value); }
        }

        private decimal fIRG_Bareme_Nouv;
        public decimal IRG_Bareme_Nouv
        {
            get { return fIRG_Bareme_Nouv; }
            set { SetPropertyValue<decimal>("IRG_Bareme_Nouv", ref fIRG_Bareme_Nouv, value); }
        }

        private decimal fBrut_Cotis_Nouv;
        public decimal Brut_Cotis_Nouv
        {
            get { return fBrut_Cotis_Nouv; }
            set { SetPropertyValue<decimal>("Brut_Cotis_Nouv", ref fBrut_Cotis_Nouv, value); }
        }

        private decimal fSS_Nouv;
        public decimal SS_Nouv
        {
            get { return fSS_Nouv; }
            set { SetPropertyValue<decimal>("SS_Nouv", ref fSS_Nouv, value); }
        }

        private decimal fBrut_Impo_Nouv;
        public decimal Brut_Impo_Nouv
        {
            get { return fBrut_Impo_Nouv; }
            set { SetPropertyValue<decimal>("Brut_Impo_Nouv", ref fBrut_Impo_Nouv, value); }
        }

        private decimal fIRG_Nouv;
        public decimal IRG_Nouv
        {
            get { return fIRG_Nouv; }
            set { SetPropertyValue<decimal>("IRG_Nouv", ref fIRG_Nouv, value); }
        }

        private decimal fNET_Nouv;
        public decimal NET_Nouv
        {
            get { return fNET_Nouv; }
            set { SetPropertyValue<decimal>("NET_Nouv", ref fNET_Nouv, value); }
        }

        private int fEntree_Nouv;
        public int Entree_Nouv
        {
            get { return fEntree_Nouv; }
            set { SetPropertyValue<int>("Entree_Nouv", ref fEntree_Nouv, value); }
        }

        private int fSortie_Nouv;
        public int Sortie_Nouv
        {
            get { return fSortie_Nouv; }
            set { SetPropertyValue<int>("Sortie_Nouv", ref fSortie_Nouv, value); }
        }

        private double fTaux_pp1_Nouv;
        public double Taux_pp1_Nouv
        {
            get { return fTaux_pp1_Nouv; }
            set { SetPropertyValue<double>("Taux_pp1_Nouv", ref fTaux_pp1_Nouv, value); }
        }

        private double fTaux_pp2_Nouv;
        public double Taux_pp2_Nouv
        {
            get { return fTaux_pp2_Nouv; }
            set { SetPropertyValue<double>("Taux_pp2_Nouv", ref fTaux_pp2_Nouv, value); }
        }

        private double fTaux_pp3_Nouv;
        public double Taux_pp3_Nouv
        {
            get { return fTaux_pp3_Nouv; }
            set { SetPropertyValue<double>("Taux_pp3_Nouv", ref fTaux_pp3_Nouv, value); }
        }

        private decimal fPP1_Nouv;
        public decimal PP1_Nouv
        {
            get { return fPP1_Nouv; }
            set { SetPropertyValue<decimal>("PP1_Nouv", ref fPP1_Nouv, value); }
        }

        private decimal fPP2_Nouv;
        public decimal PP2_Nouv
        {
            get { return fPP2_Nouv; }
            set { SetPropertyValue<decimal>("PP2_Nouv", ref fPP2_Nouv, value); }
        }

        private decimal fPP3_Nouv;
        public decimal PP3_Nouv
        {
            get { return fPP3_Nouv; }
            set { SetPropertyValue<decimal>("PP3_Nouv", ref fPP3_Nouv, value); }
        }

        private int fEff_Nouv;
        public int Eff_Nouv
        {
            get { return fEff_Nouv; }
            set { SetPropertyValue<int>("Eff_Nouv", ref fEff_Nouv, value); }
        }

        private int fNbr_jour_abs_Nouv;
        public int Nbr_jour_abs_Nouv
        {
            get
            {
                return fNbr_jour_abs_Nouv;
            }
            set { SetPropertyValue<int>("Nbr_jour_abs_Nouv", ref fNbr_jour_abs_Nouv, value); }
        }

        private double fJour_Abs_Nouv;
        public double Jour_Abs_Nouv
        {
            get
            {
                return fJour_Abs_Nouv;
            }
            set { SetPropertyValue<double>("Jour_Abs_Nouv", ref fJour_Abs_Nouv, value); }
        }

        private int fNbr_jour_ouv_Nouv;
        public int Nbr_jour_ouv_Nouv
        {
            get { return fNbr_jour_ouv_Nouv; }
            set { SetPropertyValue<int>("Nbr_jour_ouv_Nouv", ref fNbr_jour_ouv_Nouv, value); }
        }

        private double fNbr_jour_cong_Nouv;
        public double Nbr_jour_cong_Nouv
        {
            get { return fNbr_jour_cong_Nouv; }
            set { SetPropertyValue<double>("Nbr_jour_cong_Nouv", ref fNbr_jour_cong_Nouv, value); }
        }

        /***************************************** Décembre *********************************************/
        [Association("Recape_Annuelle_Dec-Recapes_Dec", typeof(Recapes_Dec))]
        public XPCollection recapes_Dec
        {
            get { return GetCollection("recapes_Dec"); }
        }

        private decimal fBrut_Impo_Taux_Dec;
        public decimal Brut_Impo_Taux_Dec
        {
            get { return fBrut_Impo_Taux_Dec; }
            set { SetPropertyValue<decimal>("Brut_Impo_Taux_Dec", ref fBrut_Impo_Taux_Dec, value); }
        }

        private decimal fIRG_Taux_Dec;
        public decimal IRG_Taux_Dec
        {
            get { return fIRG_Taux_Dec; }
            set { SetPropertyValue<decimal>("IRG_Taux_Dec", ref fIRG_Taux_Dec, value); }
        }

        private decimal fBrut_Impo_Bareme_Dec;
        public decimal Brut_Impo_Bareme_Dec
        {
            get { return fBrut_Impo_Bareme_Dec; }
            set { SetPropertyValue<decimal>("Brut_Impo_Bareme_Dec", ref fBrut_Impo_Bareme_Dec, value); }
        }

        private decimal fIRG_Bareme_Dec;
        public decimal IRG_Bareme_Dec
        {
            get { return fIRG_Bareme_Dec; }
            set { SetPropertyValue<decimal>("IRG_Bareme_Dec", ref fIRG_Bareme_Dec, value); }
        }

        private decimal fBrut_Cotis_Dec;
        public decimal Brut_Cotis_Dec
        {
            get { return fBrut_Cotis_Dec; }
            set { SetPropertyValue<decimal>("Brut_Cotis_Dec", ref fBrut_Cotis_Dec, value); }
        }

        private decimal fSS_Dec;
        public decimal SS_Dec
        {
            get { return fSS_Dec; }
            set { SetPropertyValue<decimal>("SS_Dec", ref fSS_Dec, value); }
        }

        private decimal fBrut_Impo_Dec;
        public decimal Brut_Impo_Dec
        {
            get { return fBrut_Impo_Dec; }
            set { SetPropertyValue<decimal>("Brut_Impo_Dec", ref fBrut_Impo_Dec, value); }
        }

        private decimal fIRG_Dec;
        public decimal IRG_Dec
        {
            get { return fIRG_Dec; }
            set { SetPropertyValue<decimal>("IRG_Dec", ref fIRG_Dec, value); }
        }

        private decimal fNET_Dec;
        public decimal NET_Dec
        {
            get { return fNET_Dec; }
            set { SetPropertyValue<decimal>("NET_Dec", ref fNET_Dec, value); }
        }

        private int fEntree_Dec;
        public int Entree_Dec
        {
            get { return fEntree_Dec; }
            set { SetPropertyValue<int>("Entree_Dec", ref fEntree_Dec, value); }
        }

        private int fSortie_Dec;
        public int Sortie_Dec
        {
            get { return fSortie_Dec; }
            set { SetPropertyValue<int>("Sortie_Dec", ref fSortie_Dec, value); }
        }
         
        private double fTaux_pp1_Dec;
        public double Taux_pp1_Dec
        {
            get { return fTaux_pp1_Dec; }
            set { SetPropertyValue<double>("Taux_pp1_Dec", ref fTaux_pp1_Dec, value); }
        }

        private double fTaux_pp2_Dec;
        public double Taux_pp2_Dec
        {
            get { return fTaux_pp2_Dec; }
            set { SetPropertyValue<double>("Taux_pp2_Dec", ref fTaux_pp2_Dec, value); }
        }

        private double fTaux_pp3_Dec;
        public double Taux_pp3_Dec
        {
            get { return fTaux_pp3_Dec; }
            set { SetPropertyValue<double>("Taux_pp3_Dec", ref fTaux_pp3_Dec, value); }
        }

        private decimal fPP1_Dec;
        public decimal PP1_Dec
        {
            get { return fPP1_Dec; }
            set { SetPropertyValue<decimal>("PP1_Dec", ref fPP1_Dec, value); }
        }

        private decimal fPP2_Dec;
        public decimal PP2_Dec
        {
            get { return fPP2_Dec; }
            set { SetPropertyValue<decimal>("PP2_Dec", ref fPP2_Dec, value); }
        }

        private decimal fPP3_Dec;
        public decimal PP3_Dec
        {
            get { return fPP3_Dec; }
            set { SetPropertyValue<decimal>("PP3_Dec", ref fPP3_Dec, value); }
        }

        private int fEff_Dec;
        public int Eff_Dec
        {
            get { return fEff_Dec; }
            set { SetPropertyValue<int>("Eff_Dec", ref fEff_Dec, value); }
        }

        private int fNbr_jour_abs_Dec;
        public int Nbr_jour_abs_Dec
        {
            get
            {
                return fNbr_jour_abs_Dec;
            }
            set { SetPropertyValue<int>("Nbr_jour_abs_Dec", ref fNbr_jour_abs_Dec, value); }
        }

        private double fJour_Abs_Dec;
        public double Jour_Abs_Dec
        {
            get
            {
                return fJour_Abs_Dec;
            }
            set { SetPropertyValue<double>("Jour_Abs_Dec", ref fJour_Abs_Dec, value); }
        }

        private int fNbr_jour_ouv_Dec;
        public int Nbr_jour_ouv_Dec
        {
            get { return fNbr_jour_ouv_Dec; }
            set { SetPropertyValue<int>("Nbr_jour_ouv_Dec", ref fNbr_jour_ouv_Dec, value); }
        }

        private double fNbr_jour_cong_Dec;
        public double Nbr_jour_cong_Dec
        {
            get { return fNbr_jour_cong_Dec; }
            set { SetPropertyValue<double>("Nbr_jour_cong_Dec", ref fNbr_jour_cong_Dec, value); }
        }

        /***************************************** Total *********************************************/

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

        /***************************************************************************************************/

        private parametre fparametres;
        public parametre parametres
        {
            get { return fparametres; }
            set { SetPropertyValue<parametre>("parametres", ref fparametres, value); }
        }


        public Recape_Annuelle(Session session)
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


            /************************************************************/

            parametres = parametre.GetInstance(Session);
            //parametres = Parametres;


        }

        Arrondi_Decimal ArrondiDecimale = new Arrondi_Decimal();
        ModeArrondi Mode_Arrondi = ModeArrondi.Arrondi_Chiffre_supperieur;

        public int Recape_paye(Paye paye, CategorieCloture type, int mois, int yes)
        {
            personne = paye.personne;
            Cod_Recape = paye.personne.Cod_personne + paye.Annee.ToString();
            Annee = paye.Annee;
            Unite = paye.Unite;
            if (Unite != null)
                NumEmployeur = Unite.NumEmployeur;

            MoisdelAnnee Mois = (MoisdelAnnee)mois;

            if ((personne.Dat_sortie.Month != mois) || (personne.Dat_sortie == DateTime.MinValue))
            {
                if ((personne.DateRecrutement != DateTime.MinValue) && (personne.Dat_entre.Year == DateTime.Now.Year) && (personne.Dat_entre.Day <= parametres.Jr_Debut_Mois) && (personne.Dat_entre.Month == mois))
                    switch (personne.DateRecrutement.Month)
                    {
                        case 1:
                            {
                                Entree_Janv = 1;
                                Sortie_Janv = 0;
                            }
                            break;
                        case 2:
                            {
                                Entree_Fev = 1;
                                Sortie_Fev = 0;
                            }
                            break;
                        case 3:
                            {
                                Entree_Mars = 1;
                                Sortie_Mars = 0;
                            }
                            break;
                        case 4:
                            {
                                Entree_Avr = 1;
                                Sortie_Avr = 0;
                            }
                            break;
                        case 5:
                            {
                                Entree_Mai = 1;
                                Sortie_Mai = 0;
                            }
                            break;
                        case 6:
                            {
                                Entree_Juin = 1;
                                Sortie_Juin = 0;
                            }
                            break;
                        case 7:
                            {
                                Entree_Juill = 1;
                                Sortie_Juill = 0;
                            }
                            break;
                        case 8:
                            {
                                Entree_Aout = 1;
                                Sortie_Aout = 0;
                            }
                            break;
                        case 9:
                            {
                                Entree_Sept = 1;
                                Sortie_Sept = 0;
                            }
                            break;
                        case 10:
                            {
                                Entree_Oct = 1;
                                Sortie_Oct = 0;
                            }
                            break;
                        case 11:
                            {
                                Entree_Nouv = 1;
                                Sortie_Nouv = 0;
                            }
                            break;
                        case 12:
                            {
                                Entree_Dec = 1;
                                Sortie_Dec = 0;
                            }
                            break;
                    }
            }
            else
                if ((personne.Dat_sortie.Year == DateTime.Now.Year) && (personne.Dat_sortie.Day <= parametres.Jr_Debut_Mois))
                {
                    switch (personne.Dat_sortie.Month)
                    {
                        case 1:
                            {
                                Entree_Janv = 0;
                                Sortie_Janv = 1;
                            }
                            break;
                        case 2:
                            {
                                Entree_Fev = 0;
                                Sortie_Fev = 1;
                            }
                            break;
                        case 3:
                            {
                                Entree_Mars = 0;
                                Sortie_Mars = 1;
                            }
                            break;
                        case 4:
                            {
                                Entree_Avr = 0;
                                Sortie_Avr = 1;
                            }
                            break;
                        case 5:
                            {
                                Entree_Mai = 0;
                                Sortie_Mai = 1;
                            }
                            break;
                        case 6:
                            {
                                Entree_Juin = 0;
                                Sortie_Juin = 1;
                            }
                            break;
                        case 7:
                            {
                                Entree_Juill = 0;
                                Sortie_Juill = 1;
                            }
                            break;
                        case 8:
                            {
                                Entree_Aout = 0;
                                Sortie_Aout = 1;
                            }
                            break;
                        case 9:
                            {
                                Entree_Sept = 0;
                                Sortie_Sept = 1;
                            }
                            break;
                        case 10:
                            {
                                Entree_Oct = 0;
                                Sortie_Oct = 1;
                            }
                            break;
                        case 11:
                            {
                                Entree_Nouv = 0;
                                Sortie_Nouv = 1;
                            }
                            break;
                        case 12:
                            {
                                Entree_Dec = 0;
                                Sortie_Dec = 1;
                            }
                            break;
                    }
                }


            switch (Mois)
            {
                case MoisdelAnnee.Janvier:
                    {
                        yes = Recape_Janvier(paye, type, yes);
                    }
                    break;
                case MoisdelAnnee.Février:
                    {
                        yes = Recape_Fevrier(paye, type, yes);
                    }
                    break;
                case MoisdelAnnee.Mars:
                    {
                        yes = Recape_Mars(paye, type, yes);
                    }
                    break;
                case MoisdelAnnee.Avril:
                    {
                        yes = Recape_Avril(paye, type, yes);
                    }
                    break;
                case MoisdelAnnee.Mai:
                    {
                        yes = Recape_Mai(paye, type, yes);
                    }
                    break;
                case MoisdelAnnee.Juin:
                    {
                        yes = Recape_Juin(paye, type, yes);
                    }
                    break;
                case MoisdelAnnee.Juillet:
                    {
                        yes = Recape_Juillet(paye, type, yes);
                    }
                    break;
                case MoisdelAnnee.Août:
                    {
                        yes = Recape_Aout(paye, type, yes);
                    }
                    break;
                case MoisdelAnnee.Septembre:
                    {
                        yes = Recape_Septembre(paye, type, yes);
                    }
                    break;
                case MoisdelAnnee.Octobre:
                    {
                        yes = Recape_Octobre(paye, type, yes);
                    }
                    break;
                case MoisdelAnnee.Novembre:
                    {
                        yes = Recape_Nouvembre(paye, type, yes);
                    }
                    break;
                case MoisdelAnnee.Décembre:
                    {
                        yes = Recape_Decembre(paye, type, yes);
                    }
                    break;
            }
            return yes;
        }

        public int Recape_Janvier<T>(T paye_rappel, CategorieCloture type, int yes)
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Janvier);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Categorie==?", type);
            CriteriaOperator criteria3 = CriteriaOperator.Parse("Recape_Annuelle_Janv==?", Oid);

            Recapes_Janv recapes = Session.FindObject<Recapes_Janv>(CriteriaOperator.And(criteria1, criteria2, criteria3));

            if (type == CategorieCloture.Paye)
            {
                object paye = Convert.ChangeType(paye_rappel, typeof(Paye));

                if (recapes != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("La paye du mois de Janvier de l'employé " + ((Paye)paye).personne.Cod_personne + "/" + ((Paye)paye).personne.FullName + " est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                }
                else
                {
                    if (recapes != null && yes == 1)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                    else
                    {
                        Recapes_Janv Recapes_Janv = new Recapes_Janv(Session);

                        Recapes_Janv.Brut_Impo_Bareme = ((Paye)paye).Imposable_bareme_Abs;
                        Recapes_Janv.IRG_Bareme = ((Paye)paye).Irg_bareme_Abs;
                        Recapes_Janv.Brut_Impo_Taux = ((Paye)paye).Imposable_taux_Abs;
                        Recapes_Janv.IRG_Taux = ((Paye)paye).Irg_taux_Abs;
                        Recapes_Janv.Brut_Cotis = ((Paye)paye).Brute_cotisableAbsence;
                        Recapes_Janv.SS = ((Paye)paye).SSAbsence;
                        Recapes_Janv.Brut_Impo = ((Paye)paye).Brute_imposable_Abs;
                        Recapes_Janv.IRG = ((Paye)paye).IRGAbsence;
                        Recapes_Janv.NET = ((Paye)paye).NETAbsence;
                        Recapes_Janv.PP1 = ((Paye)paye).PP1;
                        Recapes_Janv.PP2 = ((Paye)paye).PP2;
                        Recapes_Janv.PP3 = ((Paye)paye).PP3;
                        Recapes_Janv.Taux_pp1 = ((Paye)paye).Taux_pp1;
                        Recapes_Janv.Taux_pp2 = ((Paye)paye).Taux_pp2;
                        Recapes_Janv.Taux_pp3 = ((Paye)paye).Taux_pp3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            Recapes_Janv.Nbr_jour_abs = ((Paye)paye).Nbr_jour_abs;
                            Recapes_Janv.Jour_Abs = ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        Recapes_Janv.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;


                        Recapes_Janv.Recape_Annuelle_Janv = this;
                        Recapes_Janv.Categorie = type;
                        Recapes_Janv.Mois = MoisdelAnnee.Janvier;

                        recapes_Janv.Add(Recapes_Janv);
                    }
                } 
            }
            else
            {
                object rappel = Convert.ChangeType(paye_rappel, typeof(Rappel));

                if (recapes != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("Le rappel du mois est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                        recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                        recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                        recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                        recapes.SS += ((Rappel)rappel).SS_Mois;
                        recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                        recapes.IRG += ((Rappel)rappel).IRG_Mois;
                        recapes.NET += ((Rappel)rappel).NET_Mois;
                    }
                }
                else
                {
                    {
                        if (recapes != null && yes == 1)
                        {
                            recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                            recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                            recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                            recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                            recapes.SS += ((Rappel)rappel).SS_Mois;
                            recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                            recapes.IRG += ((Rappel)rappel).IRG_Mois;
                            recapes.NET += ((Rappel)rappel).NET_Mois;
                        }
                        else
                        {
                            Recapes_Janv Recapes_Janv = new Recapes_Janv(Session);

                            Recapes_Janv.Brut_Impo_Bareme = ((Rappel)rappel).Imposable_bareme_Mois;
                            Recapes_Janv.IRG_Bareme = ((Rappel)rappel).Irg_bareme_Mois;
                            Recapes_Janv.Brut_Impo_Taux = ((Rappel)rappel).Imposable_taux_Mois;
                            Recapes_Janv.Brut_Cotis = ((Rappel)rappel).Brute_cotisable_Mois;
                            Recapes_Janv.SS = ((Rappel)rappel).SS_Mois;
                            Recapes_Janv.Brut_Impo = ((Rappel)rappel).Brute_imposable_Mois;
                            Recapes_Janv.IRG = ((Rappel)rappel).IRG_Mois;
                            Recapes_Janv.NET = ((Rappel)rappel).NET_Mois;
                            Recapes_Janv.Recape_Annuelle_Janv = this;
                            Recapes_Janv.Categorie = type;
                            Recapes_Janv.Mois = MoisdelAnnee.Janvier;

                            recapes_Janv.Add(Recapes_Janv);
                        }
                    }
                }
            }
            Session.CommitTransaction();
            return yes;
        }

        public int Recape_Fevrier<T>(T paye_rappel, CategorieCloture type, int yes)
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Février);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Categorie==?", type);
            CriteriaOperator criteria3 = CriteriaOperator.Parse("Recape_Annuelle_Fev==?", Oid);

            Recapes_Fev recapes = Session.FindObject<Recapes_Fev>(CriteriaOperator.And(criteria1, criteria2, criteria3));

            if (type == CategorieCloture.Paye)
            {
                object paye = Convert.ChangeType(paye_rappel, typeof(Paye));

                if (recapes != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("La paye du mois de Février de l'employé " + ((Paye)paye).personne.Cod_personne + "/" + ((Paye)paye).personne.FullName + " est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                }
                else
                {
                    if (recapes != null && yes == 1)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                    else
                    {
                        Recapes_Fev Recapes_Fev = new Recapes_Fev(Session);

                        Recapes_Fev.Brut_Impo_Bareme = ((Paye)paye).Imposable_bareme_Abs;
                        Recapes_Fev.IRG_Bareme = ((Paye)paye).Irg_bareme_Abs;
                        Recapes_Fev.Brut_Impo_Taux = ((Paye)paye).Imposable_taux_Abs;
                        Recapes_Fev.IRG_Taux = ((Paye)paye).Irg_taux_Abs;
                        Recapes_Fev.Brut_Cotis = ((Paye)paye).Brute_cotisableAbsence;
                        Recapes_Fev.SS = ((Paye)paye).SSAbsence;
                        Recapes_Fev.Brut_Impo = ((Paye)paye).Brute_imposable_Abs;
                        Recapes_Fev.IRG = ((Paye)paye).IRGAbsence;
                        Recapes_Fev.NET = ((Paye)paye).NETAbsence;
                        Recapes_Fev.PP1 = ((Paye)paye).PP1;
                        Recapes_Fev.PP2 = ((Paye)paye).PP2;
                        Recapes_Fev.PP3 = ((Paye)paye).PP3;
                        Recapes_Fev.Taux_pp1 = ((Paye)paye).Taux_pp1;
                        Recapes_Fev.Taux_pp2 = ((Paye)paye).Taux_pp2;
                        Recapes_Fev.Taux_pp3 = ((Paye)paye).Taux_pp3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            Recapes_Fev.Nbr_jour_abs = ((Paye)paye).Nbr_jour_abs;
                            Recapes_Fev.Jour_Abs = ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        Recapes_Fev.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                        Recapes_Fev.Recape_Annuelle_Fev = this;
                        Recapes_Fev.Categorie = type;
                        Recapes_Fev.Mois = MoisdelAnnee.Février;

                        recapes_Fev.Add(Recapes_Fev);
                    }
                }
            }
            else
            {
                object rappel = Convert.ChangeType(paye_rappel, typeof(Rappel));

                if (recapes != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("La rappel du mois de Février est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                        recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                        recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                        recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                        recapes.SS += ((Rappel)rappel).SS_Mois;
                        recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                        recapes.IRG += ((Rappel)rappel).IRG_Mois;
                        recapes.NET += ((Rappel)rappel).NET_Mois;
                    }
                }
                else
                {
                    if (recapes != null && yes == 1)
                    {
                        recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                        recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                        recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                        recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                        recapes.SS += ((Rappel)rappel).SS_Mois;
                        recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                        recapes.IRG += ((Rappel)rappel).IRG_Mois;
                        recapes.NET += ((Rappel)rappel).NET_Mois;
                    }
                    else
                    {
                        Recapes_Fev Recapes_Fev = new Recapes_Fev(Session);

                        Recapes_Fev.Brut_Impo_Bareme = ((Rappel)rappel).Imposable_bareme_Mois;
                        Recapes_Fev.IRG_Bareme = ((Rappel)rappel).Irg_bareme_Mois;
                        Recapes_Fev.Brut_Impo_Taux = ((Rappel)rappel).Imposable_taux_Mois;
                        Recapes_Fev.Brut_Cotis = ((Rappel)rappel).Brute_cotisable_Mois;
                        Recapes_Fev.SS = ((Rappel)rappel).SS_Mois;
                        Recapes_Fev.Brut_Impo = ((Rappel)rappel).Brute_imposable_Mois;
                        Recapes_Fev.IRG = ((Rappel)rappel).IRG_Mois;
                        Recapes_Fev.NET = ((Rappel)rappel).NET_Mois;
                        Recapes_Fev.Recape_Annuelle_Fev = this;
                        Recapes_Fev.Categorie = type;
                        Recapes_Fev.Mois = MoisdelAnnee.Février;

                        recapes_Fev.Add(Recapes_Fev);
                    }
                }
            }
            Session.CommitTransaction();
            return yes;
        }

        public int Recape_Mars<T>(T paye_rappel, CategorieCloture type, int yes)
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Mars);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Categorie==?", type);
            CriteriaOperator criteria3 = CriteriaOperator.Parse("Recape_Annuelle_Mars==?", Oid);

            Recapes_Mars recapes = Session.FindObject<Recapes_Mars>(CriteriaOperator.And(criteria1, criteria2, criteria3));

            if (type == CategorieCloture.Paye)
            {
                object paye = Convert.ChangeType(paye_rappel, typeof(Paye));

                if (recapes != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("La paye du mois de Mars de l'employé " + ((Paye)paye).personne.Cod_personne + "/" + ((Paye)paye).personne.FullName + " est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                }
                else
                {
                    if (recapes != null && yes == 1)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                    else
                    {
                        Recapes_Mars Recapes_Mars = new Recapes_Mars(Session);

                        Recapes_Mars.Brut_Impo_Bareme = ((Paye)paye).Imposable_bareme_Abs;
                        Recapes_Mars.IRG_Bareme = ((Paye)paye).Irg_bareme_Abs;
                        Recapes_Mars.Brut_Impo_Taux = ((Paye)paye).Imposable_taux_Abs;
                        Recapes_Mars.IRG_Taux = ((Paye)paye).Irg_taux_Abs;
                        Recapes_Mars.Brut_Cotis = ((Paye)paye).Brute_cotisableAbsence;
                        Recapes_Mars.SS = ((Paye)paye).SSAbsence;
                        Recapes_Mars.Brut_Impo = ((Paye)paye).Brute_imposable_Abs;
                        Recapes_Mars.IRG = ((Paye)paye).IRGAbsence;
                        Recapes_Mars.NET = ((Paye)paye).NETAbsence;
                        Recapes_Mars.PP1 = ((Paye)paye).PP1;
                        Recapes_Mars.PP2 = ((Paye)paye).PP2;
                        Recapes_Mars.PP3 = ((Paye)paye).PP3;
                        Recapes_Mars.Taux_pp1 = ((Paye)paye).Taux_pp1;
                        Recapes_Mars.Taux_pp2 = ((Paye)paye).Taux_pp2;
                        Recapes_Mars.Taux_pp3 = ((Paye)paye).Taux_pp3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            Recapes_Mars.Nbr_jour_abs = ((Paye)paye).Nbr_jour_abs;
                            Recapes_Mars.Jour_Abs = ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        Recapes_Mars.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                        Recapes_Mars.Recape_Annuelle_Mars = this;
                        Recapes_Mars.Categorie = type;
                        Recapes_Mars.Mois = MoisdelAnnee.Mars;

                        recapes_Mars.Add(Recapes_Mars);
                    }
                }
            }
            else
                if (type == CategorieCloture.Rappel)
                {
                    object rappel = Convert.ChangeType(paye_rappel, typeof(Rappel));

                    if (recapes != null && yes == 0)
                    {
                        DialogResult result = MessageBox.Show("Le rappel du mois de Mars est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result2 == DialogResult.Yes)
                            yes = 1;

                        if (result == DialogResult.Yes)
                        {
                            recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                            recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                            recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                            recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                            recapes.SS += ((Rappel)rappel).SS_Mois;
                            recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                            recapes.IRG += ((Rappel)rappel).IRG_Mois;
                            recapes.NET += ((Rappel)rappel).NET_Mois;
                        }
                    }
                    else
                    {
                        if (recapes != null && yes == 1)
                        {
                            recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                            recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                            recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                            recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                            recapes.SS += ((Rappel)rappel).SS_Mois;
                            recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                            recapes.IRG += ((Rappel)rappel).IRG_Mois;
                            recapes.NET += ((Rappel)rappel).NET_Mois;
                        }
                        else
                        {
                            Recapes_Mars Recapes_Mars = new Recapes_Mars(Session);

                            Recapes_Mars.Brut_Impo_Bareme = ((Rappel)rappel).Imposable_bareme_Mois;
                            Recapes_Mars.IRG_Bareme = ((Rappel)rappel).Irg_bareme_Mois;
                            Recapes_Mars.Brut_Impo_Taux = ((Rappel)rappel).Imposable_taux_Mois;
                            Recapes_Mars.Brut_Cotis = ((Rappel)rappel).Brute_cotisable_Mois;
                            Recapes_Mars.SS = ((Rappel)rappel).SS_Mois;
                            Recapes_Mars.Brut_Impo = ((Rappel)rappel).Brute_imposable_Mois;
                            Recapes_Mars.IRG = ((Rappel)rappel).IRG_Mois;
                            Recapes_Mars.NET = ((Rappel)rappel).NET_Mois;
                            Recapes_Mars.Recape_Annuelle_Mars = this;
                            Recapes_Mars.Categorie = type;
                            Recapes_Mars.Mois = MoisdelAnnee.Mars;

                            recapes_Mars.Add(Recapes_Mars);
                        }
                    }
                }

            Session.CommitTransaction();
            return yes;
        }

        public int Recape_Avril<T>(T paye_rappel, CategorieCloture type, int yes)
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Avril);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Categorie==?", type);
            CriteriaOperator criteria3 = CriteriaOperator.Parse("Recape_Annuelle_Avr==?", Oid);

            Recapes_Avr recapes = Session.FindObject<Recapes_Avr>(CriteriaOperator.And(criteria1, criteria2, criteria3));

            if (type == CategorieCloture.Paye)
            {
                object paye = Convert.ChangeType(paye_rappel, typeof(Paye));

                if (recapes != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("La paye du mois d'Avril de l'employé " + ((Paye)paye).personne.Cod_personne + "/" + ((Paye)paye).personne.FullName + " est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                }
                else
                {
                    if (recapes != null && yes == 1)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                    else
                    {
                        Recapes_Avr Recapes_Avr = new Recapes_Avr(Session);

                        Recapes_Avr.Brut_Impo_Bareme = ((Paye)paye).Imposable_bareme_Abs;
                        Recapes_Avr.IRG_Bareme = ((Paye)paye).Irg_bareme_Abs;
                        Recapes_Avr.Brut_Impo_Taux = ((Paye)paye).Imposable_taux_Abs;
                        Recapes_Avr.IRG_Taux = ((Paye)paye).Irg_taux_Abs;
                        Recapes_Avr.Brut_Cotis = ((Paye)paye).Brute_cotisableAbsence;
                        Recapes_Avr.SS = ((Paye)paye).SSAbsence;
                        Recapes_Avr.Brut_Impo = ((Paye)paye).Brute_imposable_Abs;
                        Recapes_Avr.IRG = ((Paye)paye).IRGAbsence;
                        Recapes_Avr.NET = ((Paye)paye).NETAbsence;
                        Recapes_Avr.PP1 = ((Paye)paye).PP1;
                        Recapes_Avr.PP2 = ((Paye)paye).PP2;
                        Recapes_Avr.PP3 = ((Paye)paye).PP3;
                        Recapes_Avr.Taux_pp1 = ((Paye)paye).Taux_pp1;
                        Recapes_Avr.Taux_pp2 = ((Paye)paye).Taux_pp2;
                        Recapes_Avr.Taux_pp3 = ((Paye)paye).Taux_pp3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            Recapes_Avr.Nbr_jour_abs = ((Paye)paye).Nbr_jour_abs;
                            Recapes_Avr.Jour_Abs = ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        Recapes_Avr.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                        Recapes_Avr.Recape_Annuelle_Avr = this;
                        Recapes_Avr.Categorie = type;
                        Recapes_Avr.Mois = MoisdelAnnee.Avril;

                        recapes_Avr.Add(Recapes_Avr);
                    }
                }
            }
            else
            {
                object rappel = Convert.ChangeType(paye_rappel, typeof(Rappel));

                if (recapes != null)
                {
                    DialogResult result = MessageBox.Show("Le rappel du mois d'Avril est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.No)
                    {
                        Recapes_Avr Recapes_Avr = new Recapes_Avr(Session);

                        Recapes_Avr.Brut_Impo_Bareme = ((Rappel)rappel).Imposable_bareme_Mois;
                        Recapes_Avr.IRG_Bareme = ((Rappel)rappel).Irg_bareme_Mois;
                        Recapes_Avr.Brut_Impo_Taux = ((Rappel)rappel).Imposable_taux_Mois;
                        Recapes_Avr.Brut_Cotis = ((Rappel)rappel).Brute_cotisable_Mois;
                        Recapes_Avr.SS = ((Rappel)rappel).SS_Mois;
                        Recapes_Avr.Brut_Impo = ((Rappel)rappel).Brute_imposable_Mois;
                        Recapes_Avr.IRG = ((Rappel)rappel).IRG_Mois;
                        Recapes_Avr.NET = ((Rappel)rappel).NET_Mois;
                        Recapes_Avr.Recape_Annuelle_Avr = this;
                        Recapes_Avr.Categorie = type;
                        Recapes_Avr.Mois = MoisdelAnnee.Avril;

                        recapes_Avr.Add(Recapes_Avr);
                    }
                    else
                    {
                        recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                        recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                        recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                        recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                        recapes.SS += ((Rappel)rappel).SS_Mois;
                        recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                        recapes.IRG += ((Rappel)rappel).IRG_Mois;
                        recapes.NET += ((Rappel)rappel).NET_Mois;
                    }
                }
                else
                {
                    Recapes_Avr Recapes_Avr = new Recapes_Avr(Session);

                    Recapes_Avr.Brut_Impo_Bareme = ((Rappel)rappel).Imposable_bareme_Mois;
                    Recapes_Avr.IRG_Bareme = ((Rappel)rappel).Irg_bareme_Mois;
                    Recapes_Avr.Brut_Impo_Taux = ((Rappel)rappel).Imposable_taux_Mois;
                    Recapes_Avr.Brut_Cotis = ((Rappel)rappel).Brute_cotisable_Mois;
                    Recapes_Avr.SS = ((Rappel)rappel).SS_Mois;
                    Recapes_Avr.Brut_Impo = ((Rappel)rappel).Brute_imposable_Mois;
                    Recapes_Avr.IRG = ((Rappel)rappel).IRG_Mois;
                    Recapes_Avr.NET = ((Rappel)rappel).NET_Mois;
                    Recapes_Avr.Recape_Annuelle_Avr = this;
                    Recapes_Avr.Categorie = type;
                    Recapes_Avr.Mois = MoisdelAnnee.Avril;

                    recapes_Avr.Add(Recapes_Avr);

                }
            }
            Session.CommitTransaction();
            return yes;
        }

        public int Recape_Mai<T>(T paye_rappel, CategorieCloture type, int yes)
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Mai);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Categorie==?", type);
            CriteriaOperator criteria3 = CriteriaOperator.Parse("Recape_Annuelle_Mai==?", Oid);

            Recapes_Mai recapes = Session.FindObject<Recapes_Mai>(CriteriaOperator.And(criteria1, criteria2, criteria3));

            if (type == CategorieCloture.Paye)
            {

                object paye = Convert.ChangeType(paye_rappel, typeof(Paye));

                if (recapes != null && yes == 1)
                {
                    DialogResult result = MessageBox.Show("La paye du mois de Mai de l'employé " + ((Paye)paye).personne.Cod_personne + "/" + ((Paye)paye).personne.FullName + " est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                }
                else
                {
                    if (recapes != null && yes == 1)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                    else
                    {
                        Recapes_Mai Recapes_Mai = new Recapes_Mai(Session);

                        Recapes_Mai.Brut_Impo_Bareme = ((Paye)paye).Imposable_bareme_Abs;
                        Recapes_Mai.IRG_Bareme = ((Paye)paye).Irg_bareme_Abs;
                        Recapes_Mai.Brut_Impo_Taux = ((Paye)paye).Imposable_taux_Abs;
                        Recapes_Mai.IRG_Taux = ((Paye)paye).Irg_taux_Abs;
                        Recapes_Mai.Brut_Cotis = ((Paye)paye).Brute_cotisableAbsence;
                        Recapes_Mai.SS = ((Paye)paye).SSAbsence;
                        Recapes_Mai.Brut_Impo = ((Paye)paye).Brute_imposable_Abs;
                        Recapes_Mai.IRG = ((Paye)paye).IRGAbsence;
                        Recapes_Mai.NET = ((Paye)paye).NETAbsence;
                        Recapes_Mai.PP1 = ((Paye)paye).PP1;
                        Recapes_Mai.PP2 = ((Paye)paye).PP2;
                        Recapes_Mai.PP3 = ((Paye)paye).PP3;
                        Recapes_Mai.Taux_pp1 = ((Paye)paye).Taux_pp1;
                        Recapes_Mai.Taux_pp2 = ((Paye)paye).Taux_pp2;
                        Recapes_Mai.Taux_pp3 = ((Paye)paye).Taux_pp3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            Recapes_Mai.Nbr_jour_abs = ((Paye)paye).Nbr_jour_abs;
                            Recapes_Mai.Jour_Abs = ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        Recapes_Mai.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                        Recapes_Mai.Recape_Annuelle_Mai = this;
                        Recapes_Mai.Categorie = type;
                        Recapes_Mai.Mois = MoisdelAnnee.Mai;

                        recapes_Mai.Add(Recapes_Mai);
                    }
                }
            }
            else
            {
                object rappel = Convert.ChangeType(paye_rappel, typeof(Rappel));

                if (recapes != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("Le rappel du mois de Mai est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                        recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                        recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                        recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                        recapes.SS += ((Rappel)rappel).SS_Mois;
                        recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                        recapes.IRG += ((Rappel)rappel).IRG_Mois;
                        recapes.NET += ((Rappel)rappel).NET_Mois;
                    }
                }
                else
                {
                    if (recapes != null && yes == 0)
                    {
                        recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                        recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                        recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                        recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                        recapes.SS += ((Rappel)rappel).SS_Mois;
                        recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                        recapes.IRG += ((Rappel)rappel).IRG_Mois;
                        recapes.NET += ((Rappel)rappel).NET_Mois;
                    }
                    else
                    {
                        Recapes_Mai Recapes_Mai = new Recapes_Mai(Session);

                        Recapes_Mai.Brut_Impo_Bareme = ((Rappel)rappel).Imposable_bareme_Mois;
                        Recapes_Mai.IRG_Bareme = ((Rappel)rappel).Irg_bareme_Mois;
                        Recapes_Mai.Brut_Impo_Taux = ((Rappel)rappel).Imposable_taux_Mois;
                        Recapes_Mai.Brut_Cotis = ((Rappel)rappel).Brute_cotisable_Mois;
                        Recapes_Mai.SS = ((Rappel)rappel).SS_Mois;
                        Recapes_Mai.Brut_Impo = ((Rappel)rappel).Brute_imposable_Mois;
                        Recapes_Mai.IRG = ((Rappel)rappel).IRG_Mois;
                        Recapes_Mai.NET = ((Rappel)rappel).NET_Mois;
                        Recapes_Mai.Recape_Annuelle_Mai = this;
                        Recapes_Mai.Categorie = type;
                        Recapes_Mai.Mois = MoisdelAnnee.Mai;

                        recapes_Mai.Add(Recapes_Mai);
                    }
                }
            }
            Session.CommitTransaction();
            return yes;
        }

        public int Recape_Juin<T>(T paye_rappel, CategorieCloture type, int yes)
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Juin);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Categorie==?", type);
            CriteriaOperator criteria3 = CriteriaOperator.Parse("Recape_Annuelle_Juin==?", Oid);

            Recapes_Juin recapes = Session.FindObject<Recapes_Juin>(CriteriaOperator.And(criteria1, criteria2, criteria3));
            if (type == CategorieCloture.Paye)
            {
                object paye = Convert.ChangeType(paye_rappel, typeof(Paye));

                if (recapes != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("La paye du mois de Juin de l'employé " + ((Paye)paye).personne.Cod_personne + "/" + ((Paye)paye).personne.FullName + " est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                }
                else
                {
                    if (recapes != null && yes == 1)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                    else
                    {
                        Recapes_Juin Recapes_Juin = new Recapes_Juin(Session);

                        Recapes_Juin.Brut_Impo_Bareme = ((Paye)paye).Imposable_bareme_Abs;
                        Recapes_Juin.IRG_Bareme = ((Paye)paye).Irg_bareme_Abs;
                        Recapes_Juin.Brut_Impo_Taux = ((Paye)paye).Imposable_taux_Abs;
                        Recapes_Juin.IRG_Taux = ((Paye)paye).Irg_taux_Abs;
                        Recapes_Juin.Brut_Cotis = ((Paye)paye).Brute_cotisableAbsence;
                        Recapes_Juin.SS = ((Paye)paye).SSAbsence;
                        Recapes_Juin.Brut_Impo = ((Paye)paye).Brute_imposable_Abs;
                        Recapes_Juin.IRG = ((Paye)paye).IRGAbsence;
                        Recapes_Juin.NET = ((Paye)paye).NETAbsence;
                        Recapes_Juin.PP1 = ((Paye)paye).PP1;
                        Recapes_Juin.PP2 = ((Paye)paye).PP2;
                        Recapes_Juin.PP3 = ((Paye)paye).PP3;
                        Recapes_Juin.Taux_pp1 = ((Paye)paye).Taux_pp1;
                        Recapes_Juin.Taux_pp2 = ((Paye)paye).Taux_pp2;
                        Recapes_Juin.Taux_pp3 = ((Paye)paye).Taux_pp3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            Recapes_Juin.Nbr_jour_abs = ((Paye)paye).Nbr_jour_abs;
                            Recapes_Juin.Jour_Abs = ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        Recapes_Juin.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                        Recapes_Juin.Recape_Annuelle_Juin = this;
                        Recapes_Juin.Categorie = type;
                        Recapes_Juin.Mois = MoisdelAnnee.Juin;

                        recapes_Juin.Add(Recapes_Juin);
                    }
                }
            }
            else
            {
                object rappel = Convert.ChangeType(paye_rappel, typeof(Rappel));

                if (recapes != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("Le rappel du mois de Juin est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                        recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                        recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                        recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                        recapes.SS += ((Rappel)rappel).SS_Mois;
                        recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                        recapes.IRG += ((Rappel)rappel).IRG_Mois;
                        recapes.NET += ((Rappel)rappel).NET_Mois;
                    }
                }
                else
                {
                    if (recapes != null && yes == 1)
                    {
                        recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                        recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                        recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                        recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                        recapes.SS += ((Rappel)rappel).SS_Mois;
                        recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                        recapes.IRG += ((Rappel)rappel).IRG_Mois;
                        recapes.NET += ((Rappel)rappel).NET_Mois;
                    }
                    else
                    {
                        Recapes_Juin Recapes_Juin = new Recapes_Juin(Session);

                        Recapes_Juin.Brut_Impo_Bareme = ((Rappel)rappel).Imposable_bareme_Mois;
                        Recapes_Juin.IRG_Bareme = ((Rappel)rappel).Irg_bareme_Mois;
                        Recapes_Juin.Brut_Impo_Taux = ((Rappel)rappel).Imposable_taux_Mois;
                        Recapes_Juin.Brut_Cotis = ((Rappel)rappel).Brute_cotisable_Mois;
                        Recapes_Juin.SS = ((Rappel)rappel).SS_Mois;
                        Recapes_Juin.Brut_Impo = ((Rappel)rappel).Brute_imposable_Mois;
                        Recapes_Juin.IRG = ((Rappel)rappel).IRG_Mois;
                        Recapes_Juin.NET = ((Rappel)rappel).NET_Mois;
                        Recapes_Juin.Recape_Annuelle_Juin = this;
                        Recapes_Juin.Categorie = type;
                        Recapes_Juin.Mois = MoisdelAnnee.Juin;

                        recapes_Juin.Add(Recapes_Juin);
                    }
                }
            }
            Session.CommitTransaction();
            return yes;
        }

        public int Recape_Juillet<T>(T paye_rappel, CategorieCloture type, int yes)
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Juillet);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Categorie==?", type);
            CriteriaOperator criteria3 = CriteriaOperator.Parse("Recape_Annuelle_Juill==?", Oid);

            Recapes_Juill recapes = Session.FindObject<Recapes_Juill>(CriteriaOperator.And(criteria1, criteria2, criteria3));

            if (type == CategorieCloture.Paye)
            {
                object paye = Convert.ChangeType(paye_rappel, typeof(Paye));

                if (recapes != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("La paye du mois de Juillet de l'employé " + ((Paye)paye).personne.Cod_personne + "/" + ((Paye)paye).personne.FullName + " est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                }
                else
                {
                    if (recapes != null && yes == 1)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                    else
                    {
                        Recapes_Juill Recapes_Juill = new Recapes_Juill(Session);

                        Recapes_Juill.Brut_Impo_Bareme = ((Paye)paye).Imposable_bareme_Abs;
                        Recapes_Juill.IRG_Bareme = ((Paye)paye).Irg_bareme_Abs;
                        Recapes_Juill.Brut_Impo_Taux = ((Paye)paye).Imposable_taux_Abs;
                        Recapes_Juill.IRG_Taux = ((Paye)paye).Irg_taux_Abs;
                        Recapes_Juill.Brut_Cotis = ((Paye)paye).Brute_cotisableAbsence;
                        Recapes_Juill.SS = ((Paye)paye).SSAbsence;
                        Recapes_Juill.Brut_Impo = ((Paye)paye).Brute_imposable_Abs;
                        Recapes_Juill.IRG = ((Paye)paye).IRGAbsence;
                        Recapes_Juill.NET = ((Paye)paye).NETAbsence;
                        Recapes_Juill.PP1 = ((Paye)paye).PP1;
                        Recapes_Juill.PP2 = ((Paye)paye).PP2;
                        Recapes_Juill.PP3 = ((Paye)paye).PP3;
                        Recapes_Juill.Taux_pp1 = ((Paye)paye).Taux_pp1;
                        Recapes_Juill.Taux_pp2 = ((Paye)paye).Taux_pp2;
                        Recapes_Juill.Taux_pp3 = ((Paye)paye).Taux_pp3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            Recapes_Juill.Nbr_jour_abs = ((Paye)paye).Nbr_jour_abs;
                            Recapes_Juill.Jour_Abs = ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        Recapes_Juill.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                        Recapes_Juill.Recape_Annuelle_Juill = this;
                        Recapes_Juill.Categorie = type;
                        Recapes_Juill.Mois = MoisdelAnnee.Juillet;

                        recapes_Juill.Add(Recapes_Juill);
                    }
                }
            }
            else
            {
                object rappel = Convert.ChangeType(paye_rappel, typeof(Rappel));

                if (recapes != null)
                {
                    DialogResult result = MessageBox.Show("Le rappel du mois de Juillet est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                        recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                        recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                        recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                        recapes.SS += ((Rappel)rappel).SS_Mois;
                        recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                        recapes.IRG += ((Rappel)rappel).IRG_Mois;
                        recapes.NET += ((Rappel)rappel).NET_Mois;
                    }
                }
                else
                {
                    if (recapes != null && yes == 1)
                    {
                        recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                        recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                        recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                        recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                        recapes.SS += ((Rappel)rappel).SS_Mois;
                        recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                        recapes.IRG += ((Rappel)rappel).IRG_Mois;
                        recapes.NET += ((Rappel)rappel).NET_Mois;
                    }
                    else
                    {
                        Recapes_Juill Recapes_Juill = new Recapes_Juill(Session);

                        Recapes_Juill.Brut_Impo_Bareme = ((Rappel)rappel).Imposable_bareme_Mois;
                        Recapes_Juill.IRG_Bareme = ((Rappel)rappel).Irg_bareme_Mois;
                        Recapes_Juill.Brut_Impo_Taux = ((Rappel)rappel).Imposable_taux_Mois;
                        Recapes_Juill.Brut_Cotis = ((Rappel)rappel).Brute_cotisable_Mois;
                        Recapes_Juill.SS = ((Rappel)rappel).SS_Mois;
                        Recapes_Juill.Brut_Impo = ((Rappel)rappel).Brute_imposable_Mois;
                        Recapes_Juill.IRG = ((Rappel)rappel).IRG_Mois;
                        Recapes_Juill.NET = ((Rappel)rappel).NET_Mois;
                        Recapes_Juill.Recape_Annuelle_Juill = this;
                        Recapes_Juill.Categorie = type;
                        Recapes_Juill.Mois = MoisdelAnnee.Juillet;

                        recapes_Juill.Add(Recapes_Juill);
                    }
                }
            }
            Session.CommitTransaction();
            return yes;
        }

        public int Recape_Aout<T>(T paye_rappel, CategorieCloture type, int yes)
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Août);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Categorie==?", type);
            CriteriaOperator criteria3 = CriteriaOperator.Parse("Recape_Annuelle_Aout==?", Oid);

            Recapes_Aout recapes = Session.FindObject<Recapes_Aout>(CriteriaOperator.And(criteria1, criteria2, criteria3));

            if (type == CategorieCloture.Paye)
            {
                object paye = Convert.ChangeType(paye_rappel, typeof(Paye));

                if (recapes != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("La paye du mois d'Aout de l'employé " + ((Paye)paye).personne.Cod_personne + "/" + ((Paye)paye).personne.FullName + " est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv += ((Paye)paye).Nbr_jour_tra;
                    }
                }
                else
                {
                    if (recapes != null && yes == 1)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                    else
                    {
                        Recapes_Aout Recapes_Aout = new Recapes_Aout(Session);

                        Recapes_Aout.Brut_Impo_Bareme = ((Paye)paye).Imposable_bareme_Abs;
                        Recapes_Aout.IRG_Bareme = ((Paye)paye).Irg_bareme_Abs;
                        Recapes_Aout.Brut_Impo_Taux = ((Paye)paye).Imposable_taux_Abs;
                        Recapes_Aout.IRG_Taux = ((Paye)paye).Irg_taux_Abs;
                        Recapes_Aout.Brut_Cotis = ((Paye)paye).Brute_cotisableAbsence;
                        Recapes_Aout.SS = ((Paye)paye).SSAbsence;
                        Recapes_Aout.Brut_Impo = ((Paye)paye).Brute_imposable_Abs;
                        Recapes_Aout.IRG = ((Paye)paye).IRGAbsence;
                        Recapes_Aout.NET = ((Paye)paye).NETAbsence;
                        Recapes_Aout.PP1 = ((Paye)paye).PP1;
                        Recapes_Aout.PP2 = ((Paye)paye).PP2;
                        Recapes_Aout.PP3 = ((Paye)paye).PP3;
                        Recapes_Aout.Taux_pp1 = ((Paye)paye).Taux_pp1;
                        Recapes_Aout.Taux_pp2 = ((Paye)paye).Taux_pp2;
                        Recapes_Aout.Taux_pp3 = ((Paye)paye).Taux_pp3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            Recapes_Aout.Nbr_jour_abs = ((Paye)paye).Nbr_jour_abs;
                            Recapes_Aout.Jour_Abs = ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        Recapes_Aout.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                        Recapes_Aout.Recape_Annuelle_Aout = this;
                        Recapes_Aout.Categorie = type;
                        Recapes_Aout.Mois = MoisdelAnnee.Août;

                        recapes_Aout.Add(Recapes_Aout);
                    }
                }
            }
            else
            {
                object rappel = Convert.ChangeType(paye_rappel, typeof(Rappel));

                if (recapes != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("Le rappel du mois d'Aout est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                        recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                        recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                        recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                        recapes.SS += ((Rappel)rappel).SS_Mois;
                        recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                        recapes.IRG += ((Rappel)rappel).IRG_Mois;
                        recapes.NET += ((Rappel)rappel).NET_Mois;
                    }
                }
                else
                {
                    if (recapes != null && yes == 1)
                    {
                        recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                        recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                        recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                        recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                        recapes.SS += ((Rappel)rappel).SS_Mois;
                        recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                        recapes.IRG += ((Rappel)rappel).IRG_Mois;
                        recapes.NET += ((Rappel)rappel).NET_Mois;
                    }
                    else
                    {
                        Recapes_Aout Recapes_Aout = new Recapes_Aout(Session);

                        Recapes_Aout.Brut_Impo_Bareme = ((Rappel)rappel).Imposable_bareme_Mois;
                        Recapes_Aout.IRG_Bareme = ((Rappel)rappel).Irg_bareme_Mois;
                        Recapes_Aout.Brut_Impo_Taux = ((Rappel)rappel).Imposable_taux_Mois;
                        Recapes_Aout.Brut_Cotis = ((Rappel)rappel).Brute_cotisable_Mois;
                        Recapes_Aout.SS = ((Rappel)rappel).SS_Mois;
                        Recapes_Aout.Brut_Impo = ((Rappel)rappel).Brute_imposable_Mois;
                        Recapes_Aout.IRG = ((Rappel)rappel).IRG_Mois;
                        Recapes_Aout.NET = ((Rappel)rappel).NET_Mois;
                        Recapes_Aout.Recape_Annuelle_Aout = this;
                        Recapes_Aout.Categorie = type;
                        Recapes_Aout.Mois = MoisdelAnnee.Août;

                        recapes_Aout.Add(Recapes_Aout);
                    }
                }
            }
            Session.CommitTransaction();
            return yes;
        }

        public int Recape_Septembre<T>(T paye_rappel, CategorieCloture type, int yes)
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Septembre);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Categorie==?", type);
            CriteriaOperator criteria3 = CriteriaOperator.Parse("Recape_Annuelle_Sept==?", Oid);

            Recapes_Sept recapes = Session.FindObject<Recapes_Sept>(CriteriaOperator.And(criteria1, criteria2, criteria3));

            if (type == CategorieCloture.Paye)
            {
                object paye = Convert.ChangeType(paye_rappel, typeof(Paye));

                if (recapes != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("La paye du mois de Septembre de l'employé " + ((Paye)paye).personne.Cod_personne + "/" + ((Paye)paye).personne.FullName + " est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                }
                else
                {
                    if (recapes != null && yes == 1)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                    else
                    {
                        Recapes_Sept Recapes_Sept = new Recapes_Sept(Session);

                        Recapes_Sept.Brut_Impo_Bareme = ((Paye)paye).Imposable_bareme_Abs;
                        Recapes_Sept.IRG_Bareme = ((Paye)paye).Irg_bareme_Abs;
                        Recapes_Sept.Brut_Impo_Taux = ((Paye)paye).Imposable_taux_Abs;
                        Recapes_Sept.IRG_Taux = ((Paye)paye).Irg_taux_Abs;
                        Recapes_Sept.Brut_Cotis = ((Paye)paye).Brute_cotisableAbsence;
                        Recapes_Sept.SS = ((Paye)paye).SSAbsence;
                        Recapes_Sept.Brut_Impo = ((Paye)paye).Brute_imposable_Abs;
                        Recapes_Sept.IRG = ((Paye)paye).IRGAbsence;
                        Recapes_Sept.NET = ((Paye)paye).NETAbsence;
                        Recapes_Sept.PP1 = ((Paye)paye).PP1;
                        Recapes_Sept.PP2 = ((Paye)paye).PP2;
                        Recapes_Sept.PP3 = ((Paye)paye).PP3;
                        Recapes_Sept.Taux_pp1 = ((Paye)paye).Taux_pp1;
                        Recapes_Sept.Taux_pp2 = ((Paye)paye).Taux_pp2;
                        Recapes_Sept.Taux_pp3 = ((Paye)paye).Taux_pp3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            Recapes_Sept.Nbr_jour_abs = ((Paye)paye).Nbr_jour_abs;
                            Recapes_Sept.Jour_Abs = ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        Recapes_Sept.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                        Recapes_Sept.Recape_Annuelle_Sept = this;
                        Recapes_Sept.Categorie = type;
                        Recapes_Sept.Mois = MoisdelAnnee.Septembre;

                        recapes_Sept.Add(Recapes_Sept);
                    }
                }
            }
            else
            {
                object rappel = Convert.ChangeType(paye_rappel, typeof(Rappel));

                if (recapes != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("Le rappel du mois de Septembre est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                        recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                        recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                        recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                        recapes.SS += ((Rappel)rappel).SS_Mois;
                        recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                        recapes.IRG += ((Rappel)rappel).IRG_Mois;
                        recapes.NET += ((Rappel)rappel).NET_Mois;
                    }
                }
                else
                {
                    if (recapes != null && yes == 1)
                    {
                        recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                        recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                        recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                        recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                        recapes.SS += ((Rappel)rappel).SS_Mois;
                        recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                        recapes.IRG += ((Rappel)rappel).IRG_Mois;
                        recapes.NET += ((Rappel)rappel).NET_Mois;
                    }
                    else
                    {
                        Recapes_Sept Recapes_Sept = new Recapes_Sept(Session);

                        Recapes_Sept.Brut_Impo_Bareme = ((Rappel)rappel).Imposable_bareme_Mois;
                        Recapes_Sept.IRG_Bareme = ((Rappel)rappel).Irg_bareme_Mois;
                        Recapes_Sept.Brut_Impo_Taux = ((Rappel)rappel).Imposable_taux_Mois;
                        Recapes_Sept.Brut_Cotis = ((Rappel)rappel).Brute_cotisable_Mois;
                        Recapes_Sept.SS = ((Rappel)rappel).SS_Mois;
                        Recapes_Sept.Brut_Impo = ((Rappel)rappel).Brute_imposable_Mois;
                        Recapes_Sept.IRG = ((Rappel)rappel).IRG_Mois;
                        Recapes_Sept.NET = ((Rappel)rappel).NET_Mois;
                        Recapes_Sept.Recape_Annuelle_Sept = this;
                        Recapes_Sept.Categorie = type;
                        Recapes_Sept.Mois = MoisdelAnnee.Septembre;

                        recapes_Sept.Add(Recapes_Sept);
                    }
                }
            }
            Session.CommitTransaction();
            return yes;
        }

        public int Recape_Octobre<T>(T paye_rappel, CategorieCloture type, int yes)
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Octobre);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Categorie==?", type);
            CriteriaOperator criteria3 = CriteriaOperator.Parse("Recape_Annuelle_Oct==?", Oid);

            Recapes_Oct recapes = Session.FindObject<Recapes_Oct>(CriteriaOperator.And(criteria1, criteria2, criteria3));

            if (type == CategorieCloture.Paye)
            {

                object paye = Convert.ChangeType(paye_rappel, typeof(Paye));

                if (recapes != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("La paye du mois d'Octobre de l'employé " + ((Paye)paye).personne.Cod_personne + "/" + ((Paye)paye).personne.FullName + " est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                }
                else
                {
                    if (recapes != null && yes == 1)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                    else
                    {
                        Recapes_Oct Recapes_Oct = new Recapes_Oct(Session);

                        Recapes_Oct.Brut_Impo_Bareme = ((Paye)paye).Imposable_bareme_Abs;
                        Recapes_Oct.IRG_Bareme = ((Paye)paye).Irg_bareme_Abs;
                        Recapes_Oct.Brut_Impo_Taux = ((Paye)paye).Imposable_taux_Abs;
                        Recapes_Oct.IRG_Taux = ((Paye)paye).Irg_taux_Abs;
                        Recapes_Oct.Brut_Cotis = ((Paye)paye).Brute_cotisableAbsence;
                        Recapes_Oct.SS = ((Paye)paye).SSAbsence;
                        Recapes_Oct.Brut_Impo = ((Paye)paye).Brute_imposable_Abs;
                        Recapes_Oct.IRG = ((Paye)paye).IRGAbsence;
                        Recapes_Oct.NET = ((Paye)paye).NETAbsence;
                        Recapes_Oct.PP1 = ((Paye)paye).PP1;
                        Recapes_Oct.PP2 = ((Paye)paye).PP2;
                        Recapes_Oct.PP3 = ((Paye)paye).PP3;
                        Recapes_Oct.Taux_pp1 = ((Paye)paye).Taux_pp1;
                        Recapes_Oct.Taux_pp2 = ((Paye)paye).Taux_pp2;
                        Recapes_Oct.Taux_pp3 = ((Paye)paye).Taux_pp3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            Recapes_Oct.Nbr_jour_abs = ((Paye)paye).Nbr_jour_abs;
                            Recapes_Oct.Jour_Abs = ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        Recapes_Oct.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                        Recapes_Oct.Recape_Annuelle_Oct = this;
                        Recapes_Oct.Categorie = type;
                        Recapes_Oct.Mois = MoisdelAnnee.Octobre;

                        recapes_Oct.Add(Recapes_Oct);
                    }
                }
            }
            else
            {
                object rappel = Convert.ChangeType(paye_rappel, typeof(Rappel));

                if (recapes != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("Le rappel du mois d'Octobre est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                        recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                        recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                        recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                        recapes.SS += ((Rappel)rappel).SS_Mois;
                        recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                        recapes.IRG += ((Rappel)rappel).IRG_Mois;
                        recapes.NET += ((Rappel)rappel).NET_Mois;
                    }
                }
                else
                {
                    if (recapes != null && yes == 1)
                    {
                        recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                        recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                        recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                        recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                        recapes.SS += ((Rappel)rappel).SS_Mois;
                        recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                        recapes.IRG += ((Rappel)rappel).IRG_Mois;
                        recapes.NET += ((Rappel)rappel).NET_Mois;
                    }
                    else
                    {
                        Recapes_Oct Recapes_Oct = new Recapes_Oct(Session);

                        Recapes_Oct.Brut_Impo_Bareme = ((Rappel)rappel).Imposable_bareme_Mois;
                        Recapes_Oct.IRG_Bareme = ((Rappel)rappel).Irg_bareme_Mois;
                        Recapes_Oct.Brut_Impo_Taux = ((Rappel)rappel).Imposable_taux_Mois;
                        Recapes_Oct.Brut_Cotis = ((Rappel)rappel).Brute_cotisable_Mois;
                        Recapes_Oct.SS = ((Rappel)rappel).SS_Mois;
                        Recapes_Oct.Brut_Impo = ((Rappel)rappel).Brute_imposable_Mois;
                        Recapes_Oct.IRG = ((Rappel)rappel).IRG_Mois;
                        Recapes_Oct.NET = ((Rappel)rappel).NET_Mois;
                        Recapes_Oct.Recape_Annuelle_Oct = this;
                        Recapes_Oct.Categorie = type;
                        Recapes_Oct.Mois = MoisdelAnnee.Octobre;

                        recapes_Oct.Add(Recapes_Oct);
                    }
                }
            }
            Session.CommitTransaction();
            return yes;
        }

        public int Recape_Nouvembre<T>(T paye_rappel, CategorieCloture type, int yes)
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Novembre);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Categorie==?", type);
            CriteriaOperator criteria3 = CriteriaOperator.Parse("Recape_Annuelle_Nouv==?", Oid);

            Recapes_Nouv recapes = Session.FindObject<Recapes_Nouv>(CriteriaOperator.And(criteria1, criteria2, criteria3));

            if (type == CategorieCloture.Paye)
            {

                object paye = Convert.ChangeType(paye_rappel, typeof(Paye));

                if (recapes != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("La paye du mois de Nouvembre de l'employé " + ((Paye)paye).personne.Cod_personne + "/" + ((Paye)paye).personne.FullName + " est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                }
                else
                {
                    if (recapes != null && yes == 1)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                    else
                    {
                        Recapes_Nouv Recapes_Nouv = new Recapes_Nouv(Session);

                        Recapes_Nouv.Brut_Impo_Bareme = ((Paye)paye).Imposable_bareme_Abs;
                        Recapes_Nouv.IRG_Bareme = ((Paye)paye).Irg_bareme_Abs;
                        Recapes_Nouv.Brut_Impo_Taux = ((Paye)paye).Imposable_taux_Abs;
                        Recapes_Nouv.IRG_Taux = ((Paye)paye).Irg_taux_Abs;
                        Recapes_Nouv.Brut_Cotis = ((Paye)paye).Brute_cotisableAbsence;
                        Recapes_Nouv.SS = ((Paye)paye).SSAbsence;
                        Recapes_Nouv.Brut_Impo = ((Paye)paye).Brute_imposable_Abs;
                        Recapes_Nouv.IRG = ((Paye)paye).IRGAbsence;
                        Recapes_Nouv.NET = ((Paye)paye).NETAbsence;
                        Recapes_Nouv.PP1 = ((Paye)paye).PP1;
                        Recapes_Nouv.PP2 = ((Paye)paye).PP2;
                        Recapes_Nouv.PP3 = ((Paye)paye).PP3;
                        Recapes_Nouv.Taux_pp1 = ((Paye)paye).Taux_pp1;
                        Recapes_Nouv.Taux_pp2 = ((Paye)paye).Taux_pp2;
                        Recapes_Nouv.Taux_pp3 = ((Paye)paye).Taux_pp3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            Recapes_Nouv.Nbr_jour_abs = ((Paye)paye).Nbr_jour_abs;
                            Recapes_Nouv.Jour_Abs = ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        Recapes_Nouv.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                        Recapes_Nouv.Recape_Annuelle_Nouv = this;
                        Recapes_Nouv.Categorie = type;
                        Recapes_Nouv.Mois = MoisdelAnnee.Novembre;

                        recapes_Nouv.Add(Recapes_Nouv);
                    }
                }
            }
            else
            {
                object rappel = Convert.ChangeType(paye_rappel, typeof(Rappel));

                if (recapes != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("Le rappel du mois de Nouvembre est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                        recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                        recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                        //recapes.IRG_Taux += ((Rappel)rappel).Irg_taux_Mois;
                        recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                        recapes.SS += ((Rappel)rappel).SS_Mois;
                        recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                        recapes.IRG += ((Rappel)rappel).IRG_Mois;
                        recapes.NET += ((Rappel)rappel).NET_Mois;
                        //recapes.Nbr_jour_abs += ((Rappel)rappel).Nbr_jour_abs;
                    }
                }
                else
                {
                    if (recapes != null && yes == 1)
                    {
                        recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                        recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                        recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                        //recapes.IRG_Taux += ((Rappel)rappel).Irg_taux_Mois;
                        recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                        recapes.SS += ((Rappel)rappel).SS_Mois;
                        recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                        recapes.IRG += ((Rappel)rappel).IRG_Mois;
                        recapes.NET += ((Rappel)rappel).NET_Mois;
                        //recapes.Nbr_jour_abs += ((Rappel)rappel).Nbr_jour_abs;
                    }
                    else
                    {
                        Recapes_Nouv Recapes_Nouv = new Recapes_Nouv(Session);

                        Recapes_Nouv.Brut_Impo_Bareme = ((Rappel)rappel).Imposable_bareme_Mois;
                        Recapes_Nouv.IRG_Bareme = ((Rappel)rappel).Irg_bareme_Mois;
                        Recapes_Nouv.Brut_Impo_Taux = ((Rappel)rappel).Imposable_taux_Mois;
                        //Recapes_Nouv.IRG_Taux = ((Rappel)rappel).Irg_taux_Mois;
                        Recapes_Nouv.Brut_Cotis = ((Rappel)rappel).Brute_cotisable_Mois;
                        Recapes_Nouv.SS = ((Rappel)rappel).SS_Mois;
                        Recapes_Nouv.Brut_Impo = ((Rappel)rappel).Brute_imposable_Mois;
                        Recapes_Nouv.IRG = ((Rappel)rappel).IRG_Mois;
                        Recapes_Nouv.NET = ((Rappel)rappel).NET_Mois;
                        //Recapes_Nouv.Nbr_jour_abs = ((Rappel)rappel).Nbr_jour_abs;
                        Recapes_Nouv.Recape_Annuelle_Nouv = this;
                        Recapes_Nouv.Categorie = type;
                        Recapes_Nouv.Mois = MoisdelAnnee.Novembre;

                        recapes_Nouv.Add(Recapes_Nouv);
                    }
                }
            }
            Session.CommitTransaction();
            return yes;
        }

        public int Recape_Decembre<T>(T paye_rappel, CategorieCloture type, int yes)
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Décembre);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Categorie==?", type);
            CriteriaOperator criteria3 = CriteriaOperator.Parse("Recape_Annuelle_Dec==?", Oid);

            Recapes_Dec recapes = Session.FindObject<Recapes_Dec>(CriteriaOperator.And(criteria1, criteria2, criteria3));

            if (type == CategorieCloture.Paye)
            {
                object paye = Convert.ChangeType(paye_rappel, typeof(Paye));

                if (recapes != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("La paye du mois de Décembre de l'employé " + ((Paye)paye).personne.Cod_personne + "/" + ((Paye)paye).personne.FullName + " est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                }
                else
                {
                    if (recapes != null && yes == 1)
                    {
                        recapes.Brut_Impo_Bareme += ((Paye)paye).Imposable_bareme_Abs;
                        recapes.IRG_Bareme += ((Paye)paye).Irg_bareme_Abs;
                        recapes.Brut_Impo_Taux += ((Paye)paye).Imposable_taux_Abs;
                        recapes.IRG_Taux += ((Paye)paye).Irg_taux_Abs;
                        recapes.Brut_Cotis += ((Paye)paye).Brute_cotisableAbsence;
                        recapes.SS += ((Paye)paye).SSAbsence;
                        recapes.Brut_Impo += ((Paye)paye).Brute_imposable_Abs;
                        recapes.IRG += ((Paye)paye).IRGAbsence;
                        recapes.NET += ((Paye)paye).NETAbsence;
                        recapes.PP1 += ((Paye)paye).PP1;
                        recapes.PP2 += ((Paye)paye).PP2;
                        recapes.PP3 += ((Paye)paye).PP3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            recapes.Nbr_jour_abs += ((Paye)paye).Nbr_jour_abs;
                            recapes.Jour_Abs += ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        recapes.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                    }
                    else
                    {
                        Recapes_Dec Recapes_Dec = new Recapes_Dec(Session);

                        Recapes_Dec.Brut_Impo_Bareme = ((Paye)paye).Imposable_bareme_Abs;
                        Recapes_Dec.IRG_Bareme = ((Paye)paye).Irg_bareme_Abs;
                        Recapes_Dec.Brut_Impo_Taux = ((Paye)paye).Imposable_taux_Abs;
                        Recapes_Dec.IRG_Taux = ((Paye)paye).Irg_taux_Abs;
                        Recapes_Dec.Brut_Cotis = ((Paye)paye).Brute_cotisableAbsence;
                        Recapes_Dec.SS = ((Paye)paye).SSAbsence;
                        Recapes_Dec.Brut_Impo = ((Paye)paye).Brute_imposable_Abs;
                        Recapes_Dec.IRG = ((Paye)paye).IRGAbsence;
                        Recapes_Dec.NET = ((Paye)paye).NETAbsence;
                        Recapes_Dec.PP1 = ((Paye)paye).PP1;
                        Recapes_Dec.PP2 = ((Paye)paye).PP2;
                        Recapes_Dec.PP3 = ((Paye)paye).PP3;
                        Recapes_Dec.Taux_pp1 = ((Paye)paye).Taux_pp1;
                        Recapes_Dec.Taux_pp2 = ((Paye)paye).Taux_pp2;
                        Recapes_Dec.Taux_pp3 = ((Paye)paye).Taux_pp3;
                        if (((Paye)paye).cat_paye == CategoriePaye.Paye_Mensuel || ((Paye)paye).cat_paye == CategoriePaye.Congé)
                        {
                            Recapes_Dec.Nbr_jour_abs = ((Paye)paye).Nbr_jour_abs;
                            Recapes_Dec.Jour_Abs = ((Paye)paye).Jour_Abs;
                            //this.personne.Nbr_Jrs_Cong_Accor += (((Paye)paye).Nbr_jour_tra - ((Paye)paye).Jour_Abs) * parametres.nbr_jour_cong_mois;
                        }
                        Recapes_Dec.Nbr_jour_ouv = ((Paye)paye).Nbr_jour_tra;
                        Recapes_Dec.Recape_Annuelle_Dec = this;
                        Recapes_Dec.Categorie = type;
                        Recapes_Dec.Mois = MoisdelAnnee.Décembre;

                        recapes_Dec.Add(Recapes_Dec);
                    }
                }
            }
            else
            {
                object rappel = Convert.ChangeType(paye_rappel, typeof(Rappel));

                if (recapes != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("Le rappel du mois de Décembre est déja cloturée, voulez vous cumuler les montants", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    DialogResult result2 = MessageBox.Show("Voulez vous cumuler tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                        yes = 1;

                    if (result == DialogResult.Yes)
                    {
                        recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                        recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                        recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                        //recapes.IRG_Taux += ((Rappel)rappel).Irg_taux_Mois;
                        recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                        recapes.SS += ((Rappel)rappel).SS_Mois;
                        recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                        recapes.IRG += ((Rappel)rappel).IRG_Mois;
                        recapes.NET += ((Rappel)rappel).NET_Mois;
                        //recapes.Nbr_jour_abs += ((Rappel)rappel).Nbr_jour_abs;
                    }
                }
                else
                {
                    if (recapes != null && yes == 1)
                    {
                        recapes.Brut_Impo_Bareme += ((Rappel)rappel).Imposable_bareme_Mois;
                        recapes.IRG_Bareme += ((Rappel)rappel).Irg_bareme_Mois;
                        recapes.Brut_Impo_Taux += ((Rappel)rappel).Imposable_taux_Mois;
                        //recapes.IRG_Taux += ((Rappel)rappel).Irg_taux_Mois;
                        recapes.Brut_Cotis += ((Rappel)rappel).Brute_cotisable_Mois;
                        recapes.SS += ((Rappel)rappel).SS_Mois;
                        recapes.Brut_Impo += ((Rappel)rappel).Brute_imposable_Mois;
                        recapes.IRG += ((Rappel)rappel).IRG_Mois;
                        recapes.NET += ((Rappel)rappel).NET_Mois;
                        //recapes.Nbr_jour_abs += ((Rappel)rappel).Nbr_jour_abs; 
                    }
                    else
                    {
                        Recapes_Dec Recapes_Dec = new Recapes_Dec(Session);

                        Recapes_Dec.Brut_Impo_Bareme = ((Rappel)rappel).Imposable_bareme_Mois;
                        Recapes_Dec.IRG_Bareme = ((Rappel)rappel).Irg_bareme_Mois;
                        Recapes_Dec.Brut_Impo_Taux = ((Rappel)rappel).Imposable_taux_Mois;
                        //Recapes_Dec.IRG_Taux = ((Rappel)rappel).Irg_taux_Mois;
                        Recapes_Dec.Brut_Cotis = ((Rappel)rappel).Brute_cotisable_Mois;
                        Recapes_Dec.SS = ((Rappel)rappel).SS_Mois;
                        Recapes_Dec.Brut_Impo = ((Rappel)rappel).Brute_imposable_Mois;
                        Recapes_Dec.IRG = ((Rappel)rappel).IRG_Mois;
                        Recapes_Dec.NET = ((Rappel)rappel).NET_Mois;
                        //Recapes_Dec.Nbr_jour_abs = ((Rappel)rappel).Nbr_jour_abs;
                        Recapes_Dec.Recape_Annuelle_Dec = this;
                        Recapes_Dec.Categorie = type;
                        Recapes_Dec.Mois = MoisdelAnnee.Décembre;

                        recapes_Dec.Add(Recapes_Dec);
                    }
                }
            }

            Session.CommitTransaction();
            return yes;
        }

        public void Somme_Janv()
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Janvier);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Recape_Annuelle_Janv==?", Oid);

            XPCollection<Recapes_Janv> Recapes_Janv_Collection = new XPCollection<Recapes_Janv>(Session, CriteriaOperator.And(criteria1, criteria2));

            if (Recapes_Janv_Collection.Count != 0) 
                foreach (Recapes_Janv recape in Recapes_Janv_Collection)
                {
                    Brut_Impo_Bareme_Janv += recape.Brut_Impo_Bareme;
                    IRG_Bareme_Janv += recape.IRG_Bareme;
                    Brut_Impo_Taux_Janv += recape.Brut_Impo_Taux;
                    IRG_Taux_Janv += recape.IRG_Taux;
                    Brut_Cotis_Janv += recape.Brut_Cotis;
                    SS_Janv += recape.SS;
                    Brut_Impo_Janv += recape.Brut_Impo;
                    IRG_Janv += recape.IRG;
                    NET_Janv += recape.NET;
                    PP1_Janv += recape.PP1;
                    PP2_Janv += recape.PP2;
                    PP3_Janv += recape.PP3;
                    if (recape.Categorie == CategorieCloture.Paye)
                    {
                        Nbr_jour_abs_Janv += (int)recape.Nbr_jour_abs;
                        Nbr_jour_ouv_Janv += recape.Nbr_jour_ouv;
                    }
                    if (Nbr_jour_ouv_Janv > parametres.Nbr_jour_tra)
                    {
                        Nbr_jour_ouv_Janv = parametres.Nbr_jour_tra;
                        if (recape.Recape_Annuelle_Janv != null)
                            MessageBox.Show("L'employé avec la matricule : " + recape.Recape_Annuelle_Janv.personne.Cod_personne + " a plusieurs paies de catégorie <<Paie Mensuelle>> !");
                    }
                    //if (parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuel || parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuelRecuperation)
                    //{
                    personne.Nbr_Jrs_Cong_Accor = 0;
                    if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences)
                    {
                        Nbr_jour_cong_Janv = ((Nbr_jour_ouv_Janv - Nbr_jour_abs_Janv) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                        Nbr_jour_cong_Janv = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Janv);
                    }
                    else
                        if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences15)
                        {
                            if (Nbr_jour_abs_Janv < 15)
                            {
                                Nbr_jour_cong_Janv = parametres.nbr_jour_cong_mois;
                                Nbr_jour_cong_Janv = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Janv);
                            }
                        }
                        else
                        {
                            Nbr_jour_cong_Janv =   parametres.nbr_jour_cong_mois;
                            Nbr_jour_cong_Janv = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Janv);
                        }
                    personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong + Nbr_jour_cong_Janv;
                    personne.Save();
                }
        }

        public void Somme_Fev()
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Février);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Recape_Annuelle_Fev==?", Oid);

            XPCollection<Recapes_Fev> Recapes_Fev_Collection = new XPCollection<Recapes_Fev>(Session, CriteriaOperator.And(criteria1, criteria2));

            if (Recapes_Fev_Collection.Count != 0)
                foreach (Recapes_Fev recape in Recapes_Fev_Collection)
                {
                    Brut_Impo_Bareme_Fev += recape.Brut_Impo_Bareme;
                    IRG_Bareme_Fev += recape.IRG_Bareme;
                    Brut_Impo_Taux_Fev += recape.Brut_Impo_Taux;
                    IRG_Taux_Fev += recape.IRG_Taux;
                    Brut_Cotis_Fev += recape.Brut_Cotis;
                    SS_Fev += recape.SS;
                    Brut_Impo_Fev += recape.Brut_Impo;
                    IRG_Fev += recape.IRG;
                    NET_Fev += recape.NET;
                    PP1_Fev += recape.PP1;
                    PP2_Fev += recape.PP2;
                    PP3_Fev += recape.PP3;
                    if (recape.Categorie == CategorieCloture.Paye)
                    {
                        Nbr_jour_abs_Fev += (int)recape.Nbr_jour_abs;
                        Nbr_jour_ouv_Fev += recape.Nbr_jour_ouv;
                    }
                    if (Nbr_jour_ouv_Fev > parametres.Nbr_jour_tra)
                    {
                        Nbr_jour_ouv_Fev = parametres.Nbr_jour_tra;
                        if (recape.Recape_Annuelle_Fev != null)
                            MessageBox.Show("L'employé avec la matricule : " + recape.Recape_Annuelle_Fev.personne.Cod_personne + " a plusieurs paies de catégorie <<Paie Mensuelle>> !");
                    }
                    //if (parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuel || parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuelRecuperation)
                    //{
                    personne.Nbr_Jrs_Cong_Accor = 0;
                    if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences)
                    {
                        Nbr_jour_cong_Fev = ((Nbr_jour_ouv_Fev - Nbr_jour_abs_Fev) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                        Nbr_jour_cong_Fev = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Fev);
                    }
                    else
                        if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences15)
                        {
                            if (Nbr_jour_abs_Fev < 15)
                            {
                                Nbr_jour_cong_Fev = parametres.nbr_jour_cong_mois;
                                Nbr_jour_cong_Fev = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Fev);
                            }
                        }
                        else
                        {
                            Nbr_jour_cong_Fev = parametres.nbr_jour_cong_mois;
                            Nbr_jour_cong_Fev = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Fev);
                        }
                    personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong + Nbr_jour_cong_Fev + Nbr_jour_cong_Janv;
                    //personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong +
                    //     ((Nbr_jour_ouv_Janv - Nbr_jour_abs_Janv) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Fev - Nbr_jour_abs_Fev) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                    //personne.Nbr_Jrs_Cong_Accor = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Accor);
                    personne.Save();
                    //}
                }

        }

        public void Somme_Mars()
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Mars);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Recape_Annuelle_Mars==?", Oid);

            XPCollection<Recapes_Mars> Recapes_Mars_Collection = new XPCollection<Recapes_Mars>(Session, CriteriaOperator.And(criteria1, criteria2));

            if (Recapes_Mars_Collection.Count != 0)
                foreach (Recapes_Mars recape in Recapes_Mars_Collection)
                {
                    Brut_Impo_Bareme_Mars += recape.Brut_Impo_Bareme;
                    IRG_Bareme_Mars += recape.IRG_Bareme;
                    Brut_Impo_Taux_Mars += recape.Brut_Impo_Taux;
                    IRG_Taux_Mars += recape.IRG_Taux;
                    Brut_Cotis_Mars += recape.Brut_Cotis;
                    SS_Mars += recape.SS;
                    Brut_Impo_Mars += recape.Brut_Impo;
                    IRG_Mars += recape.IRG;
                    NET_Mars += recape.NET;
                    PP1_Mars += recape.PP1;
                    PP2_Mars += recape.PP2;
                    PP3_Mars += recape.PP3;
                    if (recape.Categorie == CategorieCloture.Paye)
                    {
                        Nbr_jour_abs_Mars += (int)recape.Nbr_jour_abs;
                        Nbr_jour_ouv_Mars += recape.Nbr_jour_ouv;
                    }
                    if (Nbr_jour_ouv_Mars > parametres.Nbr_jour_tra)
                    {
                        Nbr_jour_ouv_Mars = parametres.Nbr_jour_tra;
                        if (recape.Recape_Annuelle_Mars != null)
                            MessageBox.Show("L'employé avec la matricule : " + recape.Recape_Annuelle_Mars.personne.Cod_personne + " a plusieurs paies de catégorie <<Paie Mensuelle>> !");
                    }
                    //if (parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuel || parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuelRecuperation)
                    //{
                    personne.Nbr_Jrs_Cong_Accor = 0;
                    if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences)
                    {
                        Nbr_jour_cong_Mars = ((Nbr_jour_ouv_Mars - Nbr_jour_abs_Mars) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                        Nbr_jour_cong_Mars = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Mars);
                    }
                    else
                        if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences15)
                        {
                            if (Nbr_jour_abs_Mars < 15)
                            {
                                Nbr_jour_cong_Mars = parametres.nbr_jour_cong_mois;
                                Nbr_jour_cong_Mars = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Mars);
                            }
                        }
                        else
                        {
                            Nbr_jour_cong_Mars = parametres.nbr_jour_cong_mois;
                            Nbr_jour_cong_Mars = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Mars);
                        }
                    personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong + Nbr_jour_cong_Mars + Nbr_jour_cong_Fev + Nbr_jour_cong_Janv;
                    //personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong +
                    //     ((Nbr_jour_ouv_Janv - Nbr_jour_abs_Janv) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Fev - Nbr_jour_abs_Fev) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Mars - Nbr_jour_abs_Mars) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                    //personne.Nbr_Jrs_Cong_Accor = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Accor);
                    personne.Save();
                    //}
                }
        }

        public void Somme_Avr()
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Avril);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Recape_Annuelle_Avr==?", Oid);

            XPCollection<Recapes_Avr> Recapes_Avr_Collection = new XPCollection<Recapes_Avr>(Session, CriteriaOperator.And(criteria1, criteria2));

            if (Recapes_Avr_Collection.Count != 0)
                foreach (Recapes_Avr recape in Recapes_Avr_Collection)
                {
                    Brut_Impo_Bareme_Avr += recape.Brut_Impo_Bareme;
                    IRG_Bareme_Avr += recape.IRG_Bareme;
                    Brut_Impo_Taux_Avr += recape.Brut_Impo_Taux;
                    IRG_Taux_Avr += recape.IRG_Taux;
                    Brut_Cotis_Avr += recape.Brut_Cotis;
                    SS_Avr += recape.SS;
                    Brut_Impo_Avr += recape.Brut_Impo;
                    IRG_Avr += recape.IRG;
                    NET_Avr = recape.NET;
                    PP1_Avr += recape.PP1;
                    PP2_Avr += recape.PP2;
                    PP3_Avr += recape.PP3;
                    if (recape.Categorie == CategorieCloture.Paye)
                    {
                        Nbr_jour_abs_Avr += (int)recape.Nbr_jour_abs;
                        Nbr_jour_ouv_Avr += recape.Nbr_jour_ouv;
                    }
                    if (Nbr_jour_ouv_Avr > parametres.Nbr_jour_tra)
                    {
                        Nbr_jour_ouv_Avr = parametres.Nbr_jour_tra;
                        if (recape.Recape_Annuelle_Avr != null)
                            MessageBox.Show("L'employé avec la matricule : " + recape.Recape_Annuelle_Avr.personne.Cod_personne + " a plusieurs paies de catégorie <<Paie Mensuelle>> !");
                    }
                    //if (parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuel || parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuelRecuperation)
                    //{
                    personne.Nbr_Jrs_Cong_Accor = 0;
                    //personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong +
                    //     ((Nbr_jour_ouv_Janv - Nbr_jour_abs_Janv) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Fev - Nbr_jour_abs_Fev) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Mars - Nbr_jour_abs_Mars) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Avr - Nbr_jour_abs_Avr) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                    //personne.Nbr_Jrs_Cong_Accor = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Accor);
                    if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences)
                    {
                        Nbr_jour_cong_Avr = ((Nbr_jour_ouv_Avr - Nbr_jour_abs_Avr) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                        Nbr_jour_cong_Avr = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Avr);
                    }
                    else
                        if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences15)
                        {
                            if (Nbr_jour_abs_Avr < 15)
                            {
                                Nbr_jour_cong_Avr = parametres.nbr_jour_cong_mois;
                                Nbr_jour_cong_Avr = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Avr);
                            }
                        }
                        else
                        {
                            Nbr_jour_cong_Avr  = parametres.nbr_jour_cong_mois;
                            Nbr_jour_cong_Avr = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Avr);
                        }
                    personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong + Nbr_jour_cong_Avr + Nbr_jour_cong_Mars
                        + Nbr_jour_cong_Fev + Nbr_jour_cong_Janv;
                    personne.Save();
                    //}
                }
        }

        public void Somme_Mai()
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Mai);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Recape_Annuelle_Mai==?", Oid);

            XPCollection<Recapes_Mai> Recapes_Mai_Collection = new XPCollection<Recapes_Mai>(Session, CriteriaOperator.And(criteria1, criteria2));

            if (Recapes_Mai_Collection.Count != 0)
                foreach (Recapes_Mai recape in Recapes_Mai_Collection)
                {
                    Brut_Impo_Bareme_Mai += recape.Brut_Impo_Bareme;
                    IRG_Bareme_Mai += recape.IRG_Bareme;
                    Brut_Impo_Taux_Mai += recape.Brut_Impo_Taux;
                    IRG_Taux_Mai += recape.IRG_Taux;
                    Brut_Cotis_Mai += recape.Brut_Cotis;
                    SS_Mai += recape.SS;
                    Brut_Impo_Mai += recape.Brut_Impo;
                    IRG_Mai += recape.IRG;
                    NET_Mai += recape.NET;
                    PP1_Mai += recape.PP1;
                    PP2_Mai += recape.PP2;
                    PP3_Mai += recape.PP3;
                    if (recape.Categorie == CategorieCloture.Paye)
                    {
                        Nbr_jour_abs_Mai += (int)recape.Nbr_jour_abs;
                        Nbr_jour_ouv_Mai += recape.Nbr_jour_ouv;
                    }
                    if (Nbr_jour_ouv_Mai > parametres.Nbr_jour_tra)
                    {
                        Nbr_jour_ouv_Mai = parametres.Nbr_jour_tra;
                        if (recape.Recape_Annuelle_Mai != null)
                            MessageBox.Show("L'employé avec la matricule : " + recape.Recape_Annuelle_Mai.personne.Cod_personne + " a plusieurs paies de catégorie <<Paie Mensuelle>> !");
                    }
                    //if (parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuel || parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuelRecuperation)
                    //{
                    personne.Nbr_Jrs_Cong_Accor = 0;
                    if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences)
                    {
                        Nbr_jour_cong_Mai = ((Nbr_jour_ouv_Mai - Nbr_jour_abs_Mai) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                        Nbr_jour_cong_Mai = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Mai);
                    }
                    else
                        if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences15)
                        {
                            if (Nbr_jour_abs_Mai < 15)
                            {
                                Nbr_jour_cong_Mai = parametres.nbr_jour_cong_mois;
                                Nbr_jour_cong_Mai = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Mai);
                            }
                        }
                        else
                        {
                            Nbr_jour_cong_Mai = parametres.nbr_jour_cong_mois;
                            Nbr_jour_cong_Mai = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Mai);
                        }
                    personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong + Nbr_jour_cong_Mai + Nbr_jour_cong_Avr + Nbr_jour_cong_Mars
                        + Nbr_jour_cong_Fev + Nbr_jour_cong_Janv;
                    //personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong +
                    //     ((Nbr_jour_ouv_Janv - Nbr_jour_abs_Janv) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Fev - Nbr_jour_abs_Fev) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Mars - Nbr_jour_abs_Mars) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Avr - Nbr_jour_abs_Avr) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Mai - Nbr_jour_abs_Mai) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                    //personne.Nbr_Jrs_Cong_Accor = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Accor);
                    personne.Save();
                    //}
                }
        }

        public void Somme_Juin()
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Juin);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Recape_Annuelle_Juin==?", Oid);

            XPCollection<Recapes_Juin> Recapes_Juin_Collection = new XPCollection<Recapes_Juin>(Session, CriteriaOperator.And(criteria1, criteria2));

            if (Recapes_Juin_Collection.Count != 0)
                foreach (Recapes_Juin recape in Recapes_Juin_Collection)
                {
                    Brut_Impo_Bareme_Juin += recape.Brut_Impo_Bareme;
                    IRG_Bareme_Juin += recape.IRG_Bareme;
                    Brut_Impo_Taux_Juin += recape.Brut_Impo_Taux;
                    IRG_Taux_Juin += recape.IRG_Taux;
                    Brut_Cotis_Juin += recape.Brut_Cotis;
                    SS_Juin += recape.SS;
                    Brut_Impo_Juin += recape.Brut_Impo;
                    IRG_Juin += recape.IRG;
                    NET_Juin += recape.NET;
                    PP1_Juin += recape.PP1;
                    PP2_Juin += recape.PP2;
                    PP3_Juin += recape.PP3;
                    if (recape.Categorie == CategorieCloture.Paye)
                    {
                        Nbr_jour_abs_Juin += (int)recape.Nbr_jour_abs;
                        Nbr_jour_ouv_Juin += recape.Nbr_jour_ouv;
                    }
                    if (Nbr_jour_ouv_Juin > parametres.Nbr_jour_tra)
                    {
                        Nbr_jour_ouv_Juin = parametres.Nbr_jour_tra;
                        if (recape.Recape_Annuelle_Juin != null)
                            MessageBox.Show("L'employé avec la matricule : " + recape.Recape_Annuelle_Juin.personne.Cod_personne + " a plusieurs paies de catégorie <<Paie Mensuelle>> !");
                    }
                    //if (parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuel || parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuelRecuperation)
                    //{
                    personne.Nbr_Jrs_Cong_Accor = 0;
                    //personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong +
                    //    ((Nbr_jour_ouv_Janv - Nbr_jour_abs_Janv) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Fev - Nbr_jour_abs_Fev) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Mars - Nbr_jour_abs_Mars) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Avr - Nbr_jour_abs_Avr) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Mai - Nbr_jour_abs_Mai) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Juin - Nbr_jour_abs_Juin) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                    //personne.Nbr_Jrs_Cong_Accor = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Accor);
                    if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences)
                    {
                        Nbr_jour_cong_Juin = ((Nbr_jour_ouv_Juin - Nbr_jour_abs_Juin) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                        Nbr_jour_cong_Juin = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Juin);
                    }
                    else
                        if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences15)
                        {
                            if (Nbr_jour_abs_Juin < 15)
                            {
                                Nbr_jour_cong_Juin = parametres.nbr_jour_cong_mois;
                                Nbr_jour_cong_Juin = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Juin);
                            }
                        }
                        else
                        {
                            Nbr_jour_cong_Juin = parametres.nbr_jour_cong_mois;
                            Nbr_jour_cong_Juin = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Juin);
                        }
                    personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong + Nbr_jour_cong_Juin + Nbr_jour_cong_Mai + Nbr_jour_cong_Avr
                        + Nbr_jour_cong_Mars + Nbr_jour_cong_Fev + Nbr_jour_cong_Janv;
                    personne.Save();
                    //}
                }
        }

        public void Somme_Juill()
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Juillet);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Recape_Annuelle_Juill==?", Oid);

            XPCollection<Recapes_Juill> Recapes_Juill_Collection = new XPCollection<Recapes_Juill>(Session, CriteriaOperator.And(criteria1, criteria2));

            if (Recapes_Juill_Collection.Count != 0)
                foreach (Recapes_Juill recape in Recapes_Juill_Collection)
                {
                    Brut_Impo_Bareme_Juill += recape.Brut_Impo_Bareme;
                    IRG_Bareme_Juill += recape.IRG_Bareme;
                    Brut_Impo_Taux_Juill += recape.Brut_Impo_Taux;
                    IRG_Taux_Juill += recape.IRG_Taux;
                    Brut_Cotis_Juill += recape.Brut_Cotis;
                    SS_Juill += recape.SS;
                    Brut_Impo_Juill += recape.Brut_Impo;
                    IRG_Juill += recape.IRG;
                    NET_Juill += recape.NET;
                    PP1_Juill += recape.PP1;
                    PP2_Juill += recape.PP2;
                    PP3_Juill += recape.PP3;
                    if (recape.Categorie == CategorieCloture.Paye)
                    {
                        Nbr_jour_abs_Juill += (int)recape.Nbr_jour_abs;
                        Nbr_jour_ouv_Juill += recape.Nbr_jour_ouv;
                    }
                    if (Nbr_jour_ouv_Juill > parametres.Nbr_jour_tra)
                    {
                        Nbr_jour_ouv_Juill = parametres.Nbr_jour_tra;
                        if (recape.Recape_Annuelle_Juill != null)
                            MessageBox.Show("L'employé avec la matricule : " + recape.Recape_Annuelle_Juill.personne.Cod_personne + " a plusieurs paies de catégorie <<Paie Mensuelle>> !");
                    }
                    //if (parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuel || parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuelRecuperation)
                    //{
                    personne.Nbr_Jrs_Cong_Accor = 0;
                    //personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong +
                    //     ((Nbr_jour_ouv_Janv - Nbr_jour_abs_Janv) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Fev - Nbr_jour_abs_Fev) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Mars - Nbr_jour_abs_Mars) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Avr - Nbr_jour_abs_Avr) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Mai - Nbr_jour_abs_Mai) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Juin - Nbr_jour_abs_Juin) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Juill - Nbr_jour_abs_Juill) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                    //personne.Nbr_Jrs_Cong_Accor = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Accor);
                    if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences)
                    {
                        Nbr_jour_cong_Juill = ((Nbr_jour_ouv_Juill - Nbr_jour_abs_Juill) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                        Nbr_jour_cong_Juill = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Juill);
                    }
                    else
                        if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences15)
                        {
                            if (Nbr_jour_abs_Juill < 15)
                            {
                                Nbr_jour_cong_Juill = parametres.nbr_jour_cong_mois;
                                Nbr_jour_cong_Juill = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Juill);
                            }
                        }
                        else
                        {
                            Nbr_jour_cong_Juill = parametres.nbr_jour_cong_mois;
                            Nbr_jour_cong_Juill = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Juill);
                        }
                    personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong + Nbr_jour_cong_Juill + Nbr_jour_cong_Juin + Nbr_jour_cong_Mai
                        + Nbr_jour_cong_Avr + Nbr_jour_cong_Mars + Nbr_jour_cong_Fev + Nbr_jour_cong_Janv;
                    personne.Save();
                    //}
                }
        }

        public void Somme_Aout()
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Août);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Recape_Annuelle_Aout==?", Oid);

            XPCollection<Recapes_Aout> Recapes_Aout_Collection = new XPCollection<Recapes_Aout>(Session, CriteriaOperator.And(criteria1, criteria2));

            if (Recapes_Aout_Collection.Count != 0)
                foreach (Recapes_Aout recape in Recapes_Aout_Collection)
                {
                    Brut_Impo_Bareme_Aout += recape.Brut_Impo_Bareme;
                    IRG_Bareme_Aout += recape.IRG_Bareme;
                    Brut_Impo_Taux_Aout += recape.Brut_Impo_Taux;
                    IRG_Taux_Aout += recape.IRG_Taux;
                    Brut_Cotis_Aout += recape.Brut_Cotis;
                    SS_Aout += recape.SS;
                    Brut_Impo_Aout += recape.Brut_Impo;
                    IRG_Aout += recape.IRG;
                    NET_Aout += recape.NET;
                    PP1_Aout += recape.PP1;
                    PP2_Aout += recape.PP2;
                    PP3_Aout += recape.PP3;
                    if (recape.Categorie == CategorieCloture.Paye)
                    {
                        Nbr_jour_abs_Aout += (int)recape.Nbr_jour_abs;
                        Nbr_jour_ouv_Aout += recape.Nbr_jour_ouv;
                    }
                    if (Nbr_jour_ouv_Aout > parametres.Nbr_jour_tra)
                    {
                        Nbr_jour_ouv_Aout = parametres.Nbr_jour_tra;
                        if (recape.Recape_Annuelle_Aout != null)
                            MessageBox.Show("L'employé avec la matricule : " + recape.Recape_Annuelle_Aout.personne.Cod_personne + " a plusieurs paies de catégorie <<Paie Mensuelle>> !");
                    }
                    //if (parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuel || parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuelRecuperation)
                    //{
                    personne.Nbr_Jrs_Cong_Accor = 0;
                    //personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong +
                    //    ((Nbr_jour_ouv_Janv - Nbr_jour_abs_Janv) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Fev - Nbr_jour_abs_Fev) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Mars - Nbr_jour_abs_Mars) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Avr - Nbr_jour_abs_Avr) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Mai - Nbr_jour_abs_Mai) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Juin - Nbr_jour_abs_Juin) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Juill - Nbr_jour_abs_Juill) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Aout - Nbr_jour_abs_Aout) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                    //personne.Nbr_Jrs_Cong_Accor = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Accor);
                    if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences)
                    {
                        Nbr_jour_cong_Aout = ((Nbr_jour_ouv_Aout - Nbr_jour_abs_Aout) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                        Nbr_jour_cong_Aout = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Aout);
                    }
                    else
                        if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences15)
                        {
                            if (Nbr_jour_abs_Aout < 15)
                            {
                                Nbr_jour_cong_Aout = parametres.nbr_jour_cong_mois;
                                Nbr_jour_cong_Aout = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Aout);
                            }
                        }
                        else
                        {
                            Nbr_jour_cong_Aout = parametres.nbr_jour_cong_mois;
                            Nbr_jour_cong_Aout = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Aout);
                        }
                    personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong + Nbr_jour_cong_Aout + Nbr_jour_cong_Juill + Nbr_jour_cong_Juin 
                        + Nbr_jour_cong_Mai + Nbr_jour_cong_Avr + Nbr_jour_cong_Mars + Nbr_jour_cong_Fev + Nbr_jour_cong_Janv;
                    personne.Save();
                    //}
                }
        }

        public void Somme_Sept()
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Septembre);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Recape_Annuelle_Sept==?", Oid);

            XPCollection<Recapes_Sept> Recapes_Sept_Collection = new XPCollection<Recapes_Sept>(Session, CriteriaOperator.And(criteria1, criteria2));

            if (Recapes_Sept_Collection.Count != 0)
                foreach (Recapes_Sept recape in Recapes_Sept_Collection)
                {
                    Brut_Impo_Bareme_Sept += recape.Brut_Impo_Bareme;
                    IRG_Bareme_Sept += recape.IRG_Bareme;
                    Brut_Impo_Taux_Sept += recape.Brut_Impo_Taux;
                    IRG_Taux_Sept += recape.IRG_Taux;
                    Brut_Cotis_Sept += recape.Brut_Cotis;
                    SS_Sept += recape.SS;
                    Brut_Impo_Sept += recape.Brut_Impo;
                    IRG_Sept += recape.IRG;
                    NET_Sept += recape.NET;
                    PP1_Sept += recape.PP1;
                    PP2_Sept += recape.PP2;
                    PP3_Sept += recape.PP3;
                    if (recape.Categorie == CategorieCloture.Paye)
                    {
                        Nbr_jour_abs_Sept += (int)recape.Nbr_jour_abs;
                        Nbr_jour_ouv_Sept += recape.Nbr_jour_ouv;
                    }
                    if (Nbr_jour_ouv_Sept > parametres.Nbr_jour_tra)
                    {
                        Nbr_jour_ouv_Sept = parametres.Nbr_jour_tra;
                        if (recape.Recape_Annuelle_Sept != null)
                            MessageBox.Show("L'employé avec la matricule : " + recape.Recape_Annuelle_Sept.personne.Cod_personne + " a plusieurs paies de catégorie <<Paie Mensuelle>> !");
                    }
                    //if (parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuel || parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuelRecuperation)
                    //{
                    personne.Nbr_Jrs_Cong_Accor = 0;
                    //personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong +
                    //    ((Nbr_jour_ouv_Janv - Nbr_jour_abs_Janv) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Fev - Nbr_jour_abs_Fev) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Mars - Nbr_jour_abs_Mars) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Avr - Nbr_jour_abs_Avr) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Mai - Nbr_jour_abs_Mai) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Juin - Nbr_jour_abs_Juin) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Juill - Nbr_jour_abs_Juill) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Aout - Nbr_jour_abs_Aout) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Sept - Nbr_jour_abs_Sept) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                    //personne.Nbr_Jrs_Cong_Accor = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Accor);
                    if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences)
                    {
                        Nbr_jour_cong_Sept = ((Nbr_jour_ouv_Sept - Nbr_jour_abs_Sept) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                        Nbr_jour_cong_Sept = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Sept);
                    }
                    else
                        if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences15)
                        {
                            if (Nbr_jour_abs_Sept < 15)
                            {
                                Nbr_jour_cong_Sept = parametres.nbr_jour_cong_mois;
                                Nbr_jour_cong_Sept = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Sept);
                            }
                        }
                        else
                        {
                            Nbr_jour_cong_Sept = parametres.nbr_jour_cong_mois;
                            Nbr_jour_cong_Sept = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Sept);
                        }
                    personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong + Nbr_jour_cong_Sept + Nbr_jour_cong_Aout + Nbr_jour_cong_Juill 
                        + Nbr_jour_cong_Juin + Nbr_jour_cong_Mai + Nbr_jour_cong_Avr + Nbr_jour_cong_Mars + Nbr_jour_cong_Fev + Nbr_jour_cong_Janv;
                    personne.Save();
                    //}
                }
        }

        public void Somme_Oct()
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Octobre);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Recape_Annuelle_Oct==?", Oid);

            XPCollection<Recapes_Oct> Recapes_Oct_Collection = new XPCollection<Recapes_Oct>(Session, CriteriaOperator.And(criteria1, criteria2));

            if (Recapes_Oct_Collection.Count != 0)
                foreach (Recapes_Oct recape in Recapes_Oct_Collection)
                {
                    Brut_Impo_Bareme_Oct += recape.Brut_Impo_Bareme;
                    IRG_Bareme_Oct += recape.IRG_Bareme;
                    Brut_Impo_Taux_Oct += recape.Brut_Impo_Taux;
                    IRG_Taux_Oct += recape.IRG_Taux;
                    Brut_Cotis_Oct += recape.Brut_Cotis;
                    SS_Oct += recape.SS;
                    Brut_Impo_Oct += recape.Brut_Impo;
                    IRG_Oct += recape.IRG;
                    NET_Oct += recape.NET;
                    PP1_Oct += recape.PP1;
                    PP2_Oct += recape.PP2;
                    PP3_Oct += recape.PP3;
                    if (recape.Categorie == CategorieCloture.Paye)
                    {
                        Nbr_jour_abs_Oct += (int)recape.Nbr_jour_abs;
                        Nbr_jour_ouv_Oct += recape.Nbr_jour_ouv;
                    }
                    if (Nbr_jour_ouv_Oct > parametres.Nbr_jour_tra)
                    {
                        Nbr_jour_ouv_Oct = parametres.Nbr_jour_tra;
                        if (recape.Recape_Annuelle_Oct != null)
                            MessageBox.Show("L'employé avec la matricule : " + recape.Recape_Annuelle_Oct.personne.Cod_personne + " a plusieurs paies de catégorie <<Paie Mensuelle>> !");
                    }
                    //if (parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuel || parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuelRecuperation)
                    //{
                    personne.Nbr_Jrs_Cong_Accor = 0;
                    if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences)
                    {
                        Nbr_jour_cong_Oct = ((Nbr_jour_ouv_Oct - Nbr_jour_abs_Oct) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                        Nbr_jour_cong_Oct = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Oct);
                    }
                    else
                        if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences15)
                        {
                            if (Nbr_jour_abs_Oct < 15)
                            {
                                Nbr_jour_cong_Oct = parametres.nbr_jour_cong_mois;
                                Nbr_jour_cong_Oct = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Oct);
                            }
                        }
                        else
                        {
                            Nbr_jour_cong_Oct = parametres.nbr_jour_cong_mois;
                            Nbr_jour_cong_Oct = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Oct);
                        }
                    personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong + Nbr_jour_cong_Oct + Nbr_jour_cong_Sept + Nbr_jour_cong_Aout 
                        + Nbr_jour_cong_Juill + Nbr_jour_cong_Juin + Nbr_jour_cong_Mai + Nbr_jour_cong_Avr + Nbr_jour_cong_Mars + Nbr_jour_cong_Fev
                        + Nbr_jour_cong_Janv;
                    //personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong +
                    //    ((Nbr_jour_ouv_Janv - Nbr_jour_abs_Janv) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Fev - Nbr_jour_abs_Fev) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Mars - Nbr_jour_abs_Mars) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Avr - Nbr_jour_abs_Avr) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Mai - Nbr_jour_abs_Mai) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Juin - Nbr_jour_abs_Juin) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Juill - Nbr_jour_abs_Juill) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Aout - Nbr_jour_abs_Aout) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Sept - Nbr_jour_abs_Sept) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Oct - Nbr_jour_abs_Oct) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                    //personne.Nbr_Jrs_Cong_Accor = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Accor);
                    personne.Save();
                    //}
                }
        }

        public void Somme_Nouv()
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Novembre);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Recape_Annuelle_Nouv==?", Oid);

            XPCollection<Recapes_Nouv> Recapes_Nouv_Collection = new XPCollection<Recapes_Nouv>(Session, CriteriaOperator.And(criteria1, criteria2));

            if (Recapes_Nouv_Collection.Count != 0)
                foreach (Recapes_Nouv recape in Recapes_Nouv_Collection)
                {
                    Brut_Impo_Bareme_Nouv += recape.Brut_Impo_Bareme;
                    IRG_Bareme_Nouv += recape.IRG_Bareme;
                    Brut_Impo_Taux_Nouv += recape.Brut_Impo_Taux;
                    IRG_Taux_Nouv += recape.IRG_Taux;
                    Brut_Cotis_Nouv += recape.Brut_Cotis;
                    SS_Nouv += recape.SS;
                    Brut_Impo_Nouv += recape.Brut_Impo;
                    IRG_Nouv += recape.IRG;
                    NET_Nouv += recape.NET;
                    PP1_Nouv += recape.PP1;
                    PP2_Nouv += recape.PP2;
                    PP3_Nouv += recape.PP3;
                    if (recape.Categorie == CategorieCloture.Paye)
                    {
                        Nbr_jour_abs_Nouv += (int)recape.Nbr_jour_abs;
                        Nbr_jour_ouv_Nouv += recape.Nbr_jour_ouv;
                    }
                    if (Nbr_jour_ouv_Nouv > parametres.Nbr_jour_tra)
                    {
                        Nbr_jour_ouv_Nouv = parametres.Nbr_jour_tra;
                        if (recape.Recape_Annuelle_Nouv != null)
                            MessageBox.Show("L'employé avec la matricule : " + recape.Recape_Annuelle_Nouv.personne.Cod_personne + " a plusieurs paies de catégorie <<Paie Mensuelle>> !");
                    }
                    //if (parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuel || parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuelRecuperation)
                    //{
                    personne.Nbr_Jrs_Cong_Accor = 0;
                    //personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong +
                    //    ((Nbr_jour_ouv_Janv - Nbr_jour_abs_Janv) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Fev - Nbr_jour_abs_Fev) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Mars - Nbr_jour_abs_Mars) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Avr - Nbr_jour_abs_Avr) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Mai - Nbr_jour_abs_Mai) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Juin - Nbr_jour_abs_Juin) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Juill - Nbr_jour_abs_Juill) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Aout - Nbr_jour_abs_Aout) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Sept - Nbr_jour_abs_Sept) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Oct - Nbr_jour_abs_Oct) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Nouv - Nbr_jour_abs_Nouv) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                    //personne.Nbr_Jrs_Cong_Accor = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Accor);
                    if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences)
                    {
                        Nbr_jour_cong_Nouv = ((Nbr_jour_ouv_Nouv - Nbr_jour_abs_Nouv) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                        Nbr_jour_cong_Nouv = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Nouv);
                    }
                    else
                        if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences15)
                        {
                            if (Nbr_jour_abs_Nouv < 15)
                            {
                                Nbr_jour_cong_Nouv = parametres.nbr_jour_cong_mois;
                                Nbr_jour_cong_Nouv = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Nouv);
                            }
                        }
                        else
                        {
                            Nbr_jour_cong_Nouv = parametres.nbr_jour_cong_mois;
                            Nbr_jour_cong_Nouv = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Nouv);
                        }
                    personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong + Nbr_jour_cong_Nouv + Nbr_jour_cong_Oct + Nbr_jour_cong_Sept 
                        + Nbr_jour_cong_Aout + Nbr_jour_cong_Juill + Nbr_jour_cong_Juin + Nbr_jour_cong_Mai + Nbr_jour_cong_Avr + Nbr_jour_cong_Mars 
                        + Nbr_jour_cong_Fev + Nbr_jour_cong_Janv;
                    personne.Save();
                    //}
                }
        }

        public void Somme_Dec()
        {
            CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", MoisdelAnnee.Décembre);
            CriteriaOperator criteria2 = CriteriaOperator.Parse("Recape_Annuelle_Dec==?", Oid);

            XPCollection<Recapes_Dec> Recapes_Dec_Collection = new XPCollection<Recapes_Dec>(Session, CriteriaOperator.And(criteria1, criteria2));

            if (Recapes_Dec_Collection.Count != 0)
                foreach (Recapes_Dec recape in Recapes_Dec_Collection)
                {
                    Brut_Impo_Bareme_Dec += recape.Brut_Impo_Bareme;
                    IRG_Bareme_Dec += recape.IRG_Bareme;
                    Brut_Impo_Taux_Dec += recape.Brut_Impo_Taux;
                    IRG_Taux_Dec += recape.IRG_Taux;
                    Brut_Cotis_Dec += recape.Brut_Cotis;
                    SS_Dec += recape.SS;
                    Brut_Impo_Dec += recape.Brut_Impo;
                    IRG_Dec += recape.IRG;
                    NET_Dec += recape.NET;
                    PP1_Dec += recape.PP1;
                    PP2_Dec += recape.PP2;
                    PP3_Dec += recape.PP3;
                    if (recape.Categorie == CategorieCloture.Paye)
                    {
                        Nbr_jour_abs_Dec += (int)recape.Nbr_jour_abs;
                        Nbr_jour_ouv_Dec += recape.Nbr_jour_ouv;
                    }
                    if (Nbr_jour_ouv_Dec > parametres.Nbr_jour_tra)
                    {
                        Nbr_jour_ouv_Dec = parametres.Nbr_jour_tra;
                        if (recape.Recape_Annuelle_Dec != null)
                            MessageBox.Show("L'employé avec la matricule : " + recape.Recape_Annuelle_Dec.personne.Cod_personne + " a plusieurs paies de catégorie <<Paie Mensuelle>> !");
                    }
                    //if (parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuel || parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuelRecuperation)
                    //{
                    personne.Nbr_Jrs_Cong_Accor = 0;
                    //personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong +
                    //    ((Nbr_jour_ouv_Janv - Nbr_jour_abs_Janv) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Fev - Nbr_jour_abs_Fev) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Mars - Nbr_jour_abs_Mars) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Avr - Nbr_jour_abs_Avr) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Mai - Nbr_jour_abs_Mai) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Juin - Nbr_jour_abs_Juin) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Juill - Nbr_jour_abs_Juill) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Aout - Nbr_jour_abs_Aout) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Sept - Nbr_jour_abs_Sept) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Oct - Nbr_jour_abs_Oct) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Nouv - Nbr_jour_abs_Nouv) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra +
                    //    ((Nbr_jour_ouv_Dec - Nbr_jour_abs_Dec) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                    //personne.Nbr_Jrs_Cong_Accor = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Accor);
                    if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences)
                    {
                        Nbr_jour_cong_Dec = ((Nbr_jour_ouv_Dec - Nbr_jour_abs_Dec) * parametres.nbr_jour_cong_mois) / parametres.Nbr_jour_tra;
                        Nbr_jour_cong_Dec = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Dec);
                    }
                    else
                        if (parametres.JoursAbsJrsCong == ModeCalculNbrJrsConge.AvecAbsences15)
                        {
                            if (Nbr_jour_abs_Dec < 15)
                            {
                                Nbr_jour_cong_Dec = parametres.nbr_jour_cong_mois;
                                Nbr_jour_cong_Dec = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Dec);
                            }
                        }
                        else
                        {
                            Nbr_jour_cong_Dec = parametres.nbr_jour_cong_mois;
                            Nbr_jour_cong_Dec = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Nbr_jour_cong_Dec);
                        }
                    personne.Nbr_Jrs_Cong_Accor = personne.Relecat_Nbr_Jrs_Cong + Nbr_jour_cong_Dec + Nbr_jour_cong_Nouv + Nbr_jour_cong_Oct 
                        + Nbr_jour_cong_Sept + Nbr_jour_cong_Aout + Nbr_jour_cong_Juill + Nbr_jour_cong_Juin + Nbr_jour_cong_Mai + Nbr_jour_cong_Avr 
                        + Nbr_jour_cong_Mars + Nbr_jour_cong_Fev + Nbr_jour_cong_Janv;
                    personne.Save();
                    //}
                }
        }

        public void Somme_G()
        {

            Brut_Impo_Bareme = Brut_Impo_Bareme_Janv + Brut_Impo_Bareme_Fev + Brut_Impo_Bareme_Mars
                + Brut_Impo_Bareme_Avr + Brut_Impo_Bareme_Mai + Brut_Impo_Bareme_Juin + Brut_Impo_Bareme_Juill
                + Brut_Impo_Bareme_Aout + Brut_Impo_Bareme_Sept + Brut_Impo_Bareme_Oct + Brut_Impo_Bareme_Nouv
                + Brut_Impo_Bareme_Dec;

            IRG_Bareme = IRG_Bareme_Janv + IRG_Bareme_Fev + IRG_Bareme_Mars
                + IRG_Bareme_Avr + IRG_Bareme_Mai + IRG_Bareme_Juin + IRG_Bareme_Juill
                + IRG_Bareme_Aout + IRG_Bareme_Sept + IRG_Bareme_Oct + IRG_Bareme_Nouv
                + IRG_Bareme_Dec;

            Brut_Impo_Taux = Brut_Impo_Taux_Janv + Brut_Impo_Taux_Fev + Brut_Impo_Taux_Mars
                + Brut_Impo_Taux_Avr + Brut_Impo_Taux_Mai + Brut_Impo_Taux_Juin + Brut_Impo_Taux_Juill
                + Brut_Impo_Taux_Aout + Brut_Impo_Taux_Sept + Brut_Impo_Taux_Oct + Brut_Impo_Taux_Nouv
                + Brut_Impo_Taux_Dec;

            IRG_Taux = IRG_Taux_Janv + IRG_Taux_Fev + IRG_Taux_Mars
                + IRG_Taux_Avr + IRG_Taux_Mai + IRG_Taux_Juin + IRG_Taux_Juill
                + IRG_Taux_Aout + IRG_Taux_Sept + IRG_Taux_Oct + IRG_Taux_Nouv
                + IRG_Taux_Dec;

            Brut_Cotis = Brut_Cotis_Janv + Brut_Cotis_Fev + Brut_Cotis_Mars
                + Brut_Cotis_Avr + Brut_Cotis_Mai + Brut_Cotis_Juin + Brut_Cotis_Juill
                + Brut_Cotis_Aout + Brut_Cotis_Sept + Brut_Cotis_Oct + Brut_Cotis_Nouv
                + Brut_Cotis_Dec;

            SS = SS_Janv + SS_Fev + SS_Mars
                + SS_Avr + SS_Mai + SS_Juin + SS_Juill
                + SS_Aout + SS_Sept + SS_Oct + SS_Nouv
                + SS_Dec;

            Brut_Impo = Brut_Impo_Janv + Brut_Impo_Fev + Brut_Impo_Mars
                + Brut_Impo_Avr + Brut_Impo_Mai + Brut_Impo_Juin + Brut_Impo_Juill
                + Brut_Impo_Aout + Brut_Impo_Sept + Brut_Impo_Oct + Brut_Impo_Nouv
                + Brut_Impo_Dec;

            IRG = IRG_Janv + IRG_Fev + IRG_Mars
                + IRG_Avr + IRG_Mai + IRG_Juin + IRG_Juill
                + IRG_Aout + IRG_Sept + IRG_Oct + IRG_Nouv
                + IRG_Dec;

            NET = NET_Janv + NET_Fev + NET_Mars
                + NET_Avr + NET_Mai + NET_Juin + NET_Juill
                + NET_Aout + NET_Sept + NET_Oct + NET_Nouv
                + NET_Dec;

            PP1 = PP1_Janv + PP1_Fev + PP1_Mars
                + PP1_Avr + PP1_Mai + PP1_Juin + PP1_Juill
                + PP1_Aout + PP1_Sept + PP1_Oct + PP1_Nouv
                + PP1_Dec;

            PP2 = PP2_Janv + PP2_Fev + PP2_Mars
                + PP2_Avr + PP2_Mai + PP2_Juin + PP2_Juill
                + PP2_Aout + PP2_Sept + PP2_Oct + PP2_Nouv
                + PP2_Dec;

            PP3 = PP3_Janv + PP3_Fev + PP3_Mars
                + PP3_Avr + PP3_Mai + PP3_Juin + PP3_Juill
                + PP3_Aout + PP3_Sept + PP3_Oct + PP3_Nouv
                + PP3_Dec;

        }

        public void mettre_a_0_Janv()
        {
            Brut_Impo_Bareme_Janv = 0;
            IRG_Bareme_Janv = 0;
            Brut_Impo_Taux_Janv = 0;
            IRG_Taux_Janv = 0;
            Brut_Cotis_Janv = 0;
            SS_Janv = 0;
            Brut_Impo_Janv = 0;
            IRG_Janv = 0;
            NET_Janv = 0;
            PP1_Janv = 0;
            PP2_Janv = 0;
            PP3_Janv = 0;
            Nbr_jour_ouv_Janv = 0;
            Nbr_jour_abs_Janv = 0;
            Jour_Abs_Janv = 0;


            /***********************************************************************************/
        }

        public void mettre_a_0_Fev()
        {
            Brut_Impo_Bareme_Fev = 0;
            IRG_Bareme_Fev = 0;
            Brut_Impo_Taux_Fev = 0;
            IRG_Taux_Fev = 0;
            Brut_Cotis_Fev = 0;
            SS_Fev = 0;
            Brut_Impo_Fev = 0;
            IRG_Fev = 0;
            NET_Fev = 0;
            PP1_Fev = 0;
            PP2_Fev = 0;
            PP3_Fev = 0;
            Nbr_jour_abs_Fev = 0;
            Jour_Abs_Fev = 0;
            Nbr_jour_ouv_Fev = 0;

            /***********************************************************************************/
        }

        public void mettre_a_0_Mars()
        {
            Brut_Impo_Bareme_Mars = 0;
            IRG_Bareme_Mars = 0;
            Brut_Impo_Taux_Mars = 0;
            IRG_Taux_Mars = 0;
            Brut_Cotis_Mars = 0;
            SS_Mars = 0;
            Brut_Impo_Mars = 0;
            IRG_Mars = 0;
            NET_Mars = 0;
            Nbr_jour_abs_Mars = 0;
            Jour_Abs_Mars = 0;
            Nbr_jour_ouv_Mars = 0;

            /***********************************************************************************/
        }

        public void mettre_a_0_Avr()
        {
            Brut_Impo_Bareme_Avr = 0;
            IRG_Bareme_Avr = 0;
            Brut_Impo_Taux_Avr = 0;
            IRG_Taux_Avr = 0;
            Brut_Cotis_Avr = 0;
            SS_Avr = 0;
            Brut_Impo_Avr = 0;
            IRG_Avr = 0;
            NET_Avr = 0;
            Nbr_jour_abs_Avr = 0;
            Jour_Abs_Avr = 0;
            Nbr_jour_ouv_Avr = 0;

            /***********************************************************************************/
        }

        public void mettre_a_0_Mai()
        {
            Brut_Impo_Bareme_Mai = 0;
            IRG_Bareme_Mai = 0;
            Brut_Impo_Taux_Mai = 0;
            IRG_Taux_Mai = 0;
            Brut_Cotis_Mai = 0;
            SS_Mai = 0;
            Brut_Impo_Mai = 0;
            IRG_Mai = 0;
            NET_Mai = 0;
            PP1_Mai = 0;
            PP2_Mai = 0;
            PP3_Mai = 0;
            Nbr_jour_ouv_Mai = 0;
            Nbr_jour_abs_Mai = 0;
            Jour_Abs_Mai = 0;

            /***********************************************************************************/
        }

        public void mettre_a_0_Juin()
        {
            Brut_Impo_Bareme_Juin = 0;
            IRG_Bareme_Juin = 0;
            Brut_Impo_Taux_Juin = 0;
            IRG_Taux_Juin = 0;
            Brut_Cotis_Juin = 0;
            SS_Juin = 0;
            Brut_Impo_Juin = 0;
            IRG_Juin = 0;
            NET_Juin = 0;
            PP1_Juin = 0;
            PP2_Juin = 0;
            PP3_Juin = 0;
            Nbr_jour_ouv_Juin = 0;
            Nbr_jour_abs_Juin = 0;
            Jour_Abs_Juin = 0;

            /***********************************************************************************/
        }

        public void mettre_a_0_Juill()
        {
            Brut_Impo_Bareme_Juill = 0;
            IRG_Bareme_Juill = 0;
            Brut_Impo_Taux_Juill = 0;
            IRG_Taux_Juill = 0;
            Brut_Cotis_Juill = 0;
            SS_Juill = 0;
            Brut_Impo_Juill = 0;
            IRG_Juill = 0;
            NET_Juill = 0;
            PP1_Juill = 0;
            PP2_Juill = 0;
            PP3_Juill = 0;
            Nbr_jour_ouv_Juill = 0;
            Nbr_jour_abs_Juill = 0;
            Jour_Abs_Juill = 0;

            /***********************************************************************************/
        }

        public void mettre_a_0_Aout()
        {
            Brut_Impo_Bareme_Aout = 0;
            IRG_Bareme_Aout = 0;
            Brut_Impo_Taux_Aout = 0;
            IRG_Taux_Aout = 0;
            Brut_Cotis_Aout = 0;
            SS_Aout = 0;
            Brut_Impo_Aout = 0;
            IRG_Aout = 0;
            NET_Aout = 0;
            PP1_Aout = 0;
            PP2_Aout = 0;
            PP3_Aout = 0;
            Nbr_jour_ouv_Aout = 0;
            Nbr_jour_abs_Aout = 0;
            Jour_Abs_Aout = 0;

            /***********************************************************************************/
        }

        public void mettre_a_0_Sept()
        {
            Brut_Impo_Bareme_Sept = 0;
            IRG_Bareme_Sept = 0;
            Brut_Impo_Taux_Sept = 0;
            IRG_Taux_Sept = 0;
            Brut_Cotis_Sept = 0;
            SS_Sept = 0;
            Brut_Impo_Sept = 0;
            IRG_Sept = 0;
            NET_Sept = 0;
            PP1_Sept = 0;
            PP2_Sept = 0;
            PP3_Sept = 0;
            Nbr_jour_ouv_Sept = 0;
            Nbr_jour_abs_Sept = 0;
            Jour_Abs_Sept = 0;

            /***********************************************************************************/
        }

        public void mettre_a_0_Oct()
        {
            Brut_Impo_Bareme_Oct = 0;
            IRG_Bareme_Oct = 0;
            Brut_Impo_Taux_Oct = 0;
            IRG_Taux_Oct = 0;
            Brut_Cotis_Oct = 0;
            SS_Oct = 0;
            Brut_Impo_Oct = 0;
            IRG_Oct = 0;
            NET_Oct = 0;
            PP1_Oct = 0;
            PP2_Oct = 0;
            PP3_Oct = 0;
            Nbr_jour_ouv_Oct = 0;
            Nbr_jour_abs_Oct = 0;
            Jour_Abs_Oct = 0;

            /***********************************************************************************/
        }
        
        public void mettre_a_0_Nouv()
        {
            Brut_Impo_Bareme_Nouv = 0;
            IRG_Bareme_Nouv = 0;
            Brut_Impo_Taux_Nouv = 0;
            IRG_Taux_Nouv = 0;
            Brut_Cotis_Nouv = 0;
            SS_Nouv = 0;
            Brut_Impo_Nouv = 0;
            IRG_Nouv = 0;
            NET_Nouv = 0;
            PP1_Nouv = 0;
            PP2_Nouv = 0;
            PP3_Nouv = 0;
            Nbr_jour_ouv_Nouv = 0;
            Nbr_jour_abs_Nouv = 0;
            Jour_Abs_Nouv = 0;

            /***********************************************************************************/
        }

        public void mettre_a_0_Dec()
        {
            Brut_Impo_Bareme_Dec = 0;
            IRG_Bareme_Dec = 0;
            Brut_Impo_Taux_Dec = 0;
            IRG_Taux_Dec = 0;
            Brut_Cotis_Dec = 0;
            SS_Dec = 0;
            Brut_Impo_Dec = 0;
            IRG_Dec = 0;
            NET_Dec = 0;
            PP1_Dec = 0;
            PP2_Dec = 0;
            PP3_Dec = 0;
            Nbr_jour_ouv_Dec = 0;
            Nbr_jour_abs_Dec = 0;
            Jour_Abs_Dec = 0;

            /***********************************************************************************/
        }

        public void mettre_a_0_G()
        {
            Brut_Impo_Bareme = 0;
            IRG_Bareme = 0;
            Brut_Impo_Taux = 0;
            IRG_Taux = 0;
            Brut_Cotis = 0;
            SS = 0;
            Brut_Impo = 0;
            IRG = 0;
            NET = 0;
            PP1 = 0;
            PP2 = 0;
            PP3 = 0;
        }

        protected override void OnSaving()
        {
            base.OnSaving();

            mettre_a_0_Janv();
            Somme_Janv();

            mettre_a_0_Fev();
            Somme_Fev();

            mettre_a_0_Mars();
            Somme_Mars();

            mettre_a_0_Avr();
            Somme_Avr();

            mettre_a_0_Mai();
            Somme_Mai();

            mettre_a_0_Juin();
            Somme_Juin();

            mettre_a_0_Juill();
            Somme_Juill();

            mettre_a_0_Aout();
            Somme_Aout();

            mettre_a_0_Sept();
            Somme_Sept();

            mettre_a_0_Oct();
            Somme_Oct();

            mettre_a_0_Nouv();
            Somme_Nouv();

            mettre_a_0_Dec();
            Somme_Dec();

            mettre_a_0_G();
            Somme_G();
        }

        protected override void OnDeleting()
        {
            base.OnDeleting();

            XPCollection<Recapes_Janv> Recapes_Janv_Delete = new XPCollection<Recapes_Janv>(Session, CriteriaOperator.Parse("Recape_Annuelle_Janv=?", Oid.ToString()));
            Session.Delete(Recapes_Janv_Delete);
            Session.Save(Recapes_Janv_Delete);

            XPCollection<Recapes_Fev> Recapes_Fev_Delete = new XPCollection<Recapes_Fev>(Session, CriteriaOperator.Parse("Recape_Annuelle_Fev=?", Oid.ToString()));
            Session.Delete(Recapes_Fev_Delete);
            Session.Save(Recapes_Fev_Delete);

            XPCollection<Recapes_Mars> Recapes_Mars_Delete = new XPCollection<Recapes_Mars>(Session, CriteriaOperator.Parse("Recape_Annuelle_Mars=?", Oid.ToString()));
            Session.Delete(Recapes_Mars_Delete);
            Session.Save(Recapes_Mars_Delete);

            XPCollection<Recapes_Avr> Recapes_Avr_Delete = new XPCollection<Recapes_Avr>(Session, CriteriaOperator.Parse("Recape_Annuelle_Avr=?", Oid.ToString()));
            Session.Delete(Recapes_Avr_Delete);
            Session.Save(Recapes_Avr_Delete);

            XPCollection<Recapes_Mai> Recapes_Mai_Delete = new XPCollection<Recapes_Mai>(Session, CriteriaOperator.Parse("Recape_Annuelle_Mai=?", Oid.ToString()));
            Session.Delete(Recapes_Mai_Delete);
            Session.Save(Recapes_Mai_Delete);

            XPCollection<Recapes_Juin> Recapes_Juin_Delete = new XPCollection<Recapes_Juin>(Session, CriteriaOperator.Parse("Recape_Annuelle_Juin=?", Oid.ToString()));
            Session.Delete(Recapes_Juin_Delete);
            Session.Save(Recapes_Juin_Delete);

            XPCollection<Recapes_Juill> Recapes_Juill_Delete = new XPCollection<Recapes_Juill>(Session, CriteriaOperator.Parse("Recape_Annuelle_Juill=?", Oid.ToString()));
            Session.Delete(Recapes_Juill_Delete);
            Session.Save(Recapes_Juill_Delete);

            XPCollection<Recapes_Aout> Recapes_Aout_Delete = new XPCollection<Recapes_Aout>(Session, CriteriaOperator.Parse("Recape_Annuelle_Aout=?", Oid.ToString()));
            Session.Delete(Recapes_Aout_Delete);
            Session.Save(Recapes_Aout_Delete);

            XPCollection<Recapes_Sept> Recapes_Sept_Delete = new XPCollection<Recapes_Sept>(Session, CriteriaOperator.Parse("Recape_Annuelle_Sept=?", Oid.ToString()));
            Session.Delete(Recapes_Sept_Delete);
            Session.Save(Recapes_Sept_Delete);

            XPCollection<Recapes_Oct> Recapes_Oct_Delete = new XPCollection<Recapes_Oct>(Session, CriteriaOperator.Parse("Recape_Annuelle_Oct=?", Oid.ToString()));
            Session.Delete(Recapes_Oct_Delete);
            Session.Save(Recapes_Oct_Delete);

            XPCollection<Recapes_Nouv> Recapes_Nouv_Delete = new XPCollection<Recapes_Nouv>(Session, CriteriaOperator.Parse("Recape_Annuelle_Nouv=?", Oid.ToString()));
            Session.Delete(Recapes_Nouv_Delete);
            Session.Save(Recapes_Nouv_Delete);

            XPCollection<Recapes_Dec> Recapes_Dec_Delete = new XPCollection<Recapes_Dec>(Session, CriteriaOperator.Parse("Recape_Annuelle_Dec=?", Oid.ToString()));
            Session.Delete(Recapes_Dec_Delete);
            Session.Save(Recapes_Dec_Delete);

        }

    }
}