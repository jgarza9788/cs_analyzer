using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/545cedaa9943f7fe7b000048/train/csharp
	/// </summary>
	public class DetectPangramTest
	{
		[Test]
		public void SampleTests()
		{
			Assert.AreEqual(true, Kata.IsPangram("The quick brown fox jumps over the lazy dog."));
			Assert.AreEqual(false, Kata.IsPangram("abc"));
			Assert.AreEqual(false, Kata.IsPangram(""));
			Assert.AreEqual(false, Kata.IsPangram(null));
		}
	}

	public partial class Kata
	{
		public static bool IsPangram(string str)
		{
			if (string.IsNullOrWhiteSpace(str)) return false;

			return str.ToLower().Where(char.IsLetter).Distinct().Count() == 26;

			var map = Enumerable.Range('a', 'z' - 'a' + 1).Select(n => (char)n).ToList();
			if (str.Length <= map.Count) return false;

			var set = new HashSet<char>(str.Select(char.ToLower));
			return map.Except(set).Count() == 0;
		}
	}
}
