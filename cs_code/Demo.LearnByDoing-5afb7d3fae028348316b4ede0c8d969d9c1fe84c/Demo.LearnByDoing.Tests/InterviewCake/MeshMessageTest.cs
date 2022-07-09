using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
    /// <summary>
    /// https://www.interviewcake.com/question/csharp/mesh-message?section=trees-graphs&course=fc1
    /// </summary>
    public class MeshMessageTest
    {
        public static string[] GetPath(Dictionary<string, string[]> graph, string startNode, string endNode)
        {
            // Queues
            var qA = new Queue<string>();
            var qB = new Queue<string>();
            // Visited
            var vA = new HashSet<string>();
            var vB = new HashSet<string>();
            // Parents
            var pA = new Dictionary<string, string>();
            var pB = new Dictionary<string, string>();

            qA.Enqueue(startNode);
            qB.Enqueue(endNode);
            vA.Add(startNode);
            vB.Add(endNode);
            pA[startNode] = null;
            pB[endNode] = null;

            while (qA.Count >= 1 || qB.Count >= 1)
            {
                var nodeA = GetCommonNode(graph, qA, pA, vA, vB);
                var nodeB = GetCommonNode(graph, qB, pB, vB, vA);
                if (nodeA != null || nodeB != null)
                {
                    // coalese
                    var foundNode = nodeA ?? nodeB;
                    var leftPaths = GetLeftPaths(pA, foundNode);
                    var rightPaths = GetRightPaths(pB, foundNode);

                    var result = new List<string>();
                    result.AddRange(leftPaths);
                    result.Add(foundNode);
                    result.AddRange(rightPaths);
                    return result.ToArray();
                }
            }

            return null;
        }

        public static string GetCommonNode(
            Dictionary<string, string[]> graph,
            Queue<string> q,
            Dictionary<string, string> p,
            HashSet<string> vFrom,
            HashSet<string> vTo
        )
        {
            if (q.Count <= 0) return null;

            var n = q.Dequeue();
            foreach (var nb in graph[n])
            {
                if (vTo.Contains(nb)) return nb;

                if (!vFrom.Contains(nb))
                {
                    p[nb] = n;
                    q.Enqueue(nb);
                    vFrom.Add(nb);
                }
            }

            return null;
        }

        public static IEnumerable<string> GetLeftPaths(Dictionary<string, string> p, string foundNode)
        {
            var result = new Stack<string>();
            var current = foundNode;

            while (p.ContainsKey(current) && p[current] != null)
            {
                result.Push(p[current]);
                current = p[current];
            }

            return result.ToList();
        }

        public static IEnumerable<string> GetRightPaths(Dictionary<string, string> p, string foundNode)
        {
            var result = new Queue<string>();
            var current = foundNode;

            while (p.ContainsKey(current) && p[current] != null)
            {
                result.Enqueue(current);
                current = p[current];
            }

            return result.ToList();
        }

















        // Tests

        [Fact]
        public void ThreeHopPathTest()
        {
            var expected = new[] { "d", "a", "c", "e" };
            var actual = GetPath(GetNetwork(), "d", "e");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoHopPath1Test()
        {
            var expected = new[] { "a", "c", "e" };
            var actual = GetPath(GetNetwork(), "a", "e");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoHopPath2Test()
        {
            var expected = new[] { "d", "a", "c" };
            var actual = GetPath(GetNetwork(), "d", "c");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OneHopPath1Test()
        {
            var expected = new[] { "a", "c" };
            var actual = GetPath(GetNetwork(), "a", "c");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OneHopPath2Test()
        {
            var expected = new[] { "f", "g" };
            var actual = GetPath(GetNetwork(), "f", "g");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OneHopPath3Test()
        {
            var expected = new[] { "g", "f" };
            var actual = GetPath(GetNetwork(), "g", "f");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ZeroHopPath()
        {
            var expected = new[] { "a" };
            var actual = GetPath(GetNetwork(), "a", "a");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NoPathTest()
        {
            var actual = GetPath(GetNetwork(), "a", "f");
            Assert.Null(actual);
        }

        [Fact]
        public void StartNodeNotPresentTest()
        {
            Assert.Throws<ArgumentException>(() => GetPath(GetNetwork(), "h", "a"));
        }

        [Fact]
        public void EndNodeNotPresentTest()
        {
            Assert.Throws<ArgumentException>(() => GetPath(GetNetwork(), "a", "h"));
        }

        private static Dictionary<string, string[]> GetNetwork()
        {
            return new Dictionary<string, string[]>()
            {
                { "a", new [] { "b", "c", "d"} },
                { "b", new [] { "a", "d" } },
                { "c", new [] { "a", "e" } },
                { "d", new [] { "a", "b" } },
                { "e", new [] { "c" } },
                { "f", new [] { "g" } },
                { "g", new [] { "f" } },
            };
        }
    }
}