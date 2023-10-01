public class BinaryTreeNode<T> where T : IComparable
{
    public T Data { get; set; }
    public BinaryTreeNode<T> LeftNode { get; set; }
    public BinaryTreeNode<T> RightNode { get; set; }

    public BinaryTreeNode(T data)
    {
        Data = data;
        LeftNode = null;
        RightNode = null;
    }
}