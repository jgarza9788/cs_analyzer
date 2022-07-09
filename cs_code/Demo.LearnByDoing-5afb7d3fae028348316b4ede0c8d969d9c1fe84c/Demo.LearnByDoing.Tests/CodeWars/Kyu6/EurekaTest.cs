using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/take-a-number-and-sum-its-digits-raised-to-the-consecutive-powers-and-dot-dot-dot-eureka/train/csharp
	/// </summary>
	public class EurekaTest : BaseTest
	{
		public EurekaTest(ITestOutputHelper output) : base(output)
		{
		}

		private static string Array2String(long[] list)
		{
			return "[" + string.Join(", ", list) + "]";
		}

		private static void testing(long a, long b, long[] res)
		{
			Assert.Equal(Array2String(res), Array2String(SumDigPower.SumDigPow(a, b)));
		}

		[Fact]
		public static void test1()
		{
			Console.WriteLine("Basic Tests SumDigPow");
			testing(1, 10, new long[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
			testing(1, 100, new long[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 89 });
			testing(10, 100, new long[] { 89 });
			testing(90, 100, new long[] { });
			testing(90, 150, new long[] { 135 });
			testing(50, 150, new long[] { 89, 135 });
			testing(10, 150, new long[] { 89, 135 });

		}
	}

	public class SumDigPower
	{

		public static long[] SumDigPow(long a, long b)
		{
			var result = new List<long>();

			for (long i = a; i <= b; i++)
			{
				if (IsAMatch(i))
					result.Add(i);
			}

			return result.ToArray();
		}

		private static bool IsAMatch(long n)
		{
			List<int> digits = GetDigits(n).ToList();
			return n == digits.Select((number, index) => Math.Pow(number, index + 1)).Sum();
		}

		private static IEnumerable<int> GetDigits(long l)
		{
			foreach (char c in l.ToString())
			{
				yield return c - '0';
			}
		}
	}
}
