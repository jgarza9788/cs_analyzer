using System;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.RandomStuff
{
	public class RecursionTest : BaseTest
	{
		public RecursionTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(new []{1,2,3}, 6)]
		[InlineData(new []{2, 4, 8}, 14)]
		[InlineData(new []{-1, 0, 1}, 0)]
		public void TestSumming(int[] input, int expected)
		{
			var sut = new RecursionStuff();
			int actual = sut.GetSum(input);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(new object[]{new []{1,2,3}, 4, new []{5}}, 15)]
		[InlineData(new object[]{-1, new[] {0, 1}, new []{5}, 10}, 15)]
		public void TestNestedArraySum(object[] input, int expected)
		{
			var sut = new RecursionStuff();
			int actual = sut.GetNestedArraySum(input);
			Assert.Equal(expected, actual);
		}
	}

	public class RecursionStuff
	{
		public int GetNestedArraySum(object[] input)
		{
			return GetNestedArraySumRecursively(input, input.Length - 1);
		}

		private int GetNestedArraySumRecursively(object[] input, int i)
		{
			if (i < 0) return 0;

			var arr = input[i] as int[];
			int current = arr == null ? Convert.ToInt32(input[i]) : 0;
			if (arr != null)
			{
				current += GetNestedArraySumRecursively(arr.Select(x => (object)x).ToArray(), arr.Length - 1);
			}

			return current + GetNestedArraySumRecursively(input, i - 1);
		}

		public int GetSum(int[] input)
		{
			return GetSumRecursively(input, input.Length - 1);
		}

		private int GetSumRecursively(int[] input, int i)
		{
			if (i == 0) return input[i];

			return input[i] + GetSumRecursively(input, i - 1);
		}
	}
}
