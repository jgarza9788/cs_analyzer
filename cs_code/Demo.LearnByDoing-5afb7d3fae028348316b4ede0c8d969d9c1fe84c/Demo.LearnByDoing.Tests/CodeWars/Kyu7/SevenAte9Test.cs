using System.Text;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/sevenate9/train/csharp
	/// </summary>
	public class SevenAte9Test : BaseTest
	{
		public SevenAte9Test(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData("165561786121789797", "16556178612178977")]
		[InlineData("797", "77")]
		[InlineData("7979797", "7777")]
		[InlineData("797 9 7", "77 9 7")]
		[InlineData("79799997", "7799997")]
		public void ExampleTests(string input, string expected)
		{
			Assert.Equal(expected, Kata.SevenAteNine(input));
		}
	}

	public partial class Kata
	{
		public static string SevenAteNine(string str)
		{
			var buffer = new StringBuilder(str);

			for (int i = 2; i < buffer.Length; i++)
			{
				bool isSurrounded = buffer.ToString().Substring(i - 2, 3) == "797";

				if (isSurrounded)
				{
					buffer.Remove(i - 1, 1);
					i--;
				}
			}

			return buffer.ToString();
		}
	}
}
