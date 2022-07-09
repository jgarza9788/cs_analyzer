using System.Collections.Generic;

namespace Demo.LearnByDoing.General.Algorithms.Graph
{
	public class Node<T>
	{
		public T Value { get; set; }

		public Node(T value)
		{
			Value = value;
		}

		public override bool Equals(object obj)
		{
			var that = obj as Node<T>;
			return Value.Equals(that.Value);
		}

		protected bool Equals(Node<T> other)
		{
			return EqualityComparer<T>.Default.Equals(Value, other.Value);
		}

		public override int GetHashCode()
		{
			return EqualityComparer<T>.Default.GetHashCode(Value);
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}