using System;
using System.Collections.Generic;
using System.Linq;

namespace CakeMergeCalendar
{
    public static class Powersets
    {
        public static void PowersetMain()
        {
            var powerset = CreatePowerset(new HashSet<char>(new char[] { 'a', 'b', 'c' }));
            DumpPowerset(powerset);
        }

        public static ISet<ISet<T>> CreatePowerset<T>(ISet<T> input)
        {
            if (input.Count == 0)
            {
                //base case - return set that contains the empty set
                return new HashSet<ISet<T>>() { new HashSet<T>() };
            }

            //compute n - 1 powerset 
            //we remove first item from input and make recursive call with remainder
            var firstElement = input.First();
            input.Remove(firstElement);
            var nMinus1Powerset = CreatePowerset(input);

            //compute additional sets for n element set
            var additionalSets = nMinus1Powerset.Select(set => new HashSet<T>(set) { firstElement });

            //combine n - 1 element set and additional sets for n element set
            return new HashSet<ISet<T>>(nMinus1Powerset.Union(additionalSets));
        }

        public static void DumpPowerset(ISet<ISet<char>> powerset)
        {
            Console.WriteLine(string.Join(",", powerset.Select(ToString)));
        }

        private static string ToString(ISet<char> set)
        {
            if (set.Count == 0)
            {
                return "{}";
            }

            return $"{{{string.Join(",", set)}}}";
        }
    }
}

