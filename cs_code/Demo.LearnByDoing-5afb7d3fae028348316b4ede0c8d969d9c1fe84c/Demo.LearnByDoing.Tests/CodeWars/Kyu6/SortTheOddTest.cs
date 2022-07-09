using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/sort-the-odd/train/csharp
	/// </summary>
	public class SortTheOddTest : BaseTest
	{
		public SortTheOddTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void BasicTests()
		{
			Assert.Equal(new int[] { 1, 3, 2, 8, 5, 4 }, Kata.SortArray(new int[] { 5, 3, 2, 8, 1, 4 }));
			Assert.Equal(new int[] { 1, 3, 5, 8, 0 }, Kata.SortArray(new int[] { 5, 3, 1, 8, 0 }));
			Assert.Equal(new int[] { }, Kata.SortArray(new int[] { }));
		}
	}

	public partial class Kata
	{
		public static int[] SortArray(int[] a)
		{
			// Guard condition.
			if (a == null || a.Length == 0) return new int[] { };

			Func<int, bool> isOdd = number => number % 2 == 1;

			// Extract odd numbers & sort it.
			var oddNumbers = new Queue<int>(a.Where(isOdd).OrderBy(number => number).ToList());

			// update the array & return.
			for (int i = 0; i < a.Length; i++)
			{
				var current = a[i];

				// We need to leave even value so process only for odd numbers.
				if (isOdd(current))
				{
					a[i] = oddNumbers.Dequeue();
				}
			}

			return a;
		}
	}
}
