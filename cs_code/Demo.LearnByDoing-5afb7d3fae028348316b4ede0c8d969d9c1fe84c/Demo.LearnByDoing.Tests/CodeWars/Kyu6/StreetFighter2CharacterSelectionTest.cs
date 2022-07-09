using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/street-fighter-2-character-selection/train/csharp
	/// </summary>
	public class StreetFighter2CharacterSelectionTest
	{
		private Kata kata = new Kata();
		private string[][] fighters;

		public StreetFighter2CharacterSelectionTest()
		{
			this.fighters = new string[][]
			{
			  new string[] { "Ryu", "E.Honda", "Blanka", "Guile", "Balrog", "Vega" },
			  new string[] { "Ken", "Chun Li", "Zangief", "Dhalsim", "Sagat", "M.Bison" },
			};
		}


		[Test]
		public void _01_ShouldWorkWithFewMoves()
		{
			var moves = new string[] { "up", "left", "right", "left", "left" };
			var expected = new string[] { "Ryu", "Vega", "Ryu", "Vega", "Balrog" };

			CollectionAssert.AreEqual(expected, kata.StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));
		}

		[Test]
		public void _02_ShouldWorkWithNoSelectionCursorMoves()
		{
			var moves = new string[] { };
			var expected = new string[] { };

			CollectionAssert.AreEqual(expected, kata.StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));
		}

		[Test]
		public void _03_ShouldWorkWhenAlwaysMovingLeft()
		{
			var moves = new string[] { "left", "left", "left", "left", "left", "left", "left", "left" };
			var expected = new string[] { "Vega", "Balrog", "Guile", "Blanka", "E.Honda", "Ryu", "Vega", "Balrog" };

			CollectionAssert.AreEqual(expected, kata.StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));
		}

		[Test]
		public void _04_ShouldWorkWhenAlwaysMovingRight()
		{
			var moves = new string[] { "right", "right", "right", "right", "right", "right", "right", "right" };
			var expected = new string[] { "E.Honda", "Blanka", "Guile", "Balrog", "Vega", "Ryu", "E.Honda", "Blanka" };

			CollectionAssert.AreEqual(expected, kata.StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));
		}

		[Test]
		public void _05_ShouldUseAll4DirectionsClockwiseTwice()
		{
			var moves = new string[] { "up", "left", "down", "right", "up", "left", "down", "right" };
			var expected = new string[] { "Ryu", "Vega", "M.Bison", "Ken", "Ryu", "Vega", "M.Bison", "Ken" };

			CollectionAssert.AreEqual(expected, kata.StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));
		}

		[Test]
		public void _06_ShouldWorkWhenAlwaysMovingDown()
		{
			var moves = new string[] { "down", "down", "down", "down" };
			var expected = new string[] { "Ken", "Ken", "Ken", "Ken" };

			CollectionAssert.AreEqual(expected, kata.StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));
		}

		[Test]
		public void _07_ShouldWorkWhenAlwaysMovingUp()
		{
			var moves = new string[] { "up", "up", "up", "up" };
			var expected = new string[] { "Ryu", "Ryu", "Ryu", "Ryu" };

			CollectionAssert.AreEqual(expected, kata.StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));
		}
	}

	partial class Kata
	{
		public string[] StreetFighterSelection(string[][] fighters, int[] position, string[] moves)
		{
			int x = position[0];
			int y = position[1];

			var moveMap = new Dictionary<string, Action>
			{
				{"up", () => y = y - 1 < 0 ? 0 : y - 1 },
				{"left", () => x = x - 1 < 0 ? fighters[0].Length - 1 : x - 1 },
				{"down", () => y = y + 1 >= fighters.Length ? fighters.Length - 1 : y + 1 },
				{"right", () => x = x + 1 >= fighters[0].Length ? 0 : x + 1 }
			};

			var result = moves.ToList().Aggregate(new List<string>(), (acc, move) =>
			{
				moveMap[move]();
				acc.Add(fighters[y][x]);
				return acc;
			});

			return result.ToArray();

			// old iterative implementation
			//foreach (string move in moves)
			//{
			//	switch (move)
			//	{
			//		case "up":
			//			y = y - 1 < 0 ? 0 : y - 1;
			//			break;
			//		case "left":
			//			x = x - 1 < 0 ? fighters[0].Length - 1 : x - 1;
			//			break;
			//		case "down":
			//			y = y + 1 >= fighters.Length ? fighters.Length - 1 : y + 1;
			//			break;
			//		case "right":
			//			x = x + 1 >= fighters[0].Length ? 0 : x + 1;
			//			break;
			//	}

			//	result.Add(fighters[y][x]);
			//}

			//return result.ToArray();
		}
	}
}
