using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	/// <summary>
	/// https://www.codewars.com/kata/compute-the-largest-sum-of-all-contiguous-subsequences
	/// </summary>
	public class ComputeTheLargestSumOfAllContiguousSubsequencesTest : BaseTest
	{
		public ComputeTheLargestSumOfAllContiguousSubsequencesTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[MemberData(nameof(GetTestCases))]
		public void TestFromDescription(int[] a, int expected)
		{
			int actual = Kata.LargestSum(a);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetTestCases()
		{
			yield return new object[] {new[]{-1,-2,-3}, 0};
			yield return new object[] {new int[]{}, 0};
			yield return new object[] {new[]{1,2,3,4}, 10};
			yield return new object[] {new[]{ 31, -41, 59, 26, -53, 58, 97, -93, -23, 84 }, 187};
		}
	}

	partial class Kata
	{
		public static int LargestSum(int[] a)
		{
			var list = a.ToList();

			if (list.Count == 0) return 0;
			// if all numbers are negative, return 0
			if (list.Max() <= 0) return 0;
			// if all numbers are positive, return the sum of array
			if (list.All(value => value >= 0)) return list.Sum();

			int max = 0;
			int sum = 0;

			foreach (var value in list)
			{
				sum += value;
				if (sum < 0)
					sum = 0;

				if (sum > max)
					max = sum;
			}

			return max;
		}
	}
}
