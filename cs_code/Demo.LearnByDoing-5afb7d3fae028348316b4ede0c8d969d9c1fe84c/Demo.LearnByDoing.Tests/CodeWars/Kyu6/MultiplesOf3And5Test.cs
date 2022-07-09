using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/multiples-of-3-and-5/train/csharp
	/// </summary>
	public class MultiplesOf3And5Test : BaseTest
	{
		public MultiplesOf3And5Test(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void Test()
		{
			Assert.Equal(23, Kata.Solution(10));
		}
	}

	public partial class Kata
	{
		public static int Solution(int value)
		{
			return Enumerable.Range(0, value).Where(n => n % 3 == 0 || n % 5 == 0).Distinct().Sum();
		}
	}
}
