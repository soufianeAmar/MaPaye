using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using System.Data;
using System.Data.SqlClient;
using DevExpress.Xpo;
using System.Windows.Forms;
using DevExpress.ExpressApp.Xpo;
using System.Data.SQLite;
using DevExpress.Data.Filtering;

namespace MaPaye.Module
{
    public partial class Exportation : ViewController
    {
        public Exportation()
        {
            InitializeComponent();
            RegisterActions(components);
        }

        public void export_table(string table_name, string mois)
        {
            Session session = ((XPObjectSpace)ObjectSpace).Session;

            string requete = string.Format(@"SELECT   
                              p.[NETAbsence] montant
                             ,pers.Cod_personne
                             ,pers.Nom_Prenom_CCP 
                             ,pers.[Adresse_Fr] adresse_emp
                             ,pers.[Num_CPP_Banque] N_compte_banq_emp
                             ,pers.[cle_CPP_Banqu] cle_compte_banq_emp
                             ,(select Type_Paiment_Lib_Fr from Mode_Paiement where Oid=pers.[Mode_Paiement]) Mode_Paiement  
     
                             ,pers.[num_compte] N_compte_CCP_emp
                             ,pers.[cle_compt] cle_compte_CCP_emp
     

                             ,b.des_f des_fr_banque 
                             ,b.adr_f adress_fr_banque
                             ,b.cod_banque code_banque
     
                             ,(select des_f from banque where Oid=para.banqu) des_fr_banque_org  
                             ,(select cod_banque from banque where Oid=para.banqu) Cod_banque_org  
                              ,para.Adresse adress_org
                              ,para.Organisme_Fr 
                              ,para.Receveur_Cle_Compte 
                              ,para.Receveur_Num_Compte
                              ,para.Num_compte_banq Num_compte_banq_org
                              ,para.Receveur_Fr Nom_Receveur
       
                              FROM [Paye] P inner join  Personne Pers on(P.personne = Pers.oid)
                              inner join Person per on(P.personne = Per.oid) 
                              inner join Banque b on (Pers.Banque = b.oid) 
                              cross join parametre para  
  
                              where P.GCRecord is null
                              and P.Bloque_Paye = 0
                              and P.Mois = {0}", mois);

            DataTable dt = new DataTable();

            if (lsactvtn.ActivationClass.réseau)
                dt = Core.FetchData(table_name, requete, (SqlConnection)session.Connection, true);
            else
                dt = Core.FetchData(table_name, requete, (SQLiteConnection)session.Connection, false);


            using (SaveFileDialog sfdXMLFile = new SaveFileDialog() { Filter = "Fichiers XML|*.xml", FileName = "Paye", RestoreDirectory = true })
                if (sfdXMLFile.ShowDialog() == DialogResult.OK)
                {
                    dt.WriteXml(sfdXMLFile.FileName, XmlWriteMode.WriteSchema, false);
                }
        }

        public void export_table_Rappel(string table_name)
        {

            Session session = ((XPObjectSpace)ObjectSpace).Session;


            string requete = string.Format(@" SELECT   
            R.[NET_Mois] montant
            ,pers.Cod_personne
            ,pers.Nom_Prenom_CCP 
            ,pers.[Adresse_Fr] adresse_emp
            ,pers.[Num_CPP_Banque] N_compte_banq_emp
            ,pers.[cle_CPP_Banqu] cle_compte_banq_emp
     
            ,pers.[num_compte] N_compte_CCP_emp
            ,pers.[cle_compt] cle_compte_CCP_emp
      
            ,b.des_f des_fr_banque 
            ,b.adr_f adress_fr_banque
            ,b.cod_banque code_banque
     
            ,(select des_f from banque where Oid=para.banqu) des_fr_banque_org  
            ,(select cod_banque from banque where Oid=para.banqu) Cod_banque_org  
            ,para.Adresse adress_org
            ,para.Organisme_Fr 
            ,para.Receveur_Cle_Compte 
            ,para.Receveur_Num_Compte
            ,para.Num_compte_banq Num_compte_banq_org
            ,para.Receveur_Fr Nom_Receveur
       
            FROM [Rappel] R inner join  Personne Pers on(R.Cod_personne = Pers.Cod_personne) 
            inner join Banque b on (Pers.Banque = b.oid) 
            cross join parametre para  
  
            where R.GCRecord is null
            and R.Cod_Rappel_Personne in(select Code from CodesRappels)");

            DataTable dt = new DataTable();

            if (lsactvtn.ActivationClass.réseau)
                dt = Core.FetchData(table_name, requete, (SqlConnection)session.Connection, true);
            else
                dt = Core.FetchData(table_name, requete, (SQLiteConnection)session.Connection, false);

            //SqlDataAdapter sql_a = new SqlDataAdapter(string.Format(requete, table_name),
            //    (SqlConnection)session.Connection);
            //sql_a.FillSchema(dt, SchemaType.Source);
            //sql_a.Fill(dt);

            using (SaveFileDialog sfdXMLFile = new SaveFileDialog() { Filter = "Fichiers XML|*.xml", FileName = "Rappel", RestoreDirectory = true })
                if (sfdXMLFile.ShowDialog() == DialogResult.OK)
                {
                    dt.WriteXml(sfdXMLFile.FileName, XmlWriteMode.WriteSchema, false);
                } 
        }

        public void export_table_Bordereau(string table_name, string mois)
        {
            Session session = ((XPObjectSpace)ObjectSpace).Session;

            string requete = string.Format(@"SELECT   
                              B.[Montant] montant
                             ,pers.Cod_personne
                             ,pers.Nom_Prenom_CCP 
                             ,pers.[Adresse_Fr] adresse_emp
                             ,pers.[Num_CPP_Banque] N_compte_banq_emp
                             ,pers.[cle_CPP_Banqu] cle_compte_banq_emp
                             ,(select Type_Paiment_Lib_Fr from Mode_Paiement where Oid=pers.[Mode_Paiement]) Mode_Paiement  
     
                             ,pers.[num_compte] N_compte_CCP_emp
                             ,pers.[cle_compt] cle_compte_CCP_emp
     

                             ,bc.des_f des_fr_banque 
                             ,bc.adr_f adress_fr_banque
                             ,b.cod_banque code_banque
     
                             ,(select des_f from banque where Oid=para.banqu) des_fr_banque_org  
                             ,(select cod_banque from banque where Oid=para.banqu) Cod_banque_org  
                              ,para.Adresse adress_org
                              ,para.Organisme_Fr 
                              ,para.Receveur_Cle_Compte 
                              ,para.Receveur_Num_Compte
                              ,para.Num_compte_banq Num_compte_banq_org
                              ,para.Receveur_Fr Nom_Receveur
       
                              FROM [Bordereau] B inner join  Personne Pers on(B.personne = Pers.oid)
                              inner join Person per on(B.personne = Per.oid) 
                              inner join Banque bc on (Pers.Banque = bc.oid) 
                              cross join parametre para  
  
                              where B.GCRecord is null 
                              and B.Mois = {0}", mois);

            DataTable dt = new DataTable();

            if (lsactvtn.ActivationClass.réseau)
                dt = Core.FetchData(table_name, requete, (SqlConnection)session.Connection, true);
            else
                dt = Core.FetchData(table_name, requete, (SQLiteConnection)session.Connection, false);

            //SqlDataAdapter sql_a = new SqlDataAdapter(string.Format(requete, table_name),
            //    (SqlConnection)session.Connection);
            //sql_a.FillSchema(dt, SchemaType.Source);
            //sql_a.Fill(dt);


            using (SaveFileDialog sfdXMLFile = new SaveFileDialog() { Filter = "Fichiers XML|*.xml", FileName = "Bordereau", RestoreDirectory = true })
                if (sfdXMLFile.ShowDialog() == DialogResult.OK)
                {
                    dt.WriteXml(sfdXMLFile.FileName, XmlWriteMode.WriteSchema, false);
                }
        }

        private void ExportBanque_Execute(object sender, SimpleActionExecuteEventArgs e)
        { 

        }

        private void ExporterDonnéesEDICCPRappel_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Session session = ((XPObjectSpace)ObjectSpace).Session;

            string table_name = "CodesRappels"; 
            string requete_create = string.Format(@"CREATE TABLE dbo.[{0}] ([Code] [varchar](50) NULL)", table_name);
            string requete_drop = string.Format(@" IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') 
                                                    AND type in (N'U')) DROP TABLE [dbo].[{0}]", table_name); 

             
            SqlCommand drop = new SqlCommand(requete_drop, (SqlConnection)session.Connection);
          
            drop.ExecuteNonQuery();
            drop.Connection.Close(); 

            SqlCommand create = new SqlCommand(requete_create, (SqlConnection)session.Connection);
            create.Connection.Open();
            create.ExecuteNonQuery();
            create.Connection.Close();
             

            foreach (Rappel Rappel in e.SelectedObjects)
            {
                string requete_insert = string.Format(@"INSERT INTO {0} ([Code]) VALUES ('{1}')", table_name,Rappel.Cod_Rappel_Personne.ToString());
 
                SqlCommand insert = new SqlCommand(requete_insert, (SqlConnection)session.Connection);
                insert.Connection.Open();
                insert.ExecuteNonQuery();
                insert.Connection.Close(); 
            }

            export_table_Rappel("Paye");
        }

        private void ExportPaye_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            
        }

        private void ExporterDonnéesEDICCP_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            string mois = "";
            mois = e.SelectedChoiceActionItem.Data.ToString();
            export_table("Paye", mois);
        }
           
