using System;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	/// <summary>
	/// https://www.codewars.com/kata/convert-string-to-camel-case/train/csharp
	/// </summary>
	public class ConvertStringToCamelCaseTest : BaseTest
	{
		public ConvertStringToCamelCaseTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void KataTests()
		{
			Assert.Equal("theStealthWarrior", Kata.ToCamelCase("the_stealth_warrior"));
			Assert.Equal("TheStealthWarrior", Kata.ToCamelCase("The-Stealth-Warrior"));
		}
	}

	public partial class Kata
	{
		public static string ToCamelCase(string str)
		{
			return string.Join("",
				str.Split(new[] {"-", "_"}, StringSplitOptions.RemoveEmptyEntries)
					.Select((word, i) => i == 0 ? word : char.ToUpper(word[0]) + word.Substring(1)));
		}
	}
}
