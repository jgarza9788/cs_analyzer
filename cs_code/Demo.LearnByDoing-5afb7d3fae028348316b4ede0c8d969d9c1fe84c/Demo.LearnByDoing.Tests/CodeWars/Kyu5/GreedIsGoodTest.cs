using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	public class GreedIsGoodTest : BaseTest
	{
		public GreedIsGoodTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(new[] { 2, 3, 4, 6, 2 }, 0)]
		[InlineData(new[] { 4, 4, 4, 3, 3 }, 400)]
		[InlineData(new[] { 2, 4, 4, 5, 4 }, 450)]
		[InlineData(new[] { 5, 1, 3, 4, 1 }, 250)]
		[InlineData(new[] { 1, 1, 1, 3, 1 }, 1100)]
		public void TestScoreChecker(int[] dice, int expected)
		{
			int actual = Kata.Score(dice);
			Assert.Equal(expected, actual);
		}
	}

	public partial class Kata
	{
		public static int Score(int[] dice)
		{
			var map = dice.GroupBy(die => die)
				.Select(group => new { Value = group.Key, Count = group.Count() })
				.ToDictionary(item => item.Value, item => item.Count);

			int score = 0;
			if (map.ContainsKey(1) && map[1] >= 3)
			{
				score += 1000;
				map[1] -= 3;
			}

			if (map.ContainsKey(6) && map[6] >= 3)
			{
				score += 600;
				map[6] -= 3;
			}

			if (map.ContainsKey(5) && map[5] >= 3)
			{
				score += 500;
				map[5] -= 3;
			}

			if (map.ContainsKey(4) && map[4] >= 3)
			{
				score += 400;
				map[4] -= 3;
			}
			
			if (map.ContainsKey(3) && (map[3] >= 3))
			{
				score += 300;
				map[3] -= 3;
			}
			
			if (map.ContainsKey(2) && map[2] >= 3)
			{
				score += 200;
				map[2] -= 3;
			}

			if (map.ContainsKey(1) && map[1] >= 1)
			{
				score += (map[1] * 100);
				map.Remove(1);
			}

			if (map.ContainsKey(5) && map[5] >= 1)
			{
				score += (map[5] * 50);
				map.Remove(5);
			}

			return score;
		}
	}
}
