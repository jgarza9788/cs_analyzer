using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/parse-a-linked-list-from-a-string/train/csharp
	/// </summary>
	public class ParseALinkedListFromAStringTest
	{
		[Theory]
		[InlineData(new[]{"1", "2", "3", "null"}, "1 -> 2 -> 3 -> null")]
		[InlineData(new[]{"0", "1", "4", "9", "16", "null"}, "0 -> 1 -> 4 -> 9 -> 16 -> null")]
		[InlineData(new[]{"null"}, "null")]
		public void TestSplit(string[] expected, string input)
		{
			Assert.True(expected.SequenceEqual(input.Split(new []{ " -> " }, StringSplitOptions.RemoveEmptyEntries)));
		}

		[Theory]
		[MemberData(nameof(GetSampleData))]
		public void SampleTest(Node expected, string input)
		{
			Assert.Equal(expected, Kata.Parse(input));
		}

		public static IEnumerable<object[]> GetSampleData()
		{
			yield return new object[] {new Node(1, new Node(2, new Node(3))), "1 -> 2 -> 3 -> null" };
			yield return new object[] {new Node(0, new Node(1, new Node(4, new Node(9, new Node(16))))), "0 -> 1 -> 4 -> 9 -> 16 -> null" };
			yield return new object[] {null, "null" };
		}
	}

	public partial class Kata
	{
		public static Node Parse(string input)
		{
			if (input == "null") return null;
			var nodeTexts = input.Split(new[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
			// drop last "null"
			var nodeValues = nodeTexts.Take(nodeTexts.Length - 1).Select(t => Convert.ToInt32(t)).Reverse();

			Node node = null;
			foreach (int value in nodeValues)
			{
				node = new Node(value, node);
			}

			return node;
		}
	}

	public class Node : Object
	{
		public int Data;
		public Node Next;

		public Node(int data, Node next = null)
		{
			Data = data;
			Next = next;
		}

		public override bool Equals(Object obj)
		{
			// Check for null values and compare run-time types.
			if (obj == null || GetType() != obj.GetType()) { return false; }

			return ToString() == obj.ToString();
		}

		public override string ToString()
		{
			var result = new List<int>();
			Node curr = this;

			while (curr != null)
			{
				result.Add(curr.Data);
				curr = curr.Next;
			}

			return string.Copy(string.Join(" -> ", result) + " -> null");
		}
	}
}
