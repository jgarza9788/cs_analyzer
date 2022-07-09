using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/which-are-in/train/csharp
	/// </summary>
	[TestFixture]
	public class WhichAreInTest
	{
		[Test]
		public void Test1()
		{
			string[] a1 = { "arp", "live", "strong" };
			string[] a2 = { "lively", "alive", "harp", "sharp", "armstrong" };
			string[] r = { "arp", "live", "strong" };
			Assert.AreEqual(r, WhichAreIn.inArray(a1, a2));
		}

		[Test]
		public void Test2()
		{
			string[] a1 = { "tarp", "mice", "bull" };
			string[] a2 = { "lively", "alive", "harp", "sharp", "armstrong" };
			string[] r = {};
			Assert.AreEqual(r, WhichAreIn.inArray(a1, a2));
		}
	}

	class WhichAreIn
	{
		public static string[] inArray(string[] a1, string[] a2)
		{
			return a2
				// Cross join - compare all - O(n x m)
				.SelectMany(s2 => a1, (s2, s1) => s2.IndexOf(s1) >= 0 ? s1 : null)
				.Where(s => !string.IsNullOrWhiteSpace(s))
				.Distinct()
				.OrderBy(s => s)
				.ToArray();
		}
	}
}
