using System;
using System.Collections.Generic;
using System.Text;

namespace CakeMergeCalendar
{
    public static class InsertSortedList
    {
        public static void InsertSortedListMain()
        {
            var list = ListBuilder.Create(new[] { 2, 5, 7, 10, 15 });

            var inserted = InsertValue(list, 16);

            ListBuilder.Dump(inserted);
        }

        private static Node InsertValue(Node list, int v)
        {
            if (list == null)
            {
                return new Node { Value = v };
            }

            if (v < list.Value)
            {
                return new Node { Value = v, Next = list };
            }

            var current = list;

            while(current != null)
            {
                var next = current.Next;

                if (next == null)
                {
                    current.Next = new Node { Value = v };
                    break;
                }

                if (v > current.Value && v < next.Value)
                {
                    current.Next = new Node { Value = v, Next = next };
                    break;
                }

                current = current.Next;
            }

            return list;
        }
    }
}
