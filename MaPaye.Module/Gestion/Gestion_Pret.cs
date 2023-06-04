using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using System.Windows.Forms;

namespace MaPaye.Module
{
    [DefaultClassOptions]
    public class Gestion_Pret : BaseObject
    {

        private string fCodePersonne;
        public string CodePersonne
        {
            get { return fCodePersonne; }
            set { SetPropertyValue<string>("CodePersonne", ref fCodePersonne, value); }
        }

        private decimal fPret_Initial;
        public decimal Pret_Initial
        {
            get { return fPret_Initial; }
            set { SetPropertyValue<decimal>("Pret_Initial", ref fPret_Initial, value); }
        }


        private decimal fReste_Pret;
        public decimal Reste_Pret
        {
            get { return fReste_Pret; }
            set { SetPropertyValue<decimal>("Reste_Pret", ref fReste_Pret, value); }
        }
         
        private Personne fpersonne;
        public Personne personne
        {
            get { return fpersonne; }
            set { SetPropertyValue<Personne>("personne", ref fpersonne, value); }
        }
         
        private decimal fMensualite;
        public decimal Mensualite
        {
            get { return fMensualite; }
            set { SetPropertyValue<decimal>("Mensualite", ref fMensualite, value); }
        }

        private decimal fAncien_Paiement;
        public decimal Ancien_Paiement
        {
            get { return fAncien_Paiement; }
            set { SetPropertyValue<decimal>("Ancien_Paiement", ref fAncien_Paiement, value); }
        }

        private decimal fMontant_Ancien_Retenu;
        public decimal Montant_Ancien_Retenu
        {
            get { return fMontant_Ancien_Retenu; }
            set { SetPropertyValue<decimal>("Montant_Ancien_Retenu", ref fMontant_Ancien_Retenu, value); }
        }

        private DateTime fDate_Pret;
        public DateTime Date_Pret
        {
            get { return fDate_Pret; }
            set { SetPropertyValue<DateTime>("Date_Pret", ref fDate_Pret, value); }
        }

        private bool fDifferer_Payement;
        public bool Differer_Payement
        {
            get { return fDifferer_Payement; }
            set { SetPropertyValue<bool>("Differer_Payement", ref fDifferer_Payement, value); }
        }

        [Association("Gestion_Pret-Mois_Pret")]
        public XPCollection<Mois_Pret> Mois_Prets
        {
            get { return GetCollection<Mois_Pret>("Mois_Prets"); }
        }

        private parametre fparametres;
        public parametre parametres
        {
            get { return fparametres; }
            set { SetPropertyValue<parametre>("parametres", ref fparametres, value); }
        }

        public Gestion_Pret(Session session)
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

            parametres = parametre.GetInstance(Session);
            //parametres = Parametres;
        }

        protected override void OnSaving()
        {
            base.OnSaving();

            CodePersonne = personne.Cod_personne;
            if ((Reste_Pret == 0) && (Montant_Ancien_Retenu == 0))
                Reste_Pret = Pret_Initial - Ancien_Paiement;
            
        }


        protected override void OnDeleting()
        {

            XPCollection<Mois_Pret> Mois_Pret_Delete = new XPCollection<Mois_Pret>(Session, CriteriaOperator.Parse("gestion_Pret=?", Oid.ToString()));
            Session.Delete(Mois_Pret_Delete);
            Session.Save(Mois_Pret_Delete);

            base.OnDeleting();
        }

        //public bool If_ModifSpec(Paye paye)
        //{
        //    bool modifspec = false;

        //    CriteriaOperator criteria1 = CriteriaOperator.Parse("Mois==?", paye.Mois);
        //    CriteriaOperator criteria2 = CriteriaOperator.Parse("Annee==?", paye.Annee);
        //    CriteriaOperator criteria3 = CriteriaOperator.Parse("gestion_Pret==?", this);

        //    Mois_Pret MoisPret = this.Session.FindObject<Mois_Pret>(CriteriaOperator.And(criteria1, criteria2, criteria3));

