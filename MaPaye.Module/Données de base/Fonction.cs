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
    [DefaultClassOptions]
    [DefaultProperty("Fct_Lib_Fr")]
    public class Fonction : BaseObject
    {
        
        //Tadjou One to many 
        [Association("Fonctions-Indem_Fonctions", typeof(Indem_Fonction))]
        public XPCollection Indem_Fontions
        {
            get { return GetCollection("Indem_Fontions"); }
        }

        private string fcod_fonction;
        public string cod_fonction
        {
            get { return fcod_fonction; }
            set { SetPropertyValue<string>("cod_fonction", ref fcod_fonction, value); }
        }
         
        private string fFct_Lib_Fr; 
        public string Fct_Lib_Fr
        {
            get { return fFct_Lib_Fr; }
            set { SetPropertyValue<string>("Fct_Lib_Fr", ref fFct_Lib_Fr, value); }
        }
         
        private Bareme fCategorie;
        public Bareme Categorie
        {
            get { return fCategorie; }
            set { SetPropertyValue<Bareme>("Categorie", ref fCategorie, value); }
        }

        private Corps fCorps;
        public Corps Corps
        {
            get { return fCorps; }
            set { SetPropertyValue<Corps>("Corps", ref fCorps, value); }
        }
         
        public Fonction(Session session)
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

            //parametres = Parametres;
            //Secteur_Organisme = parametres.Secteur_Organisme;

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
                Indem_Fonction IndemniteAInserer = new Indem_Fonction(Session);
                IndemniteAInserer.Indem = IndemniteSDB;
                IndemniteAInserer.Fonction = this;

                Indem_Fontions.Add(IndemniteAInserer);
            }

            if (IndemniteIEP != null)
            {
                Indem_Fonction IndemniteAInserer = new Indem_Fonction(Session);
                IndemniteAInserer.Indem = IndemniteIEP;
                IndemniteAInserer.Fonction = this;

                Indem_Fontions.Add(IndemniteAInserer);
            }

            if (IndemniteBrutCotis != null)
            {
                Indem_Fonction IndemniteAInserer = new Indem_Fonction(Session);
                IndemniteAInserer.Indem = IndemniteBrutCotis;
                IndemniteAInserer.Fonction = this;

                Indem_Fontions.Add(IndemniteAInserer);
            }

            if (IndemniteSS != null)
            {
                Indem_Fonction IndemniteAInserer = new Indem_Fonction(Session);
                IndemniteAInserer.Indem = IndemniteSS;
                IndemniteAInserer.Fonction = this;

                Indem_Fontions.Add(IndemniteAInserer);
            }

            if (IndemniteBrutImpo != null)
            {
                Indem_Fonction IndemniteAInserer = new Indem_Fonction(Session);
                IndemniteAInserer.Indem = IndemniteBrutImpo;
                IndemniteAInserer.Fonction = this;

                Indem_Fontions.Add(IndemniteAInserer);
            }

            if (IndemniteIRG != null)
            {
                Indem_Fonction IndemniteAInserer = new Indem_Fonction(Session);
                IndemniteAInserer.Indem = IndemniteIRG;
                IndemniteAInserer.Fonction = this;

                Indem_Fontions.Add(IndemniteAInserer);
            }

            if (IndemniteNET != null)
            {
                Indem_Fonction IndemniteAInserer = new Indem_Fonction(Session);
                IndemniteAInserer.Indem = IndemniteNET;
                IndemniteAInserer.Fonction = this;

                Indem_Fontions.Add(IndemniteAInserer);
            }
        }


    }

}
