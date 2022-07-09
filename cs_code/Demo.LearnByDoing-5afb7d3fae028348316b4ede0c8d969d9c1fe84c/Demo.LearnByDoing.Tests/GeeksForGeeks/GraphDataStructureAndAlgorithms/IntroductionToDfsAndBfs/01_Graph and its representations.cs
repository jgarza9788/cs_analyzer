using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.GeeksForGeeks.GraphDataStructureAndAlgorithms.IntroductionToDfsAndBfs
{
	/// <summary>
	/// https://www.geeksforgeeks.org/graph-and-its-representations/
	/// </summary>
	public class _01_Graph_and_its_representations : BaseTest
	{
		public _01_Graph_and_its_representations(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void PrintGraph()
		{
			var graph = new UndirectedGraph(5);
			graph.AddEdge(0, 1);
			graph.AddEdge(0, 4);
			graph.AddEdge(1, 2);
			graph.AddEdge(1, 3);
			graph.AddEdge(1, 4);
			graph.AddEdge(2, 3);
			graph.AddEdge(3, 4);

			graph.PrintGraph();
		}
	}

	public class UndirectedGraph
	{
		public int VertexCount { get; set; }
		public LinkedList<int>[] AdjacentLists { get; set; }

		public UndirectedGraph(int vertexCount)
		{
			VertexCount = vertexCount;
			SetupAdjacentLists(vertexCount);
		}

		private void SetupAdjacentLists(int vertexCount)
		{
			AdjacentLists = new LinkedList<int>[vertexCount];
			for (int i = 0; i < vertexCount; i++)
			{
				AdjacentLists[i] = new LinkedList<int>();
			}
		}

		public void AddEdge(int fromVetex, int toVertex)
		{
			AdjacentLists[fromVetex].AddFirst(toVertex);
			AdjacentLists[toVertex].AddFirst(fromVetex);
		}

		public void PrintGraph()
		{
			for (int fromVertex = 0; fromVertex < VertexCount; fromVertex++)
			{
				Console.WriteLine("Adjancency list of vertext " + fromVertex);
				Console.Write("head");
				foreach (int toVertex in AdjacentLists[fromVertex])
				{
					Console.Write($" -> {toVertex}");
				}
				Console.WriteLine();
			}
		}
	}
}
