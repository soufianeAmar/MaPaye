using System;
using System.Collections.Generic; 
using System.Text;
using MaPaye.Module;

namespace MaPaye.Module
{

    public class AbsAutoSortie
    { 
        // 22 jrs
        public int DaysIgnoreWeekends(DateTime DateSortie, DateTime DateCourante, int jrsdbmois)
        {
            int count = 0;

            if (jrsdbmois > 1)
            {
                if (DateCourante.Month == DateSortie.Month)
                {
                    TimeSpan days = DateCourante.Subtract(DateSortie);
                    for (int a = 0; a < days.Days; a++)
                    {
                        if (DateSortie.DayOfWeek != DayOfWeek.Friday && DateSortie.DayOfWeek != DayOfWeek.Saturday)
                            count++;
                        DateSortie = DateSortie.AddDays(1.0);
                    }
                }
                else
                    if (DateCourante.Month== DateSortie.Month + 1 )
                        if (DateCourante.Day < jrsdbmois)
                        {
                            DateTime DateCourante2 = new DateTime(DateSortie.Year, DateSortie.Month + 1, jrsdbmois);

                            TimeSpan days = DateCourante2.Subtract(DateCourante);
                            for (int a = 0; a < days.Days; a++)
                            {
                                if (DateSortie.DayOfWeek != DayOfWeek.Friday && DateSortie.DayOfWeek != DayOfWeek.Saturday)
                                    count++;
                                DateSortie = DateSortie.AddDays(1.0);
                            }
                        }
            }
            else
            { 
                TimeSpan days = DateCourante.Subtract(DateSortie);
                for (int a = 0; a < days.Days; a++)
                {
                    if (DateSortie.DayOfWeek != DayOfWeek.Friday && DateSortie.DayOfWeek != DayOfWeek.Saturday)
                        count++;
                    DateSortie = DateSortie.AddDays(1.0);
                }
            }

            return count;
        }

        // 26 jrs
        public int DaysWith2Weekends(DateTime DateSortie, DateTime DateCourante, int jrsdbmois)
        {
            int count = 0;
            int i = 0;

            TimeSpan days = DateCourante.Subtract(DateSortie);
            for (int a = 0; a < days.Days; a++)
            {
                if (DateCourante.DayOfWeek != DayOfWeek.Friday && DateCourante.DayOfWeek != DayOfWeek.Saturday)
                    count++;
                else
                    i++;

                DateCourante = DateCourante.AddDays(1.0);
            }

            if (4 <= i && i < 8)
                count += 2;
            else
                if (i >= 8)
                    count = +4;

            return count;
        }

        // 30 jrs
        public int DaysWithWeekends(DateTime DateSortie, DateTime DateCourante, int jrsdbmois)
        {
            int daysst = DateSortie.Day;
            int daysend = DateCourante.Day;
            int count = daysend - daysst;

            //if (count < 0)
            //    count = 0;

            return count;
        }
    }
}
