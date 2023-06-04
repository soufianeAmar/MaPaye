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
    public enum CorpsFR { Contractuel, Paramédical, Médical, Psycologue, Résident, Interne, Administratif,
    [XafDisplayName("Contractuel Complet")]Contractuel_Complet , [XafDisplayName("Contractuel 5H")] Contractuel_5H, 
        Additif, Titulaire, Temporaire
    }
    //public enum CorpsAr { متعاقدين, شبه_طبي, طبي, الأطباء_المقيمين, الأطباء_الداخلين, الإداري, المتعاقدين_بالتوقيت_الكامل, المتعاقدين_بالتوقيت_الجزئي, إضافية, مرسمين, مؤقتين, النفسانيين }

     [DefaultProperty("DesCorps")]
    [DefaultClassOptions]
    public class Corps : BaseObject
    {
        private string fCodeCorps; 
        public string CodeCorps
        {
            get { return fCodeCorps; }
            set { SetPropertyValue<string>("CodeCorps", ref fCodeCorps, value); }
        }

        private string fDesCorps; 
        public string DesCorps
        {
            get { return fDesCorps; }
            set { SetPropertyValue<string>("DesCorps", ref fDesCorps, value); }
        }

        //private string fDesCorpsAr; 
        //public string DesCorpsAr
        //{
        //    get { return fDesCorpsAr; }
        //    set { SetPropertyValue<string>("DesCorpsAr", ref fDesCorpsAr, value); }
        //}

        //private string fTypeCorp; 
        //public string TypeCorp
        //{
        //    get { return fTypeCorp; }
        //    set { SetPropertyValue<string>("TypeCorp", ref fTypeCorp, value); }
        //}

        //private CorpsAr fCorpsLibAra; 
        //public CorpsAr CorpsLibAra
        //{
        //    get { return fCorpsLibAra; }
        //    set { SetPropertyValue<CorpsAr>("CorpsLibAra", ref fCorpsLibAra, value); }
        //}
        
        //private CorpsFR fCorpsLibFr;
        //public CorpsFR CorpsLibFr
        //{
        //    get { return fCorpsLibFr; }
        //    set { SetPropertyValue<CorpsFR>("CorpsLibFr", ref fCorpsLibFr, value); }
        //}


     
        public Corps(Session session)
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
