using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	public class ZeroBalancedArrayTest
	{
		[Fact]
		public void SampleTest()
		{
			Assert.Equal(false, Kata.IsZeroBalanced(new List<int> { 3 }));
			Assert.Equal(false, Kata.IsZeroBalanced(new List<int> { 1, 1, 15, -1, -1, 6, 2, 4, 2, 2, 2, 1, 5, 0, -100, 1, -1, 3, -2, -1, 9, 0, 6, 0, 0, 0, 0, 3, 3 }));
			Assert.Equal(true, Kata.IsZeroBalanced(new List<int> { 0, 0, 0, 0, 0, 0 }));
		}
	}

	public partial class Kata
	{
		public static bool IsZeroBalanced(List<int> xs)
		{
			//foreach (var a in xs) { Console.Write("{0}, ", a); }
			if (xs.Count == 0) return false;
			//if (xs.Count == 1) return true;

			var posMap = xs.Where(a => a > 0).GroupBy(g => g).ToDictionary(g => g.Key, g => g.Count());
			var negMap = xs.Where(a => a < 0).GroupBy(g => g).ToDictionary(g => -g.Key, g => g.Count());

			return posMap.Intersect(negMap).Count() == posMap.Count;
		}
	}
}
