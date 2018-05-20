using System;
namespace CakeMergeCalendar
{
    public class ListBuilder
    {
        public static Node Create(int [] source)
        {
            Node head = null;

            for(var i = source.Length - 1; i >= 0; i--)
            {
                var next = new Node { Value = source[i] };

                if (head == null)
                {
                    head = next;
                }
                else
                {                    
                    next.Next = head;
                    head = next;
                }
            }

            return head;
        }

        public static void Dump(Node head)
        {
            var current = head;

            while(current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }
    }
}
