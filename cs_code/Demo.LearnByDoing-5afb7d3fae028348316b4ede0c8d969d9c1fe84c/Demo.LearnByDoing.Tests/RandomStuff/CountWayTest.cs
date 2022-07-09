using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.RandomStuff
{
	/// <summary>
	/// http://www.geeksforgeeks.org/dynamic-programming-set-7-coin-change/
	/// </summary>
	public class CountWayTest
	{
		[Fact]
		public void TestSample()
		{
			var arr = new[] { 1, 2, 3 };
			int m = arr.Length;
			int n = 4;

			var sut = new CoinChange();
			const long expected = 4;
			var actual = sut.CountWays(arr, m, n);

			Assert.Equal(expected, actual);
		}
	}

	class CoinChange
	{
		public long CountWays(int[] S, int m, int n)
		{
			//Time complexity of this function: O(mn)
			//Space Complexity of this function: O(n)

			// table[i] will be storing the number of solutions
			// for value i. We need n+1 rows as the table is
			// constructed in bottom up manner using the base
			// case (n = 0)
			// Initialize all table values as 0
			long[] table = Enumerable.Repeat(0, n + 1).Select(x => (long)x).ToArray();

			// Base case (If given value is 0)
			table[0] = 1;

			// Pick all coins one by one and update the table[]
			// values after the index greater than or equal to
			// the value of the picked coin
			for (int i = 0; i < m; i++)
				for (int j = S[i]; j <= n; j++)
					table[j] += table[j - S[i]];

			return table[n];
		}
	}
}
