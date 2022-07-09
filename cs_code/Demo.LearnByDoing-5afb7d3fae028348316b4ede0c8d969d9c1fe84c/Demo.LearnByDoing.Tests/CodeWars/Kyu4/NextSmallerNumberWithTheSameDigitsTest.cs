using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu4
{
	/// <summary>
	/// https://www.codewars.com/kata/5659c6d896bc135c4c00021e/train/csharp
	/// </summary>
	public class NextSmallerNumberWithTheSameDigitsTest : BaseTest
	{
		public NextSmallerNumberWithTheSameDigitsTest(ITestOutputHelper output) : base(output)
		{
		}

		/// <summary>
		/// Find next number from here
		/// http://www.geeksforgeeks.org/find-next-greater-number-set-digits/
		/// </summary>
		[Theory]
		[InlineData(9, -1)]
		[InlineData(111, -1)]
		[InlineData(135, -1)]
		[InlineData(21, 12)]
		[InlineData(907, 790)]
		[InlineData(531, 513)]
		[InlineData(2071, 2017)]
		[InlineData(2017, 1720)]
		[InlineData(1027, -1)]
		[InlineData(441, 414)]
		[InlineData(123456798, 123456789)]
		[InlineData(53249, 52943)]
		[InlineData(51226262651257, 51226262627551)]
		[InlineData(518517, 518175)]
		[InlineData(59884848483559, 59884848459853)]
		public void FixedTests(long number, long expected)
		{
			long actual = Kata.NextSmaller(number);
			Assert.Equal(expected, actual);
		}
	}

	public partial class Kata
	{
		public static long NextSmaller(long number)
		{
			var digits = GetDigits(number).ToList();
			int from = digits.Count - 1;

			const int notFound = -1;
			int foundAt = notFound;
			//bool isFound = false;

			for (int i = from, j = from - 1; i >= 1 ; i--, j--)
			{
				var r = digits[i];
				var l = digits.Where((value, index) => index < i && value != 0).LastOrDefault();
				var lIndex = digits.Select((Value, Index) => new {Value, Index}).LastOrDefault(obj => obj.Value != 0 && obj.Index < i).Index;

				if (l > r)
				{
					// Get max index where value is less than "r" value.
					var maxIndex = GetMaxIndexAfter(digits, l, i);

					digits = Swap(digits, lIndex, maxIndex);
					foundAt = lIndex + 1;
					break;
				}
			}

			if (foundAt == notFound) return notFound;

			// 2nd iteration: Reverse sort from found + 1.
			var left = digits.Take(foundAt);
			var right = digits.Skip(foundAt).OrderByDescending(value => value);

			var smallerCandidate = ToLong(left.Concat(right).ToList());
			if (!smallerCandidate.HasValue)
				return notFound;
			return smallerCandidate.Value >= number ? notFound : smallerCandidate.Value;
		}

		private static int GetMaxIndexAfter(List<int> digits, int value, int i)
		{
			var candidates = digits.Select((Value, Index) => new { Value, Index }).Where(obj => obj.Index >= i && obj.Value < value).ToList();
			int maxValue = candidates.Max(obj => obj.Value);

			foreach (var obj in candidates)
			{
				if (obj.Value == maxValue)
					return obj.Index;
			}

			return -1;
		}

		private static List<int> Swap(List<int> digits, int i, int j)
		{
			var temp = digits[i];
			digits[i] = digits[j];
			digits[j] = temp;
			return digits;
		}

		private static long? ToLong(List<int> digits)
		{
			if (digits.Count > 0 && digits[0] == 0)
				return null;
			return long.Parse(string.Join("", digits.Select(digit => digit.ToString())));
		}

		private static IEnumerable<int> GetDigits(long number)
		{
			foreach (char c in number.ToString())
			{
				yield return c - '0';
			}
		}

	}
}
