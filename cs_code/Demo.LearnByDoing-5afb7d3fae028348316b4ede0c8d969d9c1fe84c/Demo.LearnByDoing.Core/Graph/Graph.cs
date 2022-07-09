using System.Collections.Generic;
using System.Text;

namespace Demo.LearnByDoing.Core.Graph
{
	public class Graph<T>
	{
		public List<Edge<T>> Edges { get; }
		public Dictionary<long, Vertex<T>> Vertices { get; }
		public bool IsDirected { get; }

		public Graph(bool isDirected)
		{
			Edges = new List<Edge<T>>();
			Vertices = new Dictionary<long, Vertex<T>>();
			IsDirected = isDirected;
		}

		public void AddEdge(long id1, long id2)
		{
			AddEdge(id1, id2, 0);
		}

		//This works only for directed graph because for undirected graph we can end up
		//adding edges two times to allEdges
		public void AddVertex(Vertex<T> vertex)
		{
			if (Vertices.ContainsKey(vertex.Id)) return;

			Vertices.Add(vertex.Id, vertex);
			foreach (Edge<T> edge in vertex.Edges)
			{
				Edges.Add(edge);
			}
		}

		public Vertex<T> AddSingleVertex(long id)
		{
			if (Vertices.ContainsKey(id)) return Vertices[id];

			Vertex<T> v = new Vertex<T>(id);
			Vertices.Add(id, v);

			return v;
		}

		public void AddEdge(long id1, long id2, int weight)
		{
			Vertex<T> vertex1;
			if (Vertices.ContainsKey(id1))
			{
				vertex1 = Vertices[id1];
			}
			else
			{
				vertex1 = new Vertex<T>(id1);
				Vertices.Add(id1, vertex1);
			}

			Vertex<T> vertex2;
			if (Vertices.ContainsKey(id2))
			{
				vertex2 = Vertices[id2];
			}
			else
			{
				vertex2 = new Vertex<T>(id2);
				Vertices.Add(id2, vertex2);
			}

			Edge<T> edge = new Edge<T>(vertex1, vertex2, IsDirected, weight);
			Edges.Add(edge);
			vertex1.AddAdjacentVertex(edge, vertex2);

			if (!IsDirected)
			{
				vertex2.AddAdjacentVertex(edge, vertex1);
			}
		}

		public IEnumerable<Vertex<T>> GetVertices()
		{
			return Vertices.Values;
		}

		public void SetDataForVertex(long id, T data)
		{
			if (Vertices.ContainsKey(id))
			{
				Vertex<T> vertex = Vertices[id];
				vertex.Data = data;
			}
		}

		public override string ToString()
		{
			StringBuilder buffer = new StringBuilder();

			foreach (Edge<T> edge in Edges)
			{
				buffer.AppendLine($"{edge.Vertex1} {edge.Vertex2} {edge.Weight}");
			}

			return buffer.ToString();
		}
	}
}
