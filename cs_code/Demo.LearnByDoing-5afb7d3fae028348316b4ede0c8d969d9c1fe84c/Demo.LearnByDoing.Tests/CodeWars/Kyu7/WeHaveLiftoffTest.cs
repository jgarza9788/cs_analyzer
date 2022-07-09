using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/we-have-liftoff/train/csharp
	/// </summary>
	public class WeHaveLiftoffTest
	{
		[Fact]
		public void Test()
		{
			var instructions = new List<int> { 2, 8, 10, 9, 1, 3, 4, 7, 6, 5 };
			var actual = Kata.Liftoff(instructions);
			var expected = "10 9 8 7 6 5 4 3 2 1 liftoff!";

			Assert.Equal(expected, actual);
		}
	}

	public partial class Kata
	{
		public static string Liftoff(List<int> l)
		{
			return string.Join(" ", l.OrderByDescending(x => x)) + " liftoff!";
		}
	}
}
