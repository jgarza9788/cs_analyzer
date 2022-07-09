using System;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/kth-to-last-node-in-singly-linked-list
	/// 
	///   You have a linked list ↴ and want to find the kkkth to last node.
	/// 
	/// Write a method KthToLastNode() that takes an integer kkk and the headNode of a singly-linked list, and returns the kkkth to last node in the list.
	/// 
	/// For example:
	/// 
	/// public class LinkedListNode
	/// {
	///		public int Value { get; set; }
	///		public LinkedListNode Next { get; set; }
	/// 
	///		public LinkedListNode(int value)
	///		{
	///			this.Value = value;
	///		}
	/// }
	/// 
	/// var a = new LinkedListNode(1);
	/// var b = new LinkedListNode(2);
	/// var c = new LinkedListNode(3);
	/// var d = new LinkedListNode(4);
	/// var e = new LinkedListNode(5);
	/// 
	/// a.Next = b;
	/// b.Next = c;
	/// c.Next = d;
	/// d.Next = e;
	/// 
	/// // Returns the node with value 4 (the 2nd to last node)
	/// var node = KthToLastNode(2, a);
	/// </summary>
	public class Question025Test
	{
		[Fact]
		public void TestSampleCase()
		{
			var a = new LinkedListNode(1);
			var b = new LinkedListNode(2);
			var c = new LinkedListNode(3);
			var d = new LinkedListNode(4);
			var e = new LinkedListNode(5);

			a.Next = b;
			b.Next = c;
			c.Next = d;
			d.Next = e;

			// Returns the node with value 4 (the 2nd to last node)
			var actual = KthToLastNode(2, a).Value;
			const int expected = 4;
			Assert.Equal(expected, actual);
		}

		public LinkedListNode KthToLastNode(int kth, LinkedListNode head)
		{
			var ahead = GetAheadNode(kth, head);
			if (ahead == null)
				throw new ArgumentOutOfRangeException();

			var root = head;
			while (ahead != null)
			{
				root = root.Next;
				ahead = ahead.Next;
			}

			return root;
		}

		private LinkedListNode GetAheadNode(int kth, LinkedListNode head)
		{
			int currentPosition = 0;
			var root = head;
			while (root != null && currentPosition < kth)
			{
				root = root.Next;
				currentPosition++;
			}
			return root;
		}


		public class LinkedListNode
		{
			public int Value { get; set; }
			public LinkedListNode Next { get; set; }

			public LinkedListNode(int value)
			{
				this.Value = value;
			}
		}
	}
}
