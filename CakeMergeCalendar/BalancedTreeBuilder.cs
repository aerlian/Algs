using System;
namespace CakeMergeCalendar
{
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }

    public class BalancedTreeBuilder
    {
        public static void BalancedTreeBuilderMain()
        {
            var source = new[] { 1, 1, 3, 5, 8, 13, 21 };

            //5
            //l: 1,1,3
            //r: 8,13,21

            //                     5
            //                 1         13
            //              1     3   8      21

            //left: 1,1,3

            var tree = CreateBalancedTree(source, 0, source.Length -1);
        }

        public static TreeNode CreateBalancedTree(int[] source, int start, int end)
        {
            if (start > end || end < start)
            {
                return null;
            }

            var mid = start + ((end - start) / 2);
            var value = source[mid];
            

            var tree = new TreeNode { Value = value };

            tree.Left = CreateBalancedTree(source, start, mid - 1);
            tree.Right = CreateBalancedTree(source, mid + 1, end);

            return tree;
        }
    }
}
