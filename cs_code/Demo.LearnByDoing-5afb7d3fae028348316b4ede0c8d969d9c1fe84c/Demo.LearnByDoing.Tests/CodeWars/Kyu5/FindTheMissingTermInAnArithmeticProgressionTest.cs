using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	/// <summary>
	/// https://www.codewars.com/kata/find-the-missing-term-in-an-arithmetic-progression/train/csharp
	/// </summary>
	public class FindTheMissingTermInAnArithmeticProgressionTest
	{
		private static IEnumerable<TestCaseData> testCases
		{
			get
			{
				yield return new TestCaseData(new[] { new List<int> { 1, 5, 7, 9, 11 } }).Returns(3);
				yield return new TestCaseData(new[] { new List<int> { 1, 3, 5, 9, 11 } }).Returns(7);
				yield return new TestCaseData(new[] { new List<int> { -3, -1, 1, 5, 7 } }).Returns(3);
				yield return new TestCaseData(new[] { new List<int> { 0, 5, 10, 20, 25 } }).Returns(15);
				yield return new TestCaseData(new[] { new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 } }).Returns(10);
				yield return new TestCaseData(new[] { new List<int> { 1040, 1220, 1580 } }).Returns(1400);
			}
		}

		[Test, TestCaseSource("testCases")]
		public int Test(List<int> list) => Kata.FindMissing(list);
	}

	public partial class Kata
	{
		public static int FindMissing(List<int> list)
		{
			int interval = GetInterval(list);

			int first = list.First();
			int last = list.Last();
			var set = new HashSet<int>(list);	// for O(1) lookup

			for (int i = first; i <= last; i += interval)
			{
				if (!set.Contains(i)) return i;
			}

			return -1;
		}

		private static int GetInterval(List<int> list)
		{
			int first = list.First();
			int last = list.Last();
			return (last - first) / list.Count;
		}


		public static int FindMissing_bad3(List<int> list)
		{
			int prev = list[0];
			int curr = list[1];
			int interval = GetInterval(list);

			for (int i = 2; i <= list.Count; i++)
			{
				int currDiff = curr - prev;
				if (currDiff != interval)
					return prev + interval;

				prev = curr;
				curr = list[i];
			}

			return -1;
		}

		public static int FindMissing_bad2(List<int> list)
		{
			int prev = list[0];
			int curr = list[1];
			int prevDiff = curr - prev;

			for (int i = 2; i <= list.Count; i++)
			{
				int currDiff = curr - prev;
				if (currDiff != prevDiff)
					return prev + prevDiff;

				prev = curr;
				curr = list[i];
			}

			return -1;
		}

		public static int FindMissing_bad(List<int> list)
		{
			//Console.WriteLine(string.Join(",", list.Select(n => n)));

			// find max count of differences
			int interval = GetInterval(list);
			int prev = list[0];
			for (int i = 1; i < list.Count; i++)
			{
				int curr = list[i];
				int diff = curr - prev;
				if (diff != interval)
					return prev + interval;

				prev = curr;
			}

			return -1;
		}

		private static int GetInterval2(List<int> list)
		{
			var diffMap = new Dictionary<int, int>(2);
			int prev = list[0];
			for (int i = 1; i < list.Count; i++)
			{
				int curr = list[i];
				int diff = curr - prev;

				if (!diffMap.ContainsKey(diff))
					diffMap.Add(diff, 0);
				diffMap[diff]++;

				//if (diffMap[diff] > 1) break;

				prev = curr;
			}

			//return diffMap.First(pair => pair.Value >= 1).Key;
			return diffMap.OrderByDescending(p => p.Value).First().Key;
		}
	}
}
