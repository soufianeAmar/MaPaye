using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using System.Data.SqlClient;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using Microsoft.SqlServer.Management.Smo;
using System.Windows.Forms;
using System.IO;

namespace MaPayeAdmin.Module
{
    [DefaultClassOptions, NavigationItem("Administration"), ImageName("exercice"), DefaultProperty("db_name"), CreatableItem(false)]
    public class Exercice : BaseObject
    {
        #region Propriété
        Dossier _dossier;
        [DevExpress.Xpo.DisplayName("Dossier"), ImmediatePostData(true), RuleRequiredField()]
        public Dossier dossier
        {
            get { return _dossier; }
            set
            {
                Dossier _value = XPObjectSpace.FindObjectSpaceByObject(this).GetObject<Dossier>(value);
                SetPropertyValue("dossier", ref _dossier, _value);
            }
        }
        int _exercice;
        [DevExpress.Xpo.DisplayName("Exercice")]
        public int exercice
        {
            get { return _exercice; }
            set { SetPropertyValue("exercice", ref _exercice, value); }
        }
        string _designation;
        [DevExpress.Xpo.DisplayName("Designation")]
        public string designation
        {
            get { return _designation; }
            set { SetPropertyValue("designation", ref _designation, value); }
        }
        [DevExpress.Xpo.DisplayName("Base de données")]
        public string db_name
        {
            get
            {
                return string.Format("{0}{1}", dossier, exercice);
                //return string.Format("{0}{1}", dossier, exercice);
            }
        }
        string _chemin;
        [DevExpress.Xpo.DisplayName("Chemin de la base de données")]
        public string chemin
        {
            get { return _chemin; }
            set { SetPropertyValue("chemin", ref _chemin, value); }
        }
        bool _accessible;
        [DevExpress.Xpo.DisplayName("Accessible"), VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        public bool accessible
        {
            get { return _accessible; }
            set { SetPropertyValue("accessible", ref _accessible, value); }
        }
        bool _importation;
        [DevExpress.Xpo.DisplayName("Importation"), VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        public bool importation
        {
            get { return _importation; }
            set { SetPropertyValue("importation", ref _importation, value); }
        }
        Exercice _exercice_precedent;
        [DevExpress.Xpo.DisplayName("Exercice précédent"), VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        public Exercice exercice_precedent
        {
            get { return _exercice_precedent; }
            set { SetPropertyValue("exercice_precedent", ref _exercice_precedent, value); }
        }
        #endregion
        public Exercice(Session session)
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
            string ApplicationFolder = Path.GetDirectoryName(Application.ExecutablePath);
            string DataFolder = string.Format("{0}\\Data\\", ApplicationFolder);
            if (!Directory.Exists(DataFolder))
                Directory.CreateDirectory(DataFolder);
            chemin = DataFolder;
            exercice = DateTime.Today.Year;
            accessible = true;
        }
        protected override void OnSaving()
        {
            base.OnSaving();
            string SQLServerInstance = string.Format("{0}{1}", Helper.serverName, Helper.instanceName);
            Server server = new Server(SQLServerInstance);
            if (IsDeleted)
            {
                //Database db = server.Databases[db_name];
                if (server.Databases.Contains(db_name))
                {
                    if (MessageBox.Show("La suppression d'une base de données est définitive et irréversible. Continuer?", "Suppression",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        server.KillDatabase(db_name);
                    }
                }
            }
            else
            {
                //if (CheckMaximumDatabases())
                //    throw new Exception("Le nombre maximum de bases de données est atteint pour ce dossier !");
                //else
                {
                    Database db = new Database(server, db_name);
                    if (!server.Databases.Contains(db_name))
                    {
                        //db.AutoShrink = false;
                        //db.FileGroups.Add(new FileGroup(db, "PRIMARY"));
                        //db.FileGroups[0].Files.Add(new DataFile(db.FileGroups[0], db_name, string.Format("{0}{1}.mdf", chemin, db_name)) 
                        //    { Growth = 10, GrowthType = FileGrowthType.Percent});
                        //db.LogFiles.Add(new LogFile(db, string.Format("{0}_log", db_name), string.Format("{0}{1}_log.ldf", chemin, db_name)) 
                        //    { Growth = 10, GrowthType = FileGrowthType.Percent });
                        //var script = db.Script();
                        //db.Create();
                        string fichier_modele = string.Format("{0}\\Modele\\modele.bak", Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath));
                        if (File.Exists(fichier_modele))
                            Helper.CreateServerDatabaseFromBackupInPath(SQLServerInstance, db_name, chemin, fichier_modele);
                        else
                            Helper.CreateServerDatabaseInPath(SQLServerInstance, db_name, chemin);
                    }
                    else
                    {
                        db = server.Databases[db_name];
                        chemin = Path.GetDirectoryName(db.FileGroups[0].Files[0].FileName);
                    }
                    //throw new Exception("Base de données existante !");
                    //MessageBox.Show("Base de données existante !", "Erreur de création", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //private bool CheckMaximumDatabases()
        //{
        //    if (Core.app_settings.exercices_par_dossier != -1)
        //    {
        //        XPObjectSpace object_space = (XPObjectSpace)XPObjectSpace.FindObjectSpaceByObject(this);
        //        bool error = object_space.GetObjectsCount(typeof(Exercice), CriteriaOperator.Parse("dossier = ?",
        //            dossier)) >= Core.app_settings.exercices_par_dossier;
        //        return error;
        //    }
        //    else
        //        return false;
        //}

    }

}
