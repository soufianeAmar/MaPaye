using System;
using System.Collections.Generic; 
using System.Text;
using MaPaye.Module;

namespace MaPaye.Module
{

    public class AbsAutoEntree
    { 
        // 22 jrs
        public int DaysIgnoreWeekends(DateTime DateCourante, DateTime DateEntree, int jrsdbmois)
        {
            int count = 0;

            if (jrsdbmois > 1)
            {
                if (DateEntree.Month == DateCourante.Month)
                {
                    TimeSpan days = DateEntree.Subtract(DateCourante);
                    for (int a = 0; a < days.Days; a++)
                    {
                        if (DateCourante.DayOfWeek != DayOfWeek.Friday && DateCourante.DayOfWeek != DayOfWeek.Saturday)
                            count++;
                        DateCourante = DateCourante.AddDays(1.0);
                    }
                }
                else
                    if (DateEntree.Month== DateCourante.Month + 1 )
                        if (DateEntree.Day < jrsdbmois)
                        {
                            DateTime DateCourante2 = new DateTime(DateCourante.Year, DateCourante.Month + 1, jrsdbmois);

                            TimeSpan days = DateCourante2.Subtract(DateEntree);
                            for (int a = 0; a < days.Days; a++)
                            {
                                if (DateCourante.DayOfWeek != DayOfWeek.Friday && DateCourante.DayOfWeek != DayOfWeek.Saturday)
                                    count++;
                                DateCourante = DateCourante.AddDays(1.0);
                            }
                        }
            }
            else
            { 
                TimeSpan days = DateEntree.Subtract(DateCourante);
                for (int a = 0; a < days.Days; a++)
                {
                    if (DateCourante.DayOfWeek != DayOfWeek.Friday && DateCourante.DayOfWeek != DayOfWeek.Saturday)
                        count++;
                    DateCourante = DateCourante.AddDays(1.0);
                }
            }

            return count;
        }

        // 26 jrs
        public int DaysWith2Weekends(DateTime DateCourante, DateTime DateEntree, int jrsdbmois)
        {
            int count = 0;
            int i = 0;

            TimeSpan days = DateEntree.Subtract(DateCourante);
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
        public int DaysWithWeekends(DateTime DateCourante, DateTime DateEntree, int jrsdbmois)
        {
            int dayEntr = DateEntree.Day;
            int dayCour = DateCourante.Day;
            int count = dayEntr - dayCour;
             
            return count;
        }
    }
}
