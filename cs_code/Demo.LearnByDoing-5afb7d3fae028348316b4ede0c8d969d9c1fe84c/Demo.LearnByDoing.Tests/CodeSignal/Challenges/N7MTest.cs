using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeSignal.Challenges
{
	/// <summary>
	/// https://codefights.com/challenge/6iWifbDCGEGsB396e
	/// 
	/// You have to detect long words and convert them into their numeronym counterparts. A numeronym is the shortening of a long word by only keeping the first 1-2 letters and the last letter, replacing everything in between with the number of letters removed. Also, it is always all lowercase, regardless of their placement in a sentence.
	/// 
	/// A vowel is any of aeiou. If the second letter is not a vowel, it is kept, otherwise it is part of the letters to replace.
	/// 
	/// Example where the second letter is a vowel: Numeronym -&gt; N (length of "umerony") m -&gt; n7m
	/// 
	/// Example where the second letter is not a vowel: Translation -&gt; tr (length of "anslatio") n -&gt; tr8n
	/// 
	/// Given a sentence, replace all words (alphabetic sequences) into numeronyms if the result is shorter than the original word.
	/// 
	/// Example
	/// For sentence = "Shorten this text.", the output should be
	/// n9m(sentence) = "sh4n this t2t.".
	/// 
	/// Input/Output
	/// 
	/// [execution time limit] 3 seconds (cs)
	/// 
	/// [input] string sentence
	/// 
	/// A sentence. It consists of alphabetical characters (which makes up words), spaces and punctuation (any of .,;:?!-"'()/).
	/// 
	/// Guaranteed constraints:
	/// sentence.length &lt; 1000.
	/// 
	/// [output] string
	/// 
	/// The new sentence, long words are replaced with their numeronym counterparts.
	/// </summary>
	public class N7MTest
	{
		[Theory]
		[MemberData(nameof(GetSampleCases))]
		public static void TestSampleCases(string sentence, string expected)
		{
			var actual = n7m(sentence);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetSampleCases()
		{
			yield return new object[]{ "Numeronym", "n7m" };
			yield return new object[]{ "Translation", "tr8n" };
			yield return new object[]{ "Shorten this text.", "sh4n this t2t." };
			yield return new object[]{ "Shorten this text.", "sh4n this t2t." };
		}

		[Theory]
		[MemberData(nameof(GetSampleWords))]
		public static void TestWordShortening(string word, string expected)
		{
			var actual = ShortenWord(word);
			Assert.Equal(expected, actual);
		}

		static string n7m(string sentence)
		{
			var words = sentence.ToLower().Split().Select(ShortenWord);
			return string.Join(" ", words);
		}

		private static string ShortenWord(string input)
		{
			var word = input.ToLower();
			var punctuations = string.Concat(input.Where(c => !char.IsLetter(c)));
			var secondLetter = word[1];
			var vowels = new[] {'a', 'e', 'i', 'o', 'u'};
			var isSecondLetterConsonant = !vowels.Contains(secondLetter);

			const int firstLastWordCount = 2;
			var lengthBetween = word.Length - firstLastWordCount - punctuations.Length - (isSecondLetterConsonant ? 1 : 0);
			if (lengthBetween <= 1) return word;

			var secondChar = isSecondLetterConsonant ? word[1].ToString() : "";
			return $"{word[0]}{secondChar}{lengthBetween}{word[word.Length - 1 - punctuations.Length]}{punctuations}";
		}

		public static IEnumerable<object[]> GetSampleWords()
		{
			yield return new object[] { "Numeronym", "n7m" };
			yield return new object[] { "Translation", "tr8n" };
			yield return new object[] { "Shorten", "sh4n" };
			yield return new object[] { "this", "this" };
			yield return new object[] { "text", "t2t" };
			yield return new object[] { "text.", "t2t." };
			yield return new object[] { "it", "it" };
			yield return new object[] { "itt", "itt" };
			yield return new object[] { "itt.", "itt." };
			yield return new object[] { "ittt.", "ittt." };
		}
	}
}
