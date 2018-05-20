using System;
namespace CakeMergeCalendar
{
    public class BigInteger
    {
        public static void BigIntegerMain()
        {
            var first = new[] { 6, 3, 4 };
            var second = new[] { 6, 7, 8 };

            int[] result = Add(first, second);
        }

        private static int[] CopyTo(int[] source, int max)
        {
            var temp = new int[max];
            var diff = max - 1 - (source.Length - 1);

            for (var i = 0; i <= max - 1; i++)
            {
                if (!(i < (max - 1) - (source.Length - 1) - i))                
                {
                    temp[i] = source[i - diff];
                }
            }

            return temp;
        }

        //private static int [] CopyTo(int [] source, int max)
        //{
        //    var temp = new int[max];
        //    var diff = max - 1 - source.Length - 1;
            
        //    for (var i = max - 1; i >= 0; i--)
        //    {
        //        if (i + diff < 0)
        //        {
        //            temp[i] = 0;
        //        }
        //        else
        //        {
        //            temp[i] = source[i + diff];
        //        }
        //    }

        //    return temp;
        //}


        private static int[] Add(int[] first, int[] second)
        {
            var max = Math.Max(first.Length, second.Length);

            if (first.Length != max)
            {
                first = CopyTo(first, max);
            }

            if (second.Length != max)
            {
                second = CopyTo(second, max);
            }

            var x = max - 1;
            var carry = 0;

            var output = new int[max];

            while (x >= 0)
            {
                var val1 = first[x];
                var val2 = second[x];

                var val3 = val1 + val2 + carry;

                output[x] = val3 % 10;
                carry = val3 / 10;

                --x;
            }

            if (carry > 0)
            {
                output = CopyTo(output, output.Length + 1);
                output[0] = carry;
            }

            return output;
        }
    }
}
