using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	public class DoesMNumberLookBigInThisTest : BaseTest
	{
		public DoesMNumberLookBigInThisTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(1, true)]
		[InlineData(2, true)]
		[InlineData(153, true)]
		[InlineData(1000, false)]
		[InlineData(371, true)]
		[InlineData(1634, true)]
		public void TestSampleCases(int n, bool expected)
		{
			bool actual = Kata.Narcissistic(n);

			Assert.Equal(expected, actual);
		}
	}

	public partial class Kata
	{
		public static bool Narcissistic(int n)
		{
			Func<int, List<int>> getDigits = number => number.ToString().Select(c => c - '0').ToList();
			var digits = getDigits(n);

			int power = digits.Count;
			var processedNumber = digits
				// Map each number by power of digit
				.Select(digit => (int) Math.Pow(digit, power))
				// Reduce the numbers by summing
				.Aggregate(0, (acc, digit) => acc + digit);

			return processedNumber == n;
		}
	}
}
