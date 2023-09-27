using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwCreateGame
{
    namespace HwCreateGame
    {
        public class BinaryTree<T> : IEnumerable<T> where T : IComparable
        {
            public BinaryTreeNode<T> RootNode { get; set; }
            public int Count { get; private set; }

            public BinaryTreeNode<T> Add(BinaryTreeNode<T> node, BinaryTreeNode<T> currentNode = null)
            {
                if (RootNode == null)
                {
                    node.ParentNode = null;
                    RootNode = node;
                    Count++;
                    return RootNode;
                }

                currentNode = currentNode ?? RootNode;
                node.ParentNode = currentNode;
                int result;
                if ((result = node.Data.CompareTo(currentNode.Data)) == 0)
                {
                    return currentNode;
                }
                else if (result < 0)
                {
                    if (currentNode.LeftNode == null)
                    {
                        currentNode.LeftNode = node;
                        Count++;
                        return currentNode.LeftNode;
                    }
                    else
                    {
                        return Add(node, currentNode.LeftNode);
                    }
                }
                else
                {
                    if (currentNode.RightNode == null)
                    {
                        currentNode.RightNode = node;
                        Count++;
                        return currentNode.RightNode;
                    }
                    else
                    {
                        return Add(node, currentNode.RightNode);
                    }
                }
            }

            public BinaryTreeNode<T> Add(T data)
            {
                return Add(new BinaryTreeNode<T>(data));
            }

            public BinaryTreeNode<T>? FindNode(T data, BinaryTreeNode<T> startWithNode = null)
            {
                startWithNode = startWithNode ?? RootNode;
                int result;
                if ((result = data.CompareTo(startWithNode.Data)) == 0)
                {
                    return startWithNode;
                }
                else if (result < 0)
                {
                    if (startWithNode.LeftNode == null)
                    {
                        return null;
                    }
                    else
                    {
                        return FindNode(data, startWithNode.LeftNode);
                    }
                }
                else
                {
                    if (startWithNode.RightNode == null)
                    {
                        return null;
                    }
                    else
                    {
                        return FindNode(data, startWithNode.RightNode);
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
                    var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
                    Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Data}");
                    indent += new string(' ', 3);
                    PrintTree(startNode.LeftNode, indent, Side.Left);
                    PrintTree(startNode.RightNode, indent, Side.Right);
                }
            }
            public IEnumerator<T> GetEnumerator()
            {
                return InOrderTraversal(RootNode).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            private IEnumerable<T> InOrderTraversal(BinaryTreeNode<T> node)
            {
                if (node != null)
                {
                    foreach (var item in InOrderTraversal(node.LeftNode))
                        yield return item;

                    yield return node.Data;

                    foreach (var item in InOrderTraversal(node.RightNode))
                        yield return item;
                }
            }
        }
    }
}
    


         

