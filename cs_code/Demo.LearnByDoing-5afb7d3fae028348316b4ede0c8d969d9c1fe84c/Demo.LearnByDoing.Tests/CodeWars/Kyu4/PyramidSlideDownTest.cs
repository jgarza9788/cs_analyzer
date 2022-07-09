using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu4
{
	public class PyramidSlideDownTest : BaseTest
	{
		public PyramidSlideDownTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void SmallPyramidTest()
		{
			var smallPyramid = new[]
			{
				new[] {3},
				new[] {7, 4},
				new[] {2, 4, 6},
				new[] {8, 5, 9, 3}
			};

			Assert.Equal(23, PyramidSlideDown.LongestSlideDown(smallPyramid));
		}

		[Fact]
		public void MediumPyramidTest()
		{
			var mediumPyramid = new[]
			{
				new [] {75},
				new [] {95, 64},
				new [] {17, 47, 82},
				new [] {18, 35, 87, 10},
				new [] {20,  4, 82, 47, 65},
				new [] {19,  1, 23, 75,  3, 34},
				new [] {88,  2, 77, 73,  7, 63, 67},
				new [] {99, 65,  4, 28,  6, 16, 70, 92},
				new [] {41, 41, 26, 56, 83, 40, 80, 70, 33},
				new [] {41, 48, 72, 33, 47, 32, 37, 16, 94, 29},
				new [] {53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14},
				new [] {70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57},
				new [] {91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48},
				new [] {63, 66,  4, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31},
				new [] { 4, 62, 98, 27, 23,  9, 70, 98, 73, 93, 38, 53, 60,  4, 23}
			};

			Assert.Equal(1074, PyramidSlideDown.LongestSlideDown(mediumPyramid));
		}
	}

	public class PyramidSlideDown
	{
		public static int LongestSlideDown(int[][] pyramid)
		{
			List<IEnumerable<int>> triangle = GetTriangle(pyramid);
			return GetMximumPathSum(triangle);
		}

		private static List<IEnumerable<int>> GetTriangle(int[][] pyramid)
		{
			List<IEnumerable<int>> result = new List<IEnumerable<int>>();

			foreach (int[] values in pyramid)
			{
				result.AddRange(new[] {values});
			}

			return result;
		}

		/// <summary>
		/// Work from bottom up instead of top to bottom.
		/// </summary>
		/// <remarks>
		/// https://github.com/dance2die/Problems.ProjectEuler/blob/158a9e4dc4e2297110e4fe4f27d4960b1a8c7209/Demo.ProjectEuler/Demo.ProjectEuler.Tests/0018/MaximumPathSum.cs
		/// </remarks>
		public static int GetMximumPathSum(List<IEnumerable<int>> triangle)
		{
			//List<IEnumerable<int>> triangle = ParseInput(input).ToList();

			var currentLastRow = new List<int>();
			for (int i = triangle.Count - 1; i >= 1; i--)
			{
				var currentLastRowCopy = currentLastRow.ToList();
				var lastRow = currentLastRow.Count > 0 ? currentLastRowCopy : triangle[i].ToList();
				var prevRow = triangle[i - 1].ToList();
				currentLastRow.Clear();

				for (int j = 0; j < prevRow.Count; j++)
				{
					var leftValue = lastRow[j] + prevRow[j];
					var rightValue = lastRow[j + 1] + prevRow[j];

					currentLastRow.Add(Math.Max(leftValue, rightValue));
				}
			}

			return currentLastRow.Sum();
		}

		public static IEnumerable<IEnumerable<int>> ParseInput(string input)
		{
			var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string line in lines)
			{
				yield return line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(s => Convert.ToInt32(s));
			}
		}
	}
}
