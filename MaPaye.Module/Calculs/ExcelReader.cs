using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace MaPaye.Module
{ 
    public class ExcelReader : BaseObject
    {
        public ExcelReader(Session session)
            : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here or place it only when the IsLoading property is false:
            // if (!IsLoading){
            //    It is now OK to place your initialization code here.
            // }
            // or as an alternative, move your initialization code into the AfterConstruction method.
        }

        public ExcelReader()
        {
            // TODO: Complete member initialization
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }

        private OleDbConnection CNX;
        public string Excel_filename;
        public String[] sheet_names;
        public String[] column_names;
        public bool header = true;
        public bool mixed_data = false;

        public string connection_string
        {
            get
            {
                string HDR;
                if (header)
                    HDR = "HDR=Yes;";
                else
                    HDR = "HDR=No;";
                string IMEX;
                if (mixed_data)
                    IMEX = "Imex=2;";
                else
                    IMEX = "Imex=1;";
                return String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Excel 8.0;{1}{2}", Excel_filename, HDR, IMEX);
            }
        }

        public String[] GetSheetNames()
        {
            try
            {
                if (CNX.State == ConnectionState.Closed)
                    throw new Exception("Impossible d'obtenir la liste des feuilles de calcul. connection fermée !");
                //DataTable temporary_table = CNX.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                DataTable temporary_table = CNX.GetSchema("Tables");
                if (temporary_table == null)
                    return null;
                String[] sheet_names = new String[temporary_table.Rows.Count];
                int i = 0;
                foreach (DataRow row in temporary_table.Rows)
                {
                    sheet_names[i] = row["TABLE_NAME"].ToString();
                    i++;
                }
                return sheet_names;
            }
            catch
            {
                return null;
            }
        }

        public String[] GetColumnNames()
        {
            try
            {
                if (CNX.State == ConnectionState.Closed)
                    throw new Exception("Impossible d'obtenir la liste des feuilles de calcul. connection fermée !");
                DataTable temporary_table = CNX.GetSchema("Columns");
                if (temporary_table == null)
                    return null;
                String[] column_names = new String[temporary_table.Rows.Count];
                int i = 0;
                foreach (DataRow row in temporary_table.Rows)
                {
                    column_names[i] = row["COLUMN_NAME"].ToString();
                    i++;
                }
                return column_names;
            }
            catch
            {
                return null;
            }
        }

        public void Connect()
        {
            try
            {
                if (!System.IO.File.Exists(Excel_filename))
                    throw new Exception("Fichier spécifié introuvable !");
                CNX = new OleDbConnection(connection_string);
                CNX.Open();
                sheet_names = GetSheetNames();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetExcelTable(string sheet_name)
        {
            using (OpenFileDialog dialog = new OpenFileDialog { Filter = "Fichiers Microsoft Excel 1997-2003 (.xls)|*.xls|Fichiers Microsoft Excel 2007 (*.xlsx)|*.xlsx|Tous les fichier (*.*)|*.*" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    Excel_filename = dialog.FileName;
                else
                {
                    MessageBox.Show("Aucun fichier sélectionné !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            Connect();
            DataTable ExcelTable = new DataTable(sheet_name);
            string select_command;
            if (sheet_name != string.Empty)
                select_command = string.Format("select * from [{0}]", sheet_name);
            else
                select_command = string.Format("select * from [{0}]", sheet_names[0].ToString());
            OleDbDataAdapter oleAdapter = new OleDbDataAdapter(new OleDbCommand(select_command, CNX));
            oleAdapter.FillSchema(ExcelTable, SchemaType.Source);
            oleAdapter.Fill(ExcelTable);
            column_names = GetColumnNames();
            return ExcelTable;
        }
    }

}
