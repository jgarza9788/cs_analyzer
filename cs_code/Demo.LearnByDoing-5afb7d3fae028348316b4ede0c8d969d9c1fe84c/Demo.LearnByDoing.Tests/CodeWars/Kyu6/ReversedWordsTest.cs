using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/51c8991dee245d7ddf00000e
	/// </summary>
	public class ReversedWordsTest : BaseTest
	{
		public ReversedWordsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void BasicTests()
		{
			Assert.Equal("world! hello", Kata.ReverseWords("hello world!"));
			Assert.Equal("this like speak doesn't yoda", Kata.ReverseWords("yoda doesn't speak like this"));
			Assert.Equal("foobar", Kata.ReverseWords("foobar"));
			Assert.Equal("kata editor", Kata.ReverseWords("editor kata"));
			Assert.Equal("boat your row row row", Kata.ReverseWords("row row row your boat"));
		}
	}

	public partial class Kata
	{
		public static string ReverseWords(string str)
		{
			return string.Join(" ", str.Split().Reverse());
		}
	}
}
