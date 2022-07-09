using System;
using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.RandomStuff.Glassdoor.Asana
{
    public class BalancedTreeCheckerTest
    {
        public static IEnumerable<object[]> GetTrueCases()
        {
            var root = new BinaryTreeNode(1);
            yield return new object[] { true, root };

            root.InsertLeft(2);
            yield return new object[] { true, root };

            root.InsertRight(3);
            yield return new object[] { true, root };

            var root2 = new BinaryTreeNode(1);
            root2.InsertLeft(2).InsertLeft(3);
            yield return new object[] { false, root2 };

            var root3 = new BinaryTreeNode(1);
            root3.InsertRight(2).InsertRight(3);
            yield return new object[] { false, root3 };

            var root4 = new BinaryTreeNode(1);
            root4.InsertLeft(2).InsertLeft(3);
            root4.InsertRight(5);
            yield return new object[] { true, root4 };
        }

        [Theory]
        [MemberData(nameof(GetTrueCases))]
        void TestSuperBalancedTrees(bool expected, BinaryTreeNode root)
        {
            var actual = IsBalancedTree(root);
            Assert.Equal(expected, actual);
        }

        private bool IsBalancedTree(BinaryTreeNode node)
        {
            int leftDepth = GetMaxDepth(node.Left, 0);
            int rightDepth = GetMaxDepth(node.Right, 0);

            return Math.Abs(leftDepth - rightDepth) <= 1;
        }

        private int GetMaxDepth(BinaryTreeNode node, int depth)
        {
            if (node == null) return depth;

            int left = GetMaxDepth(node.Left, depth + 1);
            int right = GetMaxDepth(node.Right, depth + 1);

            return Math.Max(left, right);
        }
    }

    class BinaryTreeNode
    {
        public int Value { get; }
        public BinaryTreeNode Left { get; private set; }
        public BinaryTreeNode Right { get; private set; }

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
    }
}
