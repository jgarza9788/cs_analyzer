using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/greatest-common-divisor/train/csharp
	/// </summary>
	public class GreatestCommonDivisorTest
	{
		[Theory]
		[MemberData(nameof(GetTestCases))]
		public void Test(int expected, int a, int b)
		{
			Assert.Equal(expected, Kata.Gcd(a, b));
		}

		public static IEnumerable<object[]> GetTestCases()
		{
			yield return new object[] {6, 30, 12};
			yield return new object[] {1, 8, 9};
			yield return new object[] {1, 1, 1};
		}
	}

	public partial class Kata
	{
		public static int Gcd(int a, int b)
		{
			if (b == 0) return a;

			return Gcd(b, a % b);
		}
	}
}
