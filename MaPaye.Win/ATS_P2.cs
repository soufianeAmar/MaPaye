using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using MaPaye.Module;
using System.Data.SqlClient;
using MaPayeAdmin;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;

namespace MaPaye.Win
{
    public partial class ATS_P2 : DevExpress.XtraReports.UI.XtraReport
    { 
        IDbConnection Connection;
        DataTable dt = new DataTable();
        string DataBaseName = "";
        string Exercice = "";
        string Dossier = "";

        double JT1 = 0;
        double JT2 = 0;
        double JT3 = 0;
        double JT4 = 0;
        double JT5 = 0;
        double JT6 = 0;
        double JT7 = 0;
        double JT8 = 0;
        double JT9 = 0;
        double JT10 = 0;
        double JT11 = 0;
        double JT12 = 0;

        decimal BC1 = 0;
        decimal BC2 = 0;
        decimal BC3 = 0;
        decimal BC4 = 0;
        decimal BC5 = 0;
        decimal BC6 = 0;
        decimal BC7 = 0;
        decimal BC8 = 0;
        decimal BC9 = 0;
        decimal BC10 = 0;
        decimal BC11 = 0;
        decimal BC12 = 0;

        decimal Ss1 = 0;
        decimal Ss2 = 0;
        decimal Ss3 = 0;
        decimal Ss4 = 0;
        decimal Ss5 = 0;
        decimal Ss6 = 0;
        decimal Ss7 = 0;
        decimal Ss8 = 0;
        decimal Ss9 = 0;
        decimal Ss10 = 0;
        decimal Ss11 = 0;
        decimal Ss12 = 0;

        string Per1 = "";
        string Per2 = "";
        string Per3 = "";
        string Per4 = "";
        string Per5 = "";
        string Per6 = "";
        string Per7 = "";
        string Per8 = "";
        string Per9 = "";
        string Per10 = "";
        string Per11 = "";
        string Per12 = "";

        int Ord = 0;
        DateTime DateDebut;
        DateTime DateFin;
        string emp = "";

        private string MoisEnLettres(int mois)
        {
            string MoisL = "";
            switch (mois)
            {
                case (1): MoisL = "Janvier"; break;
                case (2): MoisL = "Février"; break;
                case (3): MoisL = "Mars"; break;
                case (4): MoisL = "Avril"; break;
                case (5): MoisL = "Mai"; break;
                case (6): MoisL = "Juin"; break;
                case (7): MoisL = "Juillet"; break;
                case (8): MoisL = "Août"; break;
                case (9): MoisL = "Septembre"; break;
                case (10): MoisL = "Octobre"; break;
                case (11): MoisL = "Nouvembre"; break;
                case (12): MoisL = "Décembre"; break;
            }
            return MoisL;
        }

        public ATS_P2(DateTime DateD, DateTime DateF, string oid)
        {
            InitializeComponent();
            DateDebut = DateD;
            DateFin = DateF;
            emp = oid;

            //XPCollection<Personne> personnes = new XPCollection<Personne>(Core.CoreSession, CriteriaOperator.Parse("Oid=?", emp));
            Personne pers = Core.CoreSession.FindObject<Personne>(CriteriaOperator.Parse("Oid=?", emp));
            //personnes.Load();

            this.Personne.Add(pers);

        }
 
        private void ATS_P2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        { 
            if (lsactvtn.ActivationClass.réseau)
            {
                Connection = Core.GetAppConnection(true);
                if ((SqlConnection)Connection != null)
                {
                    DataBaseName = ((SqlConnection)Core.CoreSession.Connection).Database;
                    Exercice = DataBaseName.Substring(DataBaseName.Length - 4);
                    Dossier = DataBaseName.Substring(0, DataBaseName.Length - 4);
                }
                else
                    throw new Exception("Connection null !");
            } 

        }

