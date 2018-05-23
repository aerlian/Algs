using System;
using System.Collections.Generic;
using System.Linq;

namespace CakeMergeCalendar
{
    public static class MostExpensiveRoute
    {
        public static void MostExpensiveRouteMain()
        {

            var highestCost = MostExpensive(new HashSet<int> {4, -1, 3, 6, 8, 2, 5, 1}, new Dictionary<string, int>());
            
            Console.WriteLine($"Highest price:{highestCost}");
        }

        //             4 
        //         1       -1
        //      5             3
        //         2        6
        //             8


        private static Dictionary<int, ISet<int>> _illegalNeighbors;

        static MostExpensiveRoute()
        {
            _illegalNeighbors = new Dictionary<int, ISet<int>>
            {
                { 4, new HashSet<int>{1, -1}}, 
                { -1, new HashSet<int>{4, 3}}, 
                { 3, new HashSet<int>{-1, 6}}, 
                { 6, new HashSet<int>{3, 8}}, 
                { 8, new HashSet<int>{6, 2}}, 
                { 2, new HashSet<int>{8, 5}}, 
                { 5, new HashSet<int>{2, 1}}, 
                { 1, new HashSet<int>{5, 4}}, 
            };
        }

        private static int MostExpensive(ISet<int> set, Dictionary<string, int> memo)
        {
            if (set.Count == 0)
            {
                return 0;
            }

            if (set.Count == 1)
            {
                return set.First();
            }

            var costs = new List<int>();

            foreach (var currentNumber in set)
            {
                var copySet = new HashSet<int>(set);
                copySet.Remove(currentNumber);

                var badNeighbors = _illegalNeighbors[currentNumber];
                var availableSet = new HashSet<int>(copySet.Except(badNeighbors));

                int cost;

                var memoKey = string.Join(",", availableSet);
                if (memo.ContainsKey(memoKey))
                {
                    cost = memo[memoKey];
                }
                else
                {
                    cost = MostExpensive(availableSet, memo);
                    memo.Add(memoKey, cost);
                }

                costs.Add(cost + currentNumber);
            }

            return costs.Max();
        }
    }
}
