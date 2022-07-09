using System;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/prize-draw/train/csharp
	/// </summary>
	[TestFixture]
	public class PrizeDrawTest
	{
		[Test]
		public static void Test1()
		{
			string st = "";
			int[] we = { 4, 2, 1, 4, 3, 1, 2 };
			Assert.AreEqual("No participants", Rank.NthRank(st, we, 4));

			st = "Addison,Jayden,Sofia,Michael,Andrew,Lily,Benjamin";
			we = new[] { 4, 2, 1, 4, 3, 1, 2 };
			Assert.AreEqual("Not enough participants", Rank.NthRank(st, we, 8));

			st = "Addison,Jayden,Sofia,Michael,Andrew,Lily,Benjamin";
			we = new[] { 4, 2, 1, 4, 3, 1, 2 };
			Assert.AreEqual("Benjamin", Rank.NthRank(st, we, 4));

			st = "Elijah,Chloe,Elizabeth,Matthew,Natalie,Jayden";
			we = new[] { 1, 3, 5, 5, 3, 6 };
			Assert.AreEqual("Matthew", Rank.NthRank(st, we, 2));

			st = "Aubrey,Olivai,Abigail,Chloe,Andrew,Elizabeth";
			we = new[] { 3, 1, 4, 4, 3, 2 };
			Assert.AreEqual("Abigail", Rank.NthRank(st, we, 4));
		}
	}

	public class Rank
	{
		public static string NthRank(string st, int[] we, int n)
		{
			Console.WriteLine(st);
			foreach (var x in we) Console.Write("{0},", x);

			if (string.IsNullOrWhiteSpace(st)) return "No participants";
			if (we.Length < n) return "Not enough participants";

			// Get participant names
			var names = st.Split(',');

			// Map each partipant -> winning number calculation
			// Order by decreasing winning numbers
			var map = names
				.Select((name, i) => new {Key = name, Value = GetWinningNumber(name, we[i])})
				.OrderByDescending(pair => pair.Value)
				.ToDictionary(pair => pair.Key, pair => pair.Value);

			// Get the Nth value.
			var nthValue = map.Skip(n - 1).Take(1).FirstOrDefault().Value;

			// Get the first Nth occurring value ordered by the first letter
			return map.Where(pair => pair.Value == nthValue).OrderBy(pair => char.ToLower(pair.Key[0])).FirstOrDefault().Key;
		}

		private static int GetWinningNumber(string name, int weight)
		{
			return (name.Length + name.Aggregate(0, (acc, c) => acc + (char.ToLower(c) - 'a' + 1))) * weight;
		}
	}
}
