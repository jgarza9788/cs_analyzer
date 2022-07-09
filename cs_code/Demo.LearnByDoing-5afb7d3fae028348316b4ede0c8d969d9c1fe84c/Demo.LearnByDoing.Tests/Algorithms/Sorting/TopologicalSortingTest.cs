using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.LearnByDoing.Tests.Algorithms.Sorting
{
    /// <summary>
    /// 2nd try
    /// https://www.youtube.com/watch?v=ddTC4Zovtbc
    /// </summary>
    public class TopologicalSortingTest
    {
        [Theory]
        [MemberData(nameof(GetSample))]
        public void TestTopologicalSortingUsingAdjacencyList(
            IEnumerable<char> expected,
            Dictionary<char, List<char>> graph)
        {
            var actual = TopologicalSortingUsingAdjacencyList(graph);
            Assert.True(expected.SequenceEqual(actual));
        }

        private IEnumerable<char> TopologicalSortingUsingAdjacencyList(Dictionary<char, List<char>> graph)
        {
            var visited = new HashSet<char>();
            var stack = new Stack<char>();

            foreach (KeyValuePair<char, List<char>> kv in graph)
            {
                if (visited.Contains(kv.Key)) continue;
                SortingUsingAdjacencyList(graph, kv.Key, visited, stack);
            }

            return stack;
        }

        private void SortingUsingAdjacencyList(
            Dictionary<char, List<char>> graph,
            char k,
            HashSet<char> visited,
            Stack<char> stack)
        {
            visited.Add(k);
            if (graph.ContainsKey(k))
            {
                foreach (var childVertex in graph[k])
                {
                    if (visited.Contains(childVertex)) continue;
                    SortingUsingAdjacencyList(graph, childVertex, visited, stack);
                }
            }

            stack.Push(k);
        }

        public static IEnumerable<object[]> GetSample()
        {
            yield return new object[]
            {
                new List<char> {'a', 'b', 'e', 'c', 'd', 'f', 'g'},
                new Dictionary<char, List<char>>
                {
                    {'d', new List<char>{'f'} },
                    {'f', new List<char>{'g'} },
                    {'b', new List<char>{'c', 'e'} },
                    {'c', new List<char>{'d'} },
                    {'a', new List<char>{'c'} },
                }
            };
        }
    }
}
