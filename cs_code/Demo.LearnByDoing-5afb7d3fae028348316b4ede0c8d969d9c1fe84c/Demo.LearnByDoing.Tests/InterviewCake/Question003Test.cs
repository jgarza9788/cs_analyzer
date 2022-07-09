using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// Highest Product of 3
	/// https://www.interviewcake.com/question/csharp/highest-product-of-3
	/// </summary>
	public class Question003Test
	{
		[Theory]
		[InlineData(new[] { 8, 5, 3, 1, 2, 7 }, 280)]
		[InlineData(new[] { 3, 4, 5, 6, 7 }, 210)]
		[InlineData(new[] { 7, 6, 5, 4, 3, 2, 1 }, 210)]
		[InlineData(new[] { 3, 3, 3 }, 27)]
		[InlineData(new[] { -10, -10, 1, 3, 2 }, 300)]
		[InlineData(new[] { 3, 3, 4, 5 }, 60)]
		[InlineData(new[] { 5, 3, 4, 2 }, 60)]
		public void TestSampleCases(int[] input, int expected)
		{
			var sut = new HighestProductOfThree();
			int actual = sut.GetMax(input);

			Assert.Equal(expected, actual);
		}
	}

	public class HighestProductOfThree
	{
		private const int PRODUCT_SIZE = 3;

		public int GetMax(int[] a)
		{
			var initialArray = a.Take(PRODUCT_SIZE);
			var negatives = new List<int>(initialArray);
			var positives = new List<int>(initialArray);

			for (int i = PRODUCT_SIZE; i < a.Length; i++)
			{
				var value = a[i];
				negatives = GetRearrangedNegativeValue(negatives, value);
				positives = GetRearrangedPositiveValue(positives, value);
			}

			Func<IEnumerable<int>, int> getProduct = list => list.Aggregate(1, (acc, value) => acc * value);
			return Math.Max(getProduct(negatives), getProduct(positives));
		}

		private List<int> GetRearrangedPositiveValue(List<int> list, int value)
		{
			list.Add(value);
			return list.OrderByDescending(n => n).Take(PRODUCT_SIZE).ToList();
		}
		private List<int> GetRearrangedNegativeValue(List<int> list, int value)
		{
			list.Add(value);
			return list.OrderByDescending(Math.Abs).Take(PRODUCT_SIZE).ToList();
		}

		public int GetMax_DoesntWorkForNegativeElement(int[] a)
		{
			int max = int.MinValue;
			int mid = int.MinValue;
			int low = int.MinValue;

			Func<int, bool> isMax = n => n > max;
			Func<int, bool> isMid = n => n > mid;
			Func<int, bool> isLow = n => n > low;

			for (int i = 0; i < a.Length; i++)
			{
				var curr = a[i];
				if (isMax(curr))
				{
					low = mid;
					mid = max;
					max = curr;
				}
				else if (isMid(curr))
				{
					low = mid;
					mid = curr;
				}
				else if (isLow(curr))
				{
					low = curr;
				}
			}

			return max * mid * low;
		}
	}
}
