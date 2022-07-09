using System;
using System.Numerics;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu4
{
	/// <summary>
	/// https://www.codewars.com/kata/5324945e2ece5e1f32000370
	/// </summary>
	public class SumStringsAsNumbersTest : BaseTest
	{
		public SumStringsAsNumbersTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void Given123And456Returns579()
		{
			Assert.Equal("3", Kata.sumStrings("1", "2"));
			Assert.Equal("13", Kata.sumStrings("10", "3"));
			Assert.Equal("579", Kata.sumStrings("123", "456"));
		}
	}

	public partial class Kata
	{
		public static string sumStrings(string a, string b)
		{
			
			try
			{
				BigInteger val1;
				if (!BigInteger.TryParse(a, out val1))
					val1 = 0;

				BigInteger val2;
				if (!BigInteger.TryParse(b, out val2))
					val2 = 0;

				return (val1 + val2).ToString();
			}
			catch (Exception e)
			{
				return "";
			}
		}
	}
}
