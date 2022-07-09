using System;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/sum-of-cubes
	/// </summary>
	public class SumOfCubesTest
	{
		[Fact]
		public void SampleTest()
		{
			Assert.Equal(1, Kata.SumCubes(1));
			Assert.Equal(9, Kata.SumCubes(2));
			Assert.Equal(36, Kata.SumCubes(3));
			Assert.Equal(100, Kata.SumCubes(4));
			Assert.Equal(3025, Kata.SumCubes(10));
			Assert.Equal(58155876, Kata.SumCubes(123));
			Assert.Equal(2067740616877056, Kata.SumCubes(9536));
		}
	}

	public partial class Kata
	{
		public static long SumCubes(int n)
		{
			return Enumerable.Range(1, n).Aggregate(0L, (acc, next) => (long) (acc + Math.Pow(next, 3)));
		}
	}
}
