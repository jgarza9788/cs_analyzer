using System.Collections.Generic;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/array-dot-diff/train/csharp
	/// </summary>
	[TestFixture]
	public class ArrayDiffTest
	{
		[Test]
		public void SampleTest()
		{
			Assert.AreEqual(new [] { 2 }, Kata.ArrayDiff(new[] { 1, 2 }, new[] { 1 }));
			Assert.AreEqual(new [] { 2, 2 }, Kata.ArrayDiff(new[] { 1, 2, 2 }, new[] { 1 }));
			Assert.AreEqual(new [] { 1 }, Kata.ArrayDiff(new[] { 1, 2, 2 }, new[] { 2 }));
			Assert.AreEqual(new [] { 1, 2, 2 }, Kata.ArrayDiff(new[] { 1, 2, 2 }, new int[] { }));
			Assert.AreEqual(new int[] { }, Kata.ArrayDiff(new int[] { }, new[] { 1, 2 }));
		}
	}

	public partial class Kata
	{
		public static int[] ArrayDiff(int[] a, int[] b)
		{
			var result = new List<int>(a);
			var set = new HashSet<int>(b);
			foreach (int item in a)
			{
				if (set.Contains(item))
					result.Remove(item);
			}

			return result.ToArray();
		}
	}
}
