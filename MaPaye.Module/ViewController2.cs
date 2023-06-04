using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo; 
using System.Data.SqlClient; 
using System.Data;
using System.Reflection;
using DevExpress.XtraReports.Design.Commands;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Reports;
using MaPayeAdmin.Module;
using DevExpress.Persistent.BaseImpl;
using System.Data.Common;
using MaPayeAdmin;
using System.Data.SQLite;
using Microsoft.SqlServer.Management.Smo;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraReports.UI;

namespace MaPaye.Module
{
    public partial class ViewController2 : ViewController
    {
        public ViewController2()
        {
            InitializeComponent();
            RegisterActions(components);
        }
         
        public void RestaurerBanques(Session SessionDs, Session SessionSc)
        {

            XPCollection<Banque> BanqueSc = new XPCollection<Banque>(SessionSc);
            XPCollection<Banque> BanqueDs = new XPCollection<Banque>(SessionDs);

            if (BanqueDs.Count != 0)
            {
                SessionDs.Delete(BanqueDs);
                SessionDs.Save(BanqueDs);
            }

            foreach (Banque banqueSc in BanqueSc)
            {
                Banque banqueDs = new Banque(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Banque).GetProperties())
                {
                    banqueDs.SetMemberValue(PropertyDs.Name, banqueSc.GetMemberValue(PropertyDs.Name));
                }
                banqueDs.Save();
            }
        }

        public void RestaurerParametres(Session SessionDs, Session SessionSc)
        {

            parametre ParametresSc = SessionSc.FindObject<parametre>(null);
            parametre ParametresDs = SessionDs.FindObject<parametre>(null);

            foreach (PropertyInfo PropertyDs in typeof(parametre).GetProperties())
            {
                if (PropertyDs.Name == "banqu")
                {
                    if (ParametresSc.banqu != null)
                    {
                        //CriteriaOperator criteria1 = CriteriaOperator.Parse("des_a==?", ParametresSc.banqu.des_a);
                        CriteriaOperator criteria2 = CriteriaOperator.Parse("des_f==?", ParametresSc.banqu.des_f);
                        Banque banque = SessionDs.FindObject<Banque>(CriteriaOperator.And( criteria2)); 
                        if (banque != null)
                            ParametresDs.banqu = banque;
                    }
                }
                //else
                //    if (PropertyDs.Name == "Secteur_Organisme")
                //    {
                //        if (ParametresSc.Secteur_Organisme != null)
                //        {
                //            //CriteriaOperator criteria1 = CriteriaOperator.Parse("Secteur_Org_Lib_Ara==?", ParametresSc.Secteur_Organisme.Secteur_Org_Lib_Ara);
                //            CriteriaOperator criteria2 = CriteriaOperator.Parse("Secteur_Org_Lib_Fr==?", ParametresSc.Secteur_Organisme.Secteur_Org_Lib_Fr);
                //            Secteur_Organisme secteur_Organisme = SessionDs.FindObject<Secteur_Organisme>(CriteriaOperator.And(criteria2));
                //            if (secteur_Organisme != null)
                //                ParametresDs.Secteur_Organisme = secteur_Organisme;
                //        }
                //    }
                    else
                        if (PropertyDs.Name == "Type_Abcense")
                        {
                            if (ParametresSc.Type_Abcense != null)
                            {
                                //CriteriaOperator criteria1 = CriteriaOperator.Parse("Type_Abs_Lib_Ara==?", ParametresSc.Type_Abcense.Type_Abs_Lib_Ara);
                                CriteriaOperator criteria2 = CriteriaOperator.Parse("Type_Abs_Lib_Fr==?", ParametresSc.Type_Abcense.Type_Abs_Lib_Fr);
                                Type_Absence type_Abcense = SessionDs.FindObject<Type_Absence>(CriteriaOperator.And( criteria2));
                                if (type_Abcense != null)
                                    ParametresDs.Type_Abcense = type_Abcense;
                            }
                        }
                        else
                    ParametresDs.SetMemberValue(PropertyDs.Name, ParametresSc.GetMemberValue(PropertyDs.Name));
            }
            ParametresDs.Save();
        }

        public void RestaurerServices(Session SessionDs, Session SessionSc)
        {
            XPCollection<Service> ServiceSc = new XPCollection<Service>(SessionSc);
            XPCollection<Service> ServiceDs = new XPCollection<Service>(SessionDs);

            if (ServiceDs.Count != 0)
            {
                SessionDs.Delete(ServiceDs);
                SessionDs.Save(ServiceDs);
            }

            foreach (Service serviceSc in ServiceSc)
            {
                Service serviceDs = new Service(SessionDs);

                foreach (PropertyInfo PropertyDs in typeof(Service).GetProperties())
                {
                    serviceDs.SetMemberValue(PropertyDs.Name, serviceSc.GetMemberValue(PropertyDs.Name));

                }
                serviceDs.Save();
            }
        }
 
