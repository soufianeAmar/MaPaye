using System;

using DevExpress.Xpo;

using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;

namespace MaPaye.Module
{
    [DefaultClassOptions]

    public class Rappel : BaseObject
    {

        [Association("Rappel-Rappel_indems", typeof(Rappel_indem))]
        public XPCollection Rappel_indems
        {
            get { return GetCollection("Rappel_indems"); }
        }

        private Paye fPaye_Ancien;
        public Paye Paye_Ancien
        {
            get { return fPaye_Ancien; }
            set { SetPropertyValue<Paye>("Paye_Ancien", ref fPaye_Ancien, value); }
        }

        private Paye fPaye_Nouveau;
        public Paye Paye_Nouveau
        {
            get { return fPaye_Nouveau; }
            set { SetPropertyValue<Paye>("Paye_Nouveau", ref fPaye_Nouveau, value); }
        }


        private Personne fPersonne;
        public Personne Personne
        {
            get { return fPersonne; }
            set { SetPropertyValue<Personne>("Personne", ref fPersonne, value); }
        }


        private string fCod_personne; 
        public string Cod_personne
        {
            get { return fCod_personne; }
            set { SetPropertyValue<string>("Cod_personne", ref fCod_personne, value); }
        }

        private string fCod_Rappel;
        public string Cod_Rappel
        {
            get { return fCod_Rappel; }
            set { SetPropertyValue<string>("Cod_Rappel", ref fCod_Rappel, value); }
        }

        private string fCod_Rappel_Personne;
        public string Cod_Rappel_Personne
        {
            get { return fCod_Rappel_Personne; }
            set { SetPropertyValue<string>("Cod_Rappel_Personne", ref fCod_Rappel_Personne, value); }
        }

        private MoisdelAnnee fMois;
        [Size(2)]
        public MoisdelAnnee Mois
        {
            get { return fMois; }
            set { SetPropertyValue<MoisdelAnnee>("Mois", ref fMois, value); }
        }
         
        private int fAnnee;
        public int Annee
        {
            get { return fAnnee; }
            set { SetPropertyValue<int>("Annee", ref fAnnee, value); }
        }

        private string fObservation;
        public string Observation
        {
            get { return fObservation; }
            set { SetPropertyValue<string>("Observation", ref fObservation, value); }
        }  

        private decimal fBRUT_Dif;
        public decimal BRUT_Dif
        {
            get { return fBRUT_Dif; }
            set
            {
                SetPropertyValue<decimal>("BRUT_Dif", ref fBRUT_Dif, value);
            }
        }

        private decimal fIRG_Dif;
        public decimal IRG_Dif
        {
            get { return fIRG_Dif; }
            set
            {
                SetPropertyValue<decimal>("IRG_Dif", ref fIRG_Dif, value);
            }
        }

        private decimal fSS_Dif;
        public decimal SS_Dif
        {
            get { return fSS_Dif; }
            set { SetPropertyValue<decimal>("SS_Dif", ref fSS_Dif, value); }
        }

        private decimal fNET_Dif;
        public decimal NET_Dif
        {
            get { return fNET_Dif; }
            set { SetPropertyValue<decimal>("NET_Dif", ref fNET_Dif, value); }
        }

        private decimal fMONTANT_Dif;
        public decimal MONTANT_Dif
        {
            get { return fMONTANT_Dif; }
            set { SetPropertyValue<decimal>("MONTANT_Dif", ref fMONTANT_Dif, value); }
        }

        private decimal fBrute_cotisable_Dif;
        public decimal Brute_cotisable_Dif
        {
            get { return fBrute_cotisable_Dif; }
            set { SetPropertyValue<decimal>("Brute_cotisable_Dif", ref fBrute_cotisable_Dif, value); }
        }

        private decimal fBrute_imposable_Dif;
        public decimal Brute_imposable_Dif
        {
            get { return fBrute_imposable_Dif; }
            set { SetPropertyValue<decimal>("Brute_imposable_Dif", ref fBrute_imposable_Dif, value); }
        }
         
        private decimal fBASE_Dif;
        public decimal BASE_Dif
        {
            get { return fBASE_Dif; }
            set { SetPropertyValue<decimal>("BASE_Dif", ref fBASE_Dif, value); }
        }

        private double fTAUX_Dif;
        public double TAUX_Dif
        {
            get { return fTAUX_Dif; }
            set { SetPropertyValue<double>("TAUX_Dif", ref fTAUX_Dif, value); }
        }

        private double fNBR_Dif;
        public double NBR_Dif
        {
            get { return fNBR_Dif; }
            set { SetPropertyValue<double>("NBR_Dif", ref fNBR_Dif, value); }
        } 

        private decimal fSDB_Dif; //fonction fait
        public decimal SDB_Dif
        {
            get { return fSDB_Dif; }
            set { SetPropertyValue<decimal>("SDB_Dif", ref fSDB_Dif, value); }
        }

        private decimal fIEP_Dif;// fonction fait
        public decimal IEP_Dif
        {
            get { return fIEP_Dif; }
            set { SetPropertyValue<decimal>("IEP_Dif", ref fIEP_Dif, value); }
        }


        private decimal fIEP_Ext_Dif;// fonction fait
        public decimal IEP_Ext_Dif
        {
            get { return fIEP_Ext_Dif; }
            set { SetPropertyValue<decimal>("IEP_Ext_Dif", ref fIEP_Ext_Dif, value); }
        }


        private double fTAUX_IEP_Dif;
        public double TAUX_IEP_Dif
        {
            get { return fTAUX_IEP_Dif; }
            set { SetPropertyValue<double>("TAUX_IEP_Dif", ref fTAUX_IEP_Dif, value); }
        }

        private decimal fiep_fixe_Dif; //saisie dans personne
        public decimal iep_fixe_Dif
        {
            get { return fiep_fixe_Dif; }
            set { SetPropertyValue<decimal>("iep_fixe_Dif", ref fiep_fixe_Dif, value); }
        }
         
        private decimal fabat_Dif;
        public decimal abat_Dif
        {
            get { return fabat_Dif; }
            set { SetPropertyValue<decimal>("abat_Dif", ref fabat_Dif, value); }
        }
         
