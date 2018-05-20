using System;
using System.Collections.Generic;
using System.Numerics;

namespace CakeMergeCalendar
{
    public class Fibonacci
    {
        

        private static Dictionary<long, long> _previous = new Dictionary<long, long>();

        public static void FibonacciMain()
        {
            //IEnumerable<int> fib = CreateFib(10); 0,1,1,2,3,5,8,
            var fib = CreateFib(100);
            Console.WriteLine($"{fib:n0}");
        }

        private static long CreateFib(long i)
        {
            if (_previous.TryGetValue(i, out var fibValue))
            {
                return fibValue;
            }

            if (i <= 1)
            {
                return i;
            }
            

            var interim = CreateFib(i - 1) + CreateFib(i - 2);

            _previous.Add(i, interim);

            return interim;
        }

        //private static IEnumerable<int> CreateFib(int i)
        //{
        //    if (i == 1 || i == 0)
        //    {
        //        yield return i;
        //    }

        //    foreach (var item in CreateFib(i - 1))
        //    {
        //        yield i
        //    }
        //}
    }
}
