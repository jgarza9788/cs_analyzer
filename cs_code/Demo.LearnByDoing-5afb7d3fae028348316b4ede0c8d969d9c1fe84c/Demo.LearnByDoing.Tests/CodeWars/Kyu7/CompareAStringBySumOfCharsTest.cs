using System;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	public class CompareAStringBySumOfCharsTest
	{
		[Theory]
		[InlineData(true, "AD", "BC")]
		[InlineData(false, "AD", "DD")]
		[InlineData(false, "kl", "lz")]
		[InlineData(true, "gf", "FG")]
		[InlineData(true, "ZzZz", "ffPFF")]
		[InlineData(true, null, "")]
		// If the string contains other characters than letters, treat the whole string as it would be empty.
		[InlineData(true, "zz1", "")]
		public void TestBasics(bool expected, string word1, string word2)
		{
			Assert.Equal(expected, Kata.Compare(word1, word2));
		}
	}

	public partial class Kata
	{
		public static bool Compare(string s1, string s2)
		{
			string word1 = GetCleanedWord(s1);
			string word2 = GetCleanedWord(s2);

			return word1.Sum(c => (int) c) == word2.Sum(c => (int) c);
		}

		private static string GetCleanedWord(string word)
		{
			if (string.IsNullOrWhiteSpace(word)) return "";
			if (word.Any(c => !Char.IsLetter(c))) return "";

			return word.ToUpper();
		}
	}
}