        private decimal fIrg_bareme_Dif;
        public decimal Irg_bareme_Dif
        {
            get { return fIrg_bareme_Dif; }
            set { SetPropertyValue<decimal>("Irg_bareme_Dif", ref fIrg_bareme_Dif, value); }
        } 

        private decimal fTot_indem_irg_taux_Dif;
        public decimal Tot_indem_irg_taux_Dif
        {
            get { return fTot_indem_irg_taux_Dif; }
            set { SetPropertyValue<decimal>("Tot_indem_irg_taux_Dif", ref fTot_indem_irg_taux_Dif, value); }
        }

        private decimal fSs_bareme_Dif;
        public decimal Ss_bareme_Dif
        {
            get { return fSs_bareme_Dif; }
            set { SetPropertyValue<decimal>("Ss_bareme_Dif", ref fSs_bareme_Dif, value); }
        } 

        private decimal fPlafond_mutuelle_Dif;
        public decimal Plafond_mutuelle_Dif
        {
            get { return fPlafond_mutuelle_Dif; }
            set { SetPropertyValue<decimal>("Plafond_mutuelle_Dif", ref fPlafond_mutuelle_Dif, value); }
        } 

        private decimal fImposable_taux_Dif;
        public decimal Imposable_taux_Dif
        {
            get { return fImposable_taux_Dif; }
            set { SetPropertyValue<decimal>("Imposable_taux_Dif", ref fImposable_taux_Dif, value); }
        }

        private decimal fImposable_bareme_Dif;
        public decimal Imposable_bareme_Dif
        {
            get { return fImposable_bareme_Dif; }
            set { SetPropertyValue<decimal>("Imposable_bareme_Dif", ref fImposable_bareme_Dif, value); }
        }

        private decimal fmutuelle_Dif;
        public decimal mutuelle_Dif
        {
            get { return fmutuelle_Dif; }
            set { SetPropertyValue<decimal>("mutuelle_Dif", ref fmutuelle_Dif, value); }
        }

        private parametre fparametres;
        public parametre parametres
        {
            get { return fparametres; }
            set { SetPropertyValue<parametre>("parametres", ref fparametres, value); }
        } 
         
        private decimal fSU_Dif;
        public decimal SU_Dif
        {
            get { return fSU_Dif; }
            set { SetPropertyValue<decimal>("SU_Dif", ref fSU_Dif, value); }
        }

        private decimal fSU_Partiel_Dif;
        public decimal SU_Partiel_Dif
        {
            get { return fSU_Partiel_Dif; }
            set { SetPropertyValue<decimal>("SU_Partiel_Dif", ref fSU_Partiel_Dif, value); }
        }

        private decimal fAF_Dif;
        public decimal AF_Dif
        {
            get { return fAF_Dif; }
            set { SetPropertyValue<decimal>("AF_Dif", ref fAF_Dif, value); }
        }

        private decimal fAF_Partiel_Dif;
        public decimal AF_Partiel_Dif
        {
            get { return fAF_Partiel_Dif; }
            set { SetPropertyValue<decimal>("AF_Partiel_Dif", ref fAF_Partiel_Dif, value); }
        }

        private decimal fAF_P10_Dif;
        public decimal AF_P10_Dif
        {
            get { return fAF_P10_Dif; }
            set { SetPropertyValue<decimal>("AF_P10_Dif", ref fAF_P10_Dif, value); }
        }

        private decimal fAF_Global_Dif;
        public decimal AF_Global_Dif
        {
            get { return fAF_Global_Dif; }
            set { SetPropertyValue<decimal>("AF_Global_Dif", ref fAF_Global_Dif, value); }
        } 
         

        private decimal fBonif_Resp_Dif;
        public decimal Bonif_Resp_Dif
        {
            get { return fBonif_Resp_Dif; }
            set { SetPropertyValue<decimal>("Bonif_Resp_Dif", ref fBonif_Resp_Dif, value); }
        }

        private decimal fDRet_Dif;
        public decimal DRet_Dif
        {
            get { return fDRet_Dif; }
            set { SetPropertyValue<decimal>("DRet_Dif", ref fDRet_Dif, value); }
        }

        private decimal fVRet_Dif;
        public decimal VRet_Dif
        {
            get { return fVRet_Dif; }
            set { SetPropertyValue<decimal>("VRet_Dif", ref fVRet_Dif, value); }
        }
         
        private decimal fIFSP_Dif;
        public decimal IFSP_Dif
        {
            get { return fIFSP_Dif; }
            set { SetPropertyValue<decimal>("IFSP_Dif", ref fIFSP_Dif, value); }
        }

        private decimal fNUIS_Dif;
        public decimal NUIS_Dif
        {
            get { return fNUIS_Dif; }
            set { SetPropertyValue<decimal>("NUIS_Dif", ref fNUIS_Dif, value); }

        }
         
        private decimal fEncourag_Dif;
        public decimal Encourag_Dif
        {
            get { return fEncourag_Dif; }
            set { SetPropertyValue<decimal>("Encourag_Dif", ref fEncourag_Dif, value); }
        }

        private decimal fIDelegEC_Dif;
        public decimal IDelegEC_Dif
        {
            get { return fIDelegEC_Dif; }
            set { SetPropertyValue<decimal>("IDelegEC_Dif", ref fIDelegEC_Dif, value); }
        }
 
        private decimal fPrime_Pannier_Dif;
        public decimal Prime_Pannier_Dif
        {
            get { return fPrime_Pannier_Dif; }
            set { SetPropertyValue<decimal>("Prime_Pannier_Dif", ref fPrime_Pannier_Dif, value); }
        }

        private decimal fPrime_Transport_Dif;
        public decimal Prime_Transport_Dif
        {
            get { return fPrime_Transport_Dif; }
            set { SetPropertyValue<decimal>("Prime_Transport_Dif", ref fPrime_Transport_Dif, value); }
        }

        private decimal fPRI_Dif;
        public decimal PRI_Dif
        {
            get { return fPRI_Dif; }
            set { SetPropertyValue<decimal>("PRI_Dif", ref fPRI_Dif, value); }
        }

