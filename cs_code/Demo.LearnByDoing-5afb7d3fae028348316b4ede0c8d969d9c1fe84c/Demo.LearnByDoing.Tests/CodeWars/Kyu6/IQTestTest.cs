using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/552c028c030765286c00007d/train/csharp
	/// </summary>
	public class IQTestTest : BaseTest
	{
		public IQTestTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData("2 4 7 8 10", 3)]
		[InlineData("1 2 2 2 2", 1)]
		[InlineData("1 2 1 1", 2)]
		[InlineData("2 2 2 1 2 2", 4)]
		public void Test1(string numbers, int expected)
		{
			int actual = IQ.Test(numbers);
			Assert.Equal(expected, actual);
		}
	}

	public class IQ
	{
		public static int Test(string numberText)
		{
			var numbers = ParseNumbers(numberText).ToList();

			int evenNumberCount = 0;
			int oddNumberCount = 0;

			int firstEvenNumberIndex = 0;
			int firstOddNumberIndex = 0;

			Func<int, bool> isEven = number => number % 2 == 0;

			for (int i = 0; i < numbers.Count; i++)
			{
				var number = numbers[i];
				if (isEven(number))
				{
					evenNumberCount++;
					if (evenNumberCount == 1)
						firstEvenNumberIndex = i;
				}
				else
				{
					oddNumberCount++;
					if (oddNumberCount == 1)
						firstOddNumberIndex = i;
				}

				if (evenNumberCount > 1 && oddNumberCount == 1)
					return firstOddNumberIndex + 1;
				if (evenNumberCount == 1 && oddNumberCount > 1)
					return firstEvenNumberIndex + 1;
			}

			return -1;
		}

		private static IEnumerable<int> ParseNumbers(string numberText)
		{
			return numberText.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
		}
	}
}