using System;

namespace CakeMergeCalendar
{
    public static class ReverseStringInPlace
    {
        public static void ReverseStringInPlaceMain()
        {
            var reversed = Reverse("hello, world");
            Console.WriteLine(reversed);
        }

        private static string Reverse(string source)
        {
            var arr = source.ToCharArray();

            for(var i = 0; i < arr.Length / 2; i++)
            {
                Swap(arr, i, arr.Length - 1 - i);
            }

            return new string(arr);
        }

        private static void Swap(char []source, int start, int end)
        {
            var temp = source[start];
            source[start] = source[end];
            source[end] = temp;
        }
    }
}
