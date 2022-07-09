using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Demo.LearnByDoing.Tests.DataStructure.Tree;

namespace Demo.LearnByDoing.Tests.Algorithms
{
    /// <summary>
    /// "Prim's Algorithm Minimum Spanning Tree Graph Algorithm" by Tushar Roy
    /// video: https://youtu.be/oP2-8ysT3QQ
    /// source: https://github.com/mission-peace/interview/blob/master/src/com/interview/graph/PrimMST.java
    /// 
    /// NOT YET IMPLEMENTED.
    /// Need to implment a MinHeap data structure first.
    /// </summary>
    public class PrimsAlgorithmTest
    {
        [Fact]
        public void TestPrims()
        {
            var g = new Dictionary<char, List<Edge>>
            {
                {
                    'a', new List<Edge>
                    {
                        new Edge('a', 'd', 1),
                        new Edge('a', 'b', 3),
                    }
                },
                {
                    'b', new List<Edge>
                    {
                        new Edge('b', 'a', 3),
                        new Edge('b', 'c', 1),
                        new Edge('b', 'd', 3),
                    }
                },
                {
                    'c', new List<Edge>
                    {
                        new Edge('c', 'b', 1),
                        new Edge('c', 'd', 1),
                        new Edge('c', 'e', 5),
                        new Edge('c', 'f', 4),
                    }
                },
                {
                    'd', new List<Edge>
                    {
                        new Edge('d', 'a', 3),
                        new Edge('d', 'b', 3),
                        new Edge('d', 'c', 1),
                        new Edge('d', 'e', 6),
                    }
                },
                {
                    'e', new List<Edge>
                    {
                        new Edge('e', 'd', 6),
                        new Edge('e', 'c', 5),
                        new Edge('e', 'f', 2),
                    }
                },
                {
                    'f', new List<Edge>
                    {
                        new Edge('f', 'c', 4),
                        new Edge('f', 'e', 2),
                    }
                },
            };

//            var actual = GetMinimumSpanningTreeEdgesBad(g);
//            Console.WriteLine(actual);

            var expected = new[]
            {
                new Edge('a', 'd', 1),
                new Edge('c', 'b', 1),
                new Edge('d', 'c', 1),
                new Edge('f', 'e', 2),
                new Edge('c', 'f', 4),
            };

            var actual2 = GetMinimumSpanningTreeEdges2(g);
            Assert.True(expected.SequenceEqual(actual2));

            var actual3 = GetMinimumSpanningTreeEdges3(g);
            Assert.True(expected.SequenceEqual(actual3));
        }

        private IEnumerable<Edge> GetMinimumSpanningTreeEdges3(Dictionary<char,List<Edge>> g)
        {
            var vertexToEdge = new Dictionary<char, Edge>();
            var minHeap = new Dictionary<char, int>();
            var sourceVertex = g.First().Key;
            
            // Populate minHeap
            foreach (var vertex in g.Keys)
            {
                minHeap.Add(vertex, int.MaxValue);
            }

            minHeap[sourceVertex] = 0;
            
            // While the heap has value,
            //    Get the minimum vertex
            //    Get adjacent edges
            //    for each edge
            //        if the edge weight is less than what's in the heap,
            //            replace the heap weight to the new weight
            //            add/replace the edge's vertex parents to the edge

            while (minHeap.Count > 0)
            {
                var fromVertex = ExtractMinimumVertex2(minHeap);
                var edges = g[fromVertex];
                
                foreach (Edge edge in edges)
                {
                    var toVertex = edge.V2;
                    if (!minHeap.ContainsKey(toVertex)) continue;
                    
                    if (edge.Weight < minHeap[toVertex])
                    {
                        minHeap[toVertex] = edge.Weight;
                        if (vertexToEdge.ContainsKey(toVertex)) vertexToEdge[toVertex] = edge;
                        else vertexToEdge.Add(toVertex, edge);
                    }
                }

                minHeap.Remove(fromVertex);
            }
            

            return vertexToEdge.Values;
        }

