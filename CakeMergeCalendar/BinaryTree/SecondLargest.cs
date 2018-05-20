namespace CakeMergeCalendar.BinaryTree
{
    public class SecondLargest
    {
        public static void SecondLargestMain()
        {
            var j = new BinaryTreeNode(100);
            var h = j.InsertLeft(90);
            var l = j.InsertRight(110);

            var g = h.InsertLeft(80);
            var i = h.InsertRight(95);

            var k = l.InsertLeft(105);
            //var m = l.InsertRight(115);

            System.Console.WriteLine(j.Second().Value);
        }
    }

    public static partial class BinaryTreeNodeExtensions
    {
        public static BinaryTreeNode Second(this BinaryTreeNode source)
        {
            return SecondImpl(source.Left ?? source.Right, null);
        }

        public static BinaryTreeNode SecondImpl(this BinaryTreeNode source, BinaryTreeNode trailing)
        {
            if (source.Right == null && source.Left == null)
            {
                return trailing;
            }

            if (source.Right != null)
            {
                return SecondImpl(source.Right, source);
            }

            return source.Left;
        }
    }
}
