using System;
using System.Collections.Generic;
using System.Linq;

namespace CakeMergeCalendar
{
    public class Coins_v2
    {
        public static void CoinsMain()
        {
            List<List<int>> coins = CoinsImpl(new int[] { 1, 2, 3 }, 4);
        }

        private static List<List<int>> CoinsImpl(int[] coins, int amount)
        {
            var coinLists = new List<List<int>>();

            if (amount <= 0)
            {
                return coinLists;
            }

            if (coins.Length == 0)
            {
                return coinLists;
            }

            if (coins.Length == 1)
            {
                if (coins[0] == amount)
                {
                    coinLists.Add(new List<int>() { coins[0] });
                }

                return coinLists;
            }
            
            for(var i = 0; i < coins.Length; i++)
            {
                var currentCoin = coins[i];
                //var denomRemainder = amount % currentCoin;
                //var denomQty = amount / currentCoin;
                
                //if (denomRemainder == 0)
                //{
                //    coinLists.Add(new List<int>(Enumerable.Repeat(currentCoin, denomQty)));
                //}

                //var combos = CoinsImpl(Except(coins, i), amount - currentCoin);
                
            
            //var currentCoinMultiple = 
                //while()
            }

            return null;
        }

        private static int [] Except(int [] coins, int index)
        {
            if (coins.Length == 0)
            {
                return coins;
            }

            var output = new int[coins.Length - 1];
            var outputIndex = 0;
            for (var i = 0; i < coins.Length; i++)
            {
                if (i == index)
                {
                    continue;
                }

                output[outputIndex] = coins[i];
                outputIndex += 1;
            }

            return output;
        }
    }
}
