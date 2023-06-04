using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.ExpressApp.DC;

namespace MaPaye.Module
{
    public class PortfolioFileData : FileAttachmentBase
    {
        public PortfolioFileData(Session session) : base(session) { }
        private DocumentType documentType;
        protected Personne personne;
        [Persistent, Association("Personne-PortfolioFileData")]
        public Personne Personne
        {
            get { return personne; }
            set
            {
                SetPropertyValue("Personne", ref personne, value);
            }
        }

        public DocumentType DocumentType
        {
            get { return documentType; }
            set { SetPropertyValue("DocumentType", ref documentType, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            documentType = DocumentType.Document;
        }


    }

    public enum DocumentType
    {
        Document = 1, 
        [XafDisplayName("Attestation Travail")]Attestation_travail = 2, 
        Diplome = 3,
        Résidence = 4,
        [XafDisplayName("Fiche Familiale")] Fiche_familiale = 5,
        [XafDisplayName("Carte Sécurité Sociale")] Carte_sécurité_sociale = 6,
        [XafDisplayName("Extrait Naissance")] Extrait_Naissance = 7,
        [XafDisplayName("Carte Mutuel")] Carte_mutuel = 8,
        [XafDisplayName("Certificat Scolarité")] Certificat_scolarité = 9,
        [XafDisplayName("Certeficat Medical")] Certeficat_medical = 10,
        [XafDisplayName("Decret Avancement")] Decret_avancement = 11,
        [XafDisplayName("Chèque CCP")] Chèque_CCP = 12,
        [XafDisplayName("Chèque Bancaire")] Chèque_banque = 13
    }

}
