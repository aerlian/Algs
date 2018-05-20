using System;
namespace CakeMergeCalendar
{
    public class PowerOf
    {
        public static void PowerOfMain()
        {
            int result = Pow(5, 3);
        }

        private static int Pow(int num, int exp)
        {
            if (exp == 1)
            {
                return num;
            }

            var remainder = exp % 2;

            var extra = num * remainder;

            return (extra == 0 ? 1 : extra) * Pow(num, (exp - remainder) / 2) * Pow(num, (exp - remainder) / 2);
        }
    }
}
