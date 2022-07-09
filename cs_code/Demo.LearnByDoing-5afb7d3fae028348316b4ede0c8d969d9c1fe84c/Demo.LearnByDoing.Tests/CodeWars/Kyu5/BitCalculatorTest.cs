using System;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	/// <summary>
	/// https://www.codewars.com/kata/bit-calculator/train/csharp
	/// </summary>
	public class BitCalculatorTest : BaseTest
	{
		public BitCalculatorTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void BasicTests()
		{
			Assert.Equal(2, Kata.Calculate("1", "1"));
			Assert.Equal(4, Kata.Calculate("10", "10"));
			Assert.Equal(2, Kata.Calculate("10", "0"));
			Assert.Equal(3, Kata.Calculate("10", "1"));
			Assert.Equal(7, Kata.Calculate("101", "10"));
		}

	}

	public partial class Kata
	{
		public static int Calculate(string num1, string num2)
		{
			//return Convert.ToInt32(num1, 2) + Convert.ToInt32(num2, 2);
			int n1 = ToBase10(num1);
			int n2 = ToBase10(num2);

			return n1 + n2;
		}

		private static int ToBase10(string n)
		{
			int result = 0;

			for (int i = 0, j = n.Length - 1; i < n.Length; i++, j--)
			{
				int power = (int) Math.Pow(2, j);
				result += int.Parse(n[i].ToString()) * power;
			}

			return result;
		}
	}
}
