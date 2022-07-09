using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	/// <summary>
	/// https://www.codewars.com/kata/did-i-finish-my-sudoku/train/csharp
	/// </summary>
	public class DidIFinishMySudokuTest
	{
		private static object[] testCases = new object[]
		{
			new object[]
			{
				"Finished!",
				new int[][]
				{
					new int[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
					new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
					new int[] {1, 9, 8, 3, 4, 2, 5, 6, 7},
					new int[] {8, 5, 9, 7, 6, 1, 4, 2, 3},
					new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
					new int[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
					new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
					new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
					new int[] {3, 4, 5, 2, 8, 6, 1, 7, 9},
				},
			},
			new object[]
			{
				"Try again!",
				new int[][]
				{
					new int[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
					new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
					new int[] {1, 9, 8, 3, 0, 2, 5, 6, 7},
					new int[] {8, 5, 0, 7, 6, 1, 4, 2, 3},
					new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
					new int[] {7, 0, 3, 9, 2, 4, 8, 5, 6},
					new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
					new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
					new int[] {3, 0, 0, 2, 8, 6, 1, 7, 9},
				},
			},
		};

		[Test, TestCaseSource("testCases")]
		public void Test(string expected, int[][] board) => Assert.AreEqual(expected, Sudoku.DoneOrNot(board));
	}

	public class Sudoku
	{
		private const int BOARD_SIZE = 9;

		public static string DoneOrNot(int[][] board)
		{
			const string failureMessage = "Try again!";
			const string successMessage = "Finished!";

			// check all rows
			bool areRowsValid = AreRowsValid(board);
			if (!areRowsValid) return failureMessage;

			// check all columns
			bool areColumnsValid = AreColumnsValid(board);
			if (!areColumnsValid) return failureMessage;

			// check 9 blocks
			bool areBlocksValid = AreBlocksValid(board);
			if (!areBlocksValid) return failureMessage;

			return successMessage;
		}

		private static bool AreRowsValid(int[][] board)
		{
			foreach (int[] row in board)
			{
				if (!ContainsAllNumbers(row)) return false;
			}

			return true;
		}

		private static bool AreColumnsValid(int[][] board)
		{
			for (int colIndex = 0; colIndex < BOARD_SIZE; colIndex++)
			{
				var columnValues = GetColumnValues(board, colIndex);
				if (!ContainsAllNumbers(columnValues)) return false;
			}

			return true;
		}

		private static IEnumerable<int> GetColumnValues(int[][] board, int index)
		{
			for (int i = 0; i < BOARD_SIZE; i++)
			{
				yield return board[index][i];
			}
		}

		private static bool AreBlocksValid(int[][] board)
		{
			for (int rowIndex = 0, upto = 0; upto < 3; upto++, rowIndex += 3)
			{
				for (int colIndex = 0; colIndex < 3; colIndex++)
				{
					int startIndex = colIndex * 3;
					var blockValues = GetBlockValues(board, rowIndex, startIndex);
					if (!ContainsAllNumbers(blockValues)) return false;
				}
			}

			return true;
		}

		private static IEnumerable<int> GetBlockValues(int[][] board, int rowIndex, int colIndex)
		{
			for (int i = rowIndex; i < rowIndex + 3; i++)
			{
				for (int j = colIndex; j < colIndex + 3; j++)
				{
					yield return board[i][j];
				}
			}
		}

		private static bool ContainsAllNumbers(IEnumerable<int> row)
		{
			return !Enumerable.Range(1, 9).Except(row).Any();
		}
	}
}
