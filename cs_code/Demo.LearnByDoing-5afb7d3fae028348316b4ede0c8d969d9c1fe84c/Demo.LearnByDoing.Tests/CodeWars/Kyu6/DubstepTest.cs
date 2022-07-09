using System.Linq;
using System.Text.RegularExpressions;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{

	public class DubstepTest : BaseTest
	{
		public DubstepTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData("WUBWUBABCWUB", "ABC")]
		[InlineData("RWUBWUBWUBLWUB", "R L")]
		public void TestDecoder(string input, string expected)
		{
			string actual = Dubstep.SongDecoder(input);
			Assert.Equal(expected, actual);
		}
	}

	public class Dubstep
	{
		public static string SongDecoder(string input)
		{
			const string pattern = "(?:WUB)";
			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
			var split = regex.Split(input).Where(word => !string.IsNullOrWhiteSpace(word)).ToList();

			return string.Join(" ", split);
		}
	}
}