        private void detailBand1_AfterPrint(object sender, EventArgs e)
        {

            int moisD = DateDebut.Month;
            int moisF = DateFin.Month;

            int AnneeD = DateDebut.Year;
            int AnneeF = DateFin.Year;

            string ConnectionStringD = string.Format(@"Integrated Security=false;Pooling=false;Data Source={0}{1};
                                Initial Catalog={2}{3};User ID=sa;Password=58206670",
                                Helper.serverName, Helper.instanceName, Dossier, AnneeD);
            SqlConnection ConnectionD = new SqlConnection(ConnectionStringD);

            string ConnectionStringF = string.Format(@"Integrated Security=false;Pooling=false;Data Source={0}{1};
                                Initial Catalog={2}{3};User ID=sa;Password=58206670",
                                Helper.serverName, Helper.instanceName, Dossier, AnneeF);
            SqlConnection ConnectionF = new SqlConnection(ConnectionStringF);

            //string emp = this.GetCurrentColumnValue("Oid").ToString();

            if (AnneeD == AnneeF)
            {
                string requete = string.Format(@"SELECT (Mois - {0})+1 as ordre, Mois,Annee, brute_cotisableAbsence, ssAbsence, Jour_Abs, Nbr_jour_tra 
					from Paye 
					where Mois >= {0} 
					and Mois <= {1}  
					and gcrecord is null 
					and personne = '{2}'
					order by annee , mois",
                                    moisD, moisF, emp);

                SqlDataAdapter adapter = new SqlDataAdapter(requete, (SqlConnection)Connection);
                dt.Clear();
                adapter.FillSchema(dt, SchemaType.Source);
                adapter.Fill(dt);
                dt.DefaultView.Sort = "ordre ASC";
            }
            else
            {
                string requete = string.Format(@"SELECT((Mois + 12 * (Annee - {0})) - {1})+1 as ordre,Mois, Annee, brute_cotisableAbsence, ssAbsence, Jour_Abs, Nbr_jour_tra 
					FROM [ACG2015].[dbo].[Paye] 
					where gcrecord is null
					and Annee = {0}
					and Mois >= {1}					
					and personne = '{4}'
					union  
					SELECT ((Mois + 12 * (Annee - {0})) - {1})+1 as ordre, Mois, Annee, brute_cotisableAbsence, ssAbsence, Jour_Abs, Nbr_jour_tra      
					FROM [ACG2016].[dbo].[Paye] 
					where gcrecord is null
					and Annee = {2}
					and Mois <= {3}
					and personne = '{4}'
					order by annee , mois",
                                    AnneeD, moisD, AnneeF, moisF, emp);

                SqlDataAdapter adapter = new SqlDataAdapter(requete, (SqlConnection)Connection);
                dt.Clear();
                adapter.FillSchema(dt, SchemaType.Source);
                adapter.Fill(dt);
                dt.DefaultView.Sort = "ordre Asc";
            }
        }

