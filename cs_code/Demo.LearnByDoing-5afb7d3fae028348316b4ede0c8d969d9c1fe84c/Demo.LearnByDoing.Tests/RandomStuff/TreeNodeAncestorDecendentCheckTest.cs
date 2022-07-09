using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.RandomStuff
{
    /// <summary>
    /// Check if 2 tree nodes are related (ancestor/descendant) in O(1) with pre-processing
    /// https://stackoverflow.com/questions/10310809
    /// 
    /// Use http://www2.cs.arizona.edu/xiss/numbering.htm
    /// For two given nodes x and y of a tree T, 
    /// x is an ancestor of y if and only if x occurs before y in the preorder traversal of T 
    /// and after y in the post-order traversal.
    /// </summary>
    public class TreeNodeAncestorDecendentCheckTest : BaseTest
    {
        public TreeNodeAncestorDecendentCheckTest(ITestOutputHelper output) : base(output)
        {
        }

        private static int _preSteps;
        private static int _postSteps;

        [Theory]
        [MemberData(nameof(GetSampleInputs))]
        public static void TestSamples(bool expected, int parent, int decendant, Node node)
        {
            _preSteps = 0;
            _postSteps = 0;
            Dictionary<int, int> preMap = GetPreOrderMap(node);
            Dictionary<int, int> postMap = GetPostOrderMap(node);

            var actual = CheckParentDescendant(parent, decendant, preMap, postMap);
            Assert.Equal(expected, actual);
        }

        private static bool CheckParentDescendant(int parent, int decendant, Dictionary<int, int> preMap, Dictionary<int, int> postMap)
        {
            var preParentValue = preMap[parent];
            var postParentValue = postMap[parent];
            var preDescendantValue = preMap[decendant];
            var postDescendantValue = postMap[decendant];

            return preParentValue < preDescendantValue && postParentValue > postDescendantValue;
        }

        private static Dictionary<int, int> GetPreOrderMap(Node node)
        {
            return PreTraverseNode(node).ToList().ToDictionary(t => t.Item1, t => t.Item2);
        }

        private static IEnumerable<(int, int)> PreTraverseNode(Node node)
        {
            if (node == null) yield break;

            yield return (node.Value, ++_preSteps);
            foreach (var n in PreTraverseNode(node.Left).ToList()) yield return n;
            foreach (var n in PreTraverseNode(node.Right).ToList()) yield return n;
        }

        private static Dictionary<int, int> GetPostOrderMap(Node node)
        {
            return PostTraverseNode(node).ToList().ToDictionary(t => t.Item1, t => t.Item2);
        }

        private static IEnumerable<(int, int)> PostTraverseNode(Node node)
        {
            if (node == null) yield break;

            foreach (var n in PostTraverseNode(node.Left).ToList()) yield return n;
            foreach (var n in PostTraverseNode(node.Right).ToList()) yield return n;
            yield return (node.Value, ++_postSteps);
        }

        public static IEnumerable<object[]> GetSampleInputs()
        {
            // good
            yield return new object[] { true, 1, 2, GetBinaryTree() };
            yield return new object[] { true, 1, 3, GetBinaryTree() };
            yield return new object[] { true, 1, 4, GetBinaryTree() };
            yield return new object[] { true, 1, 5, GetBinaryTree() };
            yield return new object[] { true, 1, 6, GetBinaryTree() };
            yield return new object[] { true, 1, 7, GetBinaryTree() };

            yield return new object[] { true, 2, 4, GetBinaryTree() };
            yield return new object[] { true, 2, 5, GetBinaryTree() };

            yield return new object[] { true, 3, 6, GetBinaryTree() };
            yield return new object[] { true, 3, 7, GetBinaryTree() };

            // bad
            yield return new object[] { false, 2, 1, GetBinaryTree() };
            yield return new object[] { false, 3, 1, GetBinaryTree() };

            yield return new object[] { false, 4, 5, GetBinaryTree() };
            yield return new object[] { false, 4, 2, GetBinaryTree() };
            yield return new object[] { false, 4, 1, GetBinaryTree() };
            yield return new object[] { false, 4, 3, GetBinaryTree() };
            yield return new object[] { false, 4, 6, GetBinaryTree() };
            yield return new object[] { false, 4, 7, GetBinaryTree() };

            yield return new object[] { false, 5, 4, GetBinaryTree() };
            yield return new object[] { false, 5, 2, GetBinaryTree() };
            yield return new object[] { false, 5, 1, GetBinaryTree() };
            yield return new object[] { false, 5, 3, GetBinaryTree() };
            yield return new object[] { false, 5, 6, GetBinaryTree() };
            yield return new object[] { false, 5, 7, GetBinaryTree() };

            yield return new object[] { false, 6, 3, GetBinaryTree() };
            yield return new object[] { false, 6, 1, GetBinaryTree() };
            yield return new object[] { false, 6, 4, GetBinaryTree() };
            yield return new object[] { false, 6, 5, GetBinaryTree() };
            yield return new object[] { false, 6, 2, GetBinaryTree() };
            yield return new object[] { false, 6, 7, GetBinaryTree() };

            yield return new object[] { false, 7, 6, GetBinaryTree() };
            yield return new object[] { false, 7, 3, GetBinaryTree() };
            yield return new object[] { false, 7, 1, GetBinaryTree() };
            yield return new object[] { false, 7, 4, GetBinaryTree() };
            yield return new object[] { false, 7, 5, GetBinaryTree() };
            yield return new object[] { false, 7, 2, GetBinaryTree() };

        }

        private static Node GetBinaryTree()
        {
            /*
             *              1
             *          2       3
             *        4   5    6  7
             */
            return new Node
            {
                Value = 1,
                Left = new Node
                {
                    Value = 2,
                    Left = new Node { Value = 4 },
                    Right = new Node { Value = 5 }
                },
                Right = new Node
                {
                    Value = 3,
                    Left = new Node { Value = 6 },
                    Right = new Node { Value = 7 }
                }
            };
        }

        public class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

        }
    }


}
