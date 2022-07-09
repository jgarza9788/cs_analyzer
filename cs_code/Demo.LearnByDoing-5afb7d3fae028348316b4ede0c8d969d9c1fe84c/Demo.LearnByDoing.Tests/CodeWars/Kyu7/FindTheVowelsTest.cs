using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/5680781b6b7c2be860000036/train/csharp
	/// </summary>
	public class FindTheVowelsTest
	{
		[Test]
		public void FixedTest()
		{
			Assert.AreEqual(new int[] { }, Kata.VowelIndices("mmm"));
			Assert.AreEqual(new [] { 1, 5 }, Kata.VowelIndices("apple"));
			Assert.AreEqual(new [] { 2, 4 }, Kata.VowelIndices("super"));
			Assert.AreEqual(new [] { 1, 3, 6 }, Kata.VowelIndices("orange"));
			Assert.AreEqual(new [] { 2, 4, 7, 9, 12, 14, 16, 19, 21, 24, 25, 27, 29, 31, 32, 33 }, Kata.VowelIndices("supercalifragilisticexpialidocious"));
		}
	}

	public partial class Kata
	{
		public static int[] VowelIndices(string word)
		{
			var map = new HashSet<char> {'a', 'e', 'i', 'o', 'u', 'y'};
			return word
				.Select((c, i) => new {c, i})
				.Where(o => map.Contains(char.ToLower(o.c)))
				.Select(o => o.i + 1).ToArray();
		}
	}
}
