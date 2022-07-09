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
	/// <summary>
	/// https://www.codewars.com/kata/what-doesnt-belong-to-these
	/// </summary>
	public class WhatDoesntBelongToTheseTest : BaseTest
	{
		public WhatDoesntBelongToTheseTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[MemberData(nameof(GetTestCases))]
		public void ExampleTests(object[] series, object expected)
		{
			object actual = Kata.FindTheNotFittingElement(series);
		}

		public static IEnumerable<object[]> GetTestCases()
		{
			yield return new object[] { new object[] { 1, 2, 2, 2, 2 }, 1 };
			yield return new object[] { new object[] { true, true, true, false, true }, false };
			yield return new object[] { new object[] { 'a', 'a', 'b', 'a', 'a', 'a', 'a' }, 'b' };
			yield return new object[] { new object[] { '1', 2, '4', '6', '8' }, 2 };
			yield return new object[] { new object[] { 2, 2, 2, 2, 2, '2' }, '2' };
			yield return new object[] { new object[] { 1, 2, 4, 6, true }, true };
			yield return new object[] { new object[] { 1, 2, 4, 6, 10 }, 1 };
			yield return new object[] { new object[] { 2, 2, -2, 6, 10 }, -2 };
			yield return new object[] { new object[] { 'Z', 'L', 'P', 't', 'G' }, 't' };
			yield return new object[] { new object[] { 'Z', 'L', '3', 't', 'G' }, '3' };
			yield return new object[] { new object[] { 'Z', 'L', '3', 't', 4 }, 4 };
			yield return new object[] { new object[] { 'Z', 'e', '.', 'a', 'G' }, '.' };
		}

	}

	public partial class Kata
	{
		public static object FindTheNotFittingElement(object[] series)
		{
			return null;
		}
	}
}
