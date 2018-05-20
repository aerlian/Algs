using System;
using System.Collections.Generic;
using System.Text;

namespace CakeMergeCalendar
{
    public class ReverseList
    {
        public static void ReverseListMain()
        {
            var list = ListBuilder.Create(new[] { 1, 2, 3 }); //1    3->2->null

            var reverse = Reverse(list);
        }

        private static Node Reverse(Node list)
        {
            return ReverseListImpl(list);
        }

        private static Node ReverseListImpl(Node node)
        {
            if (node.Next == null)
            {
                return node;
            }

            var next = node.Next;
            node.Next = null;

            var reversed = ReverseListImpl(next);

            next.Next = node;

            //reversed.Next = node;
            //node.Next = null;

            return reversed;
        }
    }
}
