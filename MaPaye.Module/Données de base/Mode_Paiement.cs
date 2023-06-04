using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.DC;

namespace MaPaye.Module
{

    public enum ModePaiementFR { CCP, Banque, [XafDisplayName("Divers Banque")] Divers_Banque, Caisse }
    public enum ModePaiementAR { [XafDisplayName("Õ”«» »—ÌœÌ Ã«—Ì")]Õ”«»_»—ÌœÌ_Ã«—Ì, [XafDisplayName("Õ”«» »‰ﬂÌ")] Õ”«»_»‰ﬂÌ,
    [XafDisplayName("Õ”«» »‰ﬂÌ „Œ ·›")] Õ”«»_»‰ﬂÌ_„Œ ·›, «·’‰œÊﬁ
    }
  

    [DefaultClassOptions]
    public class Mode_Paiement : BaseObject
    {
        //private ModePaiementAR fType_Paiment_Lib_Ara;
        //public ModePaiementAR Type_Paiment_Lib_Ara
        //{
        //    get { return fType_Paiment_Lib_Ara; }
        //    set { SetPropertyValue<ModePaiementAR>("Type_Paiment_Lib_Ara", ref fType_Paiment_Lib_Ara, value); }
        //}

        private ModePaiementFR fType_Paiment_Lib_Fr;
        public ModePaiementFR Type_Paiment_Lib_Fr
        {
            get { return fType_Paiment_Lib_Fr; }
            set { SetPropertyValue<ModePaiementFR>("Type_Paiment_Lib_Fr", ref fType_Paiment_Lib_Fr, value); }
        }

        public Mode_Paiement(Session session)
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
