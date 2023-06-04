using System; 
using DevExpress.Xpo; 
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Data.Filtering; 

namespace MaPaye.Module
{
    [DefaultClassOptions]
    public class ContratPersonne : BaseObject
    {

        private int fNumContrat;
        public int NumContrat
        {
            get { return fNumContrat; }
            set { SetPropertyValue<int>("NumContrat", ref fNumContrat, value); }
        }

        private Personne fEmploye;
        [Association("Employe-Contrat")] 
        public Personne Employe
        {
            get { return fEmploye; }
            set { SetPropertyValue("Employe", ref fEmploye, value); }
        }

        private DateTime fDateDebutContrat;
        public DateTime DateDebutContrat
        {
            get { return fDateDebutContrat; }
            set { SetPropertyValue<DateTime>("DateDebutContrat", ref fDateDebutContrat, value); }
        }

        private DateTime fDateFinContrat;
        public DateTime DateFinContrat
        {
            get { return fDateFinContrat; }
            set { SetPropertyValue<DateTime>("DateFinContrat", ref fDateFinContrat, value); }
        }
         
        private Unite fUnite;
        public Unite Unite
        {
            get { return fUnite; }
            set { SetPropertyValue<Unite>("Unite", ref fUnite, value); }
        }
         
        public ContratPersonne(Session session)
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

            //CriteriaOperator Criteria1 = CriteriaOperator.Parse("max(NumContrat)"); 
            //CriteriaOperator Criteria2 = CriteriaOperator.Parse("max(NumContrat)");  
            //Convert.ToInt16(this.Session.Evaluate(typeof(ContratPersonne), CriteriaOperator.Parse("max(NumContrat)"), null));
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            //if (!IsDeleted)
            //{
            //    int Number = Employe.ContratsCount();
            //    NumContrat = Number + 1;
            //}
        }
    } 
}
