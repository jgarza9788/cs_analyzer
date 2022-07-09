using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.General.Algorithms.Graph;
using Xunit;

namespace Demo.LearnByDoing.Tests.Algorithms
{
    /// <summary>
    /// Implement Bellman-Ford from scratch
    /// 
    /// OverView: https://www.youtube.com/watch?v=obWXjtg0L64&t=139s
    /// Implementation: https://www.youtube.com/watch?v=-mOEd_3gTK0
    /// </summary>
    public class BellmanFordFromScratchTest
    {
        [Fact]
        public void TestBellmanFordFromMemory()
        {
            var g = new Dictionary<char, List<(char ToVertex, int Weight)>>
            {
                {
                    '0', new List<(char ToVertex, int Weight)>
                    {
                        ('1', 4),
                        ('2', 5),
                        ('3', 8),
                    }
                },
                {
                    '1', new List<(char ToVertex, int Weight)>
                    {
                        ('2', -3),
                    }
                },
                {
                    '2', new List<(char ToVertex, int Weight)>
                    {
                        ('4', 4),
                    }
                },
                {
                    '3', new List<(char ToVertex, int Weight)>
                    {
                        ('4', 2),
                    }
                },
                {
                    '4', new List<(char ToVertex, int Weight)>
                    {
                        ('3', 1),
                    }
                },
            };

            var expected = new Dictionary<char, (int Distance, char? Parent)>
            {
                {'0', (Distance: 0, Parent: (char?) null)},
                {'1', (Distance: 4, Parent: '0')},
                {'2', (Distance: 1, Parent: '1')},
                {'3', (Distance: 6, Parent: '4')},
                {'4', (Distance: 5, Parent: '2')},
            };

            var actual = GetShortestPaths2(g, g.First().Key);
            Assert.True(AreTuplesSame(expected, actual));

            var actual2 = GetShortestPaths3(g, g.First().Key);
            Assert.True(AreTuplesSame(expected, actual2));

            var actual3 = GetShortestPaths4(g, g.First().Key);
            Assert.True(AreTuplesSame(expected, actual3));

            var actual4 = GetShortestPaths5(g, g.First().Key);
            Assert.True(AreTuplesSame(expected, actual4));
        }

        private Dictionary<char, (int Distance, char? Parent)> GetShortestPaths5(
            Dictionary<char, List<(char ToVertex, int Weight)>> g, char sourceVertex)
        {
            var parents = new Dictionary<char, char?>{{sourceVertex, null}};
            var distances = new Dictionary<char, int>();
            
            // fill distances
            foreach (char vertex in g.Keys)
            {
                distances.Add(vertex, int.MaxValue);
            }

            distances[sourceVertex] = 0;

            // relax distances
            for (int i = 0; i < g.Keys.Count - 1; i++)
            {
                foreach (var startVertex in g.Keys)
                {
                    var edges = g[startVertex];
                    foreach ((char ToVertex, int Weight) edge in edges)
                    {
                        var endVertex = edge.ToVertex;
                        var currentWeight = distances[endVertex];
                        var newWeight = distances[startVertex] + edge.Weight;
                        if (newWeight < currentWeight)
                        {
                            distances[endVertex] = newWeight;
                            if (parents.ContainsKey(endVertex)) parents[endVertex] = startVertex;
                            else parents.Add(endVertex, startVertex);
                        }
                    }
                }
            }

            // return built result
            var result = new Dictionary<char, (int Distance, char? Parent)>();
            foreach (var vertex in g.Keys)
            {
                result.Add(vertex, (distances[vertex], parents[vertex]));
            }
            return result;
        }

