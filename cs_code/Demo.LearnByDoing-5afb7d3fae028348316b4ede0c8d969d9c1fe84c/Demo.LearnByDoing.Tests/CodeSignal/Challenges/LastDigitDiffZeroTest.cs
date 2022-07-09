using System.Collections.Generic;
using System.Numerics;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeSignal.Challenges
{
	/// <summary>
	/// https://codefights.com/challenge/G77e49Sztk9BY8GA2
	/// 
	/// Find the last digit of n!(factorial), which is different from zero.
	/// 
	/// Example
	/// 
	/// For n = 5, the output should be
	/// lastDigitDiffZero(n) = 2.
	/// 5! = 1 · 2 · 3 · 4 · 5 = 120.
	/// 
	/// For n = 6, the output should be
	/// lastDigitDiffZero(n) = 2.
	/// 6! =1 · 2 · 3 · 4 · 5 · 6 = 720.
	/// 
	/// For n = 10, the output should be
	/// lastDigitDiffZero(n) = 8.
	/// 10! = 3628800.
	/// 
	/// [execution time limit] 3 seconds (cs)
	/// 
	/// [input] integer64 n
	/// 
	/// Guaranteed constraints:
	/// 1 ≤ n ≤ 109.
	/// 
	/// [output] integer
	/// 
	/// </summary>
	public class LastDigitDiffZeroTest
	{
		[Theory]
		[MemberData(nameof(GetSampleCases))]
		public void TestSampleCases(long n, int expected)
		{
			int actual = lastDigitDiffZero(n);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetSampleCases()
		{
			yield return new object[] { 5, 2 };
			yield return new object[] { 6, 2 };
			yield return new object[] { 10, 8 };
		}

		[Theory]
		[MemberData(nameof(GetFactorialData))]
		public void TestFactorialGeneration(long n, BigInteger expected)
		{
			BigInteger actual = GetFactorial(n);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetFactorialData()
		{
			yield return new object[] { 5, 120 };
			yield return new object[] { 6, 720 };
			//yield return new object[] { 10, 3628800 };
			//yield return new object[] { 20, 2432902008176640000 };
		}

		private BigInteger GetFactorial(long n)
		{
			BigInteger result = 1;

			for (long i = 2; i < n; i++)
			{
				result *= i;
			}

			return result;
		}

		int lastDigitDiffZero(long n)
		{
			return -1;
		}
	}
}
