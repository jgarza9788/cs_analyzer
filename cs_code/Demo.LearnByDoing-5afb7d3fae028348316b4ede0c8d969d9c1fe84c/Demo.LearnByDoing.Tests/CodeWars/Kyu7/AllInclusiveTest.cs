using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/all-inclusive/train/csharp
	/// </summary>
	public class AllInclusiveTest : BaseTest
	{
		public AllInclusiveTest(ITestOutputHelper output) : base(output)
		{
		}

		private static void testing(Boolean actual, Boolean expected)
		{
			Assert.Equal(expected, actual);
		}

		[Fact]
		public static void test1()
		{
			Console.WriteLine("Basic Tests ContainAllRots");
			List<string> a = new List<string>() { "bsjq", "qbsj", "sjqb", "twZNsslC", "jqbs" };
			testing(Rotations.ContainAllRots("bsjq", a), true);
			a = new List<string>() { };
			testing(Rotations.ContainAllRots("", a), true);
			a = new List<string>() { "bsjq", "qbsj" };
			testing(Rotations.ContainAllRots("", a), true);
			a = new List<string>() { "TzYxlgfnhf", "yqVAuoLjMLy", "BhRXjYA", "YABhRXj", "hRXjYAB", "jYABhRX", "XjYABhR", "ABhRXjY" };
			testing(Rotations.ContainAllRots("XjYABhR", a), false);
		}
	}

	public class Rotations
	{
		public static bool ContainAllRots(string text, List<string> arr)
		{
			var allRotations = GetRotations(text).ToList();

			return !allRotations.Except(arr).Any();
		}

		private static IEnumerable<string> GetRotations(string text)
		{
			var temp = text;
			for (int i = 0; i < text.Length; i++)
			{
				temp = RotateRightOnce(temp);
				yield return temp;
			}
		}

		private static string RotateRightOnce(string text)
		{
			StringBuilder buffer = new StringBuilder(text);
			for (int i = 0; i < text.Length; i++)
			{
				buffer[(i + 1) % text.Length] = text[i];
			}

			return buffer.ToString();
		}
	}
}
