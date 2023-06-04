using System;
 
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.Metadata;
using System.Windows.Forms; 
using DevExpress.ExpressApp; 
using MaPayeAdmin;
using DevExpress.ExpressApp.DC;
using System.Data.SQLite;
using System.Data.SqlClient; 

namespace MaPaye.Module
{ 
    public enum MoisdelAnnee
    {
        Janvier = 1,
        Février = 2,
        Mars = 3,
        Avril = 4,
        Mai = 5,
        Juin = 6,
        Juillet = 7,
        Août = 8,
        Septembre = 9,
        Octobre = 10,
        Novembre = 11,
        Décembre = 12,
        [XafDisplayName("Treizième Mois")]TreizièmeMois = 13,
        [XafDisplayName("Quatorzième Mois")]QuatorzièmeMois = 14,
        [XafDisplayName("Quinzième Mois")]QuinzièmeMois = 15
    }

    public enum CategoriePaye { [XafDisplayName("Paye Mensuel")]Paye_Mensuel, Congé,  [XafDisplayName("Solde Tout Compte")] Solde_tout_Compte, Rappel }
    [DefaultClassOptions, ImageName("BO_SaleItem")]
    public class Paye : BaseObject
    {
        protected override void OnSaved()
        {
            //base.OnSaved();

            //CalculerPaye();
            //Save();

        }

        public void CalculerPaye()
        {
            parametres = parametre.GetInstance(Session);

            if (Bloque_Paye == true)
            {
                Remise_A_0();
                Remise_A_0_Indem_Paye();
            }
            else
            {
                Remise_A_0();

                if (Calcul_Absence_Auto == true)
                    CalculNbrJrsAbs();
                Save();

                CalculerSDB();
                CalculerRappelSDB();
                CalculerNbrHS();

                CalculerIEP();
                Calcul_Allocation();
                Calculer_Indem_Conge();
                Calculer_Indem_Conge_Recup();
                Calculer_Indem_STC();

                Session.CommitTransaction();
                CALCUL_SU();

                if (Note_Perso_Pri > 25)
                    Note_Perso_Pri = 25;

                Calculer_PMG();
                Calculer_ShiftNuit();

                AffectationsLignesColonnesIndem();
                CalculTotaux();

                CalculerSS();
                CalculerBrutImpo();
                CalculerMutuelle();
                //CalculerIrgCongeRecup();
                CalculerIrgBareme();
                CalculerIrgTaux();
                CalculerIrg();
                EvaluateBase();

                if (Mois != MoisdelAnnee.TreizièmeMois && Mois != MoisdelAnnee.QuatorzièmeMois && Mois != MoisdelAnnee.QuinzièmeMois)
                    CalculPret();

                AffectationsLignesColonnes();
                CalculRetenus();
                AffectationsLignesColonnes();
                CalculerNet();
                AffectationsLignesColonnes();
            }
            Save();
            Session.CommitTransaction();
        }

        [DevExpress.Xpo.Aggregated, Association("Paye-paye_indems", typeof(paye_indem))]
        public XPCollection paye_indems
        {
            get { return GetCollection("paye_indems"); }
        }

        private string fCod_paye;
        [Size(32)]
        public string Cod_paye
        {
            get { return fCod_paye; }
            set { SetPropertyValue<string>("Cod_paye", ref fCod_paye, value); }
        }

        private Personne fpersonne;
        public Personne personne
        {
            get { return fpersonne; }
            set { SetPropertyValue<Personne>("personne", ref fpersonne, value); }
        }

        private string fCod_personne;
        [Size(30)]
        public string Cod_personne
        {
            get
            {
                if (personne != null)
                    fCod_personne = personne.Cod_personne;
                return fCod_personne;
            }
            //set { SetPropertyValue<string>("Cod_personne", ref fCod_personne, value); }
        }

        private MoisdelAnnee fMois;
        [Size(2)]
        public MoisdelAnnee Mois
        {
            get { return fMois; }
            set { SetPropertyValue<MoisdelAnnee>("Mois", ref fMois, value); }
        }

        private int fAnnee;
        public int Annee
        {
            get { return fAnnee; }
            set { SetPropertyValue<int>("Annee", ref fAnnee, value); }
        }

        private int fNbr_enf_P10;
        public int Nbr_enf_p10
        {
            get { return fNbr_enf_P10; }
            set { SetPropertyValue<int>("Nbr_enf_P10", ref fNbr_enf_P10, value); }
        }

        private int fNbr_enf_M10;
        public int Nbr_enf_M10
        {
            get { return fNbr_enf_M10; }
            set { SetPropertyValue<int>("Nbr_enf_M10", ref fNbr_enf_M10, value); }
        }

        private int fNbr_enf;
        public int Nbr_enf
        {
            get
            {
                //fNbr_enf = fNbr_enf_M10 + fNbr_enf_P10;
                return fNbr_enf;
            }
            set { SetPropertyValue<int>("Nbr_enf", ref fNbr_enf, value); }
        }

        private int fNbr_enf_Scol;
        public int Nbr_enf_Scol
        {
            get
            { return fNbr_enf_Scol; }
            set { SetPropertyValue<int>("Nbr_enf_Scol", ref fNbr_enf_Scol, value); }
        }

        private int fNbr_jour_abs_Sort;
        public int Nbr_jour_abs_Sort
        {
            get { return fNbr_jour_abs_Sort; }
            set { SetPropertyValue<int>("Nbr_jour_abs_Sort", ref fNbr_jour_abs_Sort, value); }
        }

        //private bool fCalcul_Absence_Auto;
        //public bool Calcul_Absence_Auto
        //{
        //    get { return GetDelayedPropertyValue<bool>("Calcul_Absence_Auto"); }
        //    set { SetDelayedPropertyValue<bool>("Calcul_Absence_Auto", ref fCalcul_Absence_Auto, value); }
        //}

        private bool fCalcul_Absence_Auto;
        public bool Calcul_Absence_Auto
        {
            get { return fCalcul_Absence_Auto; }
            set { SetPropertyValue<bool>("Calcul_Absence_Auto", ref fCalcul_Absence_Auto, value); }
        }
        private int fNbr_jour_abs_Entr;
        public int Nbr_jour_abs_Entr
        {
            get { return fNbr_jour_abs_Entr; }
            set { SetPropertyValue<int>("Nbr_jour_abs_Entr", ref fNbr_jour_abs_Entr, value); }
        }

        //private int fNbr_abs;
        //[ImmediatePostData]
        //public int Nbr_abs
        //{
        //    get { return fNbr_abs; }
        //    set { SetPropertyValue<int>("Nbr_abs", ref fNbr_abs, value); }
        //}

        private int fNbr_jour_abs;
        [ImmediatePostData]
        public int Nbr_jour_abs
        {
            get
            {
                fNbr_jour_abs = Nbr_jour_abs_autre + Nbr_jour_abs_maladie + Nbr_jour_abs_mise_a_pieds + Nbr_jour_abs_Entr + Nbr_jour_abs_Sort;
                return fNbr_jour_abs;
            }
            //set { SetPropertyValue<int>("Nbr_jour_abs", ref fNbr_jour_abs, value); }
        }

        private double fJour_Abs;
        public double Jour_Abs
        {
            get
            {
                double nbr_heur = (Nbr_heure_abs / Nbr_heure_tra);
                fJour_Abs = Nbr_jour_abs + nbr_heur;
                return fJour_Abs;
            }
            set { SetPropertyValue<double>("Jour_Abs", ref fJour_Abs, value); }
        }

        private double fJour_Trs;
        public double Jour_Trs
        {
            get
            {
                return fJour_Trs;
            }
            set { SetPropertyValue<double>("Jour_Trs", ref fJour_Trs, value); }
        }

        private double fJour_Ppn;
        public double Jour_Ppn
        {
            get
            {
                return fJour_Ppn;
            }
            set { SetPropertyValue<double>("Jour_Ppn", ref fJour_Ppn, value); }
        }

        private int fNbr_jour_abs_maladie;
        [ImmediatePostData]
        public int Nbr_jour_abs_maladie
        {
            get { return fNbr_jour_abs_maladie; }
            set { SetPropertyValue<int>("Nbr_jour_abs_maladie", ref fNbr_jour_abs_maladie, value); }
        }


        private int fNbr_jour_abs_mise_a_pieds;
        [ImmediatePostData]
        public int Nbr_jour_abs_mise_a_pieds
        {
            get { return fNbr_jour_abs_mise_a_pieds; }
            set { SetPropertyValue<int>("Nbr_jour_abs_mise_a_pieds", ref fNbr_jour_abs_mise_a_pieds, value); }
        }


        private int fNbr_jour_abs_autre;
        [ImmediatePostData]
        public int Nbr_jour_abs_autre
        {
            get { return fNbr_jour_abs_autre; }
            set { SetPropertyValue<int>("Nbr_jour_abs_autre", ref fNbr_jour_abs_autre, value); }
        }

        private int fNbr_jour_abs_prime;
        [ImmediatePostData]
        public int Nbr_jour_abs_prime
        {
            get { return fNbr_jour_abs_prime; }
            set { SetPropertyValue<int>("Nbr_jour_abs_prime", ref fNbr_jour_abs_prime, value); }
        }

        private double fNbr_heure_abs;
        public double Nbr_heure_abs
        {
            get { return fNbr_heure_abs; }
            set { SetPropertyValue<double>("Nbr_heure_abs", ref fNbr_heure_abs, value); }
        }

        //private int fNbr_jour_ouv;
        //public int Nbr_jour_ouv
        //{
        //    get { return fNbr_jour_ouv; }
        //    set { SetPropertyValue<int>("Nbr_jour_ouv", ref fNbr_jour_ouv, value); }
        //}

        private double fNbr_heure_ouv;
        public double Nbr_heure_ouv
        {
            get { return fNbr_heure_ouv; }
            set { SetPropertyValue<double>("Nbr_heure_ouv", ref fNbr_heure_ouv, value); }
        }

        private int fNbr_jour_tra; //30
        public int Nbr_jour_tra
        {
            get { return fNbr_jour_tra; }
            set { SetPropertyValue<int>("Nbr_jour_tra", ref fNbr_jour_tra, value); }
        }

        private double fNbr_Jour_Tra_Prime; //22
        public double Nbr_Jour_Tra_Prime
        {
            get { return fNbr_Jour_Tra_Prime; }
            set { SetPropertyValue<double>("Nbr_Jour_Tra_Prime", ref fNbr_Jour_Tra_Prime, value); }
        }

        private double fNbr_heure_tra;
        public double Nbr_heure_tra
        {
            get { return fNbr_heure_tra; }
            set { SetPropertyValue<double>("Nbr_heure_tra", ref fNbr_heure_tra, value); }
        }

        //private AppliquerIRG fIrg_code;
        //public AppliquerIRG Irg_code
        //{
        //    get { return fIrg_code; }
        //    set { SetPropertyValue<AppliquerIRG>("Irg_code", ref fIrg_code, value); }
        //}

        private bool fSoumis_à_l_IRG;
        [ImmediatePostData]
        public bool Soumis_à_l_IRG
        {
            get { return fSoumis_à_l_IRG; }
            set { SetPropertyValue<bool>("Soumis_à_l_IRG", ref fSoumis_à_l_IRG, value); }
        }

        private bool fSoumis_à_la_Sécurité_Sociale;
        [ImmediatePostData]
        public bool Soumis_à_la_Sécurité_Sociale
        {
            get { return fSoumis_à_la_Sécurité_Sociale; }
            set { SetPropertyValue<bool>("Soumis_à_la_Sécurité_Sociale", ref fSoumis_à_la_Sécurité_Sociale, value); }
        }

        private bool fSoumis_Cacobatph;
        [ImmediatePostData]
        public bool Soumis_Cacobatph
        {
            get { return fSoumis_Cacobatph; }
            set { SetPropertyValue<bool>("Soumis_Cacobatph", ref fSoumis_Cacobatph, value); }
        }

        private bool fIntégral_Scol;
        public bool Intégral_Scol
        {
            get { return fIntégral_Scol; }
            set { SetPropertyValue<bool>("Intégral__Scol", ref fIntégral_Scol, value); }
        }

        private bool fPartiel_Scol;
        public bool Partiel_Scol
        {
            get { return fPartiel_Scol; }
            set { SetPropertyValue<bool>("Partiel_Scol", ref fPartiel_Scol, value); }
        }

        private decimal fBRUT;
        public decimal BRUT
        {
            get { return fBRUT; }
            set
            {
                SetPropertyValue<decimal>("BRUT", ref fBRUT, value);
            }
        }

        private decimal fBRUTAbsence;
        public decimal BRUTAbsence
        {
            get { return fBRUTAbsence; }
            set
            {
                SetPropertyValue<decimal>("BRUTAbsence", ref fBRUTAbsence, value);
            }
        }

        private decimal fIRG;
        public decimal IRG
        {
            get { return fIRG; }
            set
            {
                SetPropertyValue<decimal>("IRG", ref fIRG, value);
            }
        }

        private decimal fIRGAbsence;
        public decimal IRGAbsence
        {
            get { return fIRGAbsence; }
            set
            {
                SetPropertyValue<decimal>("IRGAbsence", ref fIRGAbsence, value);
            }
        }
         
        private decimal fSS;
        public decimal SS
        {
            get { return fSS; }
            set { SetPropertyValue<decimal>("SS", ref fSS, value); }
        }

        private decimal fSSAbsence;
        public decimal SSAbsence
        {
            get { return fSSAbsence; }
            set { SetPropertyValue<decimal>("SSAbsence", ref fSSAbsence, value); }
        }

        private decimal fSs_bareme;
        public decimal Ss_bareme
        {
            get { return fSs_bareme; }
            set { SetPropertyValue<decimal>("Ss_bareme", ref fSs_bareme, value); }
        }

        private decimal fSS_Bareme_Abs;
        public decimal SS_Bareme_Abs
        {
            get { return fSS_Bareme_Abs; }
            set { SetPropertyValue<decimal>("SS_Bareme_Abs", ref fSS_Bareme_Abs, value); }
        }

        private decimal fSs_Non_Impo;
        public decimal Ss_Non_Impo
        {
            get { return fSs_Non_Impo; }
            set { SetPropertyValue<decimal>("Ss_Non_Impo", ref fSs_Non_Impo, value); }
        }

        private decimal fSS_Non_Impo_Abs;
        public decimal SS_Non_Impo_Abs
        {
            get { return fSS_Non_Impo_Abs; }
            set { SetPropertyValue<decimal>("SS_Non_Impo_Abs", ref fSS_Non_Impo_Abs, value); }
        }

        private decimal fSS_Taux;
        public decimal SS_Taux
        {
            get { return fSS_Taux; }
            set { SetPropertyValue<decimal>("SS_Taux", ref fSS_Taux, value); }
        }

        private decimal fSS_Taux_Abs;
        public decimal SS_Taux_Abs
        {
            get { return fSS_Taux_Abs; }
            set { SetPropertyValue<decimal>("SS_Taux_Abs", ref fSS_Taux_Abs, value); }
        }
         
        private decimal fNET;
        public decimal NET
        {
            get { return fNET; }
            set { SetPropertyValue<decimal>("NET", ref fNET, value); }
        }

        private decimal fNETAbsence;
        public decimal NETAbsence
        {
            get { return fNETAbsence; }
            set { SetPropertyValue<decimal>("NETAbsence", ref fNETAbsence, value); }
        }

        private decimal fMONTANT;
        public decimal MONTANT
        {
            get { return fMONTANT; }
            set { SetPropertyValue<decimal>("MONTANT", ref fMONTANT, value); }
        }

        private decimal fBrute_cotisable;
        public decimal Brute_cotisable
        {
            get { return fBrute_cotisable; }
            set { SetPropertyValue<decimal>("Brute_cotisable", ref fBrute_cotisable, value); }
        }

        private decimal fBrute_cotisable_Bareme;
        public decimal Brute_cotisable_Bareme
        {
            get { return fBrute_cotisable_Bareme; }
            set { SetPropertyValue<decimal>("Brute_cotisable_Bareme", ref fBrute_cotisable_Bareme, value); }
        }

        private decimal fBrute_cotisable_Bareme_Abs;
        public decimal Brute_cotisable_Bareme_Abs
        {
            get { return fBrute_cotisable_Bareme_Abs; }
            set { SetPropertyValue<decimal>("Brute_cotisable_Bareme_Abs", ref fBrute_cotisable_Bareme_Abs, value); }
        }

        private decimal fBrute_cotisable_Taux;
        public decimal Brute_cotisable_Taux
        {
            get { return fBrute_cotisable_Taux; }
            set { SetPropertyValue<decimal>("Brute_cotisable_Taux", ref fBrute_cotisable_Taux, value); }
        }

        private decimal fBrute_cotisable_Taux_Abs;
        public decimal Brute_cotisable_Taux_Abs
        {
            get { return fBrute_cotisable_Taux_Abs; }
            set { SetPropertyValue<decimal>("Brute_cotisable_Taux_Abs", ref fBrute_cotisable_Taux_Abs, value); }
        }
         
        private decimal fBrute_cotisableNonImpo;
        public decimal Brute_cotisableNonImpo
        {
            get { return fBrute_cotisableNonImpo; }
            set { SetPropertyValue<decimal>("Brute_cotisableNonImpo", ref fBrute_cotisableNonImpo, value); }
        }

        private decimal fBrute_cotisableNonImpo_Abs;
        public decimal Brute_cotisableNonImpo_Abs
        {
            get { return fBrute_cotisableNonImpo_Abs; }
            set { SetPropertyValue<decimal>("Brute_cotisableNonImpo_Abs", ref fBrute_cotisableNonImpo_Abs, value); }
        }

        private decimal fBrute_cotisableAbsence;
        public decimal Brute_cotisableAbsence
        {
            get { return fBrute_cotisableAbsence; }
            set { SetPropertyValue<decimal>("Brute_cotisableAbsence", ref fBrute_cotisableAbsence, value); }
        }

        private decimal fTot_Indem_impos_Non_Cotis;
        public decimal Tot_Indem_impos_Non_Cotis
        {
            get { return fTot_Indem_impos_Non_Cotis; }
            set { SetPropertyValue<decimal>("Tot_Indem_impos_Non_Cotis", ref fTot_Indem_impos_Non_Cotis, value); }
        }

        private decimal fTot_Indem_impos_Non_Cotis_Abs;
        public decimal Tot_Indem_impos_Non_Cotis_Abs
        {
            get { return fTot_Indem_impos_Non_Cotis_Abs; }
            set { SetPropertyValue<decimal>("Tot_Indem_impos_Non_Cotis_Abs", ref fTot_Indem_impos_Non_Cotis_Abs, value); }
        }

        private decimal fTot_Indem_Non_impos_Non_Cotis;
        public decimal Tot_Indem_Non_impos_Non_Cotis
        {
            get { return fTot_Indem_Non_impos_Non_Cotis; }
            set { SetPropertyValue<decimal>("Tot_Indem_Non_impos_Non_Cotis", ref fTot_Indem_Non_impos_Non_Cotis, value); }
        }

        private decimal fTot_Indem_Non_impos_Non_Cotis_Abs;
        public decimal Tot_Indem_Non_impos_Non_Cotis_Abs
        {
            get { return fTot_Indem_Non_impos_Non_Cotis_Abs; }
            set { SetPropertyValue<decimal>("Tot_Indem_Non_impos_Non_Cotis_Abs", ref fTot_Indem_Non_impos_Non_Cotis_Abs, value); }
        }

        private decimal fTot_Indem_Net;
        public decimal Tot_Indem_Net
        {
            get { return fTot_Indem_Net; }
            set { SetPropertyValue<decimal>("Tot_Indem_Net", ref fTot_Indem_Net, value); }
        }

        private decimal fTot_Indem_Net_Abs;
        public decimal Tot_Indem_Net_Abs
        {
            get { return fTot_Indem_Net_Abs; }
            set { SetPropertyValue<decimal>("Tot_Indem_Net_Abs", ref fTot_Indem_Net_Abs, value); }
        }

        private decimal fBrute_imposable;
        public decimal Brute_imposable
        {
            get { return fBrute_imposable; }
            set { SetPropertyValue<decimal>("Brute_imposable", ref fBrute_imposable, value); }
        }

        private decimal fBrute_imposable_Abs;
        public decimal Brute_imposable_Abs
        {
            get { return fBrute_imposable_Abs; }
            set { SetPropertyValue<decimal>("Brute_imposable_Abs", ref fBrute_imposable_Abs, value); }
        }

        private double fNbr_heure_50;
        public double Nbr_heure_50
        {
            get { return fNbr_heure_50; }
            set { SetPropertyValue<double>("Nbr_heure_50", ref fNbr_heure_50, value); }
        }

        private double fNbr_heure_75;
        public double Nbr_heure_75
        {
            get { return fNbr_heure_75; }
            set { SetPropertyValue<double>("Nbr_heure_75", ref fNbr_heure_75, value); }
        }

        private double fNbr_heure_100;
        public double Nbr_heure_100
        {
            get { return fNbr_heure_100; }
            set { SetPropertyValue<double>("Nbr_heure_100", ref fNbr_heure_100, value); }
        }

        private double fNbr_heure_150;
        public double Nbr_heure_150
        {
            get { return fNbr_heure_150; }
            set { SetPropertyValue<double>("Nbr_heure_150", ref fNbr_heure_150, value); }
        }

        private double fNbr_heure_200;
        public double Nbr_heure_200
        {
            get { return fNbr_heure_200; }
            set { SetPropertyValue<double>("Nbr_heure_200", ref fNbr_heure_200, value); }
        }

        private DateTime fDat_entre;
        public DateTime Dat_entre
        {
            get { return fDat_entre; }
            set { SetPropertyValue<DateTime>("Dat_entre", ref fDat_entre, value); }
        }

        private double fNbr_Ans_Trv_Int;
        public double Nbr_Ans_Trv_Int
        {
            get
            {
                return fNbr_Ans_Trv_Int;
            }
            set { SetPropertyValue<double>("Nbr_Ans_Trv_Int", ref fNbr_Ans_Trv_Int, value); }
        }

