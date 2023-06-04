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
    public class Motif_Etat_Matrice : BaseObject
    {
        //string fMotif_Etat_Matrice_Ar;
        //public string Motif_Etat_Matrice_Ar
        //{
        //    get { return fMotif_Etat_Matrice_Ar; }
        //    set { SetPropertyValue<string>("Motif_Etat_Matrice_Ar", ref fMotif_Etat_Matrice_Ar, value); }
        //}

        string fMotif_Etat_Matrice_Fr;
        public string Motif_Etat_Matrice_Fr
        {
            get { return fMotif_Etat_Matrice_Fr; }
            set { SetPropertyValue<string>("Motif_Etat_Matrice_Fr", ref fMotif_Etat_Matrice_Fr, value); }
        }

        public Motif_Etat_Matrice(Session session)
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
