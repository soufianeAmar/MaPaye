using System; 
using System.Collections.Generic;
using System.Diagnostics; 
using DevExpress.ExpressApp; 
using DevExpress.ExpressApp.Actions; 
using DevExpress.Xpo;  
using System.Windows.Forms;
using System.Data;
using DevExpress.Data.Filtering;
using System.Data.SqlClient;
using DevExpress.ExpressApp.Xpo;
using System.IO;
using DevExpress.ExpressApp.Reports;
using System.Reflection;  
using DevExpress.ExpressApp.SystemModule;
using System.Data.SQLite;
using DevExpress.Persistent.BaseImpl;
using DevExpress.XtraReports.UI;
using MaPayeAdmin;
using System.Data.Common;
using System.Collections;


namespace MaPaye.Module
{
    public partial class ViewController1 : ViewController
    {
        public ViewController1()
        {
            InitializeComponent();
            RegisterActions(components);
        }

        private void ViewController1_Activated(object sender, EventArgs e)
        {
            Core.CoreSession =((XPObjectSpace)ObjectSpace).Session;
            Session session = ((XPObjectSpace)ObjectSpace).Session;
            
            //string db_name = "";
            //if (session.Connection is SQLiteConnection)
            //    db_name = ((SQLiteConnection)session.Connection).DataSource;
            //else
            //    if (session.Connection is SqlConnection)
            //        db_name = ((SqlConnection)session.Connection).Database;

            //if (db_name.Length > 0)
            //{
            //    string exercice = db_name.Substring(db_name.Length - 4);
            //    string dossier = db_name.Substring(0, db_name.Length - 4);
            //}

            if (View.ObjectTypeInfo.Type == typeof(Indem))
            {
                if (session.Connection != null)
                {
                    string requete = "";
                    DataTable dt = new DataTable();

                    if (lsactvtn.ActivationClass.réseau)
                    {
                        requete = string.Format(@"select
                               syscolumns.name as [name] 
                            from 
                               sysobjects, syscolumns 
                            where sysobjects.id = syscolumns.id 
                            and   sysobjects.xtype = 'U'
                            and   sysobjects.name = 'Paye'
                            order by syscolumns.name asc");

                        dt = Core.FetchData("", requete, (SqlConnection)session.Connection, true);
                    }
                    else
                    {
                        requete = string.Format(@"PRAGMA   table_info(Paye)");
                        dt = Core.FetchData("", requete, (SQLiteConnection)session.Connection, false);
                        dt.DefaultView.Sort = "name ASC";

                    }

                    IndexeIndem.Items.Clear();
                    int i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ChoiceActionItem CAI = new ChoiceActionItem(dr["name"].ToString(), dr["name"].ToString());//dr[i].ToString(),);
                        IndexeIndem.Items.Insert(i, CAI);
                        i++;
                    }

                }
            }

            if ((View is DevExpress.ExpressApp.DetailView) && (View.ObjectTypeInfo.Type == typeof(parametre)))
            {
                parametre Parametre = View.CurrentObject as parametre;
                if (Parametre.Annee_Travail == 0)
                    Parametre.Annee_Travail = DateTime.Now.Year;
            }
            //AppliquerEtatPourTousExercices.Active.SetItemValue("", !lsactvtn.ActivationClass.Demo);
            //CopierParametrageIndemnites.Active.SetItemValue("", !lsactvtn.ActivationClass.Demo);

        }
 
        private void ViewController1_Deactivated(object sender, EventArgs e)
        {
            //Application.Model.Application.Title = "MaPaye";
        }

        private void CalculerPaye_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;

            parametre Parametres = currentSession.FindObject<parametre>(null);
            int exist = -1;

            foreach (Paye selectedObject in e.SelectedObjects)
            {
                if (exist == -1)
                {
                    int mois = Convert.ToInt16(selectedObject.Mois);
                    Cloture Cloture = currentSession.FindObject<Cloture>(CriteriaOperator.Parse("Cod_Cloture==?", mois + Parametres.Annee_Travail.ToString()));
                    int i = 1;

                    if ((Cloture == null) || (Cloture != null && Cloture.Est_Cloture == false))
                    {
                        if (selectedObject.Valide != true && !selectedObject.FromRappel)
                        {
                            selectedObject.CalculerPaye();
                            selectedObject.Save();
                            //selectedObject.CalculerPaye();
                            //selectedObject.Save();
                        }
                        else
                            i = 0;
                        if (i == 0)
                            MessageBox.Show("La(les) paye(s) du ce mois a(ont) été validé ou été crée à partir d'un rappel !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("La(les) paye(s) du ce mois a(ont) été cloturé !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        exist = 0;
                    }
                }
            }
            this.View.Refresh();
            currentSession.CommitTransaction();
        }

        public static DialogResult dialogResult;
        public MoisdelAnnee Mois;

        private static void dc_Accepting(object sender, DialogControllerAcceptingEventArgs e)
        {
            dialogResult = DialogResult.OK;
        }

