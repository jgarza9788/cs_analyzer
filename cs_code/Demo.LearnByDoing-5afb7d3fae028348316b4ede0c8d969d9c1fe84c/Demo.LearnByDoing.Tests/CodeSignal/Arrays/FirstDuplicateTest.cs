using System;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeSignal.Arrays
{
	/// <summary>
	/// https://codefights.com/interview-practice/task/pMvymcahZ8dY4g75q
	/// </summary>
	public class FirstDuplicateTest
	{
		[Theory]
		[InlineData(3, new[] { 2, 3, 3, 1, 5, 2 })]
		[InlineData(-1, new[] { 2, 4, 3, 5, 1 })]
		[InlineData(-1, new[] { 2, 1 })]
		[InlineData(2, new[] { 2, 2 })]
		[InlineData(3, new[] { 2, 3, 3 })]
		[InlineData(-1, new[] { 2, 1, 3 })]
		[InlineData(-1, new[] { 10, 6, 8, 4, 9, 1, 7, 2, 5, 3 })]
		[InlineData(6, new[] { 8, 4, 6, 2, 6, 4, 7, 9, 5, 8 })]
		public void TestSampleData(int expected, int[] input)
		{
			var actual = firstDuplicate(input);
			Assert.Equal(expected, actual);
		}

		int firstDuplicate(int[] a)
		{
			for (int i = 0; i < a.Length; i++)
			{
				var curr = Math.Abs(a[i]) - 1;
				var next = a[curr] - 1;
				if (next < 0) return curr + 1;

				a[curr] = -a[curr];
			}

			return -1;
		}
	}
}
