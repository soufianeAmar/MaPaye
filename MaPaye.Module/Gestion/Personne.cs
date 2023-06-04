using System;
using System.ComponentModel; 
using DevExpress.Xpo; 
using DevExpress.Data.Filtering; 
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using System.Windows.Forms;
using MaPayeAdmin;
using DevExpress.ExpressApp.DC; 

namespace MaPaye.Module
{
    public enum SituationFamiliale { Célibataire, Marié, Divorcé, Veuf }
    public enum unit_mes { [XafDisplayName("Mensuel")]M, [XafDisplayName("Journalier")] J, [XafDisplayName("Horaire")] H }
    public enum VacataireCP { [XafDisplayName("Contractuel Temps Complet")]Vacataire_Complet, [XafDisplayName("Contractuel Temps Partiel")] Vacataire_Partiel }
    public enum Nationalite {  
        Afghan = 1,
        [XafDisplayName("Aland Islands")]Aland_Islands = 2,
        Albanian=3, 
        Algerian=4, 
        [XafDisplayName("American Samoa")]American_Samoa=5,
        Andorran=6,  
        Angolan=7, 
        Anguillan=8,  
        Antarctica=9,  
        [XafDisplayName("Antigua And Barbuda")]Antigua_And_Barbuda=10,   
        Argentinean=11,
        Armenian=12,
        Aruba = 13 ,
        Australian=14,
        Austrian=15,
        Azerbaijani=16,
        Bahamian=17,
        Bahraini=18,
        Bangladeshi=19,
        Barbadian=20,
        Belarusian=21,
        Belgian=22,
        Belizean=23,
        Beninese=24,
        Bermuda=25,
        Bhutanese=26,
        Bolivian=27,
        Bosnian=28,
        Botswana = 29,
        [XafDisplayName("Bouvet Island")]Bouvet_Island = 30,
        Brazilian=31,
        British=32,
        Bruneian=33,
        Bulgarian=34,
        Burkinabe=36, 
        Burundian=36,
        Cambodian=37,
        Cameroonian=38,
        Canadian=39,
        [XafDisplayName("Cape Verdean")]Cape_Verdean=40,
        [XafDisplayName("Cayman Islands")]Cayman_Islands=41,
        [XafDisplayName("Central African")]Central_African=42,
        Chadian=43,
        Chilean=44,
        Chinese=45,
        [XafDisplayName("Christmas Island")]Christmas_Island = 46,
        [XafDisplayName("Cocos (keeling) Islands")]Cocos_Islands = 47,
        Colombian=48,
        Comoran=49,
        Congolese=50,
        [XafDisplayName("Congo, The Democratic Republic")]Congo_The_Democratic_Republic=51,
        [XafDisplayName("Cook Islands")]Cook_Islands=52,
        [XafDisplayName("Costa Rican")]Costa_Rican=53,
        [XafDisplayName("CÔte D'ivoire")]CÔte_Divoire = 54,
        Croatian=55,
        Cuban=56,
        Cypriot=57,
        Czech=58,
        Danish=59,
        Djibouti=60,
        Dominican=61,
        [XafDisplayName("Dominican Republic")]Dominican_Republic=62,
        Ecuadorean=63,
        Egyptian=64,
        [XafDisplayName("El Salvador")]El_Salvador=65,
        [XafDisplayName("Equatorial Guinean")]Equatorial_Guinean=66,
        Eritrean=67,
        Estonian=68,
        Ethiopian=69,
        [XafDisplayName("Falkland Islands (malvinas)")]Falkland_Islands = 70,
        [XafDisplayName("Faroe Islands")]Faroe_Islands  = 71,
        Fijian=72,
        Finland = 73, 
        French=74,
        [XafDisplayName("French Guiana")] French_Guiana= 75,
        [XafDisplayName("French Polynesia")] French_Polynesia= 76 ,
        [XafDisplayName("French Southern Territories")]French_Southern_Territories = 77,
        Gabonese=78,
        Gambian=79,
        Georgian=80,
        German=81,
        Ghanaian=82,
        Gibraltar = 83,
        Greek=84,
        Greenland=85,
        Grenadian=86,
        Guadeloupe = 87,
        Guam=88,
        Guatemalan=89,
        Guernsey=90,
        Guinean =91,
        [XafDisplayName("Guinea-Bissauan")]Guinea_Bissauan=92,
        Guyanese=93,
        Haitian=94,
        Herzegovinian=95,
        Honduran=96,
        [XafDisplayName("Hong Kong")]Hong_Kong = 97,
        Hungarian=98,
        Icelander=99,
        Indian=100,
        Indonesian=101,
        Iranian=102,
        Iraqi=103,
        Irish=104,
        [XafDisplayName("Isle Of Man")]Isle_Of_Man = 105,
        Israeli=106,
        Italian=107,
        Jamaican=108,
        Japanese=109,
        Jersey =110,
        Jordanian=111,
        Kazakhstani=112,
        Kenyan=113,
        Kiribati = 114,
        [XafDisplayName("Korea, Democratic People's Republic Of")]
        Korea_Democratic_Peoples_Republic_Of = 115,
        [XafDisplayName("Korea, Republic Of")]
        Korea_Republic_Of = 116,
        Kuwaiti=117,
        Kyrgyz=118,
        Laotian=119,
        Latvian=120,
        Lebanese=121,
        Lesotho=122,
        Liberian=123,
        Libyan=124,
        Liechtensteiner=125,
        Lithuanian=126,
        Luxembourger=127,
        Macao = 128,
        Macedonian=129,
        Madagascar = 130,
        Malawian=131,
        Malaysian=132,
        Maldivan=133,
        Malian=134,
        Maltese=135,
        Marshallese=136,
        Martinique = 137,
        Mauritanian=138,
        Mauritian=139,
        Mayotte = 140,
        Mexican=141,
        Micronesian=142,
        Moldovan=143,
        Monacan=144,
        Mongolian=145,
        Montenegro=146,
        Montserrat=147,
        Moroccan=148, 
        Mozambican=149,
        Myanmar=150,
        Namibian=151,
        Nauruan=152,
        Nepalese=153,
        Netherlands = 154,
        [XafDisplayName("Netherlands Antilles")]Netherlands_Antilles = 155,
        [XafDisplayName("New Caledonia")]New_Caledonia = 156,
        [XafDisplayName("New Zealander")]New_Zealander=157,
        Nicaraguan=158,
        Nigerian=160, 
        Niue =161,
        [XafDisplayName("Norfolk Island")]Norfolk_Island = 162,
        [XafDisplayName("Northern Irish")]Northern_Irish=163,
        Norwegian=164,
        Omani=165,
        Pakistani=166,
        Palauan=167,
        [XafDisplayName("Palestinian Territory, Occupied")]Palestinian = 168 ,
        Panamanian=169,
        [XafDisplayName("Papua New Guinean")]Papua_New_Guinean=170,
        Paraguayan=171,
        Peruvian=172,
        Philippines = 173,
        Pitcairn = 174,
        Polish=175, 
        Portuguese=176,
        [XafDisplayName("Puerto Rico")]Puerto_Rico = 177,
        Qatari=178,
        REunion = 179,
        Romanian=180,
        Russian=181,
        Rwandan=182,
        [XafDisplayName("Saint BarthÉlemy")]Saint_BarthÉlemy = 183,
        [XafDisplayName("Saint Helena")]Saint_Helena = 184,
        [XafDisplayName("Saint Kitts And Nevis")]Saint_Kitts_And_Nevis = 185,
        [XafDisplayName("Saint Lucian")]Saint_Lucian=186,
        [XafDisplayName("Saint Martin")]Saint_Martin=187,
        [XafDisplayName("Saint Pierre And Miquelon")]Saint_Pierre_And_Miquelon = 188,
        [XafDisplayName("Saint Vincent And The Grenadines")]Saint_Vincent_And_The_Grenadines=189,
        Samoan=159,
        [XafDisplayName("San Marinese")]San_Marinese=191,
        [XafDisplayName("Sao Tomean")]Sao_Tomean=192,
        Saudi=193, 
        Senegalese=194,
        Serbian=195,
        Seychellois=196,
        [XafDisplayName("Sierra Leonean")]Sierra_Leonean=197,
        Singaporean=198,
        Slovakian=199,
        Slovenian=200,
        [XafDisplayName("Solomon Islander")]Solomon_Islander=201,
        Somali=202,
        [XafDisplayName("South African")]South_African=203,
        [XafDisplayName("South Georgia And The South Sandwich Isl")]South_Georgia = 204,
        Spanish=205,
        [XafDisplayName("Sri Lankan")]Sri_Lankan=206,
        Sudanese=207,
        Surinamer=208,
        [XafDisplayName("Svalbard And Jan Mayen")]Svalbard_And_Jan_Mayen = 209,
        Swazi=210,
        Swedish=211,
        Swiss=212,
        Syrian=213,
        Taiwanese=214,
        Tajik=215,
        Tanzanian=216,
        Thailand = 217,
        [XafDisplayName("Timor-leste")]Timor_leste =218,
        Togo = 219,
        Tokelau = 220,
        Tongan=221, 
        [XafDisplayName("Trinidadian or Tobagonian")]Trinidadian_or_Tobagonian=22,
        Tunisian=223,
        Turkish=224,
        Turkmenistan = 225,
        [XafDisplayName("Turks And Caicos Islands")]Turks_And_Caicos_Islands = 226,
        Tuvaluan=227,
        Ugandan=1228,
        Ukrainian=229,
        [XafDisplayName("United Arab Emirates")]United_Arab_Emirates=230,
        [XafDisplayName("United Kingdom")]United_Kingdom=231,
        [XafDisplayName("United States")]United_States=232,
        [XafDisplayName("United States Minor Outlying Islands")]United_States_Minor_Outlying_Islands=233,
        Uruguayan=234,
        Uzbekistani=235,
        Vanuatu = 236,
        Vatican_City_State = 237,
        Venezuelan=238,
        Vietnamese=239,
        [XafDisplayName("Virgin Islands, British")]Virgin_Islands_British=240,
        [XafDisplayName("Virgin Islands, U.s.")] Virgin_Islands_Us = 241,
        [XafDisplayName("Wallis And Futuna")]Wallis_And_Futuna = 242,
        [XafDisplayName("Western Sahara")] Western_Sahara= 243,
        Yemenite=244,
        Zambian=245,
        Zimbabwean=246 } 

