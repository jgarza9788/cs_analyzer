using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/complementary-dna/train/csharp
	/// </summary>
	public class ComplementaryDnaTest : BaseTest
	{
		public ComplementaryDnaTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void test01()
		{
			Assert.Equal("TTTT", DnaStrand.MakeComplement("AAAA"));
		}

		[Fact]
		public void test02()
		{
			Assert.Equal("TAACG", DnaStrand.MakeComplement("ATTGC"));
		}

		[Fact]
		public void test03()
		{
			Assert.Equal("CATA", DnaStrand.MakeComplement("GTAT"));
		}
	}

	public class DnaStrand
	{
		public static string MakeComplement(string dna)
		{
			var map = new Dictionary<char, char>
			{
				{ 'A', 'T' },{ 'T', 'A' },
				{ 'C', 'G' },{ 'G', 'C' },
			};

			return string.Concat(dna.Select(c => map[c]));
		}
	}
}
