using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/get-the-middle-character/train/csharp
	/// </summary>
	public class GetTheMiddleCharacterTest : BaseTest
	{
		public GetTheMiddleCharacterTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void GenericTests()
		{
			Assert.Equal("es", Kata.GetMiddle("test"));
			Assert.Equal("t", Kata.GetMiddle("testing"));
			Assert.Equal("dd", Kata.GetMiddle("middle"));
			Assert.Equal("A", Kata.GetMiddle("A"));
		}
	}


	public partial class Kata
	{
		public static string GetMiddle(string s)
		{
			int mid = s.Length / 2;

			// Handle even # of characters.
			if (s.Length % 2 == 0)
				return s.Substring(mid - 1, 2);

			// Handle odd # of characters.
			return new string(s[mid], 1);
		}
	}
}
