using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text; 
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using DevExpress.ExpressApp.Xpo;

namespace MaPaye.Module
{
    public partial class OutilsBDD : ViewController
    {
        public OutilsBDD()
        {
            InitializeComponent();
            RegisterActions(components);
        }

        private void BackupDatabase(string serverName, string database, string fileName)
        {
            Backup backup = new Backup()
            {
                Database = database,
                Action = BackupActionType.Database,
                Initialize = true
            };
            backup.Devices.Add(new BackupDeviceItem(fileName, DeviceType.File));
            backup.SqlBackup(new Server(serverName));
        }


        private void RestoreDatabase(string serverName, string database, string fileName)
        {
            Restore restore = new Restore()
            {
                Database = database,
                Action = RestoreActionType.Database,
                ReplaceDatabase = true
            };
            restore.Devices.Add(new BackupDeviceItem(fileName, DeviceType.File));
            Server server = new Server(serverName);
            server.KillAllProcesses(database);
            restore.SqlRestore(server);
        }

        private void SauvgarderBD_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Sauvegardes de BDD SQL|*.bak" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SqlConnection cnx = new SqlConnection(((XPObjectSpace)ObjectSpace).Session.ConnectionString);
                try
                {
                    BackupDatabase(cnx.DataSource, cnx.Database, sfd.FileName);
                    MessageBox.Show("L'archivage s'est terminé avec succés !", "Succés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void RestaurerBD_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Sauvegardes de BDD SQL|*.bak" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                SqlConnection cnx = new SqlConnection(((XPObjectSpace)ObjectSpace).Session.ConnectionString);
                try
                {
                    RestoreDatabase(cnx.DataSource, cnx.Database, ofd.FileName);
                    MessageBox.Show("La restauration s'est terminée avec succés !", "Succés", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
