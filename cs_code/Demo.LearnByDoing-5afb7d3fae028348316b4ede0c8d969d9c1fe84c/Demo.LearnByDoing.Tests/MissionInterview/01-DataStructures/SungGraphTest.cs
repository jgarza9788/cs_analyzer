using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.MissionInterview._01_DataStructures
{
	public class SungGraphTest : BaseTest
	{
		public SungGraphTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void PrintOnScreen()
		{
			SungVertex<int> root = new SungVertex<int>(0);
			Enumerable.Range(1, 10).Select(a => root.To(new SungVertex<int>(a), a));

			var vertices = root.Traverse(root);
			_output.WriteLine(vertices.ToString());
		}
	}

	public class SungVertex<T>
	{
		public T Value { get; set; }
		private List<SungEdge<T>> Edges { get; }

		public SungVertex(T value)
		{
			Value = value;
			Edges = new List<SungEdge<T>>();
		}

		public SungVertex<T> To(SungEdge<T> edge)
		{
			if (!Edges.Contains(edge))
				Edges.Add(edge);
			return this;
		}

		public SungVertex<T> To(SungVertex<T> toVertex, int cost)
		{
			return To(new SungEdge<T>(toVertex, cost));
		}

		public IEnumerable<SungEdge<T>> Traverse(SungVertex<T> vertex)
		{
			foreach (var edge in vertex.Edges)
			{
				yield return edge;
				foreach (var sungEdge in Traverse(edge.To))
				{
					yield return sungEdge;
				}
			}
		}
	}

	public class SungEdge<T>
	{
		public SungVertex<T> To { get; set; }
		public int Cost { get; set; }

		public SungEdge(SungVertex<T> to, int cost)
		{
			To = to;
			Cost = cost;
		}
	}
}
