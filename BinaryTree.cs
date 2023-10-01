namespace HwCreateGame
{
    namespace HwCreateGame
    {
        public class BinaryTree<T> where T : IComparable
        {
            public BinaryTreeNode<T> RootNode { get; set; }

            public void Insert(T data)
            {
                if (RootNode == null)
                {
                    RootNode = new BinaryTreeNode<T>(data);
                    return;
                }

                InsertRecursive(RootNode, data);
            }

            private void InsertRecursive(BinaryTreeNode<T> node, T data)
            {
                if (data.CompareTo(node.Data) < 0)
                {
                    if (node.LeftNode == null)
                    {
                        node.LeftNode = new BinaryTreeNode<T>(data);
                    }
                    else
                    {
                        InsertRecursive(node.LeftNode, data);
                    }
                }
                else
                {
                    if (node.RightNode == null)
                    {
                        node.RightNode = new BinaryTreeNode<T>(data);
                    }
                    else
                    {
                        InsertRecursive(node.RightNode, data);
                    }
                }
            }

            public void PrintTree()
            {
                PrintTree(RootNode);
            }

            private void PrintTree(BinaryTreeNode<T> startNode, string indent = "", Side? side = null)
            {
                if (startNode != null)
                {
                    string sideString = side == Side.Left ? "L" : side == Side.Right ? "R" : "Root";
                    Console.WriteLine($"{indent} [{sideString}] {startNode.Data}");
                    indent += "   ";
                    PrintTree(startNode.LeftNode, indent, Side.Left);
                    PrintTree(startNode.RightNode, indent, Side.Right);
                }
            }

            public enum Side
            {
                Left,
                Right
            }
        }
    }
}
    


         

