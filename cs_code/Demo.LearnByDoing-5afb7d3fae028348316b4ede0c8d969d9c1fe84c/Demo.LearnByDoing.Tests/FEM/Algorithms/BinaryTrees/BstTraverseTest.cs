using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.FEM.Algorithms.BinaryTrees
{
    public class BstTraverseTest
    {
        [Theory]
        [MemberData(nameof(GetInOrderData))]
        void TestInOrderTraversal(TraverseNode root, int[] expected)
        {
            var actual = TraverseInOrder(root).ToList();
            Assert.True(expected.SequenceEqual(actual));
        }

        IEnumerable<int> TraverseInOrder(TraverseNode root)
        {
            if (root.Left != null) foreach (var value in TraverseInOrder(root.Left).ToList()) yield return value;
            yield return root.Value;
            if (root.Right != null) foreach (var value in TraverseInOrder(root.Right).ToList()) yield return value;
        }

        [Theory]
        [MemberData(nameof(GetPreOrderData))]
        void TestPreOrderTraversal(TraverseNode root, int[] expected)
        {
            var actual = TraversePreOrder(root).ToList();
            Assert.True(expected.SequenceEqual(actual));
        }

        IEnumerable<int> TraversePreOrder(TraverseNode root)
        {
            yield return root.Value;
            if (root.Left != null) foreach (var value in TraversePreOrder(root.Left).ToList()) yield return value;
            if (root.Right != null) foreach (var value in TraversePreOrder(root.Right).ToList()) yield return value;
        }

        [Theory]
        [MemberData(nameof(GetPostOrderData))]
        void TestPostOrderTraversal(TraverseNode root, int[] expected)
        {
            var actual = TraversePostOrder(root).ToList();
            Assert.True(expected.SequenceEqual(actual));
        }

        IEnumerable<int> TraversePostOrder(TraverseNode root)
        {
            if (root.Left != null) foreach (var value in TraversePostOrder(root.Left).ToList()) yield return value;
            if (root.Right != null) foreach (var value in TraversePostOrder(root.Right).ToList()) yield return value;
            yield return root.Value;
        }

        public static IEnumerable<object[]> GetInOrderData()
        {
            yield return new object[] { GetSampleTree(), new[] { 1, 2, 3, 4, 5, 6, 7 } };
        }
        public static IEnumerable<object[]> GetPreOrderData()
        {
            yield return new object[] { GetSampleTree(), new[] { 4, 2, 1, 3, 6, 5, 7 } };
        }
        public static IEnumerable<object[]> GetPostOrderData()
        {
            yield return new object[] { GetSampleTree(), new[] { 1, 3, 2, 5, 7, 6, 4 } };
        }

        private static TraverseNode GetSampleTree()
        {
            return new TraverseNode
            {
                Value = 4,
                Left = new TraverseNode
                {
                    Value = 2,
                    Left = new TraverseNode { Value = 1 },
                    Right = new TraverseNode { Value = 3 }
                },
                Right = new TraverseNode
                {
                    Value = 6,
                    Left = new TraverseNode { Value = 5 },
                    Right = new TraverseNode { Value = 7 }
                }
            };
        }
    }

    class TraverseNode
    {
        public int Value { get; set; }
        public TraverseNode Left { get; set; }
        public TraverseNode Right { get; set; }
    }
}
