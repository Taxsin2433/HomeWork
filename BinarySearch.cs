using System;
namespace HwCreateGame
{
    public class BinarySearch<T> where T : IComparable
    {
        public bool Search(BinaryTreeNode<T> node, T target)
        {
            if (node == null)
                return false;

            int comparisonResult = target.CompareTo(node.Data);

            if (comparisonResult == 0)
                return true;
            else if (comparisonResult < 0)
                return Search(node.LeftNode, target);
            else
                return Search(node.RightNode, target);
        }
    }
}

   