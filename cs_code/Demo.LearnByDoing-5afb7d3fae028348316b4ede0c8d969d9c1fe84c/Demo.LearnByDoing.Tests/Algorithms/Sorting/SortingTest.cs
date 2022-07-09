using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.Algorithms.Sorting
{
	public class SortingTest
	{
		[Theory]
		[MemberData(nameof(GetSampleData))]
		public void TestSampleData(int[] expected, int[] input)
		{
			int[] actual = InsertionSort(input);
			Assert.True(expected.SequenceEqual(actual));
		}

		/// <summary>
		/// Perform in-place insertion sort.
		/// <see cref="https://www.youtube.com/watch?v=c4BRHC7kTaQ"/>
		/// </summary>
		/// <remarks>
		/// Best: O(N) when the input is pre-sorted.
		/// Worst: O(N^2) when the input is sorted backwards.
		/// </remarks>
		private int[] InsertionSort(int[] input)
		{
			for (int i = 0; i < input.Length; i++)
			{
				// Compare the current element with next one.
				// Move to left most spot.
				int j = i;
				while (j > 0 && input[j] < input[j - 1])
				{
					Swap(input, j, j - 1);
					j--;
				}
			}

			return input;
		}

		private void Swap(int[] a, int i, int j)
		{
			var temp = a[j];
			a[j] = a[i];
			a[i] = temp;
		}

		public static IEnumerable<object[]> GetSampleData()
		{
			yield return new object[] { new[] { 7, 9, 13, 23, 24, 34, 47, 64 }, new[] { 24, 13, 9, 64, 7, 23, 34, 47 } };
		}
	}
}
