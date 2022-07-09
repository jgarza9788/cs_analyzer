using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/sum-times-tables/train/csharp
	/// </summary>
	public class SumTimesTablesTest
	{
		public void SampleTest()
		{
			Assert.Equal(30, Kata.SumTimesTable(new List<int> { 2, 3 }, 1, 3));
			Assert.Equal(9, Kata.SumTimesTable(new List<int> { 1, 3, 5 }, 1, 1));
			Assert.Equal(495, Kata.SumTimesTable(new List<int> { 1, 3, 5 }, 1, 10));
		}
	}

	public partial class Kata
	{
		public static long SumTimesTable(List<int> tables, long min, long max)
		{
			long sum = 0;
			foreach (var a in tables)
			{
				// research summing 1 to 100
				// https://betterexplained.com/articles/techniques-for-adding-the-numbers-1-to-100/
			}

			return sum;
		}
	}
}
