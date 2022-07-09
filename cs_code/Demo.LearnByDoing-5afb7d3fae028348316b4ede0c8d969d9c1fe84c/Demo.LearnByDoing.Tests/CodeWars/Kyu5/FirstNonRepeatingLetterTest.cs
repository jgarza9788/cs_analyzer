using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	public class FirstNonRepeatingLetterTest : BaseTest
	{
		public FirstNonRepeatingLetterTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData("a", "a")]
		[InlineData("stress", "t")]
		[InlineData("sTreSS", "T")]
		[InlineData("moonmen", "e")]
		[InlineData("aabbcc", "")]
		public void TestFirstNonRepeatingLetter(string input, string expected)
		{
			string actual = Kata.FirstNonRepeatingLetter(input);
			Assert.Equal(expected, actual);
		}
	}

	public partial class Kata
	{
		public static string FirstNonRepeatingLetter(string input)
		{
			var map = input
				.ToCharArray()
				.GroupBy(char.ToUpper)
				.Select(group => new {group.Key, Count = group.Count()})
				.ToDictionary(item => item.Key, item => item.Count);

			var candidateCharacter = map.FirstOrDefault(item => item.Value == 1).Key;
			var uniqueCharacter = input.Where(c => char.ToUpper(c) == candidateCharacter).ToArray();

			if (uniqueCharacter.Length > 0)
				return uniqueCharacter[0].ToString();
			return string.Empty;
		}
	}
}
