using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/trainer/csharp
	/// </summary>
	public class SumOfASequenceTest
	{
		[Test]
		public void BasicTest()
		{
			Assert.AreEqual(12, Kata.SequenceSum(2, 6, 2));
			Assert.AreEqual(15, Kata.SequenceSum(1, 5, 1));
			Assert.AreEqual(5, Kata.SequenceSum(1, 5, 3));
			Assert.AreEqual(45, Kata.SequenceSum(0, 15, 3));
			Assert.AreEqual(0, Kata.SequenceSum(16, 15, 3));
			Assert.AreEqual(26, Kata.SequenceSum(2, 24, 22));
			Assert.AreEqual(2, Kata.SequenceSum(2, 2, 2));
			Assert.AreEqual(2, Kata.SequenceSum(2, 2, 1));
			Assert.AreEqual(35, Kata.SequenceSum(1, 15, 3));
			Assert.AreEqual(0, Kata.SequenceSum(15, 1, 3));
		}
	}

	public partial class Kata
	{
		public static int SequenceSum(int start, int end, int step)
		{
			if (start > end) return 0;

			return Enumerable
				.Range(start, end - start + 1)
				.Where((n, i) => i % step == 0)
				.Sum();
		}
	}
}