    [System.ComponentModel.DisplayName("Employé")]
    [DefaultClassOptions]
    [Limited]
    public class Personne : Person
    {
        private Service fLeSrevice;
        public Service LeSrevice
        {
            get { return fLeSrevice; }
            set { SetPropertyValue<Service>("LeSrevice", ref fLeSrevice, value); }
        }

        private Unite funite;
        public Unite unite
        {
            get { return funite; }
            set { SetPropertyValue<Unite>("unite", ref funite, value); }
        }

        private double fTaux_resp;
        public double Taux_resp
        {
            get { return fTaux_resp; }
            set { SetPropertyValue<double>("Taux_resp", ref fTaux_resp, value); }
        }

        private int fBonif_resp;
        public int Bonif_resp
        {
            get { return fBonif_resp; }
            set { SetPropertyValue<int>("Bonif_resp", ref fBonif_resp, value); }
        }

        private string fNaissance_Présumé;
        public string Naissance_Présumé
        {
            get { return fNaissance_Présumé; }
            set { SetPropertyValue<string>("Naissance_Présumé", ref fNaissance_Présumé, value); }
        }
         
        private string fLaResponsabilite_Fr;
        public string LaResponsabilite_Fr
        {
            get { return fLaResponsabilite_Fr; }
            set { SetPropertyValue<string>("LaResponsabilite_Fr", ref fLaResponsabilite_Fr, value); }
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

        private Corps fCorps;
        public Corps Corps
        {
            get { return fCorps; }
            set { SetPropertyValue<Corps>("Corps", ref fCorps, value); }
        }

        [DevExpress.Xpo.Aggregated, Association("Personne-PortfolioFileData", typeof(PortfolioFileData))]
        public XPCollection<PortfolioFileData> Portfolio
        {
            get { return GetCollection<PortfolioFileData>("Portfolio"); }
        }
        
        //Tadjou Validation champ unique
        [RuleUniqueValue("RuleCollectionValidation", DefaultContexts.Save,
        TargetPropertyName = "Indem")]
        
        //Tadjou One to many 
        [DevExpress.Xpo.Aggregated, Association("Personnes-Indem_Personnes", typeof(Indem_Personne))]
        public XPCollection Indem_Personnes
        {
            get { return GetCollection("Indem_Personnes"); }
        }

        private string fCod_personne;
        [Size(30)]
        //Tadjou Validation champ rquired Position importante dans la classe
        [RuleRequiredField("RuleRequiredField for Personne.Cod_personne", DefaultContexts.Save)] 
        public string Cod_personne
        {
            get { return fCod_personne; }
            set { SetPropertyValue<string>("Cod_personne", ref fCod_personne, value); }
        }

        private string fAdresse_Fr;
        public string Adresse_Fr
        {
            get { return fAdresse_Fr; }
            set { SetPropertyValue<string>("Adresse_Fr", ref fAdresse_Fr, value); }
        }

        private string fTlf;
        public string Tlf
        {
            get { return fTlf; }
            set { SetPropertyValue<string>("Tlf", ref fTlf, value); }
        }

        //private Bareme2008 fCateg_IEP;
        //public Bareme2008 Categ_IEP
        //{
        //    get
        //    { 
        //        return fCateg_IEP;
        //    }
        //    set { SetPropertyValue<Bareme2008>("Categ_IEP", ref fCateg_IEP, value); }

        //}

        //private Bareme fCateg_IEP_Bareme;
        //public Bareme Categ_IEP_Bareme
        //{
        //    get
        //    { 
        //        return fCateg_IEP_Bareme;
        //    }
        //    set { SetPropertyValue<Bareme>("Categ_IEP_Bareme", ref fCateg_IEP_Bareme, value); }

        //}

        //private Bareme2008 fCateg08;
        //public Bareme2008 Categ08
        //{
        //    get { return fCateg08; }
        //    set { SetPropertyValue<Bareme2008>("Categ08", ref fCateg08, value); }
        //}

        //private Bareme2001 fCateg01;
        //public Bareme2001 Categ01
        //{
        //    get { return fCateg01; }
        //    set { SetPropertyValue<Bareme2001>("Categ01", ref fCateg01, value); }
        //}

        private Bareme fCategori;
        public Bareme Categori
        {
            get { return fCategori; }
            set { SetPropertyValue<Bareme>("Categori", ref fCategori, value); }
        }

        //private int fEchelon08;
        //public int Echelon08
        //{
        //    get { return fEchelon08; }
        //    set { SetPropertyValue<int>("Echelon08", ref fEchelon08, value); }
        //}

        //private int fEchelon01;
        //public int Echelon01
        //{
        //    get { return fEchelon01; }
        //    set { SetPropertyValue<int>("Echelon01", ref fEchelon01, value); }
        //}

  
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

        private int fNbr_enf_P10;
        [ImmediatePostData]
        public int Nbr_enf_p10
        {
            get { return fNbr_enf_P10; }
            set { SetPropertyValue<int>("Nbr_enf_P10", ref fNbr_enf_P10, value); }
        }

        private int fNbr_enf_M10;
        [ImmediatePostData]
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

        private bool fMiTemps;  
        public bool MiTemps
        {
            get { return fMiTemps; }
            set { SetPropertyValue<bool>("MiTemps", ref fMiTemps, value); }
        }
        //private bool fVacataire;
        //[XafDisplayName("Contractuel")]
        //[ImmediatePostData]
        //public bool Vacataire
        //{
        //    get { return fVacataire; }
        //    set { SetPropertyValue<bool>("Vacataire", ref fVacataire, value); }
        //}

        //private VacataireCP fVacataire_Complet_Partiel;
        //[XafDisplayName("Contractuel Temps Partiel/Complet")]
        //public VacataireCP Vacataire_Complet_Partiel
        //{
        //    get { return fVacataire_Complet_Partiel; }
        //    set { SetPropertyValue<VacataireCP>("Vacataire_Complet_Partiel", ref fVacataire_Complet_Partiel, value); }
        //}

        private int fNbr_Heurs_Vacataire;
        public int Nbr_Heurs_Vacataire
        {
            get { return fNbr_Heurs_Vacataire; }
            set { SetPropertyValue<int>("Nbr_Heurs_Vacataire", ref fNbr_Heurs_Vacataire, value); }
        }

        private int fNbr_Heurs_Mois_Vacataire;
        public int Nbr_Heurs_Mois_vacataire
        {
            get { return fNbr_Heurs_Mois_Vacataire; }
            set { SetPropertyValue<int>("Nbr_Heurs_Mois_vacataire", ref fNbr_Heurs_Mois_Vacataire, value); }
        }

        private bool fBloque_Paye;
        [ImmediatePostData]
        public bool Bloque_Paye
        {
            get { return fBloque_Paye; }
            set { SetPropertyValue<bool>("Bloque_Paye", ref fBloque_Paye, value); }
        }

        //private bool fBloque_Pri;
        //[ImmediatePostData]
        //public bool Bloque_Pri
        //{
        //    get { return fBloque_Pri; }
        //    set { SetPropertyValue<bool>("Bloque_Pri", ref fBloque_Pri, value); }
        //}

        //private bool fOk_Pri;
        //[ImmediatePostData]
        //public bool Ok_Pri
        //{
        //    get { return fOk_Pri; }
        //    set { SetPropertyValue<bool>("Ok_Pri", ref fOk_Pri, value); }
        //}

        //private bool fBloque_PAP;
        //[ImmediatePostData]
        //public bool Bloque_PAP
        //{
        //    get { return fBloque_PAP; }
        //    set { SetPropertyValue<bool>("Bloque_PAP", ref fBloque_PAP, value); }
        //}

        //private bool fOk_PAP;
        //[ImmediatePostData]
        //public bool Ok_PAP
        //{
        //    get { return fOk_PAP; }
        //    set { SetPropertyValue<bool>("Ok_PAP", ref fOk_PAP, value); }
        //}

        private bool fBloque_Scol;
        [ImmediatePostData]
        public bool Bloque_Scol
        {
            get { return fBloque_Scol; }
            set { SetPropertyValue<bool>("Bloque_Scol", ref fBloque_Scol, value); }
        }

        private bool fIntégral_Scol;
        [ImmediatePostData]
        public bool Intégral_Scol
        {
            get { return fIntégral_Scol; }
            set { SetPropertyValue<bool>("Intégral__Scol", ref fIntégral_Scol, value); }
        }

        private bool fPartiel_Scol;
        [ImmediatePostData]
        public bool Partiel_Scol
        {
            get { return fPartiel_Scol; }
            set { SetPropertyValue<bool>("Partiel_Scol", ref fPartiel_Scol, value); }
        }

        private string fLieu_nais;
        [Size(50)]
        public string Lieu_nais
        {
            get { return fLieu_nais; }
            set { SetPropertyValue<string>("Lieu_nais", ref fLieu_nais, value); }
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

        private DateTime fDat_entre;
        [RuleRequiredField("RuleRequiredField for Personne.Dat_entre", DefaultContexts.Save)]
        public DateTime Dat_entre
        {
            get { return fDat_entre; }
            set { SetPropertyValue<DateTime>("Dat_entre", ref fDat_entre, value); }
        }

        private Raison_Sortie fRaison_Sortie;
        public Raison_Sortie Raison_Sortie
        {
            get { return fRaison_Sortie; }
            set { SetPropertyValue<Raison_Sortie>("Raison_Sortie", ref fRaison_Sortie, value); }
        }


        private DateTime fDat_sortie;
        public DateTime Dat_sortie
        {
            get { return fDat_sortie; }
            set { SetPropertyValue<DateTime>("Dat_sortie", ref fDat_sortie, value); }
        }

        //private double fTaux_Pri;
        //public double Taux_Pri
        //{
        //    get { return fTaux_Pri; }
        //    set { SetPropertyValue<double>("Taux_Pri", ref fTaux_Pri, value); }
        //}

        //private double fTaux_PAP;
        //public double Taux_PAP
        //{
        //    get { return fTaux_PAP; }
        //    set { SetPropertyValue<double>("Taux_PAP", ref fTaux_PAP, value); }
        //}

        //private int fNote_Perso_Pri;
        //[ImmediatePostData]
        //public int Note_Perso_Pri
        //{
        //    get { return fNote_Perso_Pri; }
        //    set { SetPropertyValue<int>("Note_Perso_Pri", ref fNote_Perso_Pri, value); }
        //}


        //private int fNbr_Mois_Perso_Pri;
        //[Size(2)]
        //public int Nbr_Mois_Perso_Pri
        //{
        //    get { return fNbr_Mois_Perso_Pri; }
        //    set { SetPropertyValue<int>("Nbr_Mois_Perso_Pri", ref fNbr_Mois_Perso_Pri, value); }
        //}

        //private int fNote_Perso_PAP;
        //[ImmediatePostData]
        //public int Note_Perso_PAP
        //{
        //    get { return fNote_Perso_PAP; }
        //    set { SetPropertyValue<int>("Note_Perso_PAP", ref fNote_Perso_PAP, value); }
        //}


        //private int fNbr_Mois_Perso_PAP;
        //[Size(2)]
        //public int Nbr_Mois_Perso_PAP
        //{
        //    get { return fNbr_Mois_Perso_PAP; }
        //    set { SetPropertyValue<int>("Nbr_Mois_Perso_PAP", ref fNbr_Mois_Perso_PAP, value); }
        //}

        private Sexe fsexe;
        public Sexe sexe
        {
            get { return fsexe; }
            set { SetPropertyValue<Sexe>("sexe", ref fsexe, value); }
        }

        private string fNom_Prenom_CCP;
        public string Nom_Prenom_CCP
        {
            get { return fNom_Prenom_CCP; }
            set { SetPropertyValue<string>("Nom_Prenom_CCP", ref fNom_Prenom_CCP, value); }
        }

        private string fnum_compte;
        [Size(50)]
        public string num_compte
        {
            get { return fnum_compte; }
            set { SetPropertyValue<string>("num_compte", ref fnum_compte, value); }
        }

        private string fNCN;
        public string NCN
        {
            get { return fNCN; }
            set { SetPropertyValue<string>("NCN", ref fNCN, value); }
        }

        //private string fIdNat;
        //public string IdNat
        //{
        //    get { return fIdNat; }
        //    set { SetPropertyValue<string>("IdNat", ref fIdNat, value); }
        //}

        private string fcle_compt;
        public string cle_compt
        {
            get { return fcle_compt; }
            set { SetPropertyValue<string>("cle_compt", ref fcle_compt, value); }
        }

        private string fcle_rip;
        public string cle_rip
        {
            get { return fcle_rip; }
            set { SetPropertyValue<string>("cle_rip", ref fcle_rip, value); }
        }

        private decimal fMontant_SDB;
        public decimal Montant_SDB
        {
            get { return fMontant_SDB; }
            set { SetPropertyValue<decimal>("Montant_SDB", ref fMontant_SDB, value); }
        }

        private decimal fMontant_NETCR;
        public decimal Montant_NETCR
        {
            get { return fMontant_NETCR; }
            set { SetPropertyValue<decimal>("Montant_NETCR", ref fMontant_NETCR, value); }
        }

        private decimal fBrut_Dec_2007;
        public decimal Brut_Dec_2007
        {
            get { return fBrut_Dec_2007; }
            set { SetPropertyValue<decimal>("Brut_Dec_2007", ref fBrut_Dec_2007, value); }
        }

        private decimal fBrut_Janv_2008;
        public decimal Brut_Janv_2008
        {
            get { return fBrut_Janv_2008; }
            set { SetPropertyValue<decimal>("Brut_Janv_2008", ref fBrut_Janv_2008, value); }
        }

        private decimal fPrix_heure;
        public decimal Prix_heure
        {
            get { return fPrix_heure; }
            set { SetPropertyValue<decimal>("Prix_heure", ref fPrix_heure, value); }
        }

        private decimal fPrix_jour;
        public decimal Prix_jour
        {
            get { return fPrix_jour; }
            set { SetPropertyValue<decimal>("Prix_jour", ref fPrix_jour, value); }
        }

        private unit_mes fUnit_mes;
        public unit_mes Unit_mes
        {
            get { return fUnit_mes; }
            set { SetPropertyValue<unit_mes>("Unit_mes", ref fUnit_mes, value); }
        }

        private string fMatricule_pointeuse; 
        public string Matricule_pointeuse
        {
            get { return fMatricule_pointeuse; }
            set { SetPropertyValue<string>("Matricule_pointeuse", ref fMatricule_pointeuse, value); }
        }

        private Banque fBanque; 
        public Banque Banque
        {
            get { return fBanque; }
            set { SetPropertyValue<Banque>("Banque", ref fBanque, value); }
        }

        private string fNum_CPP_Banque; 
        public string Num_CPP_Banque
        {
            get { return fNum_CPP_Banque; }
            set { SetPropertyValue<string>("Num_CPP_Banque", ref fNum_CPP_Banque, value); }
        }

        private string fcle_CPP_Banqu;
        public string cle_CPP_Banqu
        {
            get { return fcle_CPP_Banqu; }
            set { SetPropertyValue<string>("cle_CPP_Banqu", ref fcle_CPP_Banqu, value); }
        }

        private Mode_Paiement fMode_Paiement;
        public Mode_Paiement Mode_Paiement
        {
            get { return fMode_Paiement; }
            set { SetPropertyValue<Mode_Paiement>("Mode_Paiement", ref fMode_Paiement, value); }
        }

        //private decimal fiep_fixe;
        //public decimal iep_fixe
        //{
        //    get { return fiep_fixe; }
        //    set { SetPropertyValue<decimal>("iep_fixe", ref fiep_fixe, value); }
        //}

        private double fTAUX_IEP;
        public double TAUX_IEP
        {
            get
            {
                if (parametres.Aug_Auto_Taux_Iep_Org == true)
                    fTAUX_IEP = Nbr_Ans_Trv_Int * parametres.Taux_Iep_Org;
                return fTAUX_IEP;
            }
            set { SetPropertyValue<double>("TAUX_IEP", ref fTAUX_IEP, value); }
        }

        private double fTAUX_IEP_Ext;
        public double TAUX_IEP_Ext
        {
            get
            {
                fTAUX_IEP_Ext = Nbr_Ans_Trv_Ext_Prv * parametres.Taux_Iep_Hors_Secteur_Prive + Nbr_Ans_Trv_Ext_Etat * parametres.Taux_Iep_Hors_Secteur_Etat;
                return fTAUX_IEP_Ext;
            }
            set { SetPropertyValue<double>("TAUX_IEP_Ext", ref fTAUX_IEP_Ext, value); }
        }

        private double fTaux_HS;
        public double Taux_HS
        {
            get { return fTaux_HS; }
            set { SetPropertyValue<double>("Taux_HS", ref fTaux_HS, value); }
        }

        private double fTaux_Var;
        public double Taux_Var
        {
            get { return fTaux_Var; }
            set { SetPropertyValue<double>("Taux_Var", ref fTaux_Var, value); }
        }

        private double fTaux_Suj;
        public double Taux_Suj
        {
            get { return fTaux_Suj; }
            set { SetPropertyValue<double>("Taux_Suj", ref fTaux_Suj, value); }
        }

        private double fTAUX_Abat_Irg;
        public double TAUX_Abat_Irg
        {
            get { return fTAUX_Abat_Irg; }
            set { SetPropertyValue<double>("TAUX_Abat_Irg", ref fTAUX_Abat_Irg, value); }
        }


        private string fh_f;
        [Size(10)]
        public string h_f
        {
            get { return fh_f; }
            set { SetPropertyValue<string>("h_f", ref fh_f, value); }
        }

        //private bool fpaye_banque;
        //public bool paye_banque
        //{
        //    get { return fpaye_banque; }
        //    set { SetPropertyValue<bool>("paye_banque", ref fpaye_banque, value); }
        //}

        private bool fOk_mutuel;
        public bool Ok_mutuel
        {
            get { return fOk_mutuel; }
            set { SetPropertyValue<bool>("Ok_mutuel", ref fOk_mutuel, value); }
        }

        private string fnum_mutuelle;
        [Size(50)]
        public string num_mutuelle
        {
            get { return fnum_mutuelle; }
            set { SetPropertyValue<string>("num_mutuelle", ref fnum_mutuelle, value); }
        }

        private string fnum_SecSoc;
        [Size(50)]
        public string num_SecSoc
        {
            get { return fnum_SecSoc; }
            set { SetPropertyValue<string>("num_SecSoc", ref fnum_SecSoc, value); }
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

        private bool fAdopti_Enfant;
        public bool Adopti_Enfant
        {
            get { return fAdopti_Enfant; }
            set { SetPropertyValue<bool>("Adopti_Enfant", ref fAdopti_Enfant, value); }
        }

        private bool fGarde_Enfant;
        public bool Garde_Enfant
        {
            get { return fGarde_Enfant; }
            set { SetPropertyValue<bool>("Garde_Enfant", ref fGarde_Enfant, value); }
        }

        private bool fParrain_Enfant;
        public bool Parrain_Enfant
        {
            get { return fParrain_Enfant; }
            set { SetPropertyValue<bool>("Parrain_Enfant", ref fParrain_Enfant, value); }
        }

        private bool fAF_Partiel;
        public bool AF_Partiel
        {
            get { return fAF_Partiel; }
            set { SetPropertyValue<bool>("AF_Partiel", ref fAF_Partiel, value); }
        }

        int fcond;
        [ImmediatePostData]
        public int cond
        {
            get { return fcond; }
            set { SetPropertyValue<int>("cond", ref fcond, value); }
        }

        CalculerNbrAnnee CalNbrAnn = new CalculerNbrAnnee();

        private double fNbr_Ans_Trv_Int;
        public double Nbr_Ans_Trv_Int
        {
            get
            {
                //if (fNbr_Ans_Trv_Int == 0)
                DateTime date = new DateTime(parametres.Annee_Travail, DateTime.Now.Month, DateTime.Now.Day);
                if (Dat_entre != DateTime.MinValue)
                    fNbr_Ans_Trv_Int = CalNbrAnn.CalculerNbrAnne(Dat_entre, date);

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

        private string fMotif;
        public string Motif
        {
            get { return fMotif; }
            set { SetPropertyValue<string>("Motif", ref fMotif, value); }
        }

        private parametre fparametres;
        public parametre parametres
        {
            get { return fparametres; }
            set { SetPropertyValue<parametre>("parametres", ref fparametres, value); }
        }

        private DateTime fDateRecrutement;
        public DateTime DateRecrutement
        {
            get { return fDateRecrutement; }
            set { SetPropertyValue<DateTime>("DateRecrutement", ref fDateRecrutement, value); }
        }

        private TypeContrat fTypeContrat;
        public TypeContrat TypeContrat
        {
            get { return fTypeContrat; }
            set { SetPropertyValue<TypeContrat>("TypeContrat", ref fTypeContrat, value); }
        }

        [Association("Employe-Contrat")]
        public XPCollection<ContratPersonne> ContratPersonne
        {
            get { return GetCollection<ContratPersonne>("ContratPersonne"); }
        }

        //private DateTime fDateDebutContrat;
        //public DateTime DateDebutContrat
        //{
        //    get { return fDateDebutContrat; }
        //    set { SetPropertyValue<DateTime>("DateDebutContrat", ref fDateDebutContrat, value); }
        //}

        //private DateTime fDateFinContrat;
        //public DateTime DateFinContrat
        //{
        //    get { return fDateFinContrat; }
        //    set { SetPropertyValue<DateTime>("DateFinContrat", ref fDateFinContrat, value); }
        //}

        private bool faLimiter;
        public bool aLimiter
        {
            get { return faLimiter; }
            set { SetPropertyValue<bool>("aLimiter", ref faLimiter, value); }
        }

        private double fTaux_PP;
        public double Taux_PP
        {
            get { return fTaux_PP; }
            set { SetPropertyValue<double>("Taux_PP", ref fTaux_PP, value); }
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

        private int fAnnee;
        public int Annee
        {
            get { return fAnnee; }
            set { SetPropertyValue<int>("Annee", ref fAnnee, value); }
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

        private decimal fSDB; //fonction fait
        public decimal SDB
        {
            get { return fSDB; }
            set { SetPropertyValue<decimal>("SDB", ref fSDB, value); }
        }

        private decimal fSDBAbsence;
        public decimal SDBAbsence
        {
            get { return fSDBAbsence; }
            set { SetPropertyValue<decimal>("SDBAbsence", ref fSDBAbsence, value); }
        }

        private decimal fRappelSDB;
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

        private decimal fBRUT;
        public decimal BRUT
        {
            get { return fBRUT; }
            set
            {
                SetPropertyValue<decimal>("BRUT", ref fBRUT, value);
            }
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

        private decimal fImposable_taux;
        public decimal Imposable_taux
        {
            get { return fImposable_taux; }
            set { SetPropertyValue<decimal>("Imposable_taux", ref fImposable_taux, value); }
        }

        private decimal fImposable_taux_Abs;
        public decimal Imposable_taux_Abs
        {
            get { return fImposable_taux_Abs; }
            set { SetPropertyValue<decimal>("Imposable_taux_Abs", ref fImposable_taux_Abs, value); }
        }

        private decimal fImposable_bareme;
        public decimal Imposable_bareme
        {
            get { return fImposable_bareme; }
            set { SetPropertyValue<decimal>("Imposable_bareme", ref fImposable_bareme, value); }
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
         
        private decimal fBrute_cotisable;
        public decimal Brute_cotisable
        {
            get { return fBrute_cotisable; }
            set { SetPropertyValue<decimal>("Brute_cotisable", ref fBrute_cotisable, value); }
        }

        private decimal fBrute_cotisableAbsence;
        public decimal Brute_cotisableAbsence
        {
            get { return fBrute_cotisableAbsence; }
            set { SetPropertyValue<decimal>("Brute_cotisableAbsence", ref fBrute_cotisableAbsence, value); }
        }

        private decimal fBrute_cotisable_Bareme;
        public decimal Brute_cotisable_Bareme
        {
            get { return fBrute_cotisable_Bareme; }
            set { SetPropertyValue<decimal>("Brute_cotisable_Bareme", ref fBrute_cotisable_Bareme, value); }
        }

        private decimal fBrute_cotisable_Taux;
        public decimal Brute_cotisable_Taux
        {
            get { return fBrute_cotisable_Taux; }
            set { SetPropertyValue<decimal>("Brute_cotisable_Taux", ref fBrute_cotisable_Taux, value); }
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

        private decimal fIrg_bareme;
        public decimal Irg_bareme
        {
            get { return fIrg_bareme; }
            set { SetPropertyValue<decimal>("Irg_bareme", ref fIrg_bareme, value); }
        }

        private decimal fIrg_taux;
        public decimal Irg_taux
        {
            get { return fIrg_taux; }
            set { SetPropertyValue<decimal>("Irg_taux", ref fIrg_taux, value); }
        }

        private decimal fSS;
        public decimal SS
        {
            get { return fSS; }
            set { SetPropertyValue<decimal>("SS", ref fSS, value); }
        }

        private decimal fSs_bareme;
        public decimal Ss_bareme
        {
            get { return fSs_bareme; }
            set { SetPropertyValue<decimal>("Ss_bareme", ref fSs_bareme, value); }
        }

        private decimal fSS_Taux;
        public decimal SS_Taux
        {
            get { return fSS_Taux; }
            set { SetPropertyValue<decimal>("SS_Taux", ref fSS_Taux, value); }
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

        private decimal fTot_Indem_impos_Non_Cotis;
        public decimal Tot_Indem_impos_Non_Cotis
        {
            get { return fTot_Indem_impos_Non_Cotis; }
            set { SetPropertyValue<decimal>("Tot_Indem_impos_Non_Cotis", ref fTot_Indem_impos_Non_Cotis, value); }
        }

        private decimal fTot_Indem_Non_impos_Non_Cotis;
        public decimal Tot_Indem_Non_impos_Non_Cotis
        {
            get { return fTot_Indem_Non_impos_Non_Cotis; }
            set { SetPropertyValue<decimal>("Tot_Indem_Non_impos_Non_Cotis", ref fTot_Indem_Non_impos_Non_Cotis, value); }
        }

        private decimal fTot_Indem_Net;
        public decimal Tot_Indem_Net
        {
            get { return fTot_Indem_Net; }
            set { SetPropertyValue<decimal>("Tot_Indem_Net", ref fTot_Indem_Net, value); }
        }

        private decimal fmutuelle;
        public decimal mutuelle
        {
            get { return fmutuelle; }
            set { SetPropertyValue<decimal>("mutuelle", ref fmutuelle, value); }
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

        private decimal fAF_Global;
        public decimal AF_Global
        {
            get { return fAF_Global; }
            set { SetPropertyValue<decimal>("AF_Global", ref fAF_Global, value); }
        }

        private decimal fAF;
        public decimal AF
        {
            get { return fAF; }
            set { SetPropertyValue<decimal>("AF", ref fAF, value); }
        }

        private decimal fAF_Majoration;
        public decimal AF_Majoration
        {
            get { return fAF_Majoration; }
            set { SetPropertyValue<decimal>("AF_Majoration", ref fAF_Majoration, value); }
        }

        private decimal fSU;
        public decimal SU
        {
            get { return fSU; }
            set { SetPropertyValue<decimal>("SU", ref fSU, value); }
        }

        private decimal fPRI;
        public decimal PRI
        {
            get { return fPRI; }
            set { SetPropertyValue<decimal>("PRI", ref fPRI, value); }
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

        private bool fBrouillardCalcule;
        public bool BrouillardCalcule
        {
            get { return fBrouillardCalcule; }
            set { SetPropertyValue<bool>("BrouillardCalcule", ref fBrouillardCalcule, value); }
        }

        // Congé annuel
        private double fRelecat_Nbr_Jrs_Cong;
        public double Relecat_Nbr_Jrs_Cong
        {
            get { return fRelecat_Nbr_Jrs_Cong; }
            set { SetPropertyValue<double>("Relecat_Nbr_Jrs_Cong", ref fRelecat_Nbr_Jrs_Cong, value); }
        }

        private double fNbr_Jrs_Cong_Accor;
        public double Nbr_Jrs_Cong_Accor
        {
            get { return fNbr_Jrs_Cong_Accor; }
            set { SetPropertyValue<double>("Nbr_Jrs_Cong_Accor", ref fNbr_Jrs_Cong_Accor, value); }
        }

        // Congé de récupération
        private decimal fNbr_Jrs_Cong_Recup_Accor;
        public decimal Nbr_Jrs_Cong_Recup_Accor
        {
            get { return fNbr_Jrs_Cong_Recup_Accor; }
            set { SetPropertyValue<decimal>("Nbr_Jrs_Cong_Recup_Accor", ref fNbr_Jrs_Cong_Recup_Accor, value); }
        }

        private int fNbr_jour_tra; //30
        public int Nbr_jour_tra
        {
            get { return fNbr_jour_tra; }
            set { SetPropertyValue<int>("Nbr_jour_tra", ref fNbr_jour_tra, value); }
        }

        //private double fJour_Abs;
        //public double Jour_Abs
        //{
        //    get {  return fJour_Abs;  }
        //    set { SetPropertyValue<double>("Jour_Abs", ref fJour_Abs, value); }
        //}

        private double fNbr_Jour_Tra_Prime; //22
        public double Nbr_Jour_Tra_Prime
        {
            get { return fNbr_Jour_Tra_Prime; }
            set { SetPropertyValue<double>("Nbr_Jour_Tra_Prime", ref fNbr_Jour_Tra_Prime, value); }
        }

        private int fNbr_jour_abs;
        public int Nbr_jour_abs
        {
            get
            {
                return fNbr_jour_abs;
            }
            set { SetPropertyValue<int>("Nbr_jour_abs", ref fNbr_jour_abs, value); }
        }

        private int fNbr_jour_abs_Entr;
        public int Nbr_jour_abs_Entr
        {
            get { return fNbr_jour_abs_Entr; }
            set { SetPropertyValue<int>("Nbr_jour_abs_Entr", ref fNbr_jour_abs_Entr, value); }
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

        //private int fNbr_jour_abs_prime;
        //[ImmediatePostData]
        //public int Nbr_jour_abs_prime
        //{
        //    get { return fNbr_jour_abs_prime; }
        //    set { SetPropertyValue<int>("Nbr_jour_abs_prime", ref fNbr_jour_abs_prime, value); }
        //}

        private int fNbr_heure_abs;
        public int Nbr_heure_abs
        {
            get { return fNbr_heure_abs; }
            set { SetPropertyValue<int>("Nbr_heure_abs", ref fNbr_heure_abs, value); }
        }
         
        private ModeArrondi fMode_Arrondi;
        public ModeArrondi Mode_Arrondi
        {
            get { return fMode_Arrondi; }
            set { SetPropertyValue<ModeArrondi>("Mode_Arrondi", ref fMode_Arrondi, value); }
        }

        private double fTaux_SS;
        public double Taux_SS
        {
            get { return fTaux_SS; }
            set { SetPropertyValue<double>("Taux_SS", ref fTaux_SS, value); }
        }

        private double fTaux_IRG;
        public double Taux_IRG
        {
            get { return fTaux_IRG; }
            set { SetPropertyValue<double>("Taux_IRG", ref fTaux_IRG, value); }
        }

        private int fNbr_jour_abs_prime;
        [ImmediatePostData]
        public int Nbr_jour_abs_prime
        {
            get { return fNbr_jour_abs_prime; }
            set { SetPropertyValue<int>("Nbr_jour_abs_prime", ref fNbr_jour_abs_prime, value); }
        }

        private double fNbrJrsTrvPrJrsCR;
        public double NbrJrsTrvPrJrsCR
        {
            get { return fNbrJrsTrvPrJrsCR; }
            set { SetPropertyValue<double>("NbrJrsTrvPrJrsCR", ref fNbrJrsTrvPrJrsCR, value); }
        }

        private double fNbrJrsCRPrJrsTrv;
        public double NbrJrsCRPrJrsTrv
        {
            get { return fNbrJrsCRPrJrsTrv; }
            set { SetPropertyValue<double>("NbrJrsCRPrJrsTrv", ref fNbrJrsCRPrJrsTrv, value); }
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

        private bool _handicapée;
        [DevExpress.Xpo.DisplayName("Handicapée")]
        public bool handicapée
        {
            get { return _handicapée; }
            set { SetPropertyValue("handicapée", ref _handicapée, value); }
        }
        public Personne(Session session)
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

            //parametres = parametre.GetInstance(Session);
            parametres = parametre.GetInstance(Session);
            Soumis_à_l_IRG = true;
            Soumis_à_la_Sécurité_Sociale = true;
            Intégral_Scol = true;
            cond = Paye.count_Perso(this.Session) + 1;
            Annee = parametres.Annee_Travail;
            Mode_Arrondi = parametres.Mode_Arrondi;
            Taux_SS = parametres.Taux_ss;
            Taux_IRG = parametres.Taux_irg;
            Taux_Mutuel = parametres.Taux_Mutuel;
            Taux_cacobatph = parametres.Taux_cacobatph;
            Taux_chomage_intemperie = parametres.Taux_chomage_intemperie;
            Taux_chomage_intemperiePO = parametres.Taux_chomage_intemperiePO;
            Nbr_jour_tra = parametres.Nbr_jour_tra;
            Nbr_Jour_Tra_Prime = parametres.Nbr_Jour_Travail_Prime;
            Taux_PP = parametres.Taux_pp;
            Taux_pp1 = parametres.Taux_pp1;

            Sit_Emp = Session.FindObject<Situation_Employe>(CriteriaOperator.Parse("Sit_Emp_Lib_Fr==?", Sit_Emp_Fr.Actif));

            Inserer_Indem_Base();
        }

        public void Inserer_Indem_Base()
        {
            Indem IndemniteSDB = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "SDB"));
            Indem IndemniteIEP = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "IEP"));
            Indem IndemniteBrutCotis = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "Brute_cotisable"));
            Indem IndemniteSS = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "SS"));
            Indem IndemniteBrutImpo = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "Brute_imposable"));
            Indem IndemniteIRG = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "IRG"));
            Indem IndemniteNET = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "NET"));

            if (IndemniteSDB != null)
            {
                Indem_Personne IndemniteAInserer = new Indem_Personne(Session);
                IndemniteAInserer.Indem = IndemniteSDB;
                IndemniteAInserer.Personne = this;

                Indem_Personnes.Add(IndemniteAInserer);
            }

            if (IndemniteIEP != null)
            {
                Indem_Personne IndemniteAInserer = new Indem_Personne(Session);
                IndemniteAInserer.Indem = IndemniteIEP;
                IndemniteAInserer.Personne = this;

                Indem_Personnes.Add(IndemniteAInserer);
            }

            if (IndemniteBrutCotis != null)
            {
                Indem_Personne IndemniteAInserer = new Indem_Personne(Session);
                IndemniteAInserer.Indem = IndemniteBrutCotis;
                IndemniteAInserer.Personne = this;

                Indem_Personnes.Add(IndemniteAInserer);
            }

            if (IndemniteSS != null)
            {
                Indem_Personne IndemniteAInserer = new Indem_Personne(Session);
                IndemniteAInserer.Indem = IndemniteSS;
                IndemniteAInserer.Personne = this;

                Indem_Personnes.Add(IndemniteAInserer);
            }

            if (IndemniteBrutImpo != null)
            {
                Indem_Personne IndemniteAInserer = new Indem_Personne(Session);
                IndemniteAInserer.Indem = IndemniteBrutImpo;
                IndemniteAInserer.Personne = this;

                Indem_Personnes.Add(IndemniteAInserer);
            }

            if (IndemniteIRG != null)
            {
                Indem_Personne IndemniteAInserer = new Indem_Personne(Session);
                IndemniteAInserer.Indem = IndemniteIRG;
                IndemniteAInserer.Personne = this;

                Indem_Personnes.Add(IndemniteAInserer);
            }

            if (IndemniteNET != null)
            {
                Indem_Personne IndemniteAInserer = new Indem_Personne(Session);
                IndemniteAInserer.Indem = IndemniteNET;
                IndemniteAInserer.Personne = this;

                Indem_Personnes.Add(IndemniteAInserer);
            }
        }

