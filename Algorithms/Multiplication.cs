using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public static class Multiplication
    {
        public static void MultiplicationMain()
        {
            var r = Product(
                new[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 8, 9, 7, 9, 3, 2, 3, 8, 4, 6, 2, 6, 4, 3, 3, 8, 3, 2, 7, 9, 5, 0, 2, 8, 8, 4, 1, 9, 7, 1, 6, 9, 3, 9, 9, 3, 7, 5, 1, 0, 5, 8, 2, 0, 9, 7, 4, 9, 4, 4, 5, 9, 2 },
                new[] { 2, 7, 1, 8, 2, 8, 1, 8, 2, 8, 4, 5, 9, 0, 4, 5, 2, 3, 5, 3, 6, 0, 2, 8, 7, 4, 7, 1, 3, 5, 2, 6, 6, 2, 4, 9, 7, 7, 5, 7, 2, 4, 7, 0, 9, 3, 6, 9, 9, 9, 5, 9, 5, 7, 4, 9, 6, 6, 9, 6, 7, 6, 2, 7 });

            Console.WriteLine(string.Join("", r).TrimStart('0'));
        }

        static int[] Product(int[] x, int[] y)
        {
            y = x.Length > y.Length ? Enumerable.Repeat(0, x.Length - y.Length).Concat(y).ToArray() : y;
            x = y.Length > x.Length ? Enumerable.Repeat(0, y.Length - x.Length).Concat(x).ToArray() : x;

            var allSums = new List<List<int>>();
            var tenMult = 0;

            for (var i = x.Length - 1; i >= 0; i--)
            {
                var sum = new List<int>(Enumerable.Repeat(0, tenMult));
                var c = 0;

                for (var j = y.Length - 1; j >= 0; j--)
                {
                    var total = x[j] * y[i] + c;
                    c = total / 10;
                    sum.Insert(0, total % 10);
                }

                if (c > 0)
                {
                    sum.Insert(0, c);
                }

                allSums.Add(sum.ToList());
                tenMult += 1;
            }

            return Sum(allSums).ToArray();
        }

        private static int[] Sum(List<List<int>> source)
        {
            return source.Aggregate((a, v) =>
            {
                var output = new List<int>();
                var vi = v.Count - 1;
                var ai = a.Count - 1;
                var c = 0;

                while (vi >= 0 || ai >= 0)
                {
                    var total = (ai >= 0 ? a[ai] : 0) + (vi >= 0 ? v[vi] : 0) + c;
                    c = total / 10;
                    output.Insert(0, total % 10);
                    ai -= 1;
                    vi -= 1;
                }

                if (c > 0)
                {
                    output.Insert(0, c);
                }

                return output;
            }).ToArray();
        }
    }
}