        private void ExporterDonnéesEDICCPBordereau_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        { 
            string mois = "";
            mois = e.SelectedChoiceActionItem.Data.ToString();
            export_table("Paye", mois);
        }

        private DataTable ExportParametres(string table_name, string connection)
        {
            string requete = @"SELECT [Taux_ss]
                                      ,[Taux_pp1]
                                      ,[Taux_pp2]
                                      ,[Taux_pp3]
                                      ,[Taux_pp]
                                      ,[nbr_jour_ouv]
                                      ,[Nbr_heure_ouv]
                                      ,[Nbr_heure_tra]
                                      ,[Denomination]
                                      ,[Num_employeur]
                                      ,[Adresse]
                                      ,[Ai]
                                      ,[Mf]
                                      ,[Rc]
                                      ,[Centr_Payeur]
                                      ,[Type_dec]
                                      ,[Agence]
                                      ,[banqu]
                                      ,[Mois_debut_Cong]
                                      ,[Mois_fin_Cong]
                                      ,[nbr_jour_cong_mois]
                                      ,[mod_cal_prime_lic]
                                      ,[nbr_heure_jour]
                                      ,[Num_compte_banq]
                                      ,[Cle_compte_banq]
                                      ,[nom_rais_f]
                                      ,[Mod_cal_conge]
                                      ,[Tel]
                                      ,[Fax]
                                      ,[Taux_irg]
                                      ,[taux_maj_sud]
                                      ,[Smig]
                                      ,[Base_SU]
                                      ,[Base_SU_Partiel]
                                      ,[Base_AF]
                                      ,[Base_AF_Partiel]
                                      ,[Base_AF_P10]
                                      ,[Base_Prime_Scol]
                                      ,[Base_Prime_Scol_Partiel]
                                      ,[Plafond_mutuelle]
                                      ,[Valeur_mutuelle]
                                      ,[Nbr_heure_tra_Temporaire]
                                      ,[SDB_Heur]
                                      ,[Nbr_heure_tra_Mois]
                                      ,[Nbr_heure_tra_Partiel_Mois]
                                      ,[Nbr_jour_tra]
                                      ,[Nbr_Jour_Travail_Prime]
                                      ,[Nbr_jour_tra_Temp]
                                      ,[Base_Resident]
                                      ,[Taux_Iep_Org]
                                      ,[Taux_Iep_Hors_Secteur_Prive]
                                      ,[Taux_Iep_Hors_Secteur_Etat]
                                      ,[Annee_Travail]
                                      ,[Type_Abcense]
                                      ,[Mode_Arrondi]
                                      ,[Nbr_Mois_Pri]
                                      ,[Taux_Pri]
                                      ,[Note_Pri]
                                      ,[Taux_PAP]
                                      ,[Nbr_Mois_PAP]
                                      ,[Note_PAP]
                                      ,[Receveur_Ar]
                                      ,[Receveur_Fr]
                                      ,[Receveur_Num_Compte]
                                      ,[Receveur_Cle_Compte]
                                      ,[Nom_Organisme_Ar]
                                      ,[Organisme_Fr]
                                      ,[Secteur_Organisme]
                                      ,[Region_Ar]
                                      ,[Region_Fr]
                                      ,[Commune_Ar]
                                      ,[Commune_Fr]
                                      ,[Daira_Fr]
                                      ,[Daira_Ar]
                                      ,[Wilaya_Ar]
                                      ,[Wilaya_Fr]
                                      ,[Designation_Caisse]
                                      ,[NIS]
                                      ,[NIF]
                                      ,[TIN]
                                      ,[Logo]
                                      ,[Eff_Janv]
                                      ,[Eff_Fev]
                                      ,[Eff_Mars]
                                      ,[Eff_Avr]
                                      ,[Eff_Mai]
                                      ,[Eff_Juin]
                                      ,[Eff_Juill]
                                      ,[Eff_Aout]
                                      ,[Eff_Sept]
                                      ,[Eff_Oct]
                                      ,[Eff_Nouv]
                                      ,[Jr_Debut_Mois]
                                      ,[WeekEnd]
                                      ,[Eff_Dec]
                                      ,[Admin]
                                      ,[OptimisticLockField]
                                      ,[GCRecord]
                                      ,[Taux_cacobatph]
                                      ,[Taux_chomage_intemperie]
                                      ,[Email]
                                      ,[Site_Web]
                                      ,[Activite]
                                      ,[Limite_Iep_ext]
                                      ,[Limite_Iep]
                                      ,[Limite_Iep_ext_à]
                                      ,[Limite_Iep_à]
                                      ,[nom_DG]
                                      ,[Aug_Auto_Taux_Iep_Org]
                                      ,[AgenceCacobatph]
                                      ,[HeureDebutShiftNuit]
                                      ,[NbrHeuresShiftNuit]
                                      ,[ShiftNuitCR]
                                      ,[AbsenceDansJrsCongeAnnuel]
                                      ,[NbrJrsTrvPrJrsCR]
                                      ,[NbrJrsCRPrJrsTrv]
                                      ,[Taux_Mutuel]
                                      ,[Calcul_Absence_Auto]
                                      ,[DeclarationMultiple]
                                      ,[CRAvecPaye]
                                  FROM [Ma Société2015].[dbo].[parametre]
                                  where GCRecord is null";

            DataTable dt = new DataTable(table_name);

            SqlDataAdapter sql_a = new SqlDataAdapter(string.Format(requete, table_name), connection);
            sql_a.FillSchema(dt, SchemaType.Source);
            sql_a.Fill(dt);
             
            return dt; 
        }

