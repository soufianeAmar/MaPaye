using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace MaPayeAdmin
{
    public class Helper
    {
        public static string serverName;
        public static string instanceName;

        public static void CreateServerDatabaseFromBackup(string serverName, string database, string bkfileName)
        {
            Server server = new Server(serverName);
            server.ConnectionContext.LoginSecure = false;
            server.ConnectionContext.Login = "sa";
            server.ConnectionContext.Password = "58206670";
            //Database db = new Database(server, database);
            if (!server.Databases.Contains(database))
            {
                string defaultDataPath = string.IsNullOrEmpty(server.Settings.DefaultFile) ? server.MasterDBPath : server.Settings.DefaultFile;
                string defaultLogPath = string.IsNullOrEmpty(server.Settings.DefaultLog) ? server.MasterDBLogPath : server.Settings.DefaultLog;
                Restore restore = new Restore()
                {
                    Database = database,
                    Action = RestoreActionType.Database,
       
                    ReplaceDatabase = true,
                };
                restore.Devices.Add(new BackupDeviceItem(bkfileName, DeviceType.File));
                DataTable logicalRestoreFiles = restore.ReadFileList(server); //Column names : {LogicalName}, {PhysicalName}, {Type}, {FileGroupName}, {Size}, {MaxSize}
                foreach (DataRow file in logicalRestoreFiles.Rows)
                {
                    string fileName = System.IO.Path.GetFileName(file["PhysicalName"].ToString());
                    if (file["Type"].ToString() == "D")
                        restore.RelocateFiles.Add(new RelocateFile(database, string.Concat(defaultDataPath, "\\", fileName)));
                    if (file["Type"].ToString() == "L")
                        restore.RelocateFiles.Add(new RelocateFile(database + "_Log", string.Concat(defaultLogPath, "\\", fileName)));
                }
                server.KillAllProcesses(database);
                restore.SqlRestore(server);
            }
        }

        public static void CreateDatabaseFromBackupInPath(string database, string dataPath, string bkfileName)
        {
            Server server = new Server();
            Database db = new Database(server, database);
            if (!server.Databases.Contains(database))
            {
                Restore restore = new Restore()
                {
                    Database = database,
                    Action = RestoreActionType.Database,
                    ReplaceDatabase = true,
                };
                restore.Devices.Add(new BackupDeviceItem(bkfileName, DeviceType.File));
                DataTable dtFileList = restore.ReadFileList(server);
                string dbLogicalName = dtFileList.Rows[0][0].ToString();
                string dbPhysicalName = dtFileList.Rows[0][1].ToString();
                string logLogicalName = dtFileList.Rows[1][0].ToString();
                string logPhysicalName = dtFileList.Rows[1][1].ToString();
                restore.RelocateFiles.Add(new RelocateFile(dbLogicalName, string.Format("{0}{1}.mdf", dataPath, database)));
                restore.RelocateFiles.Add(new RelocateFile(logLogicalName, string.Format("{0}{1}_log.ldf", dataPath, database)));
                server.KillAllProcesses(database);
                restore.SqlRestore(server);
            }
        }

        public static void CreateServerDatabaseInPath(string serverName, string database, string dataPath)
        {
            Server server = new Server(serverName);
            Database db = new Database(server, database);
            if (!server.Databases.Contains(database))
            {
                db.AutoShrink = false;
                db.FileGroups.Add(new FileGroup(db, "PRIMARY"));
                db.FileGroups[0].Files.Add(new DataFile(db.FileGroups[0], database, string.Format("{0}{1}.mdf", dataPath, database)) { Growth = 10, GrowthType = FileGrowthType.Percent });
                db.LogFiles.Add(new LogFile(db, string.Format("{0}_log", database), string.Format("{0}{1}_log.ldf", dataPath, database)) { Growth = 10, GrowthType = FileGrowthType.Percent });
                var script = db.Script();
                db.Create();
            }
            else
                throw new Exception("Base de données existante !");
        }

        public static void CreateServerDatabaseFromBackupInPath(string serverName, string database, string dataPath, string bkfileName)
        {
            Server server = new Server(serverName);
            Database db = new Database(server, database);
            if (!server.Databases.Contains(database))
            {
                Restore restore = new Restore()
                {
                    Database = database,
                    Action = RestoreActionType.Database,
                    ReplaceDatabase = true,
                };
                restore.Devices.Add(new BackupDeviceItem(bkfileName, DeviceType.File));
                DataTable dtFileList = restore.ReadFileList(server);
                string dbLogicalName = dtFileList.Rows[0][0].ToString();
                string dbPhysicalName = dtFileList.Rows[0][1].ToString();
                string logLogicalName = dtFileList.Rows[1][0].ToString();
                string logPhysicalName = dtFileList.Rows[1][1].ToString();
                restore.RelocateFiles.Add(new RelocateFile(dbLogicalName, string.Format("{0}{1}.mdf", dataPath, database)));
                restore.RelocateFiles.Add(new RelocateFile(logLogicalName, string.Format("{0}{1}_log.ldf", dataPath, database)));
                server.KillAllProcesses(database);
                restore.SqlRestore(server);
            }
        }
    }
}
