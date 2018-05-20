using System;
using System.Collections.Generic;
using System.Text;

namespace CakeMergeCalendar
{
    public class SelectionSort
    {
        public static void SelectionSortMain()
        {
            var source = new[] { 6, 2, 8, 3, 4, 7, 1 };
            //6, 2, 8, 3, 4, 7, 1 
            //2, 6, 8, 3, 4, 7, 1
            //2, 6, 8, 3, 4, 7, 1
            //2, 6, 3, 8, 4, 7, 1
            //2, 6, 3, 8, 4, 7, 1

            int minIndex;

            for (var i = 0; i < source.Length; i++)
            {
                minIndex = i;

                for(var j = i + 1; j < source.Length; j++)
                {
                    if (source[j] < source[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    Swap(source, i, minIndex);
                }
            }
            

        }

        private static void Swap(int [] source, int firstIndex, int secondIndex)
        {
            var tmp = source[firstIndex];
            source[firstIndex] = source[secondIndex];
            source[secondIndex] = tmp;
        }














        //private static int FindNext2(int [] source, int currentValue)
        //{
        //    var offset = 0;

        //    while(offset < source.Length)
        //    {
        //        if (source[offset] < currentValue)
        //        {
        //            return offset;
        //        }

        //        offset += 1;
        //    }

        //    return -1;
        //}

        //private static void MoveDown(int[] source, int current, int offset)
        //{
        //    while(offset != current)
        //    {
        //        source[offset] = source[offset - 1];

        //        offset -= 1;
        //    }
        //}

        //private static int FindNext(int[] source, int current)
        //{
        //    var offset = current + 1;
        //    while(offset < source.Length - 1)
        //    {
        //        if (source[offset] < source[current])
        //        {
        //            return offset;
        //        }

        //        offset += 1;
        //    }

        //    return -1;
        //}
    }
}
