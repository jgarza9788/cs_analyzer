using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Algorithms
{
    public class DijkstraRepriseTest : BaseTest
    {
        [Fact]
        public void TestDijkstraHappyPath()
        {
            var g = new Dictionary<char, List<DijkstraEdge>>
            {
                {
                    'a', new List<DijkstraEdge>
                    {
                        new DijkstraEdge('a', 'b', 5),
                        new DijkstraEdge('a', 'd', 9),
                        new DijkstraEdge('a', 'e', 2),
                    }
                },
                {
                    'b', new List<DijkstraEdge>
                    {
                        new DijkstraEdge('b', 'a', 5),
                        new DijkstraEdge('b', 'c', 2),
                    }
                },
                {
                    'c', new List<DijkstraEdge>
                    {
                        new DijkstraEdge('c', 'b', 2),
                        new DijkstraEdge('c', 'd', 3),
                    }
                },
                {
                    'd', new List<DijkstraEdge>
                    {
                        new DijkstraEdge('d', 'a', 9),
                        new DijkstraEdge('d', 'c', 3),
                        new DijkstraEdge('d', 'f', 2),
                    }
                },
                {
                    'e', new List<DijkstraEdge>
                    {
                        new DijkstraEdge('e', 'a', 2),
                        new DijkstraEdge('e', 'f', 3),
                    }
                },
                {
                    'f', new List<DijkstraEdge>
                    {
                        new DijkstraEdge('f', 'e', 3),
                        new DijkstraEdge('f', 'd', 2),
                    }
                },
            };

            var parents = new Dictionary<char, char?>
            {
                {'a', null},
                {'b', 'a'},
                {'c', 'b'},
                {'d', 'f'},
                {'e', 'a'},
                {'f', 'e'},
            };
            var distances = new Dictionary<char, int>()
            {
                {'a', 0},
                {'b', 5},
                {'c', 7},
                {'d', 7},
                {'e', 2},
                {'f', 5},
            };
            var expected = new DijkstraResult(parents, distances);

            var actual = GetShortestPaths(g);
            Assert.True(AreSameResult(expected, actual));

            var actual2 = GetShortestPaths2ndTime(g);
            Assert.True(AreSameResult(expected.Parents, expected.Distances, actual2.Parents, actual2.Distances));

            var actual3 = GetShortestPaths3rdTime(g);
            Assert.True(AreSameResult(expected.Parents, expected.Distances, actual3.Parents, actual3.Distances));

            var actual4 = GetShortestPaths4thTime(g);
            Assert.True(AreSameResult(expected.Parents, expected.Distances, actual4.Parents, actual4.Distances));
        }

        private (Dictionary<char, char?> Parents, Dictionary<char, int> Distances) GetShortestPaths4thTime(
            Dictionary<char, List<DijkstraEdge>> g)
        {
            // Declare visited, parents & source vertex
            var visited = new HashSet<char>();
            var parents = new Dictionary<char, char?>();

            // initialize distances
            var distances = g.Keys.Aggregate(new Dictionary<char, int>(), (acc, v) =>
            {
                acc.Add(v, int.MaxValue);
                return acc;
            });

            // Set the first vertex distance to 0
            var sourceVertex = g.Keys.First();
            distances[sourceVertex] = 0;
            parents.Add(sourceVertex, null);

            // While not all vertices are visited,
            //     greedily update the distances

            while (distances.Count > visited.Count)
            {
                var (fromVertex, currentWeight) = GetMinimumNode(distances, visited);
                distances[fromVertex] = currentWeight;
                if (visited.Contains(fromVertex)) continue;
                if (!g.ContainsKey(fromVertex)) continue;

                var edges = g[fromVertex];
                foreach (var edge in edges)
                {
                    var toVertex = edge.V2;
                    var newWeight = currentWeight + edge.Weight;

                    // We found the shorter path, so update the distance to the shorter newWeight
                    if (newWeight < distances[toVertex])
                    {
                        distances[toVertex] = newWeight;
                        // Update parents
                        if (parents.ContainsKey(toVertex)) parents[toVertex] = fromVertex;
                        else parents.Add(toVertex, fromVertex);
                    }
                }

                visited.Add(fromVertex);
            }

            return (parents, distances);
        }

        private (Dictionary<char, char?> Parents, Dictionary<char, int> Distances) GetShortestPaths3rdTime(
            Dictionary<char, List<DijkstraEdge>> g)
        {
            var parents = new Dictionary<char, char?>();
            var distances = new Dictionary<char, int>();
            var visited = new HashSet<char>();

            // Fill distances
            var sourceVertex = g.First().Key;
            foreach (var v in g.Keys)
            {
                distances.Add(v, int.MaxValue);
            }

            // We need a starting point
            distances[sourceVertex] = 0;
            parents.Add(sourceVertex, null);

            while (distances.Count > visited.Count)
            {
                var node = GetMinimumNode(distances, visited);
                distances[node.Key] = node.Weight;
                if (visited.Contains(node.Key)) continue;
                var neighbors = g[node.Key];

                foreach (DijkstraEdge neighbor in neighbors)
                {
                    var newWeight = neighbor.Weight + node.Weight;
                    if (newWeight < distances[neighbor.V2])
                    {
                        distances[neighbor.V2] = newWeight;
                        if (parents.ContainsKey(neighbor.V2)) parents[neighbor.V2] = node.Key;
                        else parents.Add(neighbor.V2, node.Key);
                    }
                }

                visited.Add(node.Key);
            }

            return (parents, distances);
        }

        private (char Key, int Weight) GetMinimumNode(Dictionary<char, int> distances, HashSet<char> visited)
        {
            char minKey = ' ';
            int minWeight = int.MaxValue;

            foreach (KeyValuePair<char, int> node in distances)
            {
                if (visited.Contains(node.Key)) continue;
                if (node.Value < minWeight) (minKey, minWeight) = (node.Key, node.Value);
            }

            return (minKey, minWeight);
        }

        public DijkstraRepriseTest(ITestOutputHelper output) : base(output)
        {
        }

        private (Dictionary<char, char?> Parents, Dictionary<char, int> Distances)
            GetShortestPaths2ndTime(Dictionary<char, List<DijkstraEdge>> g)
        {
            var parents = new Dictionary<char, char?>();
            var distances = new Dictionary<char, int>();
            var toProcess = new Dictionary<char, int>();

            // Fill distances & processed
            var isFirst = true;
            char? sourceVertexKey = null;
            foreach (char key in g.Keys)
            {
                if (isFirst)
                {
                    sourceVertexKey = key;
                    distances.Add(key, 0);
                    toProcess.Add(key, 0);
                    isFirst = false;
                }
                else
                {
                    distances.Add(key, int.MaxValue);
                    toProcess.Add(key, int.MaxValue);
                }
            }

            // Greedily find the shortest paths from the source vertex to the rest.
            if (!sourceVertexKey.HasValue) throw new ArgumentNullException();
            var sourceVetex = sourceVertexKey.Value;
            parents.Add(sourceVetex, null);

            while (toProcess.Count > 0)
            {
                var v = PeekMinimumVertex(toProcess);
                distances[v.Key] = v.Weight;
                if (!toProcess.ContainsKey(v.Key)) continue;

                foreach (var adjV in g[v.Key])
                {
                    var newW = v.Weight + adjV.Weight;
                    if (newW < distances[adjV.V2])
                    {
                        distances[adjV.V2] = newW;
                        toProcess[adjV.V2] = newW;
                        if (!parents.ContainsKey(adjV.V2)) parents.Add(adjV.V2, v.Key);
                        else parents[adjV.V2] = v.Key;
                    }
                }

                toProcess.Remove(v.Key);
            }

            return (parents, distances);
        }

        private bool AreSameResult(
            Dictionary<char, char?> expectedParents,
            Dictionary<char, int> expectedDistances,
            Dictionary<char, char?> actualParents,
            Dictionary<char, int> actualDistances)
        {
            return AreSameResult(
                expected: new DijkstraResult(expectedParents, expectedDistances),
                actual: new DijkstraResult(actualParents, actualDistances)
            );
        }


        private bool AreSameResult(DijkstraResult expected, DijkstraResult actual)
        {
            // Edge cases
            if (expected.Parents.Count != actual.Parents.Count) return false;
            if (expected.Distances.Count != actual.Distances.Count) return false;

            // Compare parents
            if (expected.Parents.Any(expectedParent =>
                expectedParent.Value != actual.Parents[expectedParent.Key]))
                return false;

            // Compare distances
            if (expected.Distances.Any(expectedDistance =>
                expectedDistance.Value != actual.Distances[expectedDistance.Key])) return false;

            return true;
        }

        private DijkstraResult GetShortestPaths(Dictionary<char, List<DijkstraEdge>> g)
        {
            var parents = new Dictionary<char, char?>();
            // Binary MinHeap is not yet implemented, it was buggy so...
            // for now use a simple HashSet for slow `min` check.
            var distances = FillMinHeap(g.Keys);
            var processed = FillMinHeap(g.Keys);
            var sourceVertex = PeekMinimumVertex(distances);
            // Starting point doesn't have a parent
            parents.Add(sourceVertex.Key, null);

            // Find shortest paths
            while (processed.Count > 0)
            {
                var vertex = ExtractMinimumVertex(processed);
//                var vertex = PeekMinimumVertex(distances);
                distances[vertex.Key] = vertex.Weight;
                var edges = g[vertex.Key];

                foreach (DijkstraEdge edge in edges)
                {
                    // We already processed it.
                    var adjacentVertex = edge.V2;
                    if (!processed.ContainsKey(adjacentVertex)) continue;

                    var newWeight = vertex.Weight + edge.Weight;
                    if (newWeight < distances[adjacentVertex])
                    {
                        processed[adjacentVertex] = newWeight;
                        distances[adjacentVertex] = newWeight;
                        if (parents.ContainsKey(adjacentVertex))
                            parents[adjacentVertex] = vertex.Key;
                        else parents.Add(adjacentVertex, vertex.Key);
                    }
                }

                processed.Remove(vertex.Key);
            }

            return new DijkstraResult(parents, distances);
        }

        /// <summary>
        /// If this had been a Binary MinHeap, it will be O(log n) but this one's O(n)...
        /// </summary>
        private (char Key, int Weight) PeekMinimumVertex(Dictionary<char, int> minHeap)
        {
            var min = minHeap.Values.Min();
            var minVertex = minHeap.First(item => item.Value == min);
            return (minVertex.Key, minVertex.Value);
        }

        /// <summary>
        /// If this had been a Binary MinHeap, it will be O(log n) but this one's O(n)...
        /// </summary>
        private (char Key, int Weight) ExtractMinimumVertex(Dictionary<char, int> minHeap)
        {
            var min = minHeap.Values.Min();
            var minVertex = minHeap.First(item => item.Value == min);
            minHeap.Remove(minVertex.Key);
            return (minVertex.Key, minVertex.Value);
        }

        private Dictionary<char, int> FillMinHeap(IEnumerable<char> keys)
        {
            var minHeap = new Dictionary<char, int>();
            bool isFirst = true;

            foreach (var key in keys)
            {
                if (isFirst)
                {
                    minHeap.Add(key, 0);
                    isFirst = false;
                }
                else
                {
                    minHeap.Add(key, int.MaxValue);
                }
            }

            return minHeap;
        }
    }

    internal class DijkstraResult
    {
        public Dictionary<char, char?> Parents { get; } = new Dictionary<char, char?>();
        public Dictionary<char, int> Distances { get; } = new Dictionary<char, int>();

        public DijkstraResult(Dictionary<char, char?> parents, Dictionary<char, int> distances)
        {
            Parents = parents;
            Distances = distances;
        }
    }

    internal class DijkstraEdge
    {
        public char V1 { get; set; }
        public char V2 { get; set; }
        public int Weight { get; set; }

        public DijkstraEdge(char v1, char v2, int weight)
        {
            V1 = v1;
            V2 = v2;
            Weight = weight;
        }
    }
}