        private void PageFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            foreach (DataRow dr in dt.Rows)
            {
                switch (Convert.ToInt32(dr["ordre"]))
                {
                    case (1):
                        {
                            JT1 += Convert.ToDouble(dr["Nbr_jour_tra"]) - Convert.ToDouble(dr["Jour_Abs"]);
                            BC1 += Convert.ToDecimal(dr["brute_cotisableAbsence"]);
                            Ss1 += Convert.ToDecimal(dr["ssAbsence"]);
                            Ord = 1;
                            Per1 = MoisEnLettres(Convert.ToInt32(dr["Mois"])) + " " + dr["Annee"];

                            break;
                        }
                    case (2):
                        {
                            JT2 += Convert.ToDouble(dr["Nbr_jour_tra"]) - Convert.ToDouble(dr["Jour_Abs"]);
                            BC2 += Convert.ToDecimal(dr["brute_cotisableAbsence"]);
                            Ss2 += Convert.ToDecimal(dr["ssAbsence"]);
                            Ord = 2;
                            Per2 = MoisEnLettres(Convert.ToInt32(dr["Mois"])) + " " + dr["Annee"];

                            break;
                        }
                    case (3):
                        {
                            JT3 += Convert.ToDouble(dr["Nbr_jour_tra"]) - Convert.ToDouble(dr["Jour_Abs"]);
                            BC3 += Convert.ToDecimal(dr["brute_cotisableAbsence"]);
                            Ss3 += Convert.ToDecimal(dr["ssAbsence"]);
                            Ord = 3;
                            Per3 = MoisEnLettres(Convert.ToInt32(dr["Mois"])) + " " + dr["Annee"];

                            break;
                        }
                    case (4):
                        {
                            JT4 += Convert.ToDouble(dr["Nbr_jour_tra"]) - Convert.ToDouble(dr["Jour_Abs"]);
                            BC4 += Convert.ToDecimal(dr["brute_cotisableAbsence"]);
                            Ss4 += Convert.ToDecimal(dr["ssAbsence"]);
                            Ord = 4;
                            Per4 = MoisEnLettres(Convert.ToInt32(dr["Mois"])) + " " + dr["Annee"];

                            break;
                        }
                    case (5):
                        {
                            JT5 += Convert.ToDouble(dr["Nbr_jour_tra"]) - Convert.ToDouble(dr["Jour_Abs"]);
                            BC5 += Convert.ToDecimal(dr["brute_cotisableAbsence"]);
                            Ss5 += Convert.ToDecimal(dr["ssAbsence"]);
                            Ord = 5;
                            Per5 = MoisEnLettres(Convert.ToInt32(dr["Mois"])) + " " + dr["Annee"];

                            break;
                        }
                    case (6):
                        {
                            JT6 += Convert.ToDouble(dr["Nbr_jour_tra"]) - Convert.ToDouble(dr["Jour_Abs"]);
                            BC6 += Convert.ToDecimal(dr["brute_cotisableAbsence"]);
                            Ss6 += Convert.ToDecimal(dr["ssAbsence"]);
                            Ord = 6;
                            Per6 = MoisEnLettres(Convert.ToInt32(dr["Mois"])) + " " + dr["Annee"];

                            break;
                        }
                    case (7):
                        {
                            JT7 += Convert.ToDouble(dr["Nbr_jour_tra"]) - Convert.ToDouble(dr["Jour_Abs"]);
                            BC7 += Convert.ToDecimal(dr["brute_cotisableAbsence"]);
                            Ss7 += Convert.ToDecimal(dr["ssAbsence"]);
                            Ord = 7;
                            Per7 = MoisEnLettres(Convert.ToInt32(dr["Mois"])) + " " + dr["Annee"];

                            break;
                        }
                    case (8):
                        {
                            JT8 += Convert.ToDouble(dr["Nbr_jour_tra"]) - Convert.ToDouble(dr["Jour_Abs"]);
                            BC8 += Convert.ToDecimal(dr["brute_cotisableAbsence"]);
                            Ss8 += Convert.ToDecimal(dr["ssAbsence"]);
                            Ord = 8;
                            Per8 = MoisEnLettres(Convert.ToInt32(dr["Mois"])) + " " + dr["Annee"];

                            break;
                        }
                    case (9):
                        {
                            JT9 += Convert.ToDouble(dr["Nbr_jour_tra"]) - Convert.ToDouble(dr["Jour_Abs"]);
                            BC9 += Convert.ToDecimal(dr["brute_cotisableAbsence"]);
                            Ss9 += Convert.ToDecimal(dr["ssAbsence"]);
                            Ord = 9;
                            Per9 = MoisEnLettres(Convert.ToInt32(dr["Mois"])) + " " + dr["Annee"];

                            break;
                        }
                    case (10):
                        {
                            JT10 += Convert.ToDouble(dr["Nbr_jour_tra"]) - Convert.ToDouble(dr["Jour_Abs"]);
                            BC10 += Convert.ToDecimal(dr["brute_cotisableAbsence"]);
                            Ss10 += Convert.ToDecimal(dr["ssAbsence"]);
                            Ord = 10;
                            Per10 = MoisEnLettres(Convert.ToInt32(dr["Mois"])) + " " + dr["Annee"];

                            break;
                        }
                    case (11):
                        {
                            JT11 += Convert.ToDouble(dr["Nbr_jour_tra"]) - Convert.ToDouble(dr["Jour_Abs"]);
                            BC11 += Convert.ToDecimal(dr["brute_cotisableAbsence"]);
                            Ss11 += Convert.ToDecimal(dr["ssAbsence"]);
                            Ord = 11;
                            Per11 = MoisEnLettres(Convert.ToInt32(dr["Mois"])) + " " + dr["Annee"];

                            break;
                        }
                    case (12):
                        {
                            JT12 += Convert.ToDouble(dr["Nbr_jour_tra"]) - Convert.ToDouble(dr["Jour_Abs"]);
                            BC12 += Convert.ToDecimal(dr["brute_cotisableAbsence"]);
                            Ss12 += Convert.ToDecimal(dr["ssAbsence"]);
                            Ord = 12;
                            Per12 = MoisEnLettres(Convert.ToInt32(dr["Mois"])) + " " + dr["Annee"];

                            break;
                        }
                }
            }
        }

