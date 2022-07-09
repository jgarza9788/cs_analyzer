using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	public class WeightForWeightTest : BaseTest
	{
		public WeightForWeightTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData("56 65 74 100 99 68 86 180 90", "100 180 90 56 65 74 68 86 99")]
		[InlineData("103 123 4444 99 2000", "2000 103 123 4444 99")]
		[InlineData("2000 10003 1234000 44444444 9999 11 11 22 123", "11 11 2000 10003 22 123 1234000 44444444 9999")]
		public void TestWeightOrder(string numbersText, string expected)
		{
			string actual = WeightSort.orderWeight(numbersText);
			Assert.Equal(expected, actual);
		}
	}

	public class WeightSort
	{

		public static string orderWeight(string numbersText)
		{
			if (string.IsNullOrWhiteSpace(numbersText)) return "";

			var numbers = numbersText.Split().Select(long.Parse).ToArray();
			Array.Sort(numbers, new WeightComparer());
			return string.Join(" ", numbers);
		}
	}

	public class WeightComparer : IComparer<long>
	{
		public int Compare(long x, long y)
		{
			string xText = x.ToString();
			string yText = y.ToString();

			long xSum = SumText(xText);
			long ySum = SumText(yText);

			if (xSum > ySum) return 1;
			if (xSum < ySum) return -1;

			return xText.CompareTo(yText);
		}

		private long SumText(string numberText)
		{
			return numberText.ToCharArray().Select(c => long.Parse(c.ToString())).Sum();
		}
	}
}
