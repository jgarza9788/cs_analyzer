using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	public class TicTacToeCheckerTest : BaseTest
	{
		public TicTacToeCheckerTest(ITestOutputHelper output) : base(output)
		{
		}

		//[Theory]
		//[ClassData(typeof(TicTacToeCheckerTestData))]
		[Fact]
		//public void TestTicTacToeChecker(int[,] board, int expected)
		public void TestTicTacToeChecker()
		{
			int[,] board = new int[,] { { 0, 1, 1 }, { 2, 0, 2 }, { 2, 1, 0 } };
			const int expected = -1;
			int actual = new TicTacToe().IsSolved(board);
			Assert.Equal(expected, actual);
		}
	}

	public class TicTacToe
	{
		public int IsSolved(int[,] board)
		{
			bool isSolved = false;
			List<List<int>> list = Enumerable.Range(0, board.GetLength(0))
				.Select(row => Enumerable.Range(0, board.GetLength(1))
					.Select(col => board[row, col]).ToList()).ToList();

			// Check all rows
			for (int i = 0; i < board.GetLength(0); i++)
			{
				// check rows: "i" is row index here
				if (board[i, 0] != 0 && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2]) return board[i, 0];

				// check cols: "i" is col index here
				if (board[0, i] != 0 && board[0, i] == board[1, i] && board[1, i] == board[2, i]) return board[0, i];
			}

			// Check diagonal
			// left to right
			if (board[0, 0] != 0 && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) return board[0, 0];
			// right to left
			if (board[0, 2] != 0 && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]) return board[0, 0];

			// Is game over?
			return list.Any(l => l.Contains(0)) ? -1 : 0;
		}
	}

	public class TicTacToeCheckerTestData : BaseTestData
	{
		public override List<object[]> Data { get; set; } = new List<object[]>
		{
			new object[] { new[,] { { 1, 1, 0 }, { 0, 2, 0 }, { 0, 0, 0 } }, 0},
			new object[] { new[,] { { 0, 1, 0 }, { 0, 2, 0 }, { 0, 0, 0 } }, 0},
			new object[] { new[,] { { 1, 1, 1 }, { 0, 2, 0 }, { 0, 0, 0 } }, 1},
			new object[] { new[,] { { 0, 0, 2 }, { 1, 1, 1 }, { 0, 0, 0 } }, 1},
			new object[] { new[,] { { 0, 0, 2 }, { 0, 0, 0 }, { 1, 1, 1 } }, 1},
			new object[] { new[,] { { 2, 0, 2 }, { 2, 0, 0 }, { 2, 1, 1 } }, 2},
			new object[] { new[,] { { 1, 2, 2 }, { 1, 2, 0 }, { 2, 2, 1 } }, 2},
			new object[] { new[,] { { 1, 2, 2 }, { 1, 2, 2 }, { 2, 1, 2 } }, 2},
			new object[] { new[,] { { 1, 0, 2 }, { 0, 1, 2 }, { 0, 0, 1 } }, 1},
			new object[] { new[,] { { 1, 0, 2 }, { 0, 2, 1 }, { 2, 0, 1 } }, 2},
		};
	}
}
