using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Algorithms
{
	/// <summary>
	/// Re-implementing Bellman-Ford algorithm after reading "The Imposter's Syndrome".
	/// </summary>
	public class BellmanFordRepriseTest : BaseTest
	{
		public BellmanFordRepriseTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestBellmanFord()
		{
			var vertices = new[] {"S", "A", "B", "C", "D", "E"};
			var graph = new[]
			{
				new BellmanFordEdge(@from: "S", to: "A", cost: 4),
				new BellmanFordEdge(@from: "S", to: "E", cost: -5),
				new BellmanFordEdge(@from: "A", to: "C", cost: 6),
				new BellmanFordEdge(@from: "B", to: "A", cost: 3),
				new BellmanFordEdge(@from: "C", to: "B", cost: -2),
				new BellmanFordEdge(@from: "D", to: "C", cost: 3),
				new BellmanFordEdge(@from: "D", to: "A", cost: 10),
				new BellmanFordEdge(@from: "E", to: "D", cost: 8),
			};

			var expected = new Dictionary<string, int>
			{
				{"S", 0 },
				{"A", 4 },
				{"B", 4 },
				{"C", 6 },
				{"D", 3 },
				{"E", -5 },
			};

			Dictionary<string, int> actual = new BellmanFordReprise().GetShortestPath(vertices, graph);
			Assert.True(expected.SequenceEqual(actual));
		}

	}

	public class BellmanFordEdge
	{
		public string From { get; set; }
		public string To { get; set; }
		public int Cost { get; set; }

		public BellmanFordEdge(string @from, string to, int cost)
		{
			From = @from;
			To = to;
			Cost = cost;
		}
	}

	public class BellmanFordReprise
	{
		public Dictionary<string, int> GetShortestPath(string[] vertices, BellmanFordEdge[] graph)
		{
			Dictionary<string, int> map = BuildVertexMap(vertices);

			foreach (string vertex in vertices)
			{
				if (!Iterate(vertices, graph, map)) break;
			}

			return map;
		}

		private bool Iterate(string[] vertices, BellmanFordEdge[] graph, Dictionary<string, int> map)
		{
			// The return value
			bool doItAgain = false;

			foreach (string fromVertex in vertices)
			{
				// get the outgoing edges for this vertex.
				// Skip records that we cannot reach: map[edge.From] != int.MaxValue
				var edges = graph.Where(edge => edge.From == fromVertex && map[edge.From] != int.MaxValue);

				// iterate over the edges and set the costs
				foreach (BellmanFordEdge edge in edges)
				{
					// calculate the cost of the outgoing edge
					int potentialCost = map[edge.From] + edge.Cost;
					// If it's less than what's in our map table for the target vertex...
					if (potentialCost < map[edge.To])
					{
						// update the map table
						map[edge.To] = potentialCost;
						// since we made an update, we will want to iterate again
						doItAgain = true;
					}
				}
			}

			return doItAgain;
		}

		private Dictionary<string, int> BuildVertexMap(string[] vertices)
		{
			if (vertices.Length == 0) return new Dictionary<string, int>();

			var firstVertex = vertices[0];
			return vertices.ToDictionary(v => v, v => v == firstVertex ? 0 : int.MaxValue);
		}
	}
}