        private void Periode1_GetValue(object sender, GetValueEventArgs e)
        {
            if (Per1 != "")
                e.Value = Per1;
            else
                e.Value = "/";
        }

        private void Periode2_GetValue(object sender, GetValueEventArgs e)
        {
            if (Per2 != "")
                e.Value = Per2;
            else
                e.Value = "/";

        }

        private void Periode3_GetValue(object sender, GetValueEventArgs e)
        {
            if (Per3 != "")
                e.Value = Per3;
            else
                e.Value = "/";

        }

        private void Periode4_GetValue(object sender, GetValueEventArgs e)
        {
            if (Per4 != "")
                e.Value = Per4;
            else
                e.Value = "/";

        }

        private void Periode5_GetValue(object sender, GetValueEventArgs e)
        {
            if (Per5 != "")
                e.Value = Per5;
            else
                e.Value = "/";

        }

        private void Periode6_GetValue(object sender, GetValueEventArgs e)
        {
            if (Per6 != "")
                e.Value = Per6;
            else
                e.Value = "/";

        }

        private void Periode7_GetValue(object sender, GetValueEventArgs e)
        {
            if (Per7 != "")
                e.Value = Per7;
            else
                e.Value = "/";

        }

        private void Periode8_GetValue(object sender, GetValueEventArgs e)
        {
            if (Per8 != "")
                e.Value = Per8;
            else
                e.Value = "/";

        }

        private void Periode9_GetValue(object sender, GetValueEventArgs e)
        {
            if (Per9 != "")
                e.Value = Per9;
            else
                e.Value = "/";

        }

        private void Periode10_GetValue(object sender, GetValueEventArgs e)
        {
            if (Per10 != "")
                e.Value = Per10;
            else
                e.Value = "/";

        }

        private void Periode11_GetValue(object sender, GetValueEventArgs e)
        {
            if (Per11 != "")
                e.Value = Per11;
            else
                e.Value = "/";

        }

        private void Periode12_GetValue(object sender, GetValueEventArgs e)
        {
            if (Per12 != "")
                e.Value = Per12;
            else
                e.Value = "/";

        }

        private void Nbr_Jrs_Trv1_GetValue(object sender, GetValueEventArgs e)
        {
            if (JT1 != 0)
                e.Value = JT1;
            else
                e.Value = "/";

        }

        private void Nbr_Jrs_Trv2_GetValue(object sender, GetValueEventArgs e)
        {
            if (JT2 != 0)
                e.Value = JT2;
            else
                e.Value = "/";

        }

