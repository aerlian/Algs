using System;
using System.Collections.Generic;
using System.Text;

namespace CakeMergeCalendar
{
    public class LinkedListReversal
    {
        public static void LinkedListReversalMain()
        {
            var reversed = Reverse(ListBuilder.Create(new[] {1, 2, 3, 4, 5 }));
            ListBuilder.Dump(reversed);
        }

        private static Node Reverse(Node node)
        {
            var current = node;
            Node prev = null;
            Node temp;
            //Node next;

            while(current != null)
            {
                temp = current.Next;
                current.Next = prev;
                //temp.Next = current;
                prev = current;
                current = temp;
            }

            return prev;
        }
    }
}
