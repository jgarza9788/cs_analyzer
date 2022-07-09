using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/format-words-into-a-sentence/train/csharp
	/// </summary>
	public class FormatWordsIntoASentenceTest : BaseTest
	{
		public FormatWordsIntoASentenceTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[MemberData(nameof(GetNumbers))]
		public void Test(string expected, string[] words)
		{
			Assert.Equal(expected, Kata.FormatWords(words));
		}

		[Fact]
		public void TestEdgeCases()
		{
			Assert.Equal("", Kata.FormatWords(new string[] {}));
			Assert.Equal("", Kata.FormatWords(null));
			Assert.Equal("", Kata.FormatWords(new[] {""}));
			Assert.Equal("", Kata.FormatWords(new[] {"", ""}));
		}

		public static IEnumerable<object[]> GetNumbers()
		{
			yield return new object[] { "one, two, three and four", new[] { "one", "two", "three", "four" } };
			yield return new object[] { "one", new[] { "one" } };
			yield return new object[] { "one and three", new[] { "one", "", "three" } };
			yield return new object[] { "three", new[] { "", "", "three" } };
			yield return new object[] { "one and two", new[] { "one", "two", "" } };
		}
	}

	public partial class Kata
	{
		public static string FormatWords(string[] words)
		{
			// Edge case guard condition.
			if (words == null || words.Length == 0 || words.All(string.IsNullOrWhiteSpace)) return string.Empty;

			List<string> wordsOnly = words.Where(word => !string.IsNullOrWhiteSpace(word)).ToList();
			if (wordsOnly.Count == 1) return wordsOnly.FirstOrDefault();
			if (wordsOnly.Count == 2) return string.Join(" and ", wordsOnly);

			string left = string.Join(", ", wordsOnly.Take(wordsOnly.Count - 1));
			string right = wordsOnly.LastOrDefault();

			return string.Format("{0} and {1}", left, right);
		}
	}
}
