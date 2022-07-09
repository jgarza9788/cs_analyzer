using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/triangle-number-check/train/csharp
	/// </summary>
	public class TriangleNumberCheckTest : BaseTest
	{
		public TriangleNumberCheckTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void Test1()
		{
			Assert.Equal(true, TriangleNumbers.isTriangleNumber(125250));
		}

		[Fact]
		public void Test2()
		{
			Assert.Equal(true, TriangleNumbers.isTriangleNumber(3126250));
		}
	}

	public class TriangleNumbers
	{
		/// <summary>
		/// Answer using formula in wikipedia
		/// https://en.wikipedia.org/wiki/Triangular_number
		/// </summary>
		public static bool isTriangleNumber(long number)
		{
			return Math.Abs(Math.Sqrt(8 * number + 1) - 1) % 1 == 0;
		}

		public static bool isTriangleNumber2(long number)
		{
			var upto = GetTriangleNumberUpTo(number);
			return upto == number;
		}

		private static long GetTriangleNumberUpTo(long number)
		{
			for (int n = 1; ; n++)
			{
				long upto = n * (n + 1) / 2;
				if (upto >= number) return upto;
			}
		}
	}
}
