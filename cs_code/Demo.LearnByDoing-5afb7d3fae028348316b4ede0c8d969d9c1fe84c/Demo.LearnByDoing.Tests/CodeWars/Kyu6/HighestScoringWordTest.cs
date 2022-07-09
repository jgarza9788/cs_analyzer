using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/highest-scoring-word/train/csharp
	/// </summary>
	[TestFixture]
	public class HighestScoringWordTest
	{
		private static IEnumerable<TestCaseData> TestCases
		{
			get
			{
				yield return new TestCaseData("man i need a taxi up to ubud").Returns("taxi");
				yield return new TestCaseData("what time are we climbing up to the volcano").Returns("volcano");
				yield return new TestCaseData("take me to semynak").Returns("semynak");
			}
		}

		[Test, TestCaseSource(nameof(TestCases))]
		public string Test(string s) => Kata.High(s);
	}

	public partial class Kata
	{
		public static string High(string sentence)
		{
			//var map = sentence.Split().Distinct().ToDictionary(word => word, GetScore);
			//var maxScore = map.Max(pair => pair.Value);
			//return map.FirstOrDefault(pair => pair.Value == maxScore).Key;

			// one of the answers
			//return sentence.Split().OrderBy(GetScore).LastOrDefault();

			// another clever answer
			return sentence.Split().Aggregate((l, r) => GetScore(l) > GetScore(r) ? l : r);
		}

		private static int GetScore(string word)
		{
			return word.Aggregate(0, (acc, c) => acc + (c - 'a' + 1));
		}
	}
}
