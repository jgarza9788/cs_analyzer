using System.Collections.Generic;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	public class BuildTowerTest : BaseTest
	{
		public BuildTowerTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void BasicTests()
		{
			Assert.Equal(string.Join(",", new[] { "*" }), string.Join(",", Kata.TowerBuilder(1)));
			Assert.Equal(string.Join(",", new[] { " * ", "***" }), string.Join(",", Kata.TowerBuilder(2)));
			Assert.Equal(string.Join(",", new[] { "  *  ", " *** ", "*****" }), string.Join(",", Kata.TowerBuilder(3)));
		}
	}

	public partial class Kata
	{
		public static string[] TowerBuilder(int floorCount)
		{
			List<string> floors = new List<string>(floorCount);

			for (int i = floorCount, j = 1; i >= 1; i--, j+=2)
			{
				var pad = new string(' ', i - 1);
				var stars = new string('*', j);
				floors.Add(string.Format("{0}{1}{0}", pad, stars));
			}

			return floors.ToArray();
		}
	}
}