        private decimal fPrime_Km_Dif;
        public decimal Prime_Km_Dif
        {
            get { return fPrime_Km_Dif; }
            set { SetPropertyValue<decimal>("Prime_Km_Dif", ref fPrime_Km_Dif, value); }
        }
         
        private decimal fSujétion_Dif;
        public decimal Sujétion_Dif
        {
            get { return fSujétion_Dif; }
            set { SetPropertyValue<decimal>("Sujétion_Dif", ref fSujétion_Dif, value); }
        }

        private decimal fVariable_Dif;
        public decimal Variable_Dif
        {
            get { return fVariable_Dif; }
            set { SetPropertyValue<decimal>("Variable_Dif", ref fVariable_Dif, value); }
        }

        private decimal fIndem1_Dif;
        public decimal Indem1_Dif
        {
            get { return fIndem1_Dif; }
            set { SetPropertyValue<decimal>("Indem1_Dif", ref fIndem1_Dif, value); }
        }

        private decimal fIndem2_Dif;
        public decimal Indem2_Dif
        {
            get { return fIndem2_Dif; }
            set { SetPropertyValue<decimal>("Indem2_Dif", ref fIndem2_Dif, value); }
        }

        private decimal fIndem3_Dif;
        public decimal Indem3_Dif
        {
            get { return fIndem3_Dif; }
            set { SetPropertyValue<decimal>("Indem3_Dif", ref fIndem3_Dif, value); }
        }

        private decimal fIndem4_Dif;
        public decimal Indem4_Dif
        {
            get { return fIndem4_Dif; }
            set { SetPropertyValue<decimal>("Indem4", ref fIndem4_Dif, value); }
        }

        private decimal fIndem5_Dif;
        public decimal Indem5_Dif
        {
            get { return fIndem5_Dif; }
            set { SetPropertyValue<decimal>("Indem5_Dif", ref fIndem5_Dif, value); }
        }

        private decimal fIndem6_Dif;
        public decimal Indem6_Dif
        {
            get { return fIndem6_Dif; }
            set { SetPropertyValue<decimal>("Indem6_Dif", ref fIndem6_Dif, value); }
        }

        private decimal fIndem7_Dif;
        public decimal Indem7_Dif
        {
            get { return fIndem7_Dif; }
            set { SetPropertyValue<decimal>("Indem7_Dif", ref fIndem7_Dif, value); }
        }

        private decimal fIndem8_Dif;
        public decimal Indem8_Dif
        {
            get { return fIndem8_Dif; }
            set { SetPropertyValue<decimal>("Indem8_Dif", ref fIndem8_Dif, value); }
        }

        private decimal fIndem9_Dif;
        public decimal Indem9_Dif
        {
            get { return fIndem9_Dif; }
            set { SetPropertyValue<decimal>("Indem9_Dif", ref fIndem9_Dif, value); }
        }

        private decimal fIndem10_Dif;
        public decimal Indem10_Dif
        {
            get { return fIndem10_Dif; }
            set { SetPropertyValue<decimal>("Indem10_Dif", ref fIndem10_Dif, value); }
        }

        private decimal fIndem11_Dif;
        public decimal Indem11_Dif
        {
            get { return fIndem11_Dif; }
            set { SetPropertyValue<decimal>("Indem11_Dif", ref fIndem11_Dif, value); }
        }

        private decimal fIndem12_Dif;
        public decimal Indem12_Dif
        {
            get { return fIndem12_Dif; }
            set { SetPropertyValue<decimal>("Indem12_Dif", ref fIndem12_Dif, value); }
        }

        private decimal fIndem13_Dif;
        public decimal Indem13_Dif
        {
            get { return fIndem13_Dif; }
            set { SetPropertyValue<decimal>("Indem13_Dif", ref fIndem13_Dif, value); }
        }

        private decimal fIndem14_Dif;
        public decimal Indem14_Dif
        {
            get { return fIndem14_Dif; }
            set { SetPropertyValue<decimal>("Indem14_Dif", ref fIndem14_Dif, value); }
        }

        private decimal fIndem15_Dif;
        public decimal Indem15_Dif
        {
            get { return fIndem15_Dif; }
            set { SetPropertyValue<decimal>("Indem15_Dif", ref fIndem15_Dif, value); }
        }

        private decimal fIndem16_Dif;
        public decimal Indem16_Dif
        {
            get { return fIndem16_Dif; }
            set { SetPropertyValue<decimal>("Indem16_Dif", ref fIndem16_Dif, value); }
        }

        private decimal fIndem17_Dif;
        public decimal Indem17_Dif
        {
            get { return fIndem17_Dif; }
            set { SetPropertyValue<decimal>("Indem17_Dif", ref fIndem17_Dif, value); }
        }

        private decimal fIndem18_Dif;
        public decimal Indem18_Dif
        {
            get { return fIndem18_Dif; }
            set { SetPropertyValue<decimal>("Indem18_Dif", ref fIndem18_Dif, value); }
        }

        private decimal fIndem19_Dif;
        public decimal Indem19_Dif
        {
            get { return fIndem19_Dif; }
            set { SetPropertyValue<decimal>("Indem19_Dif", ref fIndem19_Dif, value); }
        }

        private decimal fIndem20_Dif;
        public decimal Indem20_Dif
        {
            get { return fIndem20_Dif; }
            set { SetPropertyValue<decimal>("Indem20_Dif", ref fIndem20_Dif, value); }
        }

        private decimal fIndem21_Dif;
        public decimal Indem21_Dif
        {
            get { return fIndem21_Dif; }
            set { SetPropertyValue<decimal>("Indem21_Dif", ref fIndem21_Dif, value); }
        }

        private decimal fIndem22_Dif;
        public decimal Indem22_Dif
        {
            get { return fIndem22_Dif; }
            set { SetPropertyValue<decimal>("Indem22_Dif", ref fIndem22_Dif, value); }
        }

        private decimal fIndem23_Dif;
        public decimal Indem23_Dif
        {
            get { return fIndem23_Dif; }
            set { SetPropertyValue<decimal>("Indem23_Dif", ref fIndem23_Dif, value); }
        }

