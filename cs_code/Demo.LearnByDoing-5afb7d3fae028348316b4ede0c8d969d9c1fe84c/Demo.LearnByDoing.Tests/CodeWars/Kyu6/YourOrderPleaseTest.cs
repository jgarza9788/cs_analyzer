using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/your-order-please
	/// </summary>
	[TestFixture]
	public class YourOrderPleaseTest
	{
		[Test, Description("Sample Tests")]
		public void SampleTest()
		{
			Assert.AreEqual("Thi1s is2 3a T4est", Kata.Order("is2 Thi1s T4est 3a"));
			Assert.AreEqual("Fo1r the2 g3ood 4of th5e pe6ople", Kata.Order("4of Fo1r pe6ople g3ood th5e the2"));
			Assert.AreEqual("", Kata.Order(""));
		}
	}

	public partial class Kata
	{
		public static string Order(string words)
		{
			if (string.IsNullOrWhiteSpace(words)) return string.Empty;

			// to match a number (between 0-9) only.
			const string pattern = @"\d";
			var ordered = words
				.Split()
				// Extract and save position as a key to sort by it.
				.ToDictionary(word => int.Parse(Regex.Match(word, pattern).Value), word => word)
				// Sort by the position matched by regex.
				.OrderBy(pair => pair.Key);
			return string.Join(" ", ordered.Select(pair => pair.Value));
		}
	}
}
