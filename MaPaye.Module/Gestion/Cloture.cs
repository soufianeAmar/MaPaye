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

    public enum CategorieCloture { Paye, Rappel }
 
    [DefaultClassOptions]
    public class Cloture : BaseObject
    {
        private string fCod_Cloture;
        public string Cod_Cloture
        {
            get { return fCod_Cloture; }
            set { SetPropertyValue<string>("Cod_Cloture", ref fCod_Cloture, value); }
        }

        private MoisdelAnnee fMois;
        public MoisdelAnnee Mois
        {
            get { return fMois; }
            set { SetPropertyValue<MoisdelAnnee>("Mois", ref fMois, value); }
        }

        private string fAnnee;
        public string Annee
        {
            get { return fAnnee; }
            set { SetPropertyValue<string>("Annee", ref fAnnee, value); }
        }

        private bool fEst_Cloture;
        public bool Est_Cloture
        {
            get { return fEst_Cloture; }
            set { SetPropertyValue<bool>("Est_Cloture", ref fEst_Cloture, value); }
        }

        private CategorieCloture fCategorie;
        public CategorieCloture Categorie
        {
            get { return fCategorie; }
            set { SetPropertyValue<CategorieCloture>("Categorie", ref fCategorie, value); }
        }

        public Cloture(Session session)
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

        protected override void OnSaving()
        {
            base.OnSaving();

            //Session currentSession = this.Session;
            //parametre Parametres = currentSession.FindObject<parametre>(null);


            //Cloture Cloture = currentSession.FindObject<Cloture>(CriteriaOperator.Parse("Cod_Cloture==?", Mois.ToString() + Parametres.Annee_Travail.ToString()));
            //if (Cloture == null)
            //{
            //    Cloture cloture = new Cloture(currentSession);
            //    cloture.Cod_Cloture = Mois + Parametres.Annee_Travail.ToString();
            //    cloture.Mois = (MoisdelAnnee)Mois;
            //    cloture.Annee = Parametres.Annee_Travail.ToString();
            //    cloture.Est_Cloture = true;
            //    cloture.Save();
            //}
            //else
            //{
            //    if (Cloture.Est_Cloture == false)
            //    {
            //        Cloture.Est_Cloture = true;
            //        Cloture.Save();
            //    }
            //    else
            //        MessageBox.Show("La paye de ce mois a été déja cloturée !");
            //}

            //XPCollection<Paye> PayeCollection = new XPCollection<Paye>(currentSession, CriteriaOperator.Parse("Mois=?", ((MoisdelAnnee)Mois).ToString()));
            //PayeCollection.Load();

            //foreach (Paye paye in PayeCollection)
            //{
            //    Recape_Annuelle Recape_Annuelle = new Recape_Annuelle(currentSession);
            //    Recape_Annuelle.Recape_paye(paye);
            //}

            //currentSession.CommitTransaction();
        }
    }

}