        public void RestaurerUnites(Session SessionDs, Session SessionSc)
        {

            XPCollection<Unite> UniteSc = new XPCollection<Unite>(SessionSc);
            XPCollection<Unite> UniteDs = new XPCollection<Unite>(SessionDs);

            if (UniteDs.Count != 0)
            {
                SessionDs.Delete(UniteDs);
                SessionDs.Save(UniteDs);
            }

            foreach (Unite uniteSc in UniteSc)
            {
                Unite uniteDs = new Unite(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Unite).GetProperties())
                {
                    uniteDs.SetMemberValue(PropertyDs.Name, uniteSc.GetMemberValue(PropertyDs.Name));

                }
                uniteDs.Save();
            }
        }

        public void RestaurerCorps(Session SessionDs, Session SessionSc)
        {

            XPCollection<Corps> CorpsSc = new XPCollection<Corps>(SessionSc);
            XPCollection<Corps> CorpsDs = new XPCollection<Corps>(SessionDs);

            if (CorpsDs.Count != 0)
            {
                SessionDs.Delete(CorpsDs);
                SessionDs.Save(CorpsDs);
            }

            foreach (Corps corpsSc in CorpsSc)
            {
                Corps corpsDs = new Corps(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Corps).GetProperties())
                {
                    corpsDs.SetMemberValue(PropertyDs.Name, corpsSc.GetMemberValue(PropertyDs.Name));

                }
                corpsDs.Save();
            }
        }

        public void RestaurerBaremes(Session SessionDs, Session SessionSc)
        {

            XPCollection<Bareme> BaremeSc = new XPCollection<Bareme>(SessionSc);
            XPCollection<Bareme> BaremeDs = new XPCollection<Bareme>(SessionDs);

            if (BaremeDs.Count != 0)
            {
                SessionDs.Delete(BaremeDs);
                SessionDs.Save(BaremeDs);
            }

            foreach (Bareme baremeSc in BaremeSc)
            {
                Bareme baremeDs = new Bareme(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Bareme).GetProperties())
                {
                    baremeDs.SetMemberValue(PropertyDs.Name, baremeSc.GetMemberValue(PropertyDs.Name));

                }
                baremeDs.Save();
            }
        }

        public void RestaurerSitEmp(Session SessionDs, Session SessionSc)
        {
            XPCollection<Situation_Employe> Situation_EmployeSc = new XPCollection<Situation_Employe>(SessionSc);
            XPCollection<Situation_Employe> Situation_EmployeDs = new XPCollection<Situation_Employe>(SessionDs);

            if (Situation_EmployeDs.Count != 0)
            {
                SessionDs.Delete(Situation_EmployeDs);
                SessionDs.Save(Situation_EmployeDs);
            }

            foreach (Situation_Employe situation_EmployeSc in Situation_EmployeSc)
            {
                Situation_Employe situation_EmployeDs = new Situation_Employe(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Situation_Employe).GetProperties())
                {
                    situation_EmployeDs.SetMemberValue(PropertyDs.Name, situation_EmployeSc.GetMemberValue(PropertyDs.Name));

                }
                situation_EmployeDs.Save();
            }

        }

        public void RestaurerSitFam(Session SessionDs, Session SessionSc)
        {

            XPCollection<Situation_Familiale> Situation_FamilialeSc = new XPCollection<Situation_Familiale>(SessionSc);
            XPCollection<Situation_Familiale> Situation_FamilialeDs = new XPCollection<Situation_Familiale>(SessionDs);

            if (Situation_FamilialeDs.Count != 0)
            {
                SessionDs.Delete(Situation_FamilialeDs);
                SessionDs.Save(Situation_FamilialeDs);
            }

            foreach (Situation_Familiale situation_FamilialeSc in Situation_FamilialeSc)
            {
                Situation_Familiale situation_FamilialeDs = new Situation_Familiale(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Situation_Familiale).GetProperties())
                {
                    situation_FamilialeDs.SetMemberValue(PropertyDs.Name, situation_FamilialeSc.GetMemberValue(PropertyDs.Name));

                }
                situation_FamilialeDs.Save();
            }

        }

        public void RestaurerSitConj(Session SessionDs, Session SessionSc)
        {

            XPCollection<Situation_Conjoint> Situation_ConjointSc = new XPCollection<Situation_Conjoint>(SessionSc);
            XPCollection<Situation_Conjoint> Situation_ConjointDs = new XPCollection<Situation_Conjoint>(SessionDs);

            if (Situation_ConjointDs.Count != 0)
            {
                SessionDs.Delete(Situation_ConjointDs);
                SessionDs.Save(Situation_ConjointDs);
            }

            foreach (Situation_Conjoint situation_ConjointSc in Situation_ConjointSc)
            {
                Situation_Conjoint situation_ConjointDs = new Situation_Conjoint(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Situation_Conjoint).GetProperties())
                {
                    situation_ConjointDs.SetMemberValue(PropertyDs.Name, situation_ConjointSc.GetMemberValue(PropertyDs.Name));

                }
                situation_ConjointDs.Save();
            }
        }

        public void RestaurerRaisSort(Session SessionDs, Session SessionSc)
        {
            XPCollection<Raison_Sortie> Raison_SortieSc = new XPCollection<Raison_Sortie>(SessionSc);
            XPCollection<Raison_Sortie> Raison_SortieDs = new XPCollection<Raison_Sortie>(SessionDs);

            if (Raison_SortieDs.Count != 0)
            {
                SessionDs.Delete(Raison_SortieDs);
                SessionDs.Save(Raison_SortieDs);
            }

            foreach (Raison_Sortie raison_SortieSc in Raison_SortieSc)
            {
                Raison_Sortie raison_SortieDs = new Raison_Sortie(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Raison_Sortie).GetProperties())
                {
                    raison_SortieDs.SetMemberValue(PropertyDs.Name, raison_SortieSc.GetMemberValue(PropertyDs.Name));

                }
                raison_SortieDs.Save();
            }

        }

        public void RestaurerIndems(Session SessionDs, Session SessionSc)
        {

            XPCollection<Indem> IndemSc = new XPCollection<Indem>(SessionSc);
            XPCollection<Indem> IndemDs = new XPCollection<Indem>(SessionDs);

            if (IndemDs.Count != 0)
            {
                SessionDs.Delete(IndemDs);
                SessionDs.Save(IndemDs);
            }

            foreach (Indem indemSc in IndemSc)
            {
                Indem indemDs = new Indem(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Indem).GetProperties())
                {

                    if (PropertyDs.Name == "parametres")
                    {

                        parametre parametres = SessionDs.FindObject<parametre>(null);
                        indemDs.parametres = parametres;
                    }
                    else
                        indemDs.SetMemberValue(PropertyDs.Name, indemSc.GetMemberValue(PropertyDs.Name));
                }
                indemDs.Save();
            }
        }

        public void RestaurerFonction(Session SessionDs, Session SessionSc)
        {
            XPCollection<Fonction> FonctionSc = new XPCollection<Fonction>(SessionSc);
            XPCollection<Fonction> FonctionDs = new XPCollection<Fonction>(SessionDs);

            if (FonctionDs.Count != 0)
            {
                SessionDs.Delete(FonctionDs);
                SessionDs.Save(FonctionDs);
            }

            foreach (Fonction fonctionSc in FonctionSc)
            {
                Fonction fonctionDs = new Fonction(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Fonction).GetProperties())
                {
                    if (PropertyDs.Name == "Categorie")
                    {
                        if (fonctionSc.Categorie != null)
                        {
                            Bareme categorie = SessionDs.FindObject<Bareme>(CriteriaOperator.Parse("CATEG==?", fonctionSc.Categorie.CATEG));
                            if (categorie != null)
                                fonctionDs.Categorie = categorie;
                        }
                    }
                    //else
                    //    if (PropertyDs.Name == "Corps")
                    //    {
                    //        if (fonctionSc.Corps != null)
                    //        {
                    //            Corps corps = SessionDs.FindObject<Corps>(CriteriaOperator.Parse("DesCorps==?", fonctionSc.Corps.DesCorps));
                    //            fonctionDs.Corps = corps;
                    //        }
                    //    }
                        //else
                        //    if (PropertyDs.Name == "Secteur_Organisme")
                        //    {
                        //        if (fonctionSc.Secteur_Organisme != null)
                        //        {
                        //            Secteur_Organisme secteur_Organisme = SessionDs.FindObject<Secteur_Organisme>(CriteriaOperator.Parse("Secteur_Org_Lib_Fr==?", fonctionSc.Secteur_Organisme.Secteur_Org_Lib_Fr));
                        //            fonctionDs.Secteur_Organisme = secteur_Organisme;
                        //        }
                        //    }
                            //else
                            //    if (PropertyDs.Name == "parametres")
                            //    {

                            //        parametre parametres = SessionDs.FindObject<parametre>(null);
                            //        fonctionDs.parametres = parametres;
                            //    }
                                else
                                    fonctionDs.SetMemberValue(PropertyDs.Name, fonctionSc.GetMemberValue(PropertyDs.Name));

                }
                fonctionDs.Save();
            }
        }

        public void RestaurerIndemFonct(Session SessionDs, Session SessionSc)
        {

            XPCollection<Indem_Fonction> Indem_FonctionSc = new XPCollection<Indem_Fonction>(SessionSc);
            XPCollection<Indem_Fonction> Indem_FonctionDs = new XPCollection<Indem_Fonction>(SessionDs);

            if (Indem_FonctionDs.Count != 0)
            {
                SessionDs.Delete(Indem_FonctionDs);
                SessionDs.Save(Indem_FonctionDs);
            }

            foreach (Indem_Fonction indem_FonctionSc in Indem_FonctionSc)
            {
                Indem_Fonction indem_FonctionDs = new Indem_Fonction(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Indem_Fonction).GetProperties())
                {
                    if (PropertyDs.Name == "Indem")
                    {
                        CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_indem_interne==?", indem_FonctionSc.Indem.Cod_indem_interne);
                        CriteriaOperator criteria2 = CriteriaOperator.Parse("Cod_indem==?", indem_FonctionSc.Indem.Cod_indem);
                        Indem indem = SessionDs.FindObject<Indem>(CriteriaOperator.And(criteria1, criteria2));
                        if (indem != null)
                            indem_FonctionDs.Indem = indem;
                    }
                    else
                        if (PropertyDs.Name == "Fonction")
                        {
                            CriteriaOperator criteria1 = CriteriaOperator.Parse("Fct_Lib_Fr==?", indem_FonctionSc.Fonction.Fct_Lib_Fr);
                            //CriteriaOperator criteria2 = CriteriaOperator.Parse("Fct_Lib_Ar==?", indem_FonctionSc.Fonction.Fct_Lib_Ar);
                            //CriteriaOperator criteria3 = CriteriaOperator.Parse("Categorie==?", indem_FonctionSc.Fonction.Categorie.CATEG);
                            Fonction fonction = SessionDs.FindObject<Fonction>(CriteriaOperator.And(criteria1));
                            if (fonction != null)
                                indem_FonctionDs.Fonction = fonction;
                        }
                        else
                            indem_FonctionDs.SetMemberValue(PropertyDs.Name, indem_FonctionSc.GetMemberValue(PropertyDs.Name));

                }
                indem_FonctionDs.Save();
            }
        } 

        public void RestaurerEmploye(Session SessionDs, Session SessionSc)
        { 
            XPCollection<Personne> EmployeSc = new XPCollection<Personne>(SessionSc);
            XPCollection<Personne> EmployeDs = new XPCollection<Personne>(SessionDs);

            if (EmployeDs.Count != 0)
            {
                SessionDs.Delete(EmployeDs);
                SessionDs.Save(EmployeDs);
            }

            foreach (Personne employeSc in EmployeSc)
            {
                Personne employeDs = new Personne(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Personne).GetProperties())
                {
                    switch (PropertyDs.Name)
                    {
                        case "LeSrevice":
                            {
                                if (employeSc.LeSrevice != null)
                                {
                                    //CriteriaOperator criteria1 = CriteriaOperator.Parse("Service_Lib_Ar==?", employeSc.LeSrevice.Service_Lib_Ar);
                                    CriteriaOperator criteria2 = CriteriaOperator.Parse("Service_Lib_Fr==?", employeSc.LeSrevice.Service_Lib_Fr);
                                    Service service = SessionDs.FindObject<Service>(CriteriaOperator.And( criteria2));
                                    if (service != null)
                                        employeDs.LeSrevice = service;
                                }
                            }
                            break;
                        case "unite":
                            {
                                if (employeSc.unite != null)
                                {
                                    //CriteriaOperator criteria1 = CriteriaOperator.Parse("Des_ar==?", employeSc.unite.Des_ar);
                                    CriteriaOperator criteria2 = CriteriaOperator.Parse("Des_fr==?", employeSc.unite.Des_fr);
                                    Unite unite = SessionDs.FindObject<Unite>(CriteriaOperator.And( criteria2));
                                    if (unite != null)
                                        employeDs.unite = unite;
                                }
                            }
                            break;
                        case "LaFonction":
                            {
                                if (employeSc.LaFonction != null)
                                {
                                    //CriteriaOperator criteria1 = CriteriaOperator.Parse("Fct_Lib_Ar==?", employeSc.LaFonction.Fct_Lib_Ar);
                                    CriteriaOperator criteria2 = CriteriaOperator.Parse("Fct_Lib_Fr==?", employeSc.LaFonction.Fct_Lib_Fr);
                                    Fonction fonction = SessionDs.FindObject<Fonction>(CriteriaOperator.And( criteria2));
                                    if (fonction != null)
                                        employeDs.LaFonction = fonction;
                                }
                            }
                            break;
                        case "Fonction_Stagière":
                            {
                                if (employeSc.Fonction_Stagière != null)
                                {
                                    //CriteriaOperator criteria1 = CriteriaOperator.Parse("Fct_Lib_Ar==?", employeSc.Fonction_Stagière.Fct_Lib_Ar);
                                    CriteriaOperator criteria2 = CriteriaOperator.Parse("Fct_Lib_Fr==?", employeSc.Fonction_Stagière.Fct_Lib_Fr);
                                    Fonction fonctionStagiere = SessionDs.FindObject<Fonction>(CriteriaOperator.And( criteria2));
                                    if (fonctionStagiere != null)
                                        employeDs.Fonction_Stagière = fonctionStagiere;
                                }
                            }
                            break;
                        case "Corps":
                            {
                                if (employeSc.Corps != null)
                                {
                                    CriteriaOperator criteria1 = CriteriaOperator.Parse("DesCorps==?", employeSc.Corps.DesCorps);
                                    //CriteriaOperator criteria2 = CriteriaOperator.Parse("DesCorpsAr==?", employeSc.Corps.DesCorpsAr);
                                    Corps corps = SessionDs.FindObject<Corps>(CriteriaOperator.And(criteria1));
                                    if (corps != null)
                                        employeDs.Corps = corps;
                                }
                            }
                            break;
                        //case "Categ_IEP":
                        //    {
                        //        if (employeSc.Categ_IEP != null)
                        //        {
                        //            CriteriaOperator criteria1 = CriteriaOperator.Parse("CATEG==?", employeSc.Categ_IEP.CATEG); 
                        //            Bareme2008 categ_IEP = SessionDs.FindObject<Bareme2008>(CriteriaOperator.And(criteria1));
                        //            if (categ_IEP != null)
                        //                employeDs.Categ_IEP = categ_IEP;
                        //        }
                        //    }
                        //    break;
                        //case "Categ_IEP_Bareme":
                        //    {
                        //        if (employeSc.Categ_IEP_Bareme != null)
                        //        {
                        //            CriteriaOperator criteria1 = CriteriaOperator.Parse("CATEG==?", employeSc.Categ_IEP_Bareme.CATEG);
                        //            Bareme categ_IEP_Bareme = SessionDs.FindObject<Bareme>(CriteriaOperator.And(criteria1));
                        //            if (categ_IEP_Bareme != null)
                        //                employeDs.Categ_IEP_Bareme = categ_IEP_Bareme;
                        //        }
                        //    }
                        //    break;
                        //case "Categ08":
                        //    {
                        //        if (employeSc.Categ08 != null)
                        //        {
                        //            CriteriaOperator criteria1 = CriteriaOperator.Parse("CATEG==?", employeSc.Categ08.CATEG);
                        //            Bareme2008 categ08 = SessionDs.FindObject<Bareme2008>(CriteriaOperator.And(criteria1));
                        //            if (categ08 != null)
                        //                employeDs.Categ08 = categ08;
                        //        }
                        //    }
                        //    break;
                        //case "Categ01":
                        //    {
                        //        if (employeSc.Categ01 != null)
                        //        {
                        //            CriteriaOperator criteria1 = CriteriaOperator.Parse("CATEG==?", employeSc.Categ01.CATEG);
                        //            Bareme2001 categ01 = SessionDs.FindObject<Bareme2001>(CriteriaOperator.And(criteria1));
                        //            if (categ01 != null)
                        //                employeDs.Categ01 = categ01;
                        //        }
                        //    }
                        //    break;
                        case "Categori":
                            {
                                if (employeSc.Categori != null)
                                {
                                    CriteriaOperator criteria1 = CriteriaOperator.Parse("CATEG==?", employeSc.Categori.CATEG);
                                    Bareme categori = SessionDs.FindObject<Bareme>(CriteriaOperator.And(criteria1));
                                    if (categori != null)
                                        employeDs.Categori = categori;
                                }
                            }
                            break;
                        case "Sit_fam":
                            {
                                if (employeSc.Sit_fam != null)
                                {
                                    //CriteriaOperator criteria1 = CriteriaOperator.Parse("Sit_Fam_Lib_Ara==?", employeSc.Sit_fam.Sit_Fam_Lib_Ara);
                                    CriteriaOperator criteria2 = CriteriaOperator.Parse("Sit_Fam_Lib_Fr==?", employeSc.Sit_fam.Sit_Fam_Lib_Fr);
                                    Situation_Familiale sit_fam = SessionDs.FindObject<Situation_Familiale>(CriteriaOperator.And(criteria2));
                                    if (sit_fam != null)
                                        employeDs.Sit_fam = sit_fam;
                                }
                            }
                            break;
                        case "Sit_Conjoint":
                            {
                                if (employeSc.Sit_Conjoint != null)
                                {
                                    //CriteriaOperator criteria1 = CriteriaOperator.Parse("Sit_Conj_Lib_Ara==?", employeSc.Sit_Conjoint.Sit_Conj_Lib_Ara);
                                    CriteriaOperator criteria2 = CriteriaOperator.Parse("Sit_Conj_Lib_Fr==?", employeSc.Sit_Conjoint.Sit_Conj_Lib_Fr);
                                    Situation_Conjoint sit_Conjoint = SessionDs.FindObject<Situation_Conjoint>(CriteriaOperator.And( criteria2));
                                    if (sit_Conjoint != null)
                                        employeDs.Sit_Conjoint = sit_Conjoint;
                                }
                            }
                            break;
                        case "Sit_Emp":
                            {
                                if (employeSc.Sit_Emp != null)
                                {
                                    //CriteriaOperator criteria1 = CriteriaOperator.Parse("Sit_Emp_Lib_Ar==?", employeSc.Sit_Emp.Sit_Emp_Lib_Ar);
                                    CriteriaOperator criteria2 = CriteriaOperator.Parse("Sit_Emp_Lib_Fr==?", employeSc.Sit_Emp.Sit_Emp_Lib_Fr);
                                    Situation_Employe sit_Emp = SessionDs.FindObject<Situation_Employe>(CriteriaOperator.And( criteria2));
                                    if (sit_Emp != null)
                                        employeDs.Sit_Emp = sit_Emp;
                                }
                            }
                            break;
                        case "Raison_Sortie":
                            {
                                if (employeSc.Raison_Sortie != null)
                                {
                                    //CriteriaOperator criteria1 = CriteriaOperator.Parse("Raison_Sortie_Ara==?", employeSc.Raison_Sortie.Raison_Sortie_Ara);
                                    CriteriaOperator criteria2 = CriteriaOperator.Parse("Raison_Sortie_Fr==?", employeSc.Raison_Sortie.Raison_Sortie_Fr);
                                    Raison_Sortie raison_Sortie = SessionDs.FindObject<Raison_Sortie>(CriteriaOperator.And( criteria2));
                                    if (raison_Sortie != null)
                                        employeDs.Raison_Sortie = raison_Sortie;
                                }
                            }
                            break;
                        case "sexe":
                            {
                                if (employeSc.sexe != null)
                                {
                                    //CriteriaOperator criteria1 = CriteriaOperator.Parse("Sexe_Lib_Ar==?", employeSc.sexe.Sexe_Lib_Ar);
                                    CriteriaOperator criteria2 = CriteriaOperator.Parse("Sexe_Lib_Fr==?", employeSc.sexe.Sexe_Lib_Fr);
                                    Sexe sexe = SessionDs.FindObject<Sexe>(CriteriaOperator.And(criteria2));
                                    if (sexe != null)
                                        employeDs.sexe = sexe;
                                }
                            }
                            break;
                        case "Banque":
                            {
                                if (employeSc.Banque != null)
                                {
                                    //CriteriaOperator criteria1 = CriteriaOperator.Parse("des_a==?", employeSc.Banque.des_a);
                                    CriteriaOperator criteria2 = CriteriaOperator.Parse("des_f==?", employeSc.Banque.des_f);
                                    Banque banque = SessionDs.FindObject<Banque>(CriteriaOperator.And( criteria2));
                                    if (banque != null)
                                        employeDs.Banque = banque;
                                }
                            }
                            break;
                        case "Mode_Paiement":
                            {
                                if (employeSc.Mode_Paiement != null)
                                {
                                    //CriteriaOperator criteria1 = CriteriaOperator.Parse("Type_Paiment_Lib_Ara==?", employeSc.Mode_Paiement.Type_Paiment_Lib_Ara);
                                    CriteriaOperator criteria2 = CriteriaOperator.Parse("Type_Paiment_Lib_Fr==?", employeSc.Mode_Paiement.Type_Paiment_Lib_Fr);
                                    Mode_Paiement mode_Paiement = SessionDs.FindObject<Mode_Paiement>(CriteriaOperator.And( criteria2));
                                    if (mode_Paiement != null)
                                        employeDs.Mode_Paiement = mode_Paiement;
                                }
                            }
                            break;
                        case "TypeContrat":
                            {
                                if (employeSc.TypeContrat != null)
                                {
                                    //CriteriaOperator criteria1 = CriteriaOperator.Parse("Type_Contrat_Ar==?", employeSc.TypeContrat.Type_Contrat_Ar);
                                    CriteriaOperator criteria2 = CriteriaOperator.Parse("Type_Contrat_Fr==?", employeSc.TypeContrat.Type_Contrat_Fr);
                                    TypeContrat typeContrat = SessionDs.FindObject<TypeContrat>(CriteriaOperator.And( criteria2));
                                    if (typeContrat != null)
                                        employeDs.TypeContrat = typeContrat;
                                }
                            }
                            break;
                        case "parametres":
                            { 
                                parametre parametres = SessionDs.FindObject<parametre>(null);
                                employeDs.parametres = parametres;
                            }
                            break;
                        default:
                            employeDs.SetMemberValue(PropertyDs.Name, employeSc.GetMemberValue(PropertyDs.Name));
                            break;
                    }
                    

                }
                employeDs.Save();
            }

        }

        public void RestaurerIndemPersonne(Session SessionDs, Session SessionSc)
        {

            XPCollection<Indem_Personne> Indem_PersonneSc = new XPCollection<Indem_Personne>(SessionSc);
            XPCollection<Indem_Personne> Indem_PersonneDs = new XPCollection<Indem_Personne>(SessionDs);

            if (Indem_PersonneDs.Count != 0)
            {
                SessionDs.Delete(Indem_PersonneDs);
                SessionDs.Save(Indem_PersonneDs);
            }

            foreach (Indem_Personne indem_PersonneSc in Indem_PersonneSc)
            {
                Indem_Personne indem_PersonneDs = new Indem_Personne(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Indem_Personne).GetProperties())
                {
                    if (PropertyDs.Name == "Personne")
                    {
                        CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_personne==?", indem_PersonneSc.Personne.Cod_personne);
                        CriteriaOperator criteria2 = CriteriaOperator.Parse("FullName==?", indem_PersonneSc.Personne.FullName);
                        Personne personne = SessionDs.FindObject<Personne>(CriteriaOperator.And(criteria1, criteria2));
                        if (personne != null)
                            indem_PersonneDs.Personne = personne;
                    }
                    else
                        if (PropertyDs.Name == "Indem")
                        {
                            CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_indem_interne==?", indem_PersonneSc.Indem.Cod_indem_interne);
                            CriteriaOperator criteria2 = CriteriaOperator.Parse("Cod_indem==?", indem_PersonneSc.Indem.Cod_indem);
                            Indem indem = SessionDs.FindObject<Indem>(CriteriaOperator.And(criteria1, criteria2));
                            if (indem != null)
                                indem_PersonneDs.Indem = indem;
                        }
                        else
                            indem_PersonneDs.SetMemberValue(PropertyDs.Name, indem_PersonneSc.GetMemberValue(PropertyDs.Name));

                }
                indem_PersonneDs.Save();
            }
        } 

        public void RestaurerPiecesJointes(Session SessionDs, Session SessionSc)
        {

            XPCollection<PortfolioFileData> PortfolioFileDataSc = new XPCollection<PortfolioFileData>(SessionSc);
            XPCollection<PortfolioFileData> PortfolioFileDataDs = new XPCollection<PortfolioFileData>(SessionDs);

            if (PortfolioFileDataDs.Count != 0)
            {
                SessionDs.Delete(PortfolioFileDataDs);
                SessionDs.Save(PortfolioFileDataDs);
            }

            foreach (PortfolioFileData portfolioFileDataSc in PortfolioFileDataSc)
            {
                PortfolioFileData portfolioFileDataDs = new PortfolioFileData(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(PortfolioFileData).GetProperties())
                {
                    if (PropertyDs.Name == "Personne")
                    {
                        CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_personne==?", portfolioFileDataSc.Personne.Cod_personne);
                        CriteriaOperator criteria2 = CriteriaOperator.Parse("FullName==?", portfolioFileDataSc.Personne.FullName);
                        Personne personne = SessionDs.FindObject<Personne>(CriteriaOperator.And(criteria1, criteria2));
                        if (personne != null)
                            portfolioFileDataDs.Personne = personne;
                    }
                    else 
                            portfolioFileDataDs.SetMemberValue(PropertyDs.Name, portfolioFileDataSc.GetMemberValue(PropertyDs.Name));

                }
                portfolioFileDataDs.Save();
            }

        }

        public void RestaurerRecappeAnnuelle(Session SessionDs, Session SessionSc)
        {
            XPCollection<Recape_Annuelle> Recape_AnnuelleSc = new XPCollection<Recape_Annuelle>(SessionSc);
            XPCollection<Recape_Annuelle> Recape_AnnuelleDs = new XPCollection<Recape_Annuelle>(SessionDs);

            if (Recape_AnnuelleDs.Count != 0)
            {
                SessionDs.Delete(Recape_AnnuelleDs);
                SessionDs.Save(Recape_AnnuelleDs);
            }

            foreach (Recape_Annuelle recape_AnnuelleSc in Recape_AnnuelleSc)
            {
                Recape_Annuelle recape_AnnuelleDs = new Recape_Annuelle(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Recape_Annuelle).GetProperties())
                {
                    if (PropertyDs.Name == "personne")
                    {
                        if (recape_AnnuelleSc.personne != null)
                        {
                            CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_personne==?", recape_AnnuelleSc.personne.Cod_personne);
                            CriteriaOperator criteria2 = CriteriaOperator.Parse("FullName==?", recape_AnnuelleSc.personne.FullName);
                            Personne personne = SessionDs.FindObject<Personne>(CriteriaOperator.And(criteria1, criteria2));
                            if (personne != null)
                                recape_AnnuelleDs.personne = personne;
                        }
                    }
                    else
                        if (PropertyDs.Name == "parametres")
                        {

                            parametre parametres = SessionDs.FindObject<parametre>(null);
                            recape_AnnuelleDs.parametres = parametres;
                        }
                        else
                            recape_AnnuelleDs.SetMemberValue(PropertyDs.Name, recape_AnnuelleSc.GetMemberValue(PropertyDs.Name));
                }
                recape_AnnuelleDs.Save();
            }
        }

        public void RestaurerRecappeJanv(Session SessionDs, Session SessionSc)
        {
            XPCollection<Recapes_Janv> Recapes_JanvSc = new XPCollection<Recapes_Janv>(SessionSc);
            XPCollection<Recapes_Janv> Recapes_JanvDs = new XPCollection<Recapes_Janv>(SessionDs);

            if (Recapes_JanvDs.Count != 0)
            {
                SessionDs.Delete(Recapes_JanvDs);
                SessionDs.Save(Recapes_JanvDs);
            }

            foreach (Recapes_Janv recapes_JanvSc in Recapes_JanvSc)
            {
                Recapes_Janv recapes_JanvDs = new Recapes_Janv(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Recapes_Janv).GetProperties())
                {
                    if (PropertyDs.Name == "Recape_Annuelle_Janv")
                    {
                        if (recapes_JanvSc.Recape_Annuelle_Janv != null)
                        {
                            CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_Recape==?", recapes_JanvSc.Recape_Annuelle_Janv.Cod_Recape); 
                            Recape_Annuelle recape_Annuelle_Janv = SessionDs.FindObject<Recape_Annuelle>(CriteriaOperator.And(criteria1));
                            if (recape_Annuelle_Janv != null)
                            {
                                recapes_JanvDs.Recape_Annuelle_Janv = recape_Annuelle_Janv;
                                recape_Annuelle_Janv.Save();
                            }
                        }
                    }
                    else
                        if (PropertyDs.Name == "parametres")
                        {

                            parametre parametres = SessionDs.FindObject<parametre>(null);
                            recapes_JanvDs.parametres = parametres;
                        }
                        else
                            recapes_JanvDs.SetMemberValue(PropertyDs.Name, recapes_JanvSc.GetMemberValue(PropertyDs.Name));
                }
                recapes_JanvDs.Save();
            }
        }

        public void RestaurerRecappeFev(Session SessionDs, Session SessionSc)
        {
            XPCollection<Recapes_Fev> Recapes_FevSc = new XPCollection<Recapes_Fev>(SessionSc);
            XPCollection<Recapes_Fev> Recapes_FevDs = new XPCollection<Recapes_Fev>(SessionDs);

            if (Recapes_FevDs.Count != 0)
            {
                SessionDs.Delete(Recapes_FevDs);
                SessionDs.Save(Recapes_FevDs);
            }

            foreach (Recapes_Fev recapes_FevSc in Recapes_FevSc)
            {
                Recapes_Fev recapes_FevDs = new Recapes_Fev(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Recapes_Fev).GetProperties())
                {
                    if (PropertyDs.Name == "Recape_Annuelle_Fev")
                    {
                        if (recapes_FevSc.Recape_Annuelle_Fev != null)
                        {
                            CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_Recape==?", recapes_FevSc.Recape_Annuelle_Fev.Cod_Recape);
                            Recape_Annuelle recape_Annuelle_Fev = SessionDs.FindObject<Recape_Annuelle>(CriteriaOperator.And(criteria1));
                            if (recape_Annuelle_Fev != null)
                            {
                                recapes_FevDs.Recape_Annuelle_Fev = recape_Annuelle_Fev;
                                recape_Annuelle_Fev.Save();
                            }
                        }
                    }
                    else
                        if (PropertyDs.Name == "parametres")
                        {

                            parametre parametres = SessionDs.FindObject<parametre>(null);
                            recapes_FevDs.parametres = parametres;
                        }
                        else
                            recapes_FevDs.SetMemberValue(PropertyDs.Name, recapes_FevSc.GetMemberValue(PropertyDs.Name));
                }
                recapes_FevDs.Save();
            }
        }

        public void RestaurerRecappeMars(Session SessionDs, Session SessionSc)
        {
            XPCollection<Recapes_Mars> Recapes_MarsSc = new XPCollection<Recapes_Mars>(SessionSc);
            XPCollection<Recapes_Mars> Recapes_MarsDs = new XPCollection<Recapes_Mars>(SessionDs);

            if (Recapes_MarsDs.Count != 0)
            {
                SessionDs.Delete(Recapes_MarsDs);
                SessionDs.Save(Recapes_MarsDs);
            }

            foreach (Recapes_Mars recapes_MarsSc in Recapes_MarsSc)
            {
                Recapes_Mars recapes_MarsDs = new Recapes_Mars(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Recapes_Mars).GetProperties())
                {
                    if (PropertyDs.Name == "Recape_Annuelle_Mars")
                    {
                        if (recapes_MarsSc.Recape_Annuelle_Mars != null)
                        {
                            CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_Recape==?", recapes_MarsSc.Recape_Annuelle_Mars.Cod_Recape);
                            Recape_Annuelle recape_Annuelle_Mars = SessionDs.FindObject<Recape_Annuelle>(CriteriaOperator.And(criteria1));
                            if (recape_Annuelle_Mars != null)
                            {
                                recapes_MarsDs.Recape_Annuelle_Mars = recape_Annuelle_Mars;
                                recape_Annuelle_Mars.Save();
                            }
                        }
                    }
                    else
                        if (PropertyDs.Name == "parametres")
                        {

                            parametre parametres = SessionDs.FindObject<parametre>(null);
                            recapes_MarsDs.parametres = parametres;
                        }
                        else
                            recapes_MarsDs.SetMemberValue(PropertyDs.Name, recapes_MarsSc.GetMemberValue(PropertyDs.Name));
                }
                recapes_MarsDs.Save();
            }
        }

        public void RestaurerRecappeAvr(Session SessionDs, Session SessionSc)
        {
            XPCollection<Recapes_Avr> Recapes_AvrSc = new XPCollection<Recapes_Avr>(SessionSc);
            XPCollection<Recapes_Avr> Recapes_AvrDs = new XPCollection<Recapes_Avr>(SessionDs);

            if (Recapes_AvrDs.Count != 0)
            {
                SessionDs.Delete(Recapes_AvrDs);
                SessionDs.Save(Recapes_AvrDs);
            }

            foreach (Recapes_Avr recapes_AvrSc in Recapes_AvrSc)
            {
                Recapes_Avr recapes_AvrDs = new Recapes_Avr(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Recapes_Avr).GetProperties())
                {
                    if (PropertyDs.Name == "Recape_Annuelle_Avr")
                    {
                        if (recapes_AvrSc.Recape_Annuelle_Avr != null)
                        {
                            CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_Recape==?", recapes_AvrSc.Recape_Annuelle_Avr.Cod_Recape);
                            Recape_Annuelle recape_Annuelle_Avr = SessionDs.FindObject<Recape_Annuelle>(CriteriaOperator.And(criteria1));
                            if (recape_Annuelle_Avr != null)
                            {
                                recapes_AvrDs.Recape_Annuelle_Avr = recape_Annuelle_Avr;
                                recape_Annuelle_Avr.Save();
                            }
                        }
                    }
                    else
                        if (PropertyDs.Name == "parametres")
                        {

                            parametre parametres = SessionDs.FindObject<parametre>(null);
                            recapes_AvrDs.parametres = parametres;
                        }
                        else
                            recapes_AvrDs.SetMemberValue(PropertyDs.Name, recapes_AvrSc.GetMemberValue(PropertyDs.Name));
                }
                recapes_AvrDs.Save();
            }
        }

        public void RestaurerRecappeMai(Session SessionDs, Session SessionSc)
        {
            XPCollection<Recapes_Mai> Recapes_MaiSc = new XPCollection<Recapes_Mai>(SessionSc);
            XPCollection<Recapes_Mai> Recapes_MaiDs = new XPCollection<Recapes_Mai>(SessionDs);

            if (Recapes_MaiDs.Count != 0)
            {
                SessionDs.Delete(Recapes_MaiDs);
                SessionDs.Save(Recapes_MaiDs);
            }

            foreach (Recapes_Mai recapes_MaiSc in Recapes_MaiSc)
            {
                Recapes_Mai recapes_MaiDs = new Recapes_Mai(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Recapes_Mai).GetProperties())
                {
                    if (PropertyDs.Name == "Recape_Annuelle_Mai")
                    {
                        if (recapes_MaiSc.Recape_Annuelle_Mai != null)
                        {
                            CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_Recape==?", recapes_MaiSc.Recape_Annuelle_Mai.Cod_Recape);
                            Recape_Annuelle recape_Annuelle_Mai = SessionDs.FindObject<Recape_Annuelle>(CriteriaOperator.And(criteria1));
                            if (recape_Annuelle_Mai != null)
                            {
                                recapes_MaiDs.Recape_Annuelle_Mai = recape_Annuelle_Mai;
                                recape_Annuelle_Mai.Save();
                            }
                        }
                    }
                    else
                        if (PropertyDs.Name == "parametres")
                        {

                            parametre parametres = SessionDs.FindObject<parametre>(null);
                            recapes_MaiDs.parametres = parametres;
                        }
                        else
                            recapes_MaiDs.SetMemberValue(PropertyDs.Name, recapes_MaiSc.GetMemberValue(PropertyDs.Name));
                }
                recapes_MaiDs.Save();
            }
        }

        public void RestaurerRecappeJuin(Session SessionDs, Session SessionSc)
        {
            XPCollection<Recapes_Juin> Recapes_JuinSc = new XPCollection<Recapes_Juin>(SessionSc);
            XPCollection<Recapes_Juin> Recapes_JuinDs = new XPCollection<Recapes_Juin>(SessionDs);

            if (Recapes_JuinDs.Count != 0)
            {
                SessionDs.Delete(Recapes_JuinDs);
                SessionDs.Save(Recapes_JuinDs);
            }

            foreach (Recapes_Juin recapes_JuinSc in Recapes_JuinSc)
            {
                Recapes_Juin recapes_JuinDs = new Recapes_Juin(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Recapes_Juin).GetProperties())
                {
                    if (PropertyDs.Name == "Recape_Annuelle_Juin")
                    {
                        if (recapes_JuinSc.Recape_Annuelle_Juin != null)
                        {
                            CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_Recape==?", recapes_JuinSc.Recape_Annuelle_Juin.Cod_Recape);
                            Recape_Annuelle recape_Annuelle_Janv = SessionDs.FindObject<Recape_Annuelle>(CriteriaOperator.And(criteria1));
                            if (recape_Annuelle_Janv != null)
                            {
                                recapes_JuinDs.Recape_Annuelle_Juin = recape_Annuelle_Janv;
                                recape_Annuelle_Janv.Save();
                            }
                        }
                    }
                    else
                        if (PropertyDs.Name == "parametres")
                        {

                            parametre parametres = SessionDs.FindObject<parametre>(null);
                            recapes_JuinDs.parametres = parametres;
                        }
                        else
                            recapes_JuinDs.SetMemberValue(PropertyDs.Name, recapes_JuinSc.GetMemberValue(PropertyDs.Name));
                }
                recapes_JuinDs.Save();
            }
        }

        public void RestaurerRecappeJuill(Session SessionDs, Session SessionSc)
        {
            XPCollection<Recapes_Juill> Recapes_JuillSc = new XPCollection<Recapes_Juill>(SessionSc);
            XPCollection<Recapes_Juill> Recapes_JuillDs = new XPCollection<Recapes_Juill>(SessionDs);

            if (Recapes_JuillDs.Count != 0)
            {
                SessionDs.Delete(Recapes_JuillDs);
                SessionDs.Save(Recapes_JuillDs);
            }

            foreach (Recapes_Juill recapes_JuillSc in Recapes_JuillSc)
            {
                Recapes_Juill recapes_JuillDs = new Recapes_Juill(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Recapes_Juill).GetProperties())
                {
                    if (PropertyDs.Name == "Recape_Annuelle_Juill")
                    {
                        if (recapes_JuillSc.Recape_Annuelle_Juill != null)
                        {
                            CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_Recape==?", recapes_JuillSc.Recape_Annuelle_Juill.Cod_Recape);
                            Recape_Annuelle recape_Annuelle_Juill = SessionDs.FindObject<Recape_Annuelle>(CriteriaOperator.And(criteria1));
                            if (recape_Annuelle_Juill != null)
                            {
                                recapes_JuillDs.Recape_Annuelle_Juill = recape_Annuelle_Juill;
                                recape_Annuelle_Juill.Save();
                            }
                        }
                    }
                    else
                        if (PropertyDs.Name == "parametres")
                        {

                            parametre parametres = SessionDs.FindObject<parametre>(null);
                            recapes_JuillDs.parametres = parametres;
                        }
                        else
                            recapes_JuillDs.SetMemberValue(PropertyDs.Name, recapes_JuillSc.GetMemberValue(PropertyDs.Name));
                }
                recapes_JuillDs.Save();
            }
        }

        public void RestaurerRecappeAout(Session SessionDs, Session SessionSc)
        {
            XPCollection<Recapes_Aout> Recapes_AoutSc = new XPCollection<Recapes_Aout>(SessionSc);
            XPCollection<Recapes_Aout> Recapes_AoutDs = new XPCollection<Recapes_Aout>(SessionDs);

            if (Recapes_AoutDs.Count != 0)
            {
                SessionDs.Delete(Recapes_AoutDs);
                SessionDs.Save(Recapes_AoutDs);
            }

            foreach (Recapes_Aout recapes_AoutSc in Recapes_AoutSc)
            {
                Recapes_Aout recapes_AoutDs = new Recapes_Aout(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Recapes_Aout).GetProperties())
                {
                    if (PropertyDs.Name == "Recape_Annuelle_Aout")
                    {
                        if (recapes_AoutSc.Recape_Annuelle_Aout != null)
                        {
                            CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_Recape==?", recapes_AoutSc.Recape_Annuelle_Aout.Cod_Recape);
                            Recape_Annuelle recape_Annuelle_Aout = SessionDs.FindObject<Recape_Annuelle>(CriteriaOperator.And(criteria1));
                            if (recape_Annuelle_Aout != null)
                            {
                                recapes_AoutDs.Recape_Annuelle_Aout = recape_Annuelle_Aout;
                                recape_Annuelle_Aout.Save();
                            }
                        }
                    }
                    else
                        if (PropertyDs.Name == "parametres")
                        {

                            parametre parametres = SessionDs.FindObject<parametre>(null);
                            recapes_AoutDs.parametres = parametres;
                        }
                        else
                            recapes_AoutDs.SetMemberValue(PropertyDs.Name, recapes_AoutSc.GetMemberValue(PropertyDs.Name));
                }
                recapes_AoutDs.Save();
            }
        }

        public void RestaurerRecappeSept(Session SessionDs, Session SessionSc)
        {
            XPCollection<Recapes_Sept> Recapes_SeptSc = new XPCollection<Recapes_Sept>(SessionSc);
            XPCollection<Recapes_Sept> Recapes_SeptDs = new XPCollection<Recapes_Sept>(SessionDs);

            if (Recapes_SeptDs.Count != 0)
            {
                SessionDs.Delete(Recapes_SeptDs);
                SessionDs.Save(Recapes_SeptDs);
            }

            foreach (Recapes_Sept recapes_SeptSc in Recapes_SeptSc)
            {
                Recapes_Sept recapes_SeptDs = new Recapes_Sept(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Recapes_Sept).GetProperties())
                {
                    if (PropertyDs.Name == "Recape_Annuelle_Sept")
                    {
                        if (recapes_SeptSc.Recape_Annuelle_Sept != null)
                        {
                            CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_Recape==?", recapes_SeptSc.Recape_Annuelle_Sept.Cod_Recape);
                            Recape_Annuelle recape_Annuelle_Sept = SessionDs.FindObject<Recape_Annuelle>(CriteriaOperator.And(criteria1));
                            if (recape_Annuelle_Sept != null)
                            {
                                recapes_SeptDs.Recape_Annuelle_Sept = recape_Annuelle_Sept;
                                recape_Annuelle_Sept.Save();
                            }
                        }
                    }
                    else
                        if (PropertyDs.Name == "parametres")
                        {

                            parametre parametres = SessionDs.FindObject<parametre>(null);
                            recapes_SeptDs.parametres = parametres;
                        }
                        else
                            recapes_SeptDs.SetMemberValue(PropertyDs.Name, recapes_SeptSc.GetMemberValue(PropertyDs.Name));
                }
                recapes_SeptDs.Save();
            }
        }

        public void RestaurerRecappeOct(Session SessionDs, Session SessionSc)
        {
            XPCollection<Recapes_Oct> Recapes_OctSc = new XPCollection<Recapes_Oct>(SessionSc);
            XPCollection<Recapes_Oct> Recapes_OctDs = new XPCollection<Recapes_Oct>(SessionDs);

            if (Recapes_OctDs.Count != 0)
            {
                SessionDs.Delete(Recapes_OctDs);
                SessionDs.Save(Recapes_OctDs);
            }

            foreach (Recapes_Oct recapes_OctSc in Recapes_OctSc)
            {
                Recapes_Oct recapes_OctDs = new Recapes_Oct(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Recapes_Oct).GetProperties())
                {
                    if (PropertyDs.Name == "Recape_Annuelle_Oct")
                    {
                        if (recapes_OctSc.Recape_Annuelle_Oct != null)
                        {
                            CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_Recape==?", recapes_OctSc.Recape_Annuelle_Oct.Cod_Recape);
                            Recape_Annuelle recape_Annuelle_Oct = SessionDs.FindObject<Recape_Annuelle>(CriteriaOperator.And(criteria1));
                            if (recape_Annuelle_Oct != null)
                            {
                                recapes_OctDs.Recape_Annuelle_Oct = recape_Annuelle_Oct;
                                recape_Annuelle_Oct.Save();
                            }
                        }
                    }
                    else
                        if (PropertyDs.Name == "parametres")
                        {

                            parametre parametres = SessionDs.FindObject<parametre>(null);
                            recapes_OctDs.parametres = parametres;
                        }
                        else
                            recapes_OctDs.SetMemberValue(PropertyDs.Name, recapes_OctSc.GetMemberValue(PropertyDs.Name));
                }
                recapes_OctDs.Save();
            }
        }

        public void RestaurerRecappeNouv(Session SessionDs, Session SessionSc)
        {
            XPCollection<Recapes_Nouv> Recapes_NouvSc = new XPCollection<Recapes_Nouv>(SessionSc);
            XPCollection<Recapes_Nouv> Recapes_NouvDs = new XPCollection<Recapes_Nouv>(SessionDs);

            if (Recapes_NouvDs.Count != 0)
            {
                SessionDs.Delete(Recapes_NouvDs);
                SessionDs.Save(Recapes_NouvDs);
            }

            foreach (Recapes_Nouv recapes_NouvSc in Recapes_NouvSc)
            {
                Recapes_Nouv recapes_NouvDs = new Recapes_Nouv(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Recapes_Nouv).GetProperties())
                {
                    if (PropertyDs.Name == "Recape_Annuelle_Janv")
                    {
                        if (recapes_NouvSc.Recape_Annuelle_Nouv != null)
                        {
                            CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_Recape==?", recapes_NouvSc.Recape_Annuelle_Nouv.Cod_Recape);
                            Recape_Annuelle recape_Annuelle_Nouv = SessionDs.FindObject<Recape_Annuelle>(CriteriaOperator.And(criteria1));
                            if (recape_Annuelle_Nouv != null)
                            {
                                recapes_NouvDs.Recape_Annuelle_Nouv = recape_Annuelle_Nouv;
                                recape_Annuelle_Nouv.Save();
                            }
                        }
                    }
                    else
                        if (PropertyDs.Name == "parametres")
                        {

                            parametre parametres = SessionDs.FindObject<parametre>(null);
                            recapes_NouvDs.parametres = parametres;
                        }
                        else
                            recapes_NouvDs.SetMemberValue(PropertyDs.Name, recapes_NouvSc.GetMemberValue(PropertyDs.Name));
                }
                recapes_NouvDs.Save();
            }
        }

        public void RestaurerRecappeDec(Session SessionDs, Session SessionSc)
        {
            XPCollection<Recapes_Dec> Recapes_DecSc = new XPCollection<Recapes_Dec>(SessionSc);
            XPCollection<Recapes_Dec> Recapes_DecDs = new XPCollection<Recapes_Dec>(SessionDs);

            if (Recapes_DecDs.Count != 0)
            {
                SessionDs.Delete(Recapes_DecDs);
                SessionDs.Save(Recapes_DecDs);
            }

            foreach (Recapes_Dec recapes_DecSc in Recapes_DecSc)
            {
                Recapes_Dec recapes_DecDs = new Recapes_Dec(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Recapes_Dec).GetProperties())
                {
                    if (PropertyDs.Name == "Recape_Annuelle_Dec")
                    {
                        if (recapes_DecSc.Recape_Annuelle_Dec != null)
                        {
                            CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_Recape==?", recapes_DecSc.Recape_Annuelle_Dec.Cod_Recape);
                            Recape_Annuelle recape_Annuelle_Dec = SessionDs.FindObject<Recape_Annuelle>(CriteriaOperator.And(criteria1));
                            if (recape_Annuelle_Dec != null)
                            {
                                recapes_DecDs.Recape_Annuelle_Dec = recape_Annuelle_Dec;
                                recape_Annuelle_Dec.Save();
                            }
                        }
                    }
                    else
                        if (PropertyDs.Name == "parametres")
                        { 
                            parametre parametres = SessionDs.FindObject<parametre>(null);
                            recapes_DecDs.parametres = parametres;
                        }
                        else
                            recapes_DecDs.SetMemberValue(PropertyDs.Name, recapes_DecSc.GetMemberValue(PropertyDs.Name));
                }
                recapes_DecDs.Save();
            }
        }

        public void RestaurerCategorieRapport(Session SessionDs, Session SessionSc)
        {
            XPCollection<Categorie_Rapport> Categorie_RapportSc = new XPCollection<Categorie_Rapport>(SessionSc);
            XPCollection<Categorie_Rapport> Categorie_RapportDs = new XPCollection<Categorie_Rapport>(SessionDs);

            if (Categorie_RapportDs.Count != 0)
            {
                SessionDs.Delete(Categorie_RapportDs);
                SessionDs.Save(Categorie_RapportDs);
            }

            foreach (Categorie_Rapport categorie_RapportSc in Categorie_RapportSc)
            {
                Categorie_Rapport categorie_RapportDs = new Categorie_Rapport(SessionDs);
                foreach (PropertyInfo PropertyDs in typeof(Categorie_Rapport).GetProperties())
                { 
                            categorie_RapportDs.SetMemberValue(PropertyDs.Name, categorie_RapportSc.GetMemberValue(PropertyDs.Name));
                }
                categorie_RapportDs.Save();
            }
        }

        public void RestaurerReportData(Session SessionDs, Session SessionSc)
        {
            XPCollection<ReportData> ReportDataSc = new XPCollection<ReportData>(SessionSc);
            XPCollection<ReportData> ReportDataDs = new XPCollection<ReportData>(SessionDs);

            if (ReportDataDs.Count != 0)
            {
                SessionDs.Delete(ReportDataDs);
                SessionDs.Save(ReportDataDs);
            }

            foreach (ReportData reportDataSc in ReportDataSc)
            {
                ReportData reportDataDs = new ReportData(SessionDs);
                foreach (PropertyInfo PropertyDs in (reportDataDs.GetType()).GetProperties())
                {
                    //if (PropertyDs.Name == "Categorie")
                    //{
                    //    //if (recapes_DecSc.Recape_Annuelle_Dec != null)
                    //    //{
                    //CriteriaOperator criteria1Sc = CriteriaOperator.Parse("Categorie==?", reportDataSc.GetMemberValue("Categorie"));
                    //        Categorie_Rapport categorie_RapportSc = SessionSc.FindObject<Categorie_Rapport>(CriteriaOperator.And(criteria1Sc));

                    //        CriteriaOperator criteria1Ds = CriteriaOperator.Parse("Categorie_Fr==?", categorie_RapportSc.Categorie_Fr);
                    //        Categorie_Rapport categorie_RapportDs = SessionDs.FindObject<Categorie_Rapport>(CriteriaOperator.And(criteria1Ds));
                    //        //if (categorie_Rapport != null)
                    //        //    reportDataDs.cate = categorie_Rapport;
                    //    //}
                    //        reportDataDs.SetMemberValue("Categorie", categorie_RapportDs);
                    //}
                    //else
                            reportDataDs.SetMemberValue(PropertyDs.Name, reportDataSc.GetMemberValue(PropertyDs.Name));
                }
                CriteriaOperator criteria1Sc = CriteriaOperator.Parse("Categorie==?", reportDataSc.GetMemberValue("Categorie"));
                Categorie_Rapport categorie_RapportSc = SessionSc.FindObject<Categorie_Rapport>(CriteriaOperator.And(criteria1Sc));

                CriteriaOperator criteria1Ds = CriteriaOperator.Parse("Categorie_Fr==?", categorie_RapportSc.Categorie_Fr);
                Categorie_Rapport categorie_RapportDs = SessionDs.FindObject<Categorie_Rapport>(CriteriaOperator.And(criteria1Ds));
             
                reportDataDs.SetMemberValue("Categorie", categorie_RapportDs);
                reportDataDs.Save();
            }
        }

        private void ImporterDonneesExercicePrecedent_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            //Session SessionDs = new Session();
            //Session SessionSc = new Session();

            //Exercice Exercice = e.CurrentObject as Exercice;

            ////foreach (Exercice Exercice in e.SelectedObjects)
            ////{
            //string dossier = Exercice.dossier.code_dossier;
            //int exercice = Exercice.exercice;

            //string ScBaseName = dossier + (exercice - 1).ToString();
            //string DsBaseName = dossier + (exercice).ToString();

            //string nom_serveur = System.Net.Dns.GetHostName();
            //string instance = GetSetting<string>("Instance");

            //string data_source = "";
            //if (instance == "")
            //    data_source = nom_serveur;
            //else
            //    data_source = nom_serveur + "\\" + instance;

            //string ScConnection = string.Format("Integrated Security=SSPI;Pooling=false;Data Source={0}{1};Initial Catalog={2}",
            //    Helper.serverName, Helper.instanceName, ScBaseName);

            //string DsConnection = string.Format("Integrated Security=SSPI;Pooling=false;Data Source={0}{1};Initial Catalog={2}",
            //     Helper.serverName, Helper.instanceName, DsBaseName);

            //SqlConnection SqlScConnection = new SqlConnection(ScConnection);
            //SqlConnection SqlDsConnection = new SqlConnection(DsConnection);

            //SessionSc.ConnectionString = SqlScConnection.ConnectionString;
            //SessionDs.ConnectionString = SqlDsConnection.ConnectionString;

            //RestaurerBanques(SessionDs, SessionSc);
            //RestaurerParametres(SessionDs, SessionSc);
            //RestaurerServices(SessionDs, SessionSc);
            //RestaurerUnites(SessionDs, SessionSc);
            //RestaurerCorps(SessionDs, SessionSc);
            //RestaurerBaremes(SessionDs, SessionSc);
            ////RestaurerSitEmp(SessionDs, SessionSc);
            ////RestaurerSitFam(SessionDs, SessionSc);
            ////RestaurerSitConj(SessionDs, SessionSc);
            ////RestaurerRaisSort(SessionDs, SessionSc);
            //RestaurerIndems(SessionDs, SessionSc);
            //RestaurerFonction(SessionDs, SessionSc);
            //RestaurerIndemFonct(SessionDs, SessionSc);
            //RestaurerEmploye(SessionDs, SessionSc);
            //RestaurerIndemPersonne(SessionDs, SessionSc);
            //RestaurerPiecesJointes(SessionDs, SessionSc);
            //RestaurerRecappeAnnuelle(SessionDs, SessionSc);
            //RestaurerRecappeJanv(SessionDs, SessionSc);
            //RestaurerRecappeFev(SessionDs, SessionSc);
            //RestaurerRecappeMars(SessionDs, SessionSc);
            //RestaurerRecappeAvr(SessionDs, SessionSc);
            //RestaurerRecappeMai(SessionDs, SessionSc);
            //RestaurerRecappeJuin(SessionDs, SessionSc);
            //RestaurerRecappeJuill(SessionDs, SessionSc);
            //RestaurerRecappeAout(SessionDs, SessionSc);
            //RestaurerRecappeSept(SessionDs, SessionSc);
            //RestaurerRecappeOct(SessionDs, SessionSc);
            //RestaurerRecappeNouv(SessionDs, SessionSc);
            //RestaurerRecappeDec(SessionDs, SessionSc);
            //RestaurerCategorieRapport(SessionDs, SessionSc);
            //RestaurerReportData(SessionDs, SessionSc);



            //}
        }

        private void ArchiverBDD_Execute(object sender, SimpleActionExecuteEventArgs e)
        { 
            string db_name = "";
            string datasource = "";

            if (((XPObjectSpace)ObjectSpace).Session.Connection is SQLiteConnection)
                db_name = ((SQLiteConnection)((XPObjectSpace)ObjectSpace).Session.Connection).DataSource;
            else
                if (((XPObjectSpace)ObjectSpace).Session.Connection is SqlConnection)
                {
                    db_name = ((SqlConnection)((XPObjectSpace)ObjectSpace).Session.Connection).Database;
                    datasource = ((SqlConnection)((XPObjectSpace)ObjectSpace).Session.Connection).DataSource;
                }

                if (lsactvtn.ActivationClass.réseau)
                {
                    SaveFileDialog sfd = new SaveFileDialog() { Filter = "Sauvegardes de BDD SQL|*.bak" };

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        { 
                            Backup backup = new Backup()
                            {
                                Database = db_name,
                                Action = BackupActionType.Database,
                                Initialize = true
                            };
                            backup.Devices.Add(new BackupDeviceItem(sfd.FileName, DeviceType.File));
                            backup.SqlBackup(new Server(datasource));

                            MessageBox.Show("L'archivage s'est terminé avec succés !", "Succés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
                else
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog() { };

                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            string dossier = db_name.Substring(0, db_name.Length - 4);
                            string SourcePath = Core.GetApplicationPath() + "\\Data\\"+ dossier +"\\"+ db_name;
                            string TargetPath = fbd.SelectedPath +"\\"+ db_name;

                            File.Copy(SourcePath, TargetPath, true);

                            MessageBox.Show("L'archivage s'est terminé avec succés !", "Succés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }  
                }
        }

        private void aConvertV2_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            //foreach (ReportData report in View.SelectedObjects)
            //{
            //    var AncienRapport = report.LoadReport(ObjectSpace) as XafReport;
            //    DevExpress.XtraReports.UI.XtraReport Rapport = new DevExpress.XtraReports.UI.XtraReport();
            //    using (MemoryStream ms = new MemoryStream())
            //    {
            //        AncienRapport.SaveLayout(ms);
            //        ms.Seek(0, SeekOrigin.Begin);
            //        Rapport.LoadLayout(ms);
            //    }
            //    DevExpress.Persistent.Base.ReportsV2.CollectionDataSource dataSource = new DevExpress.Persistent.Base.ReportsV2.CollectionDataSource();
            //    dataSource.ObjectTypeName = AncienRapport.DataType.FullName;
            //    dataSource.CriteriaString = AncienRapport.Filtering.Filter;
            //    Rapport.DataSource = dataSource;
            //    Rapport.ComponentStorage.Add(dataSource);
            //    ReportDataV2 RapportV2 = ObjectSpace.CreateObject<ReportDataV2>();
            //    //RapportV2.banque = report.banque;
            //    DevExpress.ExpressApp.ReportsV2.ReportDataProvider.ReportsStorage.SaveReport(RapportV2, Rapport);
            //    RapportV2.IsInplaceReport = report.IsInplaceReport;
            //}

            //ObjectSpace.CommitChanges();
        }

        private void SaveReportToFileV2(ReportDataV2 reportData, string fileName)
        {

            XtraReport report = DevExpress.ExpressApp.ReportsV2.ReportDataProvider.ReportsStorage.LoadReport(reportData);//reportData.LoadReport(View.ObjectSpace);
            fileName = string.Format("{0}\\{1}.repx", Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName));
            report.SaveLayout(fileName);
        }
        private void aExportV2_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            //if (fbd.ShowDialog() == DialogResult.OK)
            //{
            //    foreach (ReportDataV2 reportData in View.SelectedObjects)
            //    {
            //        SaveReportToFileV2(reportData, string.Format("{0}\\{1}", fbd.SelectedPath, reportData.DisplayName));
            //    }
            //}
        }
    }
}