        private void InsérerPayeMois_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            int choix = Convert.ToInt16(e.SelectedChoiceActionItem.Data);
            if (choix > 0)
            {
                if (choix <= 15)
                {
                    Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;
                    parametre Parametres = currentSession.FindObject<parametre>(null);
                    XPCollection<Personne> Employes = new XPCollection<Personne>(currentSession);
                    Employes.Load();

                    if (Employes.Count > 0)
                    {
                        int yes = 0;
                        int LeMoisAInserer = Convert.ToInt16(e.SelectedChoiceActionItem.Data);
                        string mois = e.SelectedChoiceActionItem.Data.ToString();

                        Cloture Cloture = currentSession.FindObject<Cloture>(CriteriaOperator.Parse("Cod_Cloture==?", mois + Parametres.Annee_Travail.ToString()));
                        if ((Cloture == null) || (Cloture != null && Cloture.Est_Cloture == false))
                        {
                            if (Cloture == null)
                            {
                                Cloture cloture = new Cloture(currentSession);
                                cloture.Cod_Cloture = mois + Parametres.Annee_Travail.ToString();
                                cloture.Mois = (MoisdelAnnee)LeMoisAInserer;
                                cloture.Annee = Parametres.Annee_Travail.ToString();
                                cloture.Est_Cloture = false;
                                cloture.Save();
                            }
                            foreach (Personne Employe in Employes)
                            {
                                if (Employe.BrouillardCalcule == false)
                                {
                                    MessageBox.Show("Le Brouillard de paie pour l'employé : "
                                        + Employe.Cod_personne + " / " + Employe.FullName
                                        + ", n'est calculé ! Calculer le d'abord. ", "Avertissement",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    string Chaine_Paye = Employe.Cod_personne + Parametres.Annee_Travail + (MoisdelAnnee)LeMoisAInserer;

                                    Paye paye = currentSession.FindObject<Paye>(CriteriaOperator.Parse("Chaine_Paye==?", Chaine_Paye));

                                    if (paye != null && yes == 0)
                                    {
                                        DialogResult result = MessageBox.Show("La paye de la personne : " + Employe.Cod_personne + " / " + Employe.FullName + ", exist déja! Voulez vous l'écraser ?", "Avertissement", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                                        if (result == DialogResult.Yes)
                                        {
                                            DialogResult result2 = MessageBox.Show("Voulez vous écraser tous ?", "Ecrasement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                            if (result2 == DialogResult.Yes)
                                                yes = 1;

                                            paye.Delete();
                                            Paye UnePaye;
                                            UnePaye = new Paye(currentSession);

                                            UnePaye.personne = Employe;
                                            UnePaye.Mois = (MoisdelAnnee)LeMoisAInserer;
                                            UnePaye.Cod_paye = Employe.Cod_personne + "/" + UnePaye.Mois.ToString();
                                            UnePaye.Chaine_Paye = Chaine_Paye;
                                            UnePaye.Save();
                                            UnePaye.InitialisationPaye();

                                            foreach (Indem_Personne Indemnite in Employe.Indem_Personnes)
                                            {
                                                if (Indemnite.Indem.Cod_indem_interne != "")
                                                {
                                                    paye_indem IndemniteAInserer = new paye_indem(currentSession);
                                                    IndemniteAInserer.Indemnite = Indemnite.Indem;
                                                    IndemniteAInserer.IBase = Indemnite.Base;
                                                    IndemniteAInserer.INbr = Indemnite.INbr;
                                                    IndemniteAInserer.ITaux = Indemnite.Taux;
                                                    IndemniteAInserer.Montant = Indemnite.Montant;
                                                    IndemniteAInserer.Montant_Absence = Indemnite.Montant;
                                                    IndemniteAInserer.ModifSpecial = Indemnite.ModifSpecial;

                                                    UnePaye.paye_indems.Add(IndemniteAInserer);
                                                }
                                                UnePaye.AffectationsLignesColonnesInverse();
                                                UnePaye.Save();
                                                currentSession.CommitTransaction();
                                                UnePaye.CalculerPaye();
                                                UnePaye.Save();
                                            }
                                        }
                                        else
                                            if (result != DialogResult.Cancel)
                                            {
                                                Paye UnePaye;
                                                UnePaye = new Paye(currentSession);

                                                UnePaye.personne = Employe;
                                                UnePaye.Mois = (MoisdelAnnee)LeMoisAInserer;
                                                UnePaye.Cod_paye = Employe.Cod_personne + "/" + UnePaye.Mois.ToString();
                                                UnePaye.Chaine_Paye = Chaine_Paye;
                                                UnePaye.Save();
                                                UnePaye.InitialisationPaye();

                                                foreach (Indem_Personne Indemnite in Employe.Indem_Personnes)
                                                {
                                                    if (Indemnite.Indem.Cod_indem_interne != "")
                                                    {
                                                        paye_indem IndemniteAInserer = new paye_indem(currentSession);
                                                        IndemniteAInserer.Indemnite = Indemnite.Indem;
                                                        IndemniteAInserer.IBase = Indemnite.Base;
                                                        IndemniteAInserer.INbr = Indemnite.INbr;
                                                        IndemniteAInserer.ITaux = Indemnite.Taux;
                                                        IndemniteAInserer.Montant = Indemnite.Montant;
                                                        IndemniteAInserer.Montant_Absence = Indemnite.Montant;
                                                        IndemniteAInserer.ModifSpecial = Indemnite.ModifSpecial;

                                                        UnePaye.paye_indems.Add(IndemniteAInserer);
                                                    }
                                                    UnePaye.AffectationsLignesColonnesInverse();
                                                    UnePaye.Save();
                                                    currentSession.CommitTransaction();
                                                    UnePaye.CalculerPaye();
                                                    UnePaye.Save();
                                                }
                                            }
                                    }
                                    else
                                        if (paye != null && yes == 1)
                                        {
                                            paye.Delete();
                                            Paye UnePaye;
                                            UnePaye = new Paye(currentSession);

                                            UnePaye.personne = Employe;
                                            UnePaye.Mois = (MoisdelAnnee)LeMoisAInserer;
                                            UnePaye.Cod_paye = Employe.Cod_personne + "/" + UnePaye.Mois.ToString();
                                            UnePaye.Chaine_Paye = Chaine_Paye;
                                            UnePaye.Save();
                                            UnePaye.InitialisationPaye();

                                            foreach (Indem_Personne Indemnite in Employe.Indem_Personnes)
                                            {
                                                if (Indemnite.Indem.Cod_indem_interne != "")
                                                {
                                                    paye_indem IndemniteAInserer = new paye_indem(currentSession);
                                                    IndemniteAInserer.Indemnite = Indemnite.Indem;
                                                    IndemniteAInserer.IBase = Indemnite.Base;
                                                    IndemniteAInserer.INbr = Indemnite.INbr;
                                                    IndemniteAInserer.ITaux = Indemnite.Taux;
                                                    IndemniteAInserer.Montant = Indemnite.Montant;
                                                    IndemniteAInserer.Montant_Absence = Indemnite.Montant;
                                                    IndemniteAInserer.ModifSpecial = Indemnite.ModifSpecial;

                                                    UnePaye.paye_indems.Add(IndemniteAInserer);
                                                }
                                                UnePaye.AffectationsLignesColonnesInverse();
                                                UnePaye.Save();
                                                currentSession.CommitTransaction();
                                                UnePaye.CalculerPaye();
                                                UnePaye.Save();
                                            }
                                        }
                                        else
                                        {
                                            Paye UnePaye;
                                            UnePaye = new Paye(currentSession);

                                            UnePaye.personne = Employe;
                                            UnePaye.Mois = (MoisdelAnnee)LeMoisAInserer;
                                            UnePaye.Cod_paye = Employe.Cod_personne + "/" + UnePaye.Mois.ToString();
                                            UnePaye.Chaine_Paye = Chaine_Paye;
                                            UnePaye.Save();
                                            UnePaye.InitialisationPaye();

                                            foreach (Indem_Personne Indemnite in Employe.Indem_Personnes)
                                            {
                                                if (Indemnite.Indem.Cod_indem_interne != "")
                                                {
                                                    paye_indem IndemniteAInserer = new paye_indem(currentSession);
                                                    IndemniteAInserer.Indemnite = Indemnite.Indem;
                                                    IndemniteAInserer.IBase = Indemnite.Base;
                                                    IndemniteAInserer.INbr = Indemnite.INbr;
                                                    IndemniteAInserer.ITaux = Indemnite.Taux;
                                                    IndemniteAInserer.Montant = Indemnite.Montant;
                                                    IndemniteAInserer.Montant_Absence = Indemnite.Montant;
                                                    IndemniteAInserer.ModifSpecial = Indemnite.ModifSpecial;

                                                    UnePaye.paye_indems.Add(IndemniteAInserer);
                                                }
                                            }
                                            UnePaye.AffectationsLignesColonnesInverse();
                                            UnePaye.Save();
                                            currentSession.CommitTransaction();
                                            UnePaye.CalculerPaye();
                                            UnePaye.Save();

                                        }
                                }
                            }
                        }
                        else
                            MessageBox.Show("La paye du ce mois a été cloturée");
                        currentSession.CommitTransaction();
                    }
                }
                else
                {
                    Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;
                    parametre Parametres = currentSession.FindObject<parametre>(null);
                    Mois = (MoisdelAnnee)Convert.ToInt16(e.SelectedChoiceActionItem.Data) - 15;
                    string mois = e.SelectedChoiceActionItem.Data.ToString();

                    Cloture Cloture = currentSession.FindObject<Cloture>(CriteriaOperator.Parse("Cod_Cloture==?", mois + Parametres.Annee_Travail.ToString()));
                    if ((Cloture == null) || (Cloture != null && Cloture.Est_Cloture == false))
                    {
                        ShowViewParameters ShowViewParameters = new ShowViewParameters();
                        IObjectSpace os = Application.CreateObjectSpace();
                        //string listViewId = Application.FindListViewId(typeof(Personne));
                        DevExpress.ExpressApp.ListView listview = Application.CreateListView(os, typeof(Personne), false);
                        ShowViewParameters.CreatedView = listview;
                        ShowViewParameters.TargetWindow = TargetWindow.NewModalWindow;
                        ShowViewParameters.Context = TemplateContext.PopupWindow;
                        listview.ProcessSelectedItem += new System.EventHandler(listView_ProcessSelectedItem);

                        DialogController dc = Application.CreateController<DialogController>();
                        dc.AcceptAction.Execute += new SimpleActionExecuteEventHandler(AcceptAction_Execute);
                        ShowViewParameters.Controllers.Add(dc);
                        dc.SaveOnAccept = false;
                        dialogResult = DialogResult.Cancel;

                        Application.ShowViewStrategy.ShowView(ShowViewParameters, new ShowViewSource(null, null));

                    }
                    else
                        MessageBox.Show("La paye du ce mois a été cloturée");
                    currentSession.CommitTransaction();
                }
            }
        }

        void listView_ProcessSelectedItem(object sender, System.EventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;
            parametre Parametres = currentSession.FindObject<parametre>(null);
            //int LeMoisAInserer = Convert.ToInt16(((SingleChoiceAction)sender).SelectedItem.Data);
            int yes = 0;
            string mois = Mois.ToString();

            Cloture Cloture = currentSession.FindObject<Cloture>(CriteriaOperator.Parse("Cod_Cloture==?", mois + Parametres.Annee_Travail.ToString()));
            if (Cloture == null)
            {
                Cloture cloture = new Cloture(currentSession);
                cloture.Cod_Cloture = mois + Parametres.Annee_Travail.ToString();
                cloture.Mois = Mois;
                cloture.Annee = Parametres.Annee_Travail.ToString();
                cloture.Est_Cloture = false;
                cloture.Save();
            }

            foreach (Personne Emp in ((DevExpress.ExpressApp.ListView)sender).SelectedObjects)
            {
                CriteriaOperator criteria1Emp = CriteriaOperator.Parse("Cod_personne==?", Emp.Cod_personne);
                CriteriaOperator criteria2Emp = CriteriaOperator.Parse("FirstName==?", Emp.FirstName);
                CriteriaOperator criteria3Emp = CriteriaOperator.Parse("LastName==?", Emp.LastName);
                Personne Employe = currentSession.FindObject<Personne>(CriteriaOperator.And(criteria1Emp, criteria2Emp, criteria3Emp));

                if (Employe.BrouillardCalcule == false)
                {
                    MessageBox.Show("Le Brouillard de paie pour l'employé : "
                        + Employe.Cod_personne + " / " + Employe.FullName
                        + ", n'est calculé ! Calculer le d'abord. ", "Avertissement",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string Chaine_Paye = Employe.Cod_personne + Parametres.Annee_Travail + Mois;

                    Paye paye = currentSession.FindObject<Paye>(CriteriaOperator.Parse("Chaine_Paye==?", Chaine_Paye));

                    if (paye != null && yes == 0)
                    {
                        DialogResult result = MessageBox.Show("La paye de la personne : " + Employe.Cod_personne + " / " + Employe.FullName + ", exist déja! Voulez vous l'écraser ?", "Avertissement", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            DialogResult result2 = MessageBox.Show("Voulez vous écraser tous ?", "Ecrasement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result2 == DialogResult.Yes)
                                yes = 1;

                            paye.Delete();
                            Paye UnePaye;
                            UnePaye = new Paye(currentSession);

                            UnePaye.personne = Employe;
                            UnePaye.Mois = Mois;
                            UnePaye.Cod_paye = Employe.Cod_personne + "/" + UnePaye.Mois.ToString();
                            UnePaye.Chaine_Paye = Chaine_Paye;
                            UnePaye.Save();
                            UnePaye.InitialisationPaye();

                            foreach (Indem_Personne Indemnite in Employe.Indem_Personnes)
                            {
                                if (Indemnite.Indem.Cod_indem_interne != "")
                                {
                                    paye_indem IndemniteAInserer = new paye_indem(currentSession);
                                    IndemniteAInserer.Indemnite = Indemnite.Indem;
                                    IndemniteAInserer.IBase = Indemnite.Base;
                                    IndemniteAInserer.INbr = Indemnite.INbr;
                                    IndemniteAInserer.ITaux = Indemnite.Taux;
                                    IndemniteAInserer.Montant = Indemnite.Montant;
                                    IndemniteAInserer.Montant_Absence = Indemnite.Montant;
                                    IndemniteAInserer.ModifSpecial = Indemnite.ModifSpecial;

                                    UnePaye.paye_indems.Add(IndemniteAInserer);
                                }
                                UnePaye.AffectationsLignesColonnesInverse();
                                UnePaye.Save();
                                currentSession.CommitTransaction();
                                UnePaye.CalculerPaye();
                                UnePaye.Save();
                            }
                        }
                        else
                            if (result != DialogResult.Cancel)
                            {
                                Paye UnePaye;
                                UnePaye = new Paye(currentSession);

                                UnePaye.personne = Employe;
                                UnePaye.Mois = Mois;
                                UnePaye.Cod_paye = Employe.Cod_personne + "/" + UnePaye.Mois.ToString();
                                UnePaye.Chaine_Paye = Chaine_Paye;
                                UnePaye.Save();
                                UnePaye.InitialisationPaye();

                                foreach (Indem_Personne Indemnite in Employe.Indem_Personnes)
                                {
                                    if (Indemnite.Indem.Cod_indem_interne != "")
                                    {
                                        paye_indem IndemniteAInserer = new paye_indem(currentSession);
                                        IndemniteAInserer.Indemnite = Indemnite.Indem;
                                        IndemniteAInserer.IBase = Indemnite.Base;
                                        IndemniteAInserer.INbr = Indemnite.INbr;
                                        IndemniteAInserer.ITaux = Indemnite.Taux;
                                        IndemniteAInserer.Montant = Indemnite.Montant;
                                        IndemniteAInserer.Montant_Absence = Indemnite.Montant;
                                        IndemniteAInserer.ModifSpecial = Indemnite.ModifSpecial;

                                        UnePaye.paye_indems.Add(IndemniteAInserer);
                                    }
                                    UnePaye.AffectationsLignesColonnesInverse();
                                    UnePaye.Save();
                                    currentSession.CommitTransaction();
                                    UnePaye.CalculerPaye();
                                    UnePaye.Save();
                                }
                            }
                    }
                    else
                        if (paye != null && yes == 1)
                        {
                            paye.Delete();
                            Paye UnePaye;
                            UnePaye = new Paye(currentSession);

                            UnePaye.personne = Employe;
                            UnePaye.Mois = Mois;
                            UnePaye.Cod_paye = Employe.Cod_personne + "/" + UnePaye.Mois.ToString();
                            UnePaye.Chaine_Paye = Chaine_Paye;
                            UnePaye.Save();
                            UnePaye.InitialisationPaye();

                            foreach (Indem_Personne Indemnite in Employe.Indem_Personnes)
                            {
                                if (Indemnite.Indem.Cod_indem_interne != "")
                                {
                                    paye_indem IndemniteAInserer = new paye_indem(currentSession);
                                    IndemniteAInserer.Indemnite = Indemnite.Indem;
                                    IndemniteAInserer.IBase = Indemnite.Base;
                                    IndemniteAInserer.INbr = Indemnite.INbr;
                                    IndemniteAInserer.ITaux = Indemnite.Taux;
                                    IndemniteAInserer.Montant = Indemnite.Montant;
                                    IndemniteAInserer.Montant_Absence = Indemnite.Montant;
                                    IndemniteAInserer.ModifSpecial = Indemnite.ModifSpecial;

                                    UnePaye.paye_indems.Add(IndemniteAInserer);
                                }
                                UnePaye.AffectationsLignesColonnesInverse();
                                UnePaye.Save();
                                currentSession.CommitTransaction();
                                UnePaye.CalculerPaye();
                                UnePaye.Save();
                            }
                        }
                        else
                        {
                            Paye UnePaye;
                            UnePaye = new Paye(currentSession);

                            UnePaye.personne = Employe;
                            UnePaye.Mois = Mois;
                            UnePaye.Cod_paye = Employe.Cod_personne + "/" + UnePaye.Mois.ToString();
                            UnePaye.Chaine_Paye = Chaine_Paye;
                            UnePaye.Save();
                            UnePaye.InitialisationPaye();

                            foreach (Indem_Personne Indemnite in Employe.Indem_Personnes)
                            {
                                if (Indemnite.Indem.Cod_indem_interne != "")
                                {
                                    paye_indem IndemniteAInserer = new paye_indem(currentSession);
                                    IndemniteAInserer.Indemnite = Indemnite.Indem;
                                    IndemniteAInserer.IBase = Indemnite.Base;
                                    IndemniteAInserer.INbr = Indemnite.INbr;
                                    IndemniteAInserer.ITaux = Indemnite.Taux;
                                    IndemniteAInserer.Montant = Indemnite.Montant;
                                    IndemniteAInserer.Montant_Absence = Indemnite.Montant;
                                    IndemniteAInserer.ModifSpecial = Indemnite.ModifSpecial;

                                    UnePaye.paye_indems.Add(IndemniteAInserer);
                                }
                            }
                            UnePaye.AffectationsLignesColonnesInverse();
                            UnePaye.Save();
                            currentSession.CommitTransaction();
                            UnePaye.CalculerPaye();
                            UnePaye.Save();

                        }
                }

            }
        }

        void AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;
            parametre Parametres = currentSession.FindObject<parametre>(null);
            int yes = 0;
            string mois = Mois.ToString();

            Cloture Cloture = currentSession.FindObject<Cloture>(CriteriaOperator.Parse("Cod_Cloture==?", mois + Parametres.Annee_Travail.ToString()));
            if (Cloture == null)
            {
                Cloture cloture = new Cloture(currentSession);
                cloture.Cod_Cloture = mois + Parametres.Annee_Travail.ToString();
                cloture.Mois = Mois;
                cloture.Annee = Parametres.Annee_Travail.ToString();
                cloture.Est_Cloture = false;
                cloture.Save();
            }

            foreach (Personne Emp in e.SelectedObjects)
            {

                CriteriaOperator criteria1Emp = CriteriaOperator.Parse("Cod_personne==?", Emp.Cod_personne);
                CriteriaOperator criteria2Emp = CriteriaOperator.Parse("FirstName==?", Emp.FirstName);
                CriteriaOperator criteria3Emp = CriteriaOperator.Parse("LastName==?", Emp.LastName);
                Personne Employe = currentSession.FindObject<Personne>(CriteriaOperator.And(criteria1Emp, criteria2Emp, criteria3Emp));

                if (Employe.BrouillardCalcule == false)
                {
                    MessageBox.Show("Le Brouillard de paie pour l'employé : "
                        + Employe.Cod_personne + " / " + Employe.FullName
                        + ", n'est calculé ! Calculer le d'abord. ", "Avertissement",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string Chaine_Paye = Employe.Cod_personne + Parametres.Annee_Travail + Mois;

                    Paye paye = currentSession.FindObject<Paye>(CriteriaOperator.Parse("Chaine_Paye==?", Chaine_Paye));

                    if (paye != null && yes == 0)
                    {
                        DialogResult result = MessageBox.Show("La paye de la personne : " + Employe.Cod_personne + " / " + Employe.FullName + ", exist déja! Voulez vous l'écraser ?", "Avertissement", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            DialogResult result2 = MessageBox.Show("Voulez vous écraser tous ?", "Ecrasement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result2 == DialogResult.Yes)
                                yes = 1;

                            paye.Delete();
                            Paye UnePaye;
                            UnePaye = new Paye(currentSession);

                            UnePaye.personne = Employe;
                            UnePaye.Mois = Mois;
                            UnePaye.Cod_paye = Employe.Cod_personne + "/" + UnePaye.Mois.ToString();
                            UnePaye.Chaine_Paye = Chaine_Paye;
                            UnePaye.Save();
                            UnePaye.InitialisationPaye();

                            foreach (Indem_Personne Indemnite in Employe.Indem_Personnes)
                            {
                                if (Indemnite.Indem.Cod_indem_interne != "")
                                {
                                    paye_indem IndemniteAInserer = new paye_indem(currentSession);
                                    IndemniteAInserer.Indemnite = Indemnite.Indem;
                                    IndemniteAInserer.IBase = Indemnite.Base;
                                    IndemniteAInserer.INbr = Indemnite.INbr;
                                    IndemniteAInserer.ITaux = Indemnite.Taux;
                                    IndemniteAInserer.Montant = Indemnite.Montant;
                                    IndemniteAInserer.Montant_Absence = Indemnite.Montant;
                                    IndemniteAInserer.ModifSpecial = Indemnite.ModifSpecial;

                                    UnePaye.paye_indems.Add(IndemniteAInserer);
                                }
                                UnePaye.AffectationsLignesColonnesInverse();
                                UnePaye.Save();
                                currentSession.CommitTransaction();
                                UnePaye.CalculerPaye();
                                UnePaye.Save();
                            }
                        }
                        else
                            if (result != DialogResult.Cancel)
                            {
                                Paye UnePaye;
                                UnePaye = new Paye(currentSession);

                                UnePaye.personne = Employe;
                                UnePaye.Mois = Mois;
                                UnePaye.Cod_paye = Employe.Cod_personne + "/" + UnePaye.Mois.ToString();
                                UnePaye.Chaine_Paye = Chaine_Paye;
                                UnePaye.Save();
                                UnePaye.InitialisationPaye();

                                foreach (Indem_Personne Indemnite in Employe.Indem_Personnes)
                                {
                                    if (Indemnite.Indem.Cod_indem_interne != "")
                                    {
                                        paye_indem IndemniteAInserer = new paye_indem(currentSession);
                                        IndemniteAInserer.Indemnite = Indemnite.Indem;
                                        IndemniteAInserer.IBase = Indemnite.Base;
                                        IndemniteAInserer.INbr = Indemnite.INbr;
                                        IndemniteAInserer.ITaux = Indemnite.Taux;
                                        IndemniteAInserer.Montant = Indemnite.Montant;
                                        IndemniteAInserer.Montant_Absence = Indemnite.Montant;
                                        IndemniteAInserer.ModifSpecial = Indemnite.ModifSpecial;

                                        UnePaye.paye_indems.Add(IndemniteAInserer);
                                    }
                                    UnePaye.AffectationsLignesColonnesInverse();
                                    UnePaye.Save();
                                    currentSession.CommitTransaction();
                                    UnePaye.CalculerPaye();
                                    UnePaye.Save();
                                }
                            }
                    }
                    else
                        if (paye != null && yes == 1)
                        {
                            paye.Delete();
                            Paye UnePaye;
                            UnePaye = new Paye(currentSession);

                            UnePaye.personne = Employe;
                            UnePaye.Mois = Mois;
                            UnePaye.Cod_paye = Employe.Cod_personne + "/" + UnePaye.Mois.ToString();
                            UnePaye.Chaine_Paye = Chaine_Paye;
                            UnePaye.Save();
                            UnePaye.InitialisationPaye();

                            foreach (Indem_Personne Indemnite in Employe.Indem_Personnes)
                            {
                                if (Indemnite.Indem.Cod_indem_interne != "")
                                {
                                    paye_indem IndemniteAInserer = new paye_indem(currentSession);
                                    IndemniteAInserer.Indemnite = Indemnite.Indem;
                                    IndemniteAInserer.IBase = Indemnite.Base;
                                    IndemniteAInserer.INbr = Indemnite.INbr;
                                    IndemniteAInserer.ITaux = Indemnite.Taux;
                                    IndemniteAInserer.Montant = Indemnite.Montant;
                                    IndemniteAInserer.Montant_Absence = Indemnite.Montant;
                                    IndemniteAInserer.ModifSpecial = Indemnite.ModifSpecial;

                                    UnePaye.paye_indems.Add(IndemniteAInserer);
                                }
                                UnePaye.AffectationsLignesColonnesInverse();
                                UnePaye.Save();
                                currentSession.CommitTransaction();
                                UnePaye.CalculerPaye();
                                UnePaye.Save();
                            }
                        }
                        else
                        {
                            Paye UnePaye;
                            UnePaye = new Paye(currentSession);

                            UnePaye.personne = Employe;
                            UnePaye.Mois = Mois;
                            UnePaye.Cod_paye = Employe.Cod_personne + "/" + UnePaye.Mois.ToString();
                            UnePaye.Chaine_Paye = Chaine_Paye;
                            UnePaye.Save();
                            UnePaye.InitialisationPaye();

                            foreach (Indem_Personne Indemnite in Employe.Indem_Personnes)
                            {
                                if (Indemnite.Indem.Cod_indem_interne != "")
                                {
                                    paye_indem IndemniteAInserer = new paye_indem(currentSession);
                                    IndemniteAInserer.Indemnite = Indemnite.Indem;
                                    IndemniteAInserer.IBase = Indemnite.Base;
                                    IndemniteAInserer.INbr = Indemnite.INbr;
                                    IndemniteAInserer.ITaux = Indemnite.Taux;
                                    IndemniteAInserer.Montant = Indemnite.Montant;
                                    IndemniteAInserer.Montant_Absence = Indemnite.Montant;
                                    IndemniteAInserer.ModifSpecial = Indemnite.ModifSpecial;

                                    UnePaye.paye_indems.Add(IndemniteAInserer);
                                }
                            }
                            UnePaye.AffectationsLignesColonnesInverse();
                            UnePaye.Save();
                            currentSession.CommitTransaction();
                            UnePaye.CalculerPaye();
                            UnePaye.Save();

                        }
                }
            }
        }

        private void InsererIndemnitesFonction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;

            foreach (Personne selectedObject in e.SelectedObjects)
            {
                if (selectedObject.LaFonction != null || selectedObject.Fonction_Stagière != null)
                {
                    selectedObject.InsererCategorieFonction();
                    selectedObject.InsererIndemniteFonction();
                    selectedObject.Save();
                }

            }
            this.View.Refresh();
            currentSession.CommitTransaction();
        }

        private void InsererPayeSelection_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;
            int yes = 0;
            parametre Parametres = currentSession.FindObject<parametre>(null);
            int LeMoisAInserer = Convert.ToInt16(e.SelectedChoiceActionItem.Data);
            string mois = e.SelectedChoiceActionItem.Data.ToString();

            Cloture Cloture = currentSession.FindObject<Cloture>(CriteriaOperator.Parse("Cod_Cloture==?", mois + Parametres.Annee_Travail.ToString()));
            if ((Cloture == null) || (Cloture != null && Cloture.Est_Cloture == false))
            {
                if (Cloture == null)
                {
                    Cloture cloture = new Cloture(currentSession);
                    cloture.Cod_Cloture = mois + Parametres.Annee_Travail.ToString();
                    cloture.Mois = (MoisdelAnnee)LeMoisAInserer;
                    cloture.Annee = Parametres.Annee_Travail.ToString();
                    cloture.Est_Cloture = false;
                    cloture.Save();
                }
                foreach (Personne Employe in e.SelectedObjects)
                {
                    if (Employe.BrouillardCalcule == false)
                    {
                        MessageBox.Show("Le Brouillard de paie pour l'employé : "
                            + Employe.Cod_personne + " / " + Employe.FullName
                            + ", n'est calculé ! Calculer le d'abord. ", "Avertissement",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        if (!Employe.Bloque_Paye)
                        {
                            string Chaine_Paye = Employe.Cod_personne + Parametres.Annee_Travail + (MoisdelAnnee)LeMoisAInserer;

                            Paye paye = currentSession.FindObject<Paye>(CriteriaOperator.Parse("Chaine_Paye==?", Chaine_Paye));

                            if (paye != null && yes == 0)
                            {
                                DialogResult result = MessageBox.Show("La paye de la personne : " + Employe.Cod_personne + " / " + Employe.FullName + ", exist déja! Voulez vous l'écraser ?", "Avertissement", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                                if (result == DialogResult.Yes)
                                {
                                    DialogResult result2 = MessageBox.Show("Voulez vous écraser tous ?", "Ecrasement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                    if (result2 == DialogResult.Yes)
                                        yes = 1;

                                    paye.Delete();
                                    Paye UnePaye;
                                    UnePaye = new Paye(currentSession);

                                    UnePaye.personne = Employe;
                                    UnePaye.Mois = (MoisdelAnnee)LeMoisAInserer;
                                    UnePaye.Cod_paye = Employe.Cod_personne + "/" + UnePaye.Mois.ToString();
                                    UnePaye.Chaine_Paye = Chaine_Paye;
                                    UnePaye.Save();
                                    UnePaye.InitialisationPaye();

                                    foreach (Indem_Personne Indemnite in Employe.Indem_Personnes)
                                    {
                                        if (Indemnite.Indem.Cod_indem_interne != "")
                                        {
                                            paye_indem IndemniteAInserer = new paye_indem(currentSession);
                                            IndemniteAInserer.Indemnite = Indemnite.Indem;
                                            IndemniteAInserer.IBase = Indemnite.Base;
                                            IndemniteAInserer.INbr = Indemnite.INbr;
                                            IndemniteAInserer.ITaux = Indemnite.Taux;
                                            IndemniteAInserer.Montant = Indemnite.Montant;
                                            IndemniteAInserer.Montant_Absence = Indemnite.Montant;
                                            IndemniteAInserer.ModifSpecial = Indemnite.ModifSpecial;

                                            UnePaye.paye_indems.Add(IndemniteAInserer);
                                        }
                                        UnePaye.AffectationsLignesColonnesInverse();
                                        UnePaye.Save();
                                        currentSession.CommitTransaction();
                                        UnePaye.CalculerPaye();
                                        UnePaye.Save();
                                    }
                                }
                                else
                                    if (result != DialogResult.Cancel)
                                    {
                                        Paye UnePaye;
                                        UnePaye = new Paye(currentSession);

                                        UnePaye.personne = Employe;
                                        UnePaye.Mois = (MoisdelAnnee)LeMoisAInserer;
                                        UnePaye.Cod_paye = Employe.Cod_personne + "/" + UnePaye.Mois.ToString();
                                        UnePaye.Chaine_Paye = Chaine_Paye;
                                        UnePaye.Save();
                                        UnePaye.InitialisationPaye();

                                        foreach (Indem_Personne Indemnite in Employe.Indem_Personnes)
                                        {
                                            if (Indemnite.Indem.Cod_indem_interne != "")
                                            {
                                                paye_indem IndemniteAInserer = new paye_indem(currentSession);
                                                IndemniteAInserer.Indemnite = Indemnite.Indem;
                                                IndemniteAInserer.IBase = Indemnite.Base;
                                                IndemniteAInserer.INbr = Indemnite.INbr;
                                                IndemniteAInserer.ITaux = Indemnite.Taux;
                                                IndemniteAInserer.Montant = Indemnite.Montant;
                                                IndemniteAInserer.Montant_Absence = Indemnite.Montant;
                                                IndemniteAInserer.ModifSpecial = Indemnite.ModifSpecial;

                                                UnePaye.paye_indems.Add(IndemniteAInserer);
                                            }
                                            UnePaye.AffectationsLignesColonnesInverse();
                                            UnePaye.Save();
                                            currentSession.CommitTransaction();
                                            UnePaye.CalculerPaye();
                                            UnePaye.Save();
                                        }
                                    }
                            }
                            else
                                if (paye != null && yes == 1)
                                {
                                    paye.Delete();
                                    Paye UnePaye;
                                    UnePaye = new Paye(currentSession);

                                    //if (Employe.DateFinContrat != DateTime.MinValue)
                                    //    if (Employe.DateFinContrat.Month == DateTime.Now.Month)
                                    //        if (Employe.Dat_sortie != Employe.DateFinContrat)
                                    //        {
                                    //            DialogResult rslt = MessageBox.Show("Le contrat de cet employé a été expiré ! voulez vous le faire sortri ?", "Contrat expiré!",
                                    //                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                    //            if (rslt == DialogResult.Yes)
                                    //            {
                                    //                Employe.Dat_sortie = Employe.DateFinContrat;
                                    //                Employe.Bloque_Paye = true;
                                    //                Employe.Save();
                                    //            }

                                    //        }

                                    UnePaye.personne = Employe;
                                    UnePaye.Mois = (MoisdelAnnee)LeMoisAInserer;
                                    UnePaye.Cod_paye = Employe.Cod_personne + "/" + UnePaye.Mois.ToString();
                                    UnePaye.Chaine_Paye = Chaine_Paye;
                                    UnePaye.Save();
                                    UnePaye.InitialisationPaye();

                                    foreach (Indem_Personne Indemnite in Employe.Indem_Personnes)
                                    {
                                        if (Indemnite.Indem.Cod_indem_interne != "")
                                        {
                                            paye_indem IndemniteAInserer = new paye_indem(currentSession);
                                            IndemniteAInserer.Indemnite = Indemnite.Indem;
                                            IndemniteAInserer.IBase = Indemnite.Base;
                                            IndemniteAInserer.INbr = Indemnite.INbr;
                                            IndemniteAInserer.ITaux = Indemnite.Taux;
                                            IndemniteAInserer.Montant = Indemnite.Montant;
                                            IndemniteAInserer.Montant_Absence = Indemnite.Montant;
                                            IndemniteAInserer.ModifSpecial = Indemnite.ModifSpecial;

                                            UnePaye.paye_indems.Add(IndemniteAInserer);
                                        }
                                        UnePaye.AffectationsLignesColonnesInverse();
                                        UnePaye.Save();
                                        currentSession.CommitTransaction();
                                        UnePaye.CalculerPaye();
                                        UnePaye.Save();
                                    }
                                }
                                else
                                {
                                    Paye UnePaye;
                                    UnePaye = new Paye(currentSession);

                                    //if (Employe.DateFinContrat != DateTime.MinValue)
                                    //    if (Employe.DateFinContrat.Month == DateTime.Now.Month)
                                    //        if (Employe.Dat_sortie != Employe.DateFinContrat)
                                    //        {
                                    //            DialogResult rslt = MessageBox.Show("Le contrat de cet employé a été expiré ! voulez vous le faire sortri ?", "Contrat expiré!",
                                    //                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                    //            if (rslt == DialogResult.Yes)
                                    //            {
                                    //                Employe.Dat_sortie = Employe.DateFinContrat;
                                    //                Employe.Bloque_Paye = true;
                                    //                Employe.Save();
                                    //            }

                                    //        }

                                    UnePaye.personne = Employe;
                                    UnePaye.Mois = (MoisdelAnnee)LeMoisAInserer;
                                    UnePaye.Cod_paye = Employe.Cod_personne + "/" + UnePaye.Mois.ToString();
                                    UnePaye.Chaine_Paye = Chaine_Paye;
                                    UnePaye.Save();
                                    UnePaye.InitialisationPaye();

                                    foreach (Indem_Personne Indemnite in Employe.Indem_Personnes)
                                    {
                                        if (Indemnite.Indem.Cod_indem_interne != "")
                                        {
                                            paye_indem IndemniteAInserer = new paye_indem(currentSession);
                                            IndemniteAInserer.Indemnite = Indemnite.Indem;
                                            IndemniteAInserer.IBase = Indemnite.Base;
                                            IndemniteAInserer.INbr = Indemnite.INbr;
                                            IndemniteAInserer.ITaux = Indemnite.Taux;
                                            IndemniteAInserer.Montant = Indemnite.Montant;
                                            IndemniteAInserer.Montant_Absence = Indemnite.Montant;
                                            IndemniteAInserer.ModifSpecial = Indemnite.ModifSpecial;

                                            UnePaye.paye_indems.Add(IndemniteAInserer);
                                        }
                                    }
                                    UnePaye.AffectationsLignesColonnesInverse();
                                    UnePaye.Save();
                                    currentSession.CommitTransaction();
                                    UnePaye.CalculerPaye();
                                    UnePaye.Save();

                                }
                        }
                }
            }
            else
                MessageBox.Show("La paye du ce mois a été cloturée");
            currentSession.CommitTransaction();
        }

        private void InsererRappelAncSet_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;

            string code = e.ParameterCurrentValue.ToString();

            foreach (Paye PayeAnc in e.SelectedObjects)
            {
                Rappel rappel = currentSession.FindObject<Rappel>(CriteriaOperator.Parse("Cod_Rappel_Personne==?", code + PayeAnc.personne.Cod_personne));
                if (rappel != null)
                {
                    rappel.Paye_Ancien = PayeAnc;
                }
                else
                {
                    Rappel Rappel = new Rappel(currentSession);

                    Rappel.Cod_Rappel_Personne = code + PayeAnc.personne.Cod_personne;
                    Rappel.Personne = PayeAnc.personne;
                    Rappel.Paye_Ancien = PayeAnc;
                    Rappel.Cod_Rappel = code;
                    Rappel.Cod_personne = PayeAnc.personne.Cod_personne;
                }
            }

            currentSession.CommitTransaction();
        }

        private void CalculerRappelIndividuel_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;
            foreach (Rappel rappel in e.SelectedObjects)
            {
                rappel.InsererRappelIndemnite(rappel.Cod_Rappel_Personne);
                rappel.Save();
            }
            currentSession.CommitTransaction();

            this.View.Refresh();
        }

        private void CalculerRappel_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;

            foreach (Rappel Rappel in e.SelectedObjects)
            {
                Rappel.InsererRappelIndemnite(Rappel.Cod_Rappel_Personne);
            }

            currentSession.CommitTransaction();

            this.View.Refresh();
        }

        private void InsererRappelNouvSet_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;

            string code = e.ParameterCurrentValue.ToString();


            foreach (Paye PayeNouv in e.SelectedObjects)
            {
                Rappel rappel = currentSession.FindObject<Rappel>(CriteriaOperator.Parse("Cod_Rappel_Personne==?", code + PayeNouv.personne.Cod_personne));

                if (rappel != null)
                {
                    rappel.Paye_Nouveau = PayeNouv;
                }
                else
                {
                    Rappel Rappel = new Rappel(currentSession);

                    Rappel.Cod_Rappel_Personne = code + PayeNouv.personne.Cod_personne;
                    Rappel.Personne = PayeNouv.personne;
                    Rappel.Paye_Nouveau = PayeNouv;
                    Rappel.Cod_Rappel = code;
                    Rappel.Cod_personne = PayeNouv.personne.Cod_personne;
                }


            }

            currentSession.CommitTransaction();
        }

        private void CloturerPayeMois_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;
            parametre Parametres = currentSession.FindObject<parametre>(null);
            int LeMoisAInserer = Convert.ToInt16(e.SelectedChoiceActionItem.Data);

            string mois = e.SelectedChoiceActionItem.Data.ToString();
            int yes = 0;

            Cloture Cloture = currentSession.FindObject<Cloture>(CriteriaOperator.Parse("Cod_Cloture==?", mois + Parametres.Annee_Travail.ToString()));
            if (Cloture == null)
            {
                Cloture cloture = new Cloture(currentSession);
                cloture.Cod_Cloture = mois + Parametres.Annee_Travail.ToString();
                cloture.Mois = (MoisdelAnnee)LeMoisAInserer;
                cloture.Annee = Parametres.Annee_Travail.ToString();
                cloture.Est_Cloture = true;
                cloture.Save();

                XPCollection<Paye> PayeCollection = new XPCollection<Paye>(currentSession, CriteriaOperator.Parse("Mois=?", ((MoisdelAnnee)LeMoisAInserer).ToString()));
                PayeCollection.Load();

                foreach (Paye paye in PayeCollection)
                {
                    CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_Recape==?", paye.personne.Cod_personne + paye.Annee.ToString());
                    CriteriaOperator criteria = CriteriaOperator.And(criteria1);
                    if (Parametres.DeclarationMultiple)
                    {
                        CriteriaOperator criteria2 = CriteriaOperator.Parse("NumEmployeur==?", paye.Unite.NumEmployeur);
                        criteria = CriteriaOperator.And(criteria1, criteria2);
                    }

                    Recape_Annuelle recape_Annuelle = currentSession.FindObject<Recape_Annuelle>(CriteriaOperator.And(criteria));
                    
                    if (recape_Annuelle == null)
                    {
                        Recape_Annuelle Recape_Annuelle = new Recape_Annuelle(currentSession);
                        yes = Recape_Annuelle.Recape_paye(paye, CategorieCloture.Paye, LeMoisAInserer, yes);
                        Recape_Annuelle.Save();
                    }
                    else
                    {
                        yes = recape_Annuelle.Recape_paye(paye, CategorieCloture.Paye, LeMoisAInserer, yes);
                        recape_Annuelle.Save();
                    }

                    currentSession.CommitTransaction();
                }
            }
            else
            {
                if (Cloture.Est_Cloture == false)
                {
                    Cloture.Est_Cloture = true;
                    Cloture.Save();

                    XPCollection<Paye> PayeCollection = new XPCollection<Paye>(currentSession, CriteriaOperator.Parse("Mois=?", ((MoisdelAnnee)LeMoisAInserer).ToString()));
                    PayeCollection.Load();

                    foreach (Paye paye in PayeCollection)
                    {
                        CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_Recape==?", paye.personne.Cod_personne + paye.Annee.ToString());
                        CriteriaOperator criteria = CriteriaOperator.And(criteria1);
                        if (Parametres.DeclarationMultiple)
                        {
                            CriteriaOperator criteria2 = CriteriaOperator.Parse("NumEmployeur==?", paye.Unite.NumEmployeur);
                            criteria = CriteriaOperator.And(criteria1, criteria2);
                        }

                        Recape_Annuelle recape_Annuelle = currentSession.FindObject<Recape_Annuelle>(CriteriaOperator.And(criteria));
                        if (recape_Annuelle == null)
                        {
                            Recape_Annuelle Recape_Annuelle = new Recape_Annuelle(currentSession);
                            yes = Recape_Annuelle.Recape_paye(paye, CategorieCloture.Paye, LeMoisAInserer, yes);
                            Recape_Annuelle.Save();
                        }
                        else
                        {
                            yes = recape_Annuelle.Recape_paye(paye, CategorieCloture.Paye, LeMoisAInserer, yes);
                            recape_Annuelle.Save();
                        }
                        currentSession.CommitTransaction();
                    }
                }
                else
                    MessageBox.Show("La paye de ce mois a été déja cloturée !");
            }
        }

        private void CreerFichierDAS_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;

            foreach (Recape_Annuelle Recappe in e.SelectedObjects)
            {
                DAS DAS = new DAS(currentSession);

                DAS.personne = Recappe.personne;
                DAS.Date_Debut = Recappe.personne.Dat_entre;
                DAS.Date_Fin = Recappe.personne.Dat_sortie;
                currentSession.CommitTransaction();
                DAS.InsererPeriodesDAS();
                DAS.Save();
            }

            currentSession.CommitTransaction();
            this.View.Refresh();
        }

        private void CalculerFichierDAS_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;

            foreach (DAS DAS in e.SelectedObjects)
            {

                XPCollection<Periodes_DAS> colDelete = new XPCollection<Periodes_DAS>(currentSession, CriteriaOperator.Parse("DAS=?", DAS.ToString()));
                if (colDelete.Count != 0)
                {
                    currentSession.Delete(colDelete);
                    currentSession.Save(colDelete);
                }

                DAS.InsererPeriodesDAS();
                DAS.Save();
            }

            currentSession.CommitTransaction();
            this.View.Refresh();
        }

