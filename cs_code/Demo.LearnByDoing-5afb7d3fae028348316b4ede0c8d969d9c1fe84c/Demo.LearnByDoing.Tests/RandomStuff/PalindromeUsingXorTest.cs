using System.Collections.Generic;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.RandomStuff
{
    /// <summary>
    /// This doesn't work!!!
    /// </summary>
	public class PalindromeUsingXorTest : BaseTest
	{
		public PalindromeUsingXorTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[MemberData(nameof(GetTestData))]
		public void TestPalindromeness(bool expected, ListNode<int> list)
		{
			_output.WriteLine(list.ToString());
		}

		public static IEnumerable<object[]> GetTestData()
		{
			yield return new object[] {true, GetListNode(0, 1, 0)};
			yield return new object[] {false, GetListNode(1, 2, 2, 3)};
		}

		private static ListNode<int> GetListNode(params int[] args)
		{
			var root = new ListNode<int>();
			var head = root;

			foreach (var arg in args)
			{
				head.Value = arg;
				var next = new ListNode<int>();
				head.Next = next;
				head = head.Next;
			}

			return root;
		}
	}

	// Copied from @Robert
	public class ListNode<T>
	{
		public T Value { get; set; }
		public ListNode<T> Next { get; set; }
	}

}
