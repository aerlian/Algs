using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CakeMergeCalendar
{
    public class Coins
    {
        public class IntArrayEqualityComparer : IEqualityComparer<int[]>
        {
            public bool Equals(int[] x, int[] y)
            {
                return x.SequenceEqual(y);
            }

            public int GetHashCode(int[] obj)
            {
                return obj.Aggregate((a, v) => a ^ v * 171);
            }
        }

        public static void CoinsMain()
        {
            var results = new List<int>();
            var coins = CoinsImpl(new int[] { 1, 2, 3 }, 4);

            var distinct = coins.Select(l => l.OrderBy(j => j).ToArray()).Distinct(new IntArrayEqualityComparer());

            foreach (var item in distinct)
            {
                Console.WriteLine(string.Join(",", item));
            }
        }

        private static List<int[]> CoinsImpl(int[] coins, int amount)
        {
            var lst = new List<int[]>();

            if (amount <= 0)
            {
                return lst;
            }

            if (coins.Length == 0)
            {
                return lst;
            }

            if (coins.Length == 1 && coins[0] == amount)
            {
                lst.Add(coins);
                return lst;
            }

            for (var i = 0; i < coins.Length; i++)
            {
                int currentCoin = coins[i];

                if (amount % currentCoin == 0)
                {
                    lst.Add(Enumerable.Repeat(currentCoin, amount / currentCoin).ToArray());
                }

                var subList = CoinsImpl(coins.Except(new[] { currentCoin }).ToArray(), amount - currentCoin);
                foreach (var s in subList.Where(j => j.Length > 0))
                {
                    if (s.Sum() + currentCoin > amount)
                    {
                        continue;
                    }

                    lst.Add(s.Concat(new[] { currentCoin }).ToArray());
                }
            }
            return lst;
        }
    }
}
