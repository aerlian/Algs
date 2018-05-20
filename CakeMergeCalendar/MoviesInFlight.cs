using System;
using System.Collections.Generic;
using System.Text;

namespace CakeMergeCalendar
{
    public class MoviesInFlight
    {
        public static void MoviesInFlightMain()
        {
            Console.WriteLine(Compute(8, new int[] {1, 3, 5, 7, 9, 10 }));
        }

        private static bool Compute(int flightLength, int [] movieLengths)
        {
            var start = 0;
            var end = movieLengths.Length - 1;

            while(start < end)
            {
                var movieA = movieLengths[start];
                var movieB = movieLengths[end];

                var movieLength = movieA + movieB;

                if (movieLength == flightLength)
                {
                    return true;
                }

                if (movieLength > flightLength)
                {
                    end -= 1;
                }
                else
                {
                    start += 1;
                }
            }

            return false;
        }
    }
}
