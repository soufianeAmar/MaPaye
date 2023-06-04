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
    [System.ComponentModel.DisplayName("Employé")]
    //[DefaultClassOptions]
    public class Das_Personnes : BaseObject
    {

        private int fOrdre;
        public int Ordre
        {
            get { return fOrdre; }
            set { SetPropertyValue<int>("Ordre", ref fOrdre, value); }
        }

        private string fCod_personne; 
        public string Cod_personne
        {
            get { return fCod_personne; }
            set { SetPropertyValue<string>("Cod_personne", ref fCod_personne, value); }
        }

        private string fNom;
        public string Nom
        {
            get { return fNom; }
            set { SetPropertyValue<string>("Nom", ref fNom, value); }
        }

        private string fPrenom;
        public string Prenom
        {
            get { return fPrenom; }
            set { SetPropertyValue<string>("Prenom", ref fPrenom, value); }
        }

        private DateTime fDate_Naissance;
        public DateTime Date_Naissance
        {
            get { return fDate_Naissance; }
            set { SetPropertyValue<DateTime>("Date_Naissance", ref fDate_Naissance, value); }
        }

        private string fNaissance_Présumé;
        public string Naissance_Présumé
        {
            get { return fNaissance_Présumé; }
            set { SetPropertyValue<string>("Naissance_Présumé", ref fNaissance_Présumé, value); }
        }

        private string fLieu_nais; 
        public string Lieu_nais
        {
            get { return fLieu_nais; }
            set { SetPropertyValue<string>("Lieu_nais", ref fLieu_nais, value); }
        }

        private string fAdresse;
        public string Adresse
        {
            get { return fAdresse; }
            set { SetPropertyValue<string>("Adresse", ref fAdresse, value); }
        }

        private string fVille;
        public string Ville
        {
            get { return fVille; }
            set { SetPropertyValue<string>("Ville", ref fVille, value); }
        }

        private string fCodePostal;
        public string CodePostal
        {
            get { return fCodePostal; }
            set { SetPropertyValue<string>("CodePostal", ref fCodePostal, value); }
        }

        private Nationalite fNationalite;
        public Nationalite Nationalite
        {
            get { return fNationalite; }
            set { SetPropertyValue<Nationalite>("Nationalite", ref fNationalite, value); }
        }

        private bool fEtranger;
        public bool Etranger
        {
            get { return fEtranger; }
            set { SetPropertyValue<bool>("Etranger", ref fEtranger, value); }
        }

        private string fNCN;
        public string NCN
        {
            get { return fNCN; }
            set { SetPropertyValue<string>("NCN", ref fNCN, value); }
        }

        private string fIdNat;
        public string IdNat
        {
            get { return fIdNat; }
            set { SetPropertyValue<string>("IdNat", ref fIdNat, value); }
        }

        private string fNComptCCP;
        public string NComptCCP
        {
            get { return fNComptCCP; }
            set { SetPropertyValue<string>("NComptCCP", ref fNComptCCP, value); }
        }

        private string fCleComptCCP;
        public string CleComptCCP
        {
            get { return fCleComptCCP; }
            set { SetPropertyValue<string>("CleComptCCP", ref fCleComptCCP, value); }
        }

        private Banque fBanque; 
        public Banque Banque
        {
            get { return fBanque; }
            set { SetPropertyValue<Banque>("Banque", ref fBanque, value); }
        }

        private string fNComptBanque;
        public string NComptBanque
        {
            get { return fNComptBanque; }
            set { SetPropertyValue<string>("NComptBanque", ref fNComptBanque, value); }
        }

        private string fCleComptBanque;
        public string CleComptBanque
        {
            get { return fCleComptBanque; }
            set { SetPropertyValue<string>("CleComptBanque", ref fCleComptBanque, value); }
        }

        private Situation_Familiale fSit_fam;
        public Situation_Familiale Sit_fam
        {
            get { return fSit_fam; }
            set { SetPropertyValue<Situation_Familiale>("Sit_fam", ref fSit_fam, value); }
        }

        private Sexe fsexe;
        public Sexe sexe
        {
            get { return fsexe; }
            set { SetPropertyValue<Sexe>("sexe", ref fsexe, value); }
        }

        private string fLaFonction;
        public string LaFonction
        {
            get { return fLaFonction; }
            set { SetPropertyValue<string>("LaFonction", ref fLaFonction, value); }
        }

        private string fTlf;
        public string Tlf
        {
            get { return fTlf; }
            set { SetPropertyValue<string>("Tlf", ref fTlf, value); }
        }

        private string fEmail;
        public string Email
        {
            get { return fEmail; }
            set { SetPropertyValue<string>("Email", ref fEmail, value); }
        }
         
        private DateTime fDat_entre;
        public DateTime Dat_entre
        {
            get { return fDat_entre; }
            set { SetPropertyValue<DateTime>("Dat_entre", ref fDat_entre, value); }
        }
 
        private DateTime fDat_sortie;
        public DateTime Dat_sortie
        {
            get { return fDat_sortie; }
            set { SetPropertyValue<DateTime>("Dat_sortie", ref fDat_sortie, value); }
        }
         
        private unit_mes fUnit_mes;
        public unit_mes Unit_mes
        {
            get { return fUnit_mes; }
            set { SetPropertyValue<unit_mes>("Unit_mes", ref fUnit_mes, value); }
        }
         
        private string fnum_SecSoc;
        [Size(50)]
        public string num_SecSoc
        {
            get { return fnum_SecSoc; }
            set { SetPropertyValue<string>("num_SecSoc", ref fnum_SecSoc, value); }
        }

        private DAS_G fDAS_G;
        [Association("DAS_G-DAS_Personnes")]
        public DAS_G DAS_G
        {
            get { return fDAS_G; }
            set { SetPropertyValue<DAS_G>("DAS_G", ref fDAS_G, value); }
        }

        private int fjrs_trv_tr1;
        public int jrs_trv_tr1
        {
            get { return fjrs_trv_tr1; }
            set { SetPropertyValue<int>("jrs_trv_tr1", ref fjrs_trv_tr1, value); }
        }

        private int fjrs_trv_tr2;
        public int jrs_trv_tr2
        {
            get { return fjrs_trv_tr2; }
            set { SetPropertyValue<int>("jrs_trv_tr2", ref fjrs_trv_tr2, value); }
        }

        private int fjrs_trv_tr3;
        public int jrs_trv_tr3
        {
            get { return fjrs_trv_tr3; }
            set { SetPropertyValue<int>("jrs_trv_tr3", ref fjrs_trv_tr3, value); }
        }

        private int fjrs_trv_tr4;
        public int jrs_trv_tr4
        {
            get { return fjrs_trv_tr4; }
            set { SetPropertyValue<int>("jrs_trv_tr4", ref fjrs_trv_tr4, value); }
        }

        private int fjrs_trv_tr;
        public int jrs_trv_tr
        {
            get { return fjrs_trv_tr; }
            set { SetPropertyValue<int>("jrs_trv_tr", ref fjrs_trv_tr, value); }
        }

        private decimal fmontant_tr1;
        public decimal montant_tr1
        {
            get { return fmontant_tr1; }
            set { SetPropertyValue<decimal>("montant_tr1", ref fmontant_tr1, value); }
        }

        private decimal fmontant_tr2;
        public decimal montant_tr2
        {
            get { return fmontant_tr2; }
            set { SetPropertyValue<decimal>("montant_tr2", ref fmontant_tr2, value); }
        }

        private decimal fmontant_tr3;
        public decimal montant_tr3
        {
            get { return fmontant_tr3; }
            set { SetPropertyValue<decimal>("montant_tr3", ref fmontant_tr3, value); }
        }

        private decimal fmontant_tr4;
        public decimal montant_tr4
        {
            get { return fmontant_tr4; }
            set { SetPropertyValue<decimal>("montant_tr4", ref fmontant_tr4, value); }
        }

        private decimal fmontant;
        public decimal montant
        {
            get
            { return fmontant;
            }
            set { SetPropertyValue<decimal>("montant", ref fmontant, value); }
        } 

        public Das_Personnes(Session session)
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
            
             
        }
        protected override void OnSaving()
        {
            base.OnSaving();

            montant = montant_tr1 + montant_tr2 + montant_tr3 + montant_tr4;
            jrs_trv_tr = jrs_trv_tr1 + jrs_trv_tr2 + jrs_trv_tr3 + jrs_trv_tr4;
        }

        protected override void OnDeleting()
        {
            base.OnDeleting();
             
        }
    }



}
