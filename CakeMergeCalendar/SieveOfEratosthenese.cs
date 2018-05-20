using System;
using System.Linq;

namespace CakeMergeCalendar
{
    class SieveOfEratosthenese
    {
        class NumberMark
        {
            public int Number;
            public bool IsMarked;
        }
        public static void SieveMain()
        {
            var slots = Enumerable.Range(2, 1000*10_000).Select(i => new NumberMark { Number = i }).ToArray();
            var p = 2;

            while (true)
            {
                MarkSlots(slots, p);

                p = FindNextEmptySlot(slots, p);

                if (p == -1)
                {
                    break;
                }                
            }

            DumpPrimes(slots);
        }

        private static void DumpPrimes(NumberMark [] primes)
        {
            var ps = primes.Where(j => !j.IsMarked).Select(k => k.Number).ToArray();
            var result = string.Join(",", ps);

            Console.WriteLine(result);
        }

        private static int NumberToSlot(int number)
        {
            return number - 2;
        }

        private static void MarkSlots(NumberMark[] candidates, int p)
        {
            var j = 2;
            var offset = 0;
            while (true)
            {
                offset = NumberToSlot(p * j);

                if (offset >= candidates.Length)
                {
                    break;
                }
                
                candidates[offset].IsMarked = true;
                j += 1;
            }
        }

        private static int FindNextEmptySlot(NumberMark[] slots, int p)
        {
            var offset = NumberToSlot(p) + 1;

            while (offset < slots.Length)
            {
                if (!slots[offset].IsMarked)
                {
                    return slots[offset].Number;
                }

                offset += 1;
            }

            return -1;
        }        
    }
}
