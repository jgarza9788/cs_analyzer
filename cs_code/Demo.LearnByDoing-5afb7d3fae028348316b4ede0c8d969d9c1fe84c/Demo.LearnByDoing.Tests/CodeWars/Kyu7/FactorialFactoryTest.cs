using System;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/factorial-factory/train/csharp
	/// </summary>
	public class FactorialFactoryTest
	{
		[Fact]
		public void Test1()
		{
			// Don't forget the special cases!
			Assert.Equal(Kata.Factorial(1), 1);
			Assert.Equal(Kata.Factorial(5), 120);
			Assert.Equal(Kata.Factorial(0), 1);
		}

		[Fact]
		public void TestNegativeNumbers()
		{
			Assert.Throws<Exception>(() => Kata.Factorial(-1));
		}
	}

	public partial class Kata
	{
		public static int Factorial(int n)
		{
			// CodeWars.com Mono compiler doesn't allow "throw" within ternary operator!
			//return 
			//	n == 0 ? 1 :
			//	n < 0 ? throw new Exception() : 
			//	n * Factorial(n - 1);

			if (n < 0) throw new Exception();
			if (n == 0) return 1;

			return n * Factorial(n - 1);
		}
	}
}