        private double fNbr_Ans_Trv_Ext_Prv;
        public double Nbr_Ans_Trv_Ext_Prv
        {
            get { return fNbr_Ans_Trv_Ext_Prv; }
            set { SetPropertyValue<double>("Nbr_Ans_Trv_Ext_Prv", ref fNbr_Ans_Trv_Ext_Prv, value); }
        }

        private double fNbr_Ans_Trv_Ext_Etat;
        public double Nbr_Ans_Trv_Ext_Etat
        {
            get { return fNbr_Ans_Trv_Ext_Etat; }
            set { SetPropertyValue<double>("Nbr_Ans_Trv_Ext_Etat", ref fNbr_Ans_Trv_Ext_Etat, value); }
        }

        private decimal fBASE;
        public decimal BASE
        {
            get { return fBASE; }
            set { SetPropertyValue<decimal>("BASE", ref fBASE, value); }
        }

        private double fTAUX;
        public double TAUX
        {
            get { return fTAUX; }
            set { SetPropertyValue<double>("TAUX", ref fTAUX, value); }
        }

        private double fNBR;
        public double NBR
        {
            get { return fNBR; }
            set { SetPropertyValue<double>("NBR", ref fNBR, value); }
        }

        private CategoriePaye fcat_paye;
        [Size(20)]
        public CategoriePaye cat_paye
        {
            get { return fcat_paye; }
            set { SetPropertyValue<CategoriePaye>("cat_paye", ref fcat_paye, value); }
        }

        private decimal fMontant_SDB;
        public decimal Montant_SDB
        {
            get { return fMontant_SDB; }
            set { SetPropertyValue<decimal>("Montant_SDB", ref fMontant_SDB, value); }
        }

        private decimal fSDB; //fonction fait
        public decimal SDB
        {
            get { return fSDB; }
            set { SetPropertyValue<decimal>("SDB", ref fSDB, value); }
        }

        private decimal fSDB_H; //fonction fait
        public decimal SDB_H
        {
            get { return fSDB_H; }
            set { SetPropertyValue<decimal>("SDB_H", ref fSDB_H, value); }
        }

        private decimal fSDBAbsence;
        public decimal SDBAbsence
        {
            get { return fSDBAbsence; }
            set { SetPropertyValue<decimal>("SDBAbsence", ref fSDBAbsence, value); }
        }

        private decimal fRappelSDB; //fonction fait
        public decimal RappelSDB
        {
            get { return fRappelSDB; }
            set { SetPropertyValue<decimal>("RappelSDB", ref fRappelSDB, value); }
        }

        private decimal fRappelSDBAbsence; //fonction fait
        public decimal RappelSDBAbsence
        {
            get { return fRappelSDBAbsence; }
            set { SetPropertyValue<decimal>("RappelSDBAbsence", ref fRappelSDBAbsence, value); }
        }

        private decimal fIEP;// fonction fait
        public decimal IEP
        {
            get { return fIEP; }
            set { SetPropertyValue<decimal>("IEP", ref fIEP, value); }
        }

        private decimal fIEP_Ext;// fonction fait
        public decimal IEP_Ext
        {
            get { return fIEP_Ext; }
            set { SetPropertyValue<decimal>("IEP_Ext", ref fIEP_Ext, value); }
        }

        private double fTAUX_IEP;
        public double TAUX_IEP
        {
            get { return fTAUX_IEP; }
            set { SetPropertyValue<double>("TAUX_IEP", ref fTAUX_IEP, value); }
        }

        private double fTAUX_IEP_Ext;
        public double TAUX_IEP_Ext
        {
            get { return fTAUX_IEP_Ext; }
            set { SetPropertyValue<double>("TAUX_IEP_Ext", ref fTAUX_IEP_Ext, value); }
        }

        private double fTaux_Iep_Org;
        public double Taux_Iep_Org
        {
            get { return fTaux_Iep_Org; }
            set { SetPropertyValue<double>("Taux_Iep_Org", ref fTaux_Iep_Org, value); }
        }

        private decimal fabat;
        public decimal abat
        {
            get { return fabat; }
            set { SetPropertyValue<decimal>("abat", ref fabat, value); }
        }

        //private double fnbr_heure_jour;
        //public double nbr_heure_jour
        //{
        //    get { return fnbr_heure_jour; }
        //    set { SetPropertyValue<double>("nbr_heure_jour", ref fnbr_heure_jour, value); }
        //}

        private bool fCal_manuel;
        public bool Cal_manuel
        {
            get { return fCal_manuel; }
            set { SetPropertyValue<bool>("Cal_manuel", ref fCal_manuel, value); }
        }

        private decimal fIrg_bareme;
        public decimal Irg_bareme
        {
            get { return fIrg_bareme; }
            set { SetPropertyValue<decimal>("Irg_bareme", ref fIrg_bareme, value); }
        }

        private decimal fIrg_bareme_Abs;
        public decimal Irg_bareme_Abs
        {
            get { return fIrg_bareme_Abs; }
            set { SetPropertyValue<decimal>("Irg_bareme_Abs", ref fIrg_bareme_Abs, value); }
        }

        private decimal fIrg_taux;
        public decimal Irg_taux
        {
            get { return fIrg_taux; }
            set { SetPropertyValue<decimal>("Irg_taux", ref fIrg_taux, value); }
        }

        private decimal fIrg_taux_Abs;
        public decimal Irg_taux_Abs
        {
            get { return fIrg_taux_Abs; }
            set { SetPropertyValue<decimal>("Irg_taux_Abs", ref fIrg_taux_Abs, value); }
        }

        private decimal fTot_indem_irg_taux;
        public decimal Tot_indem_irg_taux
        {
            get { return fTot_indem_irg_taux; }
            set { SetPropertyValue<decimal>("Tot_indem_irg_taux", ref fTot_indem_irg_taux, value); }
        }

