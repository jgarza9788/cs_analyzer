using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.General.Algorithms.Graph;

namespace Demo.LearnByDoing.General.Algorithms.AStar
{
	/// <summary>
	/// Demo program for implementing A* algorithm.
	/// </summary>
	public class AStarProgram
	{
		public static void Main(string[] args)
		{
			
		}

		/// <summary>
		/// Create a graph based on https://youtu.be/sAoBeujec74
		/// </summary>
		private static Graph<char> CreateSampleGraph()
		{
			Graph<char> graph = new Graph<char>();

			var s = new Node<char>('S');
			var a = new Node<char>('A');
			var b = new Node<char>('B');
			var c = new Node<char>('C');
			var g = new Node<char>('G');

			graph.AddVertex(s, new[] { new Edge<char>(1, a), new Edge<char>(4, b) });
			graph.AddVertex(a, new[] { new Edge<char>(2, b), new Edge<char>(5, c), new Edge<char>(12, g) });
			graph.AddVertex(b, new[] { new Edge<char>(2, c) });
			graph.AddVertex(c, new[] { new Edge<char>(3, g) });

			return graph;
		}

	}
}
