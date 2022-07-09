using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.Tests.MissionInterview
{
	public class SungLinkedList<T>
	{
		public SungNode<T> Head { get; set; }

		public IEnumerable<SungNode<T>> Traverse(Func<SungNode<T>, SungNode<T>, bool> callback = null)
		{
			var current = Head;
			SungNode<T> last = null;

			while (current != null)
			{
				var callbackResult = callback != null && callback(current, last);
				if (callbackResult) break;

				yield return current;

				last = current;
				current = current.Next;
			}
		}

		public SungNode<T> Append(T value)
		{
			var newNode = new SungNode<T>(value);

			if (Head == null)
			{
				Head = newNode;
			}
			else
			{
				var lastNode = Traverse().LastOrDefault();
				lastNode.Next = newNode;
			}

			return newNode;
		}

		public SungNode<T> InsertAt(SungNode<T> node, T value)
		{
			var newNode = new SungNode<T>(value) { Next = node.Next };
			node.Next = newNode;
			return newNode;
		}

		public void Remove(SungNode<T> node)
		{
			if (Head.Equals(node))
			{
				Head = Head.Next;
			}
			else
			{
				Traverse((currentNode, lastNode) =>
					{
						if (currentNode.Equals(node))
						{
							// Move the last node to point to current's next node.
							// Basically we are removing "current" here.
							lastNode.Next = currentNode.Next;

							// stop the iteration, we are done removing.
							return true;
						}

						// we are NOT don't yet. Move to next iteration.
						return false;
					})
					// force enumeration
					.ToList();
			}
		}
	}
}