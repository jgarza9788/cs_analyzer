using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/gauss-needs-help-sums-of-a-lot-of-numbers/train/csharp
	/// </summary>
	public class GaussNeedsHelpTest : BaseTest
	{
		public GaussNeedsHelpTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(100l, 5050l)]
		[InlineData(300l, 45150l)]
		[InlineData(50000l, 1250025000l)]
		public void TestSampleData(long input, long? expected)
		{
			long? actual = Kata.RangeSum(input);
			Assert.Equal(expected, actual);
		}
	}

	public partial class Kata
	{
		public static long? RangeSum(long n)
		{
			// Note: This function's runtime can be made to be near-instant, but it should not be necessary for this Kata.

			if (n <= 0) return null;

			var evenSum = (n + 1) * (n / 2);
			Func<long, bool> isEven = x => x % 2 == 0;
			if (isEven(n))
				return evenSum;

			long middleNumber = (n / 2) + 1;
			return evenSum + middleNumber;
		}
	}
}