        private decimal fIndem24_Dif;
        public decimal Indem24_Dif
        {
            get { return fIndem24_Dif; }
            set { SetPropertyValue<decimal>("Indem24_Dif", ref fIndem24_Dif, value); }
        }


        private decimal fIndem25_Dif;
        public decimal Indem25_Dif
        {
            get { return fIndem25_Dif; }
            set { SetPropertyValue<decimal>("Indem25_Dif", ref fIndem25_Dif, value); }
        }


        private decimal fIndem26_Dif;
        public decimal Indem26_Dif
        {
            get { return fIndem26_Dif; }
            set { SetPropertyValue<decimal>("Indem26_Dif", ref fIndem26_Dif, value); }
        }


        private decimal fIndem27_Dif;
        public decimal Indem27_Dif
        {
            get { return fIndem27_Dif; }
            set { SetPropertyValue<decimal>("Indem27_Dif", ref fIndem27_Dif, value); }
        }


        private decimal fIndem28_Dif;
        public decimal Indem28_Dif
        {
            get { return fIndem28_Dif; }
            set { SetPropertyValue<decimal>("Indem28_Dif", ref fIndem28_Dif, value); }
        }


        private decimal fIndem29_Dif;
        public decimal Indem29_Dif
        {
            get { return fIndem29_Dif; }
            set { SetPropertyValue<decimal>("Indem29_Dif", ref fIndem29_Dif, value); }
        }


        private decimal fIndem30_Dif;
        public decimal Indem30_Dif
        {
            get { return fIndem30_Dif; }
            set { SetPropertyValue<decimal>("Indem30_Dif", ref fIndem30_Dif, value); }
        }
         

        private decimal fPrime_Except_Dif;
        public decimal Prime_Except_Dif
        {
            get { return fPrime_Except_Dif; }
            set { SetPropertyValue<decimal>("Prime_Except_Dif", ref fPrime_Except_Dif, value); }
        }


        private decimal fPrime_Victime_Dif;
        public decimal Prime_Victime_Dif
        {
            get { return fPrime_Victime_Dif; }
            set { SetPropertyValue<decimal>("Prime_Victime_Dif", ref fPrime_Victime_Dif, value); }
        }


        private decimal fIncapacite_Perman_Dif;
        public decimal Incapacite_Perman_Dif
        {
            get { return fIncapacite_Perman_Dif; }
            set { SetPropertyValue<decimal>("Incapacite_Perman_Dif", ref fIncapacite_Perman_Dif, value); }
        }

        private decimal fIndem_Conge_Dif;
        public decimal Indem_Conge_Dif
        {
            get { return fIndem_Conge_Dif; }
            set { SetPropertyValue<decimal>("Indem_Conge_Dif", ref fIndem_Conge_Dif, value); }
        }

        private decimal fIndem_STC_Dif;
        public decimal Indem_STC_Dif
        {
            get { return fIndem_STC_Dif; }
            set { SetPropertyValue<decimal>("Indem_STC_Dif", ref fIndem_STC_Dif, value); }
        }

        private decimal fPMG_Dif;
        public decimal PMG_Dif
        {
            get { return fPMG_Dif; }
            set { SetPropertyValue<decimal>("PMG_Dif", ref fPMG_Dif, value); }
        }

        private decimal fShiftNuit_Dif;
        public decimal ShiftNuit_Dif
        {
            get { return fShiftNuit_Dif; }
            set { SetPropertyValue<decimal>("ShiftNuit_Dif", ref fShiftNuit_Dif, value); }
        }

        private decimal fIndem_Conge_Recup_Dif;
        public decimal Indem_Conge_Recup_Dif
        {
            get { return fIndem_Conge_Recup_Dif; }
            set { SetPropertyValue<decimal>("Indem_Conge_Recup_Dif", ref fIndem_Conge_Recup_Dif, value); }
        }

         
        //************************************ Mois *******************************************/


        private decimal fBRUT_Mois;
        public decimal BRUT_Mois
        {
            get { return fBRUT_Mois; }
            set
            {
                SetPropertyValue<decimal>("BRUT_Mois", ref fBRUT_Mois, value);
            }
        }

        private decimal fIRG_Mois;
        public decimal IRG_Mois
        {
            get { return fIRG_Mois; }
            set
            {
                SetPropertyValue<decimal>("IRG_Mois", ref fIRG_Mois, value);
            }
        }

        private decimal fSS_Mois;
        public decimal SS_Mois
        {
            get { return fSS_Mois; }
            set { SetPropertyValue<decimal>("SS_Mois", ref fSS_Mois, value); }
        }

        private decimal fNET_Mois;
        public decimal NET_Mois
        {
            get { return fNET_Mois; }
            set { SetPropertyValue<decimal>("NET_Mois", ref fNET_Mois, value); }
        }

        private decimal fMONTANT_Mois;
        public decimal MONTANT_Mois
        {
            get { return fMONTANT_Mois; }
            set { SetPropertyValue<decimal>("MONTANT_Mois", ref fMONTANT_Mois, value); }
        }

        private decimal fBrute_cotisable_Mois;
        public decimal Brute_cotisable_Mois
        {
            get { return fBrute_cotisable_Mois; }
            set { SetPropertyValue<decimal>("Brute_cotisable_Mois", ref fBrute_cotisable_Mois, value); }
        }

        private decimal fBrute_imposable_Mois;
        public decimal Brute_imposable_Mois
        {
            get { return fBrute_imposable_Mois; }
            set { SetPropertyValue<decimal>("Brute_imposable_Mois", ref fBrute_imposable_Mois, value); }
        }

        private int fNBR_Mois;
        public int NBR_Mois
        {
            get { return fNBR_Mois; }
            set { SetPropertyValue<int>("NBR_Mois", ref fNBR_Mois, value); }
        }
         

        private decimal fSDB_Mois; //fonction fait
        public decimal SDB_Mois
        {
            get { return fSDB_Mois; }
            set { SetPropertyValue<decimal>("SDB_Mois", ref fSDB_Mois, value); }
        }

        private decimal fIEP_Mois;// fonction fait
        public decimal IEP_Mois
        {
            get { return fIEP_Mois; }
            set { SetPropertyValue<decimal>("IEP_Mois", ref fIEP_Mois, value); }
        }


