using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/counting-array-elements/train/csharp
	/// </summary>
	public class CountingArrayElementsTest
	{
		[Theory]
		[MemberData(nameof(SampleInput))]
		public void SampleTest(Dictionary<string, int> expected, List<string> input)
		{
			var actual = Kata.Count(input);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> SampleInput()
		{
			yield return new object[] { new Dictionary<string, int> { { "a", 2 }, { "b", 3 } }, new List<string> { "a", "b", "b", "a", "b" } };
			yield return new object[] { new Dictionary<string, int> { { "James", 2 }, { "John", 1 } }, new List<string> { "James", "James", "John" } };
		}
	}

	public partial class Kata
	{
		public static Dictionary<string, int> Count(List<string> list)
		{
			return list.GroupBy(s => s).ToDictionary(d => d.Key, d => d.Count());
		}
	}
}
