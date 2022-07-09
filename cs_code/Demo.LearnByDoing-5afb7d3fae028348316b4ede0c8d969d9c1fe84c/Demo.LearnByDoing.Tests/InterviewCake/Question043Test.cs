using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/merge-sorted-arrays
	/// 
	///   In order to win the prize for most cookies sold, my friend Alice and I are going to merge our Girl Scout Cookies orders and enter as one unit.
	/// 
	/// Each order is represented by an "order id" (an integer).
	/// 
	/// We have our lists of orders sorted numerically already, in arrays. Write a method to merge our arrays of orders into one sorted array.
	/// 
	/// For example:
	/// 
	/// int[] myArray = { 3, 4, 6, 10, 11, 15 };
	/// int[] alicesArray = { 1, 5, 8, 12, 14, 19 };
	/// 
	/// // Prints [1, 3, 4, 5, 6, 8, 10, 11, 12, 14, 15, 19]
	/// Console.WriteLine(MergeArrays(myArray, alicesArray));
	/// </summary>
	public class Question043Test
	{
		[Fact]
		public void TestSampleCase()
		{
			int[] myArray = { 3, 4, 6, 10, 11, 15 };
			int[] alicesArray = { 1, 5, 8, 12, 14, 19 };

			int[] expected = {1, 3, 4, 5, 6, 8, 10, 11, 12, 14, 15, 19};
			var actual = MergeArrays(myArray, alicesArray);

			Assert.True(expected.SequenceEqual(actual));
		}

		private IEnumerable<int> MergeArrays(int[] a1, int[] a2)
		{
			int i = 0, j = 0;
			while (true)
			{
				if (i == a1.Length && j == a2.Length) yield break;

				if (i == a1.Length)
				{
					yield return a2[j];
					j++;
				}
				else if (j == a2.Length)
				{
					yield return a1[i];
					i++;
				}
				else
				{
					if (a1[i] <= a2[j])
					{
						yield return a1[i];
						i++;
					}
					else
					{
						yield return a2[j];
						j++;
					}
				}
			}

			//for (int i = 0, j = 0; i < a1.Length && j < a2.Length; i++, j++)
			//{
			//	if 

			//	int left = a1[i];
			//	int right = a2[j];
			//	if (left < right)
			//	{
			//		yield return left;
			//		i++;
			//	}
			//}
		}
	}
}