        //    if (MoisPret != null)
        //        modifspec = MoisPret.ModifSpecial;

        //    return modifspec;
        //}

        public decimal CalculPret(Paye paye, decimal montant)
        {
            decimal tempPres = 0;

            if (Differer_Payement != true)
            {

                CriteriaOperator criteria1 = CriteriaOperator.Parse("gestion_Pret==?", this);
                CriteriaOperator criteria2 = CriteriaOperator.Parse("Mois==?", paye.Mois);
                CriteriaOperator criteria3 = CriteriaOperator.Parse("Annee==?", paye.Annee);

                Mois_Pret mois_pret = this.Session.FindObject<Mois_Pret>(CriteriaOperator.And(criteria1, criteria2, criteria3));

                if (mois_pret == null)
                {
                    if (Reste_Pret > 0)
                    {
                        if (Reste_Pret > Mensualite)
                        {
                            tempPres += Mensualite;
                            Reste_Pret -= Mensualite;
                            Montant_Ancien_Retenu = tempPres;
                        }
                        else
                        {
                            tempPres += Reste_Pret;
                            Reste_Pret = 0;
                            Montant_Ancien_Retenu = tempPres;
                        }
                    }
                    Session.CommitTransaction();

                    Mois_Pret MoisAInserer = new Mois_Pret(Session);
                    MoisAInserer.gestion_Pret = this;
                    MoisAInserer.Mois = paye.Mois;
                    MoisAInserer.Annee = paye.Annee;
                    MoisAInserer.Montant = tempPres;

                    MoisAInserer.Save();
                    Mois_Prets.Add(MoisAInserer);

                    Session.CommitTransaction();
                }
                else
                {
                    //if (mois_pret.ModifSpecial)
                    //{
                    //    Reste_Pret += montant;
                    //    tempPres = mois_pret.Montant;
                    //    Reste_Pret -= mois_pret.Montant;
                    //}
                    //else
                        if (montant != 0)
                        {
                            if (montant == mois_pret.Montant)
                            {
                                if (mois_pret.Montant != 0)
                                {
                                    if (mois_pret.Montant == Mensualite)
                                    {
                                        tempPres = mois_pret.Montant;
                                        Montant_Ancien_Retenu = tempPres;
                                    }
                                    else
                                    {
                                        mois_pret.Montant = Mensualite;
                                        tempPres = Mensualite;
                                        Reste_Pret -= Mensualite;
                                        Montant_Ancien_Retenu = tempPres;
                                    }
                                }
                                else
                                {
                                    mois_pret.Montant = Mensualite;
                                    tempPres = Mensualite;
                                    Reste_Pret -= Mensualite;
                                    Montant_Ancien_Retenu = tempPres;
                                }
                            }
                            else
                            {
                                if (mois_pret.Montant != 0)
                                {
                                    Reste_Pret += mois_pret.Montant;
                                    mois_pret.Montant = montant; 
                                    Reste_Pret -= montant;
                                    tempPres = montant;
                                    Montant_Ancien_Retenu = tempPres;
                                }
                                else
                                {
                                    mois_pret.Montant = montant;
                                    Reste_Pret -= montant;
                                    tempPres = montant;
                                    Montant_Ancien_Retenu = tempPres;
                                }
                            }
                        }
                        else
                        {
                            if (mois_pret.Montant != 0)
                                if (mois_pret.Montant == Mensualite)
                                {
                                    tempPres = mois_pret.Montant;
                                    Montant_Ancien_Retenu = tempPres;
                                }
                                else
                                {
                                    Reste_Pret += mois_pret.Montant;
                                    mois_pret.Montant = Mensualite;
                                    tempPres = Mensualite;
                                    Reste_Pret -= Mensualite;
                                    Montant_Ancien_Retenu = tempPres;
                                }
                            else
                            {
                                mois_pret.Montant = Mensualite;
                                tempPres = Mensualite;
                                Reste_Pret -= Mensualite;
                                Montant_Ancien_Retenu = tempPres;
                            }
                        }
                }
            }
            return tempPres;
        } 
    }

}