        private DataTable ExportBaremes(string table_name, string connection)
        {
            string requete = @"SELECT [CATEG]
                                      ,[SDB] 
                                  FROM [Ma Société2015].[dbo].[Bareme]
                                  where GCRecord is null";

            DataTable dt = new DataTable(table_name);

            SqlDataAdapter sql_a = new SqlDataAdapter(string.Format(requete, table_name), connection);
            sql_a.FillSchema(dt, SchemaType.Source);
            sql_a.Fill(dt);
             
            return dt; 
        }

        private DataTable ExportSitFam(string table_name, string connection)
        {
            string requete = @"SELECT [Sit_Fam_Lib_Pour_Etat] 
                                    ,[Sit_Fam_Lib_Fr] 
                                FROM [Ma Société2015].[dbo].[Situation_Familiale]
                                where Gcrecord is null";

            DataTable dt = new DataTable(table_name);

            SqlDataAdapter sql_a = new SqlDataAdapter(string.Format(requete, table_name), connection);
            sql_a.FillSchema(dt, SchemaType.Source);
            sql_a.Fill(dt);
             
            return dt; 
        }

        private DataTable ExportSitConj(string table_name, string connection)
        {
            string requete = @"SELECT [Sit_Conj_Lib_Fr] 
                                FROM [Ma Société2015].[dbo].[Situation_Conjoint]
                                where gcrecord is null";

            DataTable dt = new DataTable(table_name);

            SqlDataAdapter sql_a = new SqlDataAdapter(string.Format(requete, table_name), connection);
            sql_a.FillSchema(dt, SchemaType.Source);
            sql_a.Fill(dt);
             
            return dt; 
        }

