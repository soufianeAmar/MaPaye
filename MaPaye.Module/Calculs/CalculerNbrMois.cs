using System;
using System.Collections.Generic; 
using System.Text;

namespace MaPaye.Module
{
    public class CalculerNbrMois
    {
        public int CalculNbrMois(DateTime DateDebut, DateTime DateFin)
        {
            int NbrMois = 0;

            int NbrAnn = DateFin.Year - DateDebut.Year + 1;

            int Dif = NbrAnn * 12;

            NbrMois = Dif - DateDebut.Month - (12 - DateFin.Month) + 1;
            
            return NbrMois;
        }
    }
}
