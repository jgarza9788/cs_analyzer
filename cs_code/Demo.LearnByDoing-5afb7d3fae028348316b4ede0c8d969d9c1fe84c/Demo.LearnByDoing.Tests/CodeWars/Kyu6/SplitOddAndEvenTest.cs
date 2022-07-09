using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/t-dot-t-t-dot-17-split-odd-and-even/train/csharp
	/// </summary>
	[TestFixture]
	public class SplitOddAndEvenTest
	{
		[Test]
		public void BasicTests()
		{
			Assert.AreEqual(string.Join(", ", new long[] { 1, 2, 3 }), string.Join(", ", Kata.SplitOddAndEven(123)));
			Assert.AreEqual(string.Join(", ", new long[] { 22, 3 }), string.Join(", ", Kata.SplitOddAndEven(223)));
			Assert.AreEqual(string.Join(", ", new long[] { 111 }), string.Join(", ", Kata.SplitOddAndEven(111)));
			Assert.AreEqual(string.Join(", ", new long[] { 13579 }), string.Join(", ", Kata.SplitOddAndEven(13579)));
			Assert.AreEqual(string.Join(", ", new long[] { 135, 246 }), string.Join(", ", Kata.SplitOddAndEven(135246)));
			Assert.AreEqual(string.Join(", ", new long[] { 1, 2, 3, 4, 5, 6 }), string.Join(", ", Kata.SplitOddAndEven(123456)));
		}
	}

	public partial class Kata
	{
		public static long[] SplitOddAndEven(long number)
		{
			long prevBit = -1;
			var numberText = number.ToString();
			var result = new List<long>(numberText.Length);

			string upto = "";
			foreach (long n in numberText.Select(c => long.Parse(c.ToString())))
			{
				long currBit = n % 2;
				if (prevBit != currBit && !string.IsNullOrWhiteSpace(upto))
				{
					result.Add(long.Parse(upto));
					upto = n.ToString();
				}
				else
				{
					upto += n.ToString();
				}

				prevBit = currBit;
			}

			if (!string.IsNullOrWhiteSpace(upto))
				result.Add(long.Parse(upto));

			return result.ToArray();
		}
	}
}
