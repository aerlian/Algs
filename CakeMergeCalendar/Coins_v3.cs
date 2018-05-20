using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CakeMergeCalendar
{
    public static class Coins_v3
    {
        public static void Coins_v3Main()
        {
            var c = new Change();

            Console.WriteLine($"ways:{c.ChangePossibilitiesTopDown(10, new[] { 1, 2, 5 })}");
        }
    }

    class Change
    {
        /*
         *  1, 2, 5 -> 10
            (1 * 10)
            (1 * 8) + 2
            (1 * 6) + (2 + 2)
            (1 * 5) + 5
            (1 * 4) + (2 + 2 + 2)
            (1 * 3) + (5 + 2)
            (1 * 3) + 3 + (2 * 2)
            (1 * 2) + 2 + 2 + 2 + 2
            (2 * 2) + 5 + 1
            (2 * 5)
        */


        private Dictionary<string, int> _memo = new Dictionary<string, int>();

        public int ChangePossibilitiesTopDown(int amountLeft, int[] denominations, int currentIndex = 0)
        {
            // Check our memo and short-circuit if we've already solved this one
            string memoKey = $"{amountLeft}, {currentIndex}";
            if (_memo.ContainsKey(memoKey))
            {
                Console.WriteLine($"grabbing memo [{memoKey}]");
                return _memo[memoKey];
            }

            // Base cases:
            // We hit the amount spot on. Yes!
            if (amountLeft == 0)
            {
                return 1;
            }

            // We overshot the amount left (used too many coins)
            if (amountLeft < 0)
            {
                return 0;
            }

            // We're out of denominations
            if (currentIndex == denominations.Length)
            {
                return 0;
            }

            // Print out actual part of array
            Console.Write($"checking ways to make {amountLeft} with ");
            Console.WriteLine($"[{string.Join(", ", denominations.Skip(currentIndex).Take(denominations.Length - currentIndex))}]");

            // Choose a current coin
            int currentCoin = denominations[currentIndex];

            // See how many possibilities we can get
            // for each number of times to use currentCoin
            int numPossibilities = 0;
            while (amountLeft >= 0)
            {
                numPossibilities += ChangePossibilitiesTopDown(amountLeft, denominations, currentIndex + 1);
                amountLeft -= currentCoin;
            }

            // Save the answer in our memo, so we don't compute it again
            _memo.Add(memoKey, numPossibilities);
            return numPossibilities;
        }
    }
}
