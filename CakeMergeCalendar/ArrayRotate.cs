using System;
using System.Collections.Generic;
using System.Text;

namespace CakeMergeCalendar
{
    //6, 7, 8, 9
    //9, 7, 8, 6
    //9, 8, 7, 6

    //1, 2, 3, 4, 5
    //5, 2, 3, 4, 1
    //5, 4, 3, 2, 1

    //5, 4, 3, 2, 1, 9, 8, 7, 6
    //6, 4, 3, 2, 1, 9, 8, 7, 5
    //6, 7, 3, 2, 1, 9, 8, 4, 5
    //6, 7, 8, 2, 1, 9, 3, 4, 5
    //6, 7, 8, 9, 1, 2, 3, 4, 5

    class ArrayRotate
    {
        // 6, 7, 8, 9, 1, 2, 3, 4, 5
        public static void ArrayRotateMain()
        {
            int[] src = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Rotate(src, 5);
        }

        private static void Rotate(int [] source, int rotate)
        {
            RotateImpl(source, 0, rotate - 1);
            RotateImpl(source, rotate, source.Length - 1);
            RotateImpl(source, 0, source.Length - 1);
        }

        private static void RotateImpl(int [] source, int start, int end)
        {
            var a = start;
            var x = end;

            while(a < x)
            {
                Swap(source, a, x);
                a += 1;
                x -= 1;
            }
        }

        private static void Swap(int [] source, int start, int end)
        {
            var tmp = source[start];
            source[start] = source[end];
            source[end] = tmp;
        }
    }
}
