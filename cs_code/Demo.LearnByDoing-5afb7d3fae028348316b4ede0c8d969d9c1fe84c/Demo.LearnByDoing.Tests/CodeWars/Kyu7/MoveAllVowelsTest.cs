using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/move-all-vowels/train/csharp
	/// </summary>
	public class MoveAllVowelsTest
	{
		public static IEnumerable<object[]> GetTestCases()
		{
			yield return new object[] { "day", "dya" };
			yield return new object[] { "apple", "pplae" };
			yield return new object[] { "peace", "pceae" };
			yield return new object[] { "maker", "mkrae" };
		}

		[Theory, MemberData(nameof(GetTestCases))]
		public void Test(string input, string expected) =>
			Assert.Equal(expected, Kata.MoveVowel(input));
	}

	public partial class Kata
	{
		public static string MoveVowel(string input)
		{
			var vowels = "aeiouAEIOU";
			var cb = new StringBuilder();
			var vb = new StringBuilder();

			// ".ToList()" is required to iterate.
			input.Select(c => vowels.IndexOf(c.ToString()) >= 0 ? vb.Append(c) : cb.Append(c)).ToList();

			return cb.Append(vb).ToString();
		}
	}
}
