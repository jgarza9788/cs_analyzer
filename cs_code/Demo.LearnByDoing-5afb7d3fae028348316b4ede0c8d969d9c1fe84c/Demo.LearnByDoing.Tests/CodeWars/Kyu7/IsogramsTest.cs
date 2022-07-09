using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/54ba84be607a92aa900000f1/train/csharp
	/// </summary>
	[TestFixture]
	public class IsogramsTest
	{
		private static IEnumerable<TestCaseData> testCases
		{
			get
			{
				yield return new TestCaseData("Dermatoglyphics").Returns(true);
				yield return new TestCaseData("isogram").Returns(true);
				yield return new TestCaseData("moose").Returns(false);
				yield return new TestCaseData("isIsogram").Returns(false);
				yield return new TestCaseData("aba").Returns(false);
				yield return new TestCaseData("moOse").Returns(false);
				yield return new TestCaseData("thumbscrewjapingly").Returns(true);
				yield return new TestCaseData("").Returns(true);
			}
		}

		[Test, TestCaseSource("testCases")]
		public bool Test(string str) => Kata.IsIsogram(str);
	}

	public partial class Kata
	{
		public static bool IsIsogram(string str)
		{
			return new HashSet<char>(str.ToLower().ToCharArray()).Count == str.Length;
			return str.ToLower().GroupBy(c => c).All(g => g.Count() == 1);
		}
	}
}
