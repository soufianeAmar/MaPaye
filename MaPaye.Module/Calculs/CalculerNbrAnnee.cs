using System;
using System.Collections.Generic; 
using System.Text;

namespace MaPaye.Module
{
    class CalculerNbrAnnee
    {

 //public int CalculerNbrAnne(int xmois, int xAnnee, DateTime Xdate)
        //{
        public int CalculerNbrAnne(DateTime DateDebut, DateTime DateFin)
        {
           
            int Nbr_Ans = 0;
            
            int NbrAnn = DateFin.Year - DateDebut.Year;
            int NbrJrs = DateFin.Day - DateDebut.Day;
            int NbrMois = DateFin.Month - DateDebut.Month;

            //int Dif = NbrMois * 12;

            //Nbr_Ans = Dif - DateDebut.Month - (12 - DateFin.Month) + 1;

            if (NbrAnn <= 0)
                Nbr_Ans = 0;
            else
            {
                if ((NbrJrs < 0) && (NbrMois < 0))
                    Nbr_Ans = NbrAnn - 1;
                else
                    if ((NbrJrs < 0) && (NbrMois == 0))
                        Nbr_Ans = NbrAnn - 1;
                    else
                        if ((NbrJrs < 0) && (NbrMois > 0))
                            Nbr_Ans = NbrAnn;
                        else
                            if ((NbrJrs >= 0) && (NbrMois < 0))
                                Nbr_Ans = NbrAnn - 1;
                            else
                                if ((NbrJrs >= 0) && (NbrMois >= 0))
                                    Nbr_Ans = NbrAnn;

            }
                return Nbr_Ans;
        }
    }
}
