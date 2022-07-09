using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu4
{
	/// <summary>
	/// https://www.codewars.com/kata/58d06bfbc43d20767e000074/train/csharp
	/// </summary>
	public class BattleShipsSunkDamagedOrNotTouchedTest : BaseTest
	{
		public BattleShipsSunkDamagedOrNotTouchedTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void BasicTest1()
		{
			int[,] board = { 
				{ 0, 0, 1, 0 },
				{ 0, 0, 1, 0 },
				{ 0, 0, 1, 0 } };
			int[,] attacks = { { 3, 1 }, { 3, 2 }, { 3, 3 } };
			var result = Kata.damagedOrSunk(board, attacks);
			Console.WriteLine("Test 1 - sunk = 1, damaged = 0, notTouched = 0, points = 1");
			Assert.Equal(1, result["sunk"]);
			Assert.Equal(0, result["damaged"]);
			Assert.Equal(0, result["notTouched"]);
			Assert.Equal(1, result["points"]);
		}

		[Fact]
		public void BasicTest2()
		{
			int[,] board = { 
				{ 3, 0, 1 },
				{ 3, 0, 1 },
				{ 0, 2, 1 },
				{ 0, 2, 0 } };
			int[,] attacks = { { 2, 1 }, { 2, 2 }, { 3, 2 }, { 3, 3 } };
			var result = Kata.damagedOrSunk(board, attacks);
			Console.WriteLine("Test 2 - sunk = 1, damaged = 1, notTouched = 1, points = 0.5");
			Assert.Equal(1, result["sunk"]);
			Assert.Equal(1, result["damaged"]);
			Assert.Equal(1, result["notTouched"]);
			Assert.Equal(0.5, result["points"]);
		}
	}

	public partial class Kata
	{
		public static Dictionary<string, double> damagedOrSunk(int[,] board, int[,] attacks)
		{
			Dictionary<string, double> result = new Dictionary<string, double>
			{
				{ "sunk",  0 },
				{ "damaged", 0 },
				{ "notTouched",  0 },
				{ "points", 0 },
			};

			Dictionary<int, List<ShipStatus>> ships = GetShips(board);
			for (int i = 0; i < attacks.GetLength(0); i++)
			{
				var attackX = (int) attacks.GetValue(i, 0);
				var attackY = (int) attacks.GetValue(i, 1);
				int? attackedShipNumber = GetAttackedShip(ships, attackX, attackY);

				if (attackedShipNumber.HasValue)
				{
					ships[attackedShipNumber.Value]
						.FirstOrDefault(status => status.AttackX == attackX && status.AttackY == attackY)
						.IsHit = true;
				}
			}

			var scores = GetScores(ships);
			result["sunk"] = scores.Item1;
			result["damaged"] = scores.Item2;
			result["notTouched"] = scores.Item3;
			result["points"] = scores.Item4;

			return result;
		}

		private static int? GetAttackedShip(Dictionary<int, List<ShipStatus>> ships, int attackX, int attackY)
		{
			foreach (KeyValuePair<int, List<ShipStatus>> ship in ships)
			{
				if (ship.Value.Any(status => status.AttackX == attackX && status.AttackY == attackY))
					return ship.Key;
			}

			return null;
		}

		private static Dictionary<int, List<ShipStatus>> GetShips(int[,] board)
		{
			var ships = new Dictionary<int, List<ShipStatus>>();

			for (int i = 0; i < board.GetLength(0); i++)
			{
				for (int j = 0; j < board.GetLength(1); j++)
				{
					var shipeNumber = board[i, j];
					if (shipeNumber == 0) continue;

					Tuple<int, int> attackCoord = GetAttackCoord(board, i, j);
					var shipStatus = new ShipStatus(attackCoord.Item1, attackCoord.Item2);

					if (!ships.ContainsKey(shipeNumber))
						ships.Add(shipeNumber, new List<ShipStatus> {shipStatus});
					else
						ships[shipeNumber].Add(shipStatus);
				}
			}

			return ships;
		}

		private static Tuple<int, int> GetAttackCoord(int[,] board, int i, int j)
		{
			var rowLength = board.GetLength(0);

			// attack coord is 1-based.
			int x = j + 1;
			int y = rowLength - i;

			return Tuple.Create(x, y);
		}

		private static Tuple<int, int, int, double> GetScores(Dictionary<int, List<ShipStatus>> ships)
		{
			int sunkCount = 0;
			int damagedCount = 0;
			int notTouchedCount = 0;

			foreach (KeyValuePair<int, List<ShipStatus>> ship in ships)
			{
				if (IsSunk(ship))
					sunkCount++;
				else if (IsNotTouched(ship))
					notTouchedCount++;
				else
					damagedCount += ship.Value.Any(status => status.IsHit) ? 1 : 0;
			}

			double points = sunkCount + (damagedCount * 0.5) + (-1 * notTouchedCount);

			return Tuple.Create(sunkCount, damagedCount, notTouchedCount, points);
		}

		private static bool IsSunk(KeyValuePair<int, List<ShipStatus>> ship)
		{
			return ship.Value.All(status => status.IsHit);
		}

		private static bool IsNotTouched(KeyValuePair<int, List<ShipStatus>> ship)
		{
			return ship.Value.All(status => !status.IsHit);
		}
	}

	public class ShipStatus
	{
		public int AttackX { get; set; }
		public int AttackY { get; set; }
		public bool IsHit { get; set; }

		public ShipStatus(int attackX, int attackY)
		{
			AttackX = attackX;
			AttackY = attackY;
		}
	}
}
