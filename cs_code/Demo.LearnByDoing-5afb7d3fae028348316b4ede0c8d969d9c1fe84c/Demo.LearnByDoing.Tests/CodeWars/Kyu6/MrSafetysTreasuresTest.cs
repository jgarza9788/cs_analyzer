using System.Collections.Generic;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/mr-safetys-treasures/train/csharp
	/// </summary>
	public class MrSafetysTreasuresTest : BaseTest
	{
		public MrSafetysTreasuresTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void BasicTest()
		{
			Assert.Equal("66542", Kata.Unlock("Nokia"));
			Assert.Equal("82588", Kata.Unlock("Valut"));
			Assert.Equal("864538", Kata.Unlock("toilet"));
		}
	}

	public partial class Kata
	{
		public static string Unlock(string str)
		{
			var map = GetMap();
			string result = "";

			foreach (char c in str)
			{
				result += map[char.ToLower(c)];
			}

			return result;
		}

		private static Dictionary<char, string> GetMap()
		{
			return new Dictionary<char, string>
			{
				{ 'a', "2" },
				{ 'b', "2" },
				{ 'c', "2" },

				{ 'd', "3" },
				{ 'e', "3" },
				{ 'f', "3" },


				{ 'g', "4" },
				{ 'h', "4" },
				{ 'i', "4" },


				{ 'j', "5" },
				{ 'k', "5" },
				{ 'l', "5" },


				{ 'm', "6" },
				{ 'n', "6" },
				{ 'o', "6" },


				{ 'p', "7" },
				{ 'q', "7" },
				{ 'r', "7" },
				{ 's', "7" },


				{ 't', "8" },
				{ 'u', "8" },
				{ 'v', "8" },


				{ 'w', "9" },
				{ 'x', "9" },
				{ 'y', "9" },
				{ 'z', "9" },

			};
		}
	}
}
