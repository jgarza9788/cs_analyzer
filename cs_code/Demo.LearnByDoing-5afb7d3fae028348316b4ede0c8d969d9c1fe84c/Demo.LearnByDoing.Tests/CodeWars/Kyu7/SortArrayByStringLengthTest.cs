using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/sort-array-by-string-length/train/csharp
	/// </summary>
	[TestFixture]
	public class SortArrayByStringLengthTest
	{
		[Test]
		public void ExampleTests()
		{
			Assert.AreEqual(new [] { "I", "To", "Beg", "Life" }, Kata.SortByLength(new [] { "Beg", "Life", "I", "To" }));
			Assert.AreEqual(new [] { "", "Pizza", "Brains", "Moderately" }, Kata.SortByLength(new[] { "", "Moderately", "Brains", "Pizza" }));
			Assert.AreEqual(new [] { "Short", "Longer", "Longest" }, Kata.SortByLength(new[] { "Longer", "Longest", "Short" }));
		}
	}

	public partial class Kata
	{
		public static string[] SortByLength(string[] array)
		{
			return array.OrderBy(str => str.Length).ToArray();
		}
	}
}