        private Dictionary<char, (int Distance, char? Parent)> GetShortestPaths4(
            Dictionary<char, List<(char ToVertex, int Weight)>> g, char sourceVertex)
        {
            var distances = g.Keys.Aggregate(new Dictionary<char, int>(), (acc, v) =>
            {
                acc.Add(v, int.MaxValue);
                return acc;
            });
            distances[sourceVertex] = 0;
            var parents = new Dictionary<char, char?> {{sourceVertex, null}};

            for (int i = 0; i < g.Keys.Count - 1; i++)
            {
                foreach (var fromVertex in g.Keys)
                {
                    var edges = g[fromVertex];
                    foreach ((char ToVertex, int Weight) edge in edges)
                    {
                        var currentWeight = distances[edge.ToVertex];
                        var newWeight = distances[fromVertex] + edge.Weight;
                        if (newWeight < currentWeight)
                        {
                            distances[edge.ToVertex] = newWeight;
                            if (parents.ContainsKey(edge.ToVertex)) parents[edge.ToVertex] = fromVertex;
                            else parents.Add(edge.ToVertex, fromVertex);
                        }
                    }
                }
            }

            return distances.Aggregate(new Dictionary<char, (int Distance, char? Parent)>(), (acc, distance) =>
            {
                acc.Add(distance.Key, (distance.Value, parents[distance.Key]));
                return acc;
            });
        }

        private Dictionary<char, (int Distance, char? Parent)> GetShortestPaths3(
            Dictionary<char, List<(char ToVertex, int Weight)>> g, char sourceVertex)
        {
            var distances = new Dictionary<char, int>();
            var parents = new Dictionary<char, char?>();

            foreach (var v in g.Keys)
            {
                distances.Add(v, int.MaxValue);
            }

            distances[sourceVertex] = 0;
            parents.Add(sourceVertex, null);

            for (int i = 0; i < g.Keys.Count - 1; i++)
            {
                foreach (char fromVertex in g.Keys)
                {
                    var edges = g[fromVertex];
                    foreach ((char ToVertex, int Weight) edge in edges)
                    {
                        var currentWeight = distances[edge.ToVertex];
                        var newWeight = distances[fromVertex] + edge.Weight;
                        if (newWeight < currentWeight)
                        {
                            distances[edge.ToVertex] = newWeight;
                            if (parents.ContainsKey(edge.ToVertex)) parents[edge.ToVertex] = fromVertex;
                            else parents.Add(edge.ToVertex, fromVertex);
                        }
                    }
                }
            }

            var result = new Dictionary<char, (int Distance, char? Parent)>();
            foreach (KeyValuePair<char, int> distance in distances)
            {
                result.Add(distance.Key, (distance.Value, parents[distance.Key]));
            }

            return result;
        }

        private bool AreTuplesSame(Dictionary<char, (int Distance, char? Parent)> expected,
            Dictionary<char, (int Distance, char? Parent)> actual)
        {
            if (expected.Count != actual.Count) return false;

            foreach (KeyValuePair<char, (int Distance, char? Parent)> expectedNode in expected)
            {
                (int Distance, int? Parent) actualValue = actual[expectedNode.Key];
                (int Distance, int? Parent) expectedValue = expectedNode.Value;
                if (actualValue.Distance != expectedValue.Distance) return false;
                if (actualValue.Parent != expectedValue.Parent) return false;
            }

            return true;
        }

        private Dictionary<char, (int Distance, char? Parent)> GetShortestPaths2(
            Dictionary<char, List<(char ToVertex, int Weight)>> g, char sourceVertex)
        {
            var parents = new Dictionary<char, char?> {[sourceVertex] = null};
            var distances = g.Aggregate(new Dictionary<char, int>(), (acc, node) =>
            {
                acc.Add(node.Key, int.MaxValue);
                return acc;
            });
            distances[sourceVertex] = 0;

            // We need to iterate at most V-1 times
            for (int i = 0; i < g.Keys.Count - 1; i++)
            {
                foreach (KeyValuePair<char, List<(char ToVertex, int Weight)>> node in g)
                {
                    var fromVertex = node.Key;
                    var edges = node.Value;
                    foreach ((char ToVertex, int Weight) edge in edges)
                    {
                        var newWeight = distances[fromVertex] + edge.Weight;
                        var currentWeight = distances[edge.ToVertex];
                        if (newWeight < currentWeight)
                        {
                            distances[edge.ToVertex] = newWeight;
                            parents[edge.ToVertex] = fromVertex;
                        }
                    }
                }
            }

            return distances.Aggregate(new Dictionary<char, (int Distance, char? Parent)>(),
                (acc, node) =>
                {
                    acc.Add(node.Key, (node.Value, parents[node.Key]));
                    return acc;
                });
        }

