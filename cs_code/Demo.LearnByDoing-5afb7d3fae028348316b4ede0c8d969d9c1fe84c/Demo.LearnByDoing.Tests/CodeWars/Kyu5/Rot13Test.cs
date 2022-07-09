using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	public class Rot13Test : BaseTest
	{
		public Rot13Test(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData("grfg", "test")]
		[InlineData("Grfg", "Test")]
		[InlineData("URYYB", "HELLO")]
		[InlineData("Gb trg gb gur bgure fvqr!", "To get to the other side!")]
		[InlineData("Jul qvq gur puvpxra pebff gur ebnq?", "Why did the chicken cross the road?")]
		public void TestHello(string expected, string message)
		{
			Assert.Equal(expected, Kata.Rot13(message));
		}
	}

	public partial class Kata
	{
		public static string Rot13(string message)
		{
			// First working implementation
			//var inputMap = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
			//var outputMap = "NOPQRSTUVWXYZABCDEFGHIJKLMnopqrstuvwxyzabcdefghijklm".ToCharArray();
			//return string.Concat(message.Select(c => inputMap.Contains(c) ? outputMap[Array.IndexOf(inputMap, c)] : c));

			Func<string, IDictionary<char, int>> toMap = text =>
				text.Select((c, i) => new { Key = c, Value = i }).ToDictionary(o => o.Key, o => o.Value);

			var upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			var lower = "abcdefghijklmnopqrstuvwxyz";

			var input = upper + lower;
			var inputMap = toMap(input);
			var outputMap = RotateBy(upper, lower, 13).ToCharArray();
			return string.Concat(message.Select(c => inputMap.ContainsKey(c) ? outputMap[inputMap[c]] : c));
		}

		private static string RotateBy(string upper, string lower, int rotationCount)
		{
			var upperBuffer = new StringBuilder(upper.Length);
			var lowerBuffer = new StringBuilder(lower.Length);

			for (int i = 0; i < upper.Length; i++)
			{
				upperBuffer.Append(upper[(rotationCount + i) % upper.Length]);
				lowerBuffer.Append(lower[(rotationCount + i) % lower.Length]);
			}

			return string.Format("{0}{1}", upperBuffer, lowerBuffer);
		}
	}
}
