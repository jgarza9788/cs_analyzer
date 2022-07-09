using System;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Algorithms
{
	/// <summary>
	/// Learned about Levenshtein Distance algorithm but came up with implementation algorithm by myself.
	/// https://www.youtube.com/watch?v=We3YDTzNXEk
	/// </summary>
	public class LevenshteinDistanceTest : BaseTest
	{
		public LevenshteinDistanceTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void BaseCaseTest()
		{
			string s1 = "azced";
			string s2 = "abcdef";
			// distance between two: 1 delete & 2 updates
			// f => d, delete "d", b => "z"
			const int expected = 3;

			int actual = new LevenshteinDistance().Calculate(s1, s2);
			Assert.Equal(expected, actual);
		}
	}

	public class LevenshteinDistance
	{
		public int Calculate(string s1, string s2)
		{
			int[,] matrix = BuildMatrix(s1, s2);

			for (int i = 0; i < s1.Length; i++)
			{
				char c1 = s1[i];
				for (int j = 0; j < s2.Length; j++)
				{
					char c2 = s2[j];

					if (c1 == c2)
					{
						matrix[i + 1, j + 1] = matrix[i, j];
					}
					else
					{
						matrix[i + 1, j + 1] = new[] { matrix[i, j], matrix[i, j + 1], matrix[i + 1, j] }.Min() + 1;
					}
				}
			}

			// return the last row and last column index value.
			return matrix[s1.Length, s2.Length];
		}

		private int[,] BuildMatrix(string s1, string s2)
		{
			int[,] matrix = new int[s1.Length + 1, s2.Length + 1];

			for (int i = 0; i <= s2.Length; i++)
			{
				matrix[0, i] = i;
			}

			for (int i = 0; i <= s1.Length; i++)
			{
				matrix[i, 0] = i;
			}

			return matrix;
		}

		private void PrintMatrix(int[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				string row = "";
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					row += matrix[i, j];
				}

				Console.WriteLine(row);
			}
		}
	}
}
