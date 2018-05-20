using System;

namespace CakeMergeCalendar
{
    public static class KnapSack
    {
        public struct KnapEntry
        {
            public int Weight;
            public int Value;

            public KnapEntry(int weight, int value)
            {
                Weight = weight;
                Value = value;
            }
        }

        public static void KnapSackMain()
        {
            //var options = new KnapEntry[] {
            //    new KnapEntry(0, 0),
            //    new KnapEntry(1, 2),
            //    new KnapEntry(3, 2), 
            //    new KnapEntry(4, 3), 
            //    new KnapEntry(5, 4)
            //};

            var options = new KnapEntry[] {
                new KnapEntry(0, 0),
                new KnapEntry(10, 60),
                new KnapEntry(20, 100),
                new KnapEntry(30, 120),
            };

            var value = HighestValue(options, options.Length - 1, 50);
            Console.WriteLine($"Highest value:{value}");
        }

        private static int HighestValue(KnapEntry [] options, int n, int capacity)
        {
            if (n == 0 || capacity == 0)
            {
                return 0;
            }

            int result;

            if (options[n].Weight > capacity)
            {
                return HighestValue(options, n - 1, capacity);
            }
            else
            {
                var tmp = HighestValue(options, n - 1, capacity);
                var tmp2 = options[n].Value + HighestValue(options, n - 1, capacity - options[n].Weight);

                result = Math.Max(tmp, tmp2);
            }

            return result;
        }
    }
}
