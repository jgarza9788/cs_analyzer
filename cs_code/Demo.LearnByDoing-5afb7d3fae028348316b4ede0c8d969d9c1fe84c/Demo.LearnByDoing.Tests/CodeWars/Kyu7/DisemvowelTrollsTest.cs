using System.Text.RegularExpressions;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	public class DisemvowelTrollsTest : BaseTest
	{
		public DisemvowelTrollsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void ShouldRemoveAllVowels()
		{
			//Assert.Equal(Kata.Disemvowel("AA EE OO"), "   ");
			Assert.Equal(Kata.Disemvowel("This website is for losers LOL!"), "Ths wbst s fr lsrs LL!");
		}
	}

	public partial class Kata
	{
		public static string Disemvowel(string input)
		{
			return Regex.Replace(input, "[aeiouAEIOU]", "");
		}
	}
}
