using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	public class TwoToOneTest : BaseTest
	{
		public TwoToOneTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public static void TestAll()
		{
			Assert.Equal("aehrsty", TwoToOne.Longest("aretheyhere", "yestheyarehere"));
			Assert.Equal("abcdefghilnoprstu", TwoToOne.Longest("loopingisfunbutdangerous", "lessdangerousthancoding"));
			Assert.Equal("acefghilmnoprstuy", TwoToOne.Longest("inmanylanguages", "theresapairoffunctions"));
		}
	}

	public class TwoToOne
	{
		public static string Longest(string s1, string s2)
		{
			var set1 = new HashSet<char>(s1);
			var set2 = new HashSet<char>(s2);
			return string.Concat(set1.Union(set2).OrderBy(c => c));

			return string.Concat(s1.Union(s2).Distinct().OrderBy(x => x));
		}
	}
}