        private double fTaux_SS;
        public double Taux_SS
        {
            get { return fTaux_SS; }
            set { SetPropertyValue<double>("Taux_SS", ref fTaux_SS, value); }
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

        private double fTaux_pp;
        public double Taux_pp
        {
            get { return fTaux_pp; }
            set { SetPropertyValue<double>("Taux_pp", ref fTaux_pp, value); }
        }

        private double fTaux_Mutuel;
        public double Taux_Mutuel
        {
            get { return fTaux_Mutuel; }
            set { SetPropertyValue<double>("Taux_Mutuel", ref fTaux_Mutuel, value); }
        }

        private decimal fPlafond_mutuelle;
        public decimal Plafond_mutuelle
        {
            get { return fPlafond_mutuelle; }
            set { SetPropertyValue<decimal>("Plafond_mutuelle", ref fPlafond_mutuelle, value); }
        }

        private double fTaux_IRG;
        public double Taux_IRG
        {
            get { return fTaux_IRG; }
            set { SetPropertyValue<double>("Taux_IRG", ref fTaux_IRG, value); }
        }

        private double fTaux_cacobatph;
        public double Taux_cacobatph
        {
            get { return fTaux_cacobatph; }
            set { SetPropertyValue<double>("Taux_cacobatph", ref fTaux_cacobatph, value); }
        }

        private double fTaux_chomage_intemperie;
        public double Taux_chomage_intemperie
        {
            get { return fTaux_chomage_intemperie; }
            set { SetPropertyValue<double>("Taux_chomage_intemperie", ref fTaux_chomage_intemperie, value); }
        }

        private double fTaux_chomage_intemperiePO;
        public double Taux_chomage_intemperiePO
        {
            get { return fTaux_chomage_intemperiePO; }
            set { SetPropertyValue<double>("Taux_chomage_intemperiePO", ref fTaux_chomage_intemperiePO, value); }
        }

        private decimal fImposable_taux;
        public decimal Imposable_taux
        {
            get { return fImposable_taux; }
            set { SetPropertyValue<decimal>("Imposable_taux", ref fImposable_taux, value); }
        }

        private decimal fImposable_bareme;
        public decimal Imposable_bareme
        {
            get { return fImposable_bareme; }
            set { SetPropertyValue<decimal>("Imposable_bareme", ref fImposable_bareme, value); }
        }

        private decimal fImposable_taux_Abs;
        public decimal Imposable_taux_Abs
        {
            get { return fImposable_taux_Abs; }
            set { SetPropertyValue<decimal>("Imposable_taux_Abs", ref fImposable_taux_Abs, value); }
        }

        private decimal fImposable_bareme_Abs;
        public decimal Imposable_bareme_Abs
        {
            get { return fImposable_bareme_Abs; }
            set { SetPropertyValue<decimal>("Imposable_bareme_Abs", ref fImposable_bareme_Abs, value); }
        }

        private decimal fImposable_bareme_22;
        public decimal Imposable_bareme_22
        {
            get { return fImposable_bareme_22; }
            set { SetPropertyValue<decimal>("Imposable_bareme_22", ref fImposable_bareme_22, value); }
        }

        private decimal fImposable_bareme_22_Abs;
        public decimal Imposable_bareme_22_Abs
        {
            get { return fImposable_bareme_22_Abs; }
            set { SetPropertyValue<decimal>("Imposable_bareme_22_Abs", ref fImposable_bareme_22_Abs, value); }
        }
         
        private decimal fmutuelle;
        public decimal mutuelle
        {
            get { return fmutuelle; }
            set { SetPropertyValue<decimal>("mutuelle", ref fmutuelle, value); }
        }

        private decimal fmutuelleAbs;
        public decimal mutuelleAbs
        {
            get { return fmutuelleAbs; }
            set { SetPropertyValue<decimal>("mutuelleAbs", ref fmutuelleAbs, value); }
        }

        private parametre fparametres;
        public parametre parametres
        {
            get { return fparametres; }
            set { SetPropertyValue<parametre>("parametres", ref fparametres, value); }
        }

        private Bareme fCategori;
        public Bareme Categori
        {
            get { return fCategori; }
            set { SetPropertyValue<Bareme>("Categori", ref fCategori, value); }
        }

        private Corps fCorps;
        public Corps Corps
        {
            get { return fCorps; }
            set { SetPropertyValue<Corps>("Corps", ref fCorps, value); }
        }

        private int fIndiceIEP;
        public int IndiceIEP
        {
            get { return fIndiceIEP; }
            set { SetPropertyValue<int>("IndiceIEP", ref fIndiceIEP, value); }
        }

        private int fEchelon08;
        public int Echelon08
        {
            get { return fEchelon08; }
            set { SetPropertyValue<int>("Echelon08", ref fEchelon08, value); }
        }

        private int fEchelon01;
        public int Echelon01
        {
            get { return fEchelon01; }
            set { SetPropertyValue<int>("Echelon01", ref fEchelon01, value); }
        }

        private Fonction fLaFonction;
        public Fonction LaFonction
        {
            get { return fLaFonction; }
            set { SetPropertyValue<Fonction>("LaFonction", ref fLaFonction, value); }
        }

        private Fonction fFonction_Stagière;
        public Fonction Fonction_Stagière
        {
            get { return fFonction_Stagière; }
            set { SetPropertyValue<Fonction>("Fonction_Stagière", ref fFonction_Stagière, value); }
        }

        private Situation_Familiale fSit_fam;
        public Situation_Familiale Sit_fam
        {
            get { return fSit_fam; }
            set { SetPropertyValue<Situation_Familiale>("Sit_fam", ref fSit_fam, value); }
        }

        private Situation_Conjoint fSit_Conjoint;
        public Situation_Conjoint Sit_Conjoint
        {
            get { return fSit_Conjoint; }
            set { SetPropertyValue<Situation_Conjoint>("Sit_Conjoint", ref fSit_Conjoint, value); }
        }

        private Situation_Employe fSit_Emp;
        public Situation_Employe Sit_Emp
        {
            get { return fSit_Emp; }
            set { SetPropertyValue<Situation_Employe>("Sit_Emp", ref fSit_Emp, value); }
        }

        private Unite fUnite;
        public Unite Unite
        {
            get { return fUnite; }
            set { SetPropertyValue<Unite>("Unite", ref fUnite, value); }
        }

        private decimal fBonif_Resp;
        public decimal Bonif_Resp
        {
            get { return fBonif_Resp; }
            set { SetPropertyValue<decimal>("Bonif_Resp", ref fBonif_Resp, value); }
        }

        private decimal fSU;
        public decimal SU
        {
            get { return fSU; }
            set { SetPropertyValue<decimal>("SU", ref fSU, value); }
        }

        private decimal fSU_Partiel;
        public decimal SU_Partiel
        {
            get { return fSU_Partiel; }
            set { SetPropertyValue<decimal>("SU_Partiel", ref fSU_Partiel, value); }
        }

        private decimal fAF;
        public decimal AF
        {
            get { return fAF; }
            set { SetPropertyValue<decimal>("AF", ref fAF, value); }
        }

        private bool fAF_Partiel;
        public bool AF_Partiel
        {
            get { return fAF_Partiel; }
            set { SetPropertyValue<bool>("AF_Partiel", ref fAF_Partiel, value); }
        }

        private decimal fAF_Majoration;
        public decimal AF_Majoration
        {
            get { return fAF_Majoration; }
            set { SetPropertyValue<decimal>("AF_Majoration", ref fAF_Majoration, value); }
        }

        private decimal fAF_Global;
        public decimal AF_Global
        {
            get { return fAF_Global; }
            set { SetPropertyValue<decimal>("AF_Global", ref fAF_Global, value); }
        }

        private decimal fPrime_Scol;
        public decimal Prime_Scol
        {
            get { return fPrime_Scol; }
            set { SetPropertyValue<decimal>("Prime_Scol", ref fPrime_Scol, value); }
        }

        private decimal fPrime_Scol_Partiel;
        public decimal Prime_Scol_Partiel
        {
            get { return fPrime_Scol_Partiel; }
            set { SetPropertyValue<decimal>("Prime_Scol_Partiel", ref fPrime_Scol_Partiel, value); }
        }

        private decimal fRetenu_Pret;
        public decimal Retenu_Pret
        {
            get { return fRetenu_Pret; }
            set { SetPropertyValue<decimal>("Retenu_Pret", ref fRetenu_Pret, value); }
        }

        private decimal fRetenu_Global;
        public decimal Retenu_Global
        {
            get { return fRetenu_Global; }
            set { SetPropertyValue<decimal>("Retenu_Global", ref fRetenu_Global, value); }
        }

        private decimal fDRet;
        public decimal DRet
        {
            get { return fDRet; }
            set { SetPropertyValue<decimal>("DRet", ref fDRet, value); }
        }

        private decimal fVRet;
        public decimal VRet
        {
            get { return fVRet; }
            set { SetPropertyValue<decimal>("VRet", ref fVRet, value); }
        }

        private decimal fIFSP;
        public decimal IFSP
        {
            get { return fIFSP; }
            set { SetPropertyValue<decimal>("IFSP", ref fIFSP, value); }
        }

        private decimal fNUIS;
        public decimal NUIS
        {
            get { return fNUIS; }
            set { SetPropertyValue<decimal>("NUIS", ref fNUIS, value); }

        }

        private decimal fGuichet;
        public decimal Guichet
        {
            get { return fGuichet; }
            set { SetPropertyValue<decimal>("Guichet", ref fGuichet, value); }
        }

        private decimal fEncourag;
        public decimal Encourag
        {
            get { return fEncourag; }
            set { SetPropertyValue<decimal>("Encourag", ref fEncourag, value); }
        }

        private decimal fPrime_Pannier;
        public decimal Prime_Pannier
        {
            get { return fPrime_Pannier; }
            set { SetPropertyValue<decimal>("Prime_Pannier", ref fPrime_Pannier, value); }
        }

        private decimal fPrime_Transport;
        public decimal Prime_Transport
        {
            get { return fPrime_Transport; }
            set { SetPropertyValue<decimal>("Prime_Transport", ref fPrime_Transport, value); }
        }

        private decimal fPRI;
        public decimal PRI
        {
            get { return fPRI; }
            set { SetPropertyValue<decimal>("PRI", ref fPRI, value); }
        }

        private decimal fPRC;
        public decimal PRC
        {
            get { return fPRC; }
            set { SetPropertyValue<decimal>("PRC", ref fPRC, value); }
        }

        private decimal fIRC;
        public decimal IRC
        {
            get { return fIRC; }
            set { SetPropertyValue<decimal>("IRC", ref fIRC, value); }
        }

        private decimal fPrime_Km;
        public decimal Prime_Km
        {
            get { return fPrime_Km; }
            set { SetPropertyValue<decimal>("Prime_Km", ref fPrime_Km, value); }
        }

        private decimal fSujétion;
        public decimal Sujétion
        {
            get { return fSujétion; }
            set { SetPropertyValue<decimal>("Sujétion", ref fSujétion, value); }
        }

        private decimal fVariable;
        public decimal Variable
        {
            get { return fVariable; }
            set { SetPropertyValue<decimal>("Variable", ref fVariable, value); }
        }

        private string fChaine_Paye;
        public string Chaine_Paye
        {
            get { return fChaine_Paye; }
            set
            {
                SetPropertyValue<string>("Chaine_Paye", ref fChaine_Paye, value);
            }
        }

        private bool fOk_Mutuel;
        public bool Ok_Mutuel
        {
            get { return fOk_Mutuel; }
            set { SetPropertyValue<bool>("Ok_Mutuel", ref fOk_Mutuel, value); }
        }

        private bool fBloque_Paye;
        [ImmediatePostData]
        public bool Bloque_Paye
        {
            get { return fBloque_Paye; }
            set { SetPropertyValue<bool>("Bloque_Paye", ref fBloque_Paye, value); }
        }

        private int fNote_Perso_Pri;
        [ImmediatePostData]
        public int Note_Perso_Pri
        {
            get { return fNote_Perso_Pri; }
            set { SetPropertyValue<int>("Note_Perso_Pri", ref fNote_Perso_Pri, value); }
        }

        private int fNbr_Mois_Perso_Pri;
        [Size(2)]
        public int Nbr_Mois_Perso_Pri
        {
            get { return fNbr_Mois_Perso_Pri; }
            set { SetPropertyValue<int>("Nbr_Mois_Perso_Pri", ref fNbr_Mois_Perso_Pri, value); }
        }

        private int fNote_Perso_PAP;
        [ImmediatePostData]
        public int Note_Perso_PAP
        {
            get { return fNote_Perso_PAP; }
            set { SetPropertyValue<int>("Note_Perso_PAP", ref fNote_Perso_PAP, value); }
        }

        private int fNbr_Mois_Perso_PAP;
        [Size(2)]
        public int Nbr_Mois_Perso_PAP
        {
            get { return fNbr_Mois_Perso_PAP; }
            set { SetPropertyValue<int>("Nbr_Mois_Perso_PAP", ref fNbr_Mois_Perso_PAP, value); }
        }

        private Type_Absence fType_Abcense;
        public Type_Absence Type_Abcense
        {
            get { return fType_Abcense; }
            set { SetPropertyValue<Type_Absence>("Type_Abcense", ref fType_Abcense, value); }
        }

        private decimal fBase_AF;
        public decimal Base_AF
        {
            get { return fBase_AF; }
            set { SetPropertyValue<decimal>("Base_AF", ref fBase_AF, value); }
        }

        private decimal fBase_AF_Partiel;
        public decimal Base_AF_Partiel
        {
            get { return fBase_AF_Partiel; }
            set { SetPropertyValue<decimal>("Base_AF_Partiel", ref fBase_AF_Partiel, value); }
        }

        private decimal fBase_AF_P10;
        public decimal Base_AF_P10
        {
            get { return fBase_AF_P10; }
            set { SetPropertyValue<decimal>("Base_AF_P10", ref fBase_AF_P10, value); }
        }

        private decimal fPrime_Except;
        public decimal Prime_Except
        {
            get { return fPrime_Except; }
            set { SetPropertyValue<decimal>("Prime_Except", ref fPrime_Except, value); }
        }

        private decimal fPrime_Victime;
        public decimal Prime_Victime
        {
            get { return fPrime_Victime; }
            set { SetPropertyValue<decimal>("Prime_Victime", ref fPrime_Victime, value); }
        }

        private decimal fIncapacite_Perman;
        public decimal Incapacite_Perman
        {
            get { return fIncapacite_Perman; }
            set { SetPropertyValue<decimal>("Incapacite_Perman", ref fIncapacite_Perman, value); }
        }

        private double fTaux_HS;
        public double Taux_HS
        {
            get { return fTaux_HS; }
            set { SetPropertyValue<double>("Taux_HS", ref fTaux_HS, value); }
        }

        private decimal fBrut_HS_Paye;
        public decimal Brut_HS_Paye
        {
            get { return fBrut_HS_Paye; }
            set { SetPropertyValue<decimal>("Brut_HS_Paye", ref fBrut_HS_Paye, value); }
        }

        private decimal fIndem1;
        public decimal Indem1
        {
            get { return fIndem1; }
            set { SetPropertyValue<decimal>("Indem1", ref fIndem1, value); }
        }

        private decimal fIndem2;
        public decimal Indem2
        {
            get { return fIndem2; }
            set { SetPropertyValue<decimal>("Indem2", ref fIndem2, value); }
        }

        private decimal fIndem3;
        public decimal Indem3
        {
            get { return fIndem3; }
            set { SetPropertyValue<decimal>("Indem3", ref fIndem3, value); }
        }

        private decimal fIndem4;
        public decimal Indem4
        {
            get { return fIndem4; }
            set { SetPropertyValue<decimal>("Indem4", ref fIndem4, value); }
        }

        private decimal fIndem5;
        public decimal Indem5
        {
            get { return fIndem5; }
            set { SetPropertyValue<decimal>("Indem5", ref fIndem5, value); }
        }

        private decimal fIndem6;
        public decimal Indem6
        {
            get { return fIndem6; }
            set { SetPropertyValue<decimal>("Indem6", ref fIndem6, value); }
        }

        private decimal fIndem7;
        public decimal Indem7
        {
            get { return fIndem7; }
            set { SetPropertyValue<decimal>("Indem7", ref fIndem7, value); }
        }

        private decimal fIndem8;
        public decimal Indem8
        {
            get { return fIndem8; }
            set { SetPropertyValue<decimal>("Indem8", ref fIndem8, value); }
        }

        private decimal fIndem9;
        public decimal Indem9
        {
            get { return fIndem9; }
            set { SetPropertyValue<decimal>("Indem9", ref fIndem9, value); }
        }

        private decimal fIndem10;
        public decimal Indem10
        {
            get { return fIndem10; }
            set { SetPropertyValue<decimal>("Indem10", ref fIndem10, value); }
        }

        private decimal fIndem11;
        public decimal Indem11
        {
            get { return fIndem11; }
            set { SetPropertyValue<decimal>("Indem11", ref fIndem11, value); }
        }

        private decimal fIndem12;
        public decimal Indem12
        {
            get { return fIndem12; }
            set { SetPropertyValue<decimal>("Indem12", ref fIndem12, value); }
        }

        private decimal fIndem13;
        public decimal Indem13
        {
            get { return fIndem13; }
            set { SetPropertyValue<decimal>("Indem13", ref fIndem13, value); }
        }

        private decimal fIndem14;
        public decimal Indem14
        {
            get { return fIndem14; }
            set { SetPropertyValue<decimal>("Indem14", ref fIndem14, value); }
        }

        private decimal fIndem15;
        public decimal Indem15
        {
            get { return fIndem15; }
            set { SetPropertyValue<decimal>("Indem15", ref fIndem15, value); }
        }

        private decimal fIndem16;
        public decimal Indem16
        {
            get { return fIndem16; }
            set { SetPropertyValue<decimal>("Indem16", ref fIndem16, value); }
        }

        private decimal fIndem17;
        public decimal Indem17
        {
            get { return fIndem17; }
            set { SetPropertyValue<decimal>("Indem17", ref fIndem17, value); }
        }

        private decimal fIndem18;
        public decimal Indem18
        {
            get { return fIndem18; }
            set { SetPropertyValue<decimal>("Indem18", ref fIndem18, value); }
        }

        private decimal fIndem19;
        public decimal Indem19
        {
            get { return fIndem19; }
            set { SetPropertyValue<decimal>("Indem19", ref fIndem19, value); }
        }

        private decimal fIndem20;
        public decimal Indem20
        {
            get { return fIndem20; }
            set { SetPropertyValue<decimal>("Indem20", ref fIndem20, value); }
        }

        private decimal fIndem21;
        public decimal Indem21
        {
            get { return fIndem21; }
            set { SetPropertyValue<decimal>("Indem21", ref fIndem21, value); }
        }

        private decimal fIndem22;
        public decimal Indem22
        {
            get { return fIndem22; }
            set { SetPropertyValue<decimal>("Indem22", ref fIndem22, value); }
        }

        private decimal fIndem23;
        public decimal Indem23
        {
            get { return fIndem23; }
            set { SetPropertyValue<decimal>("Indem23", ref fIndem23, value); }
        }

        private decimal fIndem24;
        public decimal Indem24
        {
            get { return fIndem24; }
            set { SetPropertyValue<decimal>("Indem24", ref fIndem24, value); }
        }

        private decimal fIndem25;
        public decimal Indem25
        {
            get { return fIndem25; }
            set { SetPropertyValue<decimal>("Indem25", ref fIndem25, value); }
        }

        private decimal fIndem26;
        public decimal Indem26
        {
            get { return fIndem26; }
            set { SetPropertyValue<decimal>("Indem26", ref fIndem26, value); }
        }

        private decimal fIndem27;
        public decimal Indem27
        {
            get { return fIndem27; }
            set { SetPropertyValue<decimal>("Indem27", ref fIndem27, value); }
        }

        private decimal fIndem28;
        public decimal Indem28
        {
            get { return fIndem28; }
            set { SetPropertyValue<decimal>("Indem28", ref fIndem28, value); }
        }

        private decimal fIndem29;
        public decimal Indem29
        {
            get { return fIndem29; }
            set { SetPropertyValue<decimal>("Indem29", ref fIndem29, value); }
        }

        private decimal fIndem30;
        public decimal Indem30
        {
            get { return fIndem30; }
            set { SetPropertyValue<decimal>("Indem30", ref fIndem30, value); }
        }

        private decimal fHSUP_50;
        public decimal HSUP_50
        {
            get { return fHSUP_50; }
            set { SetPropertyValue<decimal>("HSUP_50", ref fHSUP_50, value); }
        }

        private decimal fHSUP_75;
        public decimal HSUP_75
        {
            get { return fHSUP_75; }
            set { SetPropertyValue<decimal>("HSUP_75", ref fHSUP_75, value); }
        }

        private decimal fHSUP_100;
        public decimal HSUP_100
        {
            get { return fHSUP_100; }
            set { SetPropertyValue<decimal>("HSUP_100", ref fHSUP_100, value); }
        }

        private decimal fHSUP_150;
        public decimal HSUP_150
        {
            get { return fHSUP_150; }
            set { SetPropertyValue<decimal>("HSUP_150", ref fHSUP_150, value); }
        }

        private decimal fHSUP_200;
        public decimal HSUP_200
        {
            get { return fHSUP_200; }
            set { SetPropertyValue<decimal>("HSUP_200", ref fHSUP_200, value); }
        }

        private decimal fInd_Veh;
        public decimal Ind_Veh
        {
            get { return fInd_Veh; }
            set { SetPropertyValue<decimal>("Ind_Veh", ref fInd_Veh, value); }
        }

        private decimal fInd_Log;
        public decimal Ind_Log
        {
            get { return fInd_Log; }
            set { SetPropertyValue<decimal>("Ind_Log", ref fInd_Log, value); }
        }

        private decimal fPresentation;
        public decimal Presentation
        {
            get { return fPresentation; }
            set { SetPropertyValue<decimal>("Presentation", ref fPresentation, value); }
        }

        private decimal fInd_Mission;
        public decimal Ind_Mission
        {
            get { return fInd_Mission; }
            set { SetPropertyValue<decimal>("Ind_Mission", ref fInd_Mission, value); }
        }

        private string fMotif;
        public string Motif
        {
            get { return fMotif; }
            set { SetPropertyValue<string>("Motif", ref fMotif, value); }
        }

        private Mode_Paiement fMode_Paiement;
        public Mode_Paiement Mode_Paiement
        {
            get { return fMode_Paiement; }
            set { SetPropertyValue<Mode_Paiement>("Mode_Paiement", ref fMode_Paiement, value); }
        }

        private decimal fcacobatph;
        public decimal cacobatph
        {
            get { return fcacobatph; }
            set { SetPropertyValue<decimal>("cacobatph", ref fcacobatph, value); }
        }

        private decimal fchomage_intemperie;
        public decimal chomage_intemperie
        {
            get { return fchomage_intemperie; }
            set { SetPropertyValue<decimal>("chomage_intemperie", ref fchomage_intemperie, value); }
        }

        private decimal fChIntempPO;
        public decimal ChIntempPO
        {
            get { return fChIntempPO; }
            set { SetPropertyValue<decimal>("ChIntempPO", ref fChIntempPO, value); }
        }

        private decimal fChIntempPOAbs;
        public decimal ChIntempPOAbs
        {
            get { return fChIntempPOAbs; }
            set { SetPropertyValue<decimal>("ChIntempPOAbs", ref fChIntempPOAbs, value); }
        }

        private decimal fPP;
        public decimal PP
        {
            get { return fPP; }
            set { SetPropertyValue<decimal>("PP", ref fPP, value); }
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

        private decimal fIndem_Conge;
        public decimal Indem_Conge
        {
            get { return fIndem_Conge; }
            set { SetPropertyValue<decimal>("Indem_Conge", ref fIndem_Conge, value); }
        }

        private bool fConge_Calcule;
        public bool Conge_Calcule
        {
            get { return fConge_Calcule; }
            set { SetPropertyValue<bool>("Conge_Calcule", ref fConge_Calcule, value); }
        }

        private decimal fIndem_Conge_Recup;
        public decimal Indem_Conge_Recup
        {
            get { return fIndem_Conge_Recup; }
            set { SetPropertyValue<decimal>("Indem_Conge_Recup", ref fIndem_Conge_Recup, value); }
        }

        private decimal fIndem_Conge_Recup_Abs;
        public decimal Indem_Conge_Recup_Abs
        {
            get { return fIndem_Conge_Recup_Abs; }
            set { SetPropertyValue<decimal>("Indem_Conge_Recup_Abs", ref fIndem_Conge_Recup_Abs, value); }
        }

        private bool fConge_Calcule_Recup;
        public bool Conge_Calcule_Recup
        {
            get { return fConge_Calcule_Recup; }
            set { SetPropertyValue<bool>("Conge_Calcule_Recup", ref fConge_Calcule_Recup, value); }
        }

        private decimal fPMG;
        public decimal PMG
        {
            get { return fPMG; }
            set { SetPropertyValue<decimal>("PMG", ref fPMG, value); }
        }

        private PrimePMG fPrimePMG;
        public PrimePMG PrimePMG
        {
            get { return fPrimePMG; }
            set { SetPropertyValue<PrimePMG>("PrimePMG", ref fPrimePMG, value); }
        }

        private PrimeShiftNuit fPrimeShiftNuit;
        public PrimeShiftNuit PrimeShiftNuit
        {
            get { return fPrimeShiftNuit; }
            set { SetPropertyValue<PrimeShiftNuit>("PrimeShiftNuit", ref fPrimeShiftNuit, value); }
        }

        private decimal fShiftNuit;
        public decimal ShiftNuit
        {
            get { return fShiftNuit; }
            set { SetPropertyValue<decimal>("ShiftNuit", ref fShiftNuit, value); }
        }

        private decimal fNbrJrsCRSN;
        public decimal NbrJrsCRSN
        {
            get { return fNbrJrsCRSN; }
            set { SetPropertyValue<decimal>("NbrJrsCRSN", ref fNbrJrsCRSN, value); }
        }

        private TimeSpan fHeureDebutShiftNuit;
        public TimeSpan HeureDebutShiftNuit
        {
            get { return fHeureDebutShiftNuit; }
            set { SetPropertyValue<TimeSpan>("HeureDebutShiftNuit", ref fHeureDebutShiftNuit, value); }
        }

        private int fNbrHeuresShiftNuit;
        public int NbrHeurerShiftNuit
        {
            get { return fNbrHeuresShiftNuit; }
            set { SetPropertyValue<int>("NbrHeuresShiftNuit", ref fNbrHeuresShiftNuit, value); }
        }

        private bool fShiftNuitCR;
        public bool ShiftNuitCR
        {
            get { return fShiftNuitCR; }
            set { SetPropertyValue<bool>("ShiftNuitCR", ref fShiftNuitCR, value); }
        }

        private bool fCRAvecPaye;
        public bool CRAvecPaye
        {
            get { return fCRAvecPaye; }
            set { SetPropertyValue<bool>("CRAvecPaye", ref fCRAvecPaye, value); }
        }
         
        private int fNbrJrsTrvPrJrsCR;
        public int NbrJrsTrvPrJrsCR
        {
            get { return fNbrJrsTrvPrJrsCR; }
            set { SetPropertyValue<int>("NbrJrsTrvPrJrsCR", ref fNbrJrsTrvPrJrsCR, value); }
        }

        private double fNbrJrsCRPrJrsTrv;
        public double NbrJrsCRPrJrsTrv
        {
            get { return fNbrJrsCRPrJrsTrv; }
            set { SetPropertyValue<double>("NbrJrsCRPrJrsTrv", ref fNbrJrsCRPrJrsTrv, value); }
        }

        private double fNbr_Jrs_Cong;
        public double Nbr_Jrs_Cong
        {
            get { return fNbr_Jrs_Cong; }
            set { SetPropertyValue<double>("Nbr_Jrs_Cong", ref fNbr_Jrs_Cong, value); }
        }

        private double fNbr_Jrs_Cong_Recup;
        public double Nbr_Jrs_Cong_Recup
        {
            get { return fNbr_Jrs_Cong_Recup; }
            set { SetPropertyValue<double>("Nbr_Jrs_Cong_Recup", ref fNbr_Jrs_Cong_Recup, value); }
        }

        private double fNbr_Jrs_Cong_Recup_Anc;
        public double Nbr_Jrs_Cong_Recup_Anc
        {
            get { return fNbr_Jrs_Cong_Recup_Anc; }
            set { SetPropertyValue<double>("Nbr_Jrs_Cong_Recup_Anc", ref fNbr_Jrs_Cong_Recup_Anc, value); }
        }

        //private double fNbr_Jrs_Cong_Recup_Dus;
        //public double Nbr_Jrs_Cong_Recup_Dus
        //{
        //    get { return fNbr_Jrs_Cong_Recup_Dus; }
        //    set { SetPropertyValue<double>("Nbr_Jrs_Cong_Recup_Dus", ref fNbr_Jrs_Cong_Recup_Dus, value); }
        //}

        private double fnbr_jour_cong_mois;
        public double nbr_jour_cong_mois
        {
            get { return fnbr_jour_cong_mois; }
            set { SetPropertyValue<double>("nbr_jour_cong_mois", ref fnbr_jour_cong_mois, value); }
        }

        private double fNbr_Jrs_Pres;
        public double Nbr_Jrs_Pres
        {
            get { return fNbr_Jrs_Pres; }
            set { SetPropertyValue<double>("Nbr_Jrs_Pres", ref fNbr_Jrs_Pres, value); }
        }

        private DateTime fdat_deb_cong;
        public DateTime dat_deb_cong
        {
            get { return fdat_deb_cong; }
            set { SetPropertyValue<DateTime>("dat_deb_cong", ref fdat_deb_cong, value); }
        }

        private DateTime fdat_fin_cong;
        public DateTime dat_fin_cong
        {
            get { return fdat_fin_cong; }
            set { SetPropertyValue<DateTime>("dat_fin_cong", ref fdat_fin_cong, value); }
        }

        private decimal fIndem_STC;
        public decimal Indem_STC
        {
            get { return fIndem_STC; }
            set { SetPropertyValue<decimal>("Indem_STC", ref fIndem_STC, value); }
        }

        private ModeArrondi fMode_Arrondi;
        public ModeArrondi Mode_Arrondi
        {
            get
            {
                return fMode_Arrondi;
            }
            set { SetPropertyValue<ModeArrondi>("Mode_Arrondi", ref fMode_Arrondi, value); }
        }

        private bool fValide;
        public bool Valide
        {
            get { return fValide; }
            set { SetPropertyValue<bool>("Valide", ref fValide, value); }
        }

        private bool fFromRappel;
        public bool FromRappel
        {
            get { return fFromRappel; }
            set { SetPropertyValue<bool>("FromRappel", ref fFromRappel, value); }
        }

        public Paye(Session session)
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

            Calcul_Absence_Auto = parametres.Calcul_Absence_Auto;
            Nbr_heure_ouv = parametres.Nbr_heure_ouv;
            Nbr_heure_tra = parametres.Nbr_heure_tra;
            Nbr_jour_tra = parametres.Nbr_jour_tra;
            Nbr_Jour_Tra_Prime = parametres.Nbr_Jour_Travail_Prime;
            Taux_IRG = parametres.Taux_irg;
            Taux_chomage_intemperie = parametres.Taux_chomage_intemperie;
            Taux_cacobatph = parametres.Taux_cacobatph;
            Taux_SS = parametres.Taux_ss;

            Type_Abcense = parametres.Type_Abcense;
            Base_AF = parametres.Base_AF;
            Base_AF_Partiel = parametres.Base_AF_Partiel;
            Base_AF_P10 = parametres.Base_AF_P10;
            Annee = parametres.Annee_Travail;
            Taux_Iep_Org = parametres.Taux_Iep_Org;

            Mode_Arrondi = parametres.Mode_Arrondi;


        }

        //**********************************************************************************************************************//

        Arrondi_Decimal ArrondiDecimale = new Arrondi_Decimal();
        CalculerNbrMois CalculerNbrMois = new CalculerNbrMois();
        AbsAutoEntree AbsEntree = new AbsAutoEntree();
        AbsAutoSortie AbsSortie = new AbsAutoSortie();

        public static int count_Perso(Session session)
        {
            XPCollection<Personne> personne = new XPCollection<Personne>(session);

            personne.Load();
            int cpt = personne.Count;
            return cpt;
        }

        public bool If_ModifSpec(string Code)
        {
            bool modifspec = false;
            Indem Indemnite = this.Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", Code));

            if (Indemnite != null)
            {
                XPCollection<Indem> indem = new XPCollection<Indem>(Session, CriteriaOperator.Parse("Cod_indem_interne==?", Code));
                if (indem.Count > 1)
                {
                    foreach (Indem indemnite in indem)
                    {
                        CriteriaOperator criteria1 = CriteriaOperator.Parse("Indemnite==?", indemnite.Oid.ToString());
                        CriteriaOperator criteria2 = CriteriaOperator.Parse("Paye==?", this);

                        paye_indem paye_indem = Session.FindObject<paye_indem>(CriteriaOperator.And(criteria1, criteria2));

                        if (paye_indem != null)
                            modifspec = paye_indem.ModifSpecial;
                    }
                }
                else
                {
                    CriteriaOperator criteria1 = CriteriaOperator.Parse("Indemnite==?", Indemnite.Oid.ToString());
                    CriteriaOperator criteria2 = CriteriaOperator.Parse("Paye==?", this);

                    paye_indem paye_indem = Session.FindObject<paye_indem>(CriteriaOperator.And(criteria1, criteria2));

                    if (paye_indem != null)
                        modifspec = paye_indem.ModifSpecial;
                }
            }

            return modifspec;
        }

        public bool If_Exist(string Code)
        {
            bool exist = false;

            Indem Indemnite = this.Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", Code));

            if (Indemnite != null)
            {
                XPCollection<Indem> indem = new XPCollection<Indem>(Session, CriteriaOperator.Parse("Cod_indem_interne==?", Code));
                if (indem.Count > 1)
                {
                    foreach (Indem indemnite in indem)
                    {
                        CriteriaOperator criteria1 = CriteriaOperator.Parse("Indemnite==?", indemnite.Oid.ToString());
                        CriteriaOperator criteria2 = CriteriaOperator.Parse("Paye==?", this);

                        //paye_indem paye_indem = Session.FindObject<paye_indem>(PersistentCriteriaEvaluationBehavior.InTransaction, CriteriaOperator.And(criteria1, criteria2));
                        paye_indem paye_indem = Session.FindObject<paye_indem>(CriteriaOperator.And(criteria1, criteria2));

                        if (paye_indem != null)
                            exist = true;
                    }
                }
                else
                {
                    //Indem indemnite = this.Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", Code));

                    CriteriaOperator criteria1 = CriteriaOperator.Parse("Indemnite==?", Indemnite.Oid.ToString());
                    CriteriaOperator criteria2 = CriteriaOperator.Parse("Paye==?", this);

                    //paye_indem paye_indem = Session.FindObject<paye_indem>(PersistentCriteriaEvaluationBehavior.InTransaction, CriteriaOperator.And(criteria1, criteria2));
                    paye_indem paye_indem = Session.FindObject<paye_indem>(CriteriaOperator.And(criteria1, criteria2));

                    if (paye_indem != null)
                        exist = true;
                }
            }
            return exist;
        }

        public decimal Get_Montant(string Code)
        {
            decimal montant = 0;

            Indem indem = this.Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", Code));
            if (indem != null)
            {

                CriteriaOperator criteria1 = CriteriaOperator.Parse("Indemnite==?", indem.Oid.ToString());
                CriteriaOperator criteria2 = CriteriaOperator.Parse("Paye==?", this);

                paye_indem paye_indem = this.Session.FindObject<paye_indem>(CriteriaOperator.And(criteria1, criteria2));

                if (paye_indem != null)
                    montant = paye_indem.Montant;
            }

            return montant;
        }

        public double Get_Nbr(string Code)
        {
            double nbr = 0;

            Indem indem = this.Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", Code));
            if (indem != null)
            {

                CriteriaOperator criteria1 = CriteriaOperator.Parse("Indemnite==?", indem.Oid.ToString());
                CriteriaOperator criteria2 = CriteriaOperator.Parse("Paye==?", this);

                paye_indem paye_indem = this.Session.FindObject<paye_indem>(CriteriaOperator.And(criteria1, criteria2));

                if (paye_indem != null)
                    nbr = paye_indem.INbr;
            }
            return nbr;
        }

        public void Remise_A_0()
        {
            Tot_Indem_Net = 0;
            Tot_Indem_Net_Abs = 0;
            Tot_Indem_impos_Non_Cotis = 0;
            Tot_Indem_impos_Non_Cotis_Abs = 0;
            Tot_Indem_Non_impos_Non_Cotis = 0;
            Tot_Indem_Non_impos_Non_Cotis_Abs = 0;
            BRUT = 0;
            BRUTAbsence = 0;
            IRG = 0;
            IRGAbsence = 0;
            SS = 0;
            SSAbsence = 0;
            NET = 0;
            NETAbsence = 0;
            Brute_cotisable = 0;
            Brute_cotisableAbsence = 0;
            Brute_cotisable_Bareme = 0;
            Brute_cotisable_Bareme_Abs = 0;
            Brute_cotisable_Taux = 0;
            Brute_cotisable_Taux_Abs = 0;
            Brute_imposable = 0;
            Brute_imposable_Abs = 0;
            Imposable_taux = 0;
            Imposable_taux_Abs = 0;
            Imposable_bareme = 0;
            Imposable_bareme_Abs = 0;
            Imposable_bareme_22 = 0;
            Imposable_bareme_22_Abs = 0;
            SDB = 0;
            SDBAbsence = 0;
            RappelSDB = 0;
            RappelSDBAbsence = 0;
            IEP = 0;
            IEP_Ext = 0;
            Irg_bareme = 0;
            Irg_bareme_Abs = 0;
            Irg_taux = 0;
            Irg_taux_Abs = 0;
            Ss_bareme = 0;
            SS_Bareme_Abs = 0;
            SS_Taux = 0;
            SS_Taux_Abs = 0;
            mutuelle = 0;
            mutuelleAbs = 0;
            SU = 0;
            SU_Partiel = 0;
            AF = 0;
            AF_Majoration = 0;
            AF_Global = 0;
            Prime_Scol = 0;
            Prime_Scol_Partiel = 0;
            Retenu_Pret = 0;
            Retenu_Global = 0;
            DRet = 0;
            VRet = 0;
            IFSP = 0;
            NUIS = 0;
            Guichet = 0;
            Prime_Pannier = 0;
            Prime_Transport = 0;
            PRI = 0;
            Prime_Km = 0;
            Sujétion = 0;
            Variable = 0;
            Prime_Except = 0;
            Prime_Victime = 0;
            Incapacite_Perman = 0;
            Indem1 = 0;
            Indem2 = 0;
            Indem3 = 0;
            Indem4 = 0;
            Indem5 = 0;
            Indem6 = 0;
            Indem7 = 0;
            Indem8 = 0;
            Indem9 = 0;
            Indem10 = 0;
            Indem11 = 0;
            Indem12 = 0;
            Indem13 = 0;
            Indem14 = 0;
            Indem15 = 0;
            Indem16 = 0;
            Indem17 = 0;
            Indem18 = 0;
            Indem19 = 0;
            Indem20 = 0;
            Indem21 = 0;
            Indem22 = 0;
            Indem23 = 0;
            Indem24 = 0;
            Indem25 = 0;
            Indem26 = 0;
            Indem27 = 0;
            Indem28 = 0;
            Indem29 = 0;
            Indem30 = 0;
            HSUP_100 = 0;
            HSUP_150 = 0;
            HSUP_200 = 0;
            HSUP_50 = 0;
            HSUP_75 = 0;
            Ind_Log = 0;
            Ind_Veh = 0;
            Presentation = 0;
            Ind_Mission = 0;
            PP = 0;
            PP1 = 0;
            PP2 = 0;
            PP3 = 0;
            cacobatph = 0;
            chomage_intemperie = 0;
            ShiftNuit = 0;
            PMG = 0;
            Indem_Conge = 0;
            Indem_Conge_Recup = 0;
            Indem_Conge_Recup_Abs = 0;
        }

        public void Remise_A_0_Indem_Paye()
        {
            foreach (paye_indem indem in this.paye_indems)
            {
                indem.Montant = 0;
                indem.Montant_Absence = 0;
            }
        }

        public void InsererIndemnitePersonne()
        {
            foreach (Indem_Personne Indemnite in personne.Indem_Personnes)
            {
                if (Indemnite.Indem.Cod_indem_interne != null)
                {
                    Session currentSession = this.Session;
                    paye_indem IndemniteAInserer = new paye_indem(currentSession);
                    IndemniteAInserer.Indemnite = Indemnite.Indem;
                    IndemniteAInserer.IBase = Indemnite.Base;
                    IndemniteAInserer.INbr = Indemnite.INbr;
                    IndemniteAInserer.ITaux = Indemnite.Taux;
                    IndemniteAInserer.Montant = Indemnite.Montant;
                    IndemniteAInserer.ModifSpecial = Indemnite.ModifSpecial;

                    paye_indems.Add(IndemniteAInserer);


                    //selectedObject.Save();

                }
            }
        }

        public void InitialisationPaye()
        {
            LaFonction = personne.LaFonction;

            if (personne.Fonction_Stagière != null)
                fFonction_Stagière = personne.Fonction_Stagière;

            Categori = personne.Categori;
            Nbr_enf = personne.Nbr_enf;
            Nbr_enf_M10 = personne.Nbr_enf_M10;
            Nbr_enf_p10 = personne.Nbr_enf_p10;
            Nbr_enf_Scol = personne.Nbr_enf_Scol;

            if (Unite == null)
                if (personne.unite != null)
                    Unite = personne.unite;

            if (Sit_fam == null)
                if (personne.Sit_fam != null)
                    Sit_fam = personne.Sit_fam;

            if (Sit_Emp == null)
                if (personne.Sit_Emp != null)
                    Sit_Emp = personne.Sit_Emp;

            if (Sit_Conjoint == null)
                if (personne.Sit_Conjoint != null)
                    Sit_Conjoint = personne.Sit_Conjoint;

            Soumis_à_l_IRG = personne.Soumis_à_l_IRG;
            Soumis_à_la_Sécurité_Sociale = personne.Soumis_à_la_Sécurité_Sociale;
            Soumis_Cacobatph = personne.Soumis_Cacobatph;
            TAUX_IEP = personne.TAUX_IEP;
            TAUX_IEP_Ext = personne.TAUX_IEP_Ext;

            Ok_Mutuel = personne.Ok_mutuel;
            Taux_Mutuel = personne.Taux_Mutuel;
            Taux_SS = personne.Taux_SS;
            Taux_IRG = personne.Taux_IRG;
            Taux_cacobatph = personne.Taux_cacobatph;
            Taux_chomage_intemperie = personne.Taux_chomage_intemperie;
            Taux_chomage_intemperiePO = personne.Taux_chomage_intemperiePO;
            Plafond_mutuelle = personne.Plafond_mutuelle;
            Bloque_Paye = personne.Bloque_Paye;
            AF_Partiel = personne.AF_Partiel;
            Nbr_Ans_Trv_Ext_Etat = personne.Nbr_Ans_Trv_Ext_Etat;
            Nbr_Ans_Trv_Ext_Prv = personne.Nbr_Ans_Trv_Ext_Prv;
            Nbr_Ans_Trv_Int = personne.Nbr_Ans_Trv_Int;
            if (personne.Nbr_jour_tra != 0)
                Nbr_jour_tra = personne.Nbr_jour_tra;
            if (personne.Nbr_Jour_Tra_Prime != 0)
                Nbr_Jour_Tra_Prime = personne.Nbr_Jour_Tra_Prime;

            if (personne.Corps != null)
                Corps = personne.Corps;
            Motif = personne.Motif;
            if (personne.Mode_Paiement != null)
                Mode_Paiement = personne.Mode_Paiement;

            if (personne.Taux_PP == 0)
                Taux_pp = parametres.Taux_pp;
            else
                Taux_pp = personne.Taux_PP;

            if (personne.Taux_pp1 == 0)
                Taux_pp1 = parametres.Taux_pp1;
            else
                Taux_pp1 = personne.Taux_pp1;

            if (personne.Taux_pp2 == 0)
                Taux_pp2 = parametres.Taux_pp2;
            else
                Taux_pp2 = personne.Taux_pp2;

            if (personne.Taux_pp3 == 0)
                Taux_pp3 = parametres.Taux_pp3;
            else
                Taux_pp3 = personne.Taux_pp3;

            Montant_SDB = personne.Montant_SDB;

            //ModeCalculConge = parametres.ModeCalculConge;
            ShiftNuitCR = parametres.ShiftNuitCR;
            HeureDebutShiftNuit = parametres.HeureDebutShiftNuit;
            NbrHeurerShiftNuit = parametres.NbrHeuresShiftNuit;
            NbrJrsTrvPrJrsCR = parametres.NbrJrsTrvPrJrsCR;
            NbrJrsCRPrJrsTrv = parametres.NbrJrsCRPrJrsTrv;


        }

        public void CalculNbrJrsAbs()
        {
            Nbr_jour_abs_Entr = 0;
            Nbr_jour_abs_Sort = 0;
            int nbrEtr = 0;
            int nbrSrt = 0;

            if (personne.Dat_entre != DateTime.MinValue)
            {
                int mois = Convert.ToInt16(Mois);
                if (mois != 13 && mois != 14 && mois != 15)
                {
                    DateTime date = new DateTime(Annee, mois, parametres.Jr_Debut_Mois);

                    if (personne.Dat_entre.Year == Annee)
                        if (personne.Dat_entre.Month == mois || personne.Dat_entre.Month == mois + 1)
                            if (Nbr_jour_tra == 30)
                            {
                                nbrEtr = AbsEntree.DaysWithWeekends(date, personne.DateRecrutement, parametres.Jr_Debut_Mois);
                                Nbr_jour_abs_Entr = nbrEtr;
                            }
                            else
                                if (Nbr_jour_tra == 26)
                                {
                                    nbrEtr = AbsEntree.DaysWith2Weekends(date, personne.DateRecrutement, parametres.Jr_Debut_Mois);
                                    Nbr_jour_abs_Entr = nbrEtr;
                                }
                                else
                                {
                                    nbrEtr = AbsEntree.DaysIgnoreWeekends(date, personne.DateRecrutement, parametres.Jr_Debut_Mois);
                                    Nbr_jour_abs_Entr = nbrEtr;
                                }
                }
            }

            if (personne.Dat_sortie != DateTime.MinValue)
            {
                int mois = Convert.ToInt16(Mois);
                if (mois != 13 && mois != 14 && mois != 15)
                {
                    DateTime date = new DateTime(Annee, mois, 30);

                    if (personne.Dat_sortie.Year == Annee)
                        if (personne.Dat_sortie.Month == mois || personne.Dat_sortie.Month == mois + 1)
                            if (Nbr_jour_tra == 30)
                            {
                                nbrSrt = AbsSortie.DaysWithWeekends(personne.Dat_sortie, date, parametres.Jr_Debut_Mois);
                                Nbr_jour_abs_Sort = nbrSrt;
                            }
                            else
                                if (Nbr_jour_tra == 26)
                                {
                                    nbrSrt = AbsSortie.DaysWith2Weekends(personne.Dat_sortie, date, parametres.Jr_Debut_Mois);
                                    Nbr_jour_abs_Sort = nbrSrt;
                                }
                                else
                                {
                                    nbrSrt = AbsSortie.DaysIgnoreWeekends(personne.Dat_sortie, date, parametres.Jr_Debut_Mois);
                                    Nbr_jour_abs_Sort = nbrSrt;
                                }
                }
            }
        }

        public void CalculerSDB()
        {
            bool modifspecSDB = If_ModifSpec("SDB");
            bool existSDB = If_Exist("SDB");

            decimal xSDB = 0;
            decimal xSDBAbsence = 0;

            if (existSDB == true)
            {
                if (modifspecSDB == true)
                { 
                        SDB = Get_Montant("SDB");
                        SDBAbsence = Calculerabsence(SDB, Nbr_jour_tra, false);  
                }
                else
                {
                    if (Montant_SDB != 0)
                    { 
                            SDB = Montant_SDB;
                            SDBAbsence = Calculerabsence(SDB, Nbr_jour_tra, false); 
                    }
                    else
                        if (Categori != null)
                        {
                            SDB = (decimal)Categori.SDB;// *(decimal)(Nbr_jour_tra - Nbr_Jrs_Cong_Recup) / (decimal)Nbr_jour_tra;
                            SDBAbsence = Calculerabsence(SDB, Nbr_jour_tra, false);
                        }
                        else
                        {
                            SDB = xSDB;
                            SDBAbsence = xSDBAbsence;
                        }
                }
            }
            else
            {
                SDB = 0;
                SDBAbsence = 0;
            }
        }

        public void CalculerIEP()
        {
            bool modifspecIEP = If_ModifSpec("IEP");
            bool existIEP = If_Exist("IEP");

            bool modifspecIEP_Ext = If_ModifSpec("IEP_Ext");
            bool existIEP_Ext = If_Exist("IEP_Ext");

            if (parametres.Limite_Iep == true)
            {
                if (TAUX_IEP > parametres.Limite_Iep_à)
                    TAUX_IEP = parametres.Limite_Iep_à;
            }
            else
                if (TAUX_IEP < 0)
                    TAUX_IEP = 0;

            decimal xIEP = (SDB * (decimal)TAUX_IEP) / 100;
            xIEP = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, xIEP);

            if (parametres.Limite_Iep_ext == true)
            {
                if (TAUX_IEP_Ext > parametres.Limite_Iep_ext_à)
                    TAUX_IEP_Ext = parametres.Limite_Iep_ext_à;
            }
            else
                if (TAUX_IEP_Ext < 0)
                    TAUX_IEP_Ext = 0;

            decimal xIEP_Ext = (SDB * (decimal)TAUX_IEP_Ext) / 100;
            xIEP_Ext = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, xIEP_Ext);

