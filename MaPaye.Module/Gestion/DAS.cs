using System;

using DevExpress.Xpo;

using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Data.Filtering;

namespace MaPaye.Module
{

    [DefaultClassOptions]
    public class DAS : BaseObject
    {
        [Association("DAS-Periodes_DAS", typeof(Periodes_DAS))]
        public XPCollection Periodes_DAS
        {
            get { return GetCollection("Periodes_DAS"); }
        }
 
        private string fCod_DAS; 
        public string Cod_DAS
        {
            get { return fCod_DAS; }
            set { SetPropertyValue<string>("Cod_DAS", ref fCod_DAS, value); }
        }


        private Personne fpersonne;
        public Personne personne
        {
            get { return fpersonne; }
            set { SetPropertyValue<Personne>("personne", ref fpersonne, value); }
        }
  
          
        private parametre fparametres;
        public parametre parametres
        {
            get { return fparametres; }
            set { SetPropertyValue<parametre>("parametres", ref fparametres, value); }
        }



        private DateTime fDate_Debut;
        public DateTime Date_Debut
        {
            get { return fDate_Debut; }
            set { SetPropertyValue<DateTime>("Date_Debut", ref fDate_Debut, value); }
        }

        private DateTime fDate_Fin;
        public DateTime Date_Fin
        {
            get { return fDate_Fin; }
            set { SetPropertyValue<DateTime>("Date_Fin", ref fDate_Fin, value); }
        }

        public DAS(Session session)
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



            /************************************************************/
             

        }

