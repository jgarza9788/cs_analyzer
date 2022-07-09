using System;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.MissionInterview
{
	/// <summary>
	/// Implementing Stack using SungLinkedList
	/// </summary>
	public class StackTest : BaseTest
	{
		public StackTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestPush()
		{
			var sut = new SungStack<int>();
			sut.Push(1);
			sut.Push(2);
			sut.Push(3);

			int[] expected = {3, 2, 1};
			Assert.True(expected.SequenceEqual(sut.Traverse().ToArray()));
		}

		[Fact]
		public void TestPop()
		{
			var sut = new SungStack<int>();
			sut.Push(1);
			sut.Push(2);
			sut.Push(3);

			var popped = sut.Pop();
			Assert.Equal(3, popped);
			Assert.True(new[] {2,1}.SequenceEqual(sut.Traverse().ToArray()));

			popped = sut.Pop();
			Assert.Equal(2, popped);
			Assert.True(new[] {1}.SequenceEqual(sut.Traverse().ToArray()));

			popped = sut.Pop();
			Assert.Equal(1, popped);
			Assert.True(new int[] {}.SequenceEqual(sut.Traverse().ToArray()));

			Assert.Throws<InvalidOperationException>(() => sut.Pop());
		}

		[Fact]
		public void TestPeek()
		{
			var sut = new SungStack<int>();
			const int itemCount = 3;

			for (int i = 1; i <= itemCount; i++)
			{
				sut.Push(i);
				Assert.Equal(i, sut.Peek());
			}

			for (int i = itemCount - 1; i >= 0; i--)
			{
				sut.Pop();
				Assert.Equal(i, sut.Peek());
			}

			// default(int) returns 0
			Assert.Equal(0, sut.Peek());
		}
	}
}
