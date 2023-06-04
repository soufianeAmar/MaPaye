using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

namespace MaPayeAdmin.Module
{
    public partial class DBPathVC : ViewController
    {
        public DBPathVC()
        {
            InitializeComponent();
            RegisterActions(components);
        }
        /// <summary>
        /// Utilis�e pour parcourir les emplacement sur l'ordinateur
        /// </summary>
        /// <param name="BrowseFolders">Parcourt les dossiers (n'affiche aucun fichier)</param>
        /// <param name="FilterValue">Utilis� si BrowseFolders a la valeur FAUX. Repr�sente le filtre de fichiers � utiliser</param>
        /// <param name="OpenDialog">Utilis� si BrowseFolders a la valeur FAUX. Ouvre une boite de dialogue pour ouvrir un fichier si la valeur VRAI est utilis�e. Sinon, affiche une boite de dialogue pour la sauvegarde</param>
        /// <returns></returns>
        private string Parcourir(bool BrowseFolders, string FilterValue, bool OpenDialog)
        {
            if (BrowseFolders)
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        if (fbd.SelectedPath.EndsWith("\\"))
                            return fbd.SelectedPath;
                        else
                            return string.Format("{0}\\", fbd.SelectedPath);
                    }
                    else
                        return null;
                }
            }
            else
            {
                if (OpenDialog)
                {
                    using (OpenFileDialog ofd = new OpenFileDialog { Filter = FilterValue })
                    {
                        if (ofd.ShowDialog() == DialogResult.OK)
                            return ofd.FileName;
                        else
                            return null;
                    }
                }
                else
                {
                    using (SaveFileDialog sfd = new SaveFileDialog { Filter = FilterValue })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                            return sfd.FileName;
                        else
                            return null;
                    }
                }
            }
        }
        private void Parcourir_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (View.ObjectTypeInfo.Name == "Exercice")
            {
                string dbPath = Parcourir(true, "", false);
                if (dbPath != null)
                    ((Exercice)View.CurrentObject).chemin = dbPath;
            }
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            aParcourir.Active.SetItemValue("", ObjectSpace.IsNewObject(View.CurrentObject));
        }
    }
}
