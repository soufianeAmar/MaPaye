using System;
using System.Collections.Generic; 
using System.Text;
using MaPaye.Module;
using System.Windows.Forms;

namespace MaPaye.Module
{
    public class CalculEvers
    {

        Arrondi_Decimal ArrondiDecimale = new Arrondi_Decimal();

        public decimal CalculerIrg(decimal Soumis, parametre parametre)
        { 
                int[] Trs = { 0, 120000, 360000, 1440000, 99999999 };
                int[] Tax = { 0, 0, 20, 30, 35 };
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
                IrgRes = ArrondiDecimale.Arrondi((Int16)parametre.Mode_Arrondi, IrgRes);

                return IrgRes;
        }
         
        public void Calcul(decimal NET, decimal difference, decimal IRG, decimal SS,decimal cacobatph, decimal BRUT, parametre parametre)
        {
            if (NET <= 0)
                MessageBox.Show("Valeur incorrecte du net voulu !");
            else
            if (difference < 0)
             MessageBox.Show("Valeur incorrecte de la différence !");
            else
            {
                decimal net_voulu = NET;
                decimal val = net_voulu;
                    /// difference;
                decimal Brute1 = net_voulu + val;
                decimal soumis = Brute1 * (1 - (decimal)((parametre.Taux_ss + parametre.Taux_cacobatph) / 100));
                soumis = ArrondiDecimale.Arrondi((Int16)parametre.Mode_Arrondi, soumis); 

                decimal IRGRes = 0;
                IRGRes = CalculerIrg(soumis, parametre);

                decimal net_obtenu1 = (Brute1 * (1 - (decimal)((parametre.Taux_ss + parametre.Taux_cacobatph) * 0.01))) - IRGRes;
                net_obtenu1 = ArrondiDecimale.Arrondi((Int16)parametre.Mode_Arrondi, net_obtenu1); 

                while ((net_obtenu1 - net_voulu) > difference)
                {
                    val = val / 2;
                    if (net_obtenu1 > net_voulu)
                        Brute1 = Brute1 - val;
                    else
                        Brute1 = Brute1 + val;

                    soumis = Brute1 * (1 - (decimal)((parametre.Taux_ss + parametre.Taux_cacobatph) * 0.01));
                    soumis = ArrondiDecimale.Arrondi((Int16)parametre.Mode_Arrondi, soumis); 

                    IRGRes= CalculerIrg(soumis, parametre);
                    net_obtenu1 = (Brute1 * (1 - (decimal)((parametre.Taux_ss + parametre.Taux_cacobatph) * 0.01))) - (decimal)IRGRes;
                    net_obtenu1 = ArrondiDecimale.Arrondi((Int16)parametre.Mode_Arrondi, net_obtenu1); 
                }

                NET = net_obtenu1;
                BRUT = Brute1;
                SS = Brute1 * (decimal)(parametre.Taux_ss * 0.01);
                SS = ArrondiDecimale.Arrondi((Int16)parametre.Mode_Arrondi, SS);

                cacobatph = Brute1 * (decimal)(parametre.Taux_cacobatph * 0.01);
                cacobatph = ArrondiDecimale.Arrondi((Int16)parametre.Mode_Arrondi, cacobatph);

                IRG = (decimal)IRGRes;

                //mutuelle = Brute1 * parametretaux_mutuel / 100;

            }
        }
    }
}
