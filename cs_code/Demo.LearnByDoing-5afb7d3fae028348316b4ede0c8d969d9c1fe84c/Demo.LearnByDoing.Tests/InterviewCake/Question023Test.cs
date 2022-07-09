using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/linked-list-cycles
	/// 
	///   You have a singly-linked list ↴ and want to check if it contains a cycle.
	/// 
	/// A singly-linked list is built with nodes, where each node has:
	/// 
	/// node.Next—the next node in the list.
	/// node.Value—the data held in the node. For example, if our linked list stores timestamps, node.Value might be the number of seconds past the Unix epoch.
	/// </summary>
	public class Question023Test
	{
		[Fact]
		public void TestForCycleInTheMiddle()
		{
			// Cycle starts @ value 3
			// 1 -> 2 -> 3 -> 4 -> 5 -> 3 -> ...
			LinkedListNode head = new LinkedListNode(1);
			var two = new LinkedListNode(2);
			var three = new LinkedListNode(3);
			var four = new LinkedListNode(4);
			var five = new LinkedListNode(5);
			head.Next = two;
			two.Next = three;
			three.Next = four;
			four.Next = five;

			Assert.False(ContainsCycle(head));
			Assert.False(ContainsCycleWithSet(head));
			Assert.False(ContainsCycleUsingAnswer(head));
			five.Next = three;
			Assert.True(ContainsCycle(head));
			Assert.True(ContainsCycleWithSet(head));
			Assert.True(ContainsCycleUsingAnswer(head));
		}

		[Fact]
		public void TestForCycleInTheBeginning()
		{
			// Cycle starts @ value 3
			// 1 -> 2 -> 3 -> 4 -> 5 -> 1 -> ...
			LinkedListNode head = new LinkedListNode(1);
			var two = new LinkedListNode(2);
			var three = new LinkedListNode(3);
			var four = new LinkedListNode(4);
			var five = new LinkedListNode(5);
			head.Next = two;
			two.Next = three;
			three.Next = four;
			four.Next = five;

			Assert.False(ContainsCycle(head));
			Assert.False(ContainsCycleWithSet(head));
			Assert.False(ContainsCycleUsingAnswer(head));
			five.Next = head;
			Assert.True(ContainsCycle(head));
			Assert.True(ContainsCycleWithSet(head));
			Assert.True(ContainsCycleUsingAnswer(head));
		}

		public bool ContainsCycleUsingAnswer(LinkedListNode head)
		{
			var root = head;
			var ahead = head;

			while (root != null && ahead.Next != null)
			{
				root = root.Next;
				ahead = ahead.Next.Next;
				if (root == ahead) return true;
			}

			return false;
		}

		public bool ContainsCycle(LinkedListNode head)
		{
			var root = head;
			var ahead = head;

			while (root != null)
			{
				root = root.Next;
				if (root.Next == null) return false;

				if (ahead.Next?.Next == null) return false;
				ahead = ahead.Next.Next;

				if (ahead.Next == root || ahead == root) return true;
			}

			return false;
		}

		public bool ContainsCycleWithSet(LinkedListNode head)
		{
			var root = head;
			// if we had visited the node, add it to the list.
			var isSeen = new HashSet<int>();

			int nodeCount = 0;
			while (!isSeen.Contains(root.Value))
			{
				isSeen.Add(root.Value);

				root = root.Next;
				nodeCount++;
				if (nodeCount == isSeen.Count && root.Next == null) return false;
			}

			return true;
		}

		public class LinkedListNode
		{
			public int Value { get; set; }
			public LinkedListNode Next { get; set; }

			public LinkedListNode(int value)
			{
				Value = value;
			}
		}
	}

}
