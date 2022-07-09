using System;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	/// <summary>
	/// https://www.codewars.com/kata/double-cola/train/csharp
	/// </summary>
	public class DoubleColaTest : BaseTest
	{
		public DoubleColaTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(1, "Sheldon")]
		[InlineData(6, "Sheldon")]
		[InlineData(52, "Penny")]
		[InlineData(7230702951, "Leonard")]
		public void Test2(int n, string expected)
		{
			string[] names = { "Sheldon", "Leonard", "Penny", "Rajesh", "Howard" };
			Assert.Equal(expected, Line.WhoIsNext(names, n));
		}
	}

	public class Line
	{
		public static string WhoIsNext(string[] names, long n)
		{
			//// Get accumulation index
			//int accIndex = GetAccumulationIndex(n);

			//// Get accumulation count
			//long a = GetLengthUpto(accIndex - 1);
			//long b = GetLengthUpto(accIndex);

			//// get diff
			//long diff = b - a;

			//// Get denormalized index
			//var denormalizedIndex = n - a - 1;

			//// get normalized index
			//int i = (int) (denormalizedIndex / Math.Pow(accIndex - 1, 2));

			//// lookup the map.
			////var map = new Dictionary<char, string>
			////{
			////	{'s', "Sheldon"},
			////	{'l', "Leonard"},
			////	{'p', "Penny"},
			////	{'r', "Rajesh"},
			////	{'h', "Howard"},
			////};
			////return map["slprh"[i]];
			return names[0];
		}

		private static int GetAccumulationIndex(long n)
		{
			int acc = 5;
			for (int i = 0; i <= n; i++)
			{
				acc *= 2;
				if (acc >= n) return i;
			}
			return 0;
		}
	}
}
