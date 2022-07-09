using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/symbols-counted/train/csharp
	/// </summary>
	public class SymbolsCountedTest
	{
		[Theory, MemberData(nameof(GetTestCases))]
		public void TestSampleCases(string input, string expected)
		{
			var actual = Kata.Transform(input);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetTestCases()
		{
			yield return new object[] {"elevation", "e2lvation"};
			yield return new object[] {"transplantology", "t2ra2n2spl2o2gy"};
			yield return new object[] {"economics", "ec2o2nmis"};
			yield return new object[] {"embarrassed", "e2mba2r2s2d"};
			yield return new object[] {"impressive", "i2mpre2s2v"};
		}
	}

	public partial class Kata
	{
		public static string Transform(string input)
		{
			return string.Concat(input
				.Select((c, i) => Tuple.Create(c, i))
				.GroupBy(tuple => tuple.Item1)
				.Aggregate("", (acc, o) => acc + o.Key + (o.Count() > 1 ? o.Count().ToString() : "")));
		}
	}
}
