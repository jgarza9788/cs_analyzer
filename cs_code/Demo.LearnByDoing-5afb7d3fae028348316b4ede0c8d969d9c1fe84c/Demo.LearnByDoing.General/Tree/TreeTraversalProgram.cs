using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.General.Tree
{
    public class TreeTraversalProgram
    {
        public static void Main(string[] args)
        {
            TreeNode<int> root = CreateSampleBinaryTree();

            List<int> inOrderList = new List<int>();
            InOrderTraversal(root, inOrderList);
            PrintListWithHeader("In-Order Traversal", inOrderList);

            List<int> preOrderList = new List<int>();
            PreOrderTraversal(root, preOrderList);
            PrintListWithHeader("Pre-Order Traversal", preOrderList);

            List<int> postOrderList = new List<int>();
            PostOrderTraversal(root, postOrderList);
            PrintListWithHeader("Post-Order Traversal", postOrderList);
        }

        private static void PostOrderTraversal(TreeNode<int> node, List<int> list)
        {
            if (node == null) return;

            PostOrderTraversal(node.Left, list);
            PostOrderTraversal(node.Right, list);
            list.Add(node.Value);
        }

        private static void PreOrderTraversal(TreeNode<int> node, List<int> list)
        {
            if (node == null) return;

            list.Add(node.Value);
            PreOrderTraversal(node.Left, list);
            PreOrderTraversal(node.Right, list);
        }

        private static void InOrderTraversal(TreeNode<int> node, List<int> list)
        {
            if (node == null) return;

            InOrderTraversal(node.Left, list);
            list.Add(node.Value);
            InOrderTraversal(node.Right, list);
        }

        private static void PrintListWithHeader(string header, List<int> list)
        {
            Console.Write("{0}: {1}", header, string.Join(" ", list.Select(val => val.ToString()).ToArray()));
            Console.WriteLine();
        }

        private static TreeNode<int> CreateSampleBinaryTree()
        {
            TreeNode<int> root = new TreeNode<int>(4)
            {
                Left = new TreeNode<int>(2, new TreeNode<int>(1), new TreeNode<int>(3)),
                Right = new TreeNode<int>(6, new TreeNode<int>(5), new TreeNode<int>(7))
            };
            return root;
        }
    }
}