        private decimal fIEP_Ext_Mois;// fonction fait
        public decimal IEP_Ext_Mois
        {
            get { return fIEP_Ext_Mois; }
            set { SetPropertyValue<decimal>("IEP_Ext_Mois", ref fIEP_Ext_Mois, value); }
        } 
        private double fTAUX_IEP_Mois;
        public double TAUX_IEP_Mois
        {
            get { return fTAUX_IEP_Mois; }
            set { SetPropertyValue<double>("TAUX_IEP_Mois", ref fTAUX_IEP_Mois, value); }
        }

        private decimal fiep_fixe_Mois; //saisie dans personne
        public decimal iep_fixe_Mois
        {
            get { return fiep_fixe_Mois; }
            set { SetPropertyValue<decimal>("iep_fixe_Mois", ref fiep_fixe_Mois, value); }
        }
         
        private decimal fabat_Mois;
        public decimal abat_Mois
        {
            get { return fabat_Mois; }
            set { SetPropertyValue<decimal>("abat_Mois", ref fabat_Mois, value); }
        } 

        private decimal fIrg_bareme_Mois;
        public decimal Irg_bareme_Mois
        {
            get { return fIrg_bareme_Mois; }
            set { SetPropertyValue<decimal>("Irg_bareme_Mois", ref fIrg_bareme_Mois, value); }
        } 

        private decimal fTot_indem_irg_taux_Mois;
        public decimal Tot_indem_irg_taux_Mois
        {
            get { return fTot_indem_irg_taux_Mois; }
            set { SetPropertyValue<decimal>("Tot_indem_irg_taux_Mois", ref fTot_indem_irg_taux_Mois, value); }
        }

        private decimal fSs_bareme_Mois;
        public decimal Ss_bareme_Mois
        {
            get { return fSs_bareme_Mois; }
            set { SetPropertyValue<decimal>("Ss_bareme_Mois", ref fSs_bareme_Mois, value); }
        } 

        private decimal fPlafond_mutuelle_Mois;
        public decimal Plafond_mutuelle_Mois
        {
            get { return fPlafond_mutuelle_Mois; }
            set { SetPropertyValue<decimal>("Plafond_mutuelle_Mois", ref fPlafond_mutuelle_Mois, value); }
        }  

        private decimal fImposable_taux_Mois;
        public decimal Imposable_taux_Mois
        {
            get { return fImposable_taux_Mois; }
            set { SetPropertyValue<decimal>("Imposable_taux_Mois", ref fImposable_taux_Mois, value); }
        }

        private decimal fImposable_bareme_Mois;
        public decimal Imposable_bareme_Mois
        {
            get { return fImposable_bareme_Mois; }
            set { SetPropertyValue<decimal>("Imposable_bareme_Mois", ref fImposable_bareme_Mois, value); }
        }

        private decimal fmutuelle_Mois;
        public decimal mutuelle_Mois
        {
            get { return fmutuelle_Mois; }
            set { SetPropertyValue<decimal>("mutuelle_Mois", ref fmutuelle_Mois, value); }
        } 

        private decimal fSU_Mois;
        public decimal SU_Mois
        {
            get { return fSU_Mois; }
            set { SetPropertyValue<decimal>("SU_Mois", ref fSU_Mois, value); }
        }

        private decimal fSU_Partiel_Mois;
        public decimal SU_Partiel_Mois
        {
            get { return fSU_Partiel_Mois; }
            set { SetPropertyValue<decimal>("SU_Partiel_Mois", ref fSU_Partiel_Mois, value); }
        }

        private decimal fAF_Mois;
        public decimal AF_Mois
        {
            get { return fAF_Mois; }
            set { SetPropertyValue<decimal>("AF_Mois", ref fAF_Mois, value); }
        }

        private decimal fAF_Partiel_Mois;
        public decimal AF_Partiel_Mois
        {
            get { return fAF_Partiel_Mois; }
            set { SetPropertyValue<decimal>("AF_Partiel_Mois", ref fAF_Partiel_Mois, value); }
        }

        private decimal fAF_P10_Mois;
        public decimal AF_P10_Mois
        {
            get { return fAF_P10_Mois; }
            set { SetPropertyValue<decimal>("AF_P10_Mois", ref fAF_P10_Mois, value); }
        }

        private decimal fAF_Global_Mois;
        public decimal AF_Global_Mois
        {
            get { return fAF_Global_Mois; }
            set { SetPropertyValue<decimal>("AF_Global_Mois", ref fAF_Global_Mois, value); }
        }
        
        
        private decimal fBonif_Resp_Mois;
        public decimal Bonif_Resp_Mois
        {
            get { return fBonif_Resp_Mois; }
            set { SetPropertyValue<decimal>("Bonif_Resp_Mois", ref fBonif_Resp_Mois, value); }
        }

        private decimal fDRet_Mois;
        public decimal DRet_Mois
        {
            get { return fDRet_Mois; }
            set { SetPropertyValue<decimal>("DRet_Mois", ref fDRet_Mois, value); }
        }

        private decimal fVRet_Mois;
        public decimal VRet_Mois
        {
            get { return fVRet_Mois; }
            set { SetPropertyValue<decimal>("VRet_Mois", ref fVRet_Mois, value); }
        }

        private decimal fIFSP_Mois;
        public decimal IFSP_Mois
        {
            get { return fIFSP_Mois; }
            set { SetPropertyValue<decimal>("IFSP_Mois", ref fIFSP_Mois, value); }
        }

        private decimal fNUIS_Mois;
        public decimal NUIS_Mois
        {
            get { return fNUIS_Mois; }
            set { SetPropertyValue<decimal>("NUIS_Mois", ref fNUIS_Mois, value); }

        }

        private decimal fEncourag_Mois;
        public decimal Encourag_Mois
        {
            get { return fEncourag_Mois; }
            set { SetPropertyValue<decimal>("Encourag_Mois", ref fEncourag_Mois, value); }
        }

