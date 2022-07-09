using System.Collections.Generic;

namespace Demo.LearnByDoing.Core.Graph
{
	public class Vertex<T>
	{
		public long Id { get; }
		public T Data { get; set; }
		public List<Edge<T>> Edges { get; } = new List<Edge<T>>();
		public List<Vertex<T>> AdjacentVertex { get; } = new List<Vertex<T>>();

		public Vertex(long id)
		{
			Id = id;
		}

		public void AddAdjacentVertex(Edge<T> e, Vertex<T> v)
		{
			Edges.Add(e);
			AdjacentVertex.Add(v);
		}

		public override string ToString()
		{
			return $"Id:{Id}, Data:'{Data}'";
		}

		public int GetDegree()
		{
			return Edges.Count;
		}

		public override int GetHashCode()
		{
			const int prime = 31;
			int result = 1;
			result = prime * result + (int)(Id ^ (Id >> 32));
			return result;
		}

		public override bool Equals(object obj)
		{
			if (this == obj) return true;
			if (obj == null) return false;
			if (GetType() != obj.GetType()) return false;

			Vertex<T> other = obj as Vertex<T>;
			if (other == null || Id != other.Id)
				return false;
			return true;
		}
	}
}