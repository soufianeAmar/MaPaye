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
    [DefaultProperty("Denomination")]
    public class Unite : BaseObject
    {
        private string fCod_uni;
  
        [Size(30)]
        public string Cod_uni
        {
            get { return fCod_uni; }
            set { SetPropertyValue<string>("Cod_uni", ref fCod_uni, value); }
        }

        private string fDes_fr; 
        public string Des_fr
        {
            get { return fDes_fr; }
            set { SetPropertyValue<string>("Des_fr", ref fDes_fr, value); }
        }
         
        private string fDenomination;
        public string Denomination
        {
            get { return fDenomination; }
            set { SetPropertyValue<string>("Denomination", ref fDenomination, value); }
        }

        private string fNumEmployeur;
        [Size(50)]
        public string NumEmployeur
        {
            get { return fNumEmployeur; }
            set { SetPropertyValue<string>("NumEmployeur", ref fNumEmployeur, value); }
        }

        private string fAdresse;
        public string Adresse
        {
            get { return fAdresse; }
            set { SetPropertyValue<string>("Adresse", ref fAdresse, value); }
        }

        private string fRegion_Fr;
        public string Region_Fr
        {
            get { return fRegion_Fr; }
            set { SetPropertyValue<string>("Region_Fr", ref fRegion_Fr, value); }
        }

        private string fCommune_Fr;
        public string Commune_Fr
        {
            get { return fCommune_Fr; }
            set { SetPropertyValue<string>("Commune_Fr", ref fCommune_Fr, value); }
        }

        private string fDaira_Fr;
        public string Daira_Fr
        {
            get { return fDaira_Fr; }
            set { SetPropertyValue<string>("Daira_Fr", ref fDaira_Fr, value); }
        }

        private string fWilaya_Fr;
        public string Wilaya_Fr
        {
            get { return fWilaya_Fr; }
            set { SetPropertyValue<string>("Wilaya_Fr", ref fWilaya_Fr, value); }
        }
         
        private string fTel;
        public string Tel
        {
            get { return fTel; }
            set { SetPropertyValue<string>("Tel", ref fTel, value); }
        }

        private string fCentrePayeur;
        public string CentrePayeur
        {
            get { return fCentrePayeur; }
            set { SetPropertyValue<string>("CentrePayeur", ref fCentrePayeur, value); }
        }

        private Type_Declar fTypeDeclaration;
        public Type_Declar TypeDeclaration
        {
            get { return fTypeDeclaration; }
            set { SetPropertyValue<Type_Declar>("TypeDeclaration", ref fTypeDeclaration, value); }
        }

        private string fAgenceCNAS;
        [Size(30)]
        public string AgenceCNAS
        {
            get { return fAgenceCNAS; }
            set { SetPropertyValue<string>("AgenceCNAS", ref fAgenceCNAS, value); }
        }

        private string fAgenceCacobatph;
        [Size(30)]
        public string AgenceCacobatph
        {
            get { return fAgenceCacobatph; }
            set { SetPropertyValue<string>("AgenceCacobatph", ref fAgenceCacobatph, value); }
        }

        public Unite(Session session)
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
