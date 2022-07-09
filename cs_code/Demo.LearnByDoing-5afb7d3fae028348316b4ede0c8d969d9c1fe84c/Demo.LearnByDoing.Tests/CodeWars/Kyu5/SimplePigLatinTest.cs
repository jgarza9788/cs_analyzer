using System;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	/// <summary>
	/// https://www.codewars.com/kata/520b9d2ad5c005041100000f/train/csharp
	/// </summary>
	public class SimplePigLatinTest : BaseTest
	{
		public SimplePigLatinTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData("Pig latin is cool", "igPay atinlay siay oolcay")]
		[InlineData("This is my string", "hisTay siay ymay tringsay")]
		public void TestSentenceLatinPigging(string sentence, string expected)
		{
			string actual = Kata.PigIt(sentence);
			Assert.Equal(expected, actual);
		}
	}

	public partial class Kata
	{
		public static string PigIt(string sentence)
		{
			string[] words = sentence.Split(new[]{" "}, StringSplitOptions.RemoveEmptyEntries);
			var piggedWords = words.Select(word => $"{word.Substring(1)}{word[0]}ay");
			return string.Join(" ", piggedWords);
		}
	}
}
