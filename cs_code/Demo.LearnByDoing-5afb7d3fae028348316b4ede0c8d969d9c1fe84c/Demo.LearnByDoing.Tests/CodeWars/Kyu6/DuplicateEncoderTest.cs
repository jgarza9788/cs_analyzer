using System.Collections.Generic;
using System.Text;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	public class DuplicateEncoderTest : BaseTest
	{
		public DuplicateEncoderTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[ClassData(typeof(DuplicateEncoderBaseTestData))]
		public void TestDuplicateEncode(string word, string expected)
		{
			string actual = Kata.DuplicateEncode(word);

			Assert.Equal(expected, actual);
		}
	}

	public partial class Kata
	{
		public static string DuplicateEncode(string word)
		{
			IDictionary<char, int> map = BuildWordMap(word);

			StringBuilder buffer = new StringBuilder(word.Length);
			foreach (char c in word)
			{
				buffer.Append(map[char.ToUpper(c)] > 1 ? ")" : "(");
			}

			return buffer.ToString();
		}

		private static Dictionary<char, int> BuildWordMap(string word)
		{
			Dictionary<char, int> result = new Dictionary<char, int>();

			foreach (char c in word)
			{
				char key = char.ToUpper(c);
				if (!result.ContainsKey(key))
					result.Add(key, 0);

				result[key]++;
			}

			return result;
		}
	}

	public class DuplicateEncoderBaseTestData : BaseTestData
	{
		public override List<object[]> Data { get; set; } = new List<object[]>
		{
			new object[] { "din", "(((" },
			new object[] { "recede", "()()()" },
			new object[] { "Success", ")())())" },
			new object[] { "(( @", "))((" },
		};
	}
}
