using System.Collections.Generic;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	public class DirectionsReductionTest : BaseTest
	{
		public DirectionsReductionTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(new [] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" }, new []{ "WEST" })]
		[InlineData(new [] { "NORTH", "WEST", "SOUTH", "EAST" }, new []{ "NORTH", "WEST", "SOUTH", "EAST" })]
		[InlineData(new [] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH" }, new []{ "" })]
		public void TestDirectionReduce(string[] input, string[] expected)
		{
			string[] actual = DirReduction.dirReduc(input);
			Assert.Equal(expected, actual);
		}
	}

	public class DirReduction
	{

		public static string[] dirReduc(string[] input)
		{
			var oppositionMap = new Dictionary<string, string>
			{
				{ "NORTH", "SOUTH" },
				{ "SOUTH", "NORTH" },
				{ "EAST", "WEST" },
				{ "WEST", "EAST" }
			};
			var directions = new List<string>(input);

			for (int i = 1; i < directions.Count; i++)
			{
				var prev = directions[i - 1];
				var curr = directions[i];
				if (oppositionMap[curr] == prev)
				{
					directions.RemoveRange(i - 1, 2);
					i = 0;
				}
			}

			return directions.Count == 0 ? new [] {""} : directions.ToArray();
		}
	}
}
