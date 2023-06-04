using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using System.Text;
using System.Diagnostics;

namespace MaPaye.Module
{
    //[DefaultClassOptions]
    public class Convertisseur_Ar_Fr  
    {
        /// <summary>
        /// Convertion d'un montant en toutes lettres
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public string Int2Lettres(Int64 value)
        {

            Int64
                division,
                reste;
            StringBuilder sb;

            try
            {
                //Test l'Ètat null
                if (value == 0) return "ZÈro";

                //DÈcomposition de la valeur en milliards, millions, milliers,...

                sb = new StringBuilder();

                //milliard
                division = Math.DivRem(value, 1000000000, out reste);
                if (division > 0)
                {
                    Int2LettresBloc(sb, division);
                    sb.Append(" Milliard(s)");
                    //if (division > 1) sb.Append('s');
                }

                if (reste > 0)
                {
                    //million
                    value = reste;
                    division = Math.DivRem(value, 1000000, out reste);
                    if (division > 0)
                    {
                        if (sb.Length > 0) sb.Append(' ');
                        Int2LettresBloc(sb, division);
                        sb.Append(" Million(s)");
                        //if (division > 1) sb.Append('s');
                    }

                    if (reste > 0)
                    {
                        //milliers
                        value = reste;
                        division = Math.DivRem(value, 1000, out reste);
                        if (division > 0)
                        {
                            if (sb.Length > 0) sb.Append(' ');
                            if (division == 1)
                                sb.Append("Mille(s)");
                            else
                            {
                                Int2LettresBloc(sb, division);
                                sb.Append(" Mille(s)");
                            }
                        }
                        if (reste > 0)
                        {
                            //reste
                            if (sb.Length > 0) sb.Append(' ');
                            Int2LettresBloc(sb, reste);
                        }
                    }
                }
                return sb.ToString();
            }

            finally
            {
                sb = null;
            }
        }

