using System;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/words-to-hex/train/csharp
	/// </summary>
	public class WordsToHexTest
	{
		[Test, Description("It should handle sample test cases")]
		public void SampleTest()
		{
			Assert.AreEqual(new[] { "#48656c", "#6d7900", "#6e616d", "#697300", "#476172", "#616e64", "#490000", "#6c696b", "#636865" }, Kata.WordsToHex("Hello, my name is Gary and I like cheese."));
			Assert.AreEqual(new[] { "#303132" }, Kata.WordsToHex("0123456789"));
			Assert.AreEqual(new[] { "#546869" }, Kata.WordsToHex("ThisIsOneLongSentenceThatConsistsOfWords"));
			Assert.AreEqual(new[] { "#426c61", "#626c61", "#626c61", "#626c61" }, Kata.WordsToHex("Blah blah blah blaaaaaaaaaaaah"));
			Assert.AreEqual(new[] { "#262626", "#242424", "#5e5e5e", "#404040", "#282928" }, Kata.WordsToHex("&&&&& $$$$$ ^^^^^ @@@@@ ()()()()("));
		}
	}

	partial class Kata
	{
		public static string[] WordsToHex(string sentence)
		{
			string[] words = sentence.Split();
			for (int i = 0; i < words.Length; i++)
			{
				var word = words[i];

				// convert the word into a hex representation.
				var hex = ConvertToHex(word);

				// assign it to the hex representation to the current index.
				words[i] = hex;
			}

			return words;
		}

		private static string ConvertToHex(string word)
		{
			Func<char?, string> toHex = c => c.HasValue ? Convert.ToByte(c).ToString("x2") : "00";

			string result = "#";
			for (int i = 0; i < 3; i++)
			{
				if (word.Length > i)
					result += toHex(word[i]);
				else
					result += toHex(null);
			}
			return result;
		}
	}
}
