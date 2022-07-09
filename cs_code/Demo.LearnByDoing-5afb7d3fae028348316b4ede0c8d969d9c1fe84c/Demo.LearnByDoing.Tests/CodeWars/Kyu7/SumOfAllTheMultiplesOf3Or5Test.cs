using System;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	public class SumOfAllTheMultiplesOf3Or5Test : BaseTest
	{
		public SumOfAllTheMultiplesOf3Or5Test(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void MyTest()
		{
			Assert.Equal(8, Program.findSum(5));
			Assert.Equal(33, Program.findSum(10));
		}
	}

	public static class Program
	{
		public static int findSum(int n)
		{
			Func<int, int> isMultiplesOf3Or5 = x => (x % 3 == 0 || x % 5 == 0) ? x : 0;
			return Enumerable.Range(1, n).Sum(isMultiplesOf3Or5);
		}
	}
}
