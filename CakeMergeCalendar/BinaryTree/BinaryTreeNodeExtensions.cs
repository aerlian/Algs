using System.Collections.Generic;

namespace CakeMergeCalendar.BinaryTree
{
    public static partial class BinaryTreeNodeExtensions
    {
        public static bool IsValid(this BinaryTreeNode source)
        {
            return IsValidImpl(source);
        }

        private static bool IsValidImpl(BinaryTreeNode node)
        {
            var nodeStack = new Stack<BinaryTreeNode>();
            nodeStack.Push(node);

            while (nodeStack.Count > 0)
            {
                var aNode = nodeStack.Pop();

                if ((aNode.Left == null ? int.MinValue : aNode.Left.Value) < aNode.Value &&
                    aNode.Value < (aNode.Right == null ? int.MaxValue : aNode.Right.Value))
                {
                    if (aNode.Left != null)
                    {
                        nodeStack.Push(aNode.Left);
                    }

                    if (aNode.Right != null)
                    {
                        nodeStack.Push(aNode.Right);
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
