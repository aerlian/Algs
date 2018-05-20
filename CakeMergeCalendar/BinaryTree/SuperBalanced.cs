using System;
using System.Collections.Generic;
using System.Linq;

namespace CakeMergeCalendar
{
    class SuperBalanced
    {
        public static void SuperBalancedMain()
        {
            var b1 = new BinaryTreeNode(10);

            var l1 = b1.InsertLeft(11);
            l1.InsertLeft(100);

           
            var l3 = l1.InsertRight(200);

            l3.InsertLeft(6000);

            b1.InsertRight(12);

            Console.WriteLine(b1.IsSuperBalanced);
        }       
    }

    public class BinaryTreeNode
    {
        public int Value { get; }

        public BinaryTreeNode Left { get; private set; }

        public BinaryTreeNode Right { get; private set; }

        public BinaryTreeNode(int value)
        {
            Value = value;
        }

        public BinaryTreeNode InsertLeft(int leftValue)
        {
            Left = new BinaryTreeNode(leftValue);
            return Left;
        }

        public BinaryTreeNode InsertRight(int rightValue)
        {
            Right = new BinaryTreeNode(rightValue);
            return Right;
        }

        public bool IsSuperBalanced {
            get
            {
                var depths = GetLeafDepths(this, 1);

                return depths.Max() - depths.Min() <= 1;
            } }

        private IEnumerable<int> GetLeafDepths(BinaryTreeNode node, int depth)
        {
            if (node.Left == null && node.Right == null)
            {
                yield return depth;
            }

            if (node.Left != null)
            {
                foreach(var d in GetLeafDepths(node.Left, depth + 1))
                {
                    yield return d;
                }
            }

            if (node.Right != null)
            {
                foreach (var d in GetLeafDepths(node.Right, depth + 1))
                {
                    yield return d;
                }                
            }
        }
    }
}
