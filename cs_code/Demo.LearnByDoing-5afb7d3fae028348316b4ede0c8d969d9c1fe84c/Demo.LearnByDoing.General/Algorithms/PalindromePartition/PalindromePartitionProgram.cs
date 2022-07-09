using System;
using System.Diagnostics;
using Demo.LearnByDoing.Core;

namespace Demo.LearnByDoing.General.Algorithms.PalindromePartition
{
	/// <summary>
	/// Implementation of Palindrome Partitioning using Dynamic Programming
	/// after watching a video by Tushar Roy on https://youtu.be/lDYIvtBVmgo
	/// </summary>
	public class PalindromePartitionProgram
	{
		public static void Main(string[] args)
		{
			const string word = "abcbm";
			int minimumSplitCount = GetMinimumPalindromeSplitCount(word);
			Console.WriteLine(minimumSplitCount);
		}

		private static readonly PalinedromeChecker palinedromeChecker = new PalinedromeChecker();

		private static int GetMinimumPalindromeSplitCount(string word)
		{
			// initial matrix is initialized with all 0's.
			int[,] matrix = new int[word.Length, word.Length];

			for (int length = 1; length <= word.Length; length++)
			{
				for (int i = 0; i <= word.Length - length; i++)
				{
					int j = i + length - 1;
					if (palinedromeChecker.IsPalindrome(word.Substring(i, length)))
					{
						matrix[i, j] = 0;
					}
					else
					{
						matrix[i, j] = GetMinimumBetween(matrix, i, j);
					}
				}
			}

			PrintMatrix(matrix);

			return matrix[0, word.Length - 1];
		}

		private static int GetMinimumBetween(int[,] matrix, int i, int j)
		{
			var value = 1 + matrix[i, i] + matrix[i + 1, j];
			int min = value;

			for (int k = i; k <= j - 1; k++)
			{
				value = 1 + matrix[i, k] + matrix[k + 1, j];
				if (min > value)
					min = value;
			}

			return min;
		}

		private static void PrintMatrix(int[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				string line = "";
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					line += matrix[i, j] + " ";
				}
				Debug.Print(line);
			}
		}
	}
}
