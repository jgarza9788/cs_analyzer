using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/indexed-capitalization/train/csharp
	/// </summary>
	public class IndexedCapitalizationTest
	{
		public static IEnumerable<object[]> GetTestCases()
		{
			yield return new object[]{"abcdef", new List<int> { 1, 2, 5 }, "aBCdeF"};
			yield return new object[]{"abcdef", new List<int> { 1, 2, 5, 100 }, "aBCdeF" };
			yield return new object[]{"abcdef", new List<int> { 1, 100, 2, 5 }, "aBCdeF" };
			yield return new object[]{"codewars", new List<int> { 1, 3, 5, 50 }, "cOdEwArs" };
			yield return new object[]{"abracadabra", new List<int> { 2, 6, 9, 10 }, "abRacaDabRA" };
			yield return new object[]{"codewarriors", new List<int> { 5 }, "codewArriors" };
			yield return new object[]{"indexinglessons", new List<int> { 0 }, "Indexinglessons" };
		}

		[Theory, MemberData(nameof(GetTestCases))]
		public void Test(string input, List<int> indexes, string expected)
		{
			var actual = Kata.Capitalize(input, indexes);
			Assert.Equal(expected, actual);
		}
	}

	public partial class Kata
	{
		public static string Capitalize(string input, List<int> idxs)
		{
			// Create a Dictionary for O(1) lookup.
			var indexes = idxs.Where(n => n < input.Length).Distinct().ToDictionary(n => n, n => n);
			return string.Concat(input.Select((c, i) => indexes.ContainsKey(i) ? char.ToUpper(c) : c));
		}
	}
}