        public void InsererCategorieFonction()
        {
            if (Fonction_Stagière == null)
            {
                if (LaFonction != null)
                { 
                    if (Categori == null)
                        Categori = LaFonction.Categorie; 
                }
            }
            else
            { 
                if (Categori == null)
                    Categori = Fonction_Stagière.Categorie;  
            }

            if (LaFonction != null)
                if (LaFonction.Corps != null)
                    Corps = LaFonction.Corps;
        }

        public void InsererIndemniteFonction()
        {
            if (Fonction_Stagière == null)
            {
                XPCollection<Indem_Personne> colDelete = new XPCollection<Indem_Personne>(Session, CriteriaOperator.Parse("personne=?", this));
                Session.Delete(colDelete);
                Session.Save(colDelete);

                foreach (Indem_Fonction Indemnite in LaFonction.Indem_Fontions) //personne.Indem_Personnes
                {
                    if (Indemnite.Indem.Cod_indem != null)
                    {
                        Session currentSession = this.Session;
                        Indem_Personne IndemniteAInserer = new Indem_Personne(currentSession);
                        IndemniteAInserer.Indem = Indemnite.Indem;
                        IndemniteAInserer.Base = Indemnite.Base;
                        IndemniteAInserer.Taux = Indemnite.Taux;
                        IndemniteAInserer.Montant = Indemnite.Montant;
                        IndemniteAInserer.Personne = this;

                        Indem_Personnes.Add(IndemniteAInserer);
                        Save();

                    }
                }
                Save();
            }
            else
            {
                XPCollection<Indem_Personne> colDelete = new XPCollection<Indem_Personne>(Session, CriteriaOperator.Parse("personne=?", this));
                Session.Delete(colDelete);
                Session.Save(colDelete);

                foreach (Indem_Fonction Indemnite in Fonction_Stagière.Indem_Fontions)
                {
                    if (Indemnite.Indem.Cod_indem != null)
                    {
                        Session currentSession = this.Session;
                        Indem_Personne IndemniteAInserer = new Indem_Personne(currentSession);
                        IndemniteAInserer.Indem = Indemnite.Indem;
                        IndemniteAInserer.Base = Indemnite.Base;
                        IndemniteAInserer.Taux = Indemnite.Taux;
                        IndemniteAInserer.Montant = Indemnite.Montant;
                        IndemniteAInserer.Personne = this;

                        Indem_Personnes.Add(IndemniteAInserer);
                        Save();

                    }
                }
                Save();
            }
        }

