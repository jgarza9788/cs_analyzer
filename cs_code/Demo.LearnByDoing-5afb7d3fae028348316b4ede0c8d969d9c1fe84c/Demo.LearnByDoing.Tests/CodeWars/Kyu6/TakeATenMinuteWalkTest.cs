using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/take-a-ten-minute-walk/train/csharp
	/// </summary>
	[TestFixture]
	public class TakeATenMinuteWalkTest
	{
		[Test]
		public void SampleTest()
		{
			Assert.AreEqual(true, Kata.IsValidWalk(new[] { "n", "s", "n", "s", "n", "s", "n", "s", "n", "s" }), "should return true");
			Assert.AreEqual(false, Kata.IsValidWalk(new[] { "w", "e", "w", "e", "w", "e", "w", "e", "w", "e", "w", "e" }), "should return false");
			Assert.AreEqual(false, Kata.IsValidWalk(new[] { "w" }), "should return false");
			Assert.AreEqual(false, Kata.IsValidWalk(new[] { "n", "n", "n", "s", "n", "s", "n", "s", "n", "s" }), "should return false");
		}
	}

	public partial class Kata
	{
		public static bool IsValidWalk(string[] walk)
		{
			var map = new Dictionary<string, int>
			{
				{"n", 0}, {"s", 0}, {"e", 0}, {"w", 0}
			};

			walk.Select(direction => map[direction]++).ToList();

			return map["n"] - map["s"] == 0 &&
			       map["e"] - map["w"] == 0 &&
			       walk.Length == 10;
		}

		public static bool IsValidWalk2(string[] walk)
		{
			int n = 0;
			int s = 0;
			int e = 0;
			int w = 0;
			int tenMinute = 10;

			foreach (string direction in walk)
			{
				switch (direction)
				{
					case "n":
						n++;
						break;
					case "s":
						s++;
						break;
					case "e":
						e++;
						break;
					case "w":
						w++;
						break;
				}
				tenMinute--;
			}

			// if n - s == 0 && e - w == 0 && tenMinute == 0 return true
			return (n - s == 0) && (e - w == 0) && tenMinute == 0;
		}
	}
}
