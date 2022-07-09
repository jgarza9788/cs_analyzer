using System;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/count-the-digit/train/csharp
	/// </summary>
	public class CountTheDigitTest : BaseTest
	{
		public CountTheDigitTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(4, 10, 1)]
		[InlineData(11, 25, 1)]
		[InlineData(4700, 5750, 0)]
		[InlineData(9481, 11011, 2)]
		[InlineData(7733, 12224, 8)]
		[InlineData(11905, 11549, 1)]
		public static void test1(int expected, int n, int d)
		{
			Assert.Equal(expected, CountDig.NbDig(n, d));
		}
	}

	public class CountDig
	{
		public static int NbDig(int n, int d)
		{
			Func<int, int> countDigits = value => value.ToString().Count(c => Char.GetNumericValue(c) == d);
			return Enumerable.Range(0, n + 1)
				// Map
				.Select(number => number * number)
				// Reduce
				.Aggregate(0, (acc, number) => acc + countDigits(number));
		}
	}
}
