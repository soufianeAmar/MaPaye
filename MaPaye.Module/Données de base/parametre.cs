using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using System.Drawing; 
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.DC;

namespace MaPaye.Module
{
    public enum ModeArrondi
    {
        Tronquer = 0,
        [XafDisplayName("Arrondi Mathématique")]Arrondi_Mathématique = 1,
        [XafDisplayName("Arrondi Chiffre Supperieur")]Arrondi_Chiffre_supperieur = 2,
    }

    public enum WeekEnd { [XafDisplayName("Jeudi-Vendredi")]Jeudi_Vendredi,  [XafDisplayName("Vendredi-Samedi")] Vendredi_Samedi, }
  
    public enum Type_Declar
    {
        [XafDisplayName("Déclaration Normale")]N,
        [XafDisplayName("Déclaration Complémentaire")] C,
        [XafDisplayName("Déclaration de Redressement")]R,
    }

    public enum ModeCalculNbrJrsConge
    {
        [XafDisplayName("Ne pas eliminer les jours d'absences")]
        SansAbsences,
        [XafDisplayName("Eliminer les jours d'absences")]
        AvecAbsences,
        [XafDisplayName("=0 si le nombre des jours d'absences > 15")]
        AvecAbsences15
    }

    [DefaultClassOptions]
    public class parametre : BaseObject
    {
        protected internal parametre(Session session) : base(session) { }

        public static parametre GetInstance(Session Session)
        { 
            parametre result = Session.FindObject<parametre>(null);
            if (result == null)
            {
                result = new parametre(Session);
                result.nom_rais_f = "Ma société";
                result.Annee_Travail = DateTime.Now.Year;

                Type_Absence TypeAbsence = Session.FindObject<Type_Absence>(CriteriaOperator.Parse("Type_Abs_Lib_Fr=?", Type_Abs_FR.Absence_Indemnite));
                result.Type_Abcense = TypeAbsence;
                result.Jr_Debut_Mois = 1;
                result.Nbr_jour_tra = 22;
                result.Nbr_Jour_Travail_Prime = 22;
                result.Nbr_heure_tra = 8;
                result.Nbr_heure_ouv = 173.33f;
                result.Aug_Auto_Taux_Iep_Org = true;
                result.Taux_Iep_Org = 1;
                result.Mois_debut_Cong = MoisdelAnnee.Juillet;
                result.Mois_fin_Cong = MoisdelAnnee.Juin;
                result.nbr_jour_cong_mois = 2.5f;

                result.Smig = 18000;
                result.Taux_cacobatph =  12.21f;
                result.Taux_chomage_intemperie =0.75f;
                result.Taux_chomage_intemperiePO =0.75f;
                result.Taux_irg = 10;
                result.Taux_ss = 9;
                result.Taux_pp = 25.5f;
                result.Taux_pp1 = 0.5f;
                //result.Taux_pp2 = 1;
                //result.Taux_pp3 = double.Parse("0,25");
                result.Mode_Arrondi = ModeArrondi.Arrondi_Mathématique;

                result.Save();
            }
            if (result != null)
                result.Save();
            return result;
        }

