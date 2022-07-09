using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	/// <summary>
	/// https://www.codewars.com/kata/int32-to-ipv4/train/csharp
	/// </summary>
	public class Int32ToIP4Test
	{
		[Theory]
		[InlineData(2154959208, "128.114.17.104")]
		[InlineData(0, "0.0.0.0")]
		[InlineData(2149583361, "128.32.10.1")]
		public void Test(uint input, string expected)
		{
			Assert.Equal(expected, Kata.UInt32ToIP(input));
		}
	}

	public partial class Kata
	{
		private const int BYTE_SIZE = 8;

		public static string UInt32ToIP(uint ip)
		{
			//var binaryText = Convert.ToString(ip, 2).PadLeft(32, '0');
			//var numbers = GetNumbers(binaryText);
			//return string.Join(".", numbers.Select(number => Convert.ToString(number)));

			// One of the answers on solutions page.
			return string.Join(".", new[] {24, 16, 8, 0}.Select(e => (ip >> e) & 255));
		}

		private static IEnumerable<uint> GetNumbers(string binaryText)
		{
			Func<string, int, string> getText = (text, skipBy) => string.Concat(text.Skip(skipBy).Take(BYTE_SIZE));

			for (int i = 0; i < 4; i++)
			{
				yield return Convert.ToUInt32(getText(binaryText, i * BYTE_SIZE), 2);
			}
		}
	}
}

