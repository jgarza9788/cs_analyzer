using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu4
{
	public class IPValidationTest : BaseTest
	{
		public IPValidationTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData("1.2.3.4", true)]
		[InlineData("123.45.67.89", true)]
		[InlineData("12.255.56.1", true)]
		[InlineData("1.2.3", false)]
		[InlineData("1.2.3.4.5", false)]
		[InlineData("123.456.78.90", false)]
		[InlineData("123.045.067.089", false)]
		[InlineData("", false)]
		[InlineData("abc.def.ghi.jkl", false)]
		[InlineData("123.456.789.0", false)]
		[InlineData("12.34.56", false)]
		[InlineData("12.34.56. 1", false)]
		[InlineData("123.045.076.089", false)]
		public void TestIPValidity(string input, bool expected)
		{
			bool actual = Kata.is_valid_IP(input);
			Assert.Equal(expected, actual);
		}
	}

	partial class Kata
	{
		public static bool is_valid_IP(string input)
		{
			if (string.IsNullOrWhiteSpace(input)) return false;

			var digitTexts = input.Split('.');

			// Check if digit count is 4
			if (digitTexts.Length != 4) return false;

			// Check if digit is numeric
			if (digitTexts.Any(digit => !digit.All(char.IsDigit))) return false;

			// Check if digit is between 0 and 255 (all digits are numeric at this point)
			if (digitTexts.Any(digit => 0 > int.Parse(digit) || int.Parse(digit) > 255)) return false;

			// Check if digit doesn't start with "0"
			if (digitTexts.Any(digit => digit.StartsWith("0"))) return false;

			// All tests pass! Input is a valid IP address.
			return true;
		}
	}
}
