using System;

namespace Demo.LearnByDoing.General.Algorithms.MaximumSubArraySum
{
	/// <summary>
	/// Implementing Maximum Subarray sum using Kadane's algorithm in https://youtu.be/ohHWQf1HDfU
	/// </summary>
	public class MaximumSubArraySumProgram
	{
		public static void Main(string[] args)
		{
			// https://youtu.be/ohHWQf1HDfU
			//int[] a = { 1, -3, 2, -5, 7, 6, -1, -4, 11, -23 };
			//int[] a = { 1, 2, 3, 4 };
			//int[] a = { 1, 2, 3, -10 };
			int[] a = { -10 };
			MaximumSubArray maximumSubArray = GetMaximumSubArray(a);
			Console.WriteLine("From: {0} to {1}, sum: {2}", maximumSubArray.From, maximumSubArray.To, maximumSubArray.Sum);
		}

		private static MaximumSubArray GetMaximumSubArray2(int[] a)
		{
			if (a.Length <= 0) return null;

			int @from = 0;
			int to = 0;
			int sum = 0;
			int maxSum = 0;

			for (int i = 0; i < a.Length; i++)
			{
				if (sum + a[i] > 0)
				{
					if (sum == 0) @from = i;

					sum += a[i];
					if (sum > maxSum)
					{
						maxSum = sum;
						to = i;
					}
				}
				else
				{
					sum = 0;
				}
			}

			return new MaximumSubArray(@from, to, maxSum);
		}

		private static MaximumSubArray GetMaximumSubArray(int[] a)
		{
			if (a.Length <= 0) return null;

			int @from = 0;
			int to = 0;
			int sum = a[0];
			int maxSum = sum;

			for (int i = 1; i < a.Length; i++)
			{
				if (sum + a[i] > 0)
				{
					if (sum == 0)
					{
						@from = i;
					}

					sum += a[i];
					
					if (maxSum < sum)
					{
						maxSum = sum;
						to = i;
					}
				}
				else
				{
					sum = 0;
				}
			}

			return new MaximumSubArray(@from, to, maxSum);
		}
	}
}
