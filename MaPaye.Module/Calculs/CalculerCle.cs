using System;
using System.Collections.Generic; 
using System.Text;
using MaPaye.Module;

namespace MaPaye.Module
{

    public class Calculer_Cle
    {
        public string CalculerCleRIP(string num_compte)
        {
            int i, j, s;
            string NumCmpt="",CleRIP="";
            long num, clerip;

            num_compte = num_compte.Replace(" ", "");

            NumCmpt = "99999";
            s = num_compte.Length;
            j = 10 - s;
            i = 0;
            while (i < j)
            {
                NumCmpt += "0";
                i++;
            }
            NumCmpt += num_compte;
            num = Int64.Parse(NumCmpt) * 100;
            clerip = num % 97;
            clerip = 97 - clerip;
            CleRIP = clerip.ToString();

            return CleRIP;
        }

        public string CalculerCleCmpt(string num_compte)
        { 
            int i, j;
            string CleCmpt = ""; 
            int cle;

            i = num_compte.Length;
            cle = 0;
            j = 4;
            while (i >= 1)
            {
                int q = (int.Parse(num_compte[i - 1].ToString())) * j;
                cle = cle + q;
                j = j + 1;
                i = i - 1;
            } 
            cle = cle % 100;
            CleCmpt = cle.ToString(); 
            if (CleCmpt.Length <= 1)
                CleCmpt = "0" + CleCmpt;

            return CleCmpt;
        } 
    }
}
