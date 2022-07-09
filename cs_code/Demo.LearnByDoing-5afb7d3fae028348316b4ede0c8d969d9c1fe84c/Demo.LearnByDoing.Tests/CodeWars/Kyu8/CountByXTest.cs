using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu8
{
	/// <summary>
	/// https://www.codewars.com/kata/5513795bd3fafb56c200049e/train/csharp
	/// </summary>
	public class CountByXTest : BaseTest
	{
		public CountByXTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public static void CountBy1()
		{
			Assert.Equal(new[] {1, 2, 3, 4, 5}, Kata.CountBy(1, 5));
		}
		[Fact]
		public static void CountBy2()
		{
			Assert.Equal(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, Kata.CountBy(1, 10));
		}
		[Fact]
		public static void CountBy3()
		{
			Assert.Equal(new[] {2, 4, 6, 8, 10}, Kata.CountBy(2, 5));
		}

		[Fact]
		public static void CountBy4()
		{
			Assert.Equal(new[] {2, 4, 6, 8, 10}, Kata.CountBy(2, 5));
		}
	}

	public partial class Kata
	{
		public static int[] CountBy(int x, int n)
		{
			return Enumerable.Repeat(x, n).Select((a, i) => a * (i + 1)).ToArray();
		}
	}
}
