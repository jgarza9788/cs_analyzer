using System;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/replace-with-alphabet-position/train/csharp
	/// </summary>
	public class ReplaceWithAlphabetPositionTest : BaseTest
	{
		public ReplaceWithAlphabetPositionTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void SampleTest()
		{
			Assert.Equal("20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11", Kata.AlphabetPosition("The sunset sets at twelve o' clock."));
			Assert.Equal("20 8 5 14 1 18 23 8 1 12 2 1 3 15 14 19 1 20 13 9 4 14 9 7 8 20", Kata.AlphabetPosition("The narwhal bacons at midnight."));
		}
	}

	public partial class Kata
	{
		public static string AlphabetPosition(string text)
		{
			return string.Join(" ", text.Where(Char.IsLetter).Select(c => Char.ToLower(c) - 96));
		}
	}
}
