using System;
using System.Collections.Generic;
using System.Text;

namespace CakeMergeCalendar
{
    public static class PairWithSum
    {
        public static void PairWithSumMain()
        {
            Console.WriteLine(HasPairWithSum2(new int[] {2, 3, 5, 7, 9 }, 10));

        }

        private static bool HasPairWithSum2(int[] v1, int sum)
        {
            var comp = new HashSet<int>();

            foreach (var i in v1)
            {
                if (comp.Contains(sum - i))
                {
                    return true;
                }
                comp.Add(i);
            }

            return false;
        }
        private static bool HasPairWithSum(int[] v1, int sum)
        {
            int indexStart = 0;
            int indexEnd = v1.Length - 1;

            while(indexStart < v1.Length && indexStart != indexEnd && indexEnd >= 0)
            {
                if (v1[indexStart] + v1[indexEnd] == sum)
                {
                    return true;
                }

                if ((v1[indexStart] + v1[indexEnd]) < sum)
                {
                    indexStart += 1;
                }
                else
                {
                    indexEnd -= 1;
                }
            }

            return false;
        }
    }
}
