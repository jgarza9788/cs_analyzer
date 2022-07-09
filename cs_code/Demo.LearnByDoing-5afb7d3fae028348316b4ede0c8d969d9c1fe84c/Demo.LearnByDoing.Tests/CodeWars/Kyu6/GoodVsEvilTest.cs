using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/good-vs-evil/train/csharp
	/// </summary>
	/// <remarks>
	/// Hobbits: 1
	/// Men: 2
	/// Elves: 3
	/// Dwarves: 3
	/// Eagles: 4
	/// Wizards: 10
	/// 
	/// On the side of evil we have:
	/// Orcs: 1
	/// Men: 2
	/// Wargs: 2
	/// Goblins: 2
	/// Uruk Hai: 3
	/// Trolls: 5
	/// Wizards: 10
	/// </remarks>
	[TestFixture]
	public class GoodVsEvilTest
	{
		[Test]
		public static void EvilShouldWin()
		{
			Assert.AreEqual("Battle Result: Evil eradicates all trace of Good", Kata.GoodVsEvil("1 1 1 1 1 1", "1 1 1 1 1 1 1"));
		}

		[Test]
		public static void GoodShouldTriumph()
		{
			Assert.AreEqual("Battle Result: Good triumphs over Evil", Kata.GoodVsEvil("0 0 0 0 0 10", "0 1 1 1 1 0 0"));
		}

		[Test]
		public static void ShouldBeATie()
		{
			Assert.AreEqual("Battle Result: No victor on this battle field", Kata.GoodVsEvil("1 0 0 0 0 0", "1 0 0 0 0 0 0"));
		}
	}

	public partial class Kata
	{
		private static int[] _goodWorth = { 1, 2, 3, 3, 4, 10 };
		private static int[] _evilWorth = { 1, 2, 2, 2, 3, 5, 10 };

		public static string GoodVsEvil(string good, string evil)
		{
			var goodSum = good.Split().Select((c, i) => _goodWorth[i] * int.Parse(c)).Sum();
			var evilSum = evil.Split().Select((c, i) => _evilWorth[i] * int.Parse(c)).Sum();

			const string tie = "Battle Result: No victor on this battle field";
			const string goodWins = "Battle Result: Good triumphs over Evil";
			const string evilWins = "Battle Result: Evil eradicates all trace of Good";
			var diff = goodSum - evilSum;

			return diff == 0 ? tie : diff < 0 ? evilWins : goodWins;
		}
	}
}
