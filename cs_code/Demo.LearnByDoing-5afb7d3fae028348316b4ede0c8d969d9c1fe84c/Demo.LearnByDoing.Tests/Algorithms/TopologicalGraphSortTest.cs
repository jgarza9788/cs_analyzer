using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Demo.LearnByDoing.Core.Graph;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Algorithms
{
	/// <summary>
	/// Implementation using Algorithm in https://youtu.be/ddTC4Zovtbc
	/// </summary>
	public class TopologicalGraphSortTest : BaseTest
	{
		private readonly TopologicalGraphSort _sut = new TopologicalGraphSort();

		public TopologicalGraphSortTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[ClassData(typeof(TopologicalGraphSortBaseTestData))]
		public void TestTopologicalSort(Graph<string> graph, string expected)
		{
			List<Vertex<string>> sorted = _sut.GetSorted(graph);
			var actual = string.Join("", sorted.Select(vertex => vertex.Data));

			Assert.Equal(expected, actual);
		}
	}

	/// <summary>
	/// Implementation using Algorithm in https://youtu.be/ddTC4Zovtbc
	/// </summary>
	public class TopologicalGraphSort
	{
		public List<Vertex<T>> GetSorted<T>(Graph<T> graph)
		{
			Stack<Vertex<T>> stack = new Stack<Vertex<T>>();
			HashSet<Vertex<T>> visited = new HashSet<Vertex<T>>();

			// Order, which Tushar Roy used in his video.
			int[] order = {3, 2, 4, 1, 5, 6, 7};
			var vertices = graph.GetVertices();

			// Sort the vertices according to the "order".
			var zipped = vertices.Zip(order, Tuple.Create);
			List<Tuple<Vertex<T>, int>> ordered = zipped.OrderBy(tuple => tuple.Item2).ToList();

			//foreach (Vertex<T> vertex in graph.GetVertices())
			foreach (Tuple<Vertex<T>, int> vertex in ordered)
			{
				if (visited.Contains(vertex.Item1)) continue;

				SortChild(vertex.Item1, stack, visited);
			}

			return stack.ToList();
		}

		private void SortChild<T>(Vertex<T> vertex, Stack<Vertex<T>> stack, HashSet<Vertex<T>> visited)
		{
			visited.Add(vertex);

			foreach (Vertex<T> childVertex in vertex.AdjacentVertex)
			{
				if (visited.Contains(childVertex)) continue;

				SortChild<T>(childVertex, stack, visited);
			}

			stack.Push(vertex);
		}
	}

	public class TopologicalGraphSortBaseTestData : BaseTestData
	{
		public override List<object[]> Data { get; set; } = new List<object[]>
		{
			new object[] { GetGraph(), "ABECDFG"}
		};

		private static Graph<string> GetGraph()
		{
			Graph<string> graph = new Graph<string>(isDirected:true);
			var a = new Vertex<string>(1) {Data = "A"};
			var b = new Vertex<string>(2) {Data = "B"};
			var c = new Vertex<string>(3) {Data = "C"};
			var d = new Vertex<string>(4) {Data = "D"};
			var e = new Vertex<string>(5) {Data = "E"};
			var f = new Vertex<string>(6) {Data = "F"};
			var g = new Vertex<string>(7) {Data = "G"};

			graph.AddVertex(a);
			graph.AddVertex(b);
			graph.AddVertex(c);
			graph.AddVertex(d);
			graph.AddVertex(e);
			graph.AddVertex(f);
			graph.AddVertex(g);

			graph.AddEdge(1, 3);	// a -> c
			graph.AddEdge(2, 3);    // b -> c
			graph.AddEdge(2, 5);    // b -> e
			graph.AddEdge(3, 4);	// c -> d
			graph.AddEdge(4, 6);	// d -> f
			graph.AddEdge(5, 6);	// e -> f
			graph.AddEdge(6, 7);	// f -> g

			return graph;
		}
	}
}
