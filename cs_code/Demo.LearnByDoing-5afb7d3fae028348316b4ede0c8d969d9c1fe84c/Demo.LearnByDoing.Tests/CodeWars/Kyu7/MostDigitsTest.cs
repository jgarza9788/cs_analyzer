using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/most-digits/train/csharp
	/// </summary>
	public class MostDigitsTest
	{
		[Fact]
		public void SampleTest()
		{
			Assert.Equal(100, Kata.FindLongest(new[] { 1, 10, 100 }));
			Assert.Equal(9000, Kata.FindLongest(new[] { 9000, 8, 800 }));
			Assert.Equal(900, Kata.FindLongest(new[] { 8, 900, 500 }));
		}
	}

	public partial class Kata
	{
		public static int FindLongest(int[] number)
		{
			var maxLength = number.Max(n => n.ToString().Length);
			return number.First(n => n.ToString().Length == maxLength);
		}
	}
}
