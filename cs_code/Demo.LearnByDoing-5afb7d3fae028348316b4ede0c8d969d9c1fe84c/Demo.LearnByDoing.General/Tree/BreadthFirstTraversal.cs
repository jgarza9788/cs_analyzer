using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.General.Tree
{
    /// <summary>
    /// Traverse a tree using Breadth-first search algorithm.
    /// </summary>
    public class BreadthFirstTraversal
    {
        public static void Main(string[] args)
        {
            TreeNode<int> root = CreateSampleBinaryTree();

            List<int> list = new List<int>();
            TraverseBreadthFirst(root, list);

            PrintListWithHeader("===== Bread-first Traversal =====", list);
        }

        private static void TraverseBreadthFirst(TreeNode<int> root, List<int> list)
        {
            if (root == null) return;

            Queue<TreeNode<int>> queue = new Queue<TreeNode<int>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                list.Add(node.Value);

                if (node.Left != null)
                    queue.Enqueue(node.Left);

                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }
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
