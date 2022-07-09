using System;
using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/zero-fill-dot-dot-dot-for-the-queen/train/csharp
	/// </summary>
	public class ZeroFillForTheQueenTest
	{
		public static IEnumerable<object[]> GetTestCases()
		{
			yield return new object[] {11, 5, "00011"};
			yield return new object[] {11, 11, "00000000011"};
			yield return new object[] {-32, 5, "00032"};
			yield return new object[] {0, 3, "000"};
			yield return new object[] {-32.12, 3, "032"};
		}

		[Theory, MemberData(nameof(GetTestCases))]
		public void Test(int number, int size, string expected)
		{
			Assert.Equal(expected, Kata.ZeroFill(number, size));
		}
	}

	public partial class Kata
	{
		public static string ZeroFill(int number, int size)
		{
			return Math.Abs(Math.Floor((double) number)).ToString().PadLeft(size, '0');
		}
	}
}
