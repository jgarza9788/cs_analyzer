using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeSignal.CommonTechniques
{
	/// <summary>
	/// https://codefights.com/interview-practice/task/4MoqQLaw22nrzXbgs/description
	/// </summary>
	public class SumInRangeTest
	{
		[Fact]
		public void TestSumInRange()
		{
			int[] nums = { 3, 0, -2, 6, -3, 2 };
			int[][] queries = new int[3][];
			queries[0] = new[] { 0, 2 };
			queries[1] = new[] { 2, 5 };
			queries[2] = new[] { 0, 5 };

			int actual = GetSumInRange2(nums, queries);
			const int expected = 10;

			Assert.Equal(expected, actual);
		}

		private int GetSumInRange2(int[] nums, int[][] queries)
		{
			var cumulativeSums = new int[nums.Length];
			cumulativeSums[0] = nums[0];
			for (int i = 1; i < nums.Length; i++)
			{
				cumulativeSums[i] = cumulativeSums[i - 1] + nums[i];
			}

			long total = 0;
			foreach (int[] query in queries)
			{
				int f = query[0];
				int t = query[1];
				total += cumulativeSums[t] - (f == 0 ? 0 : cumulativeSums[f - 1]);
			}

			var mod = 1000000007;
			return (int) ((total % mod + mod) % mod);
		}

		private int GetSumInRange(int[] nums, int[][] queries)
		{
			var forwardSum = new List<int>(nums.Length);
			//forwardSum.Add(nums[0]);
			forwardSum[0] = 0;
			var backwardSum = new List<int>(nums.Length);
			//backwardSum.Add(nums[nums.Length - 1]);
			backwardSum[nums.Length - 1] = 0;

			for (int i = 1, j = nums.Length - 2; i < nums.Length; i++, j--)
			{
				var forwardCurrent = nums[i];
				var backwardCurrent = nums[j];
				var prevForwardNum = forwardSum[i - 1];
				var prevBackwardNum = backwardSum[j + 1];

				forwardSum[i] = forwardCurrent + prevForwardNum;
				backwardSum[j] = backwardCurrent + prevBackwardNum;

				//forwardSum.Add(prevForwardNum + forwardCurrent);
				//backwardSum.Add(prevBackwardNum + backwardCurrent);
			}

			var range = new List<int>();
			foreach (var query in queries)
			{
				var f = query[0];
				var t = query[1];

				if (t - f == 1) range.Add(nums[t] + nums[f]);
				else if (t - f == 0) range.Add(nums[t]);
				else if (f == 0) range.Add(forwardSum[t]);
				else if (t == nums.Length - 1) range.Add(backwardSum[f]);
				else range.Add(backwardSum[t] - forwardSum[f]);
			}


			foreach (var n in range) Console.WriteLine(n);

			var total = range.Sum();
			var mod = 1000000007;
			return (total % mod + mod) % mod;
		}
	}
}
