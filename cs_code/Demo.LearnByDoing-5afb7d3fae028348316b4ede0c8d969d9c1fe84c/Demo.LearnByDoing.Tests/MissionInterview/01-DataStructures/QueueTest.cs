using System;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.MissionInterview._01_DataStructures
{
	public class QueueTest
	{
		[Fact]
		public void TestEnqueue()
		{
			var sut = new SungQueue<int>();

			const int upto = 10;
			for (int i = 1; i <= upto; i++)
			{
				sut.Enqueue(i);
			}

			Assert.True(Enumerable.Range(1, upto).SequenceEqual(sut.Traverse()));
		}

		[Fact]
		public void TestPeek()
		{
			var sut = new SungQueue<int>();
			Assert.Equal(0, sut.Peek());

			const int upto = 10;
			for (int i = 1; i <= upto; i++)
			{
				sut.Enqueue(i);
			}
		}

		[Fact]
		public void TestDequeue()
		{
			var sut = new SungQueue<int>();

			const int upto = 10;
			for (int i = 1; i <= upto; i++)
			{
				sut.Enqueue(i);
			}

			for (int expected = 1; expected <= upto; expected++)
			{
				var actual = sut.Dequeue();
				Assert.Equal(expected, actual);
			}

			Assert.Throws<InvalidOperationException>(() => sut.Dequeue());
		}
	}
}
