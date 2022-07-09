using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/554ca54ffa7d91b236000023/train/csharp
	/// </summary>
	[TestFixture]
	public class DeleteOccurrencesOfAnElementIfItOccursMoreThanNTimesTest
	{
		[Test]
		public void TestSimple0()
		{
			var expected = new int[] { 3, 2, 1 };
			var actual = Kata.DeleteNth(new int[] { 3, 2, 2, 1, 2, 2, 1, 3, 3, 2 }, 1);

			CollectionAssert.AreEqual(expected, actual);
		}

		[Test]
		public void TestSimple1()
		{
			var expected = new int[] { 20, 37, 21 };
			var actual = Kata.DeleteNth(new int[] { 20, 37, 20, 21 }, 1);

			CollectionAssert.AreEqual(expected, actual);
		}

		[Test]
		public void TestSimple2()
		{
			var expected = new int[] { 1, 1, 3, 3, 7, 2, 2, 2 };
			var actual = Kata.DeleteNth(new int[] { 1, 1, 3, 3, 7, 2, 2, 2, 2 }, 3);

			CollectionAssert.AreEqual(expected, actual);
		}
	}

	public partial class Kata
	{
		public static int[] DeleteNth(int[] a, int x)
		{
			var result = new List<int>(a);
			var map = a.GroupBy(n => n).ToDictionary(g => g.Key, g => 0);

			for (int i = 0; i < result.Count; i++)
			{
				var key = result[i];
				map[key]++;
				if (map[key] > x)
				{
					result.RemoveAt(i);
					i--;
				}
			}

			return result.ToArray();
		}
	}
}