            if (existIEP == true)
            {
                if (modifspecIEP == false)
                {
                    IEP = xIEP;
                }
                else
                    IEP = Get_Montant("IEP");
            }
            else
            {
                IEP = 0;
            }

            if (existIEP_Ext == true)
            {
                if (modifspecIEP_Ext == false)
                {
                    IEP_Ext = xIEP_Ext;
                }
                else
                    IEP_Ext = Get_Montant("IEP_Ext");
            }
            else
            {
                IEP_Ext = 0;
            }
        }

        public void CalculerRappelSDB()
        {
            bool existRappelSDB = If_Exist("RappelSDB");

            if (existRappelSDB == true)
            {
                RappelSDB = Get_Montant("RappelSDB");
                RappelSDBAbsence = RappelSDB;
            }
            else
            {
                RappelSDB = 0;
                RappelSDBAbsence = 0;
            }
        }

        public void CalculerNbrHS()
        {
            Taux_HS = (double)SDB / Nbr_heure_ouv;
            Taux_HS = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Taux_HS);

            Indem Indem_HSUP_50 = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "HSUP_50"));
            if (Indem_HSUP_50 != null)
            {
                paye_indem PI_HSUP_50 = Session.FindObject<paye_indem>(CriteriaOperator.Parse("Indemnite==?", Indem_HSUP_50));
                if (PI_HSUP_50 != null)
                    if (PI_HSUP_50.INbr == 0)
                        PI_HSUP_50.INbr = Nbr_heure_50;
            }

            Indem Indem_HSUP_75 = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "HSUP_50"));
            if (Indem_HSUP_75 != null)
            {
                paye_indem PI_HSUP_75 = Session.FindObject<paye_indem>(CriteriaOperator.Parse("Indemnite==?", Indem_HSUP_75));
                if (PI_HSUP_75 != null)
                    if (PI_HSUP_75.INbr == 0)
                        PI_HSUP_75.INbr = Nbr_heure_75;
            }

            Indem Indem_HSUP_100 = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "HSUP_100"));
            if (Indem_HSUP_100 != null)
            {
                paye_indem PI_HSUP_100 = Session.FindObject<paye_indem>(CriteriaOperator.Parse("Indemnite==?", Indem_HSUP_100));
                if (PI_HSUP_100 != null)
                    if (PI_HSUP_100.INbr == 0)
                        PI_HSUP_100.INbr = Nbr_heure_50;
            }

            Indem Indem_HSUP_150 = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "HSUP_50"));
            if (Indem_HSUP_150 != null)
            {
                paye_indem PI_HSUP_150 = Session.FindObject<paye_indem>(CriteriaOperator.Parse("Indemnite==?", Indem_HSUP_150));
                if (PI_HSUP_150 != null)
                    if (PI_HSUP_150.INbr == 0)
                        PI_HSUP_150.INbr = Nbr_heure_50;
            }

            Indem Indem_HSUP_200 = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "HSUP_200"));
            if (Indem_HSUP_200 != null)
            {
                paye_indem PI_HSUP_200 = Session.FindObject<paye_indem>(CriteriaOperator.Parse("Indemnite==?", Indem_HSUP_200));
                if (PI_HSUP_200 != null)
                    if (PI_HSUP_200.INbr == 0)
                        PI_HSUP_200.INbr = Nbr_heure_50;
            }

        }

        public void CalculerPRI()
        {
            if (Note_Perso_Pri > 25)
                Note_Perso_Pri = 25;

            PRI = SDB * (decimal)(Note_Perso_Pri / 100);
        }

        public void Inserer_Indem_Conge(double Nbr)
        {
            Indem IndemniteConge = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "Indem_Conge"));
            Indem IndemniteBrutCotis = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "Brute_cotisable"));
            Indem IndemniteSS = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "SS"));
            Indem IndemniteBrutImpo = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "Brute_imposable"));
            Indem IndemniteIRG = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "IRG"));
            Indem IndemniteNET = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "NET"));

            if (IndemniteConge != null)
            {
                paye_indem IndemniteAInserer = new paye_indem(Session);
                IndemniteAInserer.Indemnite = IndemniteConge;
                IndemniteAInserer.INbr = Nbr;
                IndemniteAInserer.Paye = this;

                paye_indems.Add(IndemniteAInserer);
            }

            if (IndemniteBrutCotis != null)
            {
                paye_indem IndemniteAInserer = new paye_indem(Session);
                IndemniteAInserer.Indemnite = IndemniteBrutCotis;
                IndemniteAInserer.Paye = this;

                paye_indems.Add(IndemniteAInserer);
            }

            if (IndemniteSS != null)
            {
                paye_indem IndemniteAInserer = new paye_indem(Session);
                IndemniteAInserer.Indemnite = IndemniteSS;
                IndemniteAInserer.Paye = this;

                paye_indems.Add(IndemniteAInserer);
            }

            if (IndemniteBrutImpo != null)
            {
                paye_indem IndemniteAInserer = new paye_indem(Session);
                IndemniteAInserer.Indemnite = IndemniteBrutImpo;
                IndemniteAInserer.Paye = this;

                paye_indems.Add(IndemniteAInserer);
            }

            if (IndemniteIRG != null)
            {
                paye_indem IndemniteAInserer = new paye_indem(Session);
                IndemniteAInserer.Indemnite = IndemniteIRG;
                IndemniteAInserer.Paye = this;

                paye_indems.Add(IndemniteAInserer);
            }

            if (IndemniteNET != null)
            {
                paye_indem IndemniteAInserer = new paye_indem(Session);
                IndemniteAInserer.Indemnite = IndemniteNET;
                IndemniteAInserer.Paye = this;

                paye_indems.Add(IndemniteAInserer);
            }
        }

        public void Calculer_Indem_Conge()
        {
            bool modifspecIndem_Conge = If_ModifSpec("Indem_Conge");
            bool existIndem_Conge = If_Exist("Indem_Conge");

            decimal xindem_cong = 0;

            //if (parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuel || parametres.ModeCalculConge == Mode_Calcul_Conge.CongeAnnuelRecuperation)
            if (existIndem_Conge == true)
            {
                if (modifspecIndem_Conge != true)
                {
                    if (cat_paye == CategoriePaye.Congé)
                    {
                        double Nbr = Get_Nbr("Indem_Conge");

                        if (Nbr <= 30)
                        {
                            if (Conge_Calcule == false)
                            {
                                if (Nbr <= personne.Nbr_Jrs_Cong_Accor)
                                {
                                    Nbr_Jrs_Cong = Nbr;
                                    personne.Nbr_Jrs_Cong_Accor -= Nbr_Jrs_Cong;
                                    personne.Nbr_Jrs_Cong_Accor = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Accor);
                                    Conge_Calcule = true;
                                    xindem_cong = Calculer_Conge();
                                }
                                else
                                {
                                    Indem Indem_Cong = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "Indem_Conge"));
                                    if (Indem_Cong.Form_cal != null)
                                        MessageBox.Show("Nombre jours congé a dépassé le nombre de jours accordé pour cet employé !");
                                }
                            }
                            else
                                if (Nbr_Jrs_Cong != Nbr)
                                {
                                    personne.Nbr_Jrs_Cong_Accor += Nbr_Jrs_Cong;
                                    personne.Nbr_Jrs_Cong_Accor = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Accor);
                                    if (Nbr <= personne.Nbr_Jrs_Cong_Accor)
                                    {
                                        Nbr_Jrs_Cong = Nbr;
                                        personne.Nbr_Jrs_Cong_Accor -= Nbr_Jrs_Cong;
                                        personne.Nbr_Jrs_Cong_Accor = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Accor);
                                        xindem_cong = Calculer_Conge();
                                    }
                                    else
                                    {
                                        Indem Indem_Cong = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "Indem_Conge"));
                                        if (Indem_Cong.Form_cal != null)
                                            MessageBox.Show("Nombre jours congé a dépassé le nombre de jours accordé pour cet employé !");
                                    }
                                }
                        }
                        else
                        {
                            MessageBox.Show("Nombre jours congé ne peut être plus que 30 jours !");
                        }
                        Indem_Conge = xindem_cong;
                    }
                }
                else
                    Indem_Conge = Get_Montant("Indem_Conge");
            }
            else
                Indem_Conge = 0;
        }

        public decimal Calculer_Conge()
        {
            string database = "";
            //((SQLiteConnection)Application.Connection).DataSource;
            //Session.Connection.ConnectionString..

            if (Session.Connection is SQLiteConnection)
                database = ((SQLiteConnection)Session.Connection).DataSource;
            else
                if (Session.Connection is SqlConnection)
                    database = ((SqlConnection)Session.Connection).Database;

            string dossier = database.Substring(0, database.Length - 4);
            int exercice = int.Parse(database.Substring(database.Length - 4, 4));
            string BaseNamePass = dossier + (exercice - 1).ToString();

            string ConnectionPass = "";
            if (Session.Connection is SqlConnection)
                ConnectionPass = string.Format("Integrated Security=false;Pooling=false;Data Source={0}{1};Initial Catalog={2}; User ID=sa;Password=58206670",
                    Helper.serverName, Helper.instanceName, BaseNamePass);
            else
                ConnectionPass = string.Format(@"XpoProvider=SQLite;Data Source={0}\\Data\\{1}\\{2}",
                                 Core.GetApplicationPath(), dossier, BaseNamePass);
            
            Session SessionPass = new Session();
            SessionPass.ConnectionString = ConnectionPass;

            decimal brut_Janv_pass = 0;
            decimal brut_Fev_pass = 0;
            decimal brut_Mars_pass = 0;
            decimal brut_Avr_pass = 0;
            decimal brut_Mai_pass = 0;
            decimal brut_Juin_pass = 0;
            decimal brut_Juill_pass = 0;
            decimal brut_Aout_pass = 0;
            decimal brut_Sept_pass = 0;
            decimal brut_Oct_pass = 0;
            decimal brut_Nouv_pass = 0;
            decimal brut_Dec_pass = 0;

            decimal brut_Janv_cour = 0;
            decimal brut_Fev_cour = 0;
            decimal brut_Mars_cour = 0;
            decimal brut_Avr_cour = 0;
            decimal brut_Mai_cour = 0;
            decimal brut_Juin_cour = 0;
            decimal brut_Juill_cour = 0;
            decimal brut_Aout_cour = 0;
            decimal brut_Sept_cour = 0;
            decimal brut_Oct_cour = 0;
            decimal brut_Nouv_cour = 0;
            decimal brut_Dec_cour = 0;

            decimal brut_annee_passe = 0;
            decimal brut_annee_courante = 0;
            decimal brut_annuel = 0;

            int anneepass = exercice - 1;
            CriteriaOperator criteriaPers1 = CriteriaOperator.Parse("Cod_personne=?", personne.Cod_personne);
            CriteriaOperator criteriaPers2 = CriteriaOperator.Parse("FullName==?", personne.FullName);
            Personne pers_annee_passe = SessionPass.FindObject<Personne>(CriteriaOperator.And(criteriaPers1, criteriaPers2));

            if (pers_annee_passe != null)
            {
                CriteriaOperator criteriaP1 = CriteriaOperator.Parse("personne=?", pers_annee_passe.Oid);
                CriteriaOperator criteriaP3 = CriteriaOperator.Parse("Annee==?", anneepass.ToString());
                Recape_Annuelle recape_annee_passe = SessionPass.FindObject<Recape_Annuelle>(CriteriaOperator.And(criteriaP1, criteriaP3));

                if (recape_annee_passe != null)
                {
                    brut_Janv_pass = recape_annee_passe.Brut_Cotis_Janv;
                    brut_Fev_pass = recape_annee_passe.Brut_Cotis_Fev;
                    brut_Mars_pass = recape_annee_passe.Brut_Cotis_Mars;
                    brut_Avr_pass = recape_annee_passe.Brut_Cotis_Avr;
                    brut_Mai_pass = recape_annee_passe.Brut_Cotis_Mai;
                    brut_Juin_pass = recape_annee_passe.Brut_Cotis_Juin;
                    brut_Juill_pass = recape_annee_passe.Brut_Cotis_Juill;
                    brut_Aout_pass = recape_annee_passe.Brut_Cotis_Aout;
                    brut_Sept_pass = recape_annee_passe.Brut_Cotis_Sept;
                    brut_Oct_pass = recape_annee_passe.Brut_Cotis_Oct;
                    brut_Nouv_pass = recape_annee_passe.Brut_Cotis_Nouv;
                    brut_Dec_pass = recape_annee_passe.Brut_Cotis_Dec;
                }
            }

            CriteriaOperator criteriaC1 = CriteriaOperator.Parse("personne=?", personne.Oid);
            CriteriaOperator criteriaC2 = CriteriaOperator.Parse("Annee==?", Annee.ToString());
            Recape_Annuelle recape_annee_courante = Session.FindObject<Recape_Annuelle>(CriteriaOperator.And(criteriaC1, criteriaC2));

            if (recape_annee_courante != null)
            {
                brut_Janv_cour = recape_annee_courante.Brut_Cotis_Janv;
                brut_Fev_cour = recape_annee_courante.Brut_Cotis_Fev;
                brut_Mars_cour = recape_annee_courante.Brut_Cotis_Mars;
                brut_Avr_cour = recape_annee_courante.Brut_Cotis_Avr;
                brut_Mai_cour = recape_annee_courante.Brut_Cotis_Mai;
                brut_Juin_cour = recape_annee_courante.Brut_Cotis_Juin;
                brut_Juill_cour = recape_annee_courante.Brut_Cotis_Juill;
                brut_Aout_cour = recape_annee_courante.Brut_Cotis_Aout;
                brut_Sept_cour = recape_annee_courante.Brut_Cotis_Sept;
                brut_Oct_cour = recape_annee_courante.Brut_Cotis_Oct;
                brut_Nouv_cour = recape_annee_courante.Brut_Cotis_Nouv;
                brut_Dec_cour = recape_annee_courante.Brut_Cotis_Dec;
            }

            int Mois_debut = Convert.ToInt16(parametres.Mois_debut_Cong);
            int Mois_fin = Convert.ToInt16(parametres.Mois_fin_Cong);

            switch (Mois_debut)
            {
                case 1:
                    {
                        brut_annee_passe = brut_Janv_pass + brut_Fev_pass + brut_Mars_pass + brut_Avr_pass + brut_Mai_pass + brut_Juin_pass + brut_Juill_pass + brut_Aout_pass + brut_Sept_pass + brut_Oct_pass + brut_Nouv_pass + brut_Dec_pass;
                    }
                    break;
                case 2:
                    {
                        brut_annee_passe = brut_Fev_pass + brut_Mars_pass + brut_Avr_pass + brut_Mai_pass + brut_Juin_pass + brut_Juill_pass + brut_Aout_pass + brut_Sept_pass + brut_Oct_pass + brut_Nouv_pass + brut_Dec_pass;
                    }
                    break;
                case 3:
                    {
                        brut_annee_passe = brut_Mars_pass + brut_Avr_pass + brut_Mai_pass + brut_Juin_pass + brut_Juill_pass + brut_Aout_pass + brut_Sept_pass + brut_Oct_pass + brut_Nouv_pass + brut_Dec_pass;
                    }
                    break;
                case 4:
                    {
                        brut_annee_passe = brut_Avr_pass + brut_Mai_pass + brut_Juin_pass + brut_Juill_pass + brut_Aout_pass + brut_Sept_pass + brut_Oct_pass + brut_Nouv_pass + brut_Dec_pass;
                    }
                    break;
                case 5:
                    {
                        brut_annee_passe = brut_Mai_pass + brut_Juin_pass + brut_Juill_pass + brut_Aout_pass + brut_Sept_pass + brut_Oct_pass + brut_Nouv_pass + brut_Dec_pass;
                    }
                    break;
                case 6:
                    {
                        brut_annee_passe = brut_Juin_pass + brut_Juill_pass + brut_Aout_pass + brut_Sept_pass + brut_Oct_pass + brut_Nouv_pass + brut_Dec_pass;
                    }
                    break;
                case 7:
                    {
                        brut_annee_passe = brut_Juill_pass + brut_Aout_pass + brut_Sept_pass + brut_Oct_pass + brut_Nouv_pass + brut_Dec_pass;
                    }
                    break;
                case 8:
                    {
                        brut_annee_passe = brut_Aout_pass + brut_Sept_pass + brut_Oct_pass + brut_Nouv_pass + brut_Dec_pass;
                    }
                    break;
                case 9:
                    {
                        brut_annee_passe = brut_Sept_pass + brut_Oct_pass + brut_Nouv_pass + brut_Dec_pass;
                    }
                    break;
                case 10:
                    {
                        brut_annee_passe = brut_Oct_pass + brut_Nouv_pass + brut_Dec_pass;
                    }
                    break;
                case 11:
                    {
                        brut_annee_passe = brut_Nouv_pass + brut_Dec_pass;
                    }
                    break;
                case 12:
                    {
                        brut_annee_passe = brut_Dec_pass;
                    }
                    break;
            }

            switch (Mois_fin)
            {
                case 1:
                    {
                        brut_annee_courante = brut_Janv_cour;
                    }
                    break;
                case 2:
                    {
                        brut_annee_courante = brut_Janv_cour + brut_Fev_cour;
                    }
                    break;
                case 3:
                    {

                        brut_annee_courante = brut_Janv_cour + brut_Fev_cour + brut_Mars_cour;
                    }
                    break;
                case 4:
                    {
                        brut_annee_courante = brut_Janv_cour + brut_Fev_cour + brut_Mars_cour + brut_Avr_cour;
                    }
                    break;
                case 5:
                    {
                        brut_annee_courante = brut_Janv_cour + brut_Fev_cour + brut_Mars_cour + brut_Avr_cour + brut_Mai_cour;
                    }
                    break;
                case 6:
                    {

                        brut_annee_courante = brut_Janv_cour + brut_Fev_cour + brut_Mars_cour + brut_Avr_cour + brut_Mai_cour + brut_Juin_cour;
                    }
                    break;
                case 7:
                    {
                        brut_annee_courante = brut_Janv_cour + brut_Fev_cour + brut_Mars_cour + brut_Avr_cour + brut_Mai_cour + brut_Juin_cour + brut_Juill_cour;
                    }
                    break;
                case 8:
                    {
                        brut_annee_courante = brut_Janv_cour + brut_Fev_cour + brut_Mars_cour + brut_Avr_cour + brut_Mai_cour + brut_Juin_cour + brut_Juill_cour + brut_Aout_cour;
                    }
                    break;
                case 9:
                    {
                        brut_annee_courante = brut_Janv_cour + brut_Fev_cour + brut_Mars_cour + brut_Avr_cour + brut_Mai_cour + brut_Juin_cour + brut_Juill_cour + brut_Aout_cour + brut_Sept_cour;
                    }
                    break;
                case 10:
                    {
                        brut_annee_courante = brut_Janv_cour + brut_Fev_cour + brut_Mars_cour + brut_Avr_cour + brut_Mai_cour + brut_Juin_cour + brut_Juill_cour + brut_Aout_cour + brut_Sept_cour + brut_Oct_cour;
                    }
                    break;
                case 11:
                    {
                        brut_annee_courante = brut_Janv_cour + brut_Fev_cour + brut_Mars_cour + brut_Avr_cour + brut_Mai_cour + brut_Juin_cour + brut_Juill_cour + brut_Aout_cour + brut_Sept_cour + brut_Oct_cour + brut_Nouv_cour;
                    }
                    break;
                case 12:
                    {
                        brut_annee_courante = brut_Janv_cour + brut_Fev_cour + brut_Mars_cour + brut_Avr_cour + brut_Mai_cour + brut_Juin_cour + brut_Juill_cour + brut_Aout_cour + brut_Sept_cour + brut_Oct_cour + brut_Nouv_cour + brut_Dec_cour;
                    }
                    break;
            }
            brut_annuel = brut_annee_passe + brut_annee_courante;
            decimal brut_cong = brut_annuel / 12;
            decimal xindem_cong = 0;
            xindem_cong = (brut_cong * (decimal)Nbr_Jrs_Cong) / 30;
            xindem_cong = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, xindem_cong);
            return xindem_cong;
        }

        public void Calculer_Nbr_Jrs_Conge_Recup(bool valide)
        {
            double nbr = (Nbr_jour_tra - Jour_Abs - Nbr_Jrs_Cong_Recup) / (NbrJrsTrvPrJrsCR / NbrJrsCRPrJrsTrv);
            if (valide)
            {
                personne.Nbr_Jrs_Cong_Recup_Accor += (decimal)nbr; 
                personne.Nbr_Jrs_Cong_Recup_Accor = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Recup_Accor);
            }
            else
            {
                personne.Nbr_Jrs_Cong_Recup_Accor -= (decimal)nbr; 
                personne.Nbr_Jrs_Cong_Recup_Accor =  ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Recup_Accor);
            }
        }

        public void Calculer_Indem_Conge_Recup()
        {
            bool modifspecIndem_Conge_Recup = If_ModifSpec("Indem_Conge_Recup");
            bool existIndem_Conge_Recup = If_Exist("Indem_Conge_Recup");

            decimal xindem_cong_recup = 0, MontantNCotisImpo = 0, MontantNCotisNImpo = 0;
            Indem_Conge_Recup = 0;
            Indem_Conge_Recup_Abs = 0;

            if (CRAvecPaye)
            {
                if (existIndem_Conge_Recup)
                {
                    if (!modifspecIndem_Conge_Recup)
                    {
                        if (!Conge_Calcule_Recup)
                        {
                            personne.Nbr_Jrs_Cong_Recup_Accor -= (decimal)Nbr_Jrs_Cong_Recup;
                            personne.Nbr_Jrs_Cong_Recup_Accor = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Recup_Accor);
                            
                            Conge_Calcule = true;

                            decimal NetCR = 0;
                            if (Nbr_Jrs_Cong_Recup != 0)
                            {
                                if (personne.Montant_NETCR != 0)
                                {
                                    NetCR = personne.Montant_NETCR;
                                    xindem_cong_recup = CalculInverseIndemUnique(NetCR);
                                }
                                else
                                {
                                    NetCR = personne.NET;

                                    foreach (Indem_Personne detail in personne.Indem_Personnes)
                                        if (detail.Indem.Brut_Net_Incluse != InclusBrutNet.Sans && !detail.Indem.Retenue)
                                            if (!detail.Indem.Cotisable && detail.Indem.Imposable)
                                                MontantNCotisImpo += detail.Montant;

                                    foreach (Indem_Personne detail in personne.Indem_Personnes)
                                        if (detail.Indem.Brut_Net_Incluse != InclusBrutNet.Sans && !detail.Indem.Retenue)
                                            if (!detail.Indem.Cotisable && !detail.Indem.Imposable)
                                                MontantNCotisNImpo += detail.Montant;

                                    xindem_cong_recup = CalculInverseIndemsMultiples(NetCR, MontantNCotisImpo, MontantNCotisNImpo);
                                }
                            }

                            Indem_Conge_Recup = xindem_cong_recup;
                            Indem_Conge_Recup = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Indem_Conge_Recup);
                            Indem_Conge_Recup_Abs = Indem_Conge_Recup * (decimal)Nbr_Jrs_Cong_Recup / (decimal)Nbr_jour_tra;
                            Indem_Conge_Recup_Abs = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Indem_Conge_Recup_Abs);

                            Conge_Calcule_Recup = true;
                        }
                        else
                        {
                            double Nbr = Get_Nbr("Indem_Conge_Recup");
                            personne.Nbr_Jrs_Cong_Recup_Accor += (decimal)Nbr;
                            personne.Nbr_Jrs_Cong_Recup_Accor = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Recup_Accor);

                            personne.Nbr_Jrs_Cong_Recup_Accor -= (decimal)Nbr_Jrs_Cong_Recup;
                            personne.Nbr_Jrs_Cong_Recup_Accor = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Recup_Accor);

                            decimal NetCR = 0;
                            if (Nbr_Jrs_Cong_Recup != 0)
                            {
                                if (personne.Montant_NETCR != 0)
                                {
                                    NetCR = personne.Montant_NETCR;
                                    xindem_cong_recup = CalculInverseIndemUnique(NetCR);
                                }
                                else
                                {
                                    NetCR = personne.NET;

                                    foreach (Indem_Personne detail in personne.Indem_Personnes)
                                        if (detail.Indem.Brut_Net_Incluse != InclusBrutNet.Sans && !detail.Indem.Retenue)
                                            if (!detail.Indem.Cotisable && detail.Indem.Imposable)
                                                MontantNCotisImpo += detail.Montant;

                                    foreach (Indem_Personne detail in personne.Indem_Personnes)
                                        if (detail.Indem.Brut_Net_Incluse != InclusBrutNet.Sans && !detail.Indem.Retenue)
                                            if (!detail.Indem.Cotisable && !detail.Indem.Imposable)
                                                MontantNCotisNImpo += detail.Montant;

                                    xindem_cong_recup = CalculInverseIndemsMultiples(NetCR, MontantNCotisImpo, MontantNCotisNImpo);
                                }
                            }

                            Indem_Conge_Recup = xindem_cong_recup * (decimal)Nbr_Jrs_Cong_Recup / (decimal)Nbr_jour_tra;
                            Indem_Conge_Recup = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Indem_Conge_Recup);

                            Indem_Conge_Recup_Abs = xindem_cong_recup * (decimal)Nbr_Jrs_Cong_Recup / (decimal)Nbr_jour_tra;
                            Indem_Conge_Recup_Abs = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Indem_Conge_Recup_Abs);
                        }
                    }
                    else
                    {
                        Indem_Conge_Recup = Get_Montant("Indem_Conge_Recup");
                        Indem_Conge_Recup_Abs = Indem_Conge_Recup * (decimal)Nbr_Jrs_Cong_Recup / (decimal)Nbr_jour_tra;
                    }
                }
                else
                {
                    Indem_Conge_Recup = 0;
                    Indem_Conge_Recup_Abs = 0;
                }
            }
            else
            {
                if (!Conge_Calcule_Recup)
                {
                    personne.Nbr_Jrs_Cong_Recup_Accor -= (decimal)Nbr_Jrs_Cong_Recup;
                    personne.Nbr_Jrs_Cong_Recup_Accor = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Recup_Accor);

                    Nbr_Jrs_Cong_Recup_Anc = Nbr_Jrs_Cong_Recup;
                    Conge_Calcule_Recup = true;
                }
                else
                {
                    //double Nbr = Get_Nbr("Indem_Conge_Recup");
                    personne.Nbr_Jrs_Cong_Recup_Accor += (decimal)Nbr_Jrs_Cong_Recup_Anc;
                    personne.Nbr_Jrs_Cong_Recup_Accor = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Recup_Accor);

                    personne.Nbr_Jrs_Cong_Recup_Accor -= (decimal)Nbr_Jrs_Cong_Recup;
                    personne.Nbr_Jrs_Cong_Recup_Accor = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Recup_Accor);

                    Nbr_Jrs_Cong_Recup_Anc = Nbr_Jrs_Cong_Recup;

                }
            }
        }

        public void Inserer_Indem_STC()
        {
            Indem IndemniteSTC = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "Indem_STC"));
            Indem IndemniteBrutCotis = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "Brute_cotisable"));
            Indem IndemniteSS = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "SS"));
            Indem IndemniteBrutImpo = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "Brute_imposable"));
            Indem IndemniteIRG = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "IRG"));
            Indem IndemniteNET = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "NET"));

            if (IndemniteSTC != null)
            {
                paye_indem IndemniteAInserer = new paye_indem(Session);
                IndemniteAInserer.Indemnite = IndemniteSTC;
                IndemniteAInserer.Paye = this;

                paye_indems.Add(IndemniteAInserer);
            }

            if (IndemniteBrutCotis != null)
            {
                paye_indem IndemniteAInserer = new paye_indem(Session);
                IndemniteAInserer.Indemnite = IndemniteBrutCotis;
                IndemniteAInserer.Paye = this;

                paye_indems.Add(IndemniteAInserer);
            }

            if (IndemniteSS != null)
            {
                paye_indem IndemniteAInserer = new paye_indem(Session);
                IndemniteAInserer.Indemnite = IndemniteSS;
                IndemniteAInserer.Paye = this;

                paye_indems.Add(IndemniteAInserer);
            }

            if (IndemniteBrutImpo != null)
            {
                paye_indem IndemniteAInserer = new paye_indem(Session);
                IndemniteAInserer.Indemnite = IndemniteBrutImpo;
                IndemniteAInserer.Paye = this;

                paye_indems.Add(IndemniteAInserer);
            }

            if (IndemniteIRG != null)
            {
                paye_indem IndemniteAInserer = new paye_indem(Session);
                IndemniteAInserer.Indemnite = IndemniteIRG;
                IndemniteAInserer.Paye = this;

                paye_indems.Add(IndemniteAInserer);
            }

            if (IndemniteNET != null)
            {
                paye_indem IndemniteAInserer = new paye_indem(Session);
                IndemniteAInserer.Indemnite = IndemniteNET;
                IndemniteAInserer.Paye = this;

                paye_indems.Add(IndemniteAInserer);
            }
        }

        public void Calculer_Indem_STC()
        {
            bool modifspecIndem_stc = If_ModifSpec("Indem_STC");
            bool existIndem_stc = If_Exist("Indem_STC");

            decimal xindem_stc = 0;

            if (existIndem_stc == true)
            {
                if (modifspecIndem_stc != true)
                {
                    if (Nbr_Jrs_Cong == 0)
                    {
                        Nbr_Jrs_Cong = personne.Nbr_Jrs_Cong_Accor;
                        personne.Nbr_Jrs_Cong_Accor = 0;
                    }
                    xindem_stc = Calculer_Conge();

                    Indem IndemniteSTC = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "Indem_STC"));
                    CriteriaOperator criteria1 = CriteriaOperator.Parse("Indemnite==?", IndemniteSTC.Oid.ToString());
                    CriteriaOperator criteria2 = CriteriaOperator.Parse("Paye==?", this);
                    paye_indem paye_indem_stc = this.Session.FindObject<paye_indem>(CriteriaOperator.And(criteria1, criteria2));
                    paye_indem_stc.INbr = Nbr_Jrs_Cong;
                    Indem_STC = xindem_stc;
                }
                else
                    Indem_STC = Get_Montant("Indem_STC");
            }
            else
                Indem_STC = 0;
        }

        public void Calculer_PMG()
        {
            if (If_Exist("PMG"))
            {
                if (!If_ModifSpec("PMG"))
                {
                    CriteriaOperator criteria1 = CriteriaOperator.Parse("Employe ==?", personne);
                    CriteriaOperator criteria2 = CriteriaOperator.Parse("Mois ==?", Mois);
                    PrimePMG primePMG = this.Session.FindObject<PrimePMG>(CriteriaOperator.And(criteria1, criteria2));

                    decimal montantPMG = 0;
                    if (primePMG != null)
                    {
                        PrimePMG = primePMG;
                        foreach (PMGMois pmgmois in primePMG.pMGMois)
                        {
                            double Nbr = pmgmois.Nbr;
                            decimal montant = 0;

                            CriteriaOperator criteria1bareme = CriteriaOperator.Parse("BorneInférieure<=?", Nbr);
                            CriteriaOperator criteria2bareme = CriteriaOperator.Parse("BorneSupérieure>=?", Nbr);
                            BaremePMG bareme = this.Session.FindObject<BaremePMG>(CriteriaOperator.And(criteria1bareme, criteria2bareme));

                            if (bareme != null)
                                montant = bareme.Montant;
                            else
                                montant = 0;

                            montantPMG += montant;

                            pmgmois.Montant = montant;
                            pmgmois.Save();
                        }
                    }
                    PMG = montantPMG;
                }
                else
                    PMG = Get_Montant("PMG");
            }
            else
                PMG = 0;
        }

        public void Calculer_ShiftNuit()
        {
            if (!ShiftNuitCR)
            {
                if (If_Exist("ShiftNuit"))
                {
                    if (!If_ModifSpec("ShiftNuit"))
                    {
                        CriteriaOperator criteria1 = CriteriaOperator.Parse("Employe ==?", personne);
                        CriteriaOperator criteria2 = CriteriaOperator.Parse("Mois ==?", Mois);
                        PrimeShiftNuit primeShiftNuit = this.Session.FindObject<PrimeShiftNuit>(CriteriaOperator.And(criteria1, criteria2));

                        decimal montantShiftNuit = 0;
                        if (primeShiftNuit != null)
                        {
                            PrimeShiftNuit = primeShiftNuit;
                            foreach (ShiftNuitMois shiftnuitmois in primeShiftNuit.shiftNuitMois)
                            {
                                XPCollection<BaremeShiftNuit> bareme = new XPCollection<BaremeShiftNuit>(Session);

                                if (bareme.Count != 0)
                                {
                                    TimeSpan borninf = HeureDebutShiftNuit;
                                    decimal montant = 0;
                                    double dif = shiftnuitmois.Nbr;
                                    int i = 0;
                                    while (i <= bareme.Count && dif > 0)
                                    {

                                        CriteriaOperator criteria1bareme = CriteriaOperator.Parse("BorneInférieure==?", borninf);
                                        BaremeShiftNuit baremeShN = this.Session.FindObject<BaremeShiftNuit>(CriteriaOperator.And(criteria1bareme));

                                        if (baremeShN != null)
                                        {
                                            TimeSpan bornsup = baremeShN.BorneSupérieure;
                                            double nbr = 0;

                                            if (baremeShN.BorneInférieureDay == baremeShN.BorneSupérieureDay)
                                                nbr = bornsup.Hours - borninf.Hours;
                                            else
                                                if (baremeShN.BorneSupérieureDay == baremeShN.BorneInférieureDay + 1)
                                                    nbr = bornsup.Hours + (24 - borninf.Hours);

                                            montant += baremeShN.Montant;

                                            dif -= nbr;
                                            borninf = bornsup;
                                            i += 1;
                                        }
                                        else
                                            i += 1;
                                    }
                                    shiftnuitmois.Montant = montant;
                                    shiftnuitmois.Save();
                                }
                                montantShiftNuit += shiftnuitmois.Montant;
                            }
                        }
                        ShiftNuit = montantShiftNuit;
                    }
                    else
                        ShiftNuit = Get_Montant("ShiftNuit");
                }
                else
                    ShiftNuit = 0;
            }
            else
            {
                CriteriaOperator criteria1 = CriteriaOperator.Parse("Employe ==?", personne);
                CriteriaOperator criteria2 = CriteriaOperator.Parse("Mois ==?", Mois);
                PrimeShiftNuit primeShiftNuit = this.Session.FindObject<PrimeShiftNuit>(CriteriaOperator.And(criteria1, criteria2));

                double NbrCR = 0;
                if (primeShiftNuit != null)
                {
                    personne.Nbr_Jrs_Cong_Recup_Accor -= NbrJrsCRSN; 
                    personne.Nbr_Jrs_Cong_Recup_Accor =  ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Recup_Accor);

                    foreach (ShiftNuitMois shiftnuitmois in primeShiftNuit.shiftNuitMois)
                        if (shiftnuitmois.Nbr > NbrHeurerShiftNuit)
                        //if (shiftnuitmois.JrsCongCalcule == false)
                        {
                            NbrCR += shiftnuitmois.Nbr * 0.05555555555555555555555555555556;
                            shiftnuitmois.JrsCongCalcule = true;
                        }
                }
                NbrJrsCRSN = (decimal)NbrCR; 
                NbrJrsCRSN = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)NbrJrsCRSN);

                personne.Nbr_Jrs_Cong_Recup_Accor += NbrJrsCRSN; 
                personne.Nbr_Jrs_Cong_Recup_Accor =  ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Recup_Accor);
            }
        }

        public decimal Calculerabsence(decimal XMontant, double XMode_calcul_absence, bool AvecCR)
        {
            decimal montant = XMontant;
            double jrs = 0;

            if (AvecCR)
                jrs = Jour_Abs + Nbr_Jrs_Cong_Recup;
            else
                jrs = Jour_Abs;

            if (XMode_calcul_absence != Nbr_jour_tra)
            {
                if (XMode_calcul_absence == Nbr_Jour_Tra_Prime)
                {
                    montant = (XMontant) * (decimal)(XMode_calcul_absence - (Nbr_jour_abs_prime)) / (decimal)XMode_calcul_absence;
                }
            }
            else
            {
                montant = (XMontant) * (decimal)(XMode_calcul_absence - jrs) / (decimal)XMode_calcul_absence;
            }

            montant = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, montant);
            return montant;
            // a enrichir selon les types de calcul d'absence
        }

        public void CalculTotaux()
        {
            decimal tempTotal = 0m;
            decimal tempTotalAbsence = 0m;
            decimal TempCotisable = 0m;
            decimal TempCotisableAbsence = 0m;
            decimal TempCotisableBareme = 0m;
            decimal TempCotisableBaremeAbsence = 0m;
            decimal TempCotisableTaux = 0m;
            decimal TempCotisableTauxAbsence = 0m;
            //decimal TempCotisableCongeRecup = 0m;
            //decimal TempCotisableCongeRecup_Abs = 0m;
            decimal TempCotisableNonImpo = 0m;
            decimal TempCotisableNonImpoAbsence = 0m;
            decimal TempImposable = 0m;
            decimal TempImposableBareme = 0m;
            decimal TempImposableTaux = 0m;
            decimal TempImposable_Abs = 0m;
            decimal TempImposableBareme_Abs = 0m;
            decimal TempImposableTaux_Abs = 0m;
            decimal TempImposable22 = 0m;
            decimal TempImposable22_Abs = 0m;
            decimal TempTotIndemImposNonCotis = 0m;
            decimal TempTotIndemImposNonCotis_Abs = 0m;
            decimal TempTotIndemNonImposNonCotis = 0m;
            decimal TempTotIndemNonImposNonCotis_Abs = 0m;
            decimal TempTotIndemNet = 0m;
            decimal TempTotIndemNet_Abs = 0m;
            //decimal TempNet = 0m;

            foreach (paye_indem detail in paye_indems)
            {
                BASE = 0;
                TAUX = 0;
                NBR = 0;
                double N = 0;

                if ((detail.Indemnite.Form_base != "") && (detail.Indemnite.Form_base != null))
                    if (detail.ModifSpecial == false)
                        BASE = (decimal)Evaluate(detail.Indemnite.Form_base);
                    else
                        BASE = (decimal)detail.IBase;
                else
                    BASE = (decimal)detail.IBase;

                if ((detail.Indemnite.Form_taux != "") && (detail.Indemnite.Form_taux != null))
                    if (detail.ModifSpecial == false)
                        TAUX = (double)Evaluate(detail.Indemnite.Form_taux);
                    else
                        TAUX = (double)detail.ITaux;
                else
                    TAUX = (double)detail.ITaux;

                if ((detail.Indemnite.Form_nbr != "") && (detail.Indemnite.Form_nbr != null))
                    if (detail.ModifSpecial == false)
                        NBR = (double)Evaluate(detail.Indemnite.Form_nbr);
                    else
                        NBR = (double)detail.INbr;
                else
                    NBR = (double)detail.INbr;

                if (detail.ModifSpecial == false)
                {
                    if ((detail.Indemnite.Form_cal != "") && (detail.Indemnite.Form_cal != null))
                        N = (double)Evaluate(detail.Indemnite.Form_cal);
                    else
                        N = (double)detail.Montant;
                }
                else
                    N = (double)detail.Montant;

                if (detail.Indemnite.Valeur_Minimale == true)
                    if (N < (double)detail.Indemnite.Valeur_Min)
                        N = (double)detail.Indemnite.Valeur_Min;

                if (detail.Indemnite.Valeur_Maximale == true)
                    if (N > (double)detail.Indemnite.Valeur_Max)
                        N = (double)detail.Indemnite.Valeur_Max;


                detail.IBase = BASE;
                detail.ITaux = TAUX;
                detail.INbr = NBR;

                N = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)N);

                
                if (Nbr_Jrs_Cong_Recup != 0 && CRAvecPaye)
                {

                    if (detail.Indemnite.Cod_indem_interne != "Indem_Conge_Recup" && detail.Indemnite.Brut_Net_Incluse != InclusBrutNet.Sans && !detail.Indemnite.Retenue)
                    {
                        detail.Montant = (decimal)N * (decimal)(Nbr_jour_tra - Nbr_Jrs_Cong_Recup) / (decimal)Nbr_jour_tra;
                        detail.Montant = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, detail.Montant);

                        if ((detail.Indemnite.Mode_Calcul_Absence != 0) && (this.Type_Abcense.Type_Abs_Lib_Fr == Type_Abs_FR.Absence_Indemnite))
                            detail.Montant_Absence = Calculerabsence((decimal)N, detail.Indemnite.Mode_Calcul_Absence, true);
                        else detail.Montant_Absence = detail.Montant;
                    }
                    else
                    {
                        detail.Montant = (decimal)N; // ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)N);
                        // detail.Montant_Absence = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)N);

                        if ((detail.Indemnite.Mode_Calcul_Absence != 0) && (this.Type_Abcense.Type_Abs_Lib_Fr == Type_Abs_FR.Absence_Indemnite))
                            detail.Montant_Absence = Calculerabsence(detail.Montant, detail.Indemnite.Mode_Calcul_Absence, true);
                        else detail.Montant_Absence = detail.Montant;
                    }
                }
                else
                {
                    detail.Montant = (decimal)N; // ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)N);

                    if ((detail.Indemnite.Mode_Calcul_Absence != 0) && (this.Type_Abcense.Type_Abs_Lib_Fr == Type_Abs_FR.Absence_Indemnite))
                        detail.Montant_Absence = Calculerabsence(detail.Montant, detail.Indemnite.Mode_Calcul_Absence, false);
                    else detail.Montant_Absence = detail.Montant;
                }

                if (detail.Indemnite.Brut_Net_Incluse == InclusBrutNet.Brut && detail.Indemnite.Retenue != true)
                {
                    tempTotal += detail.Montant;
                    tempTotalAbsence += detail.Montant_Absence;
                }

                if (detail.Indemnite.Cotisable && detail.Indemnite.Retenue != true)
                {
                    TempCotisable += detail.Montant;
                    TempCotisableAbsence += detail.Montant_Absence;
                }

                if ((detail.Indemnite.Cotisable) && (detail.Indemnite.Mod_cal_irg == ModeCalculIRG.Sur_Barême) && (detail.Indemnite.Retenue != true))
                {
                    TempCotisableBareme += detail.Montant;
                    TempCotisableBaremeAbsence += detail.Montant_Absence;
                }

                if ((detail.Indemnite.Cotisable) && (detail.Indemnite.Mod_cal_irg == ModeCalculIRG.Sur_Taux) && (detail.Indemnite.Retenue != true))
                {
                    TempCotisableTaux += detail.Montant;
                    TempCotisableTauxAbsence += detail.Montant_Absence;
                }

                if ((detail.Indemnite.Cotisable == true) && (detail.Indemnite.Imposable == false) && (detail.Indemnite.Retenue != true))
                {
                    TempCotisableNonImpo += detail.Montant;
                    TempCotisableNonImpoAbsence += detail.Montant_Absence;
                }

                if ((detail.Indemnite.Imposable) && (detail.Indemnite.Retenue != true))
                {
                    TempImposable += detail.Montant;
                    TempImposable_Abs += detail.Montant_Absence;
                }

                if ((detail.Indemnite.Imposable) && (detail.Indemnite.Mod_cal_irg == ModeCalculIRG.Sur_Barême) && (detail.Indemnite.Retenue != true))
                {
                    TempImposableBareme += detail.Montant;
                    TempImposableBareme_Abs += detail.Montant_Absence;
                }

                if ((detail.Indemnite.Imposable) && (detail.Indemnite.Mod_cal_irg == ModeCalculIRG.Sur_Taux) && (detail.Indemnite.Retenue != true))
                {
                    TempImposableTaux += detail.Montant;
                    TempImposableTaux_Abs += detail.Montant_Absence;
                }

                if ((detail.Indemnite.Imposable) && (detail.Indemnite.Mod_cal_irg == ModeCalculIRG.Sur_Barême) && (detail.Indemnite.Mode_Calcul_Absence != Nbr_jour_tra && detail.Indemnite.Mode_Calcul_Absence == Nbr_Jour_Tra_Prime))
                {
                    TempImposable22 += detail.Montant;
                    TempImposable22_Abs += detail.Montant_Absence;
                }


                //if (detail.Indemnite.Cod_indem_interne == "Indem_Conge_Recup")
                //{
                //    TempImposableCongeRecup += detail.Montant;
                //    TempImposableCongeRecup_Abs += detail.Montant_Absence;

                //    TempCotisableCongeRecup += detail.Montant;
                //    TempCotisableCongeRecup_Abs += detail.Montant_Absence; 
                //}

                if ((detail.Indemnite.Imposable == true) && (detail.Indemnite.Cotisable == false) && (detail.Indemnite.Retenue != true))
                {
                    TempTotIndemImposNonCotis += detail.Montant;
                    TempTotIndemImposNonCotis_Abs += detail.Montant_Absence;
                }
                else
                    if ((detail.Indemnite.Imposable == false) && (detail.Indemnite.Cotisable == false) && (detail.Indemnite.Retenue != true))
                    {
                        TempTotIndemNonImposNonCotis += detail.Montant;
                        TempTotIndemNonImposNonCotis_Abs += detail.Montant_Absence;

                    }

                if ((detail.Indemnite.Brut_Net_Incluse == InclusBrutNet.Net) && (detail.Indemnite.Retenue == false) && (detail.Indemnite.Cod_indem_interne != "BRUT") && (detail.Indemnite.Cod_indem_interne != "SU") && (detail.Indemnite.Cod_indem_interne != "AF_Global"))
                {
                    TempTotIndemNet += detail.Montant;
                    TempTotIndemNet_Abs += detail.Montant_Absence;
                }

            }

            BRUT = tempTotal;

            Brute_cotisable = TempCotisable;

            Brute_cotisable_Bareme = TempCotisableBareme;
            Brute_cotisable_Bareme_Abs = TempCotisableBaremeAbsence;

            Brute_cotisable_Taux = TempCotisableTaux;
            Brute_cotisable_Taux_Abs = TempCotisableTauxAbsence;

            //Brute_cotisable_CongeRecup = TempCotisableCongeRecup;
            //Brute_cotisable_CongeRecup_Abs = TempCotisableCongeRecup_Abs;

            Brute_cotisableNonImpo = TempCotisableNonImpo;
            Brute_cotisableNonImpo_Abs = TempCotisableNonImpoAbsence;

            Imposable_bareme = TempImposableBareme;
            Imposable_bareme_Abs = TempImposableBareme_Abs;

            Imposable_taux = TempImposableTaux;
            Imposable_taux_Abs = TempImposableTaux_Abs;

            Brute_imposable = Imposable_taux + Imposable_bareme;
            Brute_imposable_Abs = Imposable_taux_Abs + Imposable_bareme_Abs;

            Imposable_bareme_22 = TempImposable22;
            Imposable_bareme_22_Abs = TempImposable22_Abs;

            //ImposableCongRecup = TempImposableCongeRecup;
            //ImposableCongRecup_Abs = TempImposableCongeRecup_Abs;

            Tot_Indem_impos_Non_Cotis = TempTotIndemImposNonCotis;
            Tot_Indem_impos_Non_Cotis_Abs = TempTotIndemImposNonCotis_Abs;

            Tot_Indem_Non_impos_Non_Cotis = TempTotIndemNonImposNonCotis;
            Tot_Indem_Non_impos_Non_Cotis_Abs = TempTotIndemNonImposNonCotis_Abs;

            Tot_Indem_Net = TempTotIndemNet;
            Tot_Indem_Net_Abs = TempTotIndemNet_Abs;

            if (this.Type_Abcense.Type_Abs_Lib_Fr == Type_Abs_FR.Absence_Indemnite)
            {
                BRUTAbsence = tempTotalAbsence;
                Brute_cotisableAbsence = TempCotisableAbsence;
                Brute_cotisable_Bareme_Abs = TempCotisableBaremeAbsence;
                Brute_cotisable_Taux_Abs = TempCotisableTauxAbsence;
                Brute_imposable_Abs = TempImposable_Abs;
                Imposable_bareme_Abs = TempImposableBareme_Abs;
                Imposable_taux_Abs = TempImposableTaux_Abs;
            }
            else
                if (this.Type_Abcense.Type_Abs_Lib_Fr == Type_Abs_FR.Absence_Brut)
                {
                    BRUTAbsence = Calculerabsence(BRUT, Nbr_jour_tra, false);
                    Brute_cotisableAbsence = Calculerabsence(Brute_cotisable, Nbr_jour_tra, false);
                    Brute_cotisable_Bareme_Abs = Calculerabsence(Brute_cotisable_Bareme, Nbr_jour_tra, false);
                    Brute_cotisable_Taux_Abs = Calculerabsence(Brute_cotisable_Taux, Nbr_jour_tra, false);
                    Brute_imposable_Abs = Calculerabsence(Brute_imposable, Nbr_jour_tra, false);
                    Imposable_bareme_Abs = Calculerabsence(Imposable_bareme, Nbr_jour_tra, false);
                    Imposable_taux_Abs = Calculerabsence(Imposable_taux, Nbr_jour_tra, false);
                }
                else
                    if (this.Type_Abcense.Type_Abs_Lib_Fr == Type_Abs_FR.Absence_Net)
                    {
                        BRUTAbsence = tempTotalAbsence;
                        Brute_cotisableAbsence = TempCotisableAbsence;
                        Brute_cotisable_Bareme_Abs = TempCotisableBaremeAbsence;
                        Brute_cotisable_Taux_Abs = TempCotisableTauxAbsence;
                        Imposable_bareme_Abs = TempImposableBareme_Abs;
                        Imposable_taux_Abs = TempImposableTaux_Abs;
                    }


            Imposable_bareme_22 = TempImposable22;
            Imposable_bareme_22 = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Imposable_bareme_22);

            Imposable_bareme_22_Abs = TempImposable22_Abs;
            Imposable_bareme_22_Abs = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Imposable_bareme_22_Abs);

            Tot_Indem_impos_Non_Cotis = TempTotIndemImposNonCotis;
            Tot_Indem_impos_Non_Cotis = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Tot_Indem_impos_Non_Cotis);

            Tot_Indem_impos_Non_Cotis_Abs = TempTotIndemImposNonCotis_Abs;
            Tot_Indem_impos_Non_Cotis_Abs = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Tot_Indem_impos_Non_Cotis_Abs);

            Tot_Indem_Non_impos_Non_Cotis = TempTotIndemNonImposNonCotis;
            Tot_Indem_Non_impos_Non_Cotis = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Tot_Indem_Non_impos_Non_Cotis);

            Tot_Indem_Non_impos_Non_Cotis_Abs = TempTotIndemNonImposNonCotis_Abs;
            Tot_Indem_Non_impos_Non_Cotis_Abs = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Tot_Indem_Non_impos_Non_Cotis_Abs);

        }

        public void EvaluateBase()
        {
            foreach (paye_indem detail in paye_indems)
            {
                BASE = 0;

                if ((detail.Indemnite.Form_base != "") && (detail.Indemnite.Form_base != null))
                    BASE = (decimal)Evaluate(detail.Indemnite.Form_base);
                else
                    BASE = (decimal)detail.IBase;

                detail.IBase = BASE;
            }
        }

        public void CalculerSS()
        {
            bool modifspecSS = If_ModifSpec("SS");
            bool existSS = If_Exist("SS");

            if (existSS == true)
            {
                if (modifspecSS == false)
                {
                    if (Soumis_à_la_Sécurité_Sociale == true)
                    {
                        double x = (double)Brute_cotisable;
                        double xb = (double)Brute_cotisable_Bareme;
                        double xt = (double)Brute_cotisable_Taux;
                        double xNI = (double)Brute_cotisableNonImpo;

                        double XSs = x * Taux_SS / 100;
                        double XSsb = xb * Taux_SS / 100;
                        double XSst = xt * Taux_SS / 100;
                        double XSsNI = xNI * Taux_SS / 100;
                        double XScr = (double)Indem_Conge_Recup * Taux_SS / 100;

                        SS = (decimal)XSs;
                        Ss_bareme = (decimal)XSsb;
                        SS_Taux = (decimal)XSst;
                        Ss_Non_Impo = (decimal)XSsNI;
                        //SS_CongeRecup = (decimal)XScr;

                        SS = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, SS);
                        Ss_bareme = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Ss_bareme);
                        SS_Taux = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, SS_Taux);
                        Ss_Non_Impo = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Ss_Non_Impo);

                        if (this.Type_Abcense.Type_Abs_Lib_Fr != Type_Abs_FR.Absence_Net)
                        {
                            x = (double)Brute_cotisableAbsence;
                            XSs = x * Taux_SS / 100;
                            SSAbsence = (decimal)XSs;
                            SSAbsence = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, SSAbsence);

                            xb = (double)Brute_cotisable_Bareme_Abs;
                            XSsb = xb * Taux_SS / 100;
                            SS_Bareme_Abs = (decimal)XSsb;
                            SS_Bareme_Abs = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, SS_Bareme_Abs);

                            xt = (double)Brute_cotisable_Taux_Abs;
                            XSst = xt * Taux_SS / 100;
                            SS_Taux_Abs = (decimal)XSst;
                            SS_Taux_Abs = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, SS_Taux_Abs);

                            xNI = (double)Brute_cotisableNonImpo_Abs;
                            XSsNI = xNI * Taux_SS / 100;
                            SS_Non_Impo_Abs = (decimal)XSsNI;
                            SS_Non_Impo_Abs = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, SS_Non_Impo_Abs);

                        }
                        else
                        {
                            SSAbsence = SS;
                            SS_Bareme_Abs = Ss_bareme;
                            SS_Taux_Abs = SS_Taux;
                        }

                        PP = Brute_cotisableAbsence * (decimal)Taux_pp / 100;
                        PP = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, PP);

                        PP1 = Brute_cotisableAbsence * (decimal)Taux_pp1 / 100;
                        PP1 = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, PP1);

                        PP2 = Brute_cotisableAbsence * (decimal)Taux_pp2 / 100;
                        PP2 = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, PP2);

                        PP3 = Brute_cotisableAbsence * (decimal)Taux_pp3 / 100;
                        PP3 = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, PP3);
                    }
                    else
                    {
                        SS = 0;
                        SSAbsence = 0;
                    }
                }
                else
                {
                    SS = Get_Montant("SS");
                    if (Type_Abcense.Type_Abs_Lib_Fr != Type_Abs_FR.Absence_Net)
                        SSAbsence = Calculerabsence(SS, Nbr_jour_tra, false);
                    else
                        SSAbsence = SS;
                }
            }
            else
            {
                SS = 0;
                SSAbsence = 0;
            }

            if (Soumis_Cacobatph == true)
            {
                cacobatph = Brute_cotisableAbsence * (decimal)Taux_cacobatph / 100;
                cacobatph = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, cacobatph);

                chomage_intemperie = Brute_cotisableAbsence * (decimal)Taux_chomage_intemperie / 100;
                chomage_intemperie = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, chomage_intemperie);

                if (existSS == true)
                {
                    if (!If_ModifSpec("ChIntempPO"))
                    {
                        ChIntempPO = Brute_cotisable * (decimal)Taux_chomage_intemperiePO / 100;
                        ChIntempPO = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, ChIntempPO);

                        if (this.Type_Abcense.Type_Abs_Lib_Fr != Type_Abs_FR.Absence_Net)
                        {
                            ChIntempPOAbs = Brute_cotisableAbsence * (decimal)Taux_chomage_intemperiePO / 100;
                            ChIntempPOAbs = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, ChIntempPOAbs);
                        }
                        else
                            ChIntempPOAbs = ChIntempPO;
                    }
                    else
                    {
                        ChIntempPO = Get_Montant("ChIntempPO");
                        if (Type_Abcense.Type_Abs_Lib_Fr != Type_Abs_FR.Absence_Net)
                            ChIntempPOAbs = Calculerabsence(ChIntempPO, Nbr_jour_tra, false);
                        else
                            ChIntempPOAbs = ChIntempPO;
                    }
                }
                else
                {
                    ChIntempPO = 0;
                    ChIntempPOAbs = 0;
                }
            }
            else
            {
                cacobatph = 0;
                chomage_intemperie = 0;
                ChIntempPO = 0;
                ChIntempPOAbs = 0;
            }
        }

        public void CalculerBrutImpo()
        {
            decimal BrutImpo = Brute_imposable;
            decimal BrutImpoAbs = Brute_imposable_Abs;
            decimal BrutCotisableNonImpo = Brute_cotisableNonImpo;
            decimal BrutCotisableNonImpoAbs = Brute_cotisableNonImpo_Abs;

            if (BrutImpo != 0)
                Brute_imposable = BrutImpo - (SS - Ss_Non_Impo) - ChIntempPO;
            if (BrutImpoAbs != 0)
                Brute_imposable_Abs = BrutImpoAbs - (SSAbsence - SS_Non_Impo_Abs) - ChIntempPOAbs;

            decimal BrutImpoBareme = Imposable_bareme;
            decimal BrutImpoBaremeAbs = Imposable_bareme_Abs;

            if (BrutImpoBareme != 0)
                Imposable_bareme = BrutImpoBareme - (Ss_bareme - Ss_Non_Impo) - ChIntempPO;
            if (BrutImpoBaremeAbs != 0)
                Imposable_bareme_Abs = BrutImpoBaremeAbs - (SS_Bareme_Abs - SS_Non_Impo_Abs) - ChIntempPOAbs;

            decimal BrutImpoTaux = Imposable_taux;
            decimal BrutImpoTauxAbs = Imposable_taux_Abs;

            if (BrutImpoTaux != 0)
                Imposable_taux = BrutImpoTaux - SS_Taux - (Ss_Non_Impo) - ChIntempPO;
            if (BrutImpoTauxAbs != 0)
                Imposable_taux_Abs = BrutImpoTauxAbs - (SS_Taux_Abs - SS_Non_Impo_Abs) - ChIntempPOAbs;

            //ImposableCongRecup = Brute_cotisable_CongeRecup - SS_CongeRecup; 
            //ImposableCongRecup_Abs = Brute_cotisable_CongeRecup_Abs - SS_CongeRecup; 

        }

        public void CalculerIrgTaux()
        {
            if (Soumis_à_l_IRG == false)
                Irg_taux = 0;
            else
            {
                double x = (double)(Imposable_taux);
                double XIrgTaux = x * Taux_IRG / 100;

                Irg_taux = (decimal)XIrgTaux;
                Irg_taux = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Irg_taux);

                if (this.Type_Abcense.Type_Abs_Lib_Fr != Type_Abs_FR.Absence_Net)
                    Irg_taux_Abs = Calculerabsence(Irg_taux, Nbr_jour_tra, false);
                else
                    Irg_taux_Abs = Irg_taux;
            }
        }

        public void CalculerIrgBareme()
        {
            if (Soumis_à_l_IRG == false)
                Irg_bareme = 0;
            else
            {
                int[] Trs = { 0, 120000, 360000, 1440000, 99999999 };
                //int[] Tax = { 0, 0, 0, 30, 35 };
                int[] Tax;

                //Taux a appliqué d'apres le mois et l'année 
                if (parametres.Annee_Travail > 2020)
                {
                    int[] Taxs = { 0, 0, 0, 30, 35 };
                    Tax = Taxs;
                }
                else if (parametres.Annee_Travail == 2020 && (Mois >= (MoisdelAnnee)6))
                {
                    int[] Taxs = { 0, 0, 0, 30, 35 };
                    Tax = Taxs;
                }
                else
                {
                    int[] Taxs = { 0, 0, 20, 30, 35 };
                    Tax = Taxs;
                }
                int[] Impan = { 0, 0, 48000, 372000, 3367999, 65 };

                //decimal imposable = Imposable_bareme - ImposableCongRecup;
                decimal soumis = Math.Truncate((Imposable_bareme) / 10) * 10;
                decimal Brts = soumis * 12;
                int I = 1;
                while (Brts > Trs[I])
                    I += 1;

                int taux = Tax[I];
                int Tb = Trs[I - 1];
                decimal Td = Impan[I - 1];
                decimal N = Brts - Tb;
                decimal ImpotA = (N * taux / 100) + Td; ;
                decimal ImpM = ImpotA / 12;
                decimal Abat = 0;

                Abat = ImpM * 40 / 100;
                if (Abat < 1000) { Abat = 1000; };
                if (Abat > 1500) { Abat = 1500; };

                decimal Ret = ImpM - Abat;
                if (Ret < 0) { Ret = 0; };

                decimal IrgRes = Ret * 10;

                int partent = (int)IrgRes;
                decimal partdec = IrgRes - partent;

                IrgRes = IrgRes - partdec;

                decimal c1 = partdec * 10;
                int partent1 = (int)c1;
                if (c1 > 5) { IrgRes = IrgRes + 1; };
                IrgRes = IrgRes / 10;
                if (IrgRes < 0) { IrgRes = 0; };
                Irg_bareme = IrgRes;

                if (parametres.Annee_Travail >= 2020)
                {
                    if (Mois >= (MoisdelAnnee)6)
                    {
                        //2eme abattement 
                        if (!personne.handicapée && (Brute_imposable > 30000 && Brute_imposable < 35000))
                            Irg_bareme = ((Irg_bareme * 8) - 20000) / 3;
                        //Handicapée
                        if (personne.handicapée && (Brute_imposable > 30000 && Brute_imposable < 40000))
                            Irg_bareme = ((Irg_bareme * 5) - 12500) / 3;
                    }
                }

                Irg_bareme = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Irg_bareme);


                if (this.Type_Abcense.Type_Abs_Lib_Fr != Type_Abs_FR.Absence_Net) 
                    Irg_bareme_Abs = Calculerabsence(Irg_bareme, Nbr_jour_tra, false); 
                else
                    Irg_bareme_Abs = Irg_bareme;

            }
        }

        //public void CalculerIrgCongeRecup()
        //{
        //    if (Nbr_Jrs_Cong_Recup != 0)
        //    {
        //        if (Soumis_à_l_IRG == false)
        //            Irg_bareme = 0;
        //        else
        //        {
        //            int[] Trs = { 0, 120000, 360000, 1440000, 99999999 };
        //            int[] Tax = { 0, 0, 20, 30, 35 };
        //            int[] Impan = { 0, 0, 48000, 372000, 3367999, 65 };

        //            decimal soumis = Math.Truncate((ImposableCongRecup) / 10) * 10;
        //            decimal Brts = soumis * 12;
        //            int I = 1;
        //            while (Brts > Trs[I])
        //                I += 1;

        //            int taux = Tax[I];
        //            int Tb = Trs[I - 1];
        //            decimal Td = Impan[I - 1];
        //            decimal N = Brts - Tb;
        //            decimal ImpotA = (N * taux / 100) + Td; ;
        //            decimal ImpM = ImpotA / 12;
        //            decimal Abat = 0;

        //            Abat = ImpM * 40 / 100;
        //            if (Abat < 1000) { Abat = 1000; };
        //            if (Abat > 1500) { Abat = 1500; };

        //            decimal Ret = ImpM - Abat;
        //            if (Ret < 0) { Ret = 0; };

        //            decimal IrgRes = Ret * 10;

        //            int partent = (int)IrgRes;
        //            decimal partdec = IrgRes - partent;

        //            IrgRes = IrgRes - partdec;

        //            decimal c1 = partdec * 10;
        //            int partent1 = (int)c1;
        //            if (c1 > 5) { IrgRes = IrgRes + 1; };
        //            IrgRes = IrgRes / 10;
        //            if (IrgRes < 0) { IrgRes = 0; };
        //            IRG_CongeRecup = IrgRes;
        //            IRG_CongeRecup = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, IRG_CongeRecup);

        //            IRGAbsence_CongeRecup = IRG_CongeRecup;
        //        }
        //    }
        //    else
        //    {
        //        IRG_CongeRecup = 0;
        //        IRGAbsence_CongeRecup = 0;
        //    } 
        //}

        public void CalculerIrg()
        {
            bool modifspecIRG = If_ModifSpec("IRG");
            bool existIRG = If_Exist("IRG");
            bool existIRG_B = If_Exist("Irg_bareme");
            bool existIRG_T = If_Exist("Irg_taux");
             
            if (existIRG || existIRG_B || existIRG_T)
            {
                if (modifspecIRG == false)
                {
                    IRG = Irg_bareme + Irg_taux;
                    //Nouveau IRG
                    //if (Brute_imposable <= 30000)
                    //    IRG = 0;
                    //if (Brute_imposable > 30000 && Brute_imposable < 35000)
                    //    IRG = (IRG * 8 / 3) - (20000 / 3);
                    
                    if (this.Type_Abcense.Type_Abs_Lib_Fr != Type_Abs_FR.Absence_Net)
                        IRGAbsence = CalculerabsenceIRG(IRG);
                    else
                        IRGAbsence = IRG;

                    if (IRG != 0)
                    {
                        Irg_bareme_Abs = (Irg_bareme * IRGAbsence) / IRG;
                        Irg_taux_Abs = (Irg_taux * IRGAbsence) / IRG;
                    }

                    //IRG += IRG_CongeRecup;
                    //IRGAbsence += IRGAbsence_CongeRecup;
                }
                else
                {
                    IRG = Get_Montant("IRG");
                    if (this.Type_Abcense.Type_Abs_Lib_Fr != Type_Abs_FR.Absence_Net)
                        IRGAbsence = CalculerabsenceIRG(IRG);
                    else
                        IRGAbsence = IRG;

                    
                }
            }
            else
            {
                IRG = 0;
                IRGAbsence = 0;
            }
        }

        public decimal CalculerabsenceIRG(decimal XMontant)
        {
            decimal Irg_22 = 0;
            decimal Irg_Abs_22 = 0;
            decimal Irg_30 = 0;
            decimal Irg_Bar_Abs_30 = 0;

            if (Imposable_bareme != 0)
            {
                Irg_22 = (Imposable_bareme_22 * XMontant) / (Imposable_bareme);
                Irg_22 = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Irg_22);
            }
            else
                Irg_22 = 0;

            Irg_30 = XMontant - Irg_22;

            Irg_Bar_Abs_30 = (Irg_30 * (decimal)(Nbr_jour_tra - Jour_Abs)) / (decimal)Nbr_jour_tra;
            Irg_Bar_Abs_30 = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Irg_Bar_Abs_30);

            Irg_Abs_22 = (Irg_22 * (decimal)(Nbr_Jour_Tra_Prime - Nbr_jour_abs_prime)) / (decimal)Nbr_Jour_Tra_Prime;
            Irg_Abs_22 = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Irg_Abs_22);

            decimal Irg_Abs = 0;
            Irg_Abs = Irg_Bar_Abs_30 + Irg_Abs_22;
            Irg_Abs = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Irg_Abs);

            return Irg_Abs;
        }

        public void CalculerMutuelle()
        {
            bool modifspecMut = If_ModifSpec("mutuelle");

            bool existMut = If_Exist("mutuelle");

            if (existMut == true)
            {
                if (modifspecMut == false)
                {
                    if (Ok_Mutuel == true)
                    {
                        if (Taux_Mutuel != 0)
                        {
                            double x = (double)Brute_cotisableAbsence;
                            double XMutuelle = x * Taux_Mutuel / 100;

                            if (Plafond_mutuelle != 0)
                            {
                                if (XMutuelle > (double)Plafond_mutuelle)
                                    mutuelle = Plafond_mutuelle;
                                else
                                {
                                    mutuelle = (decimal)XMutuelle;
                                    mutuelle = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, mutuelle);
                                    //mutuelleAbs = Calculerabsence(mutuelle, Nbr_jour_tra);
                                }
                            }
                            else
                            {
                                mutuelle = (decimal)XMutuelle;
                                mutuelle = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, mutuelle);
                            }


                            //mutuelleAbs = Calculerabsence(mutuelle, Nbr_jour_tra);
                            mutuelleAbs = mutuelle;
                        }
                        else
                        {
                            mutuelle = parametres.Valeur_mutuelle;
                            mutuelleAbs = mutuelle;
                        }
                    }


                    else
                        mutuelle = 0;
                }
                else
                    mutuelle = Get_Montant("mutuelle");
            }
            else
                mutuelle = 0;
        }

        public void Calcul_Allocation()
        {

            bool existAF = If_Exist("AF");
            bool existAF_Maj = If_Exist("AF_Majoration");
            bool existAF_Global = If_Exist("AF_Global");

            bool modifspecAF = If_ModifSpec("AF");
            bool modifspecAF_Maj = If_ModifSpec("AF_Majoration");
            bool modifspecAF_Global = If_ModifSpec("AF_Global");

            //AF = Montant_AF(Nbr_enf_M10, Nbr_enf_p10); 
            //AF_Majoration = Montant_AF_Majoration(Nbr_enf_p10);
            //AF_Global = AF + AF_Majoration;


            if (modifspecAF == false)
                AF = Montant_AF(Nbr_enf, Nbr_enf_p10);
            else
                AF = Get_Montant("AF");



            if (modifspecAF_Maj == false)
                AF_Majoration = Montant_AF_Majoration(Nbr_enf_p10);
            else
                AF_Majoration = Get_Montant("AF_Majoration");


            if (existAF_Global == true)
            {
                if (modifspecAF_Global == false)
                    AF_Global = AF + AF_Majoration;
                else
                    AF_Global = Get_Montant("AF_Global");
            }
            else
                AF_Global = 0;
        }

        public decimal CALCUL_AF()
        {
            decimal XAF = 0;

            XAF = Montant_AF(Nbr_enf_M10, Nbr_enf_p10);

            return XAF;
        }

        public decimal Montant_AF(int Xnbr_EnfM10, int Xnbr_EnfP10)
        {
            decimal Mt_Af = 0;
            int nbr_Enf_plus_5 = 0;
            int Som_Enf = (Xnbr_EnfM10 + Xnbr_EnfP10);
            if (Som_Enf > 5)
                nbr_Enf_plus_5 = Som_Enf - 5;

            if (AF_Partiel == false)
            {
                if (Som_Enf > 5 && Xnbr_EnfM10 > 5)
                    Mt_Af = (5 * Base_AF) + ((5 - Xnbr_EnfM10) * Base_AF_Partiel);
                else
                    Mt_Af = (Xnbr_EnfM10 * Base_AF);
            }
            else
                Mt_Af = (Xnbr_EnfM10 * Base_AF_Partiel);
            Mt_Af = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Mt_Af);
            return Mt_Af;
        }

        public decimal CALCUL_AF_Majoration()
        {
            decimal XAF_P10 = 0;
            XAF_P10 = Montant_AF_Majoration(Nbr_enf_p10);
            XAF_P10 = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, XAF_P10);

            return XAF_P10;
        }

        public decimal Montant_AF_Majoration(int Xnbr_EnfP10)
        {
            decimal Mt_Af_P10 = 0;

            Mt_Af_P10 = (Xnbr_EnfP10 * Base_AF_P10);
            Mt_Af_P10 = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Mt_Af_P10);
            return Mt_Af_P10;
        }

        public void CALCUL_SU()
        {
            bool existSU = If_Exist("SU");
            bool modifspecSU = If_ModifSpec("SU");
            decimal xSU;

            if (Sit_Emp != null && Sit_fam != null && Sit_Conjoint != null)
            {
                decimal Xmontant_Su = 0;

                //*********CAS d'un emplye Celibataire n'importe  femme ou homme ********* 
                if (Sit_fam.Sit_Fam_Lib_Fr == Sit_Fam_FR.Celibataire)
                {
                    Xmontant_Su = 0;
                }

                //********************** Cas d'1 employe Masculin
                //if (personne.sexe.Sexe_Lib_Ar == Sexe_Ar.ÐßÑ)
                //{
                if ((Sit_fam.Sit_Fam_Lib_Fr == Sit_Fam_FR.Veuf) || (Sit_fam.Sit_Fam_Lib_Fr == Sit_Fam_FR.Divorsé))
                {
                    Xmontant_Su = 0;
                }

                //***********************Cas ou le conjoint est un chomeur 
                if (Sit_Conjoint.Sit_Conj_Lib_Fr == Sit_Conj_FR.Chomeur)
                {
                    if (Sit_fam.Sit_Fam_Lib_Fr == Sit_Fam_FR.Marie_Sans_Enfants)
                    {
                        Xmontant_Su = parametres.Base_SU_Partiel;
                    }
                    else
                        if (Sit_fam.Sit_Fam_Lib_Fr == Sit_Fam_FR.Marie_Avec_Enfants)
                        {
                            Xmontant_Su = parametres.Base_SU;
                        }
                }
                else
                    if (personne.Sit_Conjoint.Sit_Conj_Lib_Fr == Sit_Conj_FR.Tavail)
                    {
                        Xmontant_Su = 0;
                    }
                xSU = Xmontant_Su;

            }
            else
                xSU = 0;

            if (existSU == true)
                if (modifspecSU == false)
                    SU = xSU;
                else
                    SU = Get_Montant("SU");
            else
                SU = 0;
        }

        public void CalculPret()
        {
            bool existRetenu_Pret = If_Exist("Retenu_Pret");
            bool modifspecRetenu_Pret = If_ModifSpec("Retenu_Pret");

            decimal tempPret = 0m;

            if (existRetenu_Pret)
            {
                CriteriaOperator criteria1 = CriteriaOperator.Parse("Oid!=?", this.Oid);
                CriteriaOperator criteria2 = CriteriaOperator.Parse("Mois==?", Mois);
                CriteriaOperator criteria3 = CriteriaOperator.Parse("Annee==?", Annee);
                CriteriaOperator criteria4 = CriteriaOperator.Parse("Retenu_Pret!=?", 0);
                CriteriaOperator criteria5 = CriteriaOperator.Parse("personne==?", personne);
                Paye paye = this.Session.FindObject<Paye>(CriteriaOperator.And(criteria1, criteria2, criteria3, criteria4, criteria5));

                if (paye == null)
                {
                    Gestion_Pret Pret = this.Session.FindObject<Gestion_Pret>(CriteriaOperator.Parse("personne==?", personne));
                    if (Pret != null)
                    {
                        if (modifspecRetenu_Pret == false)
                        {
                            tempPret = Pret.CalculPret(this, 0);
                            Retenu_Pret = tempPret;
                        }
                        else
                        {
                            decimal montant = Get_Montant("Retenu_Pret");
                            tempPret = Pret.CalculPret(this, montant);
                            Retenu_Pret = tempPret;
                        }
                    }
                    else
                    {
                        decimal montant = Get_Montant("Retenu_Pret");
                        tempPret = Pret.CalculPret(this, montant);
                        Retenu_Pret = montant;
                    }
                }
                else
                    Retenu_Pret = 0;
            }
            else
                Retenu_Pret = 0;
        }

        public void CalculRetenus()
        {
            decimal tempRetenus = 0m;

            foreach (paye_indem detail in paye_indems)
            {
                if (detail.Indemnite.Retenue == true)
                    if ((detail.Indemnite.Cod_indem_interne != "SS") && (detail.Indemnite.Cod_indem_interne != "ChIntempPO")
                        && (detail.Indemnite.Cod_indem_interne != "IRG") && (detail.Indemnite.Cod_indem_interne != "Irg_bareme")
                        && (detail.Indemnite.Cod_indem_interne != "Irg_taux") && (detail.Indemnite.Cod_indem_interne != "mutuelle"))
                        tempRetenus += detail.Montant;
            }

            Retenu_Global = tempRetenus;

        }

        public void CalculerNet()
        {
            bool modifspecNET = If_ModifSpec("NET");
            bool existNET = If_Exist("NET");
            if (existNET == true)
            {
                if (modifspecNET == false)
                {
                    if(parametres.AbsSU)
                        if (Jour_Abs >= Nbr_jour_tra)
                            SU = 0;

                    NET = BRUT - SS - ChIntempPO - IRG - Retenu_Global - mutuelle + AF_Global + SU + Tot_Indem_Net;// 

                    NET = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, NET);
                    NETAbsence = BRUTAbsence - SSAbsence - ChIntempPOAbs - IRGAbsence - mutuelle - Retenu_Global + AF_Global + SU + Tot_Indem_Net_Abs;//
                    NETAbsence = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, NETAbsence);
                    //- Prime_Pannier - Prime_Transport;
                    if (this.Type_Abcense.Type_Abs_Lib_Fr == Type_Abs_FR.Absence_Net)
                    {
                        NETAbsence = NET + Retenu_Global + mutuelle - AF_Global - SU - Tot_Indem_Net_Abs;// 
                        //-Prime_Pannier - Prime_Transport;
                        NETAbsence = Calculerabsence(NETAbsence, Nbr_jour_tra, false);
                        NETAbsence = NETAbsence - Retenu_Global - mutuelle + AF_Global + SU + Tot_Indem_Net_Abs;// 
                        NETAbsence = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, NETAbsence);
                        //+Prime_Pannier + Prime_Transport;
                    }
                }
                else
                {
                    NET = Get_Montant("NET");
                    NETAbsence = Calculerabsence(NET, Nbr_jour_tra, false);
                }
            }
            else
            {
                NET = 0;
                NETAbsence = 0;
            }
        }

        public void AffectationsLignesColonnesIndem()
        {
            foreach (paye_indem detail in paye_indems)
            {
                if (detail.Indemnite.Cod_indem_interne == "Indem_Conge_Recup")
                {
                    detail.Montant = Indem_Conge_Recup;
                    detail.Montant_Absence = Indem_Conge_Recup_Abs;
                }

                else if (detail.Indemnite.Cod_indem_interne == "PMG")
                {
                    detail.Montant = PMG;
                    detail.Montant_Absence = PMG;
                }
            }
        }

        public void AffectationsLignesColonnes()
        {
            foreach (paye_indem detail in paye_indems)
            {
                if (detail.Indemnite.Cod_indem_interne == "BRUT")
                {
                    detail.Montant = BRUT;
                    detail.Montant_Absence = BRUTAbsence;
                }
                else if (detail.Indemnite.Cod_indem_interne == "Indem_Conge_Recup")
                {
                    detail.Montant = Indem_Conge_Recup;
                    detail.Montant_Absence = Indem_Conge_Recup_Abs;
                }
                else if (detail.Indemnite.Cod_indem_interne == "Brute_cotisable")
                {
                    detail.Montant = Brute_cotisable;
                    detail.Montant_Absence = Brute_cotisableAbsence;
                }
                else if (detail.Indemnite.Cod_indem_interne == "Brute_imposable")
                {
                    detail.Montant = Brute_imposable;
                    detail.Montant_Absence = Brute_imposable_Abs;
                }
                else if (detail.Indemnite.Cod_indem_interne == "SS")
                {
                    detail.Montant = SS;
                    detail.Montant_Absence = SSAbsence;
                }
                else if (detail.Indemnite.Cod_indem_interne == "ChIntempPO")
                {
                    detail.Montant = ChIntempPO;
                    detail.Montant_Absence = ChIntempPOAbs;
                }
                else if (detail.Indemnite.Cod_indem_interne == "Irg_bareme")
                {
                    detail.Montant = Irg_bareme;
                    detail.Montant_Absence = Irg_bareme_Abs;
                }
                else if (detail.Indemnite.Cod_indem_interne == "Irg_taux")
                {
                    detail.Montant = Irg_taux;
                    detail.Montant_Absence = Irg_taux_Abs;
                }
                else if (detail.Indemnite.Cod_indem_interne == "IRG")
                {
                    detail.Montant = IRG;
                    detail.Montant_Absence = IRGAbsence;
                }
                else if (detail.Indemnite.Cod_indem_interne == "NET")
                {
                    detail.Montant = NET;
                    detail.Montant_Absence = NETAbsence;
                }
                else if (detail.Indemnite.Cod_indem_interne == "mutuelle")
                {
                    detail.Montant = mutuelle;
                    detail.Montant_Absence = mutuelleAbs;
                }
                else if (detail.Indemnite.Cod_indem_interne == "Imposable_taux")
                {
                    detail.Montant = Imposable_taux;
                    detail.Montant_Absence = Imposable_taux_Abs;
                }
                else if (detail.Indemnite.Cod_indem_interne == "Imposable_bareme")
                {
                    detail.Montant = Imposable_bareme;
                    detail.Montant_Absence = Imposable_bareme_Abs;
                }
                else if (detail.Indemnite.Cod_indem_interne == "Retenu_Pret")
                {
                    detail.Montant = Retenu_Pret;
                    detail.Montant_Absence = Retenu_Pret;
                }
                else if (detail.Indemnite.Cod_indem_interne == "PMG")
                {
                    detail.Montant = PMG;
                    detail.Montant_Absence = PMG;
                }
                else
                    AffectationIndemniteLignesAuColonnes(detail.Montant_Absence, detail);
            }
        }

        public void AffectationIndemniteLignesAuColonnes(decimal XMontant, paye_indem Xind) // Uniquement pour les indemnités qui se calculent à partir de CalculTotaux
        {
            string ind = Xind.Indemnite.Cod_indem_interne.ToString();
            this.SetMemberValue(ind, XMontant);
        }

        public void AffectationsLignesColonnesInverse()
        {
            foreach (paye_indem detail in paye_indems)
            {
                if (detail.Indemnite.Cod_indem_interne == "SDB")
                {
                    SDB = detail.Montant;
                    SDBAbsence = detail.Montant_Absence;
                }
                else
                    if (detail.Indemnite.Cod_indem_interne == "BRUT")
                    {
                        BRUT = detail.Montant;
                        BRUTAbsence = detail.Montant_Absence;
                    }
                    else
                        if (detail.Indemnite.Cod_indem_interne == "Brute_cotisable")
                        {
                            Brute_cotisable = detail.Montant;
                            Brute_cotisableAbsence = detail.Montant_Absence;
                        }
                        else
                            if (detail.Indemnite.Cod_indem_interne == "Brute_imposable")
                            {
                                Brute_imposable = detail.Montant;
                                Brute_imposable_Abs = detail.Montant_Absence;
                            }

                            else
                                if (detail.Indemnite.Cod_indem_interne == "SS")
                                {
                                    SS = detail.Montant;
                                    SSAbsence = detail.Montant_Absence;
                                }
                                else
                                    if (detail.Indemnite.Cod_indem_interne == "IRG")
                                    {
                                        IRG = detail.Montant;
                                        IRGAbsence = detail.Montant_Absence;
                                    }
                                    else
                                        if (detail.Indemnite.Cod_indem_interne == "Irg_bareme")
                                        {
                                            Irg_bareme = detail.Montant;
                                            Irg_bareme_Abs = detail.Montant_Absence;
                                        }
                                        else
                                            if (detail.Indemnite.Cod_indem_interne == "Irg_taux")
                                            {
                                                Irg_taux = detail.Montant;
                                                Irg_taux_Abs = detail.Montant_Absence;
                                            }
                                            else
                                                if (detail.Indemnite.Cod_indem_interne == "NET")
                                                {
                                                    NET = detail.Montant;
                                                    NETAbsence = detail.Montant_Absence;
                                                }
                                                else
                                                    if (detail.Indemnite.Cod_indem_interne == "Imposable_taux")
                                                    {
                                                        Imposable_taux = detail.Montant;
                                                        Imposable_taux_Abs = detail.Montant_Absence;
                                                    }
                                                    else
                                                        if (detail.Indemnite.Cod_indem_interne == "Imposable_bareme")
                                                        {
                                                            Imposable_bareme = detail.Montant;
                                                            Imposable_bareme_Abs = detail.Montant_Absence;
                                                        }
                                                        else
                                                            AffectationIndemniteLignesAuColonnes(detail.Montant_Absence, detail);
            }
        }

        public decimal CalculInverseIndemUnique(decimal Valeur)
        {
            decimal net_voulu = Valeur;
            decimal val = net_voulu;
            decimal BrutCotis = 0; 
            decimal Dif = 0;

            decimal soumisSS = (net_voulu * 2); // Brut = net_voulu * 2 (grade valeur possible)

            decimal soumisIRG = soumisSS * (1 - (decimal)((Taux_SS) / 100));//+ Taux_cacobatph
            soumisIRG = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, soumisIRG);

            decimal IRGRes = 0;
            IRGRes = CalculerIrgInvers(soumisIRG);

            decimal net_obtenu1 = (soumisSS * (1 - (decimal)((Taux_SS) * 0.01))) - IRGRes; // net_obtenu1 = soumis - IRGRes (grade valeur possible)+ Taux_cacobatph
            net_obtenu1 = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, net_obtenu1);

            //Dif = (decimal)0.0001;
            while (Math.Abs(net_obtenu1 - net_voulu) > Dif)
            {
                val = val / 2;
                if (net_obtenu1 > net_voulu)
                    soumisSS = soumisSS - val;
                else
                    soumisSS = soumisSS + val;
                soumisSS = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, soumisSS);

                soumisIRG = soumisSS * (1 - (decimal)((Taux_SS) * 0.01));//+ Taux_cacobatph
                soumisIRG = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, soumisIRG);

                IRGRes = CalculerIrgInvers(soumisIRG);
                net_obtenu1 = (soumisSS * (1 - (decimal)((Taux_SS) * 0.01))) - (decimal)IRGRes;// + Taux_cacobatph
                net_obtenu1 = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, net_obtenu1);

                if (val == 0)
                    Dif = Math.Abs(net_obtenu1 - net_voulu);
            }

            BrutCotis = soumisSS;

            return BrutCotis;
        }

        public decimal CalculInverseIndemsMultiples(decimal Valeur, decimal MontantNCotisImpo, decimal MontantNCotisNImpo)
        {
            decimal net_voulu = Valeur;
            decimal val = net_voulu;
            decimal BrutCotis = 0; 
            decimal Dif = 0;

            decimal soumisSS = (net_voulu - MontantNCotisImpo - MontantNCotisNImpo) * 2;// Brut = net_voulu * 2 (grade valeur possible)

            decimal soumisIRG = soumisSS * (1 - (decimal)((Taux_SS) / 100)) + MontantNCotisImpo;//+ Taux_cacobatph
            soumisIRG = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, soumisIRG);

            decimal IRGRes = 0;
            IRGRes = CalculerIrgInvers(soumisIRG);

            decimal net_obtenu1 = (soumisSS * (1 - (decimal)((Taux_SS) * 0.01))) - IRGRes; // net_obtenu1 = soumis - IRGRes (grade valeur possible)+ Taux_cacobatph
            net_obtenu1 = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, net_obtenu1);

            //Dif = (decimal)0.0001;
            while ((Math.Abs(net_obtenu1 - net_voulu)) > Dif)
            {
                val = val / 2;
                if (net_obtenu1 > net_voulu)
                    soumisSS = soumisSS - val;
                else
                    soumisSS = soumisSS + val;
                soumisSS = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, soumisSS);

                soumisIRG = soumisSS * (1 - (decimal)((Taux_SS) * 0.01));//+ Taux_cacobatph
                soumisIRG = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, soumisIRG);

                IRGRes = CalculerIrgInvers(soumisIRG);
                net_obtenu1 = (soumisSS * (1 - (decimal)((Taux_SS) * 0.01))) - (decimal)IRGRes;// + Taux_cacobatph
                net_obtenu1 = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, net_obtenu1);

                if (val == 0)
                    Dif = Math.Abs(net_obtenu1 - net_voulu);
            }

            BrutCotis = soumisSS;

            return BrutCotis;
        }

        public decimal CalculerIrgInvers(decimal Soumis)
        {
            int[] Trs = { 0, 120000, 360000, 1440000, 99999999 };
            int[] Tax = { 0, 0, 20, 30, 35 };
            int[] Impan = { 0, 0, 48000, 372000, 3367999, 65 };

            decimal soumis = Math.Truncate((Soumis) / 10) * 10;
            decimal Brts = soumis * 12;
            int I = 1;
            while (Brts > Trs[I])
                I += 1;

            int taux = Tax[I];
            int Tb = Trs[I - 1];
            decimal Td = Impan[I - 1];
            decimal N = Brts - Tb;
            decimal ImpotA = (N * taux / 100) + Td; ;
            decimal ImpM = ImpotA / 12;
            decimal Abat = 0;

            Abat = ImpM * 40 / 100;
            if (Abat < 1000) { Abat = 1000; };
            if (Abat > 1500) { Abat = 1500; };

            decimal Ret = ImpM - Abat;
            if (Ret < 0) { Ret = 0; };

            decimal IrgRes = Ret * 10;

            int partent = (int)IrgRes;
            decimal partdec = IrgRes - partent;

            IrgRes = IrgRes - partdec;

            decimal c1 = partdec * 10;
            int partent1 = (int)c1;
            if (c1 > 5) { IrgRes = IrgRes + 1; };
            IrgRes = IrgRes / 10;
            if (IrgRes < 0) { IrgRes = 0; };
            IrgRes = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, IrgRes);

            return IrgRes;
        }

        /************************ Insertion Fiche pour Rappel *****************************************/

        public void InsererFicheRappel(Rappel Rappel)
        {
            Remise_A_0();
            InsererIndemRappel(Rappel);
            Session.CommitTransaction();
            AffectationIndemRappel();
            CalculTotauxRappel();

            SDBAbsence = SDB;
            SS_Bareme_Abs = Ss_bareme;
            SS_Taux_Abs = SS_Taux;
            SSAbsence = SS;
            Irg_bareme_Abs = Irg_bareme;
            Irg_taux_Abs = Irg_taux;
            IRGAbsence = Rappel.IRG_Mois;
            NETAbsence = NET;

            FromRappel = true;
        }

        public void InsererIndemRappel(Rappel Rappel)
        {

            XPCollection<paye_indem> colDelete = new XPCollection<paye_indem>(Session, CriteriaOperator.Parse("Paye=?", this));
            Session.Delete(colDelete);
            Session.Save(colDelete);

            foreach (Rappel_indem Indemnite in Rappel.Rappel_indems)
            {
                if (Indemnite.Indemnite.Cod_indem_interne != null)
                {
                    Session currentSession = this.Session;
                    paye_indem IndemniteAInserer = new paye_indem(currentSession);
                    IndemniteAInserer.Indemnite = Indemnite.Indemnite;
                    IndemniteAInserer.Montant = Indemnite.Montant_Mois;
                    IndemniteAInserer.Montant_Absence = Indemnite.Montant_Mois;

                    paye_indems.Add(IndemniteAInserer);

                    Save();
                }
            }
        }

        public void AffectationIndemRappel()
        {
            foreach (paye_indem Indemnite in paye_indems)
            {
                string indem = Indemnite.Indemnite.Cod_indem_interne.ToString();
                this.SetMemberValue(indem, Indemnite.Montant);
            }
        }

        public void CalculTotauxRappel()
        {
            decimal tempTotal = 0m;
            decimal tempTotalAbsence = 0m;
            decimal TempCotisable = 0m;
            decimal TempCotisableAbsence = 0m;
            decimal TempCotisableBareme = 0m;
            decimal TempCotisableBaremeAbsence = 0m;
            decimal TempCotisableTaux = 0m;
            decimal TempCotisableTauxAbsence = 0m;
            decimal TempImposableBareme = 0m;
            decimal TempImposableTaux = 0m;
            decimal TempImposableBareme_Abs = 0m;
            decimal TempImposableTaux_Abs = 0m;
            decimal TempImposable22 = 0m;
            decimal TempImposable22_Abs = 0m;
            decimal TempTotIndemImposNonCotis = 0m;
            decimal TempTotIndemImposNonCotis_Abs = 0m;
            decimal TempTotIndemNonImposNonCotis = 0m;
            decimal TempTotIndemNonImposNonCotis_Abs = 0m;

            foreach (paye_indem detail in paye_indems)
            {

                if (detail.Indemnite.Brut_Net_Incluse == InclusBrutNet.Brut)
                {
                    tempTotal += detail.Montant;
                    tempTotalAbsence += detail.Montant_Absence;
                }

                if (detail.Indemnite.Cotisable)
                {
                    TempCotisable += detail.Montant;
                    TempCotisableAbsence += detail.Montant_Absence;
                }

                if ((detail.Indemnite.Cotisable) && (detail.Indemnite.Mod_cal_irg == ModeCalculIRG.Sur_Barême))
                {
                    TempCotisableBareme += detail.Montant;
                    TempCotisableBaremeAbsence += detail.Montant_Absence;
                }

                if ((detail.Indemnite.Cotisable) && (detail.Indemnite.Mod_cal_irg == ModeCalculIRG.Sur_Taux))
                {
                    TempCotisableTaux += detail.Montant;
                    TempCotisableTauxAbsence += detail.Montant_Absence;
                }

                if ((detail.Indemnite.Imposable) && (detail.Indemnite.Mod_cal_irg == ModeCalculIRG.Sur_Barême))
                {
                    TempImposableBareme += detail.Montant;
                    TempImposableBareme_Abs += detail.Montant_Absence;
                }

                if ((detail.Indemnite.Imposable) && (detail.Indemnite.Mod_cal_irg == ModeCalculIRG.Sur_Taux))
                {
                    TempImposableTaux += detail.Montant;
                    TempImposableTaux_Abs += detail.Montant_Absence;
                }

                if ((detail.Indemnite.Imposable) && (detail.Indemnite.Mod_cal_irg == ModeCalculIRG.Sur_Barême) && (detail.Indemnite.Mode_Calcul_Absence == 22))
                {
                    TempImposable22 += detail.Montant;
                    TempImposable22_Abs += detail.Montant_Absence;
                }

                if ((detail.Indemnite.Imposable == true) && (detail.Indemnite.Cotisable == false) && (detail.Indemnite.Retenue != true))
                {
                    TempTotIndemImposNonCotis += detail.Montant;
                    TempTotIndemImposNonCotis_Abs += detail.Montant_Absence;
                }
                else
                    if ((detail.Indemnite.Imposable == false) && (detail.Indemnite.Cotisable == false) && (detail.Indemnite.Retenue != true) && (detail.Indemnite.Brut_Net_Incluse != InclusBrutNet.Sans))
                    {
                        TempTotIndemNonImposNonCotis += detail.Montant;
                        TempTotIndemNonImposNonCotis_Abs += detail.Montant_Absence;
                    }

            }

            BRUT = tempTotal;
            BRUTAbsence = tempTotalAbsence;

            Brute_cotisable = TempCotisable;
            Brute_cotisableAbsence = TempCotisableAbsence;

            Brute_cotisable_Bareme = TempCotisableBareme;
            Brute_cotisable_Bareme_Abs = TempCotisableBaremeAbsence;

            Brute_cotisable_Taux = TempCotisableTaux;
            Brute_cotisable_Taux_Abs = TempCotisableTauxAbsence;

            Imposable_bareme = TempImposableBareme;
            Imposable_bareme_Abs = TempImposableBareme;

            Imposable_taux = TempImposableTaux;
            Imposable_taux_Abs = TempImposableTaux;

            Brute_imposable = Imposable_taux + Imposable_bareme;
            Brute_imposable_Abs = Imposable_taux_Abs + Imposable_bareme_Abs;

            Imposable_bareme_22 = TempImposable22;
            Imposable_bareme_22_Abs = TempImposable22_Abs;

            Tot_Indem_impos_Non_Cotis = TempTotIndemImposNonCotis;
            Tot_Indem_impos_Non_Cotis_Abs = TempTotIndemImposNonCotis_Abs;

            Tot_Indem_Non_impos_Non_Cotis = TempTotIndemNonImposNonCotis;
            Tot_Indem_Non_impos_Non_Cotis_Abs = TempTotIndemNonImposNonCotis_Abs;
        }

        protected override void OnDeleting()
        {
            int mois = Convert.ToInt16(Mois);
            Cloture Cloture = Session.FindObject<Cloture>(CriteriaOperator.Parse("Cod_Cloture==?", mois + Annee.ToString()));

            if ((Cloture == null) || (Cloture != null && Cloture.Est_Cloture == false))
            {
                base.OnDeleting();

                if (cat_paye == CategoriePaye.Congé || cat_paye == CategoriePaye.Solde_tout_Compte)
                {
                    if (Conge_Calcule)
                    {
                        personne.Nbr_Jrs_Cong_Accor += Nbr_Jrs_Cong;
                        personne.Nbr_Jrs_Cong_Accor = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)personne.Nbr_Jrs_Cong_Accor);
                    }
                }
                else
                {
                    if (cat_paye == CategoriePaye.Paye_Mensuel)
                    {
                        CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", Mois);
                        CriteriaOperator criteria2 = CriteriaOperator.Parse("Annee==?", Annee);

                        Mois_Pret mois_pret = Session.FindObject<Mois_Pret>(CriteriaOperator.And(criteria1, criteria2));

                        if (mois_pret != null)
                        {
                            if (Retenu_Pret != 0)
                                mois_pret.Delete();
                        }

                        if (NbrJrsCRPrJrsTrv != 0 && NbrJrsTrvPrJrsCR != 0)
                        {
                            if (Conge_Calcule_Recup)
                                Calculer_Nbr_Jrs_Conge_Recup(Valide);
                            if (NbrJrsCRSN > 0)
                                personne.Nbr_Jrs_Cong_Recup_Accor -= NbrJrsCRSN;
                        }

                    }
                }

                XPCollection<paye_indem> Paye_Indem_Delete = new XPCollection<paye_indem>(Session, CriteriaOperator.Parse("Paye=?", Oid.ToString()));
                Session.Delete(Paye_Indem_Delete);
                Session.Save(Paye_Indem_Delete);
            }
            else
            {
                throw new Exception("La paye du ce mois a été cloturée !");
            }
        }

        protected override void OnSaving()
        {
            int mois = Convert.ToInt16(Mois);
            Cloture Cloture = Session.FindObject<Cloture>(CriteriaOperator.Parse("Cod_Cloture==?", mois + Annee.ToString()));

            if ((Cloture == null) || (Cloture != null && Cloture.Est_Cloture == false))
            {
                base.OnSaving();

                Indem indemTrs = this.Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "Prime_Transport"));
                if (indemTrs != null)
                {
                    CriteriaOperator criteria1Trs = CriteriaOperator.Parse("Indemnite==?", indemTrs.Oid.ToString());
                    CriteriaOperator criteria2Trs = CriteriaOperator.Parse("Paye==?", this);

                    paye_indem paye_indemTrs = this.Session.FindObject<paye_indem>(CriteriaOperator.And(criteria1Trs, criteria2Trs));

                    if (paye_indemTrs != null)
                        Jour_Trs = paye_indemTrs.INbr;
                }

                Indem indemPpn = this.Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "Prime_Pannier"));
                if (indemPpn != null)
                {
                    CriteriaOperator criteria1Ppn = CriteriaOperator.Parse("Indemnite==?", indemPpn.Oid.ToString());
                    CriteriaOperator criteria2Ppn = CriteriaOperator.Parse("Paye==?", this);

                    paye_indem paye_indemPpn = this.Session.FindObject<paye_indem>(CriteriaOperator.And(criteria1Ppn, criteria2Ppn));

                    if (paye_indemPpn != null)
                        Jour_Ppn = paye_indemPpn.INbr;
                }
            }
        }
          
    }
}
