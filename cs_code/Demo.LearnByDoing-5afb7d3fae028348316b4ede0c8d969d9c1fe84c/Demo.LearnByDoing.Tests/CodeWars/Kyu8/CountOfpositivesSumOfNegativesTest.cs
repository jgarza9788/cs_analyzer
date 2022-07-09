using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu8
{
	/// <summary>
	/// https://www.codewars.com/kata/576bb71bbbcf0951d5000044/train/csharp
	/// </summary>
	[TestFixture]
	public class CountOfpositivesSumOfNegativesTest
	{
		[Test]
		public void CountPositivesSumNegatives_BasicTest()
		{
			int[] expectedResult = { 10, -65 };

			Assert.AreEqual(expectedResult, Kata.CountPositivesSumNegatives(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -11, -12, -13, -14, -15 }));
		}

		[Test]
		public void CountPositivesSumNegatives_InputWithZeroes()
		{
			int[] expectedResult = { 8, -50 };

			Assert.AreEqual(expectedResult, Kata.CountPositivesSumNegatives(new[] { 0, 2, 3, 0, 5, 6, 7, 8, 9, 10, -11, -12, -13, -14 }));
		}

		[Test]
		public void CountPositivesSumNegatives_NullInput()
		{
			int[] expectedResult = {};

			Assert.AreEqual(expectedResult, Kata.CountPositivesSumNegatives(null));
			Assert.AreEqual(expectedResult, Kata.CountPositivesSumNegatives(new int[]{}));
		}
	}

	public partial class Kata
	{
		public static int[] CountPositivesSumNegatives(int[] a)
		{
			if (a == null || a.Length == 0) return new int[0];
			int count = 0;
			int sum = 0;
			a.Select(n => n > 0 ? count++ : sum += n).ToList();

			return new[] {count, sum};
		}
	}
}
