using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text; 
using DevExpress.ExpressApp; 
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.DC;
using DevExpress.Xpo; 
using MaPaye.Module;
using System.Windows.Forms;
using System.Data;
using DevExpress.Data.Filtering;
using System.Data.SqlClient;
using DevExpress.ExpressApp.Xpo;
using System.IO;
using DevExpress.Persistent.BaseImpl;


namespace MaPaye.Module
{
    public partial class ImportationDonnées : ViewController
    {
        public ImportationDonnées()
        {
            InitializeComponent();
            RegisterActions(components);
        }
 
        private void ImporterEmployes_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            DialogResult result = MessageBox.Show("Vous êtes entrain d’importer des données à partir d’un fichier Excel, êtes vous sur ?", "Importation des données", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Session session = ((XPObjectSpace)ObjectSpace).Session;
                ExcelReader excel_reader = new ExcelReader(new Session());
                DataTable dt = excel_reader.GetExcelTable(string.Empty);

                if (dt != null)
                {
                    //foreach (DataColumn column in dt.Columns)
                    //    Console.WriteLine(column.ColumnName);
                    foreach (DataRow row in dt.Rows)
                    {
                        CriteriaOperator criteria1Emp = CriteriaOperator.Parse("Cod_personne==?", row["Matricule"].ToString());
                        CriteriaOperator criteria2Emp = CriteriaOperator.Parse("FirstName==?", row["Nom"].ToString());
                        CriteriaOperator criteria3Emp = CriteriaOperator.Parse("LastName==?", row["Prenom"].ToString());
                        Personne Emp = session.FindObject<Personne>(CriteriaOperator.And(criteria1Emp, criteria2Emp, criteria3Emp));
                        if (Emp == null)
                        {
                            Personne Employe = new Personne(session);

                            Employe.Cod_personne = row["Matricule"].ToString();
                            Employe.Matricule_pointeuse = row["MatriculePointeuse"].ToString();
                            Employe.FirstName = row["Nom"].ToString();
                            Employe.LastName = row["Prenom"].ToString();
                            Employe.Nom_Prenom_CCP = row["Nom"].ToString() + " " + row["Prenom"].ToString();
                            Employe.Adresse_Fr = row["Adresse"].ToString();

                            string DateNaiss = row["DateNaiss"].ToString();
                            if (DateNaiss != "")
                            {
                                if (DateNaiss[0] == '0' && DateNaiss[1] == '0' && DateNaiss[3] == '0' && DateNaiss[4] == '0')
                                    Employe.Naissance_Présumé = row["DateNaiss"].ToString();
                                else
                                    Employe.Birthday = Convert.ToDateTime(row["DateNaiss"].ToString());
                            }

                            Employe.Lieu_nais = row["LieuNaiss"].ToString();

                            string sexe = row["Sexe"].ToString();
                            if (sexe == "F")
                                Employe.sexe = session.FindObject<Sexe>(CriteriaOperator.Parse("Sexe_Lib_Fr==?", Sexe_FR.Feminin));
                            else
                                if (sexe == "M")
                                    Employe.sexe = session.FindObject<Sexe>(CriteriaOperator.Parse("Sexe_Lib_Fr==?", Sexe_FR.Masculin));

                            string SitFam = row["SitFam"].ToString();
                            if (SitFam == "M")
                                Employe.Sit_fam = session.FindObject<Situation_Familiale>(CriteriaOperator.Parse("Sit_Fam_Lib_Fr==?", Sit_Fam_FR.Marie_Sans_Enfants));
                            else
                                if (SitFam == "ME")
                                    Employe.Sit_fam = session.FindObject<Situation_Familiale>(CriteriaOperator.Parse("Sit_Fam_Lib_Fr==?", Sit_Fam_FR.Marie_Avec_Enfants));
                                else
                                    if (SitFam == "C")
                                        Employe.Sit_fam = session.FindObject<Situation_Familiale>(CriteriaOperator.Parse("Sit_Fam_Lib_Fr==?", Sit_Fam_FR.Celibataire));
                                    else
                                        if (SitFam == "V")
                                            Employe.Sit_fam = session.FindObject<Situation_Familiale>(CriteriaOperator.Parse("Sit_Fam_Lib_Fr==?", Sit_Fam_FR.Veuf));
                                        else
                                            if (SitFam == "D")
                                                Employe.Sit_fam = session.FindObject<Situation_Familiale>(CriteriaOperator.Parse("Sit_Fam_Lib_Fr==?", Sit_Fam_FR.Divorsé));


                            string SitConj = row["SitConj"].ToString();
                            if (SitConj != "" && SitConj != null)
                                if (SitConj == "T")
                                    Employe.Sit_Conjoint = session.FindObject<Situation_Conjoint>(CriteriaOperator.Parse("Sit_Conj_Lib_Fr==?", Sit_Conj_FR.Tavail));
                                else
                                    if (SitConj == "C")
                                        Employe.Sit_Conjoint = session.FindObject<Situation_Conjoint>(CriteriaOperator.Parse("Sit_Conj_Lib_Fr==?", Sit_Conj_FR.Chomeur));
                                    else
                                        Employe.Sit_Conjoint = session.FindObject<Situation_Conjoint>(CriteriaOperator.Parse("Sit_Conj_Lib_Fr==?", Sit_Conj_FR.Sans));


                            string SitEmp = row["SitEmp"].ToString();
                            if (SitEmp != "" && SitEmp != null)
                                if (SitEmp == "A")
                                    Employe.Sit_Emp = session.FindObject<Situation_Employe>(CriteriaOperator.Parse("Sit_Emp_Lib_Fr==?", Sit_Emp_Fr.Actif));
                                else
                                    if (SitEmp == "NA")
                                        Employe.Sit_Emp = session.FindObject<Situation_Employe>(CriteriaOperator.Parse("Sit_Emp_Lib_Fr==?", Sit_Emp_Fr.Non_Actif));
                                    else
                                        if (SitEmp == "R")
                                            Employe.Sit_Emp = session.FindObject<Situation_Employe>(CriteriaOperator.Parse("Sit_Emp_Lib_Fr==?", Sit_Emp_Fr.Retraite));
                                        else
                                            if (SitEmp == "D")
                                                Employe.Sit_Emp = session.FindObject<Situation_Employe>(CriteriaOperator.Parse("Sit_Emp_Lib_Fr==?", Sit_Emp_Fr.Disponibilité));
                                            else
                                                if (SitEmp == "M")
                                                    Employe.Sit_Emp = session.FindObject<Situation_Employe>(CriteriaOperator.Parse("Sit_Emp_Lib_Fr==?", Sit_Emp_Fr.Maladie));
                                                else
                                                    if (SitEmp == "MT")
                                                        Employe.Sit_Emp = session.FindObject<Situation_Employe>(CriteriaOperator.Parse("Sit_Emp_Lib_Fr==?", Sit_Emp_Fr.Maternité));

                            string NbrEnf = row["NbrEnf"].ToString();
                            if (NbrEnf != "")
                                Employe.Nbr_enf = int.Parse(NbrEnf);

                            string DateEntree = row["DateEntree"].ToString();
                            if (DateEntree != "")
                                Employe.Dat_entre = Convert.ToDateTime(row["DateEntree"].ToString());

                            string DateSortie = row["DateSortie"].ToString();
                            if (DateSortie != "")
                                Employe.Dat_sortie = Convert.ToDateTime(row["DateSortie"].ToString());

                            string Fonction = row["Fonction"].ToString();
                            if (Fonction != "")
                            {
                                Fonction LaFonctionFr = session.FindObject<Fonction>(CriteriaOperator.Parse("Fct_Lib_Fr==?", Fonction));
                                if (LaFonctionFr != null)
                                    Employe.LaFonction = LaFonctionFr;
                                else
                                {
                                    Fonction cod_fonction = session.FindObject<Fonction>(CriteriaOperator.Parse("cod_fonction==?", Fonction));
                                    if (cod_fonction != null)
                                        Employe.LaFonction = cod_fonction;
                                }
                            }

                            string Service = row["Service"].ToString();
                            if (Service != "")
                            {
                                Service ServiceFr = session.FindObject<Service>(CriteriaOperator.Parse("Service_Lib_Fr==?", Service));
                                if (ServiceFr != null)
                                    Employe.LeSrevice = ServiceFr;
                                else
                                {
                                    Service cod_serv = session.FindObject<Service>(CriteriaOperator.Parse("Cod_ser==?", Service));
                                    if (cod_serv != null)
                                        Employe.LeSrevice = cod_serv;
                                }
                            }

                            string Unite = row["Unite"].ToString();
                            if (Unite != "")
                            {
                                Unite UniteFr = session.FindObject<Unite>(CriteriaOperator.Parse("Des_fr==?", Unite));
                                if (UniteFr != null)
                                    Employe.unite = UniteFr;
                                else
                                {
                                    Unite Cod_uni = session.FindObject<Unite>(CriteriaOperator.Parse("Cod_uni==?", Unite));
                                    if (Cod_uni != null)
                                        Employe.unite = Cod_uni;
                                }
                            }

                            string typecontrat = row["TypeContrat"].ToString();
                            if (typecontrat != "")
                            {
                                TypeContrat typecontratFr = session.FindObject<TypeContrat>(CriteriaOperator.Parse("Type_Contrat_Fr==?", typecontrat));
                                if (typecontratFr != null)
                                    Employe.TypeContrat = typecontratFr;
                            }

                            string ExpSecteur = row["ExpSecteur"].ToString();
                            if (ExpSecteur != "")
                            {
                                Employe.Nbr_Ans_Trv_Int = double.Parse(ExpSecteur);
                            }

                            string ExpHorsSecteurPrive = row["ExpHorsSecteurPrive"].ToString();
                            if (ExpHorsSecteurPrive != "")
                            {
                                Employe.Nbr_Ans_Trv_Ext_Prv = double.Parse(ExpHorsSecteurPrive);
                            }

                            string ExpHorsSecteurEtat = row["ExpHorsSecteurEtat"].ToString();
                            if (ExpHorsSecteurEtat != "")
                            {
                                Employe.Nbr_Ans_Trv_Ext_Etat = double.Parse(ExpHorsSecteurEtat);
                            }

                            string Banque = row["Banque"].ToString();
                            if (Banque != "")
                            {
                                Banque BanqueFr = session.FindObject<Banque>(CriteriaOperator.Parse("des_f==?", Banque));
                                if (BanqueFr != null)
                                    Employe.Banque = BanqueFr;
                                else
                                {
                                    Banque cod_banque = session.FindObject<Banque>(CriteriaOperator.Parse("cod_banque==?", Banque));
                                    if (cod_banque != null)
                                        Employe.Banque = cod_banque;
                                }
                            }

                            string NCompteBanque = row["NCompteBanque"].ToString();
                            if (NCompteBanque != "")
                            {
                                Employe.Num_CPP_Banque = NCompteBanque;
                            }

                            string CleCompteBanque = row["CleCompteBanque"].ToString();
                            if (CleCompteBanque != "")
                            {
                                Employe.cle_CPP_Banqu = CleCompteBanque;
                            }

                            string NCompteCCP = row["NCompteCCP"].ToString();
                            if (NCompteCCP != "")
                            {
                                Employe.num_compte = NCompteCCP;
                            }

                            string CleCompteCCP = row["CleCompteCCP"].ToString();
                            if (CleCompteCCP != "")
                            {
                                Employe.cle_compt = CleCompteCCP;
                            }

                            string NSecuriteSociale = row["NSecuriteSociale"].ToString();
                            if (NSecuriteSociale != "")
                            {
                                Employe.num_SecSoc = NSecuriteSociale;
                            }

                            string SDB = row["SDB"].ToString();
                            if (SDB != "")
                            {
                                Employe.Montant_SDB = decimal.Parse(SDB);
                            }

                            string UnitMes = row["UnitMes"].ToString();
                            if (UnitMes != "")
                            {
                                if (UnitMes == "M")
                                    Employe.Unit_mes = unit_mes.M;
                                else
                                    if (UnitMes == "J")
                                        Employe.Unit_mes = unit_mes.J;
                                    else
                                        if (UnitMes == "H")
                                            Employe.Unit_mes = unit_mes.H;
                            }

                            string SoumisSS = row["SoumisSS"].ToString();
                            if (SoumisSS == "T")
                                Employe.Soumis_à_la_Sécurité_Sociale = true;
                            else
                                Employe.Soumis_à_la_Sécurité_Sociale = false;

                            string SoumisIRG = row["SoumisIRG"].ToString();
                            if (SoumisIRG == "T")
                                Employe.Soumis_à_l_IRG = true;
                            else
                                Employe.Soumis_à_l_IRG = false;

                            string SoumisCacobatph = row["SoumisCacobatph"].ToString();
                            if (SoumisCacobatph == "T")
                                Employe.Soumis_Cacobatph = true;
                            else
                                Employe.Soumis_Cacobatph = false;

                        }
                    }
                        session.CommitTransaction();
                        //session.Reload(Employe);
                        MessageBox.Show("Importation des données terminée !", "Importer des données", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        View.Refresh();
                }
            }
        }

