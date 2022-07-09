using System;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/stock-price
	/// </summary>
	/// <remarks>
	/// Writing programming interview questions hasn't made me rich. Maybe trading Apple stocks will.
	/// </remarks>
	public class Question001Test
	{
		[Theory]
		[InlineData(6, new [] { 10, 7, 5, 8, 11, 9 })]
		[InlineData(-1, new [] { 5, 4, 3, 2, 1 })]
		[InlineData(-2, new [] { 10, 7, 5, 1 })]
		[InlineData(4, new [] { 1, 2, 3, 4, 5 })]
		[InlineData(0, new [] { 2, 2, 2 })]
		public void TestSampleData(int expected, int[] input)
		{
			int actual = GetMaxProfit(input);
			Assert.Equal(expected, actual);
		}

		private int GetMaxProfit(int[] a)
		{
			int min = a[0];
			int maxSum = int.MinValue;

			for (int i = 1; i < a.Length; i++)
			{
				maxSum = Math.Max(maxSum, a[i] - min);
				min = a[i] < min ? a[i] : min;
			}

			return maxSum;
		}

		private int GetMaxProfitFailsForNegative(int[] a)
		{
			int min = int.MaxValue;
			int max = int.MinValue;
			int minIndex = -1;
			int maxIndex = -1;
			int maxDiff = 0;
			
			for (int i = 0; i < a.Length; i++)
			{
				var current = a[i];
				if (current < min)
				{
					min = current;
					minIndex = i;
				}

				if (current > max)
				{
					max = current;
					maxIndex = i;
				}

				if (max - min > maxDiff) maxDiff = max - min;
			}

			return minIndex > maxIndex ? -maxDiff : maxDiff;
		}
	}
}
