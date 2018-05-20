using System;
using System.Collections.Generic;
using System.Text;

namespace CakeMergeCalendar
{
    public static class ReverseWords
    {
        public static void ReverseWordsMain()
        {
            var result = Reverse("I decided to eat vanilla chocolate".ToCharArray());
            Console.WriteLine(result);
        }

        public static string Reverse(char [] source)
        {
            for(var i = 0; i < source.Length / 2; i++)
            {
                Swap(source, i, source.Length - 1 - i);
            }

            var startOfWord = 0;

            for(var j = 0; j < source.Length - 1; j++)
            {
                if (source[j] == ' ' || j == source.Length - 1)
                {
                    ReverseArr(source, startOfWord, j - 1);
                    startOfWord = j + 1;
                }
            }

            return new string(source);
        }

        private static void ReverseArr(char[] source, int start, int end)
        {
            var arr = source;

            var x = start;
            var y = end;

            while(x < y)
            {
                Swap(arr, x, y);
                x += 1;
                y -= 1;
            }
        }

        private static void Swap(char[] source, int start, int end)
        {
            var temp = source[start];
            source[start] = source[end];
            source[end] = temp;
        }
    }
}
