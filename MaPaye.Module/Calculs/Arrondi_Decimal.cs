using System;
using System.Collections.Generic; 
using System.Text;
using MaPaye.Module;

namespace MaPaye.Module
{

    public class Arrondi_Decimal
    {
        //********************************************************
        public decimal Arrondi(int index, decimal XBase)
        { 
            if (index == 0)
            {
                decimal X = 0; int Partie_ent = 0;

                X = XBase * 100;

                Partie_ent = (int)X;            //retirer la partie entiére 
                XBase = (decimal)Partie_ent / 100;
                //XBase = (decimal)Math.Truncate(XBase);
            }
            else
                if (index == 1)
                {
                    //Code à saisir
                    decimal X = 0; int Partie_ent = 0;


                    X = XBase * 100;
                    string chaine = X.ToString();

                    int i = 0;
                    int exist = 0;
                    decimal chiffre = 0;

                    while ((i < chaine.Length) && (exist == 0))
                    {
                        if (chaine[i] == '.' || chaine[i] == ',')
                        {
                            chiffre = decimal.Parse(chaine[i + 1].ToString());
                            exist = 1;
                        }

                        i = i + 1;
                    }

                    Partie_ent = (int)X;

                    if (chiffre >= 5)
                        Partie_ent += 1;

                    //retirer la partie entiére 
                    XBase = (decimal)Partie_ent / 100;

                    //XBase = (decimal)Math.Round(XBase, 2);
                }
                else
                    if (index == 2)
                    {
                        decimal X = 0; int Partie_ent = 0;


                        X = XBase * 100;
                        string chaine = X.ToString();

                        int i = 0;
                        int exist = 0;
                        decimal chiffre = 0;

                        while ((i < chaine.Length) && (exist == 0))
                        {
                            if (chaine[i] == '.')
                            {
                                chiffre = decimal.Parse(chaine[i + 1].ToString());
                                exist = 1;
                            }

                            i = i + 1;
                        }

                        Partie_ent = (int)X;
                        if (chiffre != 0)
                            Partie_ent += 1;

                        //retirer la partie entiére 
                        XBase = (decimal)Partie_ent / 100;
                        //XBase = Math.Round(XBase, 2, MidpointRounding.AwayFromZero);
                    }

            return (XBase);

        }
    }
}
