using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// http://www.codewars.com/kata/find-the-duplicated-number-in-a-consecutive-unsorted-list/train/csharp
	/// </summary>
	[TestFixture]
	public class FindTheDuplicatedNumberInAConsecutiveUnsortedListTest
	{
		private static IEnumerable<TestCaseData> TestCases
		{
			get
			{
				yield return new TestCaseData(new[] { new [] { 1, 1, 2, 3 } }).Returns(1);
				yield return new TestCaseData(new[] { new [] { 5, 4, 3, 2, 1, 1 } }).Returns(1);
				yield return new TestCaseData(new[] { new [] { 1, 3, 2, 5, 4, 5, 7, 6 } }).Returns(5);
				yield return new TestCaseData(new[] { new [] { 8, 2, 6, 3, 7, 2, 5, 1, 4 } }).Returns(2);
			}
		}

		[Test, TestCaseSource(nameof(TestCases))]
		public int Test(int[] arr) => Kata.FindDup(arr);
	}

	public partial class Kata
	{
		public static int FindDup(int[] a)
		{
			var map = Enumerable.Range(0, a.Length).ToArray();
			foreach (int number in a)
			{
				map[number] ^= number;
			}

			return map.Skip(1).FirstOrDefault(n => n > 0);
		}

		public static int FindDup2(int[] a)
		{
			for (int i = 0; i < a.Length; i++)
			{
				var curr = Math.Abs(a[i]) - 1;
				var next = a[curr] - 1;
				if (next < 0) return curr + 1;

				a[curr] = -a[curr];
			}

			return -1;
		}
	}
}
