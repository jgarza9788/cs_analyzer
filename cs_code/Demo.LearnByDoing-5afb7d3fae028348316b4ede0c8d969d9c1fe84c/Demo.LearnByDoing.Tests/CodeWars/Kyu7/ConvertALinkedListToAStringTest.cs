using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/convert-a-linked-list-to-a-string/train/csharp
	/// </summary>
	public class ConvertALinkedListToAStringTest
	{
		[Fact]
		public void SampleTest()
		{
			Assert.Equal("1 -> 2 -> 3 -> null", Kata.Stringify(new Node(1, new Node(2, new Node(3)))));
			Assert.Equal("0 -> 1 -> 4 -> 9 -> 16 -> null", Kata.Stringify(new Node(0, new Node(1, new Node(4, new Node(9, new Node(16)))))));
			Assert.Equal("null", Kata.Stringify(null));
		}
	}

	public partial class Kata
	{
		public static string Stringify(Node node)
		{
			const string lastValue = "null";
			if (node == null) return lastValue;

			return $"{node.Data} -> {Stringify(node.Next)}";
		}
	}

	public class Node
	{
		public int Data { get; }
		public Node Next { get; }

		public Node(int data, Node next = null)
		{
			Data = data;
			Next = next;
		}
	}
}
