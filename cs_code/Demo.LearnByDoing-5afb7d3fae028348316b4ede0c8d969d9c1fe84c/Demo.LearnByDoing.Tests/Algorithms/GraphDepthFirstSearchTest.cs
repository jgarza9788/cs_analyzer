using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.Algorithms
{
    /// <summary>
    /// http://techieme.in/depth-first-traversal/
    /// https://github.com/officialdharam/techieme/blob/master/graph-theory/DepthFirst.java
    /// </summary>
    public class GraphDepthFirstSearchTest
    {
        [Theory]
        [MemberData(nameof(GetAdjacencyLists))]
        public static void TestDfsHappyPath(int[] expected, Dictionary<int, int[]> graph)
        {
            int[] actual = DfsAdjacencyList(graph);
            Assert.True(expected.SequenceEqual(actual));
        }

        /// <summary>
        /// DFS of a graph represented as an adjacency list.
        /// </summary>
        /// <summary>
        /// Create a stack and put the first item in it.
        /// initialize visited nodes - to get around cycles
        /// 
        /// initialize result sequence.
        /// 
        /// while the stack is not empty,
        ///     pop the node
        /// if visited, then skip
        /// else add the node to the result
        ///         and add adjacent vertices to the stack.
        /// 
        /// return the result.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        private static int[] DfsAdjacencyList(Dictionary<int, int[]> graph)
        {
            var stack = new Stack<int>();
            stack.Push(graph.First().Key);

            var visited = new HashSet<int>();

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();
                if (visited.Contains(vertex)) continue;

                visited.Add(vertex);
                if (!graph.ContainsKey(vertex)) continue;
                
                foreach (var neighbor in graph[vertex])
                {
                    if (visited.Contains(neighbor)) continue;
                    stack.Push(neighbor);
                }
            }

            return visited.ToArray();
        }

        public static IEnumerable<object[]> GetAdjacencyLists()
        {
            yield return new object[]
            {
                new[] {1, 2, 3, 4, 7, 8, 6, 5, 9},
                new Dictionary<int, int[]>
                {
                    {1, new[] {7, 4, 2}},
                    {2, new[] {3}},
                    {3, new[] {4}},
                    {4, new[] {1}},
                    {7, new[] {6, 8}},
                    {6, new[] {9, 5}},
                    {9, new[] {6}},
                }
            };
        }
    }
}
