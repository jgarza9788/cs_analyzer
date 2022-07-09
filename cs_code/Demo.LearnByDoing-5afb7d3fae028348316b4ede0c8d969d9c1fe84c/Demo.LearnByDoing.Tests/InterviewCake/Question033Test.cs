using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/which-appears-twice
	/// 
	/// 
	/// I have an array of n + 1 numbers. Every number in the range 1..n appears once except for one number that appears twice.
	/// 
	/// Write a method for finding the number that appears twice.
	/// 
	/// </summary>
	public class Question033Test
	{
		[Theory]
		[MemberData(nameof(GetSampleCases))]
		public void TestHashVersion(int expected, int[] input)
		{
			int actual = FindDupeUsingHash(input);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[MemberData(nameof(GetSampleCases))]
		public void TestMathVersion(int expected, int[] input)
		{
			int actual = FindDupeUsingMath(input);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetSampleCases()
		{
			yield return new object[] {1, new[] { 1, 2, 3, 1, 4 } };
			yield return new object[] {2, new[] { 1, 2, 3, 4, 2 } };
			yield return new object[] {3, new[] { 4, 1, 2, 3, 3 } };
		}

		private int FindDupeUsingMath(int[] input)
		{
			int n = input.Length;
			//int expectedSum = Enumerable.Range(1, n).Sum();
			// Using Triagnular series sum (n^2 + n) / 2
			int expectedSum = (n * n + n) / 2;
			int actualSum = input.Sum();

			return n - expectedSum + actualSum;
		}

		private int FindDupeUsingHash(int[] input)
		{
			var isSeen = new HashSet<int>();
			foreach (int number in input)
			{
				if (isSeen.Contains(number)) return number;
				isSeen.Add(number);
			}

			throw new ArgumentException();
		}
	}
}