        private void ImporterBanques_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            DialogResult result = MessageBox.Show("Vous êtes entrain d’importer des données à partir d’un fichier Excel, êtes vous sur ?", "Importation des données", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Session session = ((XPObjectSpace)ObjectSpace).Session;
                ExcelReader excel_reader = new ExcelReader(new Session());
                DataTable dt = excel_reader.GetExcelTable(string.Empty);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Banque Banque = new Banque(session);

                        Banque.cod_banque = row["CodeBanq"].ToString();
                        //Banque.des_a = row["LibAr"].ToString();
                        Banque.des_f = row["LibFr"].ToString();
                        Banque.Cod_Agence = row["CodAgence"].ToString();
                        Banque.num_compte = row["N°Compte"].ToString();
                        Banque.cle_compte = row["CleCompte"].ToString();
                        Banque.adr_f = row["Adresse"].ToString();

                        session.CommitTransaction();
                    }
                    MessageBox.Show("Importation des données terminée !", "Importer des données", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //((DevExpress.ExpressApp.ListView)View).ObjectSpace.Refresh();

                    this.View.Refresh();
                }
            }
        
        }

        private void ImporterCorps_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            DialogResult result = MessageBox.Show("Vous êtes entrain d’importer des données à partir d’un fichier Excel, êtes vous sur ?", "Importation des données", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Session session = ((XPObjectSpace)ObjectSpace).Session;
                ExcelReader excel_reader = new ExcelReader(new Session());
                DataTable dt = excel_reader.GetExcelTable(string.Empty);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Corps Corps = new Corps(session);

                        Corps.CodeCorps = row["CodeCorps"].ToString();
                        Corps.DesCorps = row["LibFr"].ToString();
                        //Corps.DesCorpsAr = row["LibAr"].ToString();

                        session.CommitTransaction();
                    }
                    MessageBox.Show("Importation des données terminée !", "Importer des données", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //((DevExpress.ExpressApp.ListView)View).ObjectSpace.Refresh();

                    this.View.Refresh();
                }
            }
        }

        private void ImporterFonctions_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            DialogResult result = MessageBox.Show("Vous êtes entrain d’importer des données à partir d’un fichier Excel, êtes vous sur ?", "Importation des données", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Session session = ((XPObjectSpace)ObjectSpace).Session;
                ExcelReader excel_reader = new ExcelReader(new Session());
                DataTable dt = excel_reader.GetExcelTable(string.Empty);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Fonction Fonction = new Fonction(session);

                        Fonction.cod_fonction = row["CodeFct"].ToString();
                        Fonction.Fct_Lib_Fr = row["LibFr"].ToString();
                      
                        session.CommitTransaction();
                    }
                    MessageBox.Show("Importation des données terminée !", "Importer des données", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //((DevExpress.ExpressApp.ListView)View).ObjectSpace.Refresh();

                    this.View.Refresh();
                }
            }
        }

        private void ImporterServices_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            DialogResult result = MessageBox.Show("Vous êtes entrain d’importer des données à partir d’un fichier Excel, êtes vous sur ?", "Importation des données", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Session session = ((XPObjectSpace)ObjectSpace).Session;
                ExcelReader excel_reader = new ExcelReader(new Session());
                DataTable dt = excel_reader.GetExcelTable(string.Empty);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Service Service = new Service(session);

                        Service.Cod_ser = row["CodeService"].ToString();
                        Service.Service_Lib_Fr = row["LibFr"].ToString();
                        //Service.Service_Lib_Ar = row["LibAr"].ToString();

                        session.CommitTransaction();
                    }
                    MessageBox.Show("Importation des données terminée !", "Importer des données", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //((DevExpress.ExpressApp.ListView)View).ObjectSpace.Refresh();

                    this.View.Refresh();
                }
            }
        }

        private void ImporterUnités_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            DialogResult result = MessageBox.Show("Vous êtes entrain d’importer des données à partir d’un fichier Excel, êtes vous sur ?", "Importation des données", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Session session = ((XPObjectSpace)ObjectSpace).Session;
                ExcelReader excel_reader = new ExcelReader(new Session());
                DataTable dt = excel_reader.GetExcelTable(string.Empty);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Unite Unite = new Unite(session);

                        Unite.Cod_uni = row["CodeUnite"].ToString();
                        Unite.Des_fr = row["LibFr"].ToString();
                        //Unite.Des_ar = row["LibAr"].ToString();

                        session.CommitTransaction();
                    }
                    MessageBox.Show("Importation des données terminée !", "Importer des données", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //((DevExpress.ExpressApp.ListView)View).ObjectSpace.Refresh();

                    this.View.Refresh();
                }
            }
        }

        private void ImporterBareme_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            DialogResult result = MessageBox.Show("Vous êtes entrain d’importer des données à partir d’un fichier Excel, êtes vous sur ?", "Importation des données", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Session session = ((XPObjectSpace)ObjectSpace).Session;
                ExcelReader excel_reader = new ExcelReader(new Session());
                DataTable dt = excel_reader.GetExcelTable(string.Empty);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Bareme Categorie = new Bareme(session);

                        string Categ= row["Categ"].ToString();
                        if (Categ != "")
                            Categorie.CATEG =  Categ.ToString();

                        string SDB = row["SDB"].ToString();
                        if (SDB != "")
                            Categorie.SDB = double.Parse(SDB);

                        session.CommitTransaction();
                    }
                    MessageBox.Show("Importation des données terminée !", "Importer des données", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.View.Refresh();
                }
            }
        }

        private void ImporterTypesContrats_Execute(object sender, SimpleActionExecuteEventArgs e)
        {


            DialogResult result = MessageBox.Show("Vous êtes entrain d’importer des données à partir d’un fichier Excel, êtes vous sur ?", "Importation des données", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Session session = ((XPObjectSpace)ObjectSpace).Session;
                ExcelReader excel_reader = new ExcelReader(new Session());
                DataTable dt = excel_reader.GetExcelTable(string.Empty);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        TypeContrat TypeContrat = new TypeContrat(session);

                        TypeContrat.CodeType = row["CodeType"].ToString();
                        TypeContrat.Type_Contrat_Fr = row["LibFr"].ToString(); 

                        session.CommitTransaction();
                    }
                    MessageBox.Show("Importation des données terminée !", "Importer des données", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //((DevExpress.ExpressApp.ListView)View).ObjectSpace.Refresh();

                    this.View.Refresh();
                }
            }
        }

        private void ImporterPayes_Execute(object sender, SimpleActionExecuteEventArgs e)
        { 
            DialogResult result = MessageBox.Show("Vous êtes entrain d’importer des données à partir d’un fichier Excel, êtes vous sur ?", "Importation des données", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Session session = ((XPObjectSpace)ObjectSpace).Session;
                ExcelReader excel_reader = new ExcelReader(new Session());
                DataTable dt = excel_reader.GetExcelTable(string.Empty);
                parametre Parametres = session.FindObject<parametre>(null);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string CodeEmp = row["Cod_personne"].ToString();
                        Personne Emp = session.FindObject<Personne>(CriteriaOperator.Parse("Cod_personne==?", CodeEmp));
                        if (Emp != null)
                        {
                            string Mois = row["Mois"].ToString();
                            CriteriaOperator criteria1 = CriteriaOperator.Parse("personne==?", Emp);
                            CriteriaOperator criteria2 = CriteriaOperator.Parse("Mois==?", Mois);
                            Paye EmpPaye = session.FindObject<Paye>(CriteriaOperator.And(criteria1, criteria2));
                            if (EmpPaye == null)
                            {
                                Paye paye = new Paye(session);
                                paye.personne = Emp;
                                paye.Mois = (MoisdelAnnee)int.Parse(Mois);
                                string Chaine_Paye = Emp.Cod_personne + Parametres.Annee_Travail + (MoisdelAnnee)int.Parse(Mois);
                                paye.Cod_paye = Emp.Cod_personne + "/" + Mois;
                                paye.Chaine_Paye = Chaine_Paye; 
                                paye.Save();
                                paye.InitialisationPaye();

                                string NbrJrsAbs = row["Nbr_jour_abs"].ToString();
                                paye.Nbr_jour_abs_autre = int.Parse(NbrJrsAbs);

                                string NbrHeurAbs = row["Nbr_heure_abs"].ToString();
                                paye.Nbr_heure_abs = int.Parse(NbrHeurAbs);

                                string cat_paye = row["cat_paye"].ToString();
                                if (cat_paye == "")
                                    paye.cat_paye = CategoriePaye.Paye_Mensuel;
                                else
                                    if (cat_paye == "CONG")
                                        paye.cat_paye = CategoriePaye.Congé;
                                    else
                                        if (cat_paye == "STC")
                                            paye.cat_paye = CategoriePaye.Solde_tout_Compte;
                                 
                                string BrutCotis = row["Brute_cotisable"].ToString();
                                paye.Brute_cotisableAbsence = Convert.ToDecimal(BrutCotis);

                                Indem IndemniteBrutCotis = session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "Brute_cotisable"));
                                if (IndemniteBrutCotis != null)
                                {
                                    paye_indem IndemniteAInserer = new paye_indem(session);
                                    IndemniteAInserer.Indemnite = IndemniteBrutCotis;
                                    IndemniteAInserer.Montant = 0;
                                    IndemniteAInserer.Montant_Absence = Convert.ToDecimal(BrutCotis);
                                    IndemniteAInserer.Paye = paye;

                                    paye.paye_indems.Add(IndemniteAInserer);
                                }

                                string SS = row["Ss"].ToString();
                                paye.SSAbsence = Convert.ToDecimal(SS);

                                Indem IndemniteSS = session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "SS"));
                                if (IndemniteSS != null)
                                {
                                    paye_indem IndemniteAInserer = new paye_indem(session);
                                    IndemniteAInserer.Indemnite = IndemniteSS;
                                    IndemniteAInserer.Montant = 0;
                                    IndemniteAInserer.Montant_Absence = Convert.ToDecimal(SS);
                                    IndemniteAInserer.Paye = paye;

                                    paye.paye_indems.Add(IndemniteAInserer);
                                }

                                string BrutImpo = row["Brute_imposable"].ToString();
                                paye.Brute_imposable_Abs = Convert.ToDecimal(BrutImpo);

                                Indem IndemniteBrutImpo = session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "Brute_imposable"));
                                if (IndemniteBrutImpo != null)
                                {
                                    paye_indem IndemniteAInserer = new paye_indem(session);
                                    IndemniteAInserer.Indemnite = IndemniteBrutImpo;
                                    IndemniteAInserer.Montant = 0;
                                    IndemniteAInserer.Montant_Absence = Convert.ToDecimal(BrutImpo);
                                    IndemniteAInserer.Paye = paye;

                                    paye.paye_indems.Add(IndemniteAInserer);
                                }

                                string IRG = row["Irg"].ToString();
                                paye.IRGAbsence = Convert.ToDecimal(IRG);
                                Indem IndemniteIRG = session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "IRG"));
                                if (IndemniteIRG != null)
                                {
                                    paye_indem IndemniteAInserer = new paye_indem(session);
                                    IndemniteAInserer.Indemnite = IndemniteIRG;
                                    IndemniteAInserer.Montant = 0;
                                    IndemniteAInserer.Montant_Absence = Convert.ToDecimal(IRG);
                                    IndemniteAInserer.Paye = paye;

                                    paye.paye_indems.Add(IndemniteAInserer);
                                }
                                 
                                string NET = row["Net"].ToString();
                                paye.NETAbsence = Convert.ToDecimal(NET); 
                                Indem IndemniteNET = session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", "NET")); 
                                if (IndemniteNET != null)
                                {
                                    paye_indem IndemniteAInserer = new paye_indem(session);
                                    IndemniteAInserer.Indemnite = IndemniteNET;
                                    IndemniteAInserer.Montant = 0;
                                    IndemniteAInserer.Montant_Absence = Convert.ToDecimal(NET);
                                    IndemniteAInserer.Paye = paye;

                                    paye.paye_indems.Add(IndemniteAInserer);
                                }

                                paye.Valide = true;
                                paye.Save();
                            }
                        }
                        session.CommitTransaction();
                    }
                    MessageBox.Show("Importation des données terminée !", "Importer des données", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.View.Refresh();
                }
            }
        } 

    }

}