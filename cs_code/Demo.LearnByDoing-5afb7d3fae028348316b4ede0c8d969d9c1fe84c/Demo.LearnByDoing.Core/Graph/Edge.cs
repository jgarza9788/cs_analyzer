namespace Demo.LearnByDoing.Core.Graph
{
	public class Edge<T>
	{
		public Vertex<T> Vertex1 { get; }
		public Vertex<T> Vertex2 { get; }
		public int Weight { get; }
		public bool IsDirected { get; }

		public Edge(Vertex<T> vertex1, Vertex<T> vertex2)
			:this(vertex1, vertex2, false, 0)
		{
		}

		public Edge(Vertex<T> vertex1, Vertex<T> vertex2, bool isDirected)
			: this(vertex1, vertex2, isDirected, 0)
		{
		}

		public Edge(Vertex<T> vertex11, Vertex<T> vertex21, bool isDirectred, int weight)
		{
			Vertex1 = vertex11;
			Vertex2 = vertex21;
			IsDirected = isDirectred;
			Weight = weight;
		}

		public override int GetHashCode()
		{
			const int prime = 31;
			int result = 1;
			result = prime * result + (Vertex1 == null ? 0 : Vertex1.GetHashCode());
			result = prime * result + (Vertex2 == null ? 0 : Vertex2.GetHashCode());
			return result;
		}

		public override bool Equals(object obj)
		{
			if (this == obj) return true;
			if (obj == null) return false;
			if (GetType() != obj.GetType()) return false;

			Edge<T> other = obj as Edge<T>;
			if (Vertex1 == null)
			{
				if (other?.Vertex1 != null)
					return false;
			}
			else if (!Vertex1.Equals(other?.Vertex1))
				return false;

			if (Vertex2 == null)
			{
				if (other?.Vertex2 != null)
					return false;
			}
			else if (!Vertex2.Equals(other?.Vertex2))
				return false;

			return true;
		}

		public override string ToString()
		{
			return $"Edge [isDirected={IsDirected}, vertex1={Vertex1}, vertex2={Vertex2}, weight={Weight}]";
		}
	}
}