        private void EnvoyerRappelVersBordereau_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;
            parametre Parametres = currentSession.FindObject<parametre>(null);
            int mois = Convert.ToInt16(e.SelectedChoiceActionItem.Data);

            foreach (Rappel Rappel in e.SelectedObjects)
            {
                string Chaine = Rappel.Personne.Cod_personne + Parametres.Annee_Travail + (MoisdelAnnee)mois;

                Bordereau Bordereau = currentSession.FindObject<Bordereau>(CriteriaOperator.Parse("Chaine_Bordereau==?", Chaine));

                if (Bordereau != null)
                {
                    DialogResult result = MessageBox.Show("La paye de la personne : " + Rappel.Personne.Cod_personne + " / " + Parametres.Annee_Travail + " / " + (MoisdelAnnee)mois + ", exist déja! Voulez vous le mis à jour ?", "Avertissement", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        Bordereau bordereau = new Bordereau(currentSession);

                        bordereau.personne = Rappel.Personne;
                        bordereau.Mois = (MoisdelAnnee)mois;
                        bordereau.Annee = Rappel.Annee;
                        bordereau.Chaine_Bordereau = Chaine;
                        int Code = Convert.ToInt16(currentSession.Evaluate(typeof(Bordereau), CriteriaOperator.Parse("max(Code)"), null));
                        bordereau.Code = Code + 1;
                        bordereau.Cod_Bordereau = bordereau.Code.ToString() + " / " + Rappel.Personne.Cod_personne + " / " + bordereau.Mois.ToString();
                        bordereau.Montant += Rappel.NET_Mois;
                        bordereau.Save();
                    }
                    else
                    {
                        Bordereau.Montant += Rappel.NET_Mois;
                    }
                }
                else
                {
                    Bordereau bordereau = new Bordereau(currentSession);

                    bordereau.personne = Rappel.Personne;
                    bordereau.Mois = (MoisdelAnnee)mois;
                    bordereau.Annee = Rappel.Annee;
                    bordereau.Chaine_Bordereau = Chaine;
                    int Code = Convert.ToInt16(currentSession.Evaluate(typeof(Bordereau), CriteriaOperator.Parse("max(Code)"), null));
                    bordereau.Code = Code + 1;
                    bordereau.Cod_Bordereau = bordereau.Code.ToString() + " / " + Rappel.Personne.Cod_personne + " / " + bordereau.Mois.ToString();
                    bordereau.Montant += Rappel.NET_Mois;
                    bordereau.Save();
                }

            }
            currentSession.CommitTransaction();

        }

        private void EnvoyerPayeVersBordereau_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;
            parametre Parametres = currentSession.FindObject<parametre>(null);
            int mois = Convert.ToInt16(e.SelectedChoiceActionItem.Data);

            foreach (Paye Paye in e.SelectedObjects)
            {
                if (Paye.Bloque_Paye == false)
                {
                    string Chaine = Paye.personne.Cod_personne + Parametres.Annee_Travail + (MoisdelAnnee)mois;

                    Bordereau Bordereau = currentSession.FindObject<Bordereau>(CriteriaOperator.Parse("Chaine_Bordereau==?", Chaine));

                    if (Bordereau != null)
                    {
                        DialogResult result = MessageBox.Show("La paye de la personne : " + Paye.personne.Cod_personne + " / " + Parametres.Annee_Travail + " / " + (MoisdelAnnee)mois + ", exist déja! Voulez vous le mis à jour ?", "Avertissement", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                        if (result == DialogResult.No)
                        {
                            Bordereau bordereau = new Bordereau(currentSession);

                            bordereau.personne = Paye.personne;
                            bordereau.Mois = (MoisdelAnnee)mois;
                            bordereau.Annee = Paye.Annee;
                            bordereau.Chaine_Bordereau = Chaine;
                            int Code = Convert.ToInt16(currentSession.Evaluate(typeof(Bordereau), CriteriaOperator.Parse("max(Code)"), null));
                            bordereau.Code = Code + 1;
                            bordereau.Cod_Bordereau = bordereau.Code.ToString() + " / " + Paye.personne.Cod_personne + " / " + bordereau.Mois.ToString();
                            bordereau.Montant += Paye.NET;
                            bordereau.Save();
                        }
                        else
                        {
                            Bordereau.Montant += Paye.NET;
                        }
                    }
                    else
                    {
                        Bordereau bordereau = new Bordereau(currentSession);

                        bordereau.personne = Paye.personne;
                        bordereau.Mois = (MoisdelAnnee)mois;
                        bordereau.Annee = Paye.Annee;
                        bordereau.Chaine_Bordereau = Chaine;
                        int Code = Convert.ToInt16(currentSession.Evaluate(typeof(Bordereau), CriteriaOperator.Parse("max(Code)"), null));
                        bordereau.Code = Code + 1;
                        bordereau.Cod_Bordereau = bordereau.Code.ToString() + " / " + Paye.personne.Cod_personne + " / " + bordereau.Mois.ToString();
                        bordereau.Montant += Paye.NET;
                        bordereau.Save();
                    }
                }

            }
            currentSession.CommitTransaction();

        }

