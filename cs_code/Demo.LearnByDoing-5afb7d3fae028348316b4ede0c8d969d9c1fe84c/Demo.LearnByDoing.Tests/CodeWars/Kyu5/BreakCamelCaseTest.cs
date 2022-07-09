using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	/// <summary>
	/// https://www.codewars.com/kata/break-camelcase
	/// </summary>
	public class BreakCamelCaseTest
	{
		private static IEnumerable<TestCaseData> testCases
		{
			get
			{
				yield return new TestCaseData("camelCasing").Returns("camel Casing");
				yield return new TestCaseData("camelCasingTest").Returns("camel Casing Test");
			}
		}

		[Test, TestCaseSource("testCases")]
		public string Test(string str) => Kata.BreakCamelCase(str);
	}

	public partial class Kata
	{
		public static string BreakCamelCase(string text)
		{
			return text.Aggregate("", (acc, c) => acc + (char.IsUpper(c) ? " " : "") + c);
		}
	}
}
