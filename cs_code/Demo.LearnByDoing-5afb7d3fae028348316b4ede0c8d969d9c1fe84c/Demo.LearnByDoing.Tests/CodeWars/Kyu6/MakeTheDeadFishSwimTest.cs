using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/make-the-deadfish-swim/train/csharp
	/// </summary>
	[TestFixture]
	public class MakeTheDeadFishSwimTest
	{
		private static object[] _sampleTestCases = {
			new object[] {"iiisdoso", new[] {8, 64}},
			new object[] {"iiisdosodddddiso", new[] {8, 64, 3600}}
		};

		[Test, TestCaseSource(nameof(_sampleTestCases))]
		public void SampleTest(string data, int[] expected)
		{
			Assert.AreEqual(expected, Deadfish.Parse(data));
		}

		[Test, TestCaseSource(nameof(_sampleTestCases))]
		public void TestIterativeVersion(string data, int[] expected)
		{
			Assert.AreEqual(expected, Deadfish.ParseIteratively(data));
		}
	}

	public class Deadfish
	{
		public static int[] ParseIteratively(string data)
		{
			var results = new List<int>();
			var sum = 0;
			foreach (var cmd in data)
			{
				switch (cmd)
				{
					case 'i':
						sum++;
						break;
					case 'd':
						sum--;
						break;
					case 's':
						sum = sum * sum;
						break;
					case 'o':
						results.Add(sum);
						break;
				}
			}
			return results.ToArray();
		}

		public static int[] Parse(string data)
		{
			var result = new List<int>();

			var commands = new Dictionary<char, Func<int, int>>
			{
				{'i', n => ++n },
				{'d', n => --n },
				{'s', n => n * n },
				{'o', n => { result.Add(n); return n; } }
			};

			var value = 0;
			data.Select(c => value = commands[c](value)).ToList();

			return result.ToArray();
		}
	}
}
