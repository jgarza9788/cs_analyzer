using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/delete-node
	/// 
	/// Delete a node from a singly-linked list, ↴ given only a variable pointing to that node.
	/// </summary>
	public class Question022Test
	{
		[Fact]
		public void TestSampleCase()
		{
			var a = new LinkedListNode(1);
			var b = new LinkedListNode(2);
			var c = new LinkedListNode(3);
			var d = new LinkedListNode(4);

			a.Next = b;
			b.Next = c;
			c.Next = d;

			DeleteNode(a, c);

			Assert.Equal(2, a.Next.Value);
			Assert.Equal(4, a.Next.Next.Value);
		}

		private void DeleteNode(LinkedListNode head, LinkedListNode nodeToDelete)
		{
			var root = head;
			var prevNode = head;

			// Edge case - Delete the head.
			if (head == nodeToDelete)
			{
				head = head.Next;
				return;
			}


			while (head != null)
			{
				if (head == nodeToDelete)
				{
					prevNode.Next = head.Next;
					return;
				}

				prevNode = head;
				head = head.Next;
			}

			head = root;
		}
	}

	class LinkedListNode
	{
		public int Value { get; set; }

		public LinkedListNode Next { get; set; }

		public LinkedListNode(int value)
		{
			Value = value;
		}
	}
}
