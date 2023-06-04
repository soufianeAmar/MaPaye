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
    [DefaultClassOptions]
    public class Bordereau : BaseObject
    {

        private int fCode;
        public int Code
        {
            get { return fCode; }
            set { SetPropertyValue<int>("Code", ref fCode, value); }
        }
         
        private string fCod_Bordereau;
        public string Cod_Bordereau
        {
            get { return fCod_Bordereau; }
            set { SetPropertyValue<string>("Cod_Bordereau", ref fCod_Bordereau, value); }
        }


        private string fChaine_Bordereau;
        public string Chaine_Bordereau
        {
            get { return fChaine_Bordereau; }
            set { SetPropertyValue<string>("Chaine_Bordereau", ref fChaine_Bordereau, value); }
        }


        private Personne fpersonne;
        public Personne personne
        {
            get { return fpersonne; }
            set { SetPropertyValue<Personne>("personne", ref fpersonne, value); }
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


        private decimal fMontant;
        public decimal Montant
        {
            get { return fMontant; }
            set
            {
                SetPropertyValue<decimal>("Montant", ref fMontant, value);
            }
        }

        private parametre fparametres;
        public parametre parametres
        {
            get { return fparametres; }
            set { SetPropertyValue<parametre>("parametres", ref fparametres, value); }
        }

        public Bordereau(Session session)
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

            
        }
    }

}
