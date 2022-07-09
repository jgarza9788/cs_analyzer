using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/integer-depth/train/csharp
	/// </summary>
	[TestFixture]
	public class IntegerDepthTest
	{
		[Test]
		public void SampleTest1()
		{
			Assert.AreEqual(10, Kata.ComputeDepth(1));
		}

		[Test]
		public void SampleTest2()
		{
			Assert.AreEqual(9, Kata.ComputeDepth(42));
		}
	}

	public partial class Kata
	{
		public static int ComputeDepth(int n)
		{
			var isSeen = new HashSet<int>();
			var depth = 0;

			// do until isSeen contains all numbers between 0 and 9.
			do
			{
				depth++;

				var digits = GetDigits(n, depth);
				digits.Select(isSeen.Add).ToList();
			} while (!HasAllDigits(isSeen));

			return depth;
		}

		private static IEnumerable<int> GetDigits(int n, int depth)
		{
			return (n * depth).ToString().Select(c => c - '0');
		}

		private static bool HasAllDigits(HashSet<int> isSeen)
		{
			const int upto = 9;
			for (int i = 0; i <= upto; i++)
			{
				if (!isSeen.Contains(i)) return false;
			}

			return true;
		}
	}
}
