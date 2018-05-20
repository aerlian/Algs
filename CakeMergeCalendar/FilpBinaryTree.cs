using System;
using System.Collections.Generic;
using System.Text;

namespace CakeMergeCalendar
{
    public class FlipBinaryTree
    {
        public static void FlipBinaryTreeMain()
        {
            var source = new[] { 1, 1, 3, 5, 8, 13, 21 };

            var node = BalancedTreeBuilder.CreateBalancedTree(source, 0, source.Length - 1);

            Console.WriteLine("Pre-flip dump");
            DumpTree(node);
            Flip(node);
            Console.WriteLine();
            Console.WriteLine("Post-flip dump");
            DumpTree(node);

        }

        public static void DumpTree(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            DumpTree(node.Left);
            Console.WriteLine(node.Value);
            DumpTree(node.Right);
        }

        private static void Flip(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            var temp = node.Left;
            node.Left = node.Right;
            node.Right = temp;

            Flip(node.Left);
            Flip(node.Right);
        }
    }
}
