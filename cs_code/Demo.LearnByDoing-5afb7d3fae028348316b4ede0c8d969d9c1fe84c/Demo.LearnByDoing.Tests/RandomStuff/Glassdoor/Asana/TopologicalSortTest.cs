using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.RandomStuff.Glassdoor.Asana
{
    /// <summary>
    /// Tushar Roy
    /// https://www.youtube.com/watch?v=ddTC4Zovtbc
    /// </summary>
    public class TopologicalSortTest : BaseTest

    {
        public static IEnumerable<object[]> GetInputForRecursion()
        {
            yield return new object[]
            {
                new[] {'b', 'd', 'a', 'c', 'e', 'f', 'g', 'h'},
                new Dictionary<char, List<char>>
                {
                    {'a', new List<char> {'c'}},
                    {'b', new List<char> {'d', 'c'}},
                    {'c', new List<char> {'e'}},
                    {'d', new List<char> {'f'}},
                    {'e', new List<char> {'h', 'f'}},
                    {'f', new List<char> {'g'}},
                    {'g', new List<char>()},
                    {'h', new List<char>()},
                }
            };
        }

        public static IEnumerable<object[]> GetInputForIteration()
        {
            yield return new object[]
            {
                new[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'},
                new Dictionary<char, List<char>>
                {
                    {'a', new List<char> {'c'}},
                    {'b', new List<char> {'d', 'c'}},
                    {'c', new List<char> {'e'}},
                    {'d', new List<char> {'f'}},
                    {'e', new List<char> {'h', 'f'}},
                    {'f', new List<char> {'g'}},
                    {'g', new List<char>()},
                    {'h', new List<char>()},
                }
            };
        }

        [Theory]
        [MemberData(nameof(GetInputForRecursion))]
        public void TestRecursiveTopologicalSort(char[] expected, Dictionary<char, List<char>> graph)
        {
            var actual = GetTopologicallySortedRecursively(graph);
            Assert.True(expected.SequenceEqual(actual));
        }

        [Theory]
        [MemberData(nameof(GetInputForIteration))]
        public void TestIterativeTopologicalSort(char[] expected, Dictionary<char, List<char>> graph)
        {
            var actual = GetTopologicallySortedIteratively(graph).ToList();
            Assert.True(expected.SequenceEqual(actual));
        }

        private IEnumerable<char> GetTopologicallySortedIteratively(Dictionary<char, List<char>> g)
        {
            var visited = new HashSet<char>();
            var sorted = new Queue<char>();

            foreach (var node in g.Keys)
            {
                if (visited.Contains(node)) continue;

                DepthFirstSearchNeighborsIteratively(g, node, visited, sorted);
            }

            return sorted.ToArray();
        }

        private void DepthFirstSearchNeighborsIteratively(
            Dictionary<char, List<char>> g, char node,
            HashSet<char> visited, Queue<char> sorted)
        {
            var stack = new Stack<char>();
            stack.Push(node);
            Func<bool> stackHasValue = () => stack.Count > 0;

            while (stackHasValue())
            {
                var currentNode = stack.Pop();
                visited.Add(currentNode);

                foreach (var neighbor in g[node])
                {
                    if (visited.Contains(currentNode)) continue;

                    stack.Push(neighbor);
                    visited.Add(neighbor);
                }
            }

            sorted.Enqueue(node);
        }

        private IEnumerable<char> GetTopologicallySortedRecursively(Dictionary<char, List<char>> g)
        {
            var visited = new HashSet<char>();
            var sorted = new Stack<char>();

            foreach (var node in g.Keys)
            {
                if (visited.Contains(node)) continue;

                DepthFirstSearchNeighborsRecursively(g, node, visited, sorted);
            }

            return sorted;
        }

        private void DepthFirstSearchNeighborsRecursively(Dictionary<char, List<char>> g, char node,
            HashSet<char> visited, Stack<char> sorted)
        {
            visited.Add(node);
            if (!g.ContainsKey(node)) return;

            foreach (var neighbor in g[node])
            {
                if (visited.Contains(neighbor)) continue;

                DepthFirstSearchNeighborsRecursively(g, neighbor, visited, sorted);
            }

            sorted.Push(node);
        }

        public TopologicalSortTest(ITestOutputHelper output) : base(output)
        {
        }
    }
}
