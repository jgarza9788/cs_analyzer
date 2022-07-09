using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/find-the-odd-int/train/csharp
	/// </summary>
	public class FindTheOddIntTest : BaseTest
	{
		public FindTheOddIntTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void Tests()
		{
			Assert.Equal(5, Kata.find_it(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 }));
		}

	}

	partial class Kata
	{
		public static int find_it(int[] a)
		{
			var grouped = a.GroupBy(n => n).Select(g => new {g.Key, Count = g.Count()});
			foreach (var group in grouped)
			{
				if (group.Count % 2 == 1)
					return group.Key;
			}

			return -1;
		}
	}
}
