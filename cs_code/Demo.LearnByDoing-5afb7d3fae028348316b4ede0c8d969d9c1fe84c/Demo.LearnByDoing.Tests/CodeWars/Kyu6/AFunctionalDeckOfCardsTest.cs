using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/a-functional-deck-of-cards-dot-dot-dot/train/csharp
	/// </summary>
	[TestFixture]
	public class AFunctionalDeckOfCardsTest
	{
		[Test]
		public void MyTest()
		{
			var cards = DeckOfCards.BuildDeck();
			Assert.AreEqual(true, true);
		}
	}

	public class DeckOfCards
	{
		public static string[] BuildDeck()
		{
			var kinds = new[] { "hearts", "spades", "diamonds", "clubs" };
			var ranks = new[] { "ace", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king" };

			//return (from rank in ranks
			//		from kind in kinds
			//		select $"{rank} of {kind}").ToArray();
			//return ranks.SelectMany(rank => kinds, (rank, kind) => $"{rank} of {kind}").ToArray();
			return ranks.SelectMany(rank => kinds, (rank, kind) => $"{rank} of {kind}").Select(str => str).ToArray();
		}
	}
}
