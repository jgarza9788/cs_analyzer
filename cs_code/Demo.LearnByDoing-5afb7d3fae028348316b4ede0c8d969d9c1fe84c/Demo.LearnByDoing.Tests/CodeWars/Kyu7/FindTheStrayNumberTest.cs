using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/57f609022f4d534f05000024/
	/// </summary>
	public class FindTheStrayNumberTest : BaseTest
	{
		public FindTheStrayNumberTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void SimpleArray1()
		{
			Assert.Equal(2, Solution.Stray(new int[] { 1, 1, 2 }));
		}
	}

	class Solution
	{
		public static int Stray(int[] numbers)
		{
			return numbers
				.GroupBy(n => n)
				.Select(g => new { Key = g.Key, Count = g.Count() })
				.Where(o => o.Count % 2 == 1).FirstOrDefault().Key;
		}
	}
}
