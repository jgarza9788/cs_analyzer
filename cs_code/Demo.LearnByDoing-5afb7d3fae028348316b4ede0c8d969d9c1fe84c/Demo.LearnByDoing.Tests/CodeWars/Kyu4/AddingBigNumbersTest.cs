using System.Numerics;
using Demo.LearnByDoing.Core;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu4
{
	/// <summary>
	/// https://www.codewars.com/kata/adding-big-numbers/train/csharp
	/// </summary>
	public class AddingBigNumbersTest : BaseTest
	{
		public AddingBigNumbersTest(ITestOutputHelper output) : base(output)
		{
		}
	}

	public partial class Kata
	{
		public static string Add(string a, string b)
		{
			return (BigInteger.Parse(a) + BigInteger.Parse(b)).ToString();
		}
	}
}
