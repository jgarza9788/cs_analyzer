using System;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/moves-in-squared-strings-i/train/csharp
	/// </summary>
	public class MovesInSquaredStringsTest : BaseTest
	{
		public MovesInSquaredStringsTest(ITestOutputHelper output) : base(output)
		{
		}
		
		private static void testing(string actual, string expected)
		{
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestVerticalMirror()
		{
			Console.WriteLine("Fixed Tests VertMirror");
			testing(Opstrings.Oper(Opstrings.VertMirror, 
				"hSgdHQ\nHnDMao\nClNNxX\niRvxxH\nbqTVvA\nwvSyRu"),
				"QHdgSh\noaMDnH\nXxNNlC\nHxxvRi\nAvVTqb\nuRySvw");
			testing(Opstrings.Oper(Opstrings.VertMirror, 
				"IzOTWE\nkkbeCM\nWuzZxM\nvDddJw\njiJyHF\nPVHfSx"),
				"EWTOzI\nMCebkk\nMxZzuW\nwJddDv\nFHyJij\nxSfHVP");
		}

		[Fact]
		public void TestHorizontalMirror()
		{
			Console.WriteLine("Fixed Tests HorMirror");
			testing(Opstrings.Oper(Opstrings.HorMirror, "lVHt\nJVhv\nCSbg\nyeCt"), "yeCt\nCSbg\nJVhv\nlVHt");
			testing(Opstrings.Oper(Opstrings.HorMirror, "njMK\ndbrZ\nLPKo\ncEYz"), "cEYz\nLPKo\ndbrZ\nnjMK");
		}
	}

	public class Opstrings
	{
		public static string VertMirror(string text)
		{
			return string.Join("\n", text.Split('\n').Select(s => new string(s.Reverse().ToArray())));
		}

		public static string HorMirror(string text)
		{
			return string.Join("\n", text.Split('\n').Reverse());
		}

		public static string Oper(Func<string, string> strategy, string text)
		{
			return strategy(text);
		}
	}
}