        private DataTable ExportSitEmp(string table_name, string connection)
        {
            string requete = @"SELECT  [Sit_Emp_Lib_Fr] 
                                  FROM [Ma Société2015].[dbo].[Situation_Employe]
                                  WHERE GCRecord is null";

            DataTable dt = new DataTable(table_name);

            SqlDataAdapter sql_a = new SqlDataAdapter(string.Format(requete, table_name), connection);
            sql_a.FillSchema(dt, SchemaType.Source);
            sql_a.Fill(dt);
             
            return dt; 
        }

        private DataTable ExportTypeAbs(string table_name, string connection)
        {
            string requete = @"SELECT  [Type_Abs_Lib_Fr] 
                                  FROM [Ma Société2015].[dbo].[Type_Absence]
                                  where GCRecord is null";

            DataTable dt = new DataTable(table_name);

            SqlDataAdapter sql_a = new SqlDataAdapter(string.Format(requete, table_name), connection);
            sql_a.FillSchema(dt, SchemaType.Source);
            sql_a.Fill(dt);
             
            return dt; 
        }

        private DataTable ExportSexe(string table_name, string connection)
        {
            string requete = @"SELECT  [Sexe_Lib_Ar]
                                      ,[Sexe_Lib_Fr] 
                                  FROM [Ma Société2015].[dbo].[Sexe]";

            DataTable dt = new DataTable(table_name);

            SqlDataAdapter sql_a = new SqlDataAdapter(string.Format(requete, table_name), connection);
            sql_a.FillSchema(dt, SchemaType.Source);
            sql_a.Fill(dt);
             
            return dt; 
        }

