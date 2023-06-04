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


    //[DefaultClassOptions]
    public class Periodes_DAS : BaseObject
    { 
        private DAS fDAS;
        [Association("DAS-Periodes_DAS", typeof(DAS))]
        public DAS DAS
        {
            get { return fDAS; }
            set
            {
                SetPropertyValue("DAS", ref fDAS, value); 
               
            }

        }

        private DateTime fDebut_Periode;
        public DateTime Debut_Periode
        {
            get { return fDebut_Periode; }
            set { SetPropertyValue<DateTime>("Debut_Periode", ref fDebut_Periode, value); }
        }

        private DateTime fFin_Periode;
        public DateTime Fin_Periode
        {
            get { return fFin_Periode; }
            set { SetPropertyValue<DateTime>("Fin_Periode", ref fFin_Periode, value); }
        }
 
        private string fCod_DAS;
        public string Cod_DAS
        {
            get { return fCod_DAS; }
            set { SetPropertyValue<string>("Cod_DAS", ref fCod_DAS, value); }
        }


        private int fAnnee;
        public int Annee
        {
            get { return fAnnee; }
            set { SetPropertyValue<int>("Annee", ref fAnnee, value); }
        }

        private int fDuree_Travail;
        public int Duree_Travail
        {
            get { return fDuree_Travail; }
            set { SetPropertyValue<int>("Duree_Travail", ref fDuree_Travail, value); }
        }

        private decimal fSalaire_Soumis;
        public decimal Salaire_Soumis
        {
            get { return fSalaire_Soumis; }
            set
            {
                SetPropertyValue<decimal>("Salaire_Soumis", ref fSalaire_Soumis, value);
            }
        }

        private Fonction fQualification;
        public Fonction Qualification
        {
            get { return fQualification; }
            set { SetPropertyValue<Fonction>("Qualification", ref fQualification, value); }
        }


        private string fDesignation_Caisse;
        public string Designation_Caisse
        {
            get { return fDesignation_Caisse; }
            set { SetPropertyValue<string>("Designation_Caisse", ref fDesignation_Caisse, value); }
        }

        public Periodes_DAS(Session session)
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

        


    }

}
