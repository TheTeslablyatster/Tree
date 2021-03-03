using System;

namespace Tree.Properties
{
    public enum Side
    {
        Left,
        Right
    }

    public class TreeNode<T>  where T : IComparable
    {
        public TreeNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }

        public TreeNode<T> LeftNode { get; set; }
        public TreeNode<T> RightNode { get; set; }
        public TreeNode<T> ParentNode { get; set; }

        public Side? NodeSide =>
            ParentNode == null
            ? (Side?)null
            : ParentNode.LeftNode == this
                ? Side.Left
                : Side.Right;

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
