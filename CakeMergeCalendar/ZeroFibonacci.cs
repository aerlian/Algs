using System.Linq;
using System;

namespace CakeMergeCalendar
{
    public class ZeroFibonacci
    {
        public static void ZeroFibonacciMain()
        {
            var rng = Enumerable.Range(0, 5);

            foreach (var item in rng)
            {
                Console.WriteLine($"{Fib(item)}");
            }
        }

        private static int Fib(int nth)
        {
            if (nth < 2)
            {
                return nth;
            }

            return Fib(nth - 1) + Fib(nth - 2);
        }
    }
}
