namespace Demo.LearnByDoing.General.Algorithms.Graph
{
	public class Edge<T>
	{
		public int Weight { get; set; }
		public Node<T> Node { get; set; }

		public Edge(int weight, Node<T> node)
		{
			Weight = weight;
			Node = node;
		}

		public override string ToString()
		{
			return $"Node Value: {Node}, Weight: {Weight}";
		}
	}
}