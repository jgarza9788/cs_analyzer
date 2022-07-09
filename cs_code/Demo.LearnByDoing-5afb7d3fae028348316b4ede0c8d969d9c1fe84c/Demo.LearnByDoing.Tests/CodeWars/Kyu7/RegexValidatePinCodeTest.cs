using System.Text.RegularExpressions;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/regex-validate-pin-code/train/csharp
	/// </summary>
	public class RegexValidatePinCodeTest : BaseTest
	{
		public RegexValidatePinCodeTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void LengthTest()
		{
			Assert.Equal(false, Kata.ValidatePin("1"));
			Assert.Equal(false, Kata.ValidatePin("12"));
			Assert.Equal(false, Kata.ValidatePin("123"));
			Assert.Equal(false, Kata.ValidatePin("12345"));
			Assert.Equal(false, Kata.ValidatePin("1234567"));
			Assert.Equal(false, Kata.ValidatePin("-1234"));
			Assert.Equal(false, Kata.ValidatePin("1.234"));
			Assert.Equal(false, Kata.ValidatePin("00000000"));
		}

		[Fact]
		public void NonDigitTest()
		{
			Assert.Equal(false, Kata.ValidatePin("a234"));
			Assert.Equal(false, Kata.ValidatePin(".234"));
		}

		[Fact]
		public void ValidTest()
		{
			Assert.Equal(true, Kata.ValidatePin("1234"));
			Assert.Equal(true, Kata.ValidatePin("0000"));
			Assert.Equal(true, Kata.ValidatePin("1111"));
			Assert.Equal(true, Kata.ValidatePin("123456"));
			Assert.Equal(true, Kata.ValidatePin("098765"));
			Assert.Equal(true, Kata.ValidatePin("000000"));
			Assert.Equal(true, Kata.ValidatePin("090909"));
		}
	}

	public partial class Kata
	{
		public static bool ValidatePin(string pin)
		{
			const string pattern = @"^(\d{4})$|^(\d{6})$";
			return Regex.IsMatch(pin, pattern, RegexOptions.IgnoreCase);
		}
	}
}
