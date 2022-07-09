using System.Globalization;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/jaden-casing-strings/train/csharp
	/// </summary>
	public class JadenCasingStringsTest
	{
		[Fact]
		public void FixedTest()
		{
			var expected = "How Can Mirrors Be Real If Our Eyes Aren't Real";
			var actual = "How can mirrors be real if our eyes aren't real".ToJadenCase();
			Assert.Equal(expected, actual);
		}
	}

	public static class JadenCase
	{
		public static string ToJadenCase(this string phrase)
		{
			// One of the solutions
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(phrase);
			//return string.Join(" ", phrase.Split().Select(word => string.Concat(Char.ToUpper(word[0]), word.Substring(1))));
		}
	}
}
