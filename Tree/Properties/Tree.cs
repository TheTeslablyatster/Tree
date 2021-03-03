using System;
using System.Collections;

namespace Tree.Properties
{
    class Tree<T> where T: IComparable
    {
        public TreeNode<T> RootNode { get; set; }
        public Tree (TreeNode<T> node = null)
        {
            this.RootNode = node;
        }

        public TreeNode<T> Add(TreeNode<T> node, TreeNode<T> currentNode = null)
        {
            if (RootNode == null)
            {
                node.ParentNode = null;
                return RootNode = node;
            }

            currentNode = currentNode ?? RootNode;
            node.ParentNode = currentNode;
            int result;
            return (result = node.Value.CompareTo(currentNode.Value)) == 0
                ? currentNode
                : result < 0
                    ? currentNode.LeftNode == null
                        ? (currentNode.LeftNode = node)
                        : Add(node, currentNode.LeftNode)
                    : currentNode.RightNode == null
                        ? (currentNode.RightNode = node)
                        : Add(node, currentNode.RightNode);
        }
        public TreeNode<T> Add(T value)
        {
            return Add(new TreeNode<T>(value));
        }

        public TreeNode<T> FindNode(T value, TreeNode<T> currentNode = null)
        {
            currentNode = currentNode ?? RootNode;
            int result;
            return (result = value.CompareTo(currentNode.Value)) == 0
                ? currentNode
                : result < 0
                    ? currentNode.LeftNode == null
                        ? null
                        : FindNode(value, currentNode.LeftNode)
                    : currentNode.RightNode == null
                        ? null
                        : FindNode(value, currentNode.RightNode);
        }

        public void Remove(TreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            var currentNodeSide = node.NodeSide;
            if (node.LeftNode == null && node.RightNode == null)
            {
                 _= currentNodeSide == Side.Left 
                    ? node.ParentNode.LeftNode = null            
                    : node.ParentNode.RightNode = null;
            } 
            else if (node.LeftNode == null)
            {
                _= currentNodeSide == Side.Left
                    ? node.ParentNode.LeftNode = node.RightNode
                    : node.ParentNode.RightNode = node.RightNode;

                node.RightNode.ParentNode = node.ParentNode;
            }
            else if (node.RightNode == null)
            {
                _=currentNodeSide == Side.Left
                    ? node.ParentNode.LeftNode = node.LeftNode
                    : node.ParentNode.RightNode = node.LeftNode;

                node.LeftNode.ParentNode = node.ParentNode;
            }
            else
            {
                switch (currentNodeSide)
                {
                    case Side.Left:
                        node.ParentNode.LeftNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    case Side.Right:
                        node.ParentNode.RightNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    default:
                        var helpLeft = node.LeftNode;
                        var helpRightLeft = node.RightNode.LeftNode;
                        var helpRightRight = node.RightNode.RightNode;
                        node.Value = node.RightNode.Value;
                        node.RightNode = helpRightRight;
                        node.LeftNode = helpRightLeft;
                        Add(helpLeft, node);
                        break;
                }
            }
        }

        public void Remove(T value)
        {
            var foundNode = FindNode(value);
            Remove(foundNode);
        }

        public IEnumerable TreeEnumerator(TreeNode<T> startNode)
        {
            if (startNode != null)
            {
                yield return startNode;
                TreeEnumerator(startNode.LeftNode);
                TreeEnumerator(startNode.RightNode);
            }

        }

        private void PrintTree(TreeNode<T> startNode, string indent = "", Side? side = null)
        {
            if (startNode != null)
            {
                var nodeSide = side == null ? "Root" : side == Side.Left ? "Left" : "Right";
                Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Value}");
                indent += new string(' ', 3);
                PrintTree(startNode.LeftNode, indent, Side.Left);
                PrintTree(startNode.RightNode, indent, Side.Right);
            }
        }

        public void PrintTree()
        {
            PrintTree(RootNode);
        }

    }
    
}