        private void CreerFichierDASEmployés_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session session = ((XPObjectSpace)ObjectSpace).Session;
            parametre parametres = session.FindObject<parametre>(null);
            foreach (DAS_G das_g in e.SelectedObjects)
            {
                XPCollection<Das_Personnes> das_personne = new XPCollection<Das_Personnes>(session, CriteriaOperator.Parse("DAS_G=?", das_g));

                if (das_personne.Count > 0)
                {
                    MemoryStream s = new MemoryStream();
                    TextWriter tw = new StreamWriter(s) { AutoFlush = true };
                    TextReader tr = new StreamReader(s);
                    int ord = 0;

                    //Entête de la remise***************************************************************************************
                    foreach (Das_Personnes dp in das_personne)
                    {
                        if (dp.DAS_G.Num_employeur != null)
                            tw.Write(champsTexte(dp.DAS_G.Num_employeur.Replace(" ", ""), "string", 10));
                        else
                            tw.Write(champsTexte("", "string", 10));

                        tw.Write(champsTexte(string.Format("{0:yyyy}", dp.DAS_G.date), "string", 4));
                        ord += 1;

                        tw.Write(champsTexte(ord.ToString(), "string", 6));
                        if (dp.num_SecSoc != null)
                            tw.Write(champsTexte(dp.num_SecSoc.Replace(" ", ""), "string", 12));
                        else
                            tw.Write(champsTexte("", "string", 12));

                        tw.Write(champsTexte(dp.Nom, "string", 25));
                        tw.Write(champsTexte(dp.Prenom, "string", 25));
                        if (dp.Naissance_Présumé == "" || dp.Naissance_Présumé == null)
                            tw.Write(champsTexte(string.Format("{0:ddMMyyyy}", dp.Date_Naissance), "string", 8));
                        else
                            tw.Write(champsTexte(dp.Naissance_Présumé.Replace("/", ""), "string", 8));

                        tw.Write(champsTexte(Convert.ToString(dp.jrs_trv_tr1), "string", 3));
                        tw.Write(champsTexte(Convert.ToString(dp.Unit_mes), "string", 1));
                        long montanttr1 = Convert.ToInt64(Convert.ToDouble(dp.montant_tr1) * 100);
                        tw.Write(champsTexte(Convert.ToString(montanttr1), "string", 10));

                        tw.Write(champsTexte(Convert.ToString(dp.jrs_trv_tr2), "string", 3));
                        tw.Write(champsTexte(Convert.ToString(dp.Unit_mes), "string", 1));
                        long montanttr2 = Convert.ToInt64(Convert.ToDouble(dp.montant_tr2) * 100);
                        tw.Write(champsTexte(Convert.ToString(montanttr2), "string", 10));

                        tw.Write(champsTexte(Convert.ToString(dp.jrs_trv_tr3), "string", 3));
                        tw.Write(champsTexte(Convert.ToString(dp.Unit_mes), "string", 1));
                        long montanttr3 = Convert.ToInt64(Convert.ToDouble(dp.montant_tr3) * 100);
                        tw.Write(champsTexte(Convert.ToString(montanttr3), "string", 10));

                        tw.Write(champsTexte(Convert.ToString(dp.jrs_trv_tr4), "string", 3));
                        tw.Write(champsTexte(Convert.ToString(dp.Unit_mes), "string", 1));
                        long montanttr4 = Convert.ToInt64(Convert.ToDouble(dp.montant_tr4) * 100);
                        tw.Write(champsTexte(Convert.ToString(montanttr4), "string", 10));

                        long montant = Convert.ToInt64(Convert.ToDouble(dp.montant) * 100);
                        tw.Write(champsTexte(Convert.ToString(montant), "string", 12));

                        if (dp.Dat_entre != DateTime.MinValue)
                            tw.Write(champsTexte(string.Format("{0:ddMMyyyy}", dp.Dat_entre), "string", 8));
                        else
                            tw.Write(champsTexte("", "string", 8));

                        if (dp.Dat_sortie != DateTime.MinValue)
                            tw.Write(champsTexte(string.Format("{0:ddMMyyyy}", dp.Dat_sortie), "string", 8));
                        else
                            tw.Write(champsTexte("", "string", 8));

                        tw.Write(champsTexte(Convert.ToString(dp.LaFonction), "string", 20));

                        tw.WriteLine();
                    }
                    s.Position = 0;

                    das_g.text_DAS = tr.ReadToEnd();
                    das_g.Save();

                    session.CommitTransaction();


                    FolderBrowserDialog file_directory = new FolderBrowserDialog();
                    if (file_directory.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string file_name = "";
                        if (das_g.Num_employeur == "")
                            MessageBox.Show("Le numéro employeur ne doit pas etre vide dans parametres");
                        else
                        {
                            file_name = string.Format("D{0:yy}S{1}.txt", das_g.date, das_g.Num_employeur.Replace(" ", ""));

                            //string Path = string.Format(@"{0}\{1}_{2}", file_directory.SelectedPath, das_g.Denomination, das_g.Num_employeur);

                            using (TextWriter sw = new StreamWriter(string.Format(@"{0}\{1}", file_directory.SelectedPath, file_name)))
                            {
                                sw.Write(das_g.text_DAS);
                            }
                            Process.Start("explorer.exe", string.Format(@"/select, {0}\{1}", file_directory.SelectedPath, file_name));

                        }
                    }
                }
                else
                    MessageBox.Show("Aucun employé séléctionné !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public static string champsTexte(string value, string type, int length)
        {
            if (value != null)
            {
                switch (type)
                {
                    case "string":
                        if (length > value.Length)
                            return string.Format("{0}{1}", value, new string(' ', length - value.Length));
                        else
                            return value.Substring(0, length);
                    case "int":
                        if (length > value.Length)
                            return string.Format("{0}{1}", new string('0', length - value.Length), value);
                        else
                            return value.Substring(0, length);
                    case "string-L":
                        if (length > value.Length)
                            return string.Format("{0}{1}", value, new string(' ', length - value.Length));
                        else
                            return value.Substring(0, length);
                    case "string-R":
                        if (length > value.Length)
                            return string.Format("{0}{1}", new string(' ', length - value.Length), value);
                        else
                            return value.Substring(0, length);
                    default:
                        return value.Substring(0, length);
                }
            }
            else
                return "";

        }

        private void CreerFichierDASEmployeur_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session session = ((XPObjectSpace)ObjectSpace).Session;

            MemoryStream s = new MemoryStream();
            TextWriter tw = new StreamWriter(s) { AutoFlush = true };
            TextReader tr = new StreamReader(s);

            foreach (DAS_G das_g in e.SelectedObjects)
            {

                //Entête de la remise***************************************************************************************

                if (das_g.Num_employeur != null)
                    tw.Write(champsTexte(das_g.Num_employeur.Replace(" ", ""), "string", 10));
                else
                    tw.Write(champsTexte("", "string", 10));

                tw.Write(champsTexte(das_g.Type_dec.ToString(), "string", 1));
                tw.Write(champsTexte(string.Format("{0:yyyy}", das_g.date), "string", 4));

                if (das_g.Centr_Payeur != null)
                    tw.Write(champsTexte(das_g.Centr_Payeur.Replace(" ", ""), "string", 5));
                else
                    tw.Write(champsTexte("", "string", 5));

                tw.Write(champsTexte(das_g.Denomination, "string", 30));
                tw.Write(champsTexte(das_g.Organisme_Fr, "string", 30));
                tw.Write(champsTexte(das_g.Adresse, "string", 50));
                long total_montant_tr1 = Convert.ToInt64(Convert.ToDouble(das_g.tot_montant_tr1) * 100);
                tw.Write(champsTexte(Convert.ToString(total_montant_tr1), "string", 16));
                long total_montant_tr2 = Convert.ToInt64(Convert.ToDouble(das_g.tot_montant_tr2) * 100);
                tw.Write(champsTexte(Convert.ToString(total_montant_tr2), "string", 16));
                long total_montant_tr3 = Convert.ToInt64(Convert.ToDouble(das_g.tot_montant_tr3) * 100);
                tw.Write(champsTexte(Convert.ToString(total_montant_tr3), "string", 16));
                long total_montant_tr4 = Convert.ToInt64(Convert.ToDouble(das_g.tot_montant_tr4) * 100);
                tw.Write(champsTexte(Convert.ToString(total_montant_tr4), "string", 16));
                long total_montant = Convert.ToInt64(Convert.ToDouble(das_g.tot_montant) * 100);
                tw.Write(champsTexte(Convert.ToString(total_montant), "string", 16));
                tw.Write(champsTexte(Convert.ToString(das_g.nombre_employes), "string", 6));

                s.Position = 0;
                das_g.text_DAS_Employeur = tr.ReadToEnd();
                das_g.Save();

                session.CommitTransaction();

                FolderBrowserDialog file_directory = new FolderBrowserDialog();
                if (file_directory.ShowDialog() == DialogResult.OK)
                {
                    string file_name = "";
                    if (das_g.Num_employeur == "")
                        MessageBox.Show("Le numéro employeur ne doit pas etre vide dans parametres");
                    else
                    {
                        file_name = string.Format("D{0:yy}E{1}.txt", das_g.date, das_g.Num_employeur.Replace(" ", ""));

                        //string Path = string.Format(@"{0}\{1}_{2}",file_directory.SelectedPath, das_g.Denomination,das_g.Num_employeur);
                        using (TextWriter sw = new StreamWriter(string.Format(@"{0}\{1}", file_directory.SelectedPath, file_name)))
                        {
                            sw.Write(das_g.text_DAS_Employeur);
                        }
                        Process.Start("explorer.exe", string.Format(@"/select, {0}\{1}", file_directory.SelectedPath, file_name));
                    }
                }
            }
        }

        private void EnvoyerDonneesVersDAS_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session session = ((XPObjectSpace)ObjectSpace).Session;
            parametre parametres = session.FindObject<parametre>(null);

            XPCollection<DAS_G> dasg = new XPCollection<DAS_G>(session);

            DAS_G das_g = new DAS_G(session);

            int code = Convert.ToInt16(session.Evaluate(typeof(DAS_G), CriteriaOperator.Parse("max(Code)"), null));
            das_g.Code = code + 1;

            das_g.date = DateTime.Now;

            if (!parametres.DeclarationMultiple)
            {
                das_g.Num_employeur = parametres.Num_employeur;
                das_g.Denomination = parametres.Denomination;
                das_g.Organisme_Fr = parametres.Organisme_Fr;
                das_g.Adresse = parametres.Adresse;
                das_g.Tlf = parametres.Tel;
                das_g.Type_dec = parametres.Type_dec;
                das_g.Centr_Payeur = parametres.Centr_Payeur;
            }

            int ordre = 0;
            int donne = -1;
            foreach (Recape_Annuelle recape in e.SelectedObjects)
            {
                das_g.NbrEntree += recape.Entree_Janv + recape.Entree_Fev + recape.Entree_Mars + recape.Entree_Avr + recape.Entree_Mai + recape.Entree_Juin
                    + recape.Entree_Juill + recape.Entree_Aout + recape.Entree_Oct + recape.Entree_Nouv + recape.Entree_Dec;

                das_g.NbrSortie += recape.Sortie_Janv + recape.Sortie_Fev + recape.Sortie_Mars + recape.Sortie_Avr + recape.Sortie_Mai + recape.Sortie_Juin
                    + recape.Sortie_Juill + recape.Sortie_Aout + recape.Sortie_Oct + recape.Sortie_Nouv + recape.Sortie_Dec;

                ordre += 1;
                Das_Personnes das_pers = new Das_Personnes(session);

                das_pers.Ordre = ordre;
                das_pers.Nom = recape.personne.FirstName;
                das_pers.Prenom = recape.personne.LastName;
                das_pers.Cod_personne = recape.personne.Cod_personne;
                das_pers.sexe = recape.personne.sexe;
                das_pers.Sit_fam = recape.personne.Sit_fam;
                das_pers.Adresse = recape.personne.Adresse_Fr;
                das_pers.Ville = recape.personne.Ville;
                das_pers.CodePostal = recape.personne.CodePostal;
                das_pers.NComptCCP = recape.personne.num_compte;
                das_pers.CleComptCCP = recape.personne.cle_compt;
                das_pers.NComptBanque = recape.personne.Num_CPP_Banque;
                das_pers.CleComptBanque = recape.personne.cle_CPP_Banqu;
                das_pers.Banque = recape.personne.Banque;
                das_pers.Nationalite = (Nationalite)recape.personne.Nationalite;
                das_pers.Etranger = recape.personne.Etranger;
                das_pers.LaFonction = recape.personne.LaFonction.Fct_Lib_Fr;
                das_pers.Date_Naissance = recape.personne.Birthday;
                das_pers.Naissance_Présumé = recape.personne.Naissance_Présumé;
                das_pers.Lieu_nais = recape.personne.Lieu_nais;
                das_pers.Dat_entre = recape.personne.DateRecrutement;
                das_pers.Dat_sortie = recape.personne.Dat_sortie;
                das_pers.num_SecSoc = recape.personne.num_SecSoc;
                das_pers.Unit_mes = recape.personne.Unit_mes;
                das_pers.NCN = recape.personne.NCN;
                das_pers.IdNat = (Convert.ToInt16(recape.personne.Nationalite)).ToString();
                das_pers.Tlf = recape.personne.Tlf;
                das_pers.Email = recape.personne.Email;

                if (parametres.DeclarationMultiple)
                {
                    if (donne == -1)
                        if (recape.personne.unite != null)
                        {
                            das_g.Num_employeur = recape.personne.unite.NumEmployeur;
                            das_g.Denomination = recape.personne.unite.Denomination;
                            das_g.Organisme_Fr = recape.personne.unite.Des_fr;
                            das_g.Adresse = recape.personne.unite.Adresse;
                            das_g.Tlf = recape.personne.unite.Tel;
                            das_g.Type_dec = recape.personne.unite.TypeDeclaration;
                            das_g.Centr_Payeur = recape.personne.unite.CentrePayeur;

                            donne = 1;
                        }
                }

                das_pers.DAS_G = das_g;
                if (das_pers.Unit_mes == unit_mes.M)
                {
                    double nbrtr1 = (recape.Nbr_jour_ouv_Janv + recape.Nbr_jour_ouv_Fev + recape.Nbr_jour_ouv_Mars) - (recape.Nbr_jour_abs_Janv + recape.Nbr_jour_abs_Fev + recape.Nbr_jour_abs_Mars);
                    if (nbrtr1 != 0)
                    {
                        if (nbrtr1 / 30 <= 1)
                            das_pers.jrs_trv_tr1 = 1;
                        else
                            if (nbrtr1 / 30 <= 2)
                                das_pers.jrs_trv_tr1 = 2;
                            else
                                if (nbrtr1 / 30 <= 3)
                                    das_pers.jrs_trv_tr1 = 3;
                    }
                    else
                        das_pers.jrs_trv_tr1 = 0;

                    double nbrtr2 = (recape.Nbr_jour_ouv_Avr + recape.Nbr_jour_ouv_Mai + recape.Nbr_jour_ouv_Juin) - (recape.Nbr_jour_abs_Avr + recape.Nbr_jour_abs_Mai + recape.Nbr_jour_abs_Juin);
                    if (nbrtr2 != 0)
                    {
                        if (nbrtr2 / 30 <= 1)
                            das_pers.jrs_trv_tr2 = 1;
                        else
                            if (nbrtr2 / 30 <= 2)
                                das_pers.jrs_trv_tr2 = 2;
                            else
                                if (nbrtr2 / 30 <= 3)
                                    das_pers.jrs_trv_tr2 = 3;
                    }
                    else
                        das_pers.jrs_trv_tr2 = 0;

                    double nbrtr3 = (recape.Nbr_jour_ouv_Juill + recape.Nbr_jour_ouv_Aout + recape.Nbr_jour_ouv_Sept) - (recape.Nbr_jour_abs_Juill + recape.Nbr_jour_abs_Aout + recape.Nbr_jour_abs_Sept);
                    if (nbrtr3 != 0)
                    {
                        if (nbrtr3 / 30 <= 1)
                            das_pers.jrs_trv_tr3 = 1;
                        else
                            if (nbrtr3 / 30 <= 2)
                                das_pers.jrs_trv_tr3 = 2;
                            else
                                if (nbrtr3 / 30 <= 3)
                                    das_pers.jrs_trv_tr3 = 3;
                    }
                    else
                        das_pers.jrs_trv_tr3 = 0;

                    double nbrtr4 = (recape.Nbr_jour_ouv_Oct + recape.Nbr_jour_ouv_Nouv + recape.Nbr_jour_ouv_Dec) - (recape.Nbr_jour_abs_Oct + recape.Nbr_jour_abs_Nouv + recape.Nbr_jour_abs_Dec);
                    if (nbrtr4 != 0)
                    {
                        if (nbrtr4 / 30 <= 1)
                            das_pers.jrs_trv_tr4 = 1;
                        else
                            if (nbrtr4 / 30 <= 2)
                                das_pers.jrs_trv_tr4 = 2;
                            else
                                if (nbrtr4 / 30 <= 3)
                                    das_pers.jrs_trv_tr4 = 3;
                    }
                    else
                        das_pers.jrs_trv_tr4 = 0;
                }
                else
                {
                    das_pers.jrs_trv_tr1 = (recape.Nbr_jour_ouv_Janv + recape.Nbr_jour_ouv_Fev + recape.Nbr_jour_ouv_Mars) - (recape.Nbr_jour_abs_Janv + recape.Nbr_jour_abs_Fev + recape.Nbr_jour_abs_Mars);
                    das_pers.jrs_trv_tr2 = (recape.Nbr_jour_ouv_Avr + recape.Nbr_jour_ouv_Mai + recape.Nbr_jour_ouv_Juin) - (recape.Nbr_jour_abs_Avr + recape.Nbr_jour_abs_Mai + recape.Nbr_jour_abs_Juin);
                    das_pers.jrs_trv_tr3 = (recape.Nbr_jour_ouv_Juill + recape.Nbr_jour_ouv_Aout + recape.Nbr_jour_ouv_Sept) - (recape.Nbr_jour_abs_Juill + recape.Nbr_jour_abs_Aout + recape.Nbr_jour_abs_Sept);
                    das_pers.jrs_trv_tr4 = (recape.Nbr_jour_ouv_Oct + recape.Nbr_jour_ouv_Nouv + recape.Nbr_jour_ouv_Dec) - (recape.Nbr_jour_abs_Oct + recape.Nbr_jour_abs_Nouv + recape.Nbr_jour_abs_Dec);
                }

                das_pers.montant_tr1 = recape.Brut_Cotis_Janv + recape.Brut_Cotis_Fev + recape.Brut_Cotis_Mars;
                das_pers.montant_tr2 = recape.Brut_Cotis_Avr + recape.Brut_Cotis_Mai + recape.Brut_Cotis_Juin;
                das_pers.montant_tr3 = recape.Brut_Cotis_Juill + recape.Brut_Cotis_Aout + recape.Brut_Cotis_Sept;
                das_pers.montant_tr4 = recape.Brut_Cotis_Oct + recape.Brut_Cotis_Nouv + recape.Brut_Cotis_Dec;

                das_pers.Save();
            }
            session.CommitTransaction();
            das_g.Save();
            das_g.calcul();
            das_g.Save();
            session.CommitTransaction();
        }

