using System;

namespace CakeMergeCalendar
{
    public static class MergeNumbers
    {
        public static void MergeNumbersMain()
        {
            var first = new int[] { 1, 3, 5, 7, 9 };
            var second = new int[] { 2, 4, 6, 8, 10 };

            var merged = Merge(first, second, (a, b) => a > b ? -1 : 1);

            var result = string.Join(", ", merged);

            Console.WriteLine(result);
        }

        private static int [] Merge(int[] first, int[] second, Func<int, int, int> compare)
        {
            var firstIndex = 0;
            var secondIndex = 0;

            var merged = new int[first.Length + second.Length];
            var current = 0;

            while(firstIndex < first.Length && secondIndex < second.Length)
            {
                int number;
                if (compare(first[firstIndex], second[secondIndex]) <= 0)
                {
                    number = first[firstIndex++];
                }
                else
                {
                    number = second[secondIndex++];
                }

                merged[current++] = number;
            }

            var remaining = firstIndex < first.Length ? (first, firstIndex) : (second, secondIndex);

            var index = remaining.Item2;
            var source = remaining.Item1;
            while(index < remaining.Item1.Length)
            {
                merged[current++] = source[index++];
            }

            return merged;
        }
    }
}
