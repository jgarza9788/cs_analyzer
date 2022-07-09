using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu4
{
	/// <summary>
	/// https://www.codewars.com/kata/total-increasing-or-decreasing-numbers-up-to-a-power-of-10/train/csharp
	/// </summary>
	public class NonBouncyNumberCountTest : BaseTest
	{
		public NonBouncyNumberCountTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestBouncyNumbers()
		{
			int[] nonBouncyNumbers =
			{
				110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 122, 123, 124, 125, 126, 127, 128, 129, 133, 134, 135, 136, 137,
				138, 139, 144, 145, 146, 147, 148, 149, 155, 156, 157, 158, 159, 166, 167, 168, 169, 177, 178, 179, 188, 189, 199,
				200
			};

			List<int> nonBouncyNumberList = new List<int>();
			for (int i = 101; i <= 200; i++)
			{
				if (!TotalIncreasingOrDecreasingNumbers.IsBouncyNumber(i))
					nonBouncyNumberList.Add(i);
			}

			Assert.True(nonBouncyNumberList.SequenceEqual(nonBouncyNumbers));
		}

		[Theory]
		[MemberData(nameof(GetNumbers))]
		public void TestTotalIncDecCount(int power, string expected)
		{
			BigInteger actual = TotalIncreasingOrDecreasingNumbers.TotalIncDec(power);
			Assert.Equal(BigInteger.Parse(expected), actual);
		}

		public static IEnumerable<object[]> GetNumbers()
		{
			yield return new object[] { 0, "1" };
			yield return new object[] { 1, "10" };
			yield return new object[] { 2, "100" };
			yield return new object[] { 3, "475" };
			yield return new object[] { 4, "1675" };
			yield return new object[] { 5, "4954" };
			yield return new object[] { 6, "12952" };
		}
	}

	public class TotalIncreasingOrDecreasingNumbers
	{
		public static BigInteger TotalIncDec(int power)
		{
			BigInteger upto = BigInteger.Pow(10, power);
			if (upto <= 100) return upto;

			BigInteger total = 100;

			for (BigInteger i = 101; i <= upto; i++)
			{
				if (i % 1000 == 0)
				{
					// Skip bouncy numbers
					var digits = GetDigits(i).ToList();
					var skipBy = int.Parse(string.Join("", Enumerable.Repeat(digits[0].ToString(), digits.Count - 3)) + (digits[0] - 1) + "9");
					i = BigInteger.Min(upto, i + skipBy);
				}

				var isBouncy = IsBouncyNumber(i);
				if (!isBouncy)
					total++;
			}

			return total;
		}

		public static bool IsBouncyNumber(BigInteger number)
		{
			if (number <= 99) return false;

			var digits = GetDigits(number).ToList();
			var prev = digits.FirstOrDefault();

			var isDecreasing = false;
			var isIncreasing = false;

			for (int i = 1; i < digits.Count; i++)
			{
				var next = digits[i];

				// is Decreasing
				if (prev > next)
					isDecreasing = true;

				// is Increasing
				if (prev < next)
					isIncreasing = true;

				if (isDecreasing && isIncreasing)
					return true;

				prev = next;
			}

			return false;
		}

		private static IEnumerable<int> GetDigits(BigInteger number)
		{
			foreach (char c in number.ToString())
			{
				yield return c - '0';
			}
		}
	}
}
