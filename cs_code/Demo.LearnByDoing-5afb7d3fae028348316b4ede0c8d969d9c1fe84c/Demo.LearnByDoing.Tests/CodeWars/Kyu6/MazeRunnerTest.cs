using System;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/maze-runner/train/csharp
	/// </summary>
	public class MazeRunnerTest
	{
		private int[,] maze = new int[,] { { 1, 1, 1, 1, 1, 1, 1 },
										   { 1, 0, 0, 0, 0, 0, 3 },
										   { 1, 0, 1, 0, 1, 0, 1 },
										   { 0, 0, 1, 0, 0, 0, 1 },
										   { 1, 0, 1, 0, 1, 0, 1 },
										   { 1, 0, 0, 0, 0, 0, 1 },
										   { 1, 2, 1, 0, 1, 0, 1 } };

		[TestCase]
		public void FindStartAndEndCoordinates()
		{
			var sut = new Kata();
			var actual = sut.GetStartEndPaoints(maze);
			Tuple<int[], int[]> expected = Tuple.Create(new [] {6, 1}, new[] {1, 6});
			Assert.AreEqual(expected, actual);
		}

		[TestCase]
		public void FinishTest1()
		{
			string[] directions = { "N", "N", "N", "N", "N", "E", "E", "E", "E", "E" };
			Kata test = new Kata();
			string result = test.mazeRunner(maze, directions);
			Assert.AreEqual("Finish", result, "Should return: 'Finish'");
		}

		[TestCase]
		public void FinishTest2()
		{
			string[] directions = { "N", "N", "N", "N", "N", "E", "E", "S", "S", "E", "E", "N", "N", "E" };
			Kata test = new Kata();
			string result = test.mazeRunner(maze, directions);
			Assert.AreEqual("Finish", result, "Should return: 'Finish'");
		}

		[TestCase]
		public void FinishTest3()
		{
			string[] directions = { "N", "N", "N", "N", "N", "E", "E", "E", "E", "E", "W", "W" };
			Kata test = new Kata();
			string result = test.mazeRunner(maze, directions);
			Assert.AreEqual("Finish", result, "Should return: 'Finish'");
		}

		[TestCase]
		public void DeadTest1()
		{
			string[] directions = { "N", "N", "N", "W", "W" };
			Kata test = new Kata();
			string result = test.mazeRunner(maze, directions);
			Assert.AreEqual("Dead", result, "Should return: 'Dead'");
		}

		[TestCase]
		public void DeadTest2()
		{
			string[] directions = { "N", "N", "N", "N", "N", "E", "E", "S", "S", "S", "S", "S", "S" };
			Kata test = new Kata();
			string result = test.mazeRunner(maze, directions);
			Assert.AreEqual("Dead", result, "Should return: 'Dead'");
		}

		[TestCase]
		public void LostTest1()
		{
			string[] directions = { "N", "E", "E", "E", "E" };
			Kata test = new Kata();
			string result = test.mazeRunner(maze, directions);
			Assert.AreEqual("Lost", result, "Should return: 'Lost'");
		}
	}

	public partial class Kata
	{
		/*
			0 = Safe place to walk
			1 = Wall
			2 = Start Point
			3 = Finish Point
		 */
		private const int SAFE = 0;
		private const int WALL = 1;
		private const int START_POINT = 2;
		private const int FINISH_POINT = 3;
		private const int DEAD = 4;

		public string mazeRunner(int[,] maze, string[] directions)
		{

			Func<int, int, bool> isWithinBoundary = (a, b) =>
				maze.GetLowerBound(0) <= a && a <= maze.GetUpperBound(0) &&
				maze.GetLowerBound(1) <= b && b <= maze.GetUpperBound(1);

			var points = GetStartEndPaoints(maze);
			var startPoint = points.Item1;
			var endPoint = points.Item2;

			Func<int, int, int> getPoint = (a, b) =>
			{
				if (!isWithinBoundary(a, b)) return DEAD;
				if (startPoint[0] == a && startPoint[1] == b) return START_POINT;
				if (endPoint[0] == a && endPoint[1] == b) return FINISH_POINT;
				if (maze[a, b] == WALL) return WALL;
				return SAFE;
			};

			int x = startPoint[0];
			int y = startPoint[1];

			foreach (string direction in directions)
			{
				switch (direction)
				{
					case "N": x--; break;
					case "S": x++; break;
					case "E": y++; break;
					case "W": y--; break;
				}

				var point = getPoint(x, y);
				if (point == WALL || point == DEAD)
					return "Dead";

				if (point == FINISH_POINT)
					return "Finish";
			}

			var lastPoint = getPoint(x, y);
			if (lastPoint == SAFE) return "Lost";
			return "Finish";
		}

		public Tuple<int[], int[]> GetStartEndPaoints(int[,] maze)
		{
			int[] start = new int[2];
			int[] end = new int[2];

			for (int i = 0; i <= maze.GetUpperBound(0); i++)
			{
				for (int j = 0; j <= maze.GetUpperBound(1); j++)
				{
					var current = maze[i, j];
					if (current == START_POINT)
						start = new[]{i, j};
					if (current == FINISH_POINT)
						end = new[] {i, j};
				}
			}

			return Tuple.Create(start, end);
		}
	}
}
