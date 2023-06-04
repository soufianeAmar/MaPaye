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
     [DefaultProperty("des_f")]
    [DefaultClassOptions]
    public class Banque : BaseObject
    {
        private string fcod_banque; 
        public string cod_banque
        {
            get { return fcod_banque; }
            set { SetPropertyValue<string>("cod_banque", ref fcod_banque, value); }
        }

        private string fCod_Agence; 
        public string Cod_Agence
        {
            get { return fCod_Agence; }
            set { SetPropertyValue<string>("Cod_Agence", ref fCod_Agence, value); }
        }

        private string fadr_f;
        public string adr_f
        {
            get { return fadr_f; }
            set { SetPropertyValue<string>("adr_f", ref fadr_f, value); }
        }
        private string fdes_f;
        [Size(50)] 
        public string des_f
        {
            get { return fdes_f; }
            set { SetPropertyValue<string>("des_f", ref fdes_f, value); }
        }

        //private string fdes_a;
        //[Size(50)]
        //public string des_a
        //{
        //    get { return fdes_a; }
        //    set { SetPropertyValue<string>("des_a", ref fdes_a, value); }
        //}
        private string fnum_compte;
        [Size(255)]
        public string num_compte
        {
            get { return fnum_compte; }
            set { SetPropertyValue<string>("num_compte", ref fnum_compte, value); }
        }

        private string fcle_compte;
        public string cle_compte
        {
            get { return fcle_compte; }
            set { SetPropertyValue<string>("cle_compte", ref fcle_compte, value); }
        }

        //private int ftype_compte;
        //public int type_compte
        //{
        //    get { return ftype_compte; }
        //    set { SetPropertyValue<int>("type_compte", ref ftype_compte, value); }
        //}

        private string ftel;
        [Size(50)]
        public string tel
        {
            get { return ftel; }
            set { SetPropertyValue<string>("tel", ref ftel, value); }
        }
        private bool fBanque_employeur;
        public bool Banque_employeur
        {
            get { return fBanque_employeur; }
            set { SetPropertyValue<bool>("Banque_employeur", ref fBanque_employeur, value); }
        }
        

        private string ffax;
        [Size(50)]
        public string fax
        {
            get { return ffax; }
            set { SetPropertyValue<string>("fax", ref ffax, value); }
        }
        public Banque(Session session)
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