        private void Nbr_Jrs_Trv3_GetValue(object sender, GetValueEventArgs e)
        {
            if (JT3 != 0)
                e.Value = JT3;
            else
                e.Value = "/";

        }

        private void Nbr_Jrs_Trv4_GetValue(object sender, GetValueEventArgs e)
        {
            if (JT4 != 0)
                e.Value = JT4;
            else
                e.Value = "/";

        }

        private void Nbr_Jrs_Trv5_GetValue(object sender, GetValueEventArgs e)
        {
            if (JT5 != 0)
                e.Value = JT5;
            else
                e.Value = "/";

        }

        private void Nbr_Jrs_Trv6_GetValue(object sender, GetValueEventArgs e)
        {
            if (JT6 != 0)
                e.Value = JT6;
            else
                e.Value = "/";

        }

        private void Nbr_Jrs_Trv7_GetValue(object sender, GetValueEventArgs e)
        {
            if (JT7 != 0)
                e.Value = JT7;
            else
                e.Value = "/";

        }

        private void Nbr_Jrs_Trv8_GetValue(object sender, GetValueEventArgs e)
        {
            if (JT8 != 0)
                e.Value = JT8;
            else
                e.Value = "/";

        }

        private void Nbr_Jrs_Trv9_GetValue(object sender, GetValueEventArgs e)
        {
            if (JT9 != 0)
                e.Value = JT9;
            else
                e.Value = "/";

        }

        private void Nbr_Jrs_Trv10_GetValue(object sender, GetValueEventArgs e)
        {
            if (JT10 != 0)
                e.Value = JT10;
            else
                e.Value = "/";

        }

        private void Nbr_Jrs_Trv11_GetValue(object sender, GetValueEventArgs e)
        {
            if (JT11 != 0)
                e.Value = JT11;
            else
                e.Value = "/";

        }

        private void Nbr_Jrs_Trv12_GetValue(object sender, GetValueEventArgs e)
        {
            if (JT12 != 0)
                e.Value = JT12;
            else
                e.Value = "/";

        }

        private void Brut1_GetValue(object sender, GetValueEventArgs e)
        {
            if (BC1 != 0)
                e.Value = BC1;
            else
                e.Value = "/";

        }

        private void Brut2_GetValue(object sender, GetValueEventArgs e)
        {
            if (BC2 != 0)
                e.Value = BC2;
            else
                e.Value = "/";

        }

        private void Brut3_GetValue(object sender, GetValueEventArgs e)
        {
            if (BC3 != 0)
                e.Value = BC3;
            else
                e.Value = "/";

        }

        private void Brut4_GetValue(object sender, GetValueEventArgs e)
        {
            if (BC4 != 0)
                e.Value = BC4;
            else
                e.Value = "/";

        }

        private void Brut5_GetValue(object sender, GetValueEventArgs e)
        {
            if (BC5 != 0)
                e.Value = BC5;
            else
                e.Value = "/";

        }

        private void Brut6_GetValue(object sender, GetValueEventArgs e)
        {
            if (BC6 != 0)
                e.Value = BC6;
            else
                e.Value = "/";

        }

        private void Brut7_GetValue(object sender, GetValueEventArgs e)
        {
            if (BC7 != 0)
                e.Value = BC7;
            else
                e.Value = "/";

        }

        private void Brut8_GetValue(object sender, GetValueEventArgs e)
        {
            if (BC8 != 0)
                e.Value = BC8;
            else
                e.Value = "/";

        }

        private void Brut9_GetValue(object sender, GetValueEventArgs e)
        {
            if (BC9 != 0)
                e.Value = BC9;
            else
                e.Value = "/";

        }

        private void Brut10_GetValue(object sender, GetValueEventArgs e)
        {
            if (BC10 != 0)
                e.Value = BC10;
            else
                e.Value = "/";

        }

