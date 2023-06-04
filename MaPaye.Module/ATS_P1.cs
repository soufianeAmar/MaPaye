using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MaPaye.Module
{
    public partial class ATS_P1 : DevExpress.XtraReports.UI.XtraReport
    {
        DateTime DateArret;
        DateTime DateReprise;

        public ATS_P1(DateTime Arret, DateTime Reprise)
        {
            InitializeComponent();

            DateArret = Arret;
            DateReprise = Reprise;
        }

        private void Date_Reprise_GetValue(object sender, GetValueEventArgs e)
        {
            if (DateReprise != DateTime.MinValue)
                e.Value = DateReprise;
        }

        private void Date_Arret_GetValue(object sender, GetValueEventArgs e)
        { 
            if (DateArret != DateTime.MinValue)
                e.Value = DateArret;
        }

    }
}
