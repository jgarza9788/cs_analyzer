using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/bingo-card
	/// </summary>
	[TestFixture]
	public class BingoCardTests
	{
		[Test]
		public void CardHas24Numbers()
		{
			Assert.AreEqual(24, BingoCard.GetCard().Length);
		}

		[Test]
		public void EachNumberOnCardIsUnique()
		{
			var card = BingoCard.GetCard();
			Assert.AreEqual(card.Length, card.ToList().Distinct().Count());
		}

		[TestCase("B", 5)]
		[TestCase("I", 5)]
		[TestCase("N", 4)]
		[TestCase("G", 5)]
		[TestCase("O", 5)]
		public void ColumnContainsCorrectNumberOfItems(string column, int count)
		{
			var numbers = BingoCard.GetCard().Where(x => x.StartsWith(column)).ToList();
			Assert.AreEqual(count, numbers.Count);
		}

		[Test]
		public void NumbersAreOrderedByColumn()
		{
			var columns = string.Join("", BingoCard.GetCard().ToList()
				.Select(x => x.Substring(0, 1)).ToArray());

			Assert.IsTrue(Regex.IsMatch(columns, "^[B]*[I]*[N]*[G]*[O]*$"));
		}

		[TestCase("B", 1, 15)]
		[TestCase("I", 16, 30)]
		[TestCase("N", 31, 45)]
		[TestCase("G", 46, 60)]
		[TestCase("O", 61, 75)]
		public void NumbersWithinColumnAreAllInTheCorrectRange(string column, int start, int end)
		{
			var numbers = BingoCard.GetCard().Where(x => x.StartsWith(column)).ToList();

			foreach (var number in numbers)
			{
				var n = Convert.ToInt32(number.Substring(1));
				Assert.GreaterOrEqual(n, start, "Column {0} should be in the range between {1} and {2}, found: {3}", column, start, end, number);
				Assert.LessOrEqual(n, end, "Column {0} should be in the range between {1} and {2}, found: {3}", column, start, end, number);
			}
		}

		[Test]
		public void NumbersWithinColumnAreInRandomOrder()
		{
			var card = BingoCard.GetCard().Select(x => Convert.ToInt32(x.Substring(1))).ToArray();

			var isRandom = false;
			for (var i = 1; i < card.Length; i++)
			{
				if (card[i - 1] > card[i])
				{
					isRandom = true;
					break;
				}
			}

			Assert.IsTrue(isRandom, "Unlikely result, is the list ordered?");
		}
	}
	
	public class BingoCard
	{
		public static string[] GetCard()
		{
			List<string> result = new List<string>();

			var bingo = new Dictionary<string, Tuple<int, int>>
			{
				{"B", Tuple.Create(1, 15)},
				{"I", Tuple.Create(16, 30)},
				{"N", Tuple.Create(31, 45)},
				{"G", Tuple.Create(46, 60)},
				{"O", Tuple.Create(61, 75)},
			};
			foreach (var letterRange in bingo)
			{
				result.AddRange(GetLetterNumbers(letterRange));
			}

			return result.ToArray();
		}

		private static IEnumerable<string> GetLetterNumbers(KeyValuePair<string, Tuple<int, int>> letterRange)
		{
			int rowCount = letterRange.Key == "N" ? 4 : 5;

			HashSet<int> isSeen = new HashSet<int>();
			for (int i = 0; i < rowCount; i++)
			{
				var randomNumber = GetNextUniqueRandomNumberBetween(isSeen, letterRange.Value.Item1, letterRange.Value.Item2);
				yield return $"{letterRange.Key}{randomNumber}";
			}
		}

		private static int GetNextUniqueRandomNumberBetween(HashSet<int> isSeen, int min, int max)
		{
			Random random = new Random();

			var result = random.Next(min, max);
			while (isSeen.Contains(result))
			{
				result = random.Next(min, max);
			}

			isSeen.Add(result);

			return result;
		}
	}
}