        protected override void OnSaved()
        {
            base.OnSaving();

            InsererCategorieFonction(); 
        }

        protected override void OnDeleting()
        {
            base.OnDeleting();

            XPCollection<Indem_Personne> Indem_Personne_Delete = new XPCollection<Indem_Personne>(Session, CriteriaOperator.Parse("Personne=?", Oid.ToString()));
            Session.Delete(Indem_Personne_Delete);
            Session.Save(Indem_Personne_Delete);
        }

        public void InitialisationPaye()
        {
            parametres = parametre.GetInstance(Session);

            Nbr_jour_tra = parametres.Nbr_jour_tra;
            Nbr_Jour_Tra_Prime = parametres.Nbr_Jour_Travail_Prime;
        }

        public void CalculerPaye()
        { 
            Remise_A_0();
            Save();
            CalculerSDB();
            Session.CommitTransaction(); 
            CalculerHS(); 

            CalculerIEP();
            Calcul_Allocation(); 

            Session.CommitTransaction();
            CALCUL_SU(); 

            CalculTotaux();

            CalculerSS();
            CalculerBrutImpo();
            CalculerMutuelle();
            CalculerIrgBareme();
            CalculerIrgTaux();
            CalculerIrg();
            EvaluateBase(); 
            AffectationsLignesColonnes();
            CalculRetenus();
            AffectationsLignesColonnes();
            CalculerNet(); 
            AffectationsLignesColonnes();
            Save();
            Session.CommitTransaction();
        }

