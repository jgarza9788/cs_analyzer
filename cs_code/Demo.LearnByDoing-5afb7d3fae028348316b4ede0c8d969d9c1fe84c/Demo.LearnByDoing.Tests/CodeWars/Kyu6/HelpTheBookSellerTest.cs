using System;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/help-the-bookseller/train/csharp
	/// </summary>
	public class HelpTheBookSellerTest
	{
		[Test]
		public void Test1()
		{
			string[] art = { "ABAR 200", "CDXE 500", "BKWR 250", "BTSQ 890", "DRTY 600" };
			String[] cd = { "A", "B" };
			Assert.AreEqual("(A : 200) - (B : 1140)", StockList.stockSummary(art, cd));
		}

		[Test]
		public void Test2()
		{
			string[] art = { "ABART 20", "CDXEF 50", "BKWRK 25", "BTSQZ 89", "DRTYM 60" };
			String[] cd = { "A", "B", "C", "W" };
			Assert.AreEqual("(A : 20) - (B : 114) - (C : 50) - (W : 0)", StockList.stockSummary(art, cd));
		}

		[Test]
		public void TestEmptyCases()
		{
			string[] art = {};
			String[] cd = { "A", "B", "C", "W" };
			Assert.AreEqual("", StockList.stockSummary(art, cd));

			string[] art2 = {"ABART 20", "CDXEF 50", "BKWRK 25", "BTSQZ 89", "DRTYM 60"};
			string[] cd2 = {};
			Assert.AreEqual("", StockList.stockSummary(art2, cd2));
		}
	}

	public static class StockList
	{
		public static string stockSummary(string[] arts, string[] cds)
		{
			if (arts.Length == 0 || cds.Length == 0) return string.Empty;

			var cdMap = cds.ToDictionary(cd => cd, cd => 0);
			foreach (var art in arts)
			{
				var prefix = art[0].ToString();
				if (cdMap.ContainsKey(prefix))
				{
					var cdValue = int.Parse(art.Split()[1]);
					cdMap[prefix] += cdValue;
				}
			}

			return string.Join(" - ", cdMap.Select(pair => $"({pair.Key} : {pair.Value})"));
		}
	}
}
