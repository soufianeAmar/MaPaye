using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using System.Windows.Forms;

namespace MaPaye.Module
{
    //[DefaultClassOptions]
    public class Mois_Pret : BaseObject
    { 
        private Gestion_Pret fgestion_Pret;
         [Association("Gestion_Pret-Mois_Pret")]
        public Gestion_Pret gestion_Pret
        {
            get { return fgestion_Pret; }
            set { SetPropertyValue<Gestion_Pret>("gestion_Pret", ref fgestion_Pret, value); }
        }

        private decimal fMontant; 
        public decimal Montant
        {
            get { return fMontant; }
            set { SetPropertyValue<decimal>("Montant", ref fMontant, value); }
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

        //private bool fModifSpecial;
        //public bool ModifSpecial
        //{
        //    get { return fModifSpecial; }
        //    set { SetPropertyValue<bool>("ModifSpecial", ref fModifSpecial, value); }
        //}

        private int fAnnee;
        public int Annee
        {
            get { return fAnnee; }
            set { SetPropertyValue<int>("Annee", ref fAnnee, value); }
        }

        public Mois_Pret(Session session)
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
        }

        protected override void OnDeleting()
        {

            Gestion_Pret Gestion_Pret = Session.FindObject<Gestion_Pret>(CriteriaOperator.Parse("Oid==?", this.gestion_Pret));

            if (Gestion_Pret != null)
            {
                CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois=?", ((MoisdelAnnee)Mois).ToString());
                CriteriaOperator criteria2 = CriteriaOperator.Parse("personne.Cod_personne=?", gestion_Pret.CodePersonne);
                CriteriaOperator criteria3 = CriteriaOperator.Parse("cat_paye=?", CategoriePaye.Paye_Mensuel.ToString());

                Paye Paye = Session.FindObject<Paye>(CriteriaOperator.And(criteria1, criteria2, criteria3));

                if (Paye != null)
                {
                    CriteriaOperator criteria4 = CriteriaOperator.Parse("Indemnite.Cod_indem_interne=?", "Retenu_Pret");
                    CriteriaOperator criteria5 = CriteriaOperator.Parse("Paye=?", Paye.Oid.ToString());

                    paye_indem Paye_Indem = Session.FindObject<paye_indem>(CriteriaOperator.And(criteria4, criteria5));

                    if (Paye_Indem != null)
                    {
                        Paye_Indem.Delete();
                        Paye_Indem.Save();
                        Paye.Save();
                        Paye.CalculerPaye();
                        Paye.Save();
                    }
                }

                gestion_Pret.Reste_Pret += Montant;
                gestion_Pret.Save();

            }

            base.OnDeleting();
        }

    }
}
