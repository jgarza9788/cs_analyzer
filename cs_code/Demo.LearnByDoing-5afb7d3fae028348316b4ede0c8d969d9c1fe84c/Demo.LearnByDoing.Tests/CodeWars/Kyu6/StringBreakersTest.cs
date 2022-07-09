using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/string-breakers/train/csharp
	/// </summary>
	public class StringBreakersTest
	{
		[Fact]
		public void SampleTest()
		{
			Assert.Equal("Thisi" + "\n" + "sanex" + "\n" + "ample" + "\n" + "strin" + "\n" + "g", Kata.StringBreakers(5, "This is an example string"));
		}
	}

	public partial class Kata
	{
		public static string StringBreakers(int n, string str)
		{
			string result = "";
			str
				.Replace(" ", "")
				//.Aggregate("", (acc, c) => acc + c.ToString() + (acc.Length % n == 0 && acc.Length > 0 ? "\n" : "")));
				.Select((c, i) =>
				{
					result += (i > 0 && i % n == 0 ? "\n" : "") + c.ToString();
					return result;
				}).ToList();
			return result;
		}
	}
}
