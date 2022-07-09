using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	public class RememberTest
	{
		[Theory]
		[MemberData(nameof(GetTestData))]
		public void Test(string str, List<char> expected)
		{
			var actual = Kata.Remember(str);
			Assert.True(expected.SequenceEqual(actual));
		}

		public static IEnumerable<object[]> GetTestData()
		{
			yield return new object[] { "limbojackassin the garden", new List<char> { 'a', 's', 'i', ' ', 'e', 'n' } };
			//yield return new object[] { "apple", new List<char> { 'p' } };
			//yield return new object[] { "11pinguin", new List<char> { '1', 'i', 'n' } };
		}
	}

	public partial class Kata
	{
		public static List<char> Remember(string str)
		{
			//return str.Select(c => c)
			//	.GroupBy(c => c)
			//	.Select(g => new {g.Key, Count = g.Count()})
			//	.Where(o => o.Count > 1)
			//	.Select(arg => arg.Key)
			//	.ToList();

			return str
				.Select((x, i) => Tuple.Create(x, i))
				.GroupBy(x => x.Item1)
				.Where(x => x.Count() >= 2)
				.OrderBy(x => x.ElementAt(1).Item2)
				.Select(x => x.Key)
				.ToList();

			//var map = new HashSet<char>();
			//var result = new List<char>();

			//foreach (char c in str)
			//{
			//	if (map.Contains(c))
			//	{
			//		if (!result.Contains(c))
			//			result.Add(c);
			//	}
			//	else map.Add(c);
			//}

			//return result;
		}
	}
}
