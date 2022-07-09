using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu8
{
	/// <summary>
	/// https://www.codewars.com/trainer/csharp
	/// </summary>
	public class RemoveAllExclamationMarksFromTheEndOfSentenceTest
	{
		[Test, Description("It should work for basic tests")]
		public void SampleTest()
		{
			Assert.AreEqual("Hi", Kata.Remove("Hi!"));
			Assert.AreEqual("Hi", Kata.Remove("Hi!!!"));
			Assert.AreEqual("!Hi", Kata.Remove("!Hi"));
			Assert.AreEqual("!Hi", Kata.Remove("!Hi!"));
			Assert.AreEqual("Hi! Hi", Kata.Remove("Hi! Hi"));
			Assert.AreEqual("Hi! Hi", Kata.Remove("Hi! Hi!!!"));
			Assert.AreEqual("Hi", Kata.Remove("Hi"));
		}
	}

	public partial class Kata
	{
		public static string Remove(string s)
		{
			return Regex.Replace(s, "!*$", "");
		}
	}

}
