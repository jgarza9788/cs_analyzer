using System;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/string-letter-counting/train/csharp
	/// </summary>
	[TestFixture]
	public class StringLetterCountingTest
	{
		[Test]
		public void Test1()
		{
			Assert.AreEqual("1a1b1c1d3e1f1g2h1i1j1k1l1m1n4o1p1q2r1s2t2u1v1w1x1y1z", Kata.StringLetterCount("The quick brown fox jumps over the lazy dog."));
		}

		[Test]
		public void Test2()
		{
			Assert.AreEqual("2a1d5e1g1h4i1j2m3n3o3s6t1u2w2y", Kata.StringLetterCount("The time you enjoy wasting is not wasted time."));
		}

		[Test]
		public void Test3()
		{
			Assert.AreEqual("", Kata.StringLetterCount("./4592#{}()"));
		}
	}

	public partial class Kata
	{
		public static string StringLetterCount(string text)
		{
			// Extract letters lower-cased.
			var letters = text.Where(Char.IsLetter).Select(Char.ToLower).ToList();
			// Guard clause - Return empty string if no letter is found.
			if (letters.Count == 0) return string.Empty;

			return letters
				.GroupBy(c => c)
				.OrderBy(g => g.Key)
				.Aggregate("", (acc, g) => acc + $"{g.Count()}{g.Key}");
		}
	}
}
