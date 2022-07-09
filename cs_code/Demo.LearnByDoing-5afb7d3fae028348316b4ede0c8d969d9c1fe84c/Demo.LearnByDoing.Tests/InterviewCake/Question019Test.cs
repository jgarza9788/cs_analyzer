using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/queue-two-stacks
	/// 
	/// Implement a queue with 2 stacks.
	/// Your queue should have an enqueue and a dequeue method and it should be "first in first out" (FIFO).
	/// </summary>
	public class Question019Test
	{
		public static IEnumerable<object[]> GetSampleCases()
		{
			yield return new object[] { Enumerable.Range(1, 10).ToArray() };
			yield return new object[] { new [] { 3, 2, 1 } };
			yield return new object[] { new [] { 1 } };
			yield return new object[] { new [] { 2 } };
			yield return new object[] { new [] { 3 } };
			yield return new object[] { new [] { 3, 5, 7, 1, 2, 3 } };
		}

		[Theory]
		[MemberData(nameof(GetSampleCases))]
		public void TestSampleCases(int[] input)
		{
			int[] expected = input;
			var sut = new QueueWithTwoStacks();
			sut.EnqeueRange(input);

			int[] actual = sut.DequeueAll();
			Assert.True(expected.SequenceEqual(actual));
		}

		[Fact]
		public void TestOneOffCases()
		{
			var sut = new QueueWithTwoStacks();
			sut.Enqueue(1);
			sut.Enqueue(2);
			Assert.Equal(1, sut.Dequeue());
			sut.Enqueue(3);
			sut.Enqueue(4);
			Assert.Equal(2, sut.Dequeue());
			Assert.Equal(3, sut.Dequeue());
		}
	}

	public class QueueWithTwoStacks
	{
		public Stack<int> InStack { get; set; } = new Stack<int>();
		public Stack<int> OutStack { get; set; } = new Stack<int>();

		public void Enqueue(int value)
		{
			InStack.Push(value);
		}

		public int Dequeue()
		{
			if (OutStack.Count == 0)
				// 3, 2, 1? How to get them from the end?
				while (InStack.Count > 0) OutStack.Push(InStack.Pop());

			return OutStack.Pop();
		}

		public void EnqeueRange(int[] input)
		{
			foreach (var value in input)
				InStack.Push(value);

			while (InStack.Count > 0)
				OutStack.Push(InStack.Pop());
		}

		public int[] DequeueAll()
		{
			return OutStack.ToArray();
		}
	}
}
