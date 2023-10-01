

namespace HwCreateGame
{
    public class Traversal<T> where T : IComparable
    {
        public void PreOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                Console.Write($"{node.Data} ");
                PreOrderTraversal(node.LeftNode);
                PreOrderTraversal(node.RightNode);
            }
        }

        public void PostOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.LeftNode);
                PostOrderTraversal(node.RightNode);
                Console.Write($"{node.Data} ");
            }
        }

        public void SpiralTraversal(BinaryTreeNode<T> node)
        {
            if (node == null)
                return;

            Stack<BinaryTreeNode<T>> currentLevel = new Stack<BinaryTreeNode<T>>();
            Stack<BinaryTreeNode<T>> nextLevel = new Stack<BinaryTreeNode<T>>();
            bool leftToRight = true;

            while (currentLevel.Count > 0)
            {
                BinaryTreeNode<T> currentNode = currentLevel.Pop();
                Console.Write($"{currentNode.Data} ");

                if (leftToRight)
                {
                    if (currentNode.LeftNode != null)
                        nextLevel.Push(currentNode.LeftNode);
                    if (currentNode.RightNode != null)
                        nextLevel.Push(currentNode.RightNode);
                }
                else
                {
                    if (currentNode.RightNode != null)
                        nextLevel.Push(currentNode.RightNode);
                    if (currentNode.LeftNode != null)
                        nextLevel.Push(currentNode.LeftNode);
                }

                if (currentLevel.Count == 0)
                {
                    leftToRight = !leftToRight;
                    Stack<BinaryTreeNode<T>> temp = currentLevel;
                    currentLevel = nextLevel;
                    nextLevel = temp;
                }
            }
        }
    }
}