        private char ExtractMinimumVertex2(Dictionary<char,int> minHeap)
        {
            if (minHeap == null || minHeap.Count <= 0) throw new ArgumentOutOfRangeException();
            
            int minWeight = minHeap.First().Value;
            char vertex = minHeap.First().Key;

            foreach (KeyValuePair<char,int> pair in minHeap.Skip(1))
            {
                if (pair.Value < minWeight)
                {
                    minWeight = pair.Value;
                    vertex = pair.Key;
                }
            }

            return vertex;
        }

        private IEnumerable<Edge> GetMinimumSpanningTreeEdges2(Dictionary<char, List<Edge>> g)
        {
            // emulate Binary MinHeap
            var ve = new Dictionary<char, Edge>();
            var hm = BuildBinaryMinHeap(g);

            while (hm.Count > 0)
            {
                var fromVertex = ExtractMinimumVertex(hm);
                var edges = g[fromVertex];

                foreach (Edge edge in edges)
                {
                    var toVertex = edge.V2;
                    if (!hm.ContainsKey(toVertex)) continue;

                    var newWeight = edge.Weight;
                    if (newWeight < hm[toVertex])
                    {
                        hm[toVertex] = newWeight;
                        if (ve.ContainsKey(toVertex)) ve[toVertex] = edge;
                        else ve.Add(toVertex, edge);
                    }
                }

                hm.Remove(fromVertex);
            }

            return ve.Values;
        }

        private char ExtractMinimumVertex(Dictionary<char, int> minHeapMap)
        {
            var minValue = minHeapMap.Min(_ => _.Value);
            var minimumNode = minHeapMap.First(_ => _.Value == minValue);
            return minimumNode.Key;
        }

        private Dictionary<char, int> BuildBinaryMinHeap(Dictionary<char, List<Edge>> g)
        {
            var sourceVertex = g.First().Key;
            var result = g.Keys.Aggregate(new Dictionary<char, int>(), (acc, key) =>
            {
                acc.Add(key, int.MaxValue);
                return acc;
            });
            result[sourceVertex] = 0;
            return result;
        }

        private IEnumerable<Edge> GetMinimumSpanningTreeEdgesBad(Dictionary<char, List<Edge>> g)
        {
            var h = new BinaryMinHeap<char>();
            var vte = new Dictionary<char, Edge>();
            // Fill Heap
            var isFirst = true;
            foreach (char key in g.Keys)
            {
                if (isFirst)
                {
                    h.Add(new BinaryMinHeap<char>.Node {Id = key, Weight = 0});
                    isFirst = false;
                }
                else h.Add(new BinaryMinHeap<char>.Node {Id = key, Weight = int.MaxValue});
            }

            var result = new List<Edge>();

            while (h.HasItem())
            {
                var v = h.ExtractMinimum();
                vte.TryGetValue(v.Id, out Edge ste);
                if (ste != null) result.Add(ste);

                foreach (Edge e in g[v.Id])
                {
                    char adj = e.V2;
                    if (!h.Contains(adj)) continue;

                    var node = h.GetNode(adj);
                    if (node.Weight > e.Weight)
                    {
                        node.Weight = e.Weight;
                        h.Decrease(node);

                        if (!vte.ContainsKey(node.Id)) vte.Add(node.Id, e);
                        vte[node.Id] = e;
                    }
                }
            }

            return result;
        }
    }

    internal class Edge
    {
        public char V1 { get; set; }
        public char V2 { get; set; }
        public int Weight { get; set; }

        public Edge(char v1, char v2, int weight)
        {
            V1 = v1;
            V2 = v2;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{V1}:{Weight}:{V2}";
        }

        public override bool Equals(object obj)
        {
            var toEdge = obj as Edge;
            return this.V1 == toEdge.V1 && this.V2 == toEdge.V2 && this.Weight == toEdge.Weight;
        }
    }
}