        private decimal fPrime_Pannier_Mois;
        public decimal Prime_Pannier_Mois
        {
            get { return fPrime_Pannier_Mois; }
            set { SetPropertyValue<decimal>("Prime_Pannier_Mois", ref fPrime_Pannier_Mois, value); }
        }

        private decimal fPrime_Transport_Mois;
        public decimal Prime_Transport_Mois
        {
            get { return fPrime_Transport_Mois; }
            set { SetPropertyValue<decimal>("Prime_Transport_Mois", ref fPrime_Transport_Mois, value); }
        }

        private decimal fPRI_Mois;
        public decimal PRI_Mois
        {
            get { return fPRI_Mois; }
            set { SetPropertyValue<decimal>("PRI_Mois", ref fPRI_Mois, value); }
        }

        private decimal fPrime_Km_Mois;
        public decimal Prime_Km_Mois
        {
            get { return fPrime_Km_Mois; }
            set { SetPropertyValue<decimal>("Prime_Km_Mois", ref fPrime_Km_Mois, value); }
        }

        private decimal fSujétion_Mois;
        public decimal Sujétion_Mois
        {
            get { return fSujétion_Mois; }
            set { SetPropertyValue<decimal>("Sujétion_Mois", ref fSujétion_Mois, value); }
        }

        private decimal fVariable_Mois;
        public decimal Variable_Mois
        {
            get { return fVariable_Mois; }
            set { SetPropertyValue<decimal>("Variable_Mois", ref fVariable_Mois, value); }
        }


        private decimal fIndem1_Mois;
        public decimal Indem1_Mois
        {
            get { return fIndem1_Mois; }
            set { SetPropertyValue<decimal>("Indem1_Mois", ref fIndem1_Mois, value); }
        }

        private decimal fIndem2_Mois;
        public decimal Indem2_Mois
        {
            get { return fIndem2_Mois; }
            set { SetPropertyValue<decimal>("Indem2_Mois", ref fIndem2_Mois, value); }
        }

        private decimal fIndem3_Mois;
        public decimal Indem3_Mois
        {
            get { return fIndem3_Mois; }
            set { SetPropertyValue<decimal>("Indem3_Mois", ref fIndem3_Mois, value); }
        }

        private decimal fIndem4_Mois;
        public decimal Indem4_Mois
        {
            get { return fIndem4_Mois; }
            set { SetPropertyValue<decimal>("Indem4", ref fIndem4_Mois, value); }
        }

        private decimal fIndem5_Mois;
        public decimal Indem5_Mois
        {
            get { return fIndem5_Mois; }
            set { SetPropertyValue<decimal>("Indem5_Mois", ref fIndem5_Mois, value); }
        }

        private decimal fIndem6_Mois;
        public decimal Indem6_Mois
        {
            get { return fIndem6_Mois; }
            set { SetPropertyValue<decimal>("Indem6_Mois", ref fIndem6_Mois, value); }
        }

        private decimal fIndem7_Mois;
        public decimal Indem7_Mois
        {
            get { return fIndem7_Mois; }
            set { SetPropertyValue<decimal>("Indem7_Mois", ref fIndem7_Mois, value); }
        }

        private decimal fIndem8_Mois;
        public decimal Indem8_Mois
        {
            get { return fIndem8_Mois; }
            set { SetPropertyValue<decimal>("Indem8_Mois", ref fIndem8_Mois, value); }
        }

        private decimal fIndem9_Mois;
        public decimal Indem9_Mois
        {
            get { return fIndem9_Mois; }
            set { SetPropertyValue<decimal>("Indem9_Mois", ref fIndem9_Mois, value); }
        }

        private decimal fIndem10_Mois;
        public decimal Indem10_Mois
        {
            get { return fIndem10_Mois; }
            set { SetPropertyValue<decimal>("Indem10_Mois", ref fIndem10_Mois, value); }
        }

        private decimal fIndem11_Mois;
        public decimal Indem11_Mois
        {
            get { return fIndem11_Mois; }
            set { SetPropertyValue<decimal>("Indem11_Mois", ref fIndem11_Mois, value); }
        }

        private decimal fIndem12_Mois;
        public decimal Indem12_Mois
        {
            get { return fIndem12_Mois; }
            set { SetPropertyValue<decimal>("Indem12_Mois", ref fIndem12_Mois, value); }
        }

        private decimal fIndem13_Mois;
        public decimal Indem13_Mois
        {
            get { return fIndem13_Mois; }
            set { SetPropertyValue<decimal>("Indem13_Mois", ref fIndem13_Mois, value); }
        }

        private decimal fIndem14_Mois;
        public decimal Indem14_Mois
        {
            get { return fIndem14_Mois; }
            set { SetPropertyValue<decimal>("Indem14_Mois", ref fIndem14_Mois, value); }
        }

        private decimal fIndem15_Mois;
        public decimal Indem15_Mois
        {
            get { return fIndem15_Mois; }
            set { SetPropertyValue<decimal>("Indem15_Mois", ref fIndem15_Mois, value); }
        }

        private decimal fIndem16_Mois;
        public decimal Indem16_Mois
        {
            get { return fIndem16_Mois; }
            set { SetPropertyValue<decimal>("Indem16_Mois", ref fIndem16_Mois, value); }
        }

        private decimal fIndem17_Mois;
        public decimal Indem17_Mois
        {
            get { return fIndem17_Mois; }
            set { SetPropertyValue<decimal>("Indem17_Mois", ref fIndem17_Mois, value); }
        }

        private decimal fIndem18_Mois;
        public decimal Indem18_Mois
        {
            get { return fIndem18_Mois; }
            set { SetPropertyValue<decimal>("Indem18_Mois", ref fIndem18_Mois, value); }
        }

        private decimal fIndem19_Mois;
        public decimal Indem19_Mois
        {
            get { return fIndem19_Mois; }
            set { SetPropertyValue<decimal>("Indem19_Mois", ref fIndem19_Mois, value); }
        }

        private decimal fIndem20_Mois;
        public decimal Indem20_Mois
        {
            get { return fIndem20_Mois; }
            set { SetPropertyValue<decimal>("Indem20_Mois", ref fIndem20_Mois, value); }
        }