        private DataTable ExportIndemnites(string table_name, string connection)
        {
            string requete = @"SELECT  [Code]
                                        ,[Cod_indem_interne]
                                        ,[Cod_indem]
                                        ,[Lib_indem]  
                                        ,[Form_cal]
                                        ,[Cotisable]
                                        ,[Imposable] 
                                        ,[Form_base]
                                        ,[Form_nbr]
                                        ,[Form_taux]   
                                        ,[Ordre_Affichage]
                                        ,[Mod_cal_irg]
                                        ,[parametres]
                                        ,[Observation]
                                        ,[Brut_Net_Incluse]
                                        ,[Retenue]
                                        ,[Mode_Calcul_Absence]
                                        ,[Compte_Comptable]
                                        ,[Compte_Debit]
                                        ,[Compte_Credit]
                                        ,[Valeur_Min]
                                        ,[Valeur_Max]
                                        ,[Valeur_Minimale]
                                        ,[Valeur_Maximale] 
                                        ,[Cod_Rubrique]
                                    FROM [Ma Société2015].[dbo].[Indem]
                                    where GCRecord is null";

            DataTable dt = new DataTable(table_name);

            SqlDataAdapter sql_a = new SqlDataAdapter(string.Format(requete, table_name), connection);
            sql_a.FillSchema(dt, SchemaType.Source);
            sql_a.Fill(dt);
             
            return dt; 
        }

        private DataTable ExportFonctions(string table_name, string connection)
        {
            string requete = @"SELECT [cod_fonction]
                                    ,[Fct_Lib_Fr]  
                                    ,[Categorie]  
                                    ,[parametres] 
                                FROM [Ma Société2015].[dbo].[Fonction]
                                where gcrecord is null";

            DataTable dt = new DataTable(table_name);

            SqlDataAdapter sql_a = new SqlDataAdapter(string.Format(requete, table_name), connection);
            sql_a.FillSchema(dt, SchemaType.Source);
            sql_a.Fill(dt);
             
            return dt; 
        }

