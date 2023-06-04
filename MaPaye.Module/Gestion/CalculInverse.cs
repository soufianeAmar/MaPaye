using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Charts.Native;
using System.Globalization;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp;
using MaPaye.Module;

namespace MaPaye.Module
{
    public partial class CalculInverse : Form
    {
        Arrondi_Decimal ArrondiDecimale = new Arrondi_Decimal(); 
        ModeArrondi Mode_Arrondi;

        decimal NET = 0;
        decimal BrutCotis = 0;
        decimal SS = 0;
        decimal BrutImpo = 0;
        decimal IRG = 0;
        decimal Dif = 0;
        decimal IndemCotis = 0;
        decimal IndemImpo = 0;
        decimal IndemNnCotisNnImpo = 0;
        double Taux_SS = 0;
        Session Session = new Session();

        public CalculInverse(ModeArrondi Mode, double taux_ss, Session session)
        {
            InitializeComponent();
            Mode_Arrondi = Mode;
            Taux_SS = taux_ss;
            Session = session;
        }

        public decimal CalculerIrgInvers(decimal Soumis)
        {
            int[] Trs = { 0, 120000, 360000, 1440000, 99999999 };
            int[] Tax = { 0, 0, 0, 30, 35 };//{ 0, 0, 20, 30, 35 };
            int[] Impan = { 0, 0, 48000, 372000, 3367999, 65 };

            decimal soumis = Math.Truncate((Soumis) / 10) * 10;
            decimal Brts = soumis * 12;
            int I = 1;
            while (Brts > Trs[I])
                I += 1;

            int taux = Tax[I];
            int Tb = Trs[I - 1];
            decimal Td = Impan[I - 1];
            decimal N = Brts - Tb;
            decimal ImpotA = (N * taux / 100) + Td; ;
            decimal ImpM = ImpotA / 12;
            decimal Abat = 0;

            Abat = ImpM * 40 / 100;
            if (Abat < 1000) { Abat = 1000; };
            if (Abat > 1500) { Abat = 1500; };

            decimal Ret = ImpM - Abat;
            if (Ret < 0) { Ret = 0; };

            decimal IrgRes = Ret * 10;

            int partent = (int)IrgRes;
            decimal partdec = IrgRes - partent;

            IrgRes = IrgRes - partdec;

            decimal c1 = partdec * 10;
            int partent1 = (int)c1;
            if (c1 > 5) { IrgRes = IrgRes + 1; };
            IrgRes = IrgRes / 10;
            if (IrgRes < 0) { IrgRes = 0; };

            if (IrgRes != 0)
            {
                //2eme abattement 
                if (Soumis > 30000 && Soumis < 35000)
                    IrgRes = ((IrgRes * 8) - 20000) / 3;
            }

            IrgRes = ArrondiDecimale.Arrondi((Int16)ModeArrondi.Arrondi_Mathématique, IrgRes);

            return IrgRes;
        }

