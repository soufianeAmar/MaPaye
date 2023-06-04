using System;
using DevExpress.Xpo;
namespace Paye2001
{

    public class Bareme2008 : XPLiteObject
    {
        int fCATSEC;
        [Key]
        public int CATSEC
        {
            get { return fCATSEC; }
            set { SetPropertyValue<int>("CATSEC", ref fCATSEC, value); }
        }
        double fSDB;
        public double SDB
        {
            get { return fSDB; }
            set { SetPropertyValue<double>("SDB", ref fSDB, value); }
        }
        double fECH1;
        public double ECH1
        {
            get { return fECH1; }
            set { SetPropertyValue<double>("ECH1", ref fECH1, value); }
        }
        double fECH2;
        public double ECH2
        {
            get { return fECH2; }
            set { SetPropertyValue<double>("ECH2", ref fECH2, value); }
        }
        double fECH3;
        public double ECH3
        {
            get { return fECH3; }
            set { SetPropertyValue<double>("ECH3", ref fECH3, value); }
        }
        double fECH4;
        public double ECH4
        {
            get { return fECH4; }
            set { SetPropertyValue<double>("ECH4", ref fECH4, value); }
        }
        double fECH5;
        public double ECH5
        {
            get { return fECH5; }
            set { SetPropertyValue<double>("ECH5", ref fECH5, value); }
        }
        double fECH6;
        public double ECH6
        {
            get { return fECH6; }
            set { SetPropertyValue<double>("ECH6", ref fECH6, value); }
        }
        double fECH7;
        public double ECH7
        {
            get { return fECH7; }
            set { SetPropertyValue<double>("ECH7", ref fECH7, value); }
        }
        double fECH8;
        public double ECH8
        {
            get { return fECH8; }
            set { SetPropertyValue<double>("ECH8", ref fECH8, value); }
        }
        double fECH9;
        public double ECH9
        {
            get { return fECH9; }
            set { SetPropertyValue<double>("ECH9", ref fECH9, value); }
        }
        double fECH10;
        public double ECH10
        {
            get { return fECH10; }
            set { SetPropertyValue<double>("ECH10", ref fECH10, value); }
        }
        double fECH11;
        public double ECH11
        {
            get { return fECH11; }
            set { SetPropertyValue<double>("ECH11", ref fECH11, value); }
        }
        double fECH12;
        public double ECH12
        {
            get { return fECH12; }
            set { SetPropertyValue<double>("ECH12", ref fECH12, value); }
        }
        public Bareme2008(Session session) : base(session) { }
        public Bareme2008() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    public class Bareme2001 : XPLiteObject
    {
        int fCATSEC;
        [Key]
        public int CATSEC
        {
            get { return fCATSEC; }
            set { SetPropertyValue<int>("CATSEC", ref fCATSEC, value); }
        }
        double fSDB;
        public double SDB
        {
            get { return fSDB; }
            set { SetPropertyValue<double>("SDB", ref fSDB, value); }
        }
        double fECH1;
        public double ECH1
        {
            get { return fECH1; }
            set { SetPropertyValue<double>("ECH1", ref fECH1, value); }
        }
        double fECH2;
        public double ECH2
        {
            get { return fECH2; }
            set { SetPropertyValue<double>("ECH2", ref fECH2, value); }
        }
        double fECH3;
        public double ECH3
        {
            get { return fECH3; }
            set { SetPropertyValue<double>("ECH3", ref fECH3, value); }
        }
        double fECH4;
        public double ECH4
        {
            get { return fECH4; }
            set { SetPropertyValue<double>("ECH4", ref fECH4, value); }
        }
        double fECH5;
        public double ECH5
        {
            get { return fECH5; }
            set { SetPropertyValue<double>("ECH5", ref fECH5, value); }
        }
        double fECH6;
        public double ECH6
        {
            get { return fECH6; }
            set { SetPropertyValue<double>("ECH6", ref fECH6, value); }
        }
        double fECH7;
        public double ECH7
        {
            get { return fECH7; }
            set { SetPropertyValue<double>("ECH7", ref fECH7, value); }
        }
        double fECH8;
        public double ECH8
        {
            get { return fECH8; }
            set { SetPropertyValue<double>("ECH8", ref fECH8, value); }
        }
        double fECH9;
        public double ECH9
        {
            get { return fECH9; }
            set { SetPropertyValue<double>("ECH9", ref fECH9, value); }
        }
        double fECH10;
        public double ECH10
        {
            get { return fECH10; }
            set { SetPropertyValue<double>("ECH10", ref fECH10, value); }
        }
        double fECH11;
        public double ECH11
        {
            get { return fECH11; }
            set { SetPropertyValue<double>("ECH11", ref fECH11, value); }
        }
        double fECH12;
        public double ECH12
        {
            get { return fECH12; }
            set { SetPropertyValue<double>("ECH12", ref fECH12, value); }
        }
        public Bareme2001(Session session) : base(session) { }
        public Bareme2001() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    public class categorie : XPLiteObject
    {
        int fCodeCat;
        [Key]
        public int CodeCat
        {
            get { return fCodeCat; }
            set { SetPropertyValue<int>("CodeCat", ref fCodeCat, value); }
        }
        string fCategorieTechnique;
        [Size(30)]
        public string CategorieTechnique
        {
            get { return fCategorieTechnique; }
            set { SetPropertyValue<string>("CategorieTechnique", ref fCategorieTechnique, value); }
        }
        string fCategorieTechAr;
        [Size(30)]
        public string CategorieTechAr
        {
            get { return fCategorieTechAr; }
            set { SetPropertyValue<string>("CategorieTechAr", ref fCategorieTechAr, value); }
        }
        string fetabli_par;
        [Size(50)]
        public string etabli_par
        {
            get { return fetabli_par; }
            set { SetPropertyValue<string>("etabli_par", ref fetabli_par, value); }
        }
        string fmodifie_par;
        [Size(50)]
        public string modifie_par
        {
            get { return fmodifie_par; }
            set { SetPropertyValue<string>("modifie_par", ref fmodifie_par, value); }
        }
        DateTime fdat_creation;
        public DateTime dat_creation
        {
            get { return fdat_creation; }
            set { SetPropertyValue<DateTime>("dat_creation", ref fdat_creation, value); }
        }
        DateTime fdat_modif;
        public DateTime dat_modif
        {
            get { return fdat_modif; }
            set { SetPropertyValue<DateTime>("dat_modif", ref fdat_modif, value); }
        }
        string fvalidepar;
        [Size(50)]
        public string validepar
        {
            get { return fvalidepar; }
            set { SetPropertyValue<string>("validepar", ref fvalidepar, value); }
        }
        DateTime fvalide_le;
        public DateTime valide_le
        {
            get { return fvalide_le; }
            set { SetPropertyValue<DateTime>("valide_le", ref fvalide_le, value); }
        }
        bool fvalide;
        public bool valide
        {
            get { return fvalide; }
            set { SetPropertyValue<bool>("valide", ref fvalide, value); }
        }
        string fUID;
        [Size(50)]
        public string UID
        {
            get { return fUID; }
            set { SetPropertyValue<string>("UID", ref fUID, value); }
        }
        public categorie(Session session) : base(session) { }
        public categorie() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    public class BAREME89 : XPLiteObject
    {
        int fCATSEC;
        [Key]
        public int CATSEC
        {
            get { return fCATSEC; }
            set { SetPropertyValue<int>("CATSEC", ref fCATSEC, value); }
        }
        double fSDB;
        public double SDB
        {
            get { return fSDB; }
            set { SetPropertyValue<double>("SDB", ref fSDB, value); }
        }
        double fECH1;
        public double ECH1
        {
            get { return fECH1; }
            set { SetPropertyValue<double>("ECH1", ref fECH1, value); }
        }
        double fECH2;
        public double ECH2
        {
            get { return fECH2; }
            set { SetPropertyValue<double>("ECH2", ref fECH2, value); }
        }
        double fECH3;
        public double ECH3
        {
            get { return fECH3; }
            set { SetPropertyValue<double>("ECH3", ref fECH3, value); }
        }
        double fECH4;
        public double ECH4
        {
            get { return fECH4; }
            set { SetPropertyValue<double>("ECH4", ref fECH4, value); }
        }
        double fECH5;
        public double ECH5
        {
            get { return fECH5; }
            set { SetPropertyValue<double>("ECH5", ref fECH5, value); }
        }
        double fECH6;
        public double ECH6
        {
            get { return fECH6; }
            set { SetPropertyValue<double>("ECH6", ref fECH6, value); }
        }
        double fECH7;
        public double ECH7
        {
            get { return fECH7; }
            set { SetPropertyValue<double>("ECH7", ref fECH7, value); }
        }
        double fECH8;
        public double ECH8
        {
            get { return fECH8; }
            set { SetPropertyValue<double>("ECH8", ref fECH8, value); }
        }
        double fECH9;
        public double ECH9
        {
            get { return fECH9; }
            set { SetPropertyValue<double>("ECH9", ref fECH9, value); }
        }
        double fECH10;
        public double ECH10
        {
            get { return fECH10; }
            set { SetPropertyValue<double>("ECH10", ref fECH10, value); }
        }
        double fECH11;
        public double ECH11
        {
            get { return fECH11; }
            set { SetPropertyValue<double>("ECH11", ref fECH11, value); }
        }
        double fECH12;
        public double ECH12
        {
            get { return fECH12; }
            set { SetPropertyValue<double>("ECH12", ref fECH12, value); }
        }
        public BAREME89(Session session) : base(session) { }
        public BAREME89() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
    public static class Paye2001SprocHelper
    {
    }


}