        [Theory]
        [MemberData(nameof(GetSamples))]
        void TestSamplesForShortestPath(BellmanFordPaths expected, Graph<char> graph)
        {
            var actual = GetShortestPaths(graph, graph.Vertices.First(n => n.Key.Value == 'S').Key);

            Assert.True(expected.ShortestPaths.SequenceEqual(actual.ShortestPaths));
            Assert.True(expected.Parents.SequenceEqual(actual.Parents));
        }

        [Theory]
        [MemberData(nameof(GetNegativeCycleSamples))]
        void ThrowExceptionForGraphWithNegativeCycle(Graph<char> graph)
        {
            Assert.Throws<ArgumentException>(() =>
                GetShortestPaths(graph, graph.Vertices.First(n => n.Key.Value == 'S').Key));
        }

        private BellmanFordPaths GetShortestPaths(Graph<char> graph, Node<char> source)
        {
            // Initialize shortestPaths (to infinity)
            var shortestPaths = graph.Vertices.ToDictionary(vertex => vertex.Key, vertex => int.MaxValue);
            shortestPaths[source] = 0;
            // & parents (source to itself)
            var parents = new Dictionary<Node<char>, Node<char>>();

            // Relax paths and set parents (for |v| - 1 times)
            for (int i = 1; i < graph.Vertices.Count; i++)
            {
                foreach (var vertex in graph.Vertices)
                {
                    var fromNode = vertex.Key;
                    foreach (var edge in vertex.Value)
                    {
                        var toNode = edge.Node;
                        if (shortestPaths[fromNode] == int.MaxValue) continue;

                        if (shortestPaths[fromNode] + edge.Weight < shortestPaths[toNode])
                        {
                            shortestPaths[toNode] = shortestPaths[fromNode] + edge.Weight;
                            if (!parents.ContainsKey(toNode)) parents.Add(toNode, fromNode);
                            else parents[toNode] = fromNode;
                        }
                    }
                }
            }

            // Check for negative cycles
            foreach (var vertex in graph.Vertices)
            {
                var fromNode = vertex.Key;
                foreach (var edge in vertex.Value)
                {
                    var toNode = edge.Node;
                    if (shortestPaths[fromNode] == int.MaxValue) continue;

                    if (shortestPaths[fromNode] + edge.Weight < shortestPaths[toNode])
                    {
                        throw new ArgumentException("Negative Cycle Detected");
                    }
                }
            }

            return new BellmanFordPaths {Parents = parents, ShortestPaths = shortestPaths};
        }

        class BellmanFordPaths
        {
            public Dictionary<Node<char>, int> ShortestPaths { get; set; }
            public Dictionary<Node<char>, Node<char>> Parents { get; set; }
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
            g1.AddVertex(s, new[] {new Edge<char>(10, a), new Edge<char>(8, e)});
            g1.AddVertex(a, new[] {new Edge<char>(2, c)});
            g1.AddVertex(b, new[] {new Edge<char>(1, a)});
            g1.AddVertex(c, new[] {new Edge<char>(-2, b)});
            g1.AddVertex(d, new[] {new Edge<char>(-1, c), new Edge<char>(-4, a)});
            g1.AddVertex(e, new[] {new Edge<char>(1, d)});

            yield return new object[]
            {
                new BellmanFordPaths
                {
                    ShortestPaths = new Dictionary<Node<char>, int>
                    {
                        {new Node<char>('S'), 0}, {new Node<char>('A'), 5}, {new Node<char>('B'), 5},
                        {new Node<char>('C'), 7}, {new Node<char>('D'), 9}, {new Node<char>('E'), 8},
                    },
                    Parents = new Dictionary<Node<char>, Node<char>>
                    {
                        {a, d}, {e, s}, {c, a}, {b, c}, {d, e}
                    }
                },
                g1
            };
        }

        public static IEnumerable<object[]> GetNegativeCycleSamples()
        {
            var s = new Node<char>('S');
            var a = new Node<char>('A');
            var b = new Node<char>('B');
            var c = new Node<char>('C');

            var g1 = new Graph<char>();
            g1.AddVertex(s, new[] {new Edge<char>(1, a)});
            g1.AddVertex(a, new[] {new Edge<char>(3, b)});
            g1.AddVertex(b, new[] {new Edge<char>(1, c)});
            g1.AddVertex(c, new[] {new Edge<char>(-6, a)});

            // Empty object since we are checking for a negative cycle, which throws an exception.
            yield return new object[] {g1};
        }
    }
}