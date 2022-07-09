using System;
using Demo.LearnByDoing.General.Algorithms.Graph;

namespace Demo.LearnByDoing.General.Algorithms.BellmanFord
{
	public class BellmanFordProgram
	{
		public static void Main(string[] args)
		{
			Graph<char> graph = CreateSampleGraph();
			//var paths = graph.GetPathInfoUsingBellmanFordAlgorithm(new Node<char>('A'), new Node<char>('F'));
			var shortestPath = graph.GetShortestPathUsingBellmanFordAlgorithm(new Node<char>('A'), new Node<char>('F'));
			shortestPath.ForEach(c => Console.Write("{0} ", c));
			Console.WriteLine();

			shortestPath = graph.GetShortestPathUsingBellmanFordAlgorithm(new Node<char>('A'), new Node<char>('D'));
			shortestPath.ForEach(c => Console.Write("{0} ", c));
			Console.WriteLine();

			shortestPath = graph.GetShortestPathUsingBellmanFordAlgorithm(new Node<char>('B'), new Node<char>('D'));
			shortestPath.ForEach(c => Console.Write("{0} ", c));
			Console.WriteLine();
		}

		/// <summary>
		/// Create a graph based on https://youtu.be/zXfDYaahsNA
		/// </summary>
		/// <returns></returns>
		private static Graph<char> CreateSampleGraph()
		{
			Graph<char> graph = new Graph<char>();

			var a = new Node<char>('A');
			var b = new Node<char>('B');
			var c = new Node<char>('C');
			var d = new Node<char>('D');
			var e = new Node<char>('E');
			var g = new Node<char>('G');
			var f = new Node<char>('F');

			graph.AddVertex(a, new[] { new Edge<char>(5, b), new Edge<char>(10, c) });
			graph.AddVertex(b, new[] { new Edge<char>(3, e), new Edge<char>(6, d) });
			graph.AddVertex(d, new[] { new Edge<char>(6, f) });
			graph.AddVertex(e, new[] { new Edge<char>(2, c), new Edge<char>(2, d), new Edge<char>(2, g) });
			graph.AddVertex(g, new[] { new Edge<char>(2, f) });

			return graph;
		}
	}

}
