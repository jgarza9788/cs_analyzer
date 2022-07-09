using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/trainer/csharp
	/// </summary>
	public class AreTheyTheSameTest : BaseTest
	{
		public AreTheyTheSameTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void Test1()
		{
			int[] a = { 121, 144, 19, 161, 19, 144, 19, 11 };
			int[] b = { 11 * 11, 121 * 121, 144 * 144, 19 * 19, 161 * 161, 19 * 19, 144 * 144, 19 * 19 };
			Assert.Equal(true, AreTheySame.comp(a, b));
		}
	}

	public class AreTheySame
	{
		public static bool comp(int[] a, int[] b)
		{
			if (a == null || b == null) return false;

			var l1 = a.ToList();
			var l2 = b.ToList();
			return l1.Select(i => i * i).OrderBy(i => i).SequenceEqual(l2.OrderBy(i => i));
		}
	}
}
