using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter04
{
    /// <summary>
    /// ROUTE BETWEEN NODES:
    /// Given a directred graph, design an algorithm to find out 
    /// whether there is a route between two nodes.
    /// </summary>
    public class Chapter4_1Test : BaseTest
    {
        private readonly Chapter4_1 _sut = new Chapter4_1();

        public Chapter4_1Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter4Base1Data))]
        public void TestDepthFirstSearchToFindRouteBetweenTwoNodes(bool expected, Node<int> node1, Node<int> node2)
        {
            bool actual = _sut.HasRouteUsingDfs(node1, node2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(Chapter4Base1Data))]
        public void TestDepthFirstSearchToFindRouteBetweenTwoNodesOptimized(bool expected, Node<int> node1, Node<int> node2)
        {
            bool actual = _sut.HasRouteUsingDfs2(node1, node2);

            Assert.Equal(expected, actual);
        }
    }


    public class Chapter4_1
    {
        /// <summary>
        /// Optimized solution for finding a route between two nodes using Depth First Search algorithm.
        /// </summary>
        public bool HasRouteUsingDfs2(Node<int> node1, Node<int> node2)
        {
            var nodes1 = GetValuesUsingDfs(node1);
            var nodes2 = GetValuesUsingDfs(node2);

            // Enumerate multiple lists one at a time using Depth-First Search
            // http://stackoverflow.com/a/18396163/4035
            using (var n1 = nodes1.GetEnumerator())
            using (var n2 = nodes2.GetEnumerator())
            {
                while (n1.MoveNext() && n2.MoveNext())
                {
                    var nodeValue1 = n1.Current;
                    var nodeValue2 = n2.Current;

                    if (nodeValue1 == nodeValue2) return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Find if a route between two nodes in the specified graph using DFS (Depth First Search) algorithm.
        /// </summary>
        /// <param name="graph">Graph containing all nodes</param>
        /// <param name="node1">"From" node</param>
        /// <param name="node2">"To" node</param>
        /// <returns>True if route exists, false, otherwise</returns>
        public bool HasRouteUsingDfs<T>(Node<T> node1, Node<T> node2)
        {
            var nodeValues1 = GetValuesUsingDfs(node1).ToList();
            var nodeValues2 = GetValuesUsingDfs(node2).ToList();

            return nodeValues1.Contains(node2.Name) && nodeValues2.Contains(node1.Name);
        }

        /// <summary>
        /// Get all available values for the given node.
        /// </summary>
        /// <remarks>
        /// Iterative implementation of Depth First Search
        /// <see cref="https://en.wikipedia.org/wiki/Depth-first_search#Pseudocode"/>
        /// </remarks>
        private IEnumerable<T> GetValuesUsingDfs<T>(Node<T> node)
        {
            var stack = new Stack<Node<T>>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                var v = stack.Pop();
                if (!v.IsVisited)
                {
                    v.IsVisited = true;
                    yield return v.Name;

                    foreach (Node<T> child in v.Children)
                    {
                        stack.Push(child);
                    }
                }
            }
        }
    }

    public class Chapter4Base1Data : Chapter4BaseTestData
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            //// Node 1 and Node 4 -> No route between them.
            //new object[] { false, GetGraph(), GetGraph().Nodes.First(), GetGraph().Nodes.Last() },
            //// Node 1 and Node 3 -> Has a route between them.
            //new object[] { true, GetGraph(), GetGraph().Nodes.First(), GetGraph().Nodes.Skip(2).First() },

            // There is a route between first node and the 5th node
            new object[] {true, GetGraph2().Nodes.First(), GetGraph2().Nodes[GetGraph2().Nodes.Count - 2]},
            // There is NO route between first node and the 6th node
            new object[] {false, GetGraph2().Nodes.First(), GetGraph2().Nodes.Last()},
            new object[] {false, GetGraph2().Nodes[2], GetGraph2().Nodes.Last()},
            new object[] {false, GetGraph2().Nodes[3], GetGraph2().Nodes.Last()},
        };

        private static Graph<int> GetGraph2()
        {
            var graph = new Graph<int>();
            var n1 = new Node<int>(1);
            var n2 = new Node<int>(2);
            var n3 = new Node<int>(3);
            var n4 = new Node<int>(4);
            var n5 = new Node<int>(5);
            var n6 = new Node<int>(6);

            graph.Nodes.AddRange(new[] {n1, n2, n3, n4, n5, n6});

            n1.Children.Add(n2);
            n2.Children.AddRange(new [] {n4, n5});
            n3.Children.AddRange(new [] {n1});
            n4.Children.AddRange(new [] {n5, n6});
            n5.Children.AddRange(new [] {n3, n6});
            // none for n6

            return graph;
        }

        /// <summary>
        /// 1 : 2
        /// 2 : 3
        /// 3 : 
        /// 4 : 2
        /// </summary>
        private static Graph<int> GetGraph()
        {
            var graph = new Graph<int>();
            
            var n1 = new Node<int>(1);
            var n2 = new Node<int>(2);
            var n3 = new Node<int>(3);
            var n4 = new Node<int>(4);

            graph.Nodes.Add(n1);
            graph.Nodes.Add(n2);
            graph.Nodes.Add(n3);
            graph.Nodes.Add(n4);

            n1.Children.Add(n2);
            n2.Children.Add(n3);
            n4.Children.Add(n2);

            return graph;
        }
    }
}
