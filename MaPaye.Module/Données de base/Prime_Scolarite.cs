using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Filtering;


namespace MaPaye.Module
{

    //[DefaultClassOptions]
    public class Prime_Scolarite : BaseObject
    {
        private Personne fpersonne;
        public Personne personne
        {
            get { return fpersonne; }
            set { SetPropertyValue<Personne>("personne", ref fpersonne, value); }
        }

        private Corps fCorps;
        public Corps Corps
        {
            get { return fCorps; }
            set { SetPropertyValue<Corps>("Corps", ref fCorps, value); }
        }

        private Fonction fLaFonction;
        public Fonction LaFonction
        {
            get { return fLaFonction; }
            set { SetPropertyValue<Fonction>("LaFonction", ref fLaFonction, value); }
        }

        private decimal fSDB; //fonction fait
        public decimal SDB
        {
            get { return fSDB; }
            set { SetPropertyValue<decimal>("SDB", ref fSDB, value); }
        }
         
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

        private int fNbr_enf_Scol;
        public int Nbr_enf_Scol
        {
            get
            { return fNbr_enf_Scol; }
            set { SetPropertyValue<int>("Nbr_enf_Scol", ref fNbr_enf_Scol, value); }
        }

        private parametre fparametres;
        public parametre parametres
        {
            get { return fparametres; }
            set { SetPropertyValue<parametre>("parametres", ref fparametres, value); }
        } 

        private decimal fNet_Scol; 
        public decimal Net_Scol
        {
            get { return fNet_Scol; }
            set { SetPropertyValue<decimal>("Net_Scol", ref fNet_Scol, value); }
        }

        private int fAnnee_Scol;
        public int Annee_Scol
        {
            get { return fAnnee_Scol; }
            set { SetPropertyValue<int>("Annee_Scol", ref fAnnee_Scol, value); }
        }

        private ModeArrondi fMode_Arrondi;
        public ModeArrondi Mode_Arrondi
        {
            get { return fMode_Arrondi; }
            set { SetPropertyValue<ModeArrondi>("Mode_Arrondi", ref fMode_Arrondi, value); }
        }
  
        public Prime_Scolarite(Session session)
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

            Mode_Arrondi = parametres.Mode_Arrondi;
        }
 
        protected override void OnSaved()
        {
            base.OnSaved();

            CalculerPrimeScolarite();
            Save();

        }

        Arrondi_Decimal ArrondiDecimale = new Arrondi_Decimal();

        public void CalculerPrimeScolarite()
        {
            parametres = parametre.GetInstance(Session);
            //parametres = Parametres;

            if (Bloque_Scol == false)
            { 
                if (Intégral_Scol == true)
                {
                    Net_Scol = Nbr_enf_Scol * parametres.Base_Prime_Scol;
                    Net_Scol = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Net_Scol);
                }
                else
                    if (Partiel_Scol == true)
                    {
                        Net_Scol = Nbr_enf_Scol * parametres.Base_Prime_Scol_Partiel;
                        Net_Scol = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, Net_Scol);
                    }
            }
            else
                Net_Scol = 0;
        }

    }

}
