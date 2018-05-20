using System;
namespace CakeMergeCalendar
{
    public class ArrayNumberAdder
    {
        public static void ArrayNumberAdderMain()
        {
            var res = AddOne(new int[] { 1, 2, 3 });

        }

        public static int [] AddOne(int [] input)
        {
            var number = GetNumber(input);
            number += 1;

            return WriteNumber(number);
        }

        public static int GetNumber(int [] input)
        {
            var multiplier = 1;

            var number = 0;

            for (var i = input.Length - 1; i >= 0; i--)
            {
                number += (input[i] * multiplier);

                multiplier *= 10;
            }

            return number;
        }

        public static int [] WriteNumber(int input)
        {
            var multiplier = 1;
            var number = 0;

            var arraySize = GetArraySize(input);
            var output = new int[arraySize];

            for (var i = output.Length - 1; i >= 0; i--)
            {
                var digit = input % 10;
                
                if (digit == 0)
                {
                    return output;
                }

                output[i] = digit;
                input /= 10;
            }

            return output;
        }

        public static int GetArraySize(int number)
        {
            var size = 1;
            while (true)
            {
                if (number == 1)
                {
                    break;
                }

                number = number / 10;
                size += 1;
            }

            return size;
        }
    }
}
