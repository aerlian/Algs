using System;

namespace CakeMergeCalendar
{
    public class AvlNode
    {
        private AvlNode _parent;
        private AvlNode _root;
        
        public string _value;

        public int Height { get; set; }
        public int Key { get; set; }
        public string Value => _value;

        public AvlNode Parent => _parent;
        public AvlNode Left { get; set; }
        public AvlNode Right { get; set; }

        public int LeftHeight => Left == null ? -1 : Left.Height;
        public int RightHeight => Right == null ? -1 : Right.Height;

        public AvlNode(int key, string value)
        {
            Key = key;
            _value = value;
        }

        public string Find(int key)
        {
            if (Key == key)
            {
                return _value;
            }

            if (key < Key && Left != null)
            {
                return Left.Find(key);
            }
            else if (key > Key && Right != null)
            {
                return Right.Find(key);
            }

            return null;
        }

        public void SetParent(AvlNode node)
        {
            _parent = node;
        }

        public void Dump()
        {
            if (Left != null)
            {
                Left.Dump();
            }
            Console.WriteLine($"Key: {Key}; value:{_value}; height:{Height}");
            if (Right != null)
            {
                Right.Dump();
            }
        }

        public AvlNode Insert(int key, string value)
        {
            return Insert(this, key, value);
        }


        public AvlNode Insert(AvlNode node, int key, string value)
        {

            if (node == null)
            {
                return new AvlNode(key, value);
            }
            else
            {
                if (key < Key)
                {
                    node.Left = Insert(node.Left, key, value);
                }
                else if (key > Key)
                {
                    node.Right = Insert(node.Right, key, value);
                }
                else
                {
                    node._value = value;
                }
            }

            node.Height = 1 + Math.Max(node.LeftHeight, node.RightHeight);

            var balance = node == null ? 0 : node.LeftHeight - node.RightHeight;

            if (balance > 1 && key < node.Left.Key)
            {
                return RightRotate(node);
            }

            // Right Right Case
            if (balance < -1 && key > node.Right.Key)
            {
                return LeftRotate(node);
            }

            // Left Right Case
            if (balance > 1 && key > node.Left.Key)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Right Left Case
            if (balance < -1 && key < node.Right.Key)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        private AvlNode LeftRotate(AvlNode x)
        {
            AvlNode y = x.Right;
            AvlNode temp = y.Left;

            y.Left = x;
            x.Right = temp;

            x.Height = Math.Max(x.LeftHeight, x.RightHeight) + 1;
            y.Height = Math.Max(y.LeftHeight, y.RightHeight) + 1;

            // Return new root
            return y;
        }

        private AvlNode RightRotate(AvlNode y)
        {
            var x = y.Left;
            var temp = x.Right;

            x.Right = y;
            y.Left = temp;

            y.Height = Math.Max(y.LeftHeight, y.RightHeight) + 1;
            x.Height = Math.Max(x.LeftHeight, x.RightHeight) + 1;

            return x;
        }

        public int GetBalance(AvlNode node)
        {
            return node == null ? 0 : node.LeftHeight - node.RightHeight;
        }
    }

    public static class Avl
    {
        public static void AvlMain()
        {

            var root = new AvlNode(50, "mike");
            root.Dump();

            root = root.Insert(60, "simon");
            Console.WriteLine();
            root.Dump();

            root = root.Insert(70, "kevin");
            Console.WriteLine();
            root.Dump();

            Console.WriteLine();
            Console.WriteLine(root.Find(70));

        }        
    }
}
