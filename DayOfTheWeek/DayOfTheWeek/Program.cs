using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DayOfTheWeek
{
    class Program
    {
        static int[] t = { 0, 3, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4};
        
        static int dayofweek(int y, int m, int d)
        {
            y -= (m < 3) ? 1 : 0;   //create virtual year starting from March 1st and ending on Feb28th or 29th
                            //That is 2011 starts on Mar 1st and ends on Feb 29th
                            //2012 starts on Mar 1st and ends on Feb 28th

            return (y + y / 4 - y / 100 + y / 400 + t[m - 1] + d) % 7;
            // 365 % 7 = 1, that is 52 weeks + 1 day, therefore there is a shift of 1 day every year
            // y contributes this extra day per year

            // Every 4 yrs there is a leap year, that is an extra day
            //y/4 contributes leap year

            //Every 100 years is not a leap year
            //y/100 remove 100th years

            //Every 400 yrs is a leap yr again.
            //y/400 adds leap yr

            //d is the day from start of the month

            //t[] is the offset based on the month
        }

        static int DayOfWeek(int day, int month, int year) 
        {
            var a = (14 - month) / 12;
            var y = year - a;
            var m = month + 12 * a - 2;
            var d = ( day + y + y/4 - y/100 + y/400 + (31 * m)/12 )%7;
            return d;
        }
        
        static void Main(string[] args)
        {
            string[] dayName = { "Sunday", "Monday", "Tue", "Wed", "Thu", "Fri", "Sat"};
            int day = DayOfWeek(2013, 1, 22);
            Console.WriteLine(dayName[day]);
            Console.ReadLine();
        }
    }
}
