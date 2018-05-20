using CakeMergeCalendar.BinaryTree;
using System;

namespace CakeMergeCalendar2
{
    public class ValidBinarySearchTree
    {
        public static void ValidBinarySearchTreeMain()
        {
            var j = new BinaryTreeNode(100);
            var h = j.InsertLeft(90);
            var l = j.InsertRight(110);

            var g = h.InsertLeft(80);
            var i = h.InsertRight(95);

            var k = l.InsertLeft(105);
            var m = l.InsertRight(115);

            Console.WriteLine(j.IsValid());
        }
    }
}
