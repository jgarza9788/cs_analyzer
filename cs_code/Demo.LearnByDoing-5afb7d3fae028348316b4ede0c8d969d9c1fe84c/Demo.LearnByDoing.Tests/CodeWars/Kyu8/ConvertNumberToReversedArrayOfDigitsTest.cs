using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu8
{
	/// <summary>
	/// https://www.codewars.com/kata/convert-number-to-reversed-array-of-digits/train/csharp
	/// </summary>
	public class ConvertNumberToReversedArrayOfDigitsTest
	{
		[Test]
		public void MyTest()
		{
			Assert.AreEqual(new long[] { 1, 3, 2, 5, 3 }, Digitizer.Digitize(35231));
		}
	}

	static class Digitizer
	{
		public static long[] Digitize(long n)
		{
			var s = n.ToString();
			var result = Digitize(s, s.Length - 1, 0).ToArray();
			return result;
		}

		private static IEnumerable<long> Digitize(string s, int startIndex, int endIndex)
		{
			if (startIndex >= endIndex) yield return long.Parse(s[startIndex].ToString());
			if (startIndex == endIndex) yield break;

			foreach (long value in Digitize(s, startIndex - 1, endIndex))
			{
				yield return value;
			}
		}
	}
}
