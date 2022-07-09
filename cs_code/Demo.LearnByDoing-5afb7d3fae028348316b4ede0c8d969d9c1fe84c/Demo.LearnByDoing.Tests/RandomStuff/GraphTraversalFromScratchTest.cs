using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.RandomStuff
{
    public class GraphTraversalFromScratchTest : BaseTest
    {
        public GraphTraversalFromScratchTest(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Implementing using GeeksForGeeks algorithm
        /// https://www.geeksforgeeks.org/bidirectional-search/
        /// </summary>
        [Theory]
        [MemberData(nameof(GetBidrectionalBfsData))]
        public static void TesBidirectionaltBfs(Dictionary<int, List<int>> graph, int start, int end, bool expected)
        {
            bool actual = TraverseBidirectionaltBfs(graph, start, end);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Blind implementation https://stackoverflow.com/a/39782065/4035
        /// </summary>
        private static bool TraverseBidirectionaltBfs(Dictionary<int, List<int>> graph, int start, int end)
        {
            var qA = new Queue<int>();
            var qB = new Queue<int>();
            var visitedA = new HashSet<int>();
            var visitedB = new HashSet<int>();

            qA.Enqueue(start);
            qB.Enqueue(end);
            visitedA.Add(start);
            visitedB.Add(end);

            while (qA.Count > 0 || qB.Count > 0)
            {
                if (PathExistsBetween(graph, qA, visitedA, visitedB))
                    return true;
                if (PathExistsBetween(graph, qB, visitedB, visitedA))
                    return true;
            }

            return false;
        }

        private static bool PathExistsBetween(
            Dictionary<int, List<int>> graph, Queue<int> q,
            HashSet<int> visitedFrom, HashSet<int> visitedTo)
        {
            if (q.Count <= 0) return false;

            var next = q.Dequeue();
            foreach (var neighbor in graph[next])
            {
                if (visitedTo.Contains(neighbor))
                    return true;

                if (!visitedFrom.Contains(neighbor))
                {
                    visitedFrom.Add(neighbor);
                    q.Enqueue(neighbor);
                }
            }

            return false;
        }

        public static IEnumerable<object[]> GetBidrectionalBfsData()
        {
            yield return new object[] { GetBidrectionalBfsGraph(), 0, 14, true };
        }

        private static Dictionary<int, List<int>> GetBidrectionalBfsGraph()
        {
            return new Dictionary<int, List<int>>
            {
                {0, new List<int> {4}},
                {1, new List<int> {4}},
                {2, new List<int> {5}},
                {3, new List<int> {5}},
                {4, new List<int> {0, 1, 6}},
                {5, new List<int> {2, 3, 6}},
                {6, new List<int> {4, 5, 7}},
                {7, new List<int> {6, 8}},
                {8, new List<int> {7, 9, 10}},
                {9, new List<int> {8, 11, 12}},
                {10, new List<int> {8, 13, 14}},
                {11, new List<int> {9}},
                {12, new List<int> {9}},
                {13, new List<int> {10}},
                {14, new List<int> {10}},
            };
        }


        [Theory]
        [MemberData(nameof(GetBfsData))]
        public static void TestBfs(Dictionary<char, List<char>> graph, char[] expected)
        {
            var actual = TraverseBfs(graph).ToList();
            Assert.True(expected.SequenceEqual(actual));
        }

        private static IEnumerable<char> TraverseBfs(Dictionary<char, List<char>> graph)
        {
            var q = new Queue<char>();
            var visited = new HashSet<char>();

            q.Enqueue('a');

            while (q.Count > 0)
            {
                var v = q.Dequeue();
                visited.Add(v);

                foreach (var neighbor in graph[v])
                {
                    if (visited.Contains(neighbor)) continue;
                    q.Enqueue(neighbor);
                }
            }

            return visited;
        }

        public static IEnumerable<object[]> GetBfsData()
        {
            yield return new object[] { GetAdjanceDictionary(), new[] { 'a', 'b', 'd', 'g', 'e', 'f', 'c', 'h' } };
        }

        public static IEnumerable<object[]> GetDfsData()
        {
            yield return new object[] { GetDfsAdjanceDictionary(), new[] { 'a', 'b', 'd', 'f', 'e', 'c', 'g' } };
        }


        [Theory]
        [MemberData(nameof(GetDfsData))]
        public static void TestDfs(Dictionary<char, List<char>> graph, char[] expected)
        {
            var actual = TraverseDfs(graph).ToList();
            Assert.True(expected.SequenceEqual(actual));
        }

        /// <summary>
        /// Using https://en.wikipedia.org/wiki/Depth-first_search#Pseudocode
        /// </summary>
        private static IEnumerable<char> TraverseDfs(Dictionary<char, List<char>> graph)
        {
            var stack = new Stack<char>();
            var visited = new HashSet<char>();

            stack.Push('a');

            while (stack.Count > 0)
            {
                var v = stack.Pop();
                if (!visited.Contains(v))
                {
                    visited.Add(v);
                    foreach (char neighbor in graph[v])
                    {
                        stack.Push(neighbor);
                    }
                }
            }

            return visited;
        }


        public static Dictionary<char, List<char>> GetDfsAdjanceDictionary()
        {
            return new Dictionary<char, List<char>>
            {
                {'a', new List<char> {'d', 'c', 'b'}},
                {'b', new List<char> {'f', 'd', 'a'}},
                {'c', new List<char> {'g', 'a'}},
                {'d', new List<char> {'b'}},
                {'e', new List<char> {'f', 'a'}},
                {'f', new List<char> {'e', 'b'}},
                {'g', new List<char> {'c'}},
            };
        }

        public static Dictionary<char, List<char>> GetAdjanceDictionary()
        {
            return new Dictionary<char, List<char>>
            {
                {'a', new List<char> {'b', 'd', 'g'}},
                {'b', new List<char> {'e', 'f'}},
                {'e', new List<char> {'b', 'g'}},
                {'g', new List<char> {'a', 'e'}},
                {'d', new List<char> {'a', 'f'}},
                {'f', new List<char> {'b', 'd', 'c'}},
                {'c', new List<char> {'f', 'h'}},
                {'h', new List<char> {'c'}},
            };
        }
    }
}
