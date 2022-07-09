using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace Demo.LearnByDoing.Tests.RandomStuff.Glassdoor.Zocdoc
{
    /// <summary>
    /// Write a program to find the highest descendant of a binary  tree given two nodes of the tree. the node structure contained parent, left, and right.
    /// 
    /// https://www.glassdoor.com/Interview/Write-a-program-to-find-the-highest-descendant-of-a-binary-tree-given-two-nodes-of-the-tree-the-node-structure-contained-QTN_1035819.htm
    /// </summary>
    public class FindLcaInBinaryTreeTest
    {
        [DebuggerStepThrough]
        static BinaryTreeNode GetSampleBinaryTreeNode()
        {
            return new BinaryTreeNode(1)
            {
                Left = new BinaryTreeNode(2)
                {
                    Left = new BinaryTreeNode(4),
                    Right = new BinaryTreeNode(5)
                },
                Right = new BinaryTreeNode(3)
                {
                    Left = new BinaryTreeNode(6),
                    Right = new BinaryTreeNode(7)
                }
            };
        }

        [Theory]
        [MemberData(nameof(GetSampleInputs))]
        public static void TestSamples(int expected, int leftValue, int rightValue)
        {
            _isLeftFound = false;
            _isRightFound = false;

            //var node = FindLca(GetSampleBinaryTreeNode(), leftValue, rightValue);
            var node = FindLca2(GetSampleBinaryTreeNode(), leftValue, rightValue);
            var actual = _isLeftFound && _isRightFound ? node : null;

            if (_isLeftFound && _isRightFound) Assert.Equal(expected, actual?.Value);
            else Assert.Null(actual);
        }

        private static bool _isLeftFound = false;
        private static bool _isRightFound = false;
        private static BinaryTreeNode FindLca2(BinaryTreeNode node, int n1, int n2)
        {
            if (node == null) return null;
            //if (node.Value == n1 || node.Value == n2) return node;
            if (node.Value == n1)
            {
                _isLeftFound = true;
                return node;
            }

            if (node.Value == n2)
            {
                _isRightFound = true;
                return node;
            }

            var leftLca = FindLca2(node.Left, n1, n2);
            var rightLca = FindLca2(node.Right, n1, n2);

            if (leftLca != null && rightLca != null) return node;
            return leftLca ?? rightLca;
        }

        /// <summary>
        /// https://www.geeksforgeeks.org/lowest-common-ancestor-binary-tree-set-1/
        /// </summary>
        private static BinaryTreeNode FindLca(BinaryTreeNode node, int n1, int n2)
        {
            // Base case
            if (node == null)
                return null;

            // If either n1 or n2 matches with root's key, report
            // the presence by returning root (Note that if a key is
            // ancestor of other, then the ancestor key becomes LCA
            if (node.Value == n1 || node.Value == n2)
                return node;

            // Look for keys in left and right subtrees
            BinaryTreeNode left_lca = FindLca(node.Left, n1, n2);
            BinaryTreeNode right_lca = FindLca(node.Right, n1, n2);

            // If both of the above calls return Non-NULL, then one key
            // is present in once subtree and other is present in other,
            // So this node is the LCA
            if (left_lca != null && right_lca != null)
                return node;

            // Otherwise check if left subtree or right subtree is LCA
            return left_lca ?? right_lca;
        }

        [DebuggerStepThrough]
        public static IEnumerable<object[]> GetSampleInputs()
        {
            yield return new object[] { 2, 4, 5 };
            yield return new object[] { 2, 5, 4 };
            yield return new object[] { 1, 4, 6 };
            yield return new object[] { 1, 6, 4 };
            yield return new object[] { 1, 3, 4 };
            yield return new object[] { 1, 4, 3 };
            yield return new object[] { 2, 2, 4 };
            yield return new object[] { 2, 4, 2 };
            yield return new object[] { 1, 4, 7 };
            yield return new object[] { 1, 7, 4 };
            yield return new object[] { 1, 4, 6 };
            yield return new object[] { 1, 6, 4 };
            yield return new object[] { 1, 5, 6 };
            yield return new object[] { 1, 6, 5 };
            yield return new object[] { 1, 5, 7 };
            yield return new object[] { 1, 7, 5 };
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { 1, 3, 2 };
            yield return new object[] { 1, 2, 6 };
            yield return new object[] { 1, 6, 2 };
            yield return new object[] { 1, 2, 7 };
            yield return new object[] { 1, 7, 2 };
            yield return new object[] { 1, 3, 4 };
            yield return new object[] { 1, 4, 3 };
            yield return new object[] { 1, 3, 5 };
            yield return new object[] { 1, 5, 3 };
            yield return new object[] { 1, 5, 10 };
        }
    }

    [DebuggerStepThrough]
    public class BinaryTreeNode
    {
        public int Value { get; }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }

        public BinaryTreeNode(int value)
        {
            Value = value;
        }

        public BinaryTreeNode InsertLeft(int leftValue)
        {
            Left = new BinaryTreeNode(leftValue);
            return Left;
        }

        public BinaryTreeNode InsertRight(int rightValue)
        {
            Right = new BinaryTreeNode(rightValue);
            return Right;
        }

        public override string ToString()
        {
            return $"{Left?.Value}:{Value}:{Right?.Value}";
        }
    }
}
