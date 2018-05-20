using System;
using System.Collections.Generic;
using System.Text;

namespace CakeMergeCalendar
{
    class SquareRoot
    {
        public static void SquareRootMain()
        {
            Console.WriteLine(SqRoot(128));
        }

        private static double SqRoot(double v)
        {
            var depth = 1;
            var floor = 0d;
            var ceiling = v;

            double mid;

            while (true)
            {
                mid = (floor + ceiling) / 2; //floor + ((ceiling - floor) / 2);
                var midSq = mid * mid;
                
                if (Math.Abs(v - midSq) <= 10e-8)
                {
                    return mid;
                }

                if (midSq > v)
                {
                    ceiling = mid;
                }
                else
                {
                    floor = mid;
                }
                depth += 1;
            }
        }

        private static double SqRoot2(double n, double precision = 10e-8)
        {
            var depth = 1;
            double lo = 0.0d;
            double hi = Math.Max(n, 1.0d);

            double prev = 0.0d;
            double mid = (lo + hi) / 2.0d;

            while (Math.Abs(mid - prev) > precision)
            {
                prev = mid;
                mid = (mid + (n / mid)) / 2.0;
                depth += 1;
            }

            return mid;
        }

        
    }
}
