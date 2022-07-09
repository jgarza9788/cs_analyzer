using System;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/consecutive-strings/train/csharp
	/// </summary>
	[TestFixture]
	public class ConsecutiveStringsTest
	{
		private static void Testing(string actual, string expected)
		{
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public static void Test1()
		{
			Console.WriteLine("Basic Tests");
			Testing(LongestConsecutives.LongestConsec(new String[] { "zone", "abigail", "theta", "form", "libe", "zas", "theta", "abigail" }, 2), "abigailtheta");
			Testing(LongestConsecutives.LongestConsec(new String[] { "ejjjjmmtthh", "zxxuueeg", "aanlljrrrxx", "dqqqaaabbb", "oocccffuucccjjjkkkjyyyeehh" }, 1), "oocccffuucccjjjkkkjyyyeehh");
			Testing(LongestConsecutives.LongestConsec(new String[] { }, 3), "");
			Testing(LongestConsecutives.LongestConsec(new String[] { "itvayloxrp", "wkppqsztdkmvcuwvereiupccauycnjutlv", "vweqilsfytihvrzlaodfixoyxvyuyvgpck" }, 2), "wkppqsztdkmvcuwvereiupccauycnjutlvvweqilsfytihvrzlaodfixoyxvyuyvgpck");
			Testing(LongestConsecutives.LongestConsec(new String[] { "wlwsasphmxx", "owiaxujylentrklctozmymu", "wpgozvxxiu" }, 2), "wlwsasphmxxowiaxujylentrklctozmymu");
			Testing(LongestConsecutives.LongestConsec(new String[] { "zone", "abigail", "theta", "form", "libe", "zas" }, -2), "");
			Testing(LongestConsecutives.LongestConsec(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 3), "ixoyx3452zzzzzzzzzzzz");
			Testing(LongestConsecutives.LongestConsec(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 15), "");
			Testing(LongestConsecutives.LongestConsec(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 0), "");
		}
	}

	public class LongestConsecutives
	{
		public static string LongestConsec(string[] a, int k)
		{
			var n = a.Length;
			if (n == 0 || k > n || k <= 0) return string.Empty;

			var max = 0;
			var maxStartIndex = 0;

			for (int i = 0; i <= n - k; i++)
			{
				var curr = 0;
				for (int j = i; j < k + i; j++)
				{
					curr += a[j].Length;
				}

				if (curr > max)
				{
					max = curr;
					maxStartIndex = i;
				}
			}

			return string.Concat(a.Skip(maxStartIndex).Take(k));
		}
	}
}