        private decimal fIndem21_Mois;
        public decimal Indem21_Mois
        {
            get { return fIndem21_Mois; }
            set { SetPropertyValue<decimal>("Indem21_Mois", ref fIndem21_Mois, value); }
        }

        private decimal fIndem22_Mois;
        public decimal Indem22_Mois
        {
            get { return fIndem22_Mois; }
            set { SetPropertyValue<decimal>("Indem22_Mois", ref fIndem22_Mois, value); }
        }

        private decimal fIndem23_Mois;
        public decimal Indem23_Mois
        {
            get { return fIndem23_Mois; }
            set { SetPropertyValue<decimal>("Indem23_Mois", ref fIndem23_Mois, value); }
        }

        private decimal fIndem24_Mois;
        public decimal Indem24_Mois
        {
            get { return fIndem24_Mois; }
            set { SetPropertyValue<decimal>("Indem24_Mois", ref fIndem24_Mois, value); }
        }


        private decimal fIndem25_Mois;
        public decimal Indem25_Mois
        {
            get { return fIndem25_Mois; }
            set { SetPropertyValue<decimal>("Indem25_Mois", ref fIndem25_Mois, value); }
        }


        private decimal fIndem26_Mois;
        public decimal Indem26_Mois
        {
            get { return fIndem26_Mois; }
            set { SetPropertyValue<decimal>("Indem26_Mois", ref fIndem26_Mois, value); }
        }


        private decimal fIndem27_Mois;
        public decimal Indem27_Mois
        {
            get { return fIndem27_Mois; }
            set { SetPropertyValue<decimal>("Indem27_Mois", ref fIndem27_Mois, value); }
        }


        private decimal fIndem28_Mois;
        public decimal Indem28_Mois
        {
            get { return fIndem28_Mois; }
            set { SetPropertyValue<decimal>("Indem28_Mois", ref fIndem28_Mois, value); }
        }


        private decimal fIndem29_Mois;
        public decimal Indem29_Mois
        {
            get { return fIndem29_Mois; }
            set { SetPropertyValue<decimal>("Indem29_Mois", ref fIndem29_Mois, value); }
        }


        private decimal fIndem30_Mois;
        public decimal Indem30_Mois
        {
            get { return fIndem30_Mois; }
            set { SetPropertyValue<decimal>("Indem30_Mois", ref fIndem30_Mois, value); }
        }


        private decimal fPrime_Except_Mois;
        public decimal Prime_Except_Mois
        {
            get { return fPrime_Except_Mois; }
            set { SetPropertyValue<decimal>("Prime_Except_Mois", ref fPrime_Except_Mois, value); }
        }


        private decimal fPrime_Victime_Mois;
        public decimal Prime_Victime_Mois
        {
            get { return fPrime_Victime_Mois; }
            set { SetPropertyValue<decimal>("Prime_Victime_Mois", ref fPrime_Victime_Mois, value); }
        }


        private decimal fIncapacite_Perman_Mois;
        public decimal Incapacite_Perman_Mois
        {
            get { return fIncapacite_Perman_Mois; }
            set { SetPropertyValue<decimal>("Incapacite_Perman_Mois", ref fIncapacite_Perman_Mois, value); }
        }

        private decimal fIndem_Conge_Mois;
        public decimal Indem_Conge_Mois
        {
            get { return fIndem_Conge_Mois; }
            set { SetPropertyValue<decimal>("Indem_Conge_Mois", ref fIndem_Conge_Mois, value); }
        }

        private decimal fIndem_STC_Mois;
        public decimal Indem_STC_Mois
        {
            get { return fIndem_STC_Mois; }
            set { SetPropertyValue<decimal>("Indem_STC_Mois", ref fIndem_STC_Mois, value); }
        }

        private decimal fPMG_Mois;
        public decimal PMG_Mois
        {
            get { return fPMG_Mois; }
            set { SetPropertyValue<decimal>("PMG_Mois", ref fPMG_Mois, value); }
        }

        private decimal fShiftNuit_Mois;
        public decimal ShiftNuit_Mois
        {
            get { return fShiftNuit_Mois; }
            set { SetPropertyValue<decimal>("ShiftNuit_Mois", ref fShiftNuit_Mois, value); }
        }

        private decimal fIndem_Conge_Recup_Mois;
        public decimal Indem_Conge_Recup_Mois
        {
            get { return fIndem_Conge_Recup_Mois; }
            set { SetPropertyValue<decimal>("Indem_Conge_Recup_Mois", ref fIndem_Conge_Recup_Mois, value); }
        }

        /***************************************************************************************************************/
        private DateTime fDate_Début;
        public DateTime Date_Début
        {
            get { return fDate_Début; }
            set
            {
                SetPropertyValue<DateTime>("Date_Début", ref fDate_Début, value);
            }
        }

        private DateTime fDate_Fin;
        public DateTime Date_Fin
        {
            get { return fDate_Fin; }
            set
            {
                SetPropertyValue<DateTime>("Date_Fin", ref fDate_Fin, value);
            }
        }

        //private Motif_Etat_Matrice fMotif_Rappel;
        //public Motif_Etat_Matrice Motif_Rappel
        //{
        //    get { return fMotif_Rappel; }
        //    set { SetPropertyValue<Motif_Etat_Matrice>("Motif_Rappel", ref fMotif_Rappel, value); }
        //}


        public Rappel(Session session)
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

            NBR_Mois = 0;
            Date_Fin = DateTime.Parse("31/12/" + DateTime.Now.Year.ToString());
            Date_Début = DateTime.Parse("1/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());

            parametres = parametre.GetInstance(Session); 

            //parametres = Parametres;
            Annee = parametres.Annee_Travail;
              
        }

        Arrondi_Decimal ArrondiDecimale = new Arrondi_Decimal(); 
        CalculerNbrMois CalculerNbrMois = new CalculerNbrMois();

