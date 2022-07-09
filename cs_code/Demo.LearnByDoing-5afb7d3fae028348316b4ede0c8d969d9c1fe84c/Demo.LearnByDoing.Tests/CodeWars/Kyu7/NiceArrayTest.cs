using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/nice-array/train/csharp
	/// </summary>
	public class NiceArrayTest : BaseTest
	{
		public NiceArrayTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void SampleTest()
		{
			Assert.Equal(false, Kata.IsNice(new [] { 3, 4, 5, 7 }));
			Assert.Equal(true, Kata.IsNice(new[] { 2, 10, 9, 3 }));
			Assert.Equal(true, Kata.IsNice(new[] { 2, 2, 3, 3, 3 }));
			Assert.Equal(false, Kata.IsNice(new[] { 0, 2, 19, 4, 4, 3, 2, 1, 0, 3, 2, 10, 4, 1, 6, 1, 1, 8, 3, 1, 1, 0, 1, 2, 3, 1, 2, 3, 4, 0, -1, 1, 0, 2, 3, 0 }));
			Assert.Equal(false, Kata.IsNice(new[] { 3, 2, 10, 4, 1, 6, 1, 1, 8, 3, 1, 1, 0, -1, 1, 0, 3, 2, 10, 4, 1, 6, 9, 1, 1, 1, 2, 1, 1, 1, 1, 8, 3, 1, 1, 3, 1, 2, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, -2, -1, -2, 5, 0, 5, 12 }));
		}
	}

	public partial class Kata
	{
		public static bool IsNice(int[] a)
		{
			if (a.Length == 0) return false;
			return a.All(n => a.Count(v => v + 1 == n || v - 1 == n) > 0);
		}
	}
}
