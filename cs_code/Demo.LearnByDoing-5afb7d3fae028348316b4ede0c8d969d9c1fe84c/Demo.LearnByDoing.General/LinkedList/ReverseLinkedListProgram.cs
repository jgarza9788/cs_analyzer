using System;
using System.Linq;

namespace Demo.LearnByDoing.General.LinkedList
{
	public class ReverseLinkedListProgram
	{
		public static void Main(string[] args)
		{
			Console.WriteLine($"Iterative {BuildLinkedList()} to {ReverseIteratively(BuildLinkedList())}");
			var head = BuildLinkedList();
			Console.WriteLine($"Recursive {BuildLinkedList()} to {ReverseRecursively(head, head.Next, null)}");
		}

		private static Node<int> ReverseRecursively(Node<int> curr, Node<int> next, Node<int> prev)
		{
			curr.Next = prev;
			if (next == null) return curr;

			prev = curr;
			curr = next;
			return ReverseRecursively(curr, next.Next, prev);
		}

		private static Node<int> ReverseIteratively(Node<int> head)
		{
			Node<int> curr = head;
			Node<int> prev = null;

			do
			{
				var next = curr.Next;
				curr.Next = prev;
				prev = curr;
				if (next == null) break;
				curr = next;
			} while (true);

			return curr;
		}

		private static Node<int> BuildLinkedList()
		{
			Node<int> root = new Node<int>(1, null);
			var head = root;

			foreach (var i in Enumerable.Range(2, 9))
			{
				root.Next = new Node<int>(i, null);
				root = root.Next;
			}

			return head;
		}
	}
}