        Arrondi_Decimal ArrondiDecimale = new Arrondi_Decimal();

        public bool If_ModifSpec(string Code)
        {
            bool modifspec = false;

            Indem indem = this.Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", Code));
            if (indem != null)
            {

                CriteriaOperator criteria1 = CriteriaOperator.Parse("Indem==?", indem.Oid.ToString());
                CriteriaOperator criteria2 = CriteriaOperator.Parse("Personne==?", this);

                Indem_Personne Indem_Personne = this.Session.FindObject<Indem_Personne>(CriteriaOperator.And(criteria1, criteria2));

                if (Indem_Personne != null)
                    modifspec = Indem_Personne.ModifSpecial;
            }

            return modifspec;
        }

        public bool If_Exist(string Code)
        {
            bool exist = false;

            Indem indem = this.Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", Code));
            if (indem != null)
            {
                CriteriaOperator criteria1 = CriteriaOperator.Parse("Indem==?", indem.Oid.ToString());
                CriteriaOperator criteria2 = CriteriaOperator.Parse("Personne==?", this);

                //paye_indem paye_indem = Session.FindObject<paye_indem>(PersistentCriteriaEvaluationBehavior.InTransaction, CriteriaOperator.And(criteria1, criteria2));
                Indem_Personne Indem_Personne = Session.FindObject<Indem_Personne>(CriteriaOperator.And(criteria1, criteria2));

                if (Indem_Personne != null)
                    exist = true;
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

        public void CalculerSDB()
        {
            bool modifspecSDB = If_ModifSpec("SDB");
            bool existSDB = If_Exist("SDB");
            decimal xSDB = 0;

            if (Montant_SDB != 0)
                xSDB = Montant_SDB;
            else
                if (Categori != null)
                    xSDB = (decimal)Categori.SDB;
              
            if (modifspecSDB == false)
            {
                SDB = xSDB;
                SDBAbsence = xSDB;
            }
            else
            {
                SDB = Get_Montant("SDB");
                SDBAbsence = SDB;
            }

        }

        public void CalculerHS()
        {
            Taux_HS = (double)SDB / parametres.Nbr_heure_ouv;
            Taux_HS = (double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)Taux_HS);
        }

        //public void CalculerPRI()
        //{

        //    if (Note_Perso_Pri > 25)
        //        Note_Perso_Pri = 25;
        //    PRI = SDB * (decimal)(Note_Perso_Pri / 100);

        //}

        CalculerNbrMois CalculerNbrMois = new CalculerNbrMois();

        public void CalculerIEP()
        {
            bool modifspecIEP = If_ModifSpec("IEP");
            bool existIEP = If_Exist("IEP");

            bool modifspecIEP_Ext = If_ModifSpec("IEP_Ext");
            bool existIEP_Ext = If_Exist("IEP_Ext");

            //if (TAUX_IEP == 0)
            //TAUX_IEP = (Nbr_Ans_Trv_Int * parametres.Taux_Iep_Org)
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

            //TAUX_IEP_Ext = (Nbr_Ans_Trv_Ext_Prv * parametres.Taux_Iep_Hors_Secteur_Prive) + (Nbr_Ans_Trv_Ext_Etat * parametres.Taux_Iep_Hors_Secteur_Etat);
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
         
        public void AffectationsLignesColonnes()
        {
            foreach (Indem_Personne detail in Indem_Personnes)
            {
                if (detail.Indem.Cod_indem_interne == "BRUT")
                {
                    detail.Montant = BRUT;
                }
                else
                    if (detail.Indem.Cod_indem_interne == "Brute_cotisable")
                    {
                        detail.Montant = Brute_cotisable;
                    }
                    else
                        if (detail.Indem.Cod_indem_interne == "Brute_imposable")
                        {
                            detail.Montant = Brute_imposable;
                        }
                        else
                            if (detail.Indem.Cod_indem_interne == "SS")
                            {
                                detail.Montant = SS;
                            }
                            else
                                if (detail.Indem.Cod_indem_interne == "IRG")
                                {
                                    detail.Montant = IRG;
                                }
                                else
                                    if (detail.Indem.Cod_indem_interne == "Irg_bareme")
                                    {
                                        detail.Montant = Irg_bareme;
                                    }
                                    else
                                        if (detail.Indem.Cod_indem_interne == "Irg_taux")
                                        {
                                            detail.Montant = Irg_taux;
                                        }
                                        else if (detail.Indem.Cod_indem_interne == "NET")
                                        {
                                            detail.Montant = NET;
                                        }
                                        else
                                            if (detail.Indem.Cod_indem_interne == "mutuelle")
                                            {
                                                detail.Montant = mutuelle;
                                            }
                                            else
                                                if (detail.Indem.Cod_indem_interne == "Imposable_taux")
                                                {
                                                    detail.Montant = Imposable_taux;
                                                }
                                                else
                                                    if (detail.Indem.Cod_indem_interne == "Imposable_bareme")
                                                    {
                                                        detail.Montant = Imposable_bareme;
                                                    }
                //else if (detail.Indemnite.Cod_indem_interne == "SU")
                //{
                //    detail.Montant = SU;
                //    detail.Montant_Absence = SU;
                //} 

            }
        }

        public void CalculTotaux()
        {
            decimal tempTotal = 0m;
            decimal tempTotalRetenu = 0m;
            decimal TempCotisable = 0m;
            decimal TempCotisableRetenu = 0m;
            decimal TempCotisableBareme = 0m;
            decimal TempCotisableBaremeRetenu = 0m;
            decimal TempCotisableTaux = 0m;
            decimal TempCotisableTauxRetenu = 0m;
            decimal TempImposableBareme = 0m;
            decimal TempImposableTaux = 0m;
            decimal TempImposableBaremeRetenu = 0m;
            decimal TempImposableTauxRetenu = 0m;
            decimal TempImposable22 = 0m;
            decimal TempImposable22Retenu = 0m;
            decimal TempTotIndemImposNonCotis = 0m;
            decimal TempTotIndemNonImposNonCotis = 0m;
            decimal TempTotIndemNet = 0m;

            foreach (Indem_Personne detail in Indem_Personnes)
            {
                BASE = 0;
                TAUX = 0;
                NBR = 0;
                double N = 0;
                //IMemberInfo myStaticMember = XafTypesInfo.Instance.FindTypeInfo(decimal).FindMember(detail.Indem.Form_base)
                if ((detail.Indem.Form_base != "") && (detail.Indem.Form_base != null))
                    if (detail.ModifSpecial == false)
                        BASE = (decimal)Evaluate(detail.Indem.Form_base); 
                        //BASE = EvaluateFormule(detail.Indem.Form_base.ToString());
                    else
                        BASE = (decimal)detail.Base;//Get_BASE(detail.Indem.Cod_indem_interne);
                else
                    BASE = (decimal)detail.Base;

                if ((detail.Indem.Form_taux != "") && (detail.Indem.Form_taux != null))
                    if (detail.ModifSpecial == false)
                        TAUX = (double)Evaluate(detail.Indem.Form_taux);
                    else
                        TAUX = (double)detail.Taux;
                else
                    TAUX = (double)detail.Taux;

                if ((detail.Indem.Form_nbr != "") && (detail.Indem.Form_nbr != null))
                    if (detail.ModifSpecial == false)
                        NBR = (double)Evaluate(detail.Indem.Form_nbr);
                    else
                        NBR = (double)detail.INbr;
                else
                    NBR = (double)detail.INbr;

                if (detail.ModifSpecial == false)
                {
                    if ((detail.Indem.Form_cal != "") && (detail.Indem.Form_cal != null))
                        N = (double)Evaluate(detail.Indem.Form_cal);
                    else
                        N = (double)detail.Montant;
                }
                else
                    N = (double)detail.Montant;

                if (detail.Indem.Valeur_Minimale == true)
                    if (N < (double)detail.Indem.Valeur_Min)
                        N = (double)detail.Indem.Valeur_Min;

                if (detail.Indem.Valeur_Maximale == true)
                    if (N > (double)detail.Indem.Valeur_Max)
                        N = (double)detail.Indem.Valeur_Max;


                detail.Base = BASE;
                //detail.ITaux = TAUX;
                detail.Taux = TAUX;
                    //(double)ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)TAUX);
                detail.INbr = NBR;
                detail.Montant = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, (decimal)N);

                if (detail.Indem.Brut_Net_Incluse == InclusBrutNet.Brut)
                {
                    tempTotal += detail.Montant;
                }

                if (detail.Indem.Cotisable)
                {
                    TempCotisable += detail.Montant;
                }

                if ((detail.Indem.Cotisable) && (detail.Indem.Mod_cal_irg == ModeCalculIRG.Sur_Barême))
                {
                    TempCotisableBareme += detail.Montant;
                }

                if ((detail.Indem.Cotisable) && (detail.Indem.Mod_cal_irg == ModeCalculIRG.Sur_Taux))
                {
                    TempCotisableTaux += detail.Montant;
                }

                if ((detail.Indem.Imposable) && (detail.Indem.Mod_cal_irg == ModeCalculIRG.Sur_Barême))
                {
                    TempImposableBareme += detail.Montant;
                }

                if ((detail.Indem.Imposable) && (detail.Indem.Mod_cal_irg == ModeCalculIRG.Sur_Taux))
                {
                    TempImposableTaux += detail.Montant;
                }

                if ((detail.Indem.Imposable) && (detail.Indem.Mod_cal_irg == ModeCalculIRG.Sur_Barême) && (detail.Indem.Mode_Calcul_Absence != parametres.Nbr_jour_tra && detail.Indem.Mode_Calcul_Absence == parametres.Nbr_Jour_Travail_Prime))
                {
                    TempImposable22 += detail.Montant;
                }

                if ((detail.Indem.Imposable == true) && (detail.Indem.Cotisable == false))
                {
                    TempTotIndemImposNonCotis += detail.Montant;
                }
                else
                    if ((detail.Indem.Imposable == false) && (detail.Indem.Cotisable == false))
                    {
                        TempTotIndemNonImposNonCotis += detail.Montant;

                    }

                if ((detail.Indem.Brut_Net_Incluse == InclusBrutNet.Net) && (detail.Indem.Retenue == false) && (detail.Indem.Cod_indem_interne != "BRUT") && (detail.Indem.Cod_indem_interne != "SU") && (detail.Indem.Cod_indem_interne != "AF_Global"))
                {
                    TempTotIndemNet += detail.Montant;
                }
            }

            BRUT = tempTotal - tempTotalRetenu; 

            Brute_cotisable = TempCotisable - TempCotisableRetenu;
            Brute_cotisableAbsence = TempCotisable - TempCotisableRetenu;

            Brute_cotisable_Bareme = TempCotisableBareme - TempCotisableBaremeRetenu;  
            Brute_cotisable_Taux = TempCotisableTaux - TempCotisableTauxRetenu; 
            Imposable_bareme = TempImposableBareme - TempImposableBaremeRetenu;  
            Imposable_taux = TempImposableTaux - TempImposableTauxRetenu;

            Brute_imposable = Imposable_taux + Imposable_bareme;
            Brute_imposable_Abs = Imposable_taux + Imposable_bareme;

            Imposable_bareme_22 = TempImposable22 - TempImposable22Retenu;
            Tot_Indem_impos_Non_Cotis = TempTotIndemImposNonCotis;
            Tot_Indem_Non_impos_Non_Cotis = TempTotIndemNonImposNonCotis;
            Tot_Indem_Net = TempTotIndemNet;
        }

        public void CalculerSS()
        {
            if (Soumis_à_la_Sécurité_Sociale == true)
            {
                double x = (double)Brute_cotisable;
                double xb = (double)Brute_cotisable_Bareme;
                double xt = (double)Brute_cotisable_Taux;

                double XSs = x * Taux_SS / 100;
                double XSsb = xb * Taux_SS / 100;
                double XSst = xt * Taux_SS / 100;

                SS = (decimal)XSs;
                Ss_bareme = (decimal)XSsb;
                SS_Taux = (decimal)XSst;

                SS = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, SS);
                Ss_bareme = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Ss_bareme);
                SS_Taux = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, SS_Taux);


