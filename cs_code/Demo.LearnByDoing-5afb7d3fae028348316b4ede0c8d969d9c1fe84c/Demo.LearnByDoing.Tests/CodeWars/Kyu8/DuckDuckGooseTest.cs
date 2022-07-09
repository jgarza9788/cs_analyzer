using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu8
{
	public class DuckDuckGooseTest : BaseTest
	{
		public DuckDuckGooseTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(1, "a")]
		[InlineData(3, "c")]
		[InlineData(10, "z")]
		[InlineData(20, "z")]
		[InlineData(30, "z")]
		[InlineData(18, "g")]
		[InlineData(28, "g")]
		[InlineData(12, "b")]
		[InlineData(2, "b")]
		[InlineData(7, "f")]
		public void DuckDuckGooseTests(int goose, string expected)
		{
			var exampleNames = new[] { "a", "b", "c", "d", "c", "e", "f", "g", "h", "z" };
			var players = exampleNames.Select(x => new Player(x)).ToArray();
			string actual = Kata.DuckDuckGoose(players, goose);

			Assert.Equal(expected, actual);
		}
	}

	public partial class Kata
	{
		public static string DuckDuckGoose(Player[] players, int goose)
		{
			int index = (goose % players.Length) == 0 ? players.Length - 1 : (goose % players.Length) - 1;
			return players[index].Name;
		}
	}

	public class Player
	{
		public string Name { get; set; }

		public Player(string name)
		{
			this.Name = name;
		}
	}
}
