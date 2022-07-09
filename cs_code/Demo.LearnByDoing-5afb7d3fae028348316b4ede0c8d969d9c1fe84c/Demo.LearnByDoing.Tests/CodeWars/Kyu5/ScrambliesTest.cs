using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	/// <summary>
	/// https://www.codewars.com/kata/scramblies/train/csharp
	/// </summary>
	public class ScrambliesTest : BaseTest
	{
		public ScrambliesTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public static void Test1()
		{
			Assert.Equal(Scramblies.Scramble("rkqodlw", "world"), true);
			Assert.Equal(Scramblies.Scramble("cedewaraaossoqqyt", "codewars"), true);
			Assert.Equal(Scramblies.Scramble("katas", "steak"), false);
			Assert.Equal(Scramblies.Scramble("scriptjavx", "javascript"), false);
			Assert.Equal(Scramblies.Scramble("scriptingjava", "javascript"), true);
			Assert.Equal(Scramblies.Scramble("scriptsjava", "javascripts"), true);
			Assert.Equal(Scramblies.Scramble("javscripts", "javascript"), false);
			Assert.Equal(Scramblies.Scramble("aabbcamaomsccdd", "commas"), true);
			Assert.Equal(Scramblies.Scramble("commas", "commas"), true);
			Assert.Equal(Scramblies.Scramble("sammoc", "commas"), true);
		}
	}

	public class Scramblies
	{
		public static bool Scramble(string s1, string s2)
		{
			Func<string, Dictionary<char, int>> toMap = s =>
				s.GroupBy(c => c)
				.Select(g => new { g.Key, Count = g.Count() })
				.ToDictionary(pair => pair.Key, pair => pair.Count);

			var map1 = toMap(s1);
			var map2 = toMap(s2);

			foreach (KeyValuePair<char, int> p2 in map2)
			{
				if (!map1.ContainsKey(p2.Key)) return false;

				if (map1[p2.Key] < p2.Value) return false;
			}

			return true;
		}
	}
}