                PP = Brute_cotisable * (decimal)Taux_PP / 100;
                PP = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, PP);

                PP1 = Brute_cotisable * (decimal)Taux_pp1 / 100;
                PP1 = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, PP1);

                PP2 = Brute_cotisable * (decimal)Taux_pp2 / 100;
                PP2 = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, PP2);

                PP3 = Brute_cotisable * (decimal)Taux_pp3 / 100;
                PP3 = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, PP3);

            }

            else
            {
                SS = 0; 
            }

            if (Soumis_Cacobatph == true)
            { 
                cacobatph = Brute_cotisableAbsence * (decimal)Taux_cacobatph / 100;
                cacobatph = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, cacobatph);

                chomage_intemperie = Brute_cotisableAbsence * (decimal)Taux_chomage_intemperie / 100;
                chomage_intemperie = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, chomage_intemperie);

                ChIntempPO = Brute_cotisable * (decimal)Taux_chomage_intemperiePO / 100;
                ChIntempPO = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, ChIntempPO);

            }
            else
            { 
                ChIntempPO = 0;
                cacobatph = 0;
                chomage_intemperie = 0;
            }

        }

        public void CalculerBrutImpo()
        {
            decimal BrutImpo = Brute_imposable; 

            if (BrutImpo != 0)
                Brute_imposable = BrutImpo - SS - ChIntempPO; 

            decimal BrutImpoBareme = Imposable_bareme;

            if (BrutImpoBareme != 0)
            {
                Imposable_bareme = BrutImpoBareme - Ss_bareme - ChIntempPO;
                Imposable_bareme_Abs = Imposable_bareme;
            }


            decimal BrutImpoTaux = Imposable_taux;

            if (BrutImpoTaux != 0)
            {
                Imposable_taux = BrutImpoTaux - SS_Taux - ChIntempPO;
                Imposable_taux_Abs = Imposable_taux;
            }
        }

        public void CalculerMutuelle()
        {
            bool modifspecMut = If_ModifSpec("mutuelle");

            bool existMut = If_Exist("mutuelle");

            if (existMut == true)
            {
                if (modifspecMut == false)
                {

                    if (Taux_Mutuel != 0)
                    {
                        double x = (double)Brute_cotisable;
                        double XMutuelle = x * Taux_Mutuel / 100;

                        if (Plafond_mutuelle != 0)
                        {
                            if (XMutuelle > (double)Plafond_mutuelle)
                                mutuelle = Plafond_mutuelle;
                            else
                            {
                                mutuelle = (decimal)XMutuelle;
                                mutuelle = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, mutuelle); 
                            }
                        }
                        else
                        {
                            mutuelle = (decimal)XMutuelle;
                            mutuelle = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, mutuelle);
                        } 
                    }
                    else
                    {
                        mutuelle = parametres.Valeur_mutuelle;
                    }

                }
                else
                    mutuelle = Get_Montant("mutuelle");
            }
            else
                mutuelle = 0;
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
            }
        }

        public void CalculerIrgBareme()
        {
            if (Soumis_à_l_IRG == false)
                Irg_bareme = 0;
            else
            {
                int[] Trs = { 0, 120000, 360000, 1440000, 99999999 };
                int[] Tax = { 0, 0, 0, 30, 35 };
                int[] Impan = { 0, 0, 48000, 372000, 3367999, 65 };



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

                //2eme abattement 
                if (!handicapée && (Brute_imposable > 30000 && Brute_imposable < 35000))
                    Irg_bareme = ((Irg_bareme * 8) - 20000) / 3;
                //Handicapée
                if (handicapée & (Brute_imposable > 30000 && Brute_imposable < 40000))
                    Irg_bareme = ((Irg_bareme * 5) - 12500) / 3;

                Irg_bareme = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Irg_bareme);
            }
        }

        public void CalculerIrg()
        {
            IRG = Irg_bareme + Irg_taux;

            if (TAUX_Abat_Irg != 0)
            {
                decimal abat = 0;
                abat = IRG * (decimal)TAUX_Abat_Irg / 100;
                if (abat > 1000)
                    abat = 1000;
                IRG = IRG - abat;
                IRG = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, IRG);
            } 
        }

        public void EvaluateBase()
        {
            foreach (Indem_Personne detail in Indem_Personnes)
            {
                BASE = 0;

                if ((detail.Indem.Form_base != "") && (detail.Indem.Form_base != null))
                    BASE = (decimal)Evaluate(detail.Indem.Form_base);
                else
                    BASE = (decimal)detail.Base;

                detail.Base = BASE;
            }
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
                    Mt_Af = (5 * parametres.Base_AF) + ((5 - Xnbr_EnfM10) * parametres.Base_AF_Partiel);
                else
                    Mt_Af = (Xnbr_EnfM10 * parametres.Base_AF);
            }
            else
                Mt_Af = (Xnbr_EnfM10 * parametres.Base_AF_Partiel);
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

            Mt_Af_P10 = (Xnbr_EnfP10 * parametres.Base_AF_P10);
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
                //if (personne.sexe.Sexe_Lib_Ar == Sexe_Ar.ذكر)
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
                    if (Sit_Conjoint.Sit_Conj_Lib_Fr == Sit_Conj_FR.Tavail)
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

        public void CalculRetenus()
        {
            decimal tempRetenus = 0m;

            foreach (Indem_Personne detail in Indem_Personnes)
            {
                if (detail.Indem.Retenue == true)
                    if ((detail.Indem.Cod_indem_interne != "SS") && (detail.Indem.Cod_indem_interne != "ChIntempPO")
                       && (detail.Indem.Cod_indem_interne != "IRG") && (detail.Indem.Cod_indem_interne != "Irg_bareme")
                       && (detail.Indem.Cod_indem_interne != "Irg_taux") && (detail.Indem.Cod_indem_interne != "mutuelle"))
                        tempRetenus += detail.Montant;
            }

            Retenu_Global = tempRetenus;

        }
         
        public void CalculerNet()
        {
            bool modifspecNET = If_ModifSpec("NET");

            if (modifspecNET == false)
            {
                NET = BRUT - SS - ChIntempPO - IRG - mutuelle - Retenu_Global + AF_Global + SU + Tot_Indem_Net;//  
                NET = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, NET);

                NETAbsence = NET;

            }
            else
            {
                NET = Get_Montant("NET"); 
                NET = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, NET);

                NETAbsence = NET;
            }
        }

        public void Remise_A_0()
        {
            BRUT = 0;
            IRG = 0;
            SS = 0;
            NET = 0;
            NETAbsence = 0;
            Brute_cotisable = 0;
            Brute_cotisableAbsence = 0;
            Brute_cotisable_Bareme = 0;
            Brute_cotisable_Taux = 0;
            Brute_imposable = 0;
            Brute_imposable_Abs = 0;
            Imposable_taux = 0;
            Imposable_bareme = 0;
            Imposable_bareme_22 = 0;
            SDB = 0;
            SDBAbsence = 0;
            RappelSDB = 0;
            RappelSDBAbsence = 0;
            IEP = 0;
            IEP_Ext = 0; 
            Irg_bareme = 0;
            Irg_taux = 0;
            Ss_bareme = 0;
            SS_Taux = 0;
            mutuelle = 0;
        }

        public int ContratsCount()
        {
            CriteriaOperator Criteria1 = CriteriaOperator.Parse("max(NumContrat)");
            CriteriaOperator Criteria2 = CriteriaOperator.Parse("Employe",this);
            int Number = Convert.ToInt16(this.Session.Evaluate(typeof(ContratPersonne), CriteriaOperator.And(Criteria1), null));

            return Number;
        }

        Calculer_Cle Calculer_Cle = new Calculer_Cle();

        protected override void OnSaving()
        {
            base.OnSaving();
             
            //Nbr_Jrs_Cong_Accor = Relecat_Nbr_Jrs_Cong;
            if (num_compte != "" && num_compte != null)
            {
                try
                {
                    string clecmpt = Calculer_Cle.CalculerCleCmpt(num_compte);
                    string clerip = Calculer_Cle.CalculerCleRIP(num_compte);

                    if (cle_compt != clecmpt)
                    {
                        //MessageBox.Show("Employé " + Cod_personne + "  " + FullName + " : Clé compte CCP " + cle_compt + " erronée, " + clecmpt + " calculé !");
                        cle_compt = clecmpt;
                    }
                    cle_rip = clerip;
                }
                catch
                {
                    throw new Exception("Le format du N°Compte CCP saisi n'est pas valide, veuillez le vérifier ! ");
                }
            }

            if(parametres != null)
                if(Soumis_Cacobatph ==true)  
                    if (Taux_cacobatph == 0)
                    {
                        Taux_cacobatph = parametres.Taux_cacobatph;
                        Taux_chomage_intemperie = parametres.Taux_chomage_intemperie;
                    }
             
        }
         

    }

}
