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
    public enum Type_Abs_FR { [XafDisplayName("Absence Indemnite")]Absence_Indemnite, [XafDisplayName("Absence Brut")] Absence_Brut, [XafDisplayName("Absence Net")] Absence_Net }
    public enum Type_Abs_Ar { [XafDisplayName("€Ì«» «· ⁄ÊÌ÷")]€Ì«»_«· ⁄ÊÌ÷, [XafDisplayName("€Ì«» «·Œ«„")] €Ì«»_«·Œ«„, [XafDisplayName("€Ì«» «·’«›Ì")] €Ì«»_«·’«›Ì }
   
    [DefaultClassOptions]
    public class Type_Absence : BaseObject
    {
        //[Key]
        private Type_Abs_FR fType_Abs_Lib_Fr; 
        public Type_Abs_FR Type_Abs_Lib_Fr
        {
            get { return fType_Abs_Lib_Fr; }
            set { SetPropertyValue<Type_Abs_FR>("Type_Abs_Lib_Fr", ref fType_Abs_Lib_Fr, value); }
        }
         
        public Type_Absence(Session session)
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