        public void InsererRappelIndemnite(string code_Rappel_personne)
        {
            Session currentSession = this.Session; 
           // NBR_Mois = Date_Fin.Month - Date_Début.Month + 1;

            NBR_Mois = CalculerNbrMois.CalculNbrMois(Date_Début, Date_Fin);

            foreach (paye_indem IndemNou in Paye_Nouveau.paye_indems)
            {
                CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_indem_interne==?", IndemNou.Indemnite.Cod_indem_interne);
                CriteriaOperator criteria2 = CriteriaOperator.Parse("Cod_Rappel==?", code_Rappel_personne);
                CriteriaOperator criteria3 = CriteriaOperator.Parse("Rappel==?", this);
                Rappel_indem RappelIndem = currentSession.FindObject<Rappel_indem>(PersistentCriteriaEvaluationBehavior.InTransaction, CriteriaOperator.And(criteria1, criteria2, criteria3));

                    if (RappelIndem != null)
                    {
                        RappelIndem.Montant_Nouveau = IndemNou.Montant_Absence;
                        RappelIndem.Montant_Dif = RappelIndem.Montant_Nouveau - RappelIndem.Montant_Ancien;
                        RappelIndem.Montant_Mois = RappelIndem.Montant_Dif * NBR_Mois; 

                        RappelIndem.Save();

                        AffectationIndemniteLignesAuColonnesDif(RappelIndem.Indemnite.Cod_indem_interne, RappelIndem.Montant_Dif);
                        AffectationIndemniteLignesAuColonnesMois(RappelIndem.Indemnite.Cod_indem_interne, RappelIndem.Montant_Mois);

                        this.Save();
                    }
                    else
                    {
                        Rappel_indem IndemniteAInserer = new Rappel_indem(currentSession);
                        IndemniteAInserer.Cod_Rappel = code_Rappel_personne;
                        IndemniteAInserer.Indemnite = IndemNou.Indemnite;
                        IndemniteAInserer.Cod_indem = IndemNou.Indemnite.Cod_indem;
                        IndemniteAInserer.Cod_indem_interne = IndemNou.Indemnite.Cod_indem_interne;
                        IndemniteAInserer.Montant_Nouveau = IndemNou.Montant_Absence;
                        IndemniteAInserer.Montant_Ancien = 0;
                        IndemniteAInserer.Montant_Dif = IndemniteAInserer.Montant_Nouveau - IndemniteAInserer.Montant_Ancien;
                        IndemniteAInserer.Montant_Mois = IndemniteAInserer.Montant_Dif * NBR_Mois; 

                        Rappel_indems.Add(IndemniteAInserer);

                        AffectationIndemniteLignesAuColonnesDif(IndemniteAInserer.Indemnite.Cod_indem_interne, IndemniteAInserer.Montant_Dif);
                        AffectationIndemniteLignesAuColonnesMois(IndemniteAInserer.Indemnite.Cod_indem_interne, IndemniteAInserer.Montant_Mois);

                        this.Save();
                    } 

            }

            foreach (paye_indem IndemAnc in Paye_Ancien.paye_indems)
            {

                CriteriaOperator criteria1 = CriteriaOperator.Parse("Cod_indem_interne==?", IndemAnc.Indemnite.Cod_indem_interne);
                CriteriaOperator criteria2 = CriteriaOperator.Parse("Cod_Rappel==?", code_Rappel_personne);
                CriteriaOperator criteria3 = CriteriaOperator.Parse("Rappel==?", this);
                Rappel_indem RappelIndem = currentSession.FindObject<Rappel_indem>(PersistentCriteriaEvaluationBehavior.InTransaction, CriteriaOperator.And(criteria1, criteria2, criteria3));
                    
                    if (RappelIndem == null)
                    {
                        Rappel_indem IndemniteAInserer = new Rappel_indem(currentSession);
                        IndemniteAInserer.Cod_Rappel = code_Rappel_personne;
                        IndemniteAInserer.Indemnite = IndemAnc.Indemnite;
                        IndemniteAInserer.Cod_indem = IndemAnc.Indemnite.Cod_indem;
                        IndemniteAInserer.Cod_indem_interne = IndemAnc.Indemnite.Cod_indem_interne;
                        IndemniteAInserer.Montant_Nouveau = 0;
                        IndemniteAInserer.Montant_Ancien = IndemAnc.Montant_Absence;
                        IndemniteAInserer.Montant_Dif = IndemniteAInserer.Montant_Nouveau - IndemniteAInserer.Montant_Ancien;
                        IndemniteAInserer.Montant_Mois = IndemniteAInserer.Montant_Dif * NBR_Mois; 

                        Rappel_indems.Add(IndemniteAInserer);

                        AffectationIndemniteLignesAuColonnesDif(IndemniteAInserer.Indemnite.Cod_indem_interne, IndemniteAInserer.Montant_Dif);
                        AffectationIndemniteLignesAuColonnesMois(IndemniteAInserer.Indemnite.Cod_indem_interne, IndemniteAInserer.Montant_Mois);

                        this.Save();
                    }
                    else
                    {
                        RappelIndem.Montant_Ancien = IndemAnc.Montant_Absence;
                        RappelIndem.Montant_Dif = RappelIndem.Montant_Nouveau - RappelIndem.Montant_Ancien;
                        RappelIndem.Montant_Mois = RappelIndem.Montant_Dif * NBR_Mois; 

                        RappelIndem.Save();

                        AffectationIndemniteLignesAuColonnesDif(RappelIndem.Indemnite.Cod_indem_interne, RappelIndem.Montant_Dif);
                        AffectationIndemniteLignesAuColonnesMois(RappelIndem.Indemnite.Cod_indem_interne, RappelIndem.Montant_Mois);

                        this.Save();
                    } 
            }
        }

        public void AffectationIndemniteLignesAuColonnesDif(string Cod_Indemnite, decimal XMontant) // Uniquement pour les indemnités qui se calculent à partir de CalculTotaux
        { 
                string ind_Dif =  Cod_Indemnite.ToString() + "_Dif";
                this.SetMemberValue(ind_Dif, XMontant);  
        }

        public void AffectationIndemniteLignesAuColonnesMois(string Cod_Indemnite, decimal XMontant) // Uniquement pour les indemnités qui se calculent à partir de CalculTotaux
        { 
            string ind_Mois = Cod_Indemnite.ToString() + "_Mois";
                this.SetMemberValue(ind_Mois, XMontant); 
        }

    }     
}
