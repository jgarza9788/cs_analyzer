using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Demo.LearnByDoing.General.Algorithms.Graph;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Algorithms
{
    /// <summary>
    /// CSE373 2012 - Lecture 12 - Breadth-First Search
    /// https://youtu.be/g5vF8jscteo
    /// </summary>
    public class GraphBreadthFirstSearchTest : BaseTest
    {
        public GraphBreadthFirstSearchTest(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [MemberData(nameof(GetSamples))]
        public void TestBfs(char[] expected, Graph<char> graph)
        {
            var actual = BreadthFirstSearchGraph(graph, new Node<char>('S'));

            Assert.True(expected.SequenceEqual(actual.Select(_ => _.Value).OrderBy(_ => _)));
        }

        private IEnumerable<Node<char>> BreadthFirstSearchGraph(Graph<char> graph, Node<char> start)
        {
            var q = new Queue<Node<char>>();
            q.Enqueue(start);

            var discovered = new HashSet<Node<char>> { start };

            while (q.Count > 0)
            {
                var vertex = q.Dequeue();

                Edge<char>[] edges = graph.Vertices[vertex];
                foreach (var edge in edges)
                {
                    if (!discovered.Contains(edge.Node))
                    {
                        q.Enqueue(edge.Node);
                        discovered.Add(edge.Node);
                    }
                }
            }

            return discovered;
        }

        public static IEnumerable<object[]> GetSamples()
        {
            var s = new Node<char>('S');
            var a = new Node<char>('A');
            var b = new Node<char>('B');
            var c = new Node<char>('C');
            var d = new Node<char>('D');
            var e = new Node<char>('E');

            var g1 = new Graph<char>();
            g1.AddVertex(s, new[] { new Edge<char>(10, a), new Edge<char>(8, e) });
            g1.AddVertex(a, new[] { new Edge<char>(2, c) });
            g1.AddVertex(b, new[] { new Edge<char>(1, a) });
            g1.AddVertex(c, new[] { new Edge<char>(-2, b) });
            g1.AddVertex(d, new[] { new Edge<char>(-1, c), new Edge<char>(-4, a) });
            g1.AddVertex(e, new[] { new Edge<char>(1, d) });

            yield return new object[] { new[] { 'A', 'B', 'C', 'D', 'E', 'S' }, g1 };
        }

    }
}