        /// <summary>
        /// Retourne la conversion d'un bloc de 3 bloc
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        private void Int2LettresBloc(StringBuilder sb, Int64 value)
        {
            Boolean b_centaines;
            Int64
                division,
                reste;

            try
            {
                division = Math.DivRem(value, 100, out reste);

                //Test si des centaines sont prÈsentes
                if (division > 0)
                {
                    //ajout des centaines ‡ la sortie
                    switch (division)
                    {
                        case 1:
                            {
                                sb.Append("Cent(s)");
                                break;
                            }
                        default:
                            {
                                Int2LettresBase(sb, division);
                                sb.Append(" Cent(s)");
                                break;
                            }
                    }
                    b_centaines = true;
                }
                else
                {
                    b_centaines = false;
                }

                //Test si il reste des ÈlÈments apres les centaines
                if (reste > 0)
                {
                    //Introduction d'un espace si on a intÈgrÈ des centaines
                    if (b_centaines) sb.Append(' ');
                    //Calcul des dixaines et de leurs reste
                    value = reste;
                    division = Math.DivRem(value, 10, out reste);

                    switch (division)
                    {
                        case 0:
                        case 1:
                        case 7:
                        case 9:
                            {
                                Int2LettresBase(sb, value);
                                break;
                            }
                        default:
                            {
                                Int2LettresBase(sb, division * 10);
                                if (reste > 0)
                                {
                                    if (reste == 1)
                                        sb.Append(" et Un");
                                    else
                                    {
                                        sb.Append('-');
                                        Int2LettresBase(sb, reste);
                                    }
                                }

                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void Int2LettresBase(StringBuilder sb, Int64 value)
        {
            switch (value)
            {
                case 0: { sb.Append("ZÈro"); break; }
                case 1: { sb.Append("Un"); break; }
                case 2: { sb.Append("Deux"); break; }
                case 3: { sb.Append("Trois"); break; }
                case 4: { sb.Append("Quatre"); break; }
                case 5: { sb.Append("Cinq"); break; }
                case 6: { sb.Append("Six"); break; }
                case 7: { sb.Append("Sept"); break; }
                case 8: { sb.Append("Huit"); break; }
                case 9: { sb.Append("Neuf"); break; }
                case 10: { sb.Append("Dix"); break; }
                case 11: { sb.Append("Onze"); break; }
                case 12: { sb.Append("Douze"); break; }
                case 13: { sb.Append("Treize"); break; }
                case 14: { sb.Append("Quatorze"); break; }
                case 15: { sb.Append("Quinze"); break; }
                case 16: { sb.Append("Seize"); break; }
                case 17: { sb.Append("Dix-Sept"); break; }
                case 18: { sb.Append("Dix-Huit"); break; }
                case 19: { sb.Append("Dix-Neuf"); break; }
                case 20: { sb.Append("Vingt"); break; }
                case 30: { sb.Append("Trente"); break; }
                case 40: { sb.Append("Quarante"); break; }
                case 50: { sb.Append("Cinquante"); break; }
                case 60: { sb.Append("Soixante"); break; }
                case 70: { sb.Append("Soixante-Dix"); break; }
                case 71: { sb.Append("Soixante et Onze"); break; }
                case 72: { sb.Append("Soixante-Douze"); break; }
                case 73: { sb.Append("Soixante-Treize"); break; }
                case 74: { sb.Append("Soixante-Quatorze"); break; }
                case 75: { sb.Append("Soixante-Quinze"); break; }
                case 76: { sb.Append("Soixante-Seize"); break; }
                case 77: { sb.Append("Soixante-Dix-Sept"); break; }
                case 78: { sb.Append("Soixante-Dix-Huit"); break; }
                case 79: { sb.Append("Soixante-Dix-Neuf"); break; }
                case 80: { sb.Append("Quatre-Vingt"); break; }
                case 90: { sb.Append("Quatre-Vingt-Dix"); break; }
                case 91: { sb.Append("Quatre-Vingt-Onze"); break; }
                case 92: { sb.Append("Quatre-Vingt-Douze"); break; }
                case 93: { sb.Append("Quatre-Vingt-Treize"); break; }
                case 94: { sb.Append("Quatre-Vingt-Quatorze"); break; }
                case 95: { sb.Append("Quatre-Vingt-Quinze"); break; }
                case 96: { sb.Append("Quatre-Vingt-Seize"); break; }
                case 97: { sb.Append("Quatre-Vingt-Dix-Sept"); break; }
                case 98: { sb.Append("Quatre-Vingt-Dix-Huit"); break; }
                case 99: { sb.Append("Quatre-Vingt-Dix-Neuf"); break; }
                case 100: { sb.Append("Cent"); break; }
                default: { /*RAS*/ break; }
            }
        }




          public void  CurrencyInfo()
        {
                    CurrencyID = 3;
                    CurrencyCode = "DZD";
                    IsCurrencyNameFeminine = false;
                    Arabic1CurrencyName = "œÌ‰«— Ã“«∆—Ì";
                    Arabic2CurrencyName = "œÌ‰«—«‰ Ã“«∆—Ì«‰";
                    Arabic310CurrencyName = "œ‰«‰Ì— Ã“«∆—Ì…";
                    Arabic1199CurrencyName = "œÌ‰«— Ã“«∆—Ì";
                    Arabic1CurrencyPartName = "”‰ Ì„";
                    Arabic2CurrencyPartName = "”‰ Ì„«‰";
                    Arabic310CurrencyPartName = "”‰ Ì„";
                    Arabic1199CurrencyPartName = "”‰ Ì„";
                    PartPrecision = 3;
                    IsCurrencyPartNameFeminine = false;
                          }
        public Int64 CurrencyID { get; set; }
        /// <summary>
        /// Standard Code
        /// Syrian Pound: SYP
        /// UAE Dirham: AED
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// Is the currency name feminine ( Mua'anath „ƒ‰À)
        /// ·Ì—… ”Ê—Ì… : „ƒ‰À = true
        /// œ—Â„ : „–ﬂ— = false
        /// </summary>
        /// 
       public Boolean IsCurrencyNameFeminine { get; set; }
        /// <summary>
        /// English Currency Name for single use
        /// Syrian Pound
        /// UAE Dirham
        /// </summary>
           public string Arabic1CurrencyName { get; set; }
        /// <summary>
        /// Arabic Currency Name for 2 units only
        /// ·Ì— «‰ ”Ê—Ì «‰
        /// œ—Â„«‰ ≈„«—« Ì«‰
        /// </summary>
        public string Arabic2CurrencyName { get; set; }
        /// <summary>
        /// Arabic Currency Name for 3 to 10 units
        /// Œ„” ·Ì—«  ”Ê—Ì…
        /// Œ„”… œ—«Â„ ≈„«—« Ì…
        /// </summary>
        public string Arabic310CurrencyName { get; set; }
        /// <summary>
        /// Arabic Currency Name for 11 to 99 units
        /// Œ„” Ê ”»⁄Ê‰ ·Ì—… ”Ê—Ì…
        /// Œ„”… Ê ”»⁄Ê‰ œ—Â„« ≈„«—« Ì«
        /// </summary>
        public string Arabic1199CurrencyName { get; set; }
        /// <summary>
        /// Decimal Part Precision
        /// for Syrian Pounds: 2 ( 1 SP = 100 parts)
        /// for Tunisian Dinars: 3 ( 1 TND = 1000 parts)
        /// </summary>
        public Byte PartPrecision { get; set; }
        /// <summary>
        /// Is the currency part name feminine ( Mua'anath „ƒ‰À)
        /// Â··… : „ƒ‰À = true
        /// ﬁ—‘ : „–ﬂ— = false
        /// </summary>
        public Boolean IsCurrencyPartNameFeminine { get; set; }
        /// <summary>
        /// English Currency Part Name for single use
        /// Piaster
        /// Fils
        /// </summary>
           public string Arabic1CurrencyPartName { get; set; }
        /// <summary>
        /// Arabic Currency Part Name for 2 unit only
        /// ﬁ—‘«‰
        /// Â·· «‰
        /// </summary>
        public string Arabic2CurrencyPartName { get; set; }
        /// <summary>
        /// Arabic Currency Part Name for 3 to 10 units
        /// ﬁ—Ê‘
        /// Â··« 
        /// </summary>
        public string Arabic310CurrencyPartName { get; set; }
        /// <summary>
        /// Arabic Currency Part Name for 11 to 99 units
        /// ﬁ—‘«
        /// Â··…
        /// </summary>
        public string Arabic1199CurrencyPartName { get; set; }
        private long _intergerValue = 0;
        private Int64 _decimalValue = 0;
        private static string[] arabicOnes =
      new string[] {
            String.Empty, "Ê«Õœ", "«À‰«‰", "À·«À…", "√—»⁄…", "Œ„”…", "” …", "”»⁄…", "À„«‰Ì…", " ”⁄…",
            "⁄‘—…", "√Õœ ⁄‘—", "«À‰« ⁄‘—", "À·«À… ⁄‘—", "√—»⁄… ⁄‘—", "Œ„”… ⁄‘—", "” … ⁄‘—", "”»⁄… ⁄‘—", "À„«‰Ì… ⁄‘—", " ”⁄… ⁄‘—"
        };

        private static string[] arabicFeminineOnes =
           new string[] {
            String.Empty, "≈ÕœÏ", "«À‰ «‰", "À·«À", "√—»⁄", "Œ„”", "” ", "”»⁄", "À„«‰", " ”⁄",
            "⁄‘—", "≈ÕœÏ ⁄‘—…", "«À‰ « ⁄‘—…", "À·«À ⁄‘—…", "√—»⁄ ⁄‘—…", "Œ„” ⁄‘—…", "”  ⁄‘—…", "”»⁄ ⁄‘—…", "À„«‰Ì ⁄‘—…", " ”⁄ ⁄‘—…"
        };

        private static string[] arabicTens =
            new string[] {
            "⁄‘—Ê‰", "À·«ÀÊ‰", "√—»⁄Ê‰", "Œ„”Ê‰", "” Ê‰", "”»⁄Ê‰", "À„«‰Ê‰", " ”⁄Ê‰"
        };

        private static string[] arabicHundreds =
            new string[] {
            "", "„«∆…", "„∆ «‰", "À·«À„«∆…", "√—»⁄„«∆…", "Œ„”„«∆…", "” „«∆…", "”»⁄„«∆…", "À„«‰„«∆…"," ”⁄„«∆…"
        };

        private static string[] arabicAppendedTwos =
            new string[] {
            "„∆ «", "√·›«", "„·ÌÊ‰«", "„·Ì«—«", " —Ì·ÌÊ‰«", "ﬂÊ«œ—Ì·ÌÊ‰«", "ﬂÊÌ‰ ·ÌÊ‰«", "”ﬂ” Ì·ÌÊ‰«"
        };

        private static string[] arabicTwos =
            new string[] {
            "„∆ «‰", "√·›«‰", "„·ÌÊ‰«‰", "„·Ì«—«‰", " —Ì·ÌÊ‰«‰", "ﬂÊ«œ—Ì·ÌÊ‰«‰", "ﬂÊÌ‰ ·ÌÊ‰«‰", "”ﬂ” Ì·ÌÊ‰«‰"
        };

        private static string[] arabicGroup =
            new string[] {
            "„«∆…", "√·›", "„·ÌÊ‰", "„·Ì«—", " —Ì·ÌÊ‰", "ﬂÊ«œ—Ì·ÌÊ‰", "ﬂÊÌ‰ ·ÌÊ‰", "”ﬂ” Ì·ÌÊ‰"
        };

        private static string[] arabicAppendedGroup =
            new string[] {
            "", "√·›«", "„·ÌÊ‰«", "„·Ì«—«", " —Ì·ÌÊ‰«", "ﬂÊ«œ—Ì·ÌÊ‰«", "ﬂÊÌ‰ ·ÌÊ‰«", "”ﬂ” Ì·ÌÊ‰«"
        };

        private static string[] arabicPluralGroups =
            new string[] {
            "", "¬·«›", "„·«ÌÌ‰", "„·Ì«—« ", " —Ì·ÌÊ‰« ", "ﬂÊ«œ—Ì·ÌÊ‰« ", "ﬂÊÌ‰ ·ÌÊ‰« ", "”ﬂ” Ì·ÌÊ‰« "
        };
        public Decimal Number { get; set; }
   //     public CurrencyInfo Currency { get; set; }
        public String EnglishPrefixText { get; set; }
        public String EnglishSuffixText { get; set; }
        public String ArabicPrefixText { get; set; }
        public String ArabicSuffixText { get; set; }

        private string GetDigitFeminineStatus(Int64 digit, Int64 groupLevel)
        {
            if (groupLevel == -1)
            { // if it is in the decimal part
                if (IsCurrencyPartNameFeminine)
                    return arabicFeminineOnes[digit]; // use feminine field
                else
                    return arabicOnes[digit];
            }
            else
                if (groupLevel == 0)
                {
                    if (IsCurrencyNameFeminine)
                        return arabicFeminineOnes[digit];// use feminine field
                    else
                        return arabicOnes[digit];
                }
                else
                    return arabicOnes[digit];
        }
        /*****************************/
        private string ProcessArabicGroup(Int64 groupNumber, Int64 groupLevel, Int64 remainingNumber)
        {
            Int64 tens = groupNumber % 100;

            Int64 hundreds = groupNumber / 100;

            string retVal = String.Empty;

            if (hundreds > 0)
            {
                if (tens == 0 && hundreds == 2) // Õ«·… «·„÷«›
                    retVal = String.Format("{0}", arabicAppendedTwos[0]);
                else //  «·Õ«·… «·⁄«œÌ…
                    retVal = String.Format("{0}", arabicHundreds[hundreds]);
            }

            if (tens > 0)
            {
                if (tens < 20)
                { // if we are processing under 20 numbers
                    if (tens == 2 && hundreds == 0 && groupLevel > 0)
                    { // This is special case for number 2 when it comes alone in the group
                        if (_intergerValue == 2000 || _intergerValue == 2000000 || _intergerValue == 2000000000 || _intergerValue == 2000000000000 || _intergerValue == 2000000000000000 || _intergerValue == 2000000000000000000)
                            retVal = String.Format("{0}", arabicAppendedTwos[groupLevel]); // ›Ì Õ«·… «·«÷«›…
                        else
                            retVal = String.Format("{0}", arabicTwos[groupLevel]);//  ›Ì Õ«·… «·«›—«œ
                    }
                    else
                    { // General case
                        if (retVal != String.Empty)
                            retVal += " Ê ";

                        if (tens == 1 && groupLevel > 0 && hundreds == 0)
                            retVal += " ";
                        else
                            if ((tens == 1 || tens == 2) && (groupLevel == 0 || groupLevel == -1) && hundreds == 0 && remainingNumber == 0)
                                retVal += String.Empty; // Special case for 1 and 2 numbers like: ·Ì—… ”Ê—Ì… Ê ·Ì— «‰ ”Ê—Ì «‰
                            else
                                retVal += GetDigitFeminineStatus(tens, groupLevel);// Get Feminine status for this digit
                    }
                }
                else
                {
                    Int64 ones = tens % 10;
                    tens = (tens / 10) - 2; // 20's offset

                    if (ones > 0)
                    {
                        if (retVal != String.Empty)
                            retVal += " Ê ";

                        // Get Feminine status for this digit
                        retVal += GetDigitFeminineStatus(ones, groupLevel);
                    }

                    if (retVal != String.Empty)
                        retVal += " Ê ";

                    // Get Tens text
                    retVal += arabicTens[tens];
                }
            }

            return retVal;
        }
        /**************************************/
        public string ConvertToArabic(Int64 Number)
        {
          //  Currency = new CurrencyInfo();
            Int64 tempNumber = Number;

            if (tempNumber == 0)
                return "";

            // Get Text for the decimal part
            string decimalString = ProcessArabicGroup(_decimalValue, -1, 0);

            string retVal = String.Empty;
            Byte group = 0;
            while (tempNumber >= 1)
            {
                // seperate number into groups
                Int64 numberToProcess = (Int64)(tempNumber % 1000);

                tempNumber = tempNumber / 1000;

                // convert group into its text
                string groupDescription = ProcessArabicGroup(numberToProcess, group, tempNumber);

                if (groupDescription != String.Empty)
                { // here we add the new converted group to the previous concatenated text
                    if (group > 0)
                    {
                        if (retVal != String.Empty)
                            retVal = String.Format("{0} {1}", "Ê", retVal);

                        if (numberToProcess != 2)
                        {
                            if (numberToProcess % 100 != 1)
                            {
                                if (numberToProcess >= 3 && numberToProcess <= 10) // for numbers between 3 and 9 we use plural name
                                    retVal = String.Format("{0} {1}", arabicPluralGroups[group], retVal);
                                else
                                {
                                    if (retVal != String.Empty) // use appending case
                                        retVal = String.Format("{0} {1}", arabicAppendedGroup[group], retVal);
                                    else
                                        retVal = String.Format("{0} {1}", arabicGroup[group], retVal); // use normal case
                                }
                            }
                            else
                            {
                                retVal = String.Format("{0} {1}", arabicGroup[group], retVal); // use normal case
                            }
                        }
                    }

                    retVal = String.Format("{0} {1}", groupDescription, retVal);
                }

                group++;
            }

            String formattedNumber = String.Empty;
            formattedNumber += (ArabicPrefixText != String.Empty) ? String.Format("{0} ", ArabicPrefixText) : String.Empty;
            formattedNumber += (retVal != String.Empty) ? retVal : String.Empty;
            if (_intergerValue != 0)
            { // here we add currency name depending on _intergerValue : 1 ,2 , 3--->10 , 11--->99
                Int64 remaining100 = (Int64)(_intergerValue % 100);

                if (remaining100 == 0)
                    formattedNumber += Arabic1CurrencyName;
                else
                    if (remaining100 == 1)
                        formattedNumber += Arabic1CurrencyName;
                    else
                        if (remaining100 == 2)
                        {
                            if (_intergerValue == 2)
                                formattedNumber += Arabic2CurrencyName;
                            else
                                formattedNumber += Arabic1CurrencyName;
                        }
                        else
                            if (remaining100 >= 3 && remaining100 <= 10)
                                formattedNumber += Arabic310CurrencyName;
                            else
                                if (remaining100 >= 11 && remaining100 <= 99)
                                    formattedNumber += Arabic1199CurrencyName;
            }
            formattedNumber += (_decimalValue != 0) ? " Ê " : String.Empty;
            formattedNumber += (_decimalValue != 0) ? decimalString : String.Empty;
            if (_decimalValue != 0)
            { // here we add currency part name depending on _intergerValue : 1 ,2 , 3--->10 , 11--->99
                formattedNumber += " ";

                Int64 remaining100 = (Int64)(_decimalValue % 100);

                if (remaining100 == 0)
                    formattedNumber += Arabic1CurrencyPartName;
                else
                    if (remaining100 == 1)
                        formattedNumber += Arabic1CurrencyPartName;
                    else
                        if (remaining100 == 2)
                            formattedNumber += Arabic2CurrencyPartName;
                        else
                            if (remaining100 >= 3 && remaining100 <= 10)
                                formattedNumber += Arabic310CurrencyPartName;
                            else
                                if (remaining100 >= 11 && remaining100 <= 99)
                                    formattedNumber += Arabic1199CurrencyPartName;
            }
            formattedNumber += (ArabicSuffixText != String.Empty) ? String.Format(" {0}", ArabicSuffixText) : String.Empty;

            return formattedNumber;
        }
        ///************************************************/ 
        public string convert_Ar(decimal Somme_Montants)
        {
            //string affiche = null;
            Int64 entiÈre = (Int64)Somme_Montants;
            Int64 frac = (Int64)((Somme_Montants - entiÈre) * 100);
            if (frac != 0)
                return ConvertToArabic(entiÈre) + " œÌ‰«— Ã“«∆—Ì Ê" + ConvertToArabic(frac) + " ”‰ Ì„";
            else
                return  ConvertToArabic(entiÈre) + " œÌ‰«— Ã“«∆—Ì";

        }
        /************************************************/
        public string convert_FR(decimal Somme_Montants)
        {
            Int64 entiÈre = (Int64)Somme_Montants;
            Int64 frac = (Int64)((Somme_Montants - entiÈre) * 100);
            if (frac != 0)
               return Int2Lettres(entiÈre) + " Dinar(s) AlgÈrien(s) et " + Int2Lettres(frac) + " Centim(s)";
            else
              return Int2Lettres(entiÈre) + " Dinar(s) AlgÈrien(s)";

        }




     
    }
}


