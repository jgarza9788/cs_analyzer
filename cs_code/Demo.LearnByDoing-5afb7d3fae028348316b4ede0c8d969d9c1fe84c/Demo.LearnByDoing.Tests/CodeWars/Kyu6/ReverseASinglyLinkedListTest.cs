using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/reverse-a-singly-linked-list/train/csharp
	/// </summary>
	[TestFixture]
	public class ReverseASinglyLinkedListTest
	{
		[Test]
		public void SampleTest()
		{
			Assert.AreEqual(new Node(3, new Node(2, new Node(1, null))), Kata.ReverseList(new Node(1, new Node(2, new Node(3, null)))));

			// For simplicity, Node can also be constructed using any non-empty IEnumerable<int>:
			Assert.AreEqual(new Node(new int[] { 5, 4, 3, 2, 1 }), Kata.ReverseList(new Node(new int[] { 1, 2, 3, 4, 5 })));
		}

		public class Kata
		{
			//public static Node ReverseList(Node node)
			//{
			//	if (node == null) return null;

			//	Stack<Node> result = new Stack<Node>();
			//	while (node != null)
			//	{
			//		result.Push(node);
			//		node = node.Next;
			//	}

			//	return new Node(result.Select(n => n.Value).ToArray());
			//}

			private static Node head = null;
			public static Node ReverseList(Node node)
			{
				Console.WriteLine(ToString(node));
				if (node == null) return head;
				Reverse(node);
				return head;
			}

			private static Node Reverse(Node node)
			{
				if (node.Next == null)
				{
					head = node;
					return node;
				}

				var newNode = Reverse(node.Next);
				node.Next = null;
				newNode.Next = node;
				return node;
			}

			private static string ToString(Node n)
			{
				var result = "";
				while (n != null)
				{
					result += $"{n.Value}=>";
					n = n.Next;
				}

				return result + "null";
			}
		}

		public class Node
		{
			public int Value { get; set; }
			public Node Next { get; set; }

			public Node(int v, Node node)
			{
				Value = v;
				Next = node;
			}

			public Node(int[] values)
			{
				BuildNode(this, values);
			}

			private void BuildNode(Node root, int[] values)
			{
				var head = root;
				foreach (var value in values)
				{
					var node = new Node(value, null);
					head.Next = node;
					head = head.Next;
				}
			}

			//public static bool operator ==(Node n1, Node n2)
			//{
			//	return n1.Equals(n2);
			//}

			//public static bool operator !=(Node n1, Node n2)
			//{
			//	return !(n1 == n2);
			//}

			//public override bool Equals(object obj)
			//{
			//	var that = this;
			//	var other = obj as Node;
			//	while (that.Next != null)
			//	{
			//		if (that.Value != other.Value) return false;
			//		that = that.Next;
			//		other = other.Next;
			//	}

			//	return true;
			//}
		}
	}

}
