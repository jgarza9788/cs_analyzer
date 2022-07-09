using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	/// <summary>
	/// https://www.codewars.com/kata/where-my-anagrams-at/train/csharp
	/// </summary>
	public class WhereMyAnagramsAtTest
	{
		[Test]
		public void SampleTest()
		{
			Assert.AreEqual(new List<string> { "a" }, Kata.Anagrams("a", new List<string> { "a", "b", "c", "d" }));
			Assert.AreEqual(new List<string> { "carer", "arcre", "carre" }, Kata.Anagrams("racer", new List<string> { "carer", "arcre", "carre", "racrs", "racers", "arceer", "raccer", "carrer", "cerarr" }));
		}

		//[Test]
		//public void CheckForDuplicateAndReturnOnlyDistinctList()
		//{
		//	Assert.AreEqual(new List<string> { "a" }, Kata.Anagrams("a", new List<string> { "a", "b", "a", "d" }));
		//	Assert.AreEqual(new List<string> { "carer", "arcre", "carre" }, 
		//		Kata.Anagrams("racer", new List<string> { "carer", "arcre", "carre", "carer", "racers", "arceer", "arcre", "carrer", "cerarr" }));
		//}

		[Test]
		public void TestEdgeCases()
		{
			var expected = new List<string>();
			string word = null;
			List<string> words = null;

			var actual = Kata.Anagrams(word, words);
			Assert.AreEqual(expected, actual);
		}
	}

	public static partial class Kata
	{
		public static List<string> Anagrams(string input, List<string> words)
		{
			// Edge case.
			if (words == null || words.Count == 0) return new List<string>();

			// Iterate the words and compare with the word.
			// How do I compare? How do I know if a word is an anagram of another word?

			var result = new List<string>();
			foreach (var word in words)
			{
				if (IsAganram(word, input))
					result.Add(word);
			}

			return result;
		}

		private static bool IsAganram(string word1, string word2)
		{
			return word1.OrderBy(c => c).SequenceEqual(word2.OrderBy(c => c));
		}
	}
}
