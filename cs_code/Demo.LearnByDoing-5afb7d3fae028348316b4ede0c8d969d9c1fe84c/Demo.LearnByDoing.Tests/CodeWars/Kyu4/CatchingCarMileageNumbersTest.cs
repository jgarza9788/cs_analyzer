using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu4
{
	/// <summary>
	/// https://www.codewars.com/kata/catching-car-mileage-numbers/train/csharp
	/// </summary>
	public class CatchingCarMileageNumbersTest : BaseTest
	{
		public CatchingCarMileageNumbersTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void ShouldWorkTest()
		{
			//Assert.Equal(0, Kata.IsInteresting(3, new List<int>() { 1337, 256 }));
			//Assert.Equal(1, Kata.IsInteresting(1336, new List<int>() { 1337, 256 }));
			//Assert.Equal(2, Kata.IsInteresting(1337, new List<int>() { 1337, 256 }));
			//Assert.Equal(0, Kata.IsInteresting(11208, new List<int>() { 1337, 256 }));
			//Assert.Equal(1, Kata.IsInteresting(11209, new List<int>() { 1337, 256 }));
			//Assert.Equal(2, Kata.IsInteresting(11211, new List<int>() { 1337, 256 }));
			//Assert.Equal(2, Kata.IsInteresting(67890, new List<int>() { 1337, 256 }));
			//Assert.Equal(2, Kata.IsInteresting(3210, new List<int>() { 1337, 256 }));
			Assert.Equal(1, Kata.IsInteresting(1232, new List<int>() { 1337, 256 }));
		}
	}

	public partial class Kata
	{
		public static int IsInteresting(int number, List<int> awesomePhrases)
		{
			if (IsNumberInteresting(number, awesomePhrases)) return 2;

			if (IsNumberInteresting(number + 1, awesomePhrases) || IsNumberInteresting(number + 2, awesomePhrases)) return 1;

			return 0;
		}

		private static bool IsNumberInteresting(int number, List<int> awesomePhrases)
		{
			var digits = GetDigits2(number).ToList();

			// is digit count less than 3? then not interesting.
			if (digits.Count < 3) return false;

			// Rest is 0? 100, 90000
			var rest = digits.Skip(1).Distinct().ToList();
			if (rest.Count == 1 && rest.FirstOrDefault() == 0) return true;

			// All same number? 111
			if (digits.Distinct().Count() == 1) return true;

			var increaseSize = 1;
			var decreaseSize = 1;
			//for (int i = 0; i < digits.Count - 1; i++)
			//{
			//	var curr = digits[i];
			//	var next = digits[i + 1] == 0 ? 10 : digits[i + 1];
			//	if (curr + 1 == next) increaseSize++;
			//	if (curr - 1 == next) decreaseSize++;
			//}


			for (int i = 0; i < digits.Count - 1; i++)
			{
				var curr = digits[i];
				var next = digits[i + 1] == 0 ? 10 : digits[i + 1];
				if (curr + 1 == next) increaseSize++;
			}

			for (int i = 0; i < digits.Count - 1; i++)
			{
				var curr = digits[i];
				var next = digits[i + 1];
				if (curr - 1 == next) decreaseSize++;
			}


			if (increaseSize == digits.Count || decreaseSize == digits.Count) return true;

			// Is Palindrome? 1221 73837
			if (IsPalindrome(number.ToString())) return true;

			// Matches anything in awesomePhrases?
			return awesomePhrases.Contains(number);
		}

		public static bool IsPalindrome(string word)
		{
			if (word.Length == 1) return true;
			if (string.IsNullOrEmpty(word)) return false;

			int start = 0;
			int end = word.Length - 1;
			int mid = end / 2;

			for (int i = start; i <= mid; i++)
			{
				if (word[start] != word[end]) return false;

				start++;
				end--;
			}

			return true;
		}


		private static IEnumerable<int> GetDigits2(long number)
		{
			foreach (char c in number.ToString())
			{
				yield return c - '0';
			}
		}

	}
}