        public void CalculIndemUniq()
        { 
            if (textBox1.Text != "")
            {
                SS = 0; BrutImpo = 0; IRG = 0; BrutCotis = 0;

                string uiSep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                if (uiSep.Equals(","))
                    NET = Convert.ToDecimal(textBox1.Text.ToString().Replace(".", ","));
                else
                    NET = Convert.ToDecimal(textBox1.Text.ToString());
                 

            if (NET <= 0)
                MessageBox.Show("Valeur incorrecte du net voulu !");
            else
                if (Dif < 0)
                    MessageBox.Show("Valeur incorrecte de la différence !");
                else
                {
                    decimal net_voulu = NET;
                    decimal val = net_voulu;
                    /// difference;
                    decimal Brute1 = net_voulu + val; // Brut = net_voulu * 2 (grade valeur possible)
                    decimal soumis = Brute1 * (1 - (decimal)((Taux_SS) / 100));//+ Taux_cacobatph
                    soumis = ArrondiDecimale.Arrondi((Int16)ModeArrondi.Arrondi_Mathématique, soumis);

                    decimal IRGRes = 0;
                    IRGRes = CalculerIrgInvers(soumis);

                    decimal net_obtenu1 = (Brute1 * (1 - (decimal)((Taux_SS) * 0.01))) - IRGRes; // net_obtenu1 = soumis - IRGRes (grade valeur possible)+ Taux_cacobatph
                    net_obtenu1 = ArrondiDecimale.Arrondi((Int16)ModeArrondi.Arrondi_Mathématique, net_obtenu1);

                    while (Math.Abs(net_obtenu1 - net_voulu) > Dif)
                    {
                        val = val / 2;
                        if (net_obtenu1 > net_voulu)
                            Brute1 = Brute1 - val;
                        else
                            Brute1 = Brute1 + val;
                        Brute1 = ArrondiDecimale.Arrondi((Int16)ModeArrondi.Arrondi_Mathématique, Brute1);

                        soumis = Brute1 * (1 - (decimal)((Taux_SS) * 0.01));//+ Taux_cacobatph
                        soumis = ArrondiDecimale.Arrondi((Int16)ModeArrondi.Arrondi_Mathématique, soumis);

                        IRGRes = CalculerIrgInvers(soumis);
                        net_obtenu1 = (Brute1 * (1 - (decimal)((Taux_SS) * 0.01))) - (decimal)IRGRes;// + Taux_cacobatph
                        net_obtenu1 = ArrondiDecimale.Arrondi((Int16)ModeArrondi.Arrondi_Mathématique, net_obtenu1);
                    }

                    NET = net_obtenu1;
                    BrutCotis = Brute1;
                    SS = Brute1 * (decimal)(Taux_SS * 0.01);
                    SS = ArrondiDecimale.Arrondi((Int16)ModeArrondi.Arrondi_Mathématique, SS);
                    //cacobatph_Invers = Brute1 * (decimal)(Taux_cacobatph * 0.01);
                    //cacobatph_Invers = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, cacobatph_Invers);
                    BrutImpo = BrutCotis - SS;
                    IRG = (decimal)IRGRes;
                    //mutuelle = Brute1 * parametretaux_mutuel / 100; 

                    textBox1.Text = NET.ToString("n2");
                    textBox2.Text = BrutCotis.ToString("n2");
                    textBox3.Text = SS.ToString("n2");
                    textBox4.Text = BrutImpo.ToString("n2");
                    textBox5.Text = IRG.ToString("n2");
                }
            }
            else
                MessageBox.Show("Veuillez saisir le montant du NET voulu !","Avertissement",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        //public void CalculIndemMulti()
        //{
        //    if (textBox6.Text != "")
        //    {
        //        SS = 0; BrutImpo = 0; IRG = 0; BrutCotis = 0; IndemCotis = 0; IndemImpo = 0; IndemNnCotisNnImpo = 0;
        //        decimal Somme = 0 ;

        //        string uiSep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        //        if (uiSep.Equals(","))
        //            NET = Convert.ToDecimal(textBox6.Text.ToString().Replace(".", ","));
        //        else
        //            NET = Convert.ToDecimal(textBox6.Text.ToString());
                 
        //        if (NET <= 0)
        //            MessageBox.Show("Valeur incorrecte du net voulu !");
        //        else
        //            if (Dif < 0)
        //                MessageBox.Show("Valeur incorrecte de la différence !");
        //            else
        //            {
        //                foreach (DataGridViewRow row in dataGridView1.Rows)
        //                {
        //                    if (row.Cells["Montant"].Value != null)
        //                    {
        //                        decimal mnt = 0;
        //                        if (uiSep.Equals(","))
        //                            mnt = Convert.ToDecimal(row.Cells["Montant"].Value.ToString().Replace(".", ","));
        //                        else
        //                            mnt = Convert.ToDecimal(row.Cells["Montant"].Value);

        //                        bool cotis = Convert.ToBoolean(row.Cells["Cotisable"].Value);
        //                        bool impo = Convert.ToBoolean(row.Cells["Imposable"].Value);

        //                        if (cotis)
        //                            IndemCotis += mnt;
        //                        else
        //                            if (impo)
        //                                IndemImpo += mnt;
        //                            else
        //                                if (!cotis && !impo)
        //                                    IndemNnCotisNnImpo += mnt;
        //                        Somme += mnt;
        //                    }
        //                }

        //                decimal val = NET;
        //                decimal brute1 = NET + val;
        //                decimal MontantRech = brute1 - Somme - IndemNnCotisNnImpo;
        //                decimal soumis = (IndemImpo + MontantRech) - ((IndemCotis + MontantRech) * (((decimal)Taux_SS) / 100));

        //                decimal IRGRes = 0;
        //                IRGRes = CalculerIrgInvers(soumis);

        //                decimal net_obtenu1 = brute1 - ((IndemCotis + MontantRech) * ((decimal)Taux_SS / 100)) - IRGRes;

        //                while ((Math.Abs(net_obtenu1 - NET)) > Dif)
        //                {
        //                    val = val / 2;
        //                    if (net_obtenu1 > NET)
        //                        brute1 = brute1 - val;
        //                    else
        //                        brute1 = brute1 + val;
        //                    brute1 = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, brute1);

        //                    MontantRech = brute1 - Somme;

        //                    soumis = (IndemImpo + MontantRech) - ((IndemCotis + MontantRech) * ((decimal)Taux_SS / 100));

        //                    IRGRes = CalculerIrgInvers(soumis);
        //                    net_obtenu1 = brute1 - ((IndemCotis + MontantRech) * ((decimal)Taux_SS / 100)) - IRGRes;// + Taux_cacobatph
        //                    net_obtenu1 = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, net_obtenu1);

        //                }

        //                BrutCotis = IndemCotis + MontantRech;
        //                SS = (IndemCotis + MontantRech) * ((decimal)Taux_SS / 100);
        //                SS = ArrondiDecimale.Arrondi((Int16)Mode_Arrondi, SS);
        //                BrutImpo = BrutCotis - SS + IndemImpo;
        //                IRG = (decimal)IRGRes;

        //                textBox10.Text = BrutCotis.ToString("n2");
        //                textBox8.Text = SS.ToString("n2");
        //                textBox9.Text = BrutImpo.ToString("n2");
        //                textBox7.Text = IRG.ToString("n2");
        //                textBox6.Text = NET.ToString("n2");
        //            }
        //    }
        //    else
        //        MessageBox.Show("Veuillez saisir le montant du NET voulu !", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //}


        public void CalculIndemMulti()
        {
            if (textBox6.Text != "")
            {
                SS = 0; BrutImpo = 0; IRG = 0; BrutCotis = 0; IndemCotis = 0; IndemImpo = 0; IndemNnCotisNnImpo = 0;
                decimal Somme = 0;

                string uiSep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                if (uiSep.Equals(","))
                    NET = Convert.ToDecimal(textBox6.Text.ToString().Replace(".", ","));
                else
                    NET = Convert.ToDecimal(textBox6.Text.ToString());

                if (NET <= 0)
                    MessageBox.Show("Valeur incorrecte du net voulu !");
                else
                    if (Dif < 0)
                        MessageBox.Show("Valeur incorrecte de la différence !");
                    else
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells["Montant"].Value != null)
                            {
                                decimal mnt = 0;
                                if (uiSep.Equals(","))
                                    mnt = Convert.ToDecimal(row.Cells["Montant"].Value.ToString().Replace(".", ","));
                                else
                                    mnt = Convert.ToDecimal(row.Cells["Montant"].Value);

                                bool cotis = Convert.ToBoolean(row.Cells["Cotisable"].Value);
                                bool impo = Convert.ToBoolean(row.Cells["Imposable"].Value);

                                if (cotis)
                                    IndemCotis += mnt;
                                else
                                    if (impo)
                                        IndemImpo += mnt;
                                    else
                                        if (!cotis && !impo)
                                            IndemNnCotisNnImpo += mnt;
                                Somme += mnt;
                            }
                        }

                        decimal val = NET;
                        decimal brute1 = NET + val;
                        decimal MontantRech = brute1 - Somme - IndemNnCotisNnImpo;
                        decimal soumis = (IndemImpo + MontantRech) - ((IndemCotis + MontantRech) * (((decimal)Taux_SS) / 100));

                        decimal IRGRes = 0;
                        IRGRes = CalculerIrgInvers(soumis);

                        decimal net_obtenu1 = brute1 - ((IndemCotis + MontantRech) * ((decimal)Taux_SS / 100)) - IRGRes;

                        while ((Math.Abs(net_obtenu1 - NET)) > Dif)
                        {
                            val = val / 2;
                            if (net_obtenu1 > NET)
                                brute1 = brute1 - val;
                            else
                                brute1 = brute1 + val;
                            brute1 = ArrondiDecimale.Arrondi((Int16)ModeArrondi.Arrondi_Mathématique, brute1);

                            MontantRech = brute1 - Somme;

                            soumis = (IndemImpo + MontantRech) - ((IndemCotis + MontantRech) * ((decimal)Taux_SS / 100));

                            IRGRes = CalculerIrgInvers(soumis);
                            net_obtenu1 = brute1 - ((IndemCotis + MontantRech) * ((decimal)Taux_SS / 100)) - IRGRes;// + Taux_cacobatph
                            net_obtenu1 = ArrondiDecimale.Arrondi((Int16)ModeArrondi.Arrondi_Mathématique, net_obtenu1);

                        }

                        BrutCotis = IndemCotis + MontantRech;
                        SS = (IndemCotis + MontantRech) * ((decimal)Taux_SS / 100);
                        SS = ArrondiDecimale.Arrondi((Int16)ModeArrondi.Arrondi_Mathématique, SS);
                        BrutImpo = BrutCotis - SS + IndemImpo;
                        IRG = (decimal)IRGRes;

                        textBox10.Text = BrutCotis.ToString("n2");
                        textBox8.Text = SS.ToString("n2");
                        textBox9.Text = BrutImpo.ToString("n2");
                        textBox7.Text = IRG.ToString("n2");
                        textBox6.Text = NET.ToString("n2");
                    }
            }
            else
                MessageBox.Show("Veuillez saisir le montant du NET voulu !", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalculIndemUniq();
        }

        private void CalculInverse_Load(object sender, EventArgs e)
        { 
            xpCollection1.Session = Session;

            textBox1.Text = string.Format("{0:n2}", 0);
            textBox2.Text = string.Format("{0:n2}", 0);
            textBox3.Text = string.Format("{0:n2}", 0);
            textBox4.Text = string.Format("{0:n2}", 0);
            textBox5.Text = string.Format("{0:n2}", 0);

            textBox6.Text = string.Format("{0:n2}", 0);
            textBox10.Text = string.Format("{0:n2}", 0);
            textBox8.Text = string.Format("{0:n2}", 0);
            textBox9.Text = string.Format("{0:n2}", 0);
            textBox7.Text = string.Format("{0:n2}", 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CalculIndemMulti();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        { 
            if (e.KeyCode == Keys.Enter)
            {
                CalculIndemUniq();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculIndemMulti();
            }
        }
    }
}
