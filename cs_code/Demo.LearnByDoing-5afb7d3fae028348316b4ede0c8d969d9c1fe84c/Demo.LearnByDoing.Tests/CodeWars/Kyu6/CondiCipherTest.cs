using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	public class CondiCipherTest : BaseTest
	{
		public CondiCipherTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestKeyGeneration()
		{
			// cryptogambdefhijklnqsuvwxz
			Dictionary<char, int> expected = new Dictionary<char, int>
			{
				{'c', 1}, {'r', 2}, {'y', 3}, {'p', 4}, {'t', 5},
				{'o', 6}, {'g', 7}, {'a', 8}, {'m', 9}, {'b', 10},
				{'d', 11}, {'e', 12}, {'f', 13}, {'h', 14}, {'i', 15},
				{'j', 16}, {'k', 17}, {'l', 18}, {'n', 19}, {'q', 20},
				{'s', 21}, {'u', 22}, {'v', 23}, {'w', 24}, {'x', 25},
				{'z', 26}
			};

			//var expected = "cryptogambdefhijklnqsuvwxz";
			var actual = Kata.GetMap("cryptogram");
			//Assert.Equal(expected, actual);
			Assert.True(expected.SequenceEqual(actual));
		}

		[Theory]
		[InlineData("jx", "on", "cryptogam", 10)]
		[InlineData("cytgmdfmbk", "cryptogram", "cryptogam", 0)]
		[InlineData("jx wnz xrkvz jnd l ufd vwcz.", "on the first day i got lost.", "cryptogam", 10)]
		[InlineData("n ggka cvssb bfe esz omgdyr bqqva", "i will never eat any grapes again", "superkey", 4)]
		public void TestEncoding(string expected, string message, string key, int initShift)
		{
			Assert.Equal(expected, Kata.Encode(key, message, initShift));
		}

		[Theory]
		//[InlineData("on", "jx", "cryptogam", 10)]
		//[InlineData("....", "....", "cryptogam", 10)]
		//[InlineData("sit", "abc", "keykeykeykey", 10)]
		//[InlineData(",sit", ",abc", "keykeykeykey", 10)]
		//[InlineData("on the first day i got lost.", "jx wnz xrkvz jnd l ufd vwcz.", "cryptogam", 10)]
		[InlineData("i will never eat any grapes again", "n ggka cvssb bfe esz omgdyr bqqva", "superkey", 30)]
		[InlineData("zva nguhbmmgydx.s,ok se,rmafz vpedgbua", "qvf cmnxmdkjfca.p,ab mf,byokf vjhwpcyb", "nqhbfgmi", 28)]
		public void TestDecoding(string expected, string message, string key, int initShift)
		{
			Assert.Equal(expected, Kata.Decode(key, message, initShift));
		}
	}

	public partial class Kata
	{
		public static string Encode(string key, string message, int initShift)
		{
			var map = GetMap(key);
			Func<int, int> shiftBy = i =>
			{
				var index = (map.Count + i) % map.Count;
				return index == 0 ? map.Count : index;
			};

			var buffer = new StringBuilder(message.Length);
			int nextShift = shiftBy(initShift);

			foreach (char c in message)
			{
				if (!map.ContainsKey(c))
				{
					buffer.Append(c);
					continue;
				}

				int currIndex = map[c];
				var encodeIndex = shiftBy(currIndex + nextShift);
				char encodedChar = map.First(pair => pair.Value == encodeIndex).Key;
				buffer.Append(encodedChar);

				nextShift = shiftBy(map[c]);
			}

			return buffer.ToString();

		}

		public static string Decode(string key, string message, int initShift)
		{
			var map = GetMap(key);
			Func<int, int> shiftBy = i =>
			{
				if (i == 0) return map.Count;

				var index = (map.Count - i) % map.Count;
				return index == 0 ? map.Count : index;
			};

			var buffer = new StringBuilder(message.Length);
			int nextShift = shiftBy(initShift);

			foreach (char c in message)
			{
				if (!map.ContainsKey(c))
				{
					buffer.Append(c);
					continue;
				}

				int currIndex = map[c];
				var encodeIndex = shiftBy(currIndex + nextShift);
				char encodedChar = map.First(pair => pair.Value == encodeIndex).Key;
				buffer.Append(encodedChar);

				nextShift = shiftBy(map[c]);
			}

			return buffer.ToString();
		}

		public static Dictionary<char, int> GetMap(string key)
		{
			var map = key
				.Distinct()
				.Select((c, i) => new { Key = c, Value = i + 1 })
				.ToDictionary(o => o.Key, o => o.Value);

			int offset = map.Count;
			var aToZ = Enumerable.Range('a', 'z' - 'a' + 1).ToList();
			var rest = aToZ.Where(n => !map.ContainsKey((char) n)).ToList();

			for (int i = 0; i < aToZ.Count - offset; i++)
			{
				map.Add((char)rest[i], i + offset + 1);
			}

			return map;
		}
	}
}