        private DataTable ExportReports(string table_name, string connection)
        {
            string requete = @"SELECT [OID]
                                      ,[ObjectTypeName]
                                      ,[Content]
                                      ,[Name]
                                      ,[IsInplaceReport] 
                                  FROM [Ma Société2015].[dbo].[ReportData]
                                  where GCRecord is  null";

            DataTable dt = new DataTable(table_name);

            SqlDataAdapter sql_a = new SqlDataAdapter(string.Format(requete, table_name), connection);
            sql_a.FillSchema(dt, SchemaType.Source);
            sql_a.Fill(dt);
             
            return dt; 
        }

        private DataTable ExportModesPaiement(string table_name, string connection)
        {
            string requete = @"SELECT  [Type_Paiment_Lib_Fr] 
                                  FROM [Ma Société2015].[dbo].[Mode_Paiement]
                                  where gcrecord is null";

            DataTable dt = new DataTable(table_name);

            SqlDataAdapter sql_a = new SqlDataAdapter(string.Format(requete, table_name), connection);
            sql_a.FillSchema(dt, SchemaType.Source);
            sql_a.Fill(dt);
             
            return dt; 
        }

        private void ExportData_Execute(object sender, SimpleActionExecuteEventArgs e)
        { 
            string connection = "Integrated Security=false;Pooling=false;Data Source=AMEL-PC\\LEADERSOFT1;Initial Catalog=Ma Société2015;User ID=sa;Password=58206670"; 
  
            DataTable BaremesDT = ExportBaremes("Bareme", connection);
            DataTable SitFamDT = ExportSitFam("Situation_Familiale", connection);
            DataTable SitConjDT = ExportSitConj("Situation_Conjoint", connection);
            DataTable SitEmpDT = ExportSitEmp("Situation_Employe", connection);
            DataTable TypeAbsDT = ExportTypeAbs("Type_Absence", connection);
            DataTable SexeDT = ExportSexe("Sexe", connection);
            DataTable IndemnitesDT = ExportIndemnites("Indem", connection);
            DataTable FonctionsDT = ExportFonctions("Fonction", connection);
            DataTable ReportsDT = ExportReports("ReportData", connection);
            DataTable ModesPaiementDT = ExportModesPaiement("Mode_Paiement", connection);

            DataSet DS = new DataSet("MaPayeData"); 
            DS.Tables.Add(BaremesDT);
            DS.Tables.Add(SitFamDT);
            DS.Tables.Add(SitConjDT);
            DS.Tables.Add(SitEmpDT);
            DS.Tables.Add(TypeAbsDT);
            DS.Tables.Add(SexeDT);
            DS.Tables.Add(IndemnitesDT);
            DS.Tables.Add(FonctionsDT);
            DS.Tables.Add(ReportsDT);
            DS.Tables.Add(ModesPaiementDT);
             
            DS.Tables[0].TableName = "Bareme";
            DS.Tables[1].TableName = "Situation_Familiale";
            DS.Tables[2].TableName = "Situation_Conjoint";
            DS.Tables[3].TableName = "Situation_Employe";
            DS.Tables[4].TableName = "Type_Absence";
            DS.Tables[5].TableName = "Sexe";
            DS.Tables[6].TableName = "Indem";
            DS.Tables[7].TableName = "Fonction";
            DS.Tables[8].TableName = "ReportData";
            DS.Tables[9].TableName = "Mode_Paiement";

            using (SaveFileDialog sfdXMLFile = new SaveFileDialog() { Filter = "Fichiers XML|*.xml", FileName = "MaPayeData", RestoreDirectory = true })
                if (sfdXMLFile.ShowDialog() == DialogResult.OK)
                {
                    DS.WriteXml(sfdXMLFile.FileName, XmlWriteMode.WriteSchema);
                } 
        }
         
    }
}
