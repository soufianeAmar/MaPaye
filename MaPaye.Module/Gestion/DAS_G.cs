using System;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace MaPaye.Module
{
    [DefaultClassOptions]  
    public class DAS_G : BaseObject
    {

        private int fCode;
        public int Code
        {
            get { return fCode; }
            set { SetPropertyValue<int>("Code", ref fCode, value); }
        }
        
        //private string fCodeDAS;
        //public string CodeDAS
        //{
        //    get { return fCodeDAS; }
        //    set { SetPropertyValue<string>("CodeDAS", ref fCodeDAS, value); }
        //}
 
        DateTime fdate;
        [DisplayName("Date")] 
        public DateTime date
        {
            get { return fdate; }
            set { SetPropertyValue("date", ref fdate, value); }
        }

        //private int fAnnee;
        //public int Annee
        //{
        //    get { return fAnnee; }
        //    set { SetPropertyValue<int>("Annee", ref fAnnee, value); }
        //}

        private string fDenomination;
        public string Denomination
        {
            get { return fDenomination; }
            set { SetPropertyValue<string>("Denomination", ref fDenomination, value); }
        }

        private string fOrganisme_Fr;
        public string Organisme_Fr
        {
            get { return fOrganisme_Fr; }
            set { SetPropertyValue<string>("Organisme_Fr", ref fOrganisme_Fr, value); }
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

        private decimal ftot_montant_tr1;
        public decimal tot_montant_tr1
        {
            get {  
                return ftot_montant_tr1; 
            }
            set { SetPropertyValue<decimal>("tot_montant_tr1", ref ftot_montant_tr1, value); }
        }

        private decimal ftot_montant_tr2;
        public decimal tot_montant_tr2
        {
            get {
                return ftot_montant_tr2; 
            }
            set { SetPropertyValue<decimal>("tot_montant_tr2", ref ftot_montant_tr2, value); }
        }

        private decimal ftot_montant_tr3;
        public decimal tot_montant_tr3
        {
            get {  
                return ftot_montant_tr3; 
            }
            set { SetPropertyValue<decimal>("tot_montant_tr3", ref ftot_montant_tr3, value); }
        }

        private decimal ftot_montant_tr4;
        public decimal tot_montant_tr4
        {
            get { 
                return ftot_montant_tr4;
            }
            set { SetPropertyValue<decimal>("tot_montant_tr4", ref ftot_montant_tr4, value); }
        }

        private decimal ftot_montant;
        public decimal tot_montant
        {
            get
            {
                return ftot_montant; 
            }
            set { SetPropertyValue<decimal>("tot_montant", ref ftot_montant, value); }
        }

        //private int ftot_jrs_trv_tr1;
        //public int tot_jrs_trv_tr1
        //{
        //    get { return ftot_jrs_trv_tr1; }
        //    set { SetPropertyValue<int>("tot_jrs_trv_tr1", ref ftot_jrs_trv_tr1, value); }
        //}

        //private int ftot_jrs_trv_tr2;
        //public int tot_jrs_trv_tr2
        //{
        //    get { return ftot_jrs_trv_tr2; }
        //    set { SetPropertyValue<int>("tot_jrs_trv_tr2", ref ftot_jrs_trv_tr2, value); }
        //}

        //private int ftot_jrs_trv_tr3;
        //public int tot_jrs_trv_tr3
        //{
        //    get { return ftot_jrs_trv_tr3; }
        //    set { SetPropertyValue<int>("tot_jrs_trv_tr3", ref ftot_jrs_trv_tr3, value); }
        //}

        //private int ftot_jrs_trv_tr4;
        //public int tot_jrs_trv_tr4
        //{
        //    get { return ftot_jrs_trv_tr4; }
        //    set { SetPropertyValue<int>("tot_jrs_trv_tr4", ref ftot_jrs_trv_tr4, value); }
        //}
         
        string ftext_DAS;
        [DisplayName("DAS")]
        [Size(SizeAttribute.Unlimited)]
        public string text_DAS
        {
            get { return ftext_DAS; }
            set { SetPropertyValue("text_DAS", ref ftext_DAS, value); }
        }

        string ftext_DAS_Employeur;
        [DisplayName("DAS_Employeur")]
        [Size(SizeAttribute.Unlimited)]
        public string text_DAS_Employeur
        {
            get { return ftext_DAS_Employeur; }
            set { SetPropertyValue("text_DAS_Employeur", ref ftext_DAS_Employeur, value); }
        }

        [DisplayName("Employés")]
        [Association("DAS_G-DAS_Personnes")]
        public XPCollection<Das_Personnes> Das_Personnes
        {
            get { return GetCollection<Das_Personnes>("Das_Personnes"); }
        }

        [DisplayName("Nombre d'employés")]
        [Index(4)]
        public int nombre_employes
        {
            get { return Das_Personnes.Count; }
        }

        private Type_Declar fType_dec;
        public Type_Declar Type_dec
        {
            get { return fType_dec; }
            set { SetPropertyValue<Type_Declar>("Type_dec", ref fType_dec, value); }
        }

        private string fCentr_Payeur;
        public string Centr_Payeur
        {
            get { return fCentr_Payeur; }
            set { SetPropertyValue<string>("Centr_Payeur", ref fCentr_Payeur, value); }
        }

        private string fTlf;
        public string Tlf
        {
            get { return fTlf; }
            set { SetPropertyValue<string>("Tlf", ref fTlf, value); }
        }
         
        private int fNbrEntree;
        public int NbrEntree
        {
            get { return fNbrEntree; }
            set { SetPropertyValue<int>("NbrEntree", ref fNbrEntree, value); }
        }

        private int fNbrSortie;
        public int NbrSortie
        {
            get { return fNbrSortie; }
            set { SetPropertyValue<int>("NbrSortie", ref fNbrSortie, value); }
        }

        public DAS_G(Session session)
            : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here or place it only when the IsLoading property is false:
            // if (!IsLoading){
            //    It is now OK to place your initialization code here.
            // }
            // or as an alternative, move your initialization code into the AfterConstruction method.
            if (!IsLoading)
            {
                date = DateTime.Today;
            }
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }

        //public static int count_DAS(Session session)
        //{
            //XPCollection<DAS_G> das_g = new XPCollection<DAS_G>(session);

            //das_g.Load();
            //int cpt = das_g.Count;
            //return cpt;
        //}

        protected override void OnSaving()
        {
            base.OnSaving();

            Session session = Session;

            tot_montant_tr1 = Convert.ToDecimal(session.Evaluate(typeof(Das_Personnes), CriteriaOperator.Parse("sum(montant_tr1)"),
                CriteriaOperator.Parse("DAS_G=?", this)));

            tot_montant_tr2 = Convert.ToDecimal(session.Evaluate(typeof(Das_Personnes), CriteriaOperator.Parse("sum(montant_tr2)"),
                CriteriaOperator.Parse("DAS_G=?", this)));

            tot_montant_tr3 = Convert.ToDecimal(session.Evaluate(typeof(Das_Personnes), CriteriaOperator.Parse("sum(montant_tr3)"),
                    CriteriaOperator.Parse("DAS_G=?", this)));

            tot_montant_tr4 = Convert.ToDecimal(session.Evaluate(typeof(Das_Personnes), CriteriaOperator.Parse("sum(montant_tr4)"),
                CriteriaOperator.Parse("DAS_G=?", this)));

            tot_montant = Convert.ToDecimal(session.Evaluate(typeof(Das_Personnes), CriteriaOperator.Parse("sum(montant)"),
                CriteriaOperator.Parse("DAS_G=?", this)));//bordereaux.Criteria));
        }

        public void calcul()
        {
            Session session = Session;

            tot_montant_tr1 = Convert.ToDecimal(session.Evaluate(typeof(Das_Personnes), CriteriaOperator.Parse("sum(montant_tr1)"),
                CriteriaOperator.Parse("DAS_G=?", this)));

            tot_montant_tr2 = Convert.ToDecimal(session.Evaluate(typeof(Das_Personnes), CriteriaOperator.Parse("sum(montant_tr2)"),
                CriteriaOperator.Parse("DAS_G=?", this)));

            tot_montant_tr3 = Convert.ToDecimal(session.Evaluate(typeof(Das_Personnes), CriteriaOperator.Parse("sum(montant_tr3)"),
                    CriteriaOperator.Parse("DAS_G=?", this)));

            tot_montant_tr4 = Convert.ToDecimal(session.Evaluate(typeof(Das_Personnes), CriteriaOperator.Parse("sum(montant_tr4)"),
                CriteriaOperator.Parse("DAS_G=?", this)));

            tot_montant = Convert.ToDecimal(session.Evaluate(typeof(Das_Personnes), CriteriaOperator.Parse("sum(montant)"),
                CriteriaOperator.Parse("DAS_G=?", this)));//bordereaux.Criteria));
        }
    }

}
