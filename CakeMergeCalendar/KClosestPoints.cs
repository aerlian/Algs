using System;
using System.Linq;

namespace CakeMergeCalendar
{
    public static class KClosestPoints
    {
        public static void KClosestPointsMain()
        {
            var points = new(int, int)[] { (-2, 4), (0, -2), (-1, 0), (3, 5), (-2, -3), (3, 2) };

            var result = points.Select(p => (FindLength(p), p)).OrderBy(i => i.Item1).Select(j => j.Item2).Take(2);

            foreach (var p in result)
            {
                Console.WriteLine($"({p.Item1}, {p.Item2})");
            }
        }

        private static double FindLength((int a, int b) p)
        {
            double sq = Math.Pow(p.a, 2) + Math.Pow(p.b, 2);
            return Math.Sqrt(sq);
        }
    }
}
