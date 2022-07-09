using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.Tests.MissionInterview
{
	public class DoublySungLinkedList<T>
	{
		public DoublySungNode<T> Head { get; set; }

		public IEnumerable<DoublySungNode<T>> Traverse(Func<DoublySungNode<T>, DoublySungNode<T>, bool> callback = null)
		{
			var current = Head;
			DoublySungNode<T> last = null;

			while (current != null)
			{
				var callbackResult = callback != null && callback(current, last);
				if (callbackResult) break;

				yield return current;

				last = current;
				current = current.Next;
			}
		}

		public DoublySungNode<T> Append(T value)
		{
			var newNode = new DoublySungNode<T>(value);

			if (Head == null)
			{
				Head = newNode;
			}
			else
			{
				var lastNode = Traverse().LastOrDefault();
				lastNode.Next = newNode;
				newNode.Previous = lastNode;
			}

			return newNode;
		}

		public DoublySungNode<T> InsertAt(DoublySungNode<T> node, T value)
		{
			var newNode = new DoublySungNode<T>(value)
			{
				Next = node.Next,
				Previous = node
			};

			if (node.Next != null) node.Next.Previous = newNode;
			node.Next = newNode;

			return newNode;
		}

		public void Remove(DoublySungNode<T> node)
		{
			if (Head.Equals(node))
			{
				Head = Head.Next;
			}
			else
			{
				if (node.Previous != null)
				{
					node.Previous.Next = node.Next;
				}

				if (node.Next != null)
				{
					node.Next.Previous = node.Previous;
				}
			}
		}
	}
}