        private void AjouterIndemPaye_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            foreach (Paye Paye in e.SelectedObjects)
            {
                Session Session = ((XPObjectSpace)this.ObjectSpace).Session;

                string code = e.ParameterCurrentValue.ToString();

                Indem Indemnite = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", code));

                if (Indemnite != null)
                {
                    CriteriaOperator criteria1 = CriteriaOperator.Parse("Indemnite==?", Indemnite);
                    CriteriaOperator criteria2 = CriteriaOperator.Parse("Paye==?", Paye.Oid);
                    XPCollection<paye_indem> payeindem = new XPCollection<paye_indem>(Session, CriteriaOperator.And(criteria1, criteria2));

                    if (payeindem == null)
                    {
                        paye_indem IndemniteAInserer = new paye_indem(Session);
                        IndemniteAInserer.Indemnite = Indemnite;
                        IndemniteAInserer.Paye = Paye;

                        payeindem.Add(IndemniteAInserer);
                        Paye.Save();
                    }
                    else
                    {
                        Session.Delete(payeindem);
                        Session.Save(payeindem);

                        paye_indem IndemniteAInserer = new paye_indem(Session);
                        IndemniteAInserer.Indemnite = Indemnite;
                        IndemniteAInserer.Paye = Paye;

                        payeindem.Add(IndemniteAInserer);
                        Paye.Save();
                    }

                    Session.CommitTransaction();
                }
                else
                    MessageBox.Show("L'indemnité '" + code + "' n'existe pas !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AjouterIndemFonction_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            foreach (Fonction Fonction in e.SelectedObjects)
            {
                Session Session = ((XPObjectSpace)this.ObjectSpace).Session;

                string code = e.ParameterCurrentValue.ToString();

                Indem Indemnite = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", code));

                if (Indemnite != null)
                {
                    CriteriaOperator criteria1 = CriteriaOperator.Parse("Indem==?", Indemnite);
                    CriteriaOperator criteria2 = CriteriaOperator.Parse("Fonction==?", Fonction.Oid);
                    XPCollection<Indem_Fonction> IndemFonction = new XPCollection<Indem_Fonction>(Session, CriteriaOperator.And(criteria1, criteria2));

                    if (IndemFonction == null)
                    {
                        Indem_Fonction IndemniteAInserer = new Indem_Fonction(Session);
                        IndemniteAInserer.Indem = Indemnite;
                        IndemniteAInserer.Fonction = Fonction;

                        IndemFonction.Add(IndemniteAInserer);
                        Fonction.Save();
                    }
                    else
                    {
                        Session.Delete(IndemFonction);
                        Session.Save(IndemFonction);

                        Indem_Fonction IndemniteAInserer = new Indem_Fonction(Session);
                        IndemniteAInserer.Indem = Indemnite;
                        IndemniteAInserer.Fonction = Fonction;

                        IndemFonction.Add(IndemniteAInserer);
                        Fonction.Save();
                    }

                    Session.CommitTransaction();
                }
                else
                    MessageBox.Show("L'indemnité '" + code + "' n'existe pas !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AjouterIndemPersonne_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            foreach (Personne Personne in e.SelectedObjects)
            {
                Session Session = ((XPObjectSpace)this.ObjectSpace).Session;

                string code = e.ParameterCurrentValue.ToString();
                if (code != "")
                {
                    Indem Indemnite = Session.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", code));

                    if (Indemnite != null)
                    {
                        CriteriaOperator criteria1 = CriteriaOperator.Parse("Indem==?", Indemnite);
                        CriteriaOperator criteria2 = CriteriaOperator.Parse("Personne==?", Personne.Oid);
                        XPCollection<Indem_Personne> IndemPersonne = new XPCollection<Indem_Personne>(Session, CriteriaOperator.And(criteria1, criteria2));

                        if (IndemPersonne == null)
                        {
                            Indem_Personne IndemniteAInserer = new Indem_Personne(Session);
                            IndemniteAInserer.Indem = Indemnite;
                            IndemniteAInserer.Personne = Personne;

                            IndemPersonne.Add(IndemniteAInserer);
                            Personne.Save();
                        }
                        else
                        {
                            Session.Delete(IndemPersonne);
                            Session.Save(IndemPersonne);

                            Indem_Personne IndemniteAInserer = new Indem_Personne(Session);
                            IndemniteAInserer.Indem = Indemnite;
                            IndemniteAInserer.Personne = Personne;

                            IndemPersonne.Add(IndemniteAInserer);
                            Personne.Save();
                        }

                        Session.CommitTransaction();
                    }
                    else
                        MessageBox.Show("L'indemnité '" + code + "' n'existe pas !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Veuillez saisir l'indexe de l'indemnité à ajouter d'abord !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExporetrEtats_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();

            if (fd.ShowDialog() == DialogResult.OK)
            {
                foreach (ReportData report in e.SelectedObjects)
                {
                    string path = string.Format(" {0}\\{1}.repx", fd.SelectedPath, report.ReportName);
                    XtraReport rep = new XtraReport();

                    rep = report.LoadReport(ObjectSpace);
                    rep.SaveLayout(path);
                }
            }
        }

        private void CalculerBrouillardPaye_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            foreach (Personne selectedObject in e.SelectedObjects)
            {
                selectedObject.InitialisationPaye();
                selectedObject.CalculerPaye();
                selectedObject.BrouillardCalcule = true;
                selectedObject.Save();
            }
        }

        private void DupliquerPaye_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;

            int LeMoisAInserer = Convert.ToInt16(e.SelectedChoiceActionItem.Data);

            foreach (Paye Paye in e.SelectedObjects)
            {
                parametre Parametres = currentSession.FindObject<parametre>(null);
                string Chaine_Paye = Paye.personne.Cod_personne + Parametres.Annee_Travail + (MoisdelAnnee)LeMoisAInserer;
                Paye UnePaye = currentSession.FindObject<Paye>(CriteriaOperator.Parse("Chaine_Paye==?", Chaine_Paye));

                if (UnePaye == null)
                {
                    Paye CopiePaye = new Paye(currentSession);

                    foreach (PropertyInfo PayeProperty in typeof(Paye).GetProperties())
                    {
                        if (PayeProperty.Name != "Mois" && PayeProperty.Name != "Valide")
                            CopiePaye.SetMemberValue(PayeProperty.Name, Paye.GetMemberValue(PayeProperty.Name));
                    }
                    CopiePaye.Mois = (MoisdelAnnee)LeMoisAInserer;

                    foreach (paye_indem Indemnite in Paye.paye_indems)
                    {
                        if (Indemnite.Indemnite.Cod_indem_interne != "")
                        {
                            paye_indem IndemniteAInserer = new paye_indem(currentSession);
                            IndemniteAInserer.Indemnite = Indemnite.Indemnite;
                            IndemniteAInserer.IBase = Indemnite.IBase;
                            IndemniteAInserer.INbr = Indemnite.INbr;
                            IndemniteAInserer.ITaux = Indemnite.ITaux;
                            IndemniteAInserer.Montant = Indemnite.Montant;
                            IndemniteAInserer.Montant_Absence = Indemnite.Montant_Absence;
                            IndemniteAInserer.ModifSpecial = Indemnite.ModifSpecial;

                            CopiePaye.paye_indems.Add(IndemniteAInserer);
                        }
                    }
                }
                else
                {
                    Paye CopiePaye = new Paye(currentSession);

                    foreach (PropertyInfo PayeProperty in typeof(Paye).GetProperties())
                    {
                        if (PayeProperty.Name != "Mois" && PayeProperty.Name != "Valide")
                            CopiePaye.SetMemberValue(PayeProperty.Name, Paye.GetMemberValue(PayeProperty.Name));
                    }
                    CopiePaye.Mois = (MoisdelAnnee)LeMoisAInserer;
                    CopiePaye.Motif = "Paye dupliquée";

                    foreach (paye_indem Indemnite in Paye.paye_indems)
                    {
                        if (Indemnite.Indemnite.Cod_indem_interne != "")
                        {
                            paye_indem IndemniteAInserer = new paye_indem(currentSession);
                            IndemniteAInserer.Indemnite = Indemnite.Indemnite;
                            IndemniteAInserer.IBase = Indemnite.IBase;
                            IndemniteAInserer.INbr = Indemnite.INbr;
                            IndemniteAInserer.ITaux = Indemnite.ITaux;
                            IndemniteAInserer.Montant = Indemnite.Montant;
                            IndemniteAInserer.Montant_Absence = Indemnite.Montant_Absence;
                            IndemniteAInserer.ModifSpecial = Indemnite.ModifSpecial;

                            CopiePaye.paye_indems.Add(IndemniteAInserer);
                        }
                    }
                }
            }

            this.View.Refresh();
            currentSession.CommitTransaction();
        }

        private void DupliqueRappel_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;

            string chaine = e.ParameterCurrentValue.ToString();

            string code = "";
            string num = "";
            bool ok = true;
            int i = 0;

            while (i <= chaine.Length - 1 && ok == true)
            {
                if (chaine[i] != '/')
                {
                    code += chaine[i];
                }
                else
                    ok = false;
                i += 1;
            }

            for (i = code.Length + 1; i <= chaine.Length - 1; i++)
                num += chaine[i];

            foreach (Rappel Rappel in e.SelectedObjects)
            {
                Rappel UnRappel = currentSession.FindObject<Rappel>(CriteriaOperator.Parse("Cod_Rappel_Personne==?", code));
                if (UnRappel == null)
                {
                    Rappel CopieRappel = new Rappel(currentSession);

                    foreach (PropertyInfo RappelProperty in typeof(Rappel).GetProperties())
                    {
                        if (RappelProperty.Name != "Cod_Rappel" || RappelProperty.Name != "Num_Situation" || RappelProperty.Name != "code")
                            CopieRappel.SetMemberValue(RappelProperty.Name, Rappel.GetMemberValue(RappelProperty.Name));
                    }

                    CopieRappel.Cod_Rappel = code;
                    CopieRappel.Cod_Rappel_Personne = chaine + Rappel.Personne.Cod_personne;

                    foreach (Rappel_indem Indemnite in Rappel.Rappel_indems)
                    {
                        if (Indemnite.Indemnite.Cod_indem_interne != "")
                        {
                            Rappel_indem IndemniteAInserer = new Rappel_indem(currentSession);
                            IndemniteAInserer.Indemnite = Indemnite.Indemnite;
                            IndemniteAInserer.Montant_Ancien = Indemnite.Montant_Ancien;
                            IndemniteAInserer.Montant_Nouveau = Indemnite.Montant_Nouveau;
                            IndemniteAInserer.Montant_Dif = Indemnite.Montant_Dif;
                            IndemniteAInserer.Montant_Mois = Indemnite.Montant_Mois;

                            CopieRappel.Rappel_indems.Add(IndemniteAInserer);

                        }
                    }
                }
                else
                {
                    Rappel CopieRappel = new Rappel(currentSession);

                    foreach (PropertyInfo RappelProperty in typeof(Rappel).GetProperties())
                    {
                        if (RappelProperty.Name != "Cod_Rappel" || RappelProperty.Name != "Num_Situation" || RappelProperty.Name != "code")
                            CopieRappel.SetMemberValue(RappelProperty.Name, Rappel.GetMemberValue(RappelProperty.Name));
                    }

                    CopieRappel.Cod_Rappel = code;
                    CopieRappel.Cod_Rappel_Personne = chaine + Rappel.Personne.Cod_personne;
                    CopieRappel.Observation = "Rappel dupliqué";

                    foreach (Rappel_indem Indemnite in Rappel.Rappel_indems)
                    {
                        if (Indemnite.Indemnite.Cod_indem_interne != "")
                        {
                            Rappel_indem IndemniteAInserer = new Rappel_indem(currentSession);
                            IndemniteAInserer.Indemnite = Indemnite.Indemnite;
                            IndemniteAInserer.Montant_Ancien = Indemnite.Montant_Ancien;
                            IndemniteAInserer.Montant_Nouveau = Indemnite.Montant_Nouveau;
                            IndemniteAInserer.Montant_Dif = Indemnite.Montant_Dif;
                            IndemniteAInserer.Montant_Mois = Indemnite.Montant_Mois;

                            CopieRappel.Rappel_indems.Add(IndemniteAInserer);

                        }
                    }
                }
            }

            this.View.Refresh();
            currentSession.CommitTransaction();
        }

        public void ViderTable(string TableName, Session session)
        {
            string requete = "";
            if (TableName == "Paye")
                requete = string.Format(@"DELETE FROM [{0}] where GCRecord is not null
                                            and Oid not in (select Paye_Ancien FROM [Rappel])
                                            and Oid not in (select Paye_Nouveau FROM [Rappel])", TableName);
            else
                requete = string.Format(@"DELETE FROM [{0}] where  GCRecord is not null", TableName);

            SqlCommand sqlcommand = new SqlCommand(requete, (SqlConnection)session.Connection);
            sqlcommand.ExecuteNonQuery();
        }

        private void VideCorbeille_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session session = ((XPObjectSpace)ObjectSpace).Session;

            ViderTable("Rappel", session);
            ViderTable("Rappel_indem", session);
            ViderTable("Paye", session);
            ViderTable("paye_indem", session);
            ViderTable("Bordereau", session);
            ViderTable("Recapes_Janv", session);
            ViderTable("Recapes_Fev", session);
            ViderTable("Recapes_Mars", session);
            ViderTable("Recapes_Avr", session);
            ViderTable("Recapes_Mai", session);
            ViderTable("Recapes_Juin", session);
            ViderTable("Recapes_Juill", session);
            ViderTable("Recapes_Aout", session);
            ViderTable("Recapes_Sept", session);
            ViderTable("Recapes_Oct", session);
            ViderTable("Recapes_Nouv", session);
            ViderTable("Recapes_Dec", session);
            ViderTable("Recape_Annuelle", session);
        }

        private void GenererFormule_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            Session session = ((XPObjectSpace)ObjectSpace).Session;
            int Choix = Convert.ToInt16(e.SelectedChoiceActionItem.Data);
            foreach (Indem indem in e.SelectedObjects)
            {
                using (var GenererFormuleCalculForm = new GenererFormuleCalculForm(session, Choix))
                {
                    var result = GenererFormuleCalculForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        if (Choix == 1)
                            indem.Form_base = GenererFormuleCalculForm.FormuleIndem;
                        if (Choix == 2)
                            indem.Form_taux = GenererFormuleCalculForm.FormuleIndem + "*1.00";
                        if (Choix == 3)
                            indem.Form_nbr = GenererFormuleCalculForm.FormuleIndem + "*1.00";
                        if (Choix == 4)
                            indem.Form_cal = GenererFormuleCalculForm.FormuleIndem + "*1.00";
                    }
                }
            }
        }

        private void IndexeIndem_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            Session session = ((XPObjectSpace)ObjectSpace).Session;
            foreach (Indem indem in e.SelectedObjects)
            {
                indem.Cod_indem_interne = IndexeIndem.SelectedItem.Data.ToString();
                indem.Save();
            }
        }

        private void InsererConge_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;
            parametre Parametres = currentSession.FindObject<parametre>(null);
            int LeMoisAInserer = Convert.ToInt16(e.SelectedChoiceActionItem.Data);
            string mois = e.SelectedChoiceActionItem.Data.ToString();