        private double fTaux_ss;
        public double Taux_ss
        {
            get { return fTaux_ss; }
            set { SetPropertyValue<double>("Taux_ss", ref fTaux_ss, value); }
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
         
        private double fNbr_heure_ouv;
        public double Nbr_heure_ouv
        {
            get { return fNbr_heure_ouv; }
            set { SetPropertyValue<double>("Nbr_heure_ouv", ref fNbr_heure_ouv, value); }
        }

        private double fNbr_heure_tra;
        public double Nbr_heure_tra
        {
            get { return fNbr_heure_tra; }
            set { SetPropertyValue<double>("Nbr_heure_tra", ref fNbr_heure_tra, value); }
        }

        private string fDenomination;
        public string Denomination
        {
            get { return fDenomination; }
            set { SetPropertyValue<string>("Denomination", ref fDenomination, value); }
        }

        private string fNum_employeur;
        [Size(50)]
        public string Num_employeur
        {
            get { return fNum_employeur; }
            set { SetPropertyValue<string>("Num_employeur", ref fNum_employeur, value); }
        }

        private string fAdresse;
        public string Adresse
        {
            get { return fAdresse; }
            set { SetPropertyValue<string>("Adresse", ref fAdresse, value); }
        }

        private string fAi;
        [Size(30)]
        public string Ai
        {
            get { return fAi; }
            set { SetPropertyValue<string>("Ai", ref fAi, value); }
        }

        private string fMf;
        [Size(30)]
        public string Mf
        {
            get { return fMf; }
            set { SetPropertyValue<string>("Mf", ref fMf, value); }
        }

        private string fRc;
        [Size(30)]
        public string Rc
        {
            get { return fRc; }
            set { SetPropertyValue<string>("Rc", ref fRc, value); }
        }
         
        private string fCentr_Payeur; 
        public string Centr_Payeur
        {
            get { return fCentr_Payeur; }
            set { SetPropertyValue<string>("Centr_Payeur", ref fCentr_Payeur, value); }
        }

        private Type_Declar fType_dec; 
        public Type_Declar Type_dec
        {
            get { return fType_dec; }
            set { SetPropertyValue<Type_Declar>("Type_dec", ref fType_dec, value); }
        }

        private string fAgence;
        [Size(30)]
        public string Agence
        {
            get { return fAgence; }
            set { SetPropertyValue<string>("Agence", ref fAgence, value); }
        }

        private string fAgenceCacobatph;
        [Size(30)]
        public string AgenceCacobatph
        {
            get { return fAgenceCacobatph; }
            set { SetPropertyValue<string>("AgenceCacobatph", ref fAgenceCacobatph, value); }
        }

        private Banque fbanqu;
        public Banque banqu
        {
            get { return fbanqu; }
            set { SetPropertyValue<Banque>("banqu", ref fbanqu, value); }
        }

        private MoisdelAnnee fMois_debut_Cong;
        public MoisdelAnnee Mois_debut_Cong
        {
            get { return fMois_debut_Cong; }
            set { SetPropertyValue<MoisdelAnnee>("Mois_debut_Cong", ref fMois_debut_Cong, value); }
        }

        private MoisdelAnnee fMois_fin_Cong; 
        public MoisdelAnnee Mois_fin_Cong
        {
            get { return fMois_fin_Cong; }
            set { SetPropertyValue<MoisdelAnnee>("Mois_fin_Cong", ref fMois_fin_Cong, value); }
        }

        private double fnbr_jour_cong_mois;
        public double nbr_jour_cong_mois
        {
            get { return fnbr_jour_cong_mois; }
            set { SetPropertyValue<double>("nbr_jour_cong_mois", ref fnbr_jour_cong_mois, value); }
        }

        private ModeCalculNbrJrsConge fJoursAbsJrsCong;
        public ModeCalculNbrJrsConge JoursAbsJrsCong
        {
            get { return fJoursAbsJrsCong; }
            set { SetPropertyValue<ModeCalculNbrJrsConge>("JoursAbsJrsCong", ref fJoursAbsJrsCong, value); }
        }
        
        private TimeSpan fHeureDebutShiftNuit;
        public TimeSpan HeureDebutShiftNuit
        {
            get { return fHeureDebutShiftNuit; }
            set { SetPropertyValue<TimeSpan>("HeureDebutShiftNuit", ref fHeureDebutShiftNuit, value); }
        }

        private int fNbrHeuresShiftNuit;
        public int NbrHeuresShiftNuit
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

        private int fNbrJrsCRPrJrsTrv;
        public int NbrJrsCRPrJrsTrv
        {
            get { return fNbrJrsCRPrJrsTrv; }
            set { SetPropertyValue<int>("NbrJrsCRPrJrsTrv", ref fNbrJrsCRPrJrsTrv, value); }
        }

        private string fNum_compte_banq;
        public string Num_compte_banq
        {
            get { return fNum_compte_banq; }
            set { SetPropertyValue<string>("Num_compte_banq", ref fNum_compte_banq, value); }
        }

        private string fCle_compte_banq;
        public string Cle_compte_banq
        {
            get { return fCle_compte_banq; }
            set { SetPropertyValue<string>("Cle_compte_banq", ref fCle_compte_banq, value); }
        }

        private string fnom_rais_f;
        [Size(30)]
        public string nom_rais_f
        {
            get { return fnom_rais_f; }
            set { SetPropertyValue<string>("nom_rais_f", ref fnom_rais_f, value); }
        }

        private string fnom_DG; 
        public string nom_DG
        {
            get { return fnom_DG; }
            set { SetPropertyValue<string>("nom_DG", ref fnom_DG, value); }
        }

        private string fActivite; 
        public string Activite
        {
            get { return fActivite; }
            set { SetPropertyValue<string>("Activite", ref fActivite, value); }
        }

        private string fTel;
        public string Tel
        {
            get { return fTel; }
            set { SetPropertyValue<string>("Tel", ref fTel, value); }
        }

        private string fFax;
        public string Fax
        {
            get { return fFax; }
            set { SetPropertyValue<string>("Fax", ref fFax, value); }
        }

        private string fEmail;
        public string Email
        {
            get { return fEmail; }
            set { SetPropertyValue<string>("Email", ref fEmail, value); }
        }

        private string fSite_Web;
        public string Site_Web
        {
            get { return fSite_Web; }
            set { SetPropertyValue<string>("Site_Web", ref fSite_Web, value); }
        }

        private double fTaux_irg;
        public double Taux_irg
        {
            get { return fTaux_irg; }
            set { SetPropertyValue<double>("Taux_irg", ref fTaux_irg, value); }
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

        private double ftaux_maj_sud;
        public double taux_maj_sud
        {
            get { return ftaux_maj_sud; }
            set { SetPropertyValue<double>("taux_maj_sud", ref ftaux_maj_sud, value); }
        }

        private decimal fSmig;
        public decimal Smig
        {
            get { return fSmig; }
            set { SetPropertyValue<decimal>("Smig", ref fSmig, value); }
        }

        private decimal fBase_SU;
        public decimal Base_SU
        {
            get { return fBase_SU; }
            set { SetPropertyValue<decimal>("Base_SU", ref fBase_SU, value); }
        }

        private decimal fBase_SU_Partiel;
        public decimal Base_SU_Partiel
        {
            get { return fBase_SU_Partiel; }
            set { SetPropertyValue<decimal>("Base_SU_Partiel", ref fBase_SU_Partiel, value); }
        }

        private bool fAbsSU;
        public bool AbsSU
        {
            get { return fAbsSU; }
            set { SetPropertyValue<bool>("AbsSU", ref fAbsSU, value); }
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

        private decimal fBase_Prime_Scol;
        public decimal Base_Prime_Scol
        {
            get { return fBase_Prime_Scol; }
            set { SetPropertyValue<decimal>("Base_Prime_Scol", ref fBase_Prime_Scol, value); }
        }

        private decimal fBase_Prime_Scol_Partiel;
        public decimal Base_Prime_Scol_Partiel
        {
            get { return fBase_Prime_Scol_Partiel; }
            set { SetPropertyValue<decimal>("Base_Prime_Scol_Partiel", ref fBase_Prime_Scol_Partiel, value); }
        }

        private decimal fPlafond_mutuelle;
        public decimal Plafond_mutuelle
        {
            get { return fPlafond_mutuelle; }
            set { SetPropertyValue<decimal>("Plafond_mutuelle", ref fPlafond_mutuelle, value); }
        }

        private decimal fValeur_mutuelle;
        public decimal Valeur_mutuelle
        {
            get { return fValeur_mutuelle; }
            set { SetPropertyValue<decimal>("Valeur_mutuelle", ref fValeur_mutuelle, value); }
        }

        private double fTaux_Mutuel;
        public double Taux_Mutuel
        {
            get { return fTaux_Mutuel; }
            set { SetPropertyValue<double>("Taux_Mutuel", ref fTaux_Mutuel, value); }
        }

        private double fNbr_heure_tra_Temporaire; //26
        public double Nbr_heure_tra_Temporaire
        {
            get { return fNbr_heure_tra_Temporaire; }
            set { SetPropertyValue<double>("Nbr_heure_tra_Temporaire", ref fNbr_heure_tra_Temporaire, value); }
        }

        private decimal fSDB_Heur;
        public decimal SDB_Heur
        {
            get { return fSDB_Heur; }
            set { SetPropertyValue<decimal>("SDB_Heur", ref fSDB_Heur, value); }
        }
          
        private double fNbr_heure_tra_Partiel_Mois; //108.33
        public double Nbr_heure_tra_Partiel_Mois
        {
            get { return fNbr_heure_tra_Partiel_Mois; }
            set { SetPropertyValue<double>("Nbr_heure_tra_Partiel_Mois", ref fNbr_heure_tra_Partiel_Mois, value); }
        }

        private int fNbr_jour_tra; //30
        public int Nbr_jour_tra
        {
            get { return fNbr_jour_tra; }
            set { SetPropertyValue<int>("Nbr_jour_tra", ref fNbr_jour_tra, value); }
        }

        private double fNbr_Jour_Travail_Prime; //22
        public double Nbr_Jour_Travail_Prime
        {
            get { return fNbr_Jour_Travail_Prime; }
            set { SetPropertyValue<double>("Nbr_Jour_Travail_Prime", ref fNbr_Jour_Travail_Prime, value); }
        }

        private int fNbr_jour_tra_Temp; //26
        public int Nbr_jour_tra_Temp
        {
            get { return fNbr_jour_tra_Temp; }
            set { SetPropertyValue<int>("Nbr_jour_tra_Temp", ref fNbr_jour_tra_Temp, value); }
        }

        private decimal fBase_Resident;
        public decimal Base_Resident
        {
            get { return fBase_Resident; }
            set { SetPropertyValue<decimal>("Base_Resident", ref fBase_Resident, value); }
        }

        private bool fAug_Auto_Taux_Iep_Org;
        public bool Aug_Auto_Taux_Iep_Org
        {
            get { return fAug_Auto_Taux_Iep_Org; }
            set { SetPropertyValue<bool>("Aug_Auto_Taux_Iep_Org", ref fAug_Auto_Taux_Iep_Org, value); }
        }

        private double fTaux_Iep_Org;
        public double Taux_Iep_Org
        {
            get { return fTaux_Iep_Org; }
            set { SetPropertyValue<double>("Taux_Iep_Org", ref fTaux_Iep_Org, value); }
        }

        private double fTaux_Iep_Hors_Secteur_Prive;
        public double Taux_Iep_Hors_Secteur_Prive
        {
            get { return fTaux_Iep_Hors_Secteur_Prive; }
            set { SetPropertyValue<double>("Taux_Iep_Hors_Secteur_Prive", ref fTaux_Iep_Hors_Secteur_Prive, value); }
        }

        private double fTaux_Iep_Hors_Secteur_Etat;
        public double Taux_Iep_Hors_Secteur_Etat
        {
            get { return fTaux_Iep_Hors_Secteur_Etat; }
            set { SetPropertyValue<double>("Taux_Iep_Hors_Secteur_Etat", ref fTaux_Iep_Hors_Secteur_Etat, value); }
        }

        private int fAnnee_Travail;
        public int Annee_Travail
        {
            get { return fAnnee_Travail; }
            set { SetPropertyValue<int>("Annee_Travail", ref fAnnee_Travail, value); }
        }

        private Type_Absence fType_Abcense;
        public Type_Absence Type_Abcense
        {
            get { return fType_Abcense; }
            set { SetPropertyValue<Type_Absence>("Type_Abcense", ref fType_Abcense, value); }
        }

        private bool fCalcul_Absence_Auto;
        public bool Calcul_Absence_Auto
        {
            get { return fCalcul_Absence_Auto; }
            set { SetPropertyValue<bool>("Calcul_Absence_Auto", ref fCalcul_Absence_Auto, value); }
        }

        private ModeArrondi fMode_Arrondi;
        public ModeArrondi Mode_Arrondi
        {
            get { return fMode_Arrondi; }
            set { SetPropertyValue<ModeArrondi>("Mode_Arrondi", ref fMode_Arrondi, value); }
        }

        private int fNbr_Mois_Pri;
        public int Nbr_Mois_Pri
        {
            get { return fNbr_Mois_Pri; }
            set { SetPropertyValue<int>("Nbr_Mois_Pri", ref fNbr_Mois_Pri, value); }
        }

        private double fTaux_Pri;
        public double Taux_Pri
        {
            get { return fTaux_Pri; }
            set { SetPropertyValue<double>("Taux_Pri", ref fTaux_Pri, value); }
        }

        private int fNote_Pri;
        [ImmediatePostData]
        public int Note_Pri
        {
            get { return fNote_Pri; }
            set { SetPropertyValue<int>("Note_Pri", ref fNote_Pri, value); }
        }

        private double fTaux_PAP;
        public double Taux_PAP
        {
            get { return fTaux_PAP; }
            set { SetPropertyValue<double>("Taux_PAP", ref fTaux_PAP, value); }
        }

        private int fNbr_Mois_PAP;
        public int Nbr_Mois_PAP
        {
            get { return fNbr_Mois_PAP; }
            set { SetPropertyValue<int>("Nbr_Mois_PAP", ref fNbr_Mois_PAP, value); }
        }

        private int fNote_PAP;
        [ImmediatePostData]
        public int Note_PAP
        {
            get { return fNote_PAP; }
            set { SetPropertyValue<int>("Note_PAP", ref fNote_PAP, value); }
        }
         
        private string fReceveur_Fr;
        public string Receveur_Fr
        {
            get { return fReceveur_Fr; }
            set { SetPropertyValue<string>("Receveur_Fr", ref fReceveur_Fr, value); }
        }

        private string fReceveur_Num_Compte;
        public string Receveur_Num_Compte
        {
            get { return fReceveur_Num_Compte; }
            set { SetPropertyValue<string>("Receveur_Num_Compte", ref fReceveur_Num_Compte, value); }
        }

        private string fReceveur_Cle_Compte;
        public string Receveur_Cle_Compte
        {
            get { return fReceveur_Cle_Compte; }
            set { SetPropertyValue<string>("Receveur_Cle_Compte", ref fReceveur_Cle_Compte, value); }
        }
         
        private string fOrganisme_Fr;
        public string Organisme_Fr
        {
            get { return fOrganisme_Fr; }
            set { SetPropertyValue<string>("Organisme_Fr", ref fOrganisme_Fr, value); }
        }
          
        private string fRegion_Fr;
        public string Region_Fr
        {
            get { return fRegion_Fr; }
            set { SetPropertyValue<string>("Region_Fr", ref fRegion_Fr, value); }
        }
         
        private string fCommune_Fr;
        public string Commune_Fr
        {
            get { return fCommune_Fr; }
            set { SetPropertyValue<string>("Commune_Fr", ref fCommune_Fr, value); }
        }

        private string fDaira_Fr;
        public string Daira_Fr
        {
            get { return fDaira_Fr; }
            set { SetPropertyValue<string>("Daira_Fr", ref fDaira_Fr, value); }
        }
         
        private string fWilaya_Fr;
        public string Wilaya_Fr
        {
            get { return fWilaya_Fr; }
            set { SetPropertyValue<string>("Wilaya_Fr", ref fWilaya_Fr, value); }
        }
         
        private string fDesignation_Caisse;
        public string Designation_Caisse
        {
            get { return fDesignation_Caisse; }
            set { SetPropertyValue<string>("Designation_Caisse", ref fDesignation_Caisse, value); }
        }

        private string fNIS;
        public string NIS
        {
            get { return fNIS; }
            set { SetPropertyValue<string>("NIS", ref fNIS, value); }
        }

        private string fNIF;
        public string NIF
        {
            get { return fNIF; }
            set { SetPropertyValue<string>("NIF", ref fNIF, value); }
        }
         
        private string fTIN;
        public string TIN
        {
            get { return fTIN; }
            set { SetPropertyValue<string>("TIN", ref fTIN, value); }
        }

        [Delayed]
        [ValueConverter(typeof(DevExpress.Xpo.Metadata.ImageValueConverter))]
        public Image Logo
        {
            get { return GetDelayedPropertyValue<Image>("Logo"); }
            set { SetDelayedPropertyValue<Image>("Logo", value); }
        }

        private int fEff_Janv;
        public int Eff_Janv
        {
            get { return fEff_Janv; }
            set { SetPropertyValue<int>("Eff_Janv", ref fEff_Janv, value); }
        }
         
        private int fEff_Fev;
        public int Eff_Fev
        {
            get { return fEff_Fev; }
            set { SetPropertyValue<int>("Eff_Fev", ref fEff_Fev, value); }
        }
         
        private int fEff_Mars;
        public int Eff_Mars
        {
            get { return fEff_Mars; }
            set { SetPropertyValue<int>("Eff_Mars", ref fEff_Mars, value); }
        }
         
        private int fEff_Avr;
        public int Eff_Avr
        {
            get { return fEff_Avr; }
            set { SetPropertyValue<int>("Eff_Avr", ref fEff_Avr, value); }
        }

        private int fEff_Mai;
        public int Eff_Mai
        {
            get { return fEff_Mai; }
            set { SetPropertyValue<int>("Eff_Mai", ref fEff_Mai, value); }
        }

        private int fEff_Juin;
        public int Eff_Juin
        {
            get { return fEff_Juin; }
            set { SetPropertyValue<int>("Eff_Juin", ref fEff_Juin, value); }
        }

        private int fEff_Juill;
        public int Eff_Juill
        {
            get { return fEff_Juill; }
            set { SetPropertyValue<int>("Eff_Juill", ref fEff_Juill, value); }
        }
         
        private int fEff_Aout;
        public int Eff_Aout
        {
            get { return fEff_Aout; }
            set { SetPropertyValue<int>("Eff_Aout", ref fEff_Aout, value); }
        }

        private int fEff_Sept;
        public int Eff_Sept
        {
            get { return fEff_Sept; }
            set { SetPropertyValue<int>("Eff_Sept", ref fEff_Sept, value); }
        }

        private int fEff_Oct;
        public int Eff_Oct
        {
            get { return fEff_Oct; }
            set { SetPropertyValue<int>("Eff_Oct", ref fEff_Oct, value); }
        }
         
        private int fEff_Nouv;
        public int Eff_Nouv
        {
            get { return fEff_Nouv; }
            set { SetPropertyValue<int>("Eff_Nouv", ref fEff_Nouv, value); }
        }

        private int fJr_Debut_Mois;
        public int Jr_Debut_Mois
        {
            get { return fJr_Debut_Mois; }
            set { SetPropertyValue<int>("Jr_Debut_Mois", ref fJr_Debut_Mois, value); }
        }

        private WeekEnd fWeekEnd;
        public WeekEnd WeekEnd
        {
            get { return fWeekEnd; }
            set { SetPropertyValue<WeekEnd>("WeekEnd", ref fWeekEnd, value); }
        }

        private int fEff_Dec;
        public int Eff_Dec
        {
            get { return fEff_Dec; }
            set { SetPropertyValue<int>("Eff_Dec", ref fEff_Dec, value); }
        }
         
        private bool fAdmin;
        public bool Admin
        {
            get { return fAdmin; }
            set { SetPropertyValue<bool>("Admin", ref fAdmin, value); }
        }

        private bool fLimite_Iep_ext;
        public bool Limite_Iep_ext
        {
            get { return fLimite_Iep_ext; }
            set { SetPropertyValue<bool>("Limite_Iep_ext", ref fLimite_Iep_ext, value); }
        }

        private bool fLimite_Iep;
        public bool Limite_Iep
        {
            get { return fLimite_Iep; }
            set { SetPropertyValue<bool>("Limite_Iep", ref fLimite_Iep, value); }
        }

        private double fLimite_Iep_ext_à;
        public double Limite_Iep_ext_à
        {
            get { return fLimite_Iep_ext_à; }
            set { SetPropertyValue<double>("Limite_Iep_ext_à", ref fLimite_Iep_ext_à, value); }
        }

        private double fLimite_Iep_à;
        public double Limite_Iep_à
        {
            get { return fLimite_Iep_à; }
            set { SetPropertyValue<double>("Limite_Iep_à", ref fLimite_Iep_à, value); }
        }

        private bool fDeclarationMultiple;
        public bool DeclarationMultiple
        {
            get { return fDeclarationMultiple; }
            set { SetPropertyValue<bool>("DeclarationMultiple", ref fDeclarationMultiple, value); }
        }
         
        public override void AfterConstruction()
        {
            base.AfterConstruction(); 
        }

        //Prevent the Singleton from being deleted
        protected override void OnDeleting()
        {
            throw new Exception("Impossible de supprimer les paramètres de la société !");
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            if (Type_Abcense == null)
            {
                CriteriaOperator condition1 = CriteriaOperator.Parse("Type_Abs_Lib_Fr=?", Type_Abs_FR.Absence_Net.ToString());
                Type_Absence TypeAbs = Session.FindObject<Type_Absence>(PersistentCriteriaEvaluationBehavior.InTransaction,
                    CriteriaOperator.And(condition1));

                if (TypeAbs != null)
                    Type_Abcense = TypeAbs;
            }
        }

        public void nbr_eff(int LeMois)
        {
            //int cpt_sort = 0;
            int cpt_entr = 0;

            //Eff_Janv = 0;
            //Eff_Fev = 0;
            //Eff_Mars = 0;
            //Eff_Avr = 0;
            //Eff_Mai = 0;
            //Eff_Juin = 0;
            //Eff_Juill = 0;
            //Eff_Aout = 0;
            //Eff_Sept = 0;
            //Eff_Oct = 0;
            //Eff_Nouv = 0;
            //Eff_Dec = 0;

            //int month = 0;
            DateTime date = new DateTime();

            if (LeMois < 12)
            { 
                date = new DateTime(DateTime.Now.Year, LeMois, Jr_Debut_Mois);
            }
            else
            { 
                date = new DateTime(DateTime.Now.Year, LeMois, 31);
            }


            XPCollection<Personne> personne = new XPCollection<Personne>(Session);
            personne.Load();

            foreach (Personne employe in personne)
            {

                CriteriaOperator criteria1 = CriteriaOperator.Parse("personne==?", employe);
                CriteriaOperator criteria2 = CriteriaOperator.Parse("Mois==?", LeMois);

                Paye Paye = Session.FindObject<Paye>(CriteriaOperator.And(criteria1, criteria2));

                if (Paye != null)
                    if ((employe.Dat_entre < date) && ((employe.Dat_sortie == DateTime.MinValue) || (employe.Dat_sortie >= date)))
                        cpt_entr += 1;
                    //else
                    //    if ((employe.Dat_sortie <= date) && (employe.Dat_sortie != DateTime.MinValue))
                    //        cpt_sort += 1;

            } 
             

            switch (LeMois)
            {
                case 1:
                    {
                       
                        Eff_Janv = cpt_entr;
                        //Eff_Janv -= cpt_sort;
                    }
                    break;
                case 2:
                    {
                        Eff_Fev = cpt_entr;
                        //Eff_Fev -= cpt_sort;
                    }
                    break;
                case 3:
                    {
                        Eff_Mars = cpt_entr;
                        //Eff_Mars -= cpt_sort;
                    }
                    break;
                case 4:
                    {
                        Eff_Avr = cpt_entr;
                        //Eff_Avr -= cpt_sort;
                    }
                    break;
                case 5:
                    {
                        Eff_Mai = cpt_entr;
                        //Eff_Mai -= cpt_sort;
                    }
                    break;
                case 6:
                    {
                        Eff_Juin = cpt_entr;
                        //Eff_Juin -= cpt_sort;
                    }
                    break;
                case 7:
                    {
                        Eff_Juill = cpt_entr;

                    }
                    break;
                case 8:
                    {
                        Eff_Aout = cpt_entr;
                        //Eff_Aout -= cpt_sort;
                    }
                    break;
                case 9:
                    {
                        Eff_Sept = cpt_entr;
                        //Eff_Sept -= cpt_sort;
                    }
                    break;
                case 10:
                    {
                        Eff_Oct = cpt_entr;
                        //Eff_Oct -= cpt_sort;
                    }
                    break;
                case 11:
                    {
                        Eff_Nouv = cpt_entr;
                        //Eff_Nouv -= cpt_sort;
                    }
                    break;
                case 12:
                    {
                        Eff_Dec = cpt_entr;
                        //Eff_Dec -= cpt_sort;
                    }
                    break;
            }

        }
         
        public void Initialise_Eff(int LeMois)
        { 
            switch (LeMois)
            {
                case 1:
                    {
                        Eff_Janv = 0;
                    }
                    break;
                case 2:
                    {
                        Eff_Fev = 0;
                    }
                    break;
                case 3:
                    {
                        Eff_Mars = 0;
                    }
                    break;
                case 4:
                    {
                        Eff_Avr = 0;
                    }
                    break;
                case 5:
                    {
                        Eff_Mai = 0;
                    }
                    break;
                case 6:
                    {
                        Eff_Juin = 0;
                    }
                    break;
                case 7:
                    {
                        Eff_Juill = 0;
                    }
                    break;
                case 8:
                    {
                        Eff_Aout = 0;
                    }
                    break;
                case 9:
                    {
                        Eff_Sept = 0;
                    }
                    break;
                case 10:
                    {
                        Eff_Oct = 0;
                    }
                    break;
                case 11:
                    {
                        Eff_Nouv = 0;
                    }
                    break;
                case 12:
                    {
                        Eff_Dec = 0; 
                    }
                    break;
            }

        }
    }

}
