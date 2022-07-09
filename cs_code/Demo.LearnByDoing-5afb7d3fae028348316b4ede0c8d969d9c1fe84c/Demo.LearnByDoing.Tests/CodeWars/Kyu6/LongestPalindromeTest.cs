using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/longest-palindrome/train/csharp
	/// </summary>
	public class LongestPalindromeTest
	{
		[Theory]
		[InlineData("", 0)]
		[InlineData(null, 0)]
		[InlineData("a", 1)]
		[InlineData("aa", 2)]
		[InlineData("baa", 2)]
		[InlineData("abc0cba1", 7)]
		[InlineData("12 21glg", 5)]
		[InlineData("I like racecars that go fast", 7)]
		[InlineData("   ", 3)]
		public void SampleTest(string input, int expected)
		{
			var actual = Kata.GetLongestPalindrome(input);
			Assert.Equal(expected, actual);
		}
	}

	public partial class Kata
	{
		public static int GetLongestPalindrome(string sentence)
		{
			if (sentence == null) return 0;
			if (sentence.Length == 1) return 1;

			for (int i = 0; i < sentence.Length - 1; i++)
			{
				for (int j = sentence.Length; j > i + 1; j--)
				{
					var length = j - i;
					var partial = sentence.Substring(i, length);
					if (IsPalindrome(partial)) return length;
				}
			}

			return 0;
		}

		private static bool IsPalindrome(string word)
		{
			if (word.Length == 1) return true;

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
	}
}