        public int DureeTravail(DateTime DateDebut, DateTime DateFin)
        {
            int NbrJrs = 0;


            ////TimeSpan nbrm = DateFin - DateDebut;
            ////double mois = nbrm.totalm;

            //TimeSpan nbrj = DateFin - DateDebut;
            //double jrs = nbrj.TotalDays;

            ////TimeSpan nbrjw = DateFin - DateDebut;
            ////double jrsw = nbrjw.

            //parametres = parametre.GetInstance(Session);
            //parametres = Parametres;

 

            return NbrJrs;
        }
        public void InsererPeriodesDAS()
        {

            parametres = parametre.GetInstance(Session);
            //parametres = Parametres;


            CalculerNbrAnnee NbrAnnee = new CalculerNbrAnnee();
            CalculerNbrMois NbrMois = new CalculerNbrMois();

            int Dif_Ann = Date_Fin.Year - Date_Debut.Year + 1;
            int i = 0;
            int year = Date_Debut.Year;

            while (i < Dif_Ann)
            {
                if (i == 0)
                {
                    Periodes_DAS PeriodesAInserer = new Periodes_DAS(Session);

                    PeriodesAInserer.DAS = this;
                    PeriodesAInserer.Annee = year;

                    PeriodesAInserer.Debut_Periode = Date_Debut;
                    DateTime datefin = new DateTime(year, 12, 31);
                    PeriodesAInserer.Fin_Periode = datefin;

                    //TimeSpan duree = PeriodesAInserer.Fin_Periode - PeriodesAInserer.Debut_Periode;
                    int nbrmois = NbrMois.CalculNbrMois(PeriodesAInserer.Debut_Periode, PeriodesAInserer.Fin_Periode);
                    PeriodesAInserer.Duree_Travail = nbrmois * parametres.Nbr_jour_tra;

                    if (PeriodesAInserer.Debut_Periode.Date.Day != 1)
                    {
                        int dif = 30 - PeriodesAInserer.Debut_Periode.Day;
                        PeriodesAInserer.Duree_Travail -= dif;
                    }

                    PeriodesAInserer.Qualification = personne.LaFonction;

                    CriteriaOperator criteria1 = CriteriaOperator.Parse("Annee==?", year);
                    CriteriaOperator criteria2 = CriteriaOperator.Parse("personne==?", personne);

                    Recape_Annuelle Recape_Annuelle = this.Session.FindObject<Recape_Annuelle>(CriteriaOperator.And(criteria1, criteria2));
                    if (Recape_Annuelle != null)
                    {
                        PeriodesAInserer.Salaire_Soumis = Recape_Annuelle.Brut_Cotis;
                    }
                    else
                        PeriodesAInserer.Salaire_Soumis = 0;

                    Periodes_DAS.Add(PeriodesAInserer);
                    i += 1;
                    year += 1;
                }
                else
                    if (i == Dif_Ann - 1)
                    {
                        Periodes_DAS PeriodesAInserer = new Periodes_DAS(Session);

                        PeriodesAInserer.DAS = this;
                        PeriodesAInserer.Annee = year;

                        DateTime dateDebut = new DateTime(year, 1, 1);
                        PeriodesAInserer.Debut_Periode = dateDebut;
                        PeriodesAInserer.Fin_Periode = Date_Fin;

                        //TimeSpan dif=Date_Fin-Date_Debut;
                         
                        //TimeSpan duree = PeriodesAInserer.Fin_Periode - PeriodesAInserer.Debut_Periode;
                        //int nbrmois = NbrMois.CalculNbrMois(datedebut, datefin);
                        //PeriodesAInserer.Duree_Travail = (int)dif.TotalDays;
                        //PeriodesAInserer.Duree_Travail=nbr

                        int nbrmois = NbrMois.CalculNbrMois(PeriodesAInserer.Debut_Periode, PeriodesAInserer.Fin_Periode);
                        PeriodesAInserer.Duree_Travail = nbrmois * parametres.Nbr_jour_tra;


                        if (PeriodesAInserer.Fin_Periode.Date.Day != 31 || PeriodesAInserer.Fin_Periode.Day != 30)
                        {
                            int days  = System.DateTime.DaysInMonth(year, PeriodesAInserer.Fin_Periode.Month);

                            if (days == 31)
                            {
                                int dif = 30 - PeriodesAInserer.Fin_Periode.Day - 1;
                                PeriodesAInserer.Duree_Travail -= dif;
                            }
                            else
                            {
                                int dif = 30 - PeriodesAInserer.Fin_Periode.Day;
                                PeriodesAInserer.Duree_Travail -= dif;
                            }
                        }


                        PeriodesAInserer.Qualification = personne.LaFonction;
                        PeriodesAInserer.Designation_Caisse = parametres.Designation_Caisse;

                        CriteriaOperator criteria1 = CriteriaOperator.Parse("Annee==?", year);
                        CriteriaOperator criteria2 = CriteriaOperator.Parse("personne==?", personne);

                        Recape_Annuelle Recape_Annuelle = this.Session.FindObject<Recape_Annuelle>(CriteriaOperator.And(criteria1, criteria2));
                        if (Recape_Annuelle != null)
                        {
                            PeriodesAInserer.Salaire_Soumis = Recape_Annuelle.Brut_Cotis_Janv + Recape_Annuelle.Brut_Cotis_Fev +
                                Recape_Annuelle.Brut_Cotis_Mars + Recape_Annuelle.Brut_Cotis_Avr + Recape_Annuelle.Brut_Cotis_Mai +
                                Recape_Annuelle.Brut_Cotis_Juin + Recape_Annuelle.Brut_Cotis_Juill + Recape_Annuelle.Brut_Cotis_Aout +
                                Recape_Annuelle.Brut_Cotis_Sept + Recape_Annuelle.Brut_Cotis_Oct + Recape_Annuelle.Brut_Cotis_Nouv +
                                Recape_Annuelle.Brut_Cotis_Dec;
                        }
                        else
                            PeriodesAInserer.Salaire_Soumis = 0;

                        Periodes_DAS.Add(PeriodesAInserer);
                        i += 1;
                        year += 1;
                    }
                    else
                    {
                        Periodes_DAS PeriodesAInserer = new Periodes_DAS(Session);

                        PeriodesAInserer.DAS = this;
                        PeriodesAInserer.Annee = year;

                        DateTime datedebut = new DateTime(year, 1, 1);
                        PeriodesAInserer.Debut_Periode = datedebut;
                        DateTime datefin = new DateTime(year, 12, 31);
                        PeriodesAInserer.Fin_Periode = datefin;

                        //TimeSpan duree = PeriodesAInserer.Fin_Periode - PeriodesAInserer.Debut_Periode;
                        int nbrmois = NbrMois.CalculNbrMois(PeriodesAInserer.Debut_Periode , PeriodesAInserer.Fin_Periode);
                        PeriodesAInserer.Duree_Travail = nbrmois * parametres.Nbr_jour_tra;
                        //PeriodesAInserer.Duree_Travail = (int)duree.TotalDays;

                        PeriodesAInserer.Qualification = personne.LaFonction;

                        CriteriaOperator criteria1 = CriteriaOperator.Parse("Annee==?", year);
                        CriteriaOperator criteria2 = CriteriaOperator.Parse("personne==?", personne);

                        Recape_Annuelle Recape_Annuelle = this.Session.FindObject<Recape_Annuelle>(CriteriaOperator.And(criteria1, criteria2));
                        if (Recape_Annuelle != null)
                        {
                            PeriodesAInserer.Salaire_Soumis = Recape_Annuelle.Brut_Cotis_Janv + Recape_Annuelle.Brut_Cotis_Fev +
                                Recape_Annuelle.Brut_Cotis_Mars + Recape_Annuelle.Brut_Cotis_Avr + Recape_Annuelle.Brut_Cotis_Mai +
                                Recape_Annuelle.Brut_Cotis_Juin + Recape_Annuelle.Brut_Cotis_Juill + Recape_Annuelle.Brut_Cotis_Aout +
                                Recape_Annuelle.Brut_Cotis_Sept + Recape_Annuelle.Brut_Cotis_Oct + Recape_Annuelle.Brut_Cotis_Nouv +
                                Recape_Annuelle.Brut_Cotis_Dec;
                        }
                        else
                            PeriodesAInserer.Salaire_Soumis = 0;

                        Periodes_DAS.Add(PeriodesAInserer);
                        i += 1;
                        year += 1;
                    }
            }


            Session.CommitTransaction();
        }
    }
}