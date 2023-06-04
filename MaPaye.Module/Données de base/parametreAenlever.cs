using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace MaPaye.Module.Données_de_base
{
    [DefaultClassOptions]
    public class parametre : BaseObject
    {
        private double fTaux_ss;
        public double Taux_ss
        {
            get { return fTaux_ss; }
            set { SetPropertyValue<double>("Taux_ss", ref fTaux_ss, value); }
        }
        private double fTaux_pp;
        public double Taux_pp
        {
            get { return fTaux_pp; }
            set { SetPropertyValue<double>("Taux_pp", ref fTaux_pp, value); }
        }
        private double fTaux_vf;
        public double Taux_vf
        {
            get { return fTaux_vf; }
            set { SetPropertyValue<double>("Taux_vf", ref fTaux_vf, value); }
        }
        private int fnbr_jour_ouv;
        public int nbr_jour_ouv
        {
            get { return fnbr_jour_ouv; }
            set { SetPropertyValue<int>("nbr_jour_ouv", ref fnbr_jour_ouv, value); }
        }
        private int fNbr_jour_tra;
        public int Nbr_jour_tra
        {
            get { return fNbr_jour_tra; }
            set { SetPropertyValue<int>("Nbr_jour_tra", ref fNbr_jour_tra, value); }
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
        private string fCentre_payeur;
        [Size(5)]
        public string Centre_payeur
        {
            get { return fCentre_payeur; }
            set { SetPropertyValue<string>("Centre_payeur", ref fCentre_payeur, value); }
        }
        private string fTyp_dec;
        [Size(1)]
        public string Typ_dec
        {
            get { return fTyp_dec; }
            set { SetPropertyValue<string>("Typ_dec", ref fTyp_dec, value); }
        }
        private string fAgence;
        [Size(30)]
        public string Agence
        {
            get { return fAgence; }
            set { SetPropertyValue<string>("Agence", ref fAgence, value); }
        }
        private bool fCacobath;
        public bool Cacobath
        {
            get { return fCacobath; }
            set { SetPropertyValue<bool>("Cacobath", ref fCacobath, value); }
        }
        private bool fCacobath_pat;
        public bool Cacobath_pat
        {
            get { return fCacobath_pat; }
            set { SetPropertyValue<bool>("Cacobath_pat", ref fCacobath_pat, value); }
        }
        private double fTaux_cacobath;
        public double Taux_cacobath
        {
            get { return fTaux_cacobath; }
            set { SetPropertyValue<double>("Taux_cacobath", ref fTaux_cacobath, value); }
        }
        private double fTaux_cacobath_pat;
        public double Taux_cacobath_pat
        {
            get { return fTaux_cacobath_pat; }
            set { SetPropertyValue<double>("Taux_cacobath_pat", ref fTaux_cacobath_pat, value); }
        }
        private string fbanque;
        [Size(200)]
        public string banque
        {
            get { return fbanque; }
            set { SetPropertyValue<string>("banque", ref fbanque, value); }
        }
        private string fMois_deb_cong;
        [Size(2)]
        public string Mois_deb_cong
        {
            get { return fMois_deb_cong; }
            set { SetPropertyValue<string>("Mois_deb_cong", ref fMois_deb_cong, value); }
        }
        private string fMois_fin_cong;
        [Size(2)]
        public string Mois_fin_cong
        {
            get { return fMois_fin_cong; }
            set { SetPropertyValue<string>("Mois_fin_cong", ref fMois_fin_cong, value); }
        }
        private double fnbr_jour_cong_mois;
        public double nbr_jour_cong_mois
        {
            get { return fnbr_jour_cong_mois; }
            set { SetPropertyValue<double>("nbr_jour_cong_mois", ref fnbr_jour_cong_mois, value); }
        }
        private string fmod_cal_prime_lic;
        [Size(50)]
        public string mod_cal_prime_lic
        {
            get { return fmod_cal_prime_lic; }
            set { SetPropertyValue<string>("mod_cal_prime_lic", ref fmod_cal_prime_lic, value); }
        }
        private double fnbr_heure_jour;
        public double nbr_heure_jour
        {
            get { return fnbr_heure_jour; }
            set { SetPropertyValue<double>("nbr_heure_jour", ref fnbr_heure_jour, value); }
        }
        private string fNum_compte_banq;
        public string Num_compte_banq
        {
            get { return fNum_compte_banq; }
            set { SetPropertyValue<string>("Num_compte_banq", ref fNum_compte_banq, value); }
        }
        private string fnom_rais_f;
        [Size(30)]
        public string nom_rais_f
        {
            get { return fnom_rais_f; }
            set { SetPropertyValue<string>("nom_rais_f", ref fnom_rais_f, value); }
        }
        private string fMod_cal_conge;
        [Size(50)]
        public string Mod_cal_conge
        {
            get { return fMod_cal_conge; }
            set { SetPropertyValue<string>("Mod_cal_conge", ref fMod_cal_conge, value); }
        }
        private bool fTyp_dec_cacobatph;
        public bool Typ_dec_cacobatph
        {
            get { return fTyp_dec_cacobatph; }
            set { SetPropertyValue<bool>("Typ_dec_cacobatph", ref fTyp_dec_cacobatph, value); }
        }
        private int fNum_dec_cacobatph;
        public int Num_dec_cacobatph
        {
            get { return fNum_dec_cacobatph; }
            set { SetPropertyValue<int>("Num_dec_cacobatph", ref fNum_dec_cacobatph, value); }
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
        private double fTaux_irg;
        public double Taux_irg
        {
            get { return fTaux_irg; }
            set { SetPropertyValue<double>("Taux_irg", ref fTaux_irg, value); }
        }
        private double ftaux_mutuel;
        public double taux_mutuel
        {
            get { return ftaux_mutuel; }
            set { SetPropertyValue<double>("taux_mutuel", ref ftaux_mutuel, value); }
        }
        private double ftaux_maj_sud;
        public double taux_maj_sud
        {
            get { return ftaux_maj_sud; }
            set { SetPropertyValue<double>("taux_maj_sud", ref ftaux_maj_sud, value); }
        }
        public parametre(Session session)
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