        private void Brut11_GetValue(object sender, GetValueEventArgs e)
        {
            if (BC11 != 0)
                e.Value = BC11;
            else
                e.Value = "/";

        }

        private void Brut12_GetValue(object sender, GetValueEventArgs e)
        {
            if (BC12 != 0)
                e.Value = BC12;
            else
                e.Value = "/";

        }

        private void SS1_GetValue(object sender, GetValueEventArgs e)
        {
            if (Ss1 != 0)
                e.Value = Ss1;
            else
                e.Value = "/";

        }

        private void SS2_GetValue(object sender, GetValueEventArgs e)
        {
            if (Ss2 != 0)
                e.Value = Ss2;
            else
                e.Value = "/";

        }

        private void SS3_GetValue(object sender, GetValueEventArgs e)
        {
            if (Ss3 != 0)
                e.Value = Ss3;
            else
                e.Value = "/";

        }

        private void SS4_GetValue(object sender, GetValueEventArgs e)
        {
            if (Ss4 != 0)
                e.Value = Ss4;
            else
                e.Value = "/";

        }

        private void SS5_GetValue(object sender, GetValueEventArgs e)
        {
            if (Ss5 != 0)
                e.Value = Ss5;
            else
                e.Value = "/";

        }

        private void SS6_GetValue(object sender, GetValueEventArgs e)
        {
            if (Ss6 != 0)
                e.Value = Ss6;
            else
                e.Value = "/";

        }

        private void SS7_GetValue(object sender, GetValueEventArgs e)
        {
            if (Ss7 != 0)
                e.Value = Ss7;
            else
                e.Value = "/";

        }

        private void SS8_GetValue(object sender, GetValueEventArgs e)
        {
            if (Ss8 != 0)
                e.Value = Ss8;
            else
                e.Value = "/";

        }

        private void SS9_GetValue(object sender, GetValueEventArgs e)
        {
            if (Ss9 != 0)
                e.Value = Ss9;
            else
                e.Value = "/";

        }

        private void SS10_GetValue(object sender, GetValueEventArgs e)
        {
            if (Ss10 != 0)
                e.Value = Ss10;
            else
                e.Value = "/";

        }

        private void SS11_GetValue(object sender, GetValueEventArgs e)
        {
            if (Ss11 != 0)
                e.Value = Ss11;
            else
                e.Value = "/";

        }

        private void SS12_GetValue(object sender, GetValueEventArgs e)
        {
            if (Ss12 != 0)
                e.Value = Ss12;
            else
                e.Value = "/";

        }

        private void PageFooter_AfterPrint(object sender, EventArgs e)
        { 
            JT1 = 0;
            JT2 = 0;
            JT3 = 0;
            JT4 = 0;
            JT5 = 0;
            JT6 = 0;
            JT7 = 0;
            JT8 = 0;
            JT9 = 0;
            JT10 = 0;
            JT11 = 0;
            JT12 = 0;

            BC1 = 0;
            BC2 = 0;
            BC3 = 0;
            BC4 = 0;
            BC5 = 0;
            BC6 = 0;
            BC7 = 0;
            BC8 = 0;
            BC9 = 0;
            BC10 = 0;
            BC11 = 0;
            BC12 = 0;

            Ss1 = 0;
            Ss2 = 0;
            Ss3 = 0;
            Ss4 = 0;
            Ss5 = 0;
            Ss6 = 0;
            Ss7 = 0;
            Ss8 = 0;
            Ss9 = 0;
            Ss10 = 0;
            Ss11 = 0;
            Ss12 = 0;

            Per1 = "";
            Per2 = "";
            Per3 = "";
            Per4 = "";
            Per5 = "";
            Per6 = "";
            Per7 = "";
            Per8 = "";
            Per9 = "";
            Per10 = "";
            Per11 = "";
            Per12 = "";
 

        }
 
    }
}
