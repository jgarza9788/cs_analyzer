using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	public class PersistentBuggerTest : BaseTest
	{
		public PersistentBuggerTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(39, 3)]
		[InlineData(999, 4)]
		[InlineData(4, 0)]
		[InlineData(25, 2)]
		public void TestPersistence(long number, int expected)
		{
			int actual = Persist.Persistence(number);
			Assert.Equal(expected, actual);
		}
	}

	public class Persist
	{
		public static int Persistence(long number)
		{
			var digits = GetDigits(number).ToList();
			if (digits.Count <= 1) return 0;

			int counter = 0;
			do
			{
				counter++;

				int newNum = digits.Aggregate(1, (a, b) => a * b);
				digits = GetDigits(newNum).ToList();
				if (digits.Count <= 1) return counter;
			} while (digits.Count > 1);

			return counter;
		}

		private static IEnumerable<int> GetDigits(long number)
		{
			foreach (char c in number.ToString())
			{
				yield return c - '0';
			}
		}
	}
}