            Cloture Cloture = currentSession.FindObject<Cloture>(CriteriaOperator.Parse("Cod_Cloture==?", mois + Parametres.Annee_Travail.ToString()));
            if ((Cloture == null) || (Cloture != null && Cloture.Est_Cloture == false))
            {
                if (Cloture == null)
                {
                    Cloture cloture = new Cloture(currentSession);
                    cloture.Cod_Cloture = mois + Parametres.Annee_Travail.ToString();
                    cloture.Mois = (MoisdelAnnee)LeMoisAInserer;
                    cloture.Annee = Parametres.Annee_Travail.ToString();
                    cloture.Est_Cloture = false;
                    cloture.Save();
                }

                foreach (Personne Employe in e.SelectedObjects)
                {
                    string Chaine_Conge = Employe.Cod_personne + Parametres.Annee_Travail + (MoisdelAnnee)LeMoisAInserer + " Congé";
                    CriteriaOperator criteria = CriteriaOperator.Parse("Chaine_Paye==?", Chaine_Conge);
                    Paye Conge = currentSession.FindObject<Paye>(CriteriaOperator.Parse("Chaine_Paye==?", Chaine_Conge));

                    if (Conge != null)
                    {
                        Conge.Delete();
                        Paye UnConge;
                        UnConge = new Paye(currentSession);

                        UnConge.personne = Employe;
                        UnConge.Mois = (MoisdelAnnee)LeMoisAInserer;
                        UnConge.Cod_paye = Employe.Cod_personne + "/" + UnConge.Mois.ToString();
                        UnConge.Chaine_Paye = Chaine_Conge;
                        UnConge.cat_paye = CategoriePaye.Congé;
                        UnConge.Save();
                        UnConge.InitialisationPaye();
                        if (Employe.Nbr_Jrs_Cong_Accor > 30)
                            UnConge.Inserer_Indem_Conge(30);
                        else
                            UnConge.Inserer_Indem_Conge(Employe.Nbr_Jrs_Cong_Accor);
                        UnConge.Save();
                        currentSession.CommitTransaction();
                        UnConge.CalculerPaye();
                        UnConge.Save();
                    }
                    else
                    {
                        Paye UnConge;
                        UnConge = new Paye(currentSession);

                        UnConge.personne = Employe;
                        UnConge.Mois = (MoisdelAnnee)LeMoisAInserer;
                        UnConge.Cod_paye = Employe.Cod_personne + "/" + UnConge.Mois.ToString();
                        UnConge.Chaine_Paye = Chaine_Conge;
                        UnConge.cat_paye = CategoriePaye.Congé;
                        UnConge.Save();
                        UnConge.InitialisationPaye();
                        if (Employe.Nbr_Jrs_Cong_Accor > 30)
                            UnConge.Inserer_Indem_Conge(30);
                        else
                            UnConge.Inserer_Indem_Conge(Employe.Nbr_Jrs_Cong_Accor);
                        UnConge.Save();
                        currentSession.CommitTransaction();
                        UnConge.CalculerPaye();
                        UnConge.Save();
                    }
                }
            }
            else
                MessageBox.Show("La paye du ce mois a été cloturée");
            currentSession.CommitTransaction();
        }

        private void InsererSTC_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {

            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;
            parametre Parametres = currentSession.FindObject<parametre>(null);
            int LeMoisAInserer = Convert.ToInt16(e.SelectedChoiceActionItem.Data);
            string mois = e.SelectedChoiceActionItem.Data.ToString();

            Cloture Cloture = currentSession.FindObject<Cloture>(CriteriaOperator.Parse("Cod_Cloture==?", mois + Parametres.Annee_Travail.ToString()));
            if ((Cloture == null) || (Cloture != null && Cloture.Est_Cloture == false))
            {
                if (Cloture == null)
                {
                    Cloture cloture = new Cloture(currentSession);
                    cloture.Cod_Cloture = mois + Parametres.Annee_Travail.ToString();
                    cloture.Mois = (MoisdelAnnee)LeMoisAInserer;
                    cloture.Annee = Parametres.Annee_Travail.ToString();
                    cloture.Est_Cloture = false;
                    cloture.Save();
                }

                foreach (Personne Employe in e.SelectedObjects)
                {
                    string Chaine_STC = Employe.Cod_personne + Parametres.Annee_Travail + (MoisdelAnnee)LeMoisAInserer + " STC";
                    CriteriaOperator criteria = CriteriaOperator.Parse("Chaine_Paye==?", Chaine_STC);
                    Paye STC = currentSession.FindObject<Paye>(CriteriaOperator.Parse("Chaine_Paye==?", Chaine_STC));

                    if (STC != null)
                    {
                        STC.Delete();
                        Paye UnSTC;
                        UnSTC = new Paye(currentSession);

                        UnSTC.personne = Employe;
                        UnSTC.Mois = (MoisdelAnnee)LeMoisAInserer;
                        UnSTC.Cod_paye = Employe.Cod_personne + "/" + UnSTC.Mois.ToString();
                        UnSTC.Chaine_Paye = Chaine_STC;
                        UnSTC.cat_paye = CategoriePaye.Solde_tout_Compte;
                        UnSTC.Save();
                        UnSTC.InitialisationPaye();
                        UnSTC.Inserer_Indem_STC();
                        UnSTC.Save();
                        currentSession.CommitTransaction();
                        UnSTC.CalculerPaye();
                        UnSTC.Save();
                    }
                    else
                    {
                        Paye UnSTC;
                        UnSTC = new Paye(currentSession);

                        UnSTC.personne = Employe;
                        UnSTC.Mois = (MoisdelAnnee)LeMoisAInserer;
                        UnSTC.Cod_paye = Employe.Cod_personne + "/" + UnSTC.Mois.ToString();
                        UnSTC.Chaine_Paye = Chaine_STC;
                        UnSTC.cat_paye = CategoriePaye.Solde_tout_Compte;
                        UnSTC.Save();
                        UnSTC.InitialisationPaye();
                        UnSTC.Inserer_Indem_STC();
                        UnSTC.Save();
                        currentSession.CommitTransaction();
                        UnSTC.CalculerPaye();
                        UnSTC.Save();
                    }
                }
            }
            else
                MessageBox.Show("La paye du ce mois a été cloturée");
            currentSession.CommitTransaction();
        }

        private void CreerFichierDASCacobatph_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session session = ((XPObjectSpace)ObjectSpace).Session;
            parametre parametres = session.FindObject<parametre>(null);

            MemoryStream s = new MemoryStream();
            TextWriter tw = new StreamWriter(s) { AutoFlush = true };
            TextReader tr = new StreamReader(s);

            DAS_G das_g = (DAS_G)e.CurrentObject;

            //1 ere ligne *************************************************************************************** 
            tw.Write("DAS CACOBATPH VER 2.0");
            tw.WriteLine();

            //2 eme ligne *************************************************************************************** 
            if (das_g.Num_employeur != null)
                tw.Write(champsTexte(das_g.Num_employeur.Replace(" ", ""), "string", 8));
            else
                tw.Write(champsTexte("", "string", 8));

            tw.Write(champsTexte(das_g.date.Year.ToString(), "string", 4));
            tw.Write(champsTexte(das_g.Code.ToString(), "string", 2));

            //double total_montant = Convert.ToDouble(das_g.tot_montant);
            //tw.Write(champsTexte(Convert.ToString(total_montant), "string-R", 15));
            tw.Write(champsTexte(string.Format("{0:n2}", das_g.tot_montant).Replace(" ", ""), "string-R", 15));
            
            tw.Write(champsTexte(Convert.ToString(das_g.nombre_employes), "string-R", 5));
            tw.WriteLine();

            //lignes salariés ***************************************************************************************

            XPCollection<Das_Personnes> das_personne = new XPCollection<Das_Personnes>(session, CriteriaOperator.Parse("DAS_G=?", das_g));

            if (das_personne.Count > 0)
            {
                foreach (Das_Personnes dp in das_personne)
                {
                    if (dp.num_SecSoc != null && dp.num_SecSoc != "")
                        tw.Write(champsTexte(dp.num_SecSoc.Replace(" ", ""), "string", 12));
                    else
                        tw.Write(champsTexte("000000000000", "string", 12));

                    if (dp.Nom != "" && dp.Nom != null)
                        tw.Write(champsTexte(dp.Nom, "string", 30));
                    else
                        tw.Write(champsTexte("", "string", 30));

                    if (dp.Prenom != "" && dp.Prenom != null)
                        tw.Write(champsTexte(dp.Prenom, "string", 30));
                    else
                        tw.Write(champsTexte("", "string", 30));

                    if (dp.Sit_fam != null)
                    {
                        if ((dp.Sit_fam.Sit_Fam_Lib_Fr == Sit_Fam_FR.Celibataire) || (dp.Sit_fam.Sit_Fam_Lib_Fr == Sit_Fam_FR.Divorsé) || (dp.Sit_fam.Sit_Fam_Lib_Fr == Sit_Fam_FR.Veuf))
                            tw.Write(champsTexte("C", "string", 1));
                        else
                            tw.Write(champsTexte("M", "string", 1));
                    }
                    else
                        tw.Write(champsTexte("", "string", 1));

                    string presume = "";
                    if (dp.Naissance_Présumé == "" || dp.Naissance_Présumé == null)
                    {
                        tw.Write(champsTexte(string.Format("{0:dd/MM/yyyy}", dp.Date_Naissance), "string", 10));
                        presume = "N";
                    }
                    else
                    {
                        tw.Write(champsTexte(dp.Naissance_Présumé, "string", 10));
                        presume = "O";
                    }

                    if (dp.Lieu_nais != "" && dp.Lieu_nais != null)
                        tw.Write(champsTexte(dp.Lieu_nais, "string", 40));
                    else
                        tw.Write(champsTexte("", "string", 40));

                    if (dp.Adresse != "" && dp.Adresse != null)
                        tw.Write(champsTexte(dp.Adresse, "string", 50));
                    else
                        tw.Write(champsTexte("", "string", 50));

                    if (dp.Ville != "" && dp.Ville != null)
                        tw.Write(champsTexte(dp.Ville, "string", 50));
                    else
                        tw.Write(champsTexte("", "string", 50));

                    if (dp.CodePostal != "" && dp.CodePostal != null)
                        tw.Write(champsTexte(dp.CodePostal, "string", 5));
                    else
                        tw.Write(champsTexte("", "string", 5));

                    if (presume != "" && presume != null)
                        tw.Write(champsTexte(presume, "string", 1));
                    else
                        tw.Write(champsTexte("", "string", 1));

                    if (dp.Etranger == true)
                        tw.Write(champsTexte("O", "string", 1));
                    else
                        tw.Write(champsTexte("N", "string", 1));

                    if (dp.NComptCCP != "" && dp.NComptCCP != null)
                        tw.Write(champsTexte(dp.NComptCCP + dp.CleComptCCP, "string", 20));
                    else
                        tw.Write(champsTexte("", "string", 20));

                    if (dp.NComptBanque != "" && dp.NComptBanque != null)
                        tw.Write(champsTexte(dp.NComptBanque + dp.CleComptBanque, "string", 20));
                    else
                        tw.Write(champsTexte("", "string", 20));

                    if (dp.Banque != null)
                        tw.Write(champsTexte(dp.Banque.cod_banque, "string", 10));
                    else
                        tw.Write(champsTexte("", "string", 10));

                    if (dp.Banque != null)
                        tw.Write(champsTexte(dp.Banque.des_f, "string", 20));
                    else
                        tw.Write(champsTexte("", "string", 20));

                    if (dp.LaFonction != null)
                        tw.Write(champsTexte(dp.LaFonction, "string", 25));
                    else
                        tw.Write(champsTexte("", "string", 25));

                    //double totalmontant = Convert.ToDouble(dp.montant);
                    //tw.Write(champsTexte(Convert.ToString(totalmontant), "string-R", 15));
                    tw.Write(champsTexte(string.Format("{0:n2}", dp.montant).Replace(" ", ""), "string-R", 15));
                    tw.Write(champsTexte(Convert.ToString(dp.jrs_trv_tr), "string-R", 5));
                    tw.Write(champsTexte(Convert.ToString(dp.Unit_mes), "string", 1));

                    string ES = "";
                    if (dp.Dat_sortie != DateTime.MinValue)
                    {
                        tw.Write(champsTexte(string.Format("{0:dd/MM/yyyy}", dp.Dat_sortie), "string", 10));
                        ES = "S";
                    }
                    else
                        if (dp.Dat_entre != DateTime.MinValue)
                        {
                            tw.Write(champsTexte(string.Format("{0:dd/MM/yyyy}", dp.Dat_entre), "string", 10));
                            ES = "E";
                        }
                        else
                        {
                            tw.Write(champsTexte("", "string", 10));
                        }

                    tw.Write(champsTexte(ES, "string", 1));
                    if (dp.sexe != null)
                    {
                        if (dp.sexe.Sexe_Lib_Fr == Sexe_FR.Feminin)
                            tw.Write(champsTexte("F", "string", 1));
                        else
                            if (dp.sexe.Sexe_Lib_Fr == Sexe_FR.Masculin)
                                tw.Write(champsTexte("M", "string", 1));
                    }
                    else
                        tw.Write(champsTexte("", "string", 1));

                    if (dp.Tlf != "" && dp.Tlf != null)
                        tw.Write(champsTexte(dp.Tlf, "string", 10));
                    else
                        //tw.Write(champsTexte("0000000000", "string", 10));
                        tw.Write(champsTexte("", "string", 10));

                    if (dp.Email != "" && dp.Email != null)
                        tw.Write(champsTexte(dp.Email, "string", 40));
                    else
                        tw.Write(champsTexte("", "string", 40));

                    if (dp.NCN != "" && dp.NCN != null)
                        tw.Write(champsTexte(dp.NCN, "string", 15));
                    else
                        tw.Write(champsTexte("", "string", 15));

                    if (dp.IdNat != "" && dp.IdNat != null)
                        tw.Write(champsTexte(dp.IdNat, "int", 3));
                    else
                        tw.Write(champsTexte("", "int", 3));

                    tw.WriteLine();
                }
                s.Position = 0;

                das_g.text_DAS = tr.ReadToEnd();
                das_g.Save();

                session.CommitTransaction();


                FolderBrowserDialog file_directory = new FolderBrowserDialog();
                if (file_directory.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string file_name = "";
                    if (das_g.Num_employeur == "")
                        MessageBox.Show("Le numéro employeur ne doit pas etre vide dans parametres");
                    else
                    {
                        file_name = string.Format("{0}_DAS_{1}.txt", das_g.Num_employeur.Replace(" ", ""), DateTime.Now.Year.ToString());

                        using (TextWriter sw = new StreamWriter(string.Format(@"{0}\{1}", file_directory.SelectedPath, file_name)))
                        {
                            sw.Write(das_g.text_DAS);
                        }
                        Process.Start("explorer.exe", string.Format(@"/select, {0}\{1}", file_directory.SelectedPath, file_name));

                    }
                }
            }
            else
                MessageBox.Show("Aucun employé séléctionné !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void ImporterAbsences_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            Session session = ((XPObjectSpace)ObjectSpace).Session;
            parametre Parametres = session.FindObject<parametre>(null);
            int mois = Convert.ToInt16(e.SelectedChoiceActionItem.Data);

            ExcelReader excel_reader = new ExcelReader(new Session());
            DataTable dt = excel_reader.GetExcelTable(string.Empty);

            foreach (DataRow row in dt.Rows)
            {
                string matriculeP = row["MATPOINT"].ToString();
                string Nom = row["NOM"].ToString();
                string Prenom = row["PRENOM"].ToString();

                CriteriaOperator criteria1Emp = CriteriaOperator.Parse("Matricule_pointeuse==?", matriculeP);
                CriteriaOperator criteria2Emp = CriteriaOperator.Parse("FirstName==?", Nom);
                CriteriaOperator criteria3Emp = CriteriaOperator.Parse("LastName==?", Prenom);
                Personne Employe = session.FindObject<Personne>(CriteriaOperator.And(criteria1Emp, criteria2Emp, criteria3Emp));

                if (Employe != null)
                {
                    CriteriaOperator criteria1Paye = CriteriaOperator.Parse("personne==?", Employe);
                    CriteriaOperator criteria2Paye = CriteriaOperator.Parse("cat_paye==?", CategoriePaye.Paye_Mensuel);
                    CriteriaOperator criteria3Paye = CriteriaOperator.Parse("Mois==?", mois);
                    Paye paye = session.FindObject<Paye>(CriteriaOperator.And(criteria1Paye, criteria2Paye, criteria3Paye));

                    if (paye != null)
                    {
                        double p = 0, c = 0, cr = 0, ha = 0, hsup50 = 0, hsup75 = 0, hsup100 = 0, hsup150 = 0, hsup200 = 0, fc = 0;
                        int a = 0, m = 0, s = 0, ap = 0;

                        if (row["A"].ToString() != "")
                            a = int.Parse(row["A"].ToString()); // Absence

                        if (row["M"].ToString() != "")
                            m = int.Parse(row["M"].ToString()); // Maladie

                        if (row["S"].ToString() != "")
                            s = int.Parse(row["S"].ToString()); // Suspension

                        if (row["AP"].ToString() != "")
                            ap = int.Parse(row["AP"].ToString()); // Suspension

                        if (row["C"].ToString() != "")
                            c = double.Parse(row["C"].ToString()); // Congé

                        if (row["CR"].ToString() != "")
                            cr = double.Parse(row["CR"].ToString()); // Congé

                        if (row["FC"].ToString() != "")
                            fc = double.Parse(row["FC"].ToString()); // Fin contrat

                        if (row["HA"].ToString() != "")
                            ha = double.Parse(row["HA"].ToString()); // Congé

                        if (row["HSUP50"].ToString() != "")
                            hsup50 = double.Parse(row["HSUP50"].ToString()); // Heurs supplementaire 

                        if (row["HSUP75"].ToString() != "")
                            hsup75 = double.Parse(row["HSUP75"].ToString()); // Heurs supplementaire

                        if (row["HSUP100"].ToString() != "")
                            hsup100 = double.Parse(row["HSUP100"].ToString()); // Heurs supplementaire

                        if (row["HSUP150"].ToString() != "")
                            hsup150 = double.Parse(row["HSUP150"].ToString()); // Heurs supplementaire

                        if (row["HSUP200"].ToString() != "")
                            hsup200 = double.Parse(row["HSUP200"].ToString()); // Heurs supplementaire

                        p = paye.Nbr_jour_tra - (a + m + s);
                        if (p != paye.Nbr_Jrs_Pres)
                        {
                            paye.personne.Nbr_Jrs_Cong_Accor -= (paye.Nbr_Jrs_Pres * Parametres.NbrJrsCRPrJrsTrv) / Parametres.NbrJrsTrvPrJrsCR;
                            paye.Nbr_Jrs_Pres = p;
                            paye.personne.Nbr_Jrs_Cong_Accor += (p * Parametres.NbrJrsCRPrJrsTrv) / Parametres.NbrJrsTrvPrJrsCR;
                        }
                        paye.Nbr_jour_abs_autre = (int)a;
                        paye.Nbr_jour_abs_maladie = (int)m;
                        paye.Nbr_jour_abs_mise_a_pieds = (int)s;
                        paye.Nbr_jour_abs_prime = (int)ap;
                        paye.Nbr_heure_abs = ha;
                        paye.Nbr_heure_50 = hsup50;
                        paye.Nbr_heure_75 = hsup75;
                        paye.Nbr_heure_100 = hsup100;
                        paye.Nbr_heure_150 = hsup150;
                        paye.Nbr_heure_200 = hsup200;
                        paye.Nbr_Jrs_Cong_Recup = cr;
                        paye.Nbr_Jrs_Cong = c;

                        CriteriaOperator criteria1PMG = CriteriaOperator.Parse("Employe==?", Employe);
                        CriteriaOperator criteria2PMG = CriteriaOperator.Parse("Mois==?", mois);
                        PrimePMG PMG = session.FindObject<PrimePMG>(CriteriaOperator.And(criteria1PMG, criteria2PMG));

                        if (PMG == null)
                        {
                            PrimePMG PrimePMG = new PrimePMG(session);
                            PrimePMG.Mois = (MoisdelAnnee)mois;
                            PrimePMG.Employe = Employe;
                            int i = 1;
                            while (i <= 31)
                            {
                                string name = string.Format("PMG{0}", i);
                                PMGMois pmgmois = new PMGMois(session);
                                pmgmois.JourMois = i;

                                if (row[name].ToString() != "")
                                    pmgmois.Nbr = double.Parse(row[name].ToString());

                                pmgmois.Save();
                                PrimePMG.pMGMois.Add(pmgmois);
                                PrimePMG.Save();

                                i += 1;
                            }
                        }
                        else
                        {
                            XPCollection<PMGMois> colDelete = new XPCollection<PMGMois>(session, CriteriaOperator.Parse("PrimePMG=?", PMG));
                            session.Delete(colDelete);
                            session.CommitTransaction();

                            int i = 1;
                            while (i <= 31)
                            {
                                string name = string.Format("PMG{0}", i);
                                PMGMois pmgmois = new PMGMois(session);
                                pmgmois.JourMois = i;

                                if (row[name].ToString() != "")
                                    pmgmois.Nbr = double.Parse(row[name].ToString());

                                pmgmois.Save();
                                PMG.pMGMois.Add(pmgmois);
                                PMG.Save();

                                i += 1;
                            }
                        }

                        CriteriaOperator criteria1ShiftNuit = CriteriaOperator.Parse("Employe==?", Employe);
                        CriteriaOperator criteria2ShiftNuit = CriteriaOperator.Parse("Mois==?", mois);
                        PrimeShiftNuit ShiftNuit = session.FindObject<PrimeShiftNuit>(CriteriaOperator.And(criteria1ShiftNuit, criteria2ShiftNuit));

                        if (ShiftNuit == null)
                        {
                            PrimeShiftNuit PrimeShiftNuit = new PrimeShiftNuit(session);
                            PrimeShiftNuit.Mois = (MoisdelAnnee)mois;
                            PrimeShiftNuit.Employe = Employe;
                            int i = 1;
                            while (i <= 31)
                            {
                                string name = string.Format("ShiftNuit{0}", i);
                                ShiftNuitMois ShiftNuitmois = new ShiftNuitMois(session);
                                ShiftNuitmois.JourMois = i;

                                if (row[name].ToString() != "")
                                    ShiftNuitmois.Nbr = double.Parse(row[name].ToString());

                                ShiftNuitmois.Save();
                                PrimeShiftNuit.shiftNuitMois.Add(ShiftNuitmois);
                                PrimeShiftNuit.Save();

                                i += 1;
                            }
                        }
                        else
                        {
                            XPCollection<ShiftNuitMois> colDelete = new XPCollection<ShiftNuitMois>(session, CriteriaOperator.Parse("PrimeShiftNuit=?", ShiftNuit));
                            session.Delete(colDelete);
                            session.CommitTransaction();

                            int i = 1;
                            while (i <= 31)
                            {
                                string name = string.Format("ShiftNuit{0}", i);
                                ShiftNuitMois ShiftNuitmois = new ShiftNuitMois(session);
                                ShiftNuitmois.JourMois = i;

                                if (row[name].ToString() != "")
                                    ShiftNuitmois.Nbr = double.Parse(row[name].ToString());

                                ShiftNuitmois.Save();
                                ShiftNuit.shiftNuitMois.Add(ShiftNuitmois);
                                ShiftNuit.Save();

                                i += 1;
                            }
                        }

                        paye.CalculerPaye();
                        paye.Save();
                    }
                }
                session.CommitTransaction();
            }
            MessageBox.Show("Pointage importé!", "Importation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CalculerPayeInverse_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;
            parametre Parametres = currentSession.FindObject<parametre>(null);
            CalculInverse CalculInverse = new CalculInverse(Parametres.Mode_Arrondi, Parametres.Taux_ss, currentSession);
            CalculInverse.Show();
        }

        private void ValiderPaye_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session session = new Session();

            foreach (Paye paye in e.SelectedObjects)
            {
                if (!paye.Valide)
                {
                    if (paye.cat_paye == CategoriePaye.Paye_Mensuel)
                        if (paye.NbrJrsCRPrJrsTrv != 0 && paye.NbrJrsTrvPrJrsCR != 0)
                            paye.Calculer_Nbr_Jrs_Conge_Recup(true);
                    paye.Valide = true;
                    paye.Save();
                }
            }
        }

        private void DevaliderPaye_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session session = new Session();

            foreach (Paye paye in e.SelectedObjects)
            {
                if (paye.Valide)
                {
                    if (paye.cat_paye == CategoriePaye.Paye_Mensuel)
                        if (paye.NbrJrsCRPrJrsTrv != 0 && paye.NbrJrsTrvPrJrsCR != 0)
                            paye.Calculer_Nbr_Jrs_Conge_Recup(false);
                    paye.Valide = false;
                    paye.Save();
                }
            }
        }

        private void CreerFichedePaye_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;
            int yes = 0;
            parametre Parametres = currentSession.FindObject<parametre>(null);
            int LeMoisAInserer = Convert.ToInt16(e.SelectedChoiceActionItem.Data);
            string mois = e.SelectedChoiceActionItem.Data.ToString();

            foreach (Rappel Rappel in e.SelectedObjects)
            {
                string Chaine_Paye = Rappel.Cod_Rappel + Rappel.Cod_personne + Parametres.Annee_Travail + (MoisdelAnnee)LeMoisAInserer;

                Paye paye = currentSession.FindObject<Paye>(CriteriaOperator.Parse("Chaine_Paye==?", Chaine_Paye));


                if (paye != null && yes == 0)
                {
                    DialogResult result = MessageBox.Show("Le Rappel de la personne : " + Rappel.Cod_personne + " / " + Rappel.Personne.FullName + ", exist déja dans la table Paye! Voulez vous l'écraser ?", "Avertissement", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        DialogResult result2 = MessageBox.Show("Voulez vous écraser tous ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result2 == DialogResult.Yes)
                            yes = 1;

                        paye.Delete();
                        Paye UnePaye;
                        UnePaye = new Paye(currentSession);

                        UnePaye.personne = Rappel.Personne;
                        UnePaye.cat_paye = CategoriePaye.Rappel;
                        UnePaye.Mois = (MoisdelAnnee)LeMoisAInserer;
                        UnePaye.Cod_paye = Rappel.Cod_Rappel + Rappel.Cod_personne + "/" + UnePaye.Mois.ToString();
                        UnePaye.Chaine_Paye = Chaine_Paye;
                        UnePaye.Save();
                        UnePaye.InitialisationPaye();
                        //UnePaye.InsererIndemnitePersonne();
                        UnePaye.InsererFicheRappel(Rappel);
                        currentSession.CommitTransaction();
                        //UnePaye.CalculerPaye(); 
                        UnePaye.Save();
                    }
                    else
                    {
                        Paye UnePaye;
                        UnePaye = new Paye(currentSession);

                        UnePaye.personne = Rappel.Personne;
                        UnePaye.cat_paye = CategoriePaye.Rappel;
                        UnePaye.Mois = (MoisdelAnnee)LeMoisAInserer;
                        UnePaye.Cod_paye = Rappel.Cod_personne + "/" + UnePaye.Mois.ToString();
                        UnePaye.Chaine_Paye = Chaine_Paye;
                        UnePaye.Save();
                        UnePaye.InitialisationPaye();
                        //UnePaye.InsererIndemnitePersonne();
                        UnePaye.InsererFicheRappel(Rappel);
                        currentSession.CommitTransaction();
                        //UnePaye.CalculerPaye();
                        UnePaye.Save();
                    }
                }
                else
                    if (paye != null && yes == 1)
                    {
                        paye.Delete();
                        Paye UnePaye;
                        UnePaye = new Paye(currentSession);

                        UnePaye.personne = Rappel.Personne;
                        UnePaye.cat_paye = CategoriePaye.Rappel;
                        UnePaye.Mois = (MoisdelAnnee)LeMoisAInserer;
                        UnePaye.Cod_paye = Rappel.Cod_personne + "/" + UnePaye.Mois.ToString();
                        UnePaye.Chaine_Paye = Chaine_Paye;
                        UnePaye.Save();
                        UnePaye.InitialisationPaye();
                        //UnePaye.InsererIndemnitePersonne();
                        UnePaye.InsererFicheRappel(Rappel);
                        currentSession.CommitTransaction();
                        //UnePaye.CalculerPaye();
                        UnePaye.Save();
                    }

                    else
                    {
                        Paye UnePaye;
                        UnePaye = new Paye(currentSession);

                        UnePaye.personne = Rappel.Personne;
                        UnePaye.cat_paye = CategoriePaye.Rappel;
                        UnePaye.Mois = (MoisdelAnnee)LeMoisAInserer;
                        UnePaye.Cod_paye = Rappel.Cod_personne + "/" + UnePaye.Mois.ToString();
                        UnePaye.Chaine_Paye = Chaine_Paye;
                        UnePaye.Save();
                        UnePaye.InitialisationPaye();
                        //UnePaye.InsererIndemnitePersonne();
                        UnePaye.InsererFicheRappel(Rappel);
                        currentSession.CommitTransaction();
                        //UnePaye.CalculerPaye();
                        UnePaye.Save();
                    }
            }
        }

        private void FiltrePaye_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            Session currentSession = ((XPObjectSpace)this.ObjectSpace).Session;
            parametre Parametres = currentSession.FindObject<parametre>(null);
            if ((View is DevExpress.ExpressApp.ListView) && (View.ObjectTypeInfo.Type == typeof(Paye)))
            {
                int LeMoisAInserer = Convert.ToInt16(e.SelectedChoiceActionItem.Data);
                if (LeMoisAInserer == 0)
                {
                    ((DevExpress.ExpressApp.ListView)View).CollectionSource.Criteria["Filter1"] = null;
                }
                else
                {
                    ((DevExpress.ExpressApp.ListView)View).CollectionSource.Criteria["Filter1"] =
                        new BinaryOperator("Mois", LeMoisAInserer.ToString(), BinaryOperatorType.Equal);
                }
            }
            ((DevExpress.ExpressApp.ListView)View).Refresh();
        }

        private void ImporterEtats_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session session = ((XPObjectSpace)this.ObjectSpace).Session;
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Etats | *.repx";
            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in of.FileNames)
                {
                    if (File.Exists(file))
                    {
                        ReportData rd = new ReportData(session);
                        XafReport rep = new XafReport();
                        rep.LoadLayout(file);
                        rd.SaveReport(rep);
                        rd.Save();
                        session.CommitTransaction();
                    }
                }
            }
        }

        private void simpleAction1_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session session = ((XPObjectSpace)this.ObjectSpace).Session;
            foreach (Paye paye in e.SelectedObjects)
            {
                XPCollection<paye_indem> PICollection = new XPCollection<paye_indem>(session, CriteriaOperator.Parse("Paye=?", paye));
                PICollection.Load();
                foreach (paye_indem pi in PICollection)
                {
                    Indem_Personne ipers = new Indem_Personne(session);
                    ipers.Indem = pi.Indemnite;
                    ipers.Base = pi.IBase;
                    ipers.Taux = pi.ITaux;
                    ipers.INbr = pi.INbr;
                    ipers.Montant = pi.Montant;
                    ipers.Personne = paye.personne;
                    ipers.Save();
                    paye.personne.Indem_Personnes.Add(ipers);
                    paye.personne.Save();
                }
                session.CommitTransaction();
            }
        }

        private void AppliquerEtatPourTousExercices_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session SessionSc = ((XPObjectSpace)this.ObjectSpace).Session;
            Session SessionDs = new Session();

            string db_name = "";
            if (Application.Connection is SQLiteConnection)
                db_name = ((SQLiteConnection)Application.Connection).DataSource;
            else
                if (Application.Connection is SqlConnection)
                    db_name = ((SqlConnection)Application.Connection).DataSource;
 
            using (var Dossiers_Exercices = new Dossiers_Exercices(SessionSc, false, db_name))
            {
                List<string> dossiers = new List<string>();
                List<string> exercices = new List<string>();

                var result = Dossiers_Exercices.ShowDialog();
                if (result == DialogResult.OK)
                {
                    dossiers = Dossiers_Exercices.dossiers;
                    exercices = Dossiers_Exercices.exercices;

                    if (lsactvtn.ActivationClass.réseau)
                    {
                        for (int i = 0; i < dossiers.Count; i++)
                        {
                            string ConnectionString = string.Format(@"Integrated Security=false;Pooling=false;Data Source={0}{1};
                                Initial Catalog={2}{3};User ID=sa;Password=58206670", Helper.serverName, Helper.instanceName, dossiers[i], exercices[i]);

                            SqlConnection ConnectionDs = new SqlConnection(ConnectionString);
                            SessionDs.Connection = ConnectionDs;

                            foreach (ReportData report in e.SelectedObjects)
                            {
                                ReportData newReportData = new ReportData(SessionDs);
                                XtraReport newXtraReport = new XtraReport();
                                ReportData oldReport = SessionDs.FindObject<ReportData>(CriteriaOperator.Parse("Name==?", report.ReportName));

                                if (oldReport != null)
                                {
                                    SessionDs.Delete(oldReport);

                                    newXtraReport = report.LoadReport(ObjectSpace);
                                    newReportData.SaveReport(newXtraReport);
                                    newReportData.IsInplaceReport = true;
                                    newReportData.Save();
                                }
                                else
                                {
                                    newXtraReport = report.LoadReport(ObjectSpace);
                                    newReportData.SaveReport(newXtraReport);
                                    newReportData.IsInplaceReport = true;
                                    newReportData.Save();
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dossiers.Count; i++)
                        {
                            string ConnectionString = string.Format(@"XpoProvider=SQLite;Data Source={0}\\Data\\{1}\\{1}{2}",
                                Core.GetApplicationPath(), dossiers[i], exercices[i]);
                            DbConnection ConnectionDs = new SQLiteConnection(ConnectionString);
                            SessionDs.Connection = ConnectionDs;

                            foreach (ReportData report in e.SelectedObjects)
                            {
                                ReportData newReportData = new ReportData(SessionDs);
                                XtraReport newXtraReport = new XtraReport();
                                ReportData oldReport = SessionDs.FindObject<ReportData>(CriteriaOperator.Parse("Name==?", report.ReportName));

                                if (oldReport != null)
                                {
                                    SessionDs.Delete(oldReport);

                                    newXtraReport = report.LoadReport(ObjectSpace);
                                    newReportData.SaveReport(newXtraReport);
                                    newReportData.IsInplaceReport = true;
                                    newReportData.Save();
                                }
                                else
                                {
                                    newXtraReport = report.LoadReport(ObjectSpace);
                                    newReportData.SaveReport(newXtraReport);
                                    newReportData.IsInplaceReport = true;
                                    newReportData.Save();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void CopierParametrageIndemnites_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session SessionSc = ((XPObjectSpace)this.ObjectSpace).Session;
            Session SessionDs = new Session();

            string db_name = "";
            if (Application.Connection is SQLiteConnection)
                db_name = ((SQLiteConnection)Application.Connection).DataSource;
            else
                if (Application.Connection is SqlConnection)
                    db_name = ((SqlConnection)Application.Connection).DataSource;

            using (var Dossiers_Exercices = new Dossiers_Exercices(SessionSc, true,db_name))
            {
                List<string> dossiers = new List<string>();
                List<string> exercices = new List<string>();
                List<string> parametresIndem = new List<string>();
                List<bool> valeures = new List<bool>();
                bool optionsAvancees = false;

                var result = Dossiers_Exercices.ShowDialog();
                if (result == DialogResult.OK)
                {
                    dossiers = Dossiers_Exercices.dossiers;
                    exercices = Dossiers_Exercices.exercices;

                    if (lsactvtn.ActivationClass.réseau)
                    {
                        for (int i = 0; i < dossiers.Count; i++)
                        {
                            string ConnectionString = string.Format(@"Integrated Security=false;Pooling=false;Data Source={0}{1};
                                Initial Catalog={2}{3};User ID=sa;Password=58206670", Helper.serverName, Helper.instanceName, dossiers[i], exercices[i]);
                            SqlConnection ConnectionDs = new SqlConnection(ConnectionString);
                            SessionDs.Connection = ConnectionDs;

                            if (optionsAvancees)
                            {
                                parametresIndem = Dossiers_Exercices.parametresIndem;
                                valeures = Dossiers_Exercices.valeures;

                                foreach (Indem Indem in e.SelectedObjects)
                                {
                                    Indem newIndem = new Indem(SessionDs);
                                    Indem oldIndem = SessionDs.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", Indem.Cod_indem_interne));

                                    if (oldIndem != null)
                                    {
                                        for (int j = 0; j < parametresIndem.Count; j++)
                                        {
                                            if (valeures[i] == true)
                                            {
                                                string champ = parametresIndem[j];
                                                oldIndem.SetMemberValue(champ, Indem.GetMemberValue(champ));
                                                oldIndem.Save();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int j = 0; j < parametresIndem.Count; j++)
                                        {
                                            if (valeures[i] == true)
                                            {
                                                string champ = parametresIndem[j];
                                                newIndem.SetMemberValue(champ, Indem.GetMemberValue(champ));
                                                newIndem.Cod_indem_interne = Indem.Cod_indem_interne;
                                                newIndem.Save();
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                parametresIndem = new List<string> { "Ordre_Affichage", "Code", "Cod_indem", "Lib_indem", "Cotisable", "Imposable",
                                    "Brut_Net_Incluse", "Mod_cal_irg", "Retenue", "Mode_Calcul_Absence", "Form_base", "Form_taux", "Form_nbr", 
                                    "Form_cal", "Compte_Comptable", "Compte_Debit", "Compte_Credit" };

                                foreach (Indem Indem in e.SelectedObjects)
                                {
                                    Indem newIndem = new Indem(SessionDs);
                                    Indem oldIndem = SessionDs.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", Indem.Cod_indem_interne));

                                    if (oldIndem != null)
                                    {
                                        for (int j = 0; j < parametresIndem.Count; j++)
                                        {
                                            string champ = parametresIndem[j];
                                            oldIndem.SetMemberValue(champ, Indem.GetMemberValue(champ));
                                            oldIndem.Save();
                                        }
                                    }
                                    else
                                    {
                                        for (int j = 0; j < parametresIndem.Count; j++)
                                        {
                                            string champ = parametresIndem[j];
                                            newIndem.SetMemberValue(champ, Indem.GetMemberValue(champ));
                                            newIndem.Cod_indem_interne = Indem.Cod_indem_interne;
                                            newIndem.Save();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dossiers.Count; i++)
                        {
                            string ConnectionString = string.Format(@"XpoProvider=SQLite;Data Source={0}\\Data\\{1}\\{1}{2}",
                                Core.GetApplicationPath(), dossiers[i], exercices[i]);
                            DbConnection ConnectionDs = new SQLiteConnection(ConnectionString);
                            SessionDs.Connection = ConnectionDs;

                            if (optionsAvancees)
                            {
                                foreach (Indem Indem in e.SelectedObjects)
                                {
                                    Indem newIndem = new Indem(SessionDs);
                                    Indem oldIndem = SessionDs.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", Indem.Cod_indem_interne));

                                    if (oldIndem != null)
                                    {
                                        for (int j = 0; j < parametresIndem.Count; j++)
                                        {
                                            if (valeures[i] == true)
                                            {
                                                string champ = parametresIndem[j];
                                                oldIndem.SetMemberValue(champ, Indem.GetMemberValue(champ));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int j = 0; j < parametresIndem.Count; j++)
                                        {
                                            if (valeures[i] == true)
                                            {
                                                string champ = parametresIndem[j];
                                                newIndem.SetMemberValue(champ, Indem.GetMemberValue(champ));
                                                newIndem.Cod_indem_interne = Indem.Cod_indem_interne;
                                                newIndem.Save();
                                            }
                                        }
                                    }
                                } 
                            }
                            else
                            {
                                parametresIndem = new List<string> { "Ordre_Affichage", "Code", "Cod_indem", "Lib_indem", "Cotisable", "Imposable",
                                    "Brut_Net_Incluse", "Mod_cal_irg", "Retenue", "Mode_Calcul_Absence", "Form_base", "Form_taux", "Form_nbr", 
                                    "Form_cal", "Compte_Comptable", "Compte_Debit", "Compte_Credit" };

                                foreach (Indem Indem in e.SelectedObjects)
                                {
                                    Indem newIndem = new Indem(SessionDs);
                                    Indem oldIndem = SessionDs.FindObject<Indem>(CriteriaOperator.Parse("Cod_indem_interne==?", Indem.Cod_indem_interne));

                                    if (oldIndem != null)
                                    {
                                        for (int j = 0; j < parametresIndem.Count; j++)
                                        {
                                            string champ = parametresIndem[j];
                                            oldIndem.SetMemberValue(champ, Indem.GetMemberValue(champ));
                                            oldIndem.Save();
                                        }
                                    }
                                    else
                                    {
                                        for (int j = 0; j < parametresIndem.Count; j++)
                                        {
                                            string champ = parametresIndem[j];
                                            newIndem.SetMemberValue(champ, Indem.GetMemberValue(champ));
                                            newIndem.Cod_indem_interne = Indem.Cod_indem_interne;
                                            newIndem.Save();
                                        }
                                    } 
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ViewController1_FrameAssigned(object sender, EventArgs e)
        {
        }

        private void aEnvoyerDonneesVersDASCacobatph_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session session = ((XPObjectSpace)ObjectSpace).Session;
            parametre parametres = session.FindObject<parametre>(null);

            //XPCollection<DAS_G> dasg = new XPCollection<DAS_G>(session);

            DAS_G das_g = new DAS_G(session);

            int code = Convert.ToInt16(session.Evaluate(typeof(DAS_G), CriteriaOperator.Parse("max(Code)"), null));
            das_g.Code = code + 1;

            das_g.date = DateTime.Now;

            if (!parametres.DeclarationMultiple)
            {
                das_g.Num_employeur = parametres.Num_employeur;
                das_g.Denomination = parametres.Denomination;
                das_g.Organisme_Fr = parametres.Organisme_Fr;
                das_g.Adresse = parametres.Adresse;
                das_g.Tlf = parametres.Tel;
                das_g.Type_dec = parametres.Type_dec;
                das_g.Centr_Payeur = parametres.Centr_Payeur;
            }

            int ordre = 0;
            int donne = -1;
            XPCollection<Recape_Annuelle> recapes = new XPCollection<Recape_Annuelle>(session);
            foreach (Recape_Annuelle recape in recapes)//e.SelectedObjects)
            {
                //Recape_Annuelle recapeN_1 = osN_1 != null ? osN_1.FindObject<Recape_Annuelle>(CriteriaOperator.Parse("Cod_Recape = ?", 
                //    string.Format("{0}{1}", recape.personne.Cod_personne, exerciceN_1.exercice))): null;
                das_g.NbrEntree += recape.Entree_Janv + recape.Entree_Fev + recape.Entree_Mars + recape.Entree_Avr + recape.Entree_Mai + recape.Entree_Juin;
                //if (recapeN_1 != null)
                //    das_g.NbrEntree += recapeN_1.Entree_Juill + recapeN_1.Entree_Aout + recapeN_1.Entree_Oct + recapeN_1.Entree_Nouv + recapeN_1.Entree_Dec;

                das_g.NbrSortie += recape.Sortie_Janv + recape.Sortie_Fev + recape.Sortie_Mars + recape.Sortie_Avr + recape.Sortie_Mai + recape.Sortie_Juin;
                //if (recapeN_1 != null)
                //    das_g.NbrSortie += recape.Sortie_Juill + recape.Sortie_Aout + recape.Sortie_Oct + recape.Sortie_Nouv + recape.Sortie_Dec;

                ordre += 1;
                Das_Personnes das_pers = new Das_Personnes(session)
                {
                    Ordre = ordre,
                    Nom = recape.personne.FirstName,
                    Prenom = recape.personne.LastName,
                    Cod_personne = recape.personne.Cod_personne,
                    sexe = recape.personne.sexe,
                    Sit_fam = recape.personne.Sit_fam,
                    Adresse = recape.personne.Adresse_Fr,
                    Ville = recape.personne.Ville,
                    CodePostal = recape.personne.CodePostal,
                    NComptCCP = recape.personne.num_compte,
                    CleComptCCP = recape.personne.cle_compt,
                    NComptBanque = recape.personne.Num_CPP_Banque,
                    CleComptBanque = recape.personne.cle_CPP_Banqu,
                    Banque = recape.personne.Banque,
                    Nationalite = (Nationalite)recape.personne.Nationalite,
                    Etranger = recape.personne.Etranger,
                    LaFonction = recape.personne.LaFonction.Fct_Lib_Fr,
                    Date_Naissance = recape.personne.Birthday,
                    Naissance_Présumé = recape.personne.Naissance_Présumé,
                    Lieu_nais = recape.personne.Lieu_nais,
                    Dat_entre = recape.personne.DateRecrutement,
                    Dat_sortie = recape.personne.Dat_sortie,
                    num_SecSoc = recape.personne.num_SecSoc,
                    Unit_mes = recape.personne.Unit_mes,
                    NCN = recape.personne.NCN,
                    IdNat = (Convert.ToInt16(recape.personne.Nationalite)).ToString(),
                    Tlf = recape.personne.Tlf,
                    Email = recape.personne.Email
                };

                if (parametres.DeclarationMultiple)
                {
                    if (donne == -1)
                        if (recape.personne.unite != null)
                        {
                            das_g.Num_employeur = recape.personne.unite.NumEmployeur;
                            das_g.Denomination = recape.personne.unite.Denomination;
                            das_g.Organisme_Fr = recape.personne.unite.Des_fr;
                            das_g.Adresse = recape.personne.unite.Adresse;
                            das_g.Tlf = recape.personne.unite.Tel;
                            das_g.Type_dec = recape.personne.unite.TypeDeclaration;
                            das_g.Centr_Payeur = recape.personne.unite.CentrePayeur;

                            donne = 1;
                        }
                }

                das_pers.DAS_G = das_g;
                if (das_pers.Unit_mes == unit_mes.M)
                {
                    //double nbrtr1 = recapeN_1 != null ? (recapeN_1.Nbr_jour_ouv_Juill + recapeN_1.Nbr_jour_ouv_Aout + recapeN_1.Nbr_jour_ouv_Sept) - (recapeN_1.Nbr_jour_abs_Juill + recapeN_1.Nbr_jour_abs_Aout + recapeN_1.Nbr_jour_abs_Sept) : 0;
                    //if (nbrtr1 != 0)
                    //{
                    //    if (nbrtr1 / 30 <= 1)
                    //        das_pers.jrs_trv_tr1 = 1;
                    //    else
                    //        if (nbrtr1 / 30 <= 2)
                    //            das_pers.jrs_trv_tr1 = 2;
                    //        else
                    //            if (nbrtr1 / 30 <= 3)
                    //                das_pers.jrs_trv_tr1 = 3;
                    //}
                    //else
                    //    das_pers.jrs_trv_tr1 = 0;

                    //double nbrtr2 = recapeN_1 != null ? (recapeN_1.Nbr_jour_ouv_Oct + recapeN_1.Nbr_jour_ouv_Nouv + recapeN_1.Nbr_jour_ouv_Dec) - (recapeN_1.Nbr_jour_abs_Oct + recapeN_1.Nbr_jour_abs_Nouv + recapeN_1.Nbr_jour_abs_Dec) : 0;
                    //if (nbrtr2 != 0)
                    //{
                    //    if (nbrtr2 / 30 <= 1)
                    //        das_pers.jrs_trv_tr2 = 1;
                    //    else
                    //        if (nbrtr2 / 30 <= 2)
                    //            das_pers.jrs_trv_tr2 = 2;
                    //        else
                    //            if (nbrtr2 / 30 <= 3)
                    //                das_pers.jrs_trv_tr2 = 3;
                    //}
                    //else
                    //    das_pers.jrs_trv_tr2 = 0;

                    double nbrtr3 = (recape.Nbr_jour_ouv_Janv + recape.Nbr_jour_ouv_Fev + recape.Nbr_jour_ouv_Mars) - (recape.Nbr_jour_abs_Janv + recape.Nbr_jour_abs_Fev + recape.Nbr_jour_abs_Mars);
                    if (nbrtr3 != 0)
                    {
                        if (nbrtr3 / 30 <= 1)
                            das_pers.jrs_trv_tr3 = 1;
                        else
                            if (nbrtr3 / 30 <= 2)
                                das_pers.jrs_trv_tr3 = 2;
                            else
                                if (nbrtr3 / 30 <= 3)
                                    das_pers.jrs_trv_tr3 = 3;
                    }
                    else
                        das_pers.jrs_trv_tr3 = 0;

                    double nbrtr4 = (recape.Nbr_jour_ouv_Avr + recape.Nbr_jour_ouv_Mai + recape.Nbr_jour_ouv_Juin) - (recape.Nbr_jour_abs_Avr + recape.Nbr_jour_abs_Mai + recape.Nbr_jour_abs_Juin);
                    if (nbrtr4 != 0)
                    {
                        if (nbrtr4 / 30 <= 1)
                            das_pers.jrs_trv_tr4 = 1;
                        else
                            if (nbrtr4 / 30 <= 2)
                                das_pers.jrs_trv_tr4 = 2;
                            else
                                if (nbrtr4 / 30 <= 3)
                                    das_pers.jrs_trv_tr4 = 3;
                    }
                    else
                        das_pers.jrs_trv_tr4 = 0;
                }
                else
                {
                    //das_pers.jrs_trv_tr1 = recapeN_1 != null ? (recapeN_1.Nbr_jour_ouv_Juill + recapeN_1.Nbr_jour_ouv_Aout + recapeN_1.Nbr_jour_ouv_Sept) - (recapeN_1.Nbr_jour_abs_Juill + recapeN_1.Nbr_jour_abs_Aout + recapeN_1.Nbr_jour_abs_Sept) : 0;
                    //das_pers.jrs_trv_tr2 = recapeN_1 != null ? (recapeN_1.Nbr_jour_ouv_Oct + recapeN_1.Nbr_jour_ouv_Nouv + recapeN_1.Nbr_jour_ouv_Dec) - (recapeN_1.Nbr_jour_abs_Oct + recapeN_1.Nbr_jour_abs_Nouv + recapeN_1.Nbr_jour_abs_Dec) : 0;
                    das_pers.jrs_trv_tr3 = (recape.Nbr_jour_ouv_Janv + recape.Nbr_jour_ouv_Fev + recape.Nbr_jour_ouv_Mars) - (recape.Nbr_jour_abs_Janv + recape.Nbr_jour_abs_Fev + recape.Nbr_jour_abs_Mars);
                    das_pers.jrs_trv_tr4 = (recape.Nbr_jour_ouv_Avr + recape.Nbr_jour_ouv_Mai + recape.Nbr_jour_ouv_Juin) - (recape.Nbr_jour_abs_Avr + recape.Nbr_jour_abs_Mai + recape.Nbr_jour_abs_Juin);
                }

                //das_pers.montant_tr1 = recapeN_1 != null ? recapeN_1.Brut_Cotis_Juill + recapeN_1.Brut_Cotis_Aout + recapeN_1.Brut_Cotis_Sept : 0;
                //das_pers.montant_tr2 = recapeN_1 != null ? recapeN_1.Brut_Cotis_Oct + recapeN_1.Brut_Cotis_Nouv + recapeN_1.Brut_Cotis_Dec : 0;
                das_pers.montant_tr3 = recape.Brut_Cotis_Janv + recape.Brut_Cotis_Fev + recape.Brut_Cotis_Mars;
                das_pers.montant_tr4 = recape.Brut_Cotis_Avr + recape.Brut_Cotis_Mai + recape.Brut_Cotis_Juin;
                //das_pers.montant_tr1 = recape.Brut_Cotis_Janv + recape.Brut_Cotis_Fev + recape.Brut_Cotis_Mars;
                //das_pers.montant_tr2 = recape.Brut_Cotis_Avr + recape.Brut_Cotis_Mai + recape.Brut_Cotis_Juin;
                //das_pers.montant_tr3 = recape.Brut_Cotis_Juill + recape.Brut_Cotis_Aout + recape.Brut_Cotis_Sept;
                //das_pers.montant_tr4 = recape.Brut_Cotis_Oct + recape.Brut_Cotis_Nouv + recape.Brut_Cotis_Dec;

                das_pers.Save();
            }
            MaPayeAdmin.Module.Exercice exerciceN = ((CustomLogonParameter)Application.Security.LogonParameters).database;
            MaPayeAdmin.Module.Exercice exerciceN_1 = ((CustomLogonParameter)Application.Security.LogonParameters).database.exercice_precedent;
            string connectionString = session.Connection is SQLiteConnection ? string.Format("XpoProvider=SQLite;Data Source={0}{1}\\{2}", 
                exerciceN.chemin, exerciceN.dossier.code_dossier, exerciceN_1.db_name) :
                session.Connection is SqlConnection ? string.Format("Integrated Security=false;Pooling=false;Data Source={0}{1};Initial Catalog={2}; User ID=sa;Password=58206670", 
                Helper.serverName, Helper.instanceName, exerciceN_1.db_name) : string.Empty;
            XPObjectSpaceProvider osp = string.IsNullOrEmpty(connectionString) ? null : new XPObjectSpaceProvider(connectionString);
            IObjectSpace osN_1 = osp != null ? osp.CreateObjectSpace() : null;
            Session sessionN_1 = ((XPObjectSpace)osN_1).Session;
            XPCollection<Recape_Annuelle> recapesN_1 = new XPCollection<Recape_Annuelle>(sessionN_1);
            foreach (Recape_Annuelle recapeN_1 in recapesN_1)//e.SelectedObjects)
            {
                Recape_Annuelle recape = ObjectSpace.GetObject<Recape_Annuelle>(recapeN_1);
                //das_g.NbrEntree += recape.Entree_Janv + recape.Entree_Fev + recape.Entree_Mars + recape.Entree_Avr + recape.Entree_Mai + recape.Entree_Juin;
                //if (recapeN_1 != null)
                das_g.NbrEntree += recapeN_1.Entree_Juill + recapeN_1.Entree_Aout + recapeN_1.Entree_Oct + recapeN_1.Entree_Nouv + recapeN_1.Entree_Dec;

                //das_g.NbrSortie += recape.Sortie_Janv + recape.Sortie_Fev + recape.Sortie_Mars + recape.Sortie_Avr + recape.Sortie_Mai + recape.Sortie_Juin;
                //if (recapeN_1 != null)
                das_g.NbrSortie += recapeN_1.Sortie_Juill + recapeN_1.Sortie_Aout + recapeN_1.Sortie_Oct + recapeN_1.Sortie_Nouv + recapeN_1.Sortie_Dec;

                ordre += 1;
                Das_Personnes das_pers = session.FindObject<Das_Personnes>(PersistentCriteriaEvaluationBehavior.InTransaction,
                    CriteriaOperator.Parse("Cod_personne = ? and DAS_G = ?", recapeN_1.personne.Cod_personne, das_g));
                if (das_pers == null)
                {
                    das_pers = new Das_Personnes(session)
                    {
                        Ordre = ordre,
                        Nom = recapeN_1.personne.FirstName,
                        Prenom = recapeN_1.personne.LastName,
                        Cod_personne = recapeN_1.personne.Cod_personne,
                        sexe = ObjectSpace.GetObject<Sexe>(recapeN_1.personne.sexe),
                        Sit_fam = ObjectSpace.GetObject<Situation_Familiale>(recapeN_1.personne.Sit_fam),
                        Adresse = recapeN_1.personne.Adresse_Fr,
                        Ville = recapeN_1.personne.Ville,
                        CodePostal = recapeN_1.personne.CodePostal,
                        NComptCCP = recapeN_1.personne.num_compte,
                        CleComptCCP = recapeN_1.personne.cle_compt,
                        NComptBanque = recapeN_1.personne.Num_CPP_Banque,
                        CleComptBanque = recapeN_1.personne.cle_CPP_Banqu,
                        Banque = ObjectSpace.GetObject<Banque>(recapeN_1.personne.Banque),
                        Nationalite = (Nationalite)recapeN_1.personne.Nationalite,
                        Etranger = recapeN_1.personne.Etranger,
                        LaFonction = recapeN_1.personne.LaFonction.Fct_Lib_Fr,
                        Date_Naissance = recapeN_1.personne.Birthday,
                        Naissance_Présumé = recapeN_1.personne.Naissance_Présumé,
                        Lieu_nais = recapeN_1.personne.Lieu_nais,
                        Dat_entre = recapeN_1.personne.DateRecrutement,
                        Dat_sortie = recapeN_1.personne.Dat_sortie,
                        num_SecSoc = recapeN_1.personne.num_SecSoc,
                        Unit_mes = ObjectSpace.GetObject<unit_mes>(recapeN_1.personne.Unit_mes),
                        NCN = recapeN_1.personne.NCN,
                        IdNat = (Convert.ToInt16(recapeN_1.personne.Nationalite)).ToString(),
                        Tlf = recapeN_1.personne.Tlf,
                        Email = recapeN_1.personne.Email
                    };


                    if (parametres.DeclarationMultiple)
                    {
                        if (donne == -1)
                            if (recapeN_1.personne.unite != null)
                            {
                                das_g.Num_employeur = recapeN_1.personne.unite.NumEmployeur;
                                das_g.Denomination = recapeN_1.personne.unite.Denomination;
                                das_g.Organisme_Fr = recapeN_1.personne.unite.Des_fr;
                                das_g.Adresse = recapeN_1.personne.unite.Adresse;
                                das_g.Tlf = recapeN_1.personne.unite.Tel;
                                das_g.Type_dec = recapeN_1.personne.unite.TypeDeclaration;
                                das_g.Centr_Payeur = recapeN_1.personne.unite.CentrePayeur;

                                donne = 1;
                            }
                    }


                    das_pers.DAS_G = das_g;
                }
                if (das_pers.Unit_mes == unit_mes.M)
                {
                    double nbrtr1 = recapeN_1 != null ? (recapeN_1.Nbr_jour_ouv_Juill + recapeN_1.Nbr_jour_ouv_Aout + recapeN_1.Nbr_jour_ouv_Sept) - (recapeN_1.Nbr_jour_abs_Juill + recapeN_1.Nbr_jour_abs_Aout + recapeN_1.Nbr_jour_abs_Sept) : 0;
                    if (nbrtr1 != 0)
                    {
                        if (nbrtr1 / 30 <= 1)
                            das_pers.jrs_trv_tr1 = 1;
                        else
                            if (nbrtr1 / 30 <= 2)
                                das_pers.jrs_trv_tr1 = 2;
                            else
                                if (nbrtr1 / 30 <= 3)
                                    das_pers.jrs_trv_tr1 = 3;
                    }
                    else
                        das_pers.jrs_trv_tr1 = 0;

                    double nbrtr2 = recapeN_1 != null ? (recapeN_1.Nbr_jour_ouv_Oct + recapeN_1.Nbr_jour_ouv_Nouv + recapeN_1.Nbr_jour_ouv_Dec) - (recapeN_1.Nbr_jour_abs_Oct + recapeN_1.Nbr_jour_abs_Nouv + recapeN_1.Nbr_jour_abs_Dec) : 0;
                    if (nbrtr2 != 0)
                    {
                        if (nbrtr2 / 30 <= 1)
                            das_pers.jrs_trv_tr2 = 1;
                        else
                            if (nbrtr2 / 30 <= 2)
                                das_pers.jrs_trv_tr2 = 2;
                            else
                                if (nbrtr2 / 30 <= 3)
                                    das_pers.jrs_trv_tr2 = 3;
                    }
                    else
                        das_pers.jrs_trv_tr2 = 0;

                }
                else
                {
                    das_pers.jrs_trv_tr1 = recapeN_1 != null ? (recapeN_1.Nbr_jour_ouv_Juill + recapeN_1.Nbr_jour_ouv_Aout + recapeN_1.Nbr_jour_ouv_Sept) - (recapeN_1.Nbr_jour_abs_Juill + recapeN_1.Nbr_jour_abs_Aout + recapeN_1.Nbr_jour_abs_Sept) : 0;
                    das_pers.jrs_trv_tr2 = recapeN_1 != null ? (recapeN_1.Nbr_jour_ouv_Oct + recapeN_1.Nbr_jour_ouv_Nouv + recapeN_1.Nbr_jour_ouv_Dec) - (recapeN_1.Nbr_jour_abs_Oct + recapeN_1.Nbr_jour_abs_Nouv + recapeN_1.Nbr_jour_abs_Dec) : 0;
                }

                das_pers.montant_tr1 = recapeN_1 != null ? recapeN_1.Brut_Cotis_Juill + recapeN_1.Brut_Cotis_Aout + recapeN_1.Brut_Cotis_Sept : 0;
                das_pers.montant_tr2 = recapeN_1 != null ? recapeN_1.Brut_Cotis_Oct + recapeN_1.Brut_Cotis_Nouv + recapeN_1.Brut_Cotis_Dec : 0;

                das_pers.Save();
            }
            session.CommitTransaction();
            das_g.Save();
            das_g.calcul();
            das_g.Save();
            session.CommitTransaction();
        }
    }
}