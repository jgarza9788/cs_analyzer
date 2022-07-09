using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeSignal.Hashtable
{
    /// <summary>
    /// Question on
    /// https://app.codesignal.com/interview-practice/task/rMe9ypPJkXgk3MHhZ
    /// </summary>
    public class PossibleSumsTest : BaseTest
    {
        public PossibleSumsTest(ITestOutputHelper output) : base(output)
        {
        }

        public static IEnumerable<object[]> GetSamples()
        {
            yield return new object[]
            {
                new[] {10, 50, 60, 100, 110, 150, 160, 200, 210},
                new[] {10, 50, 100}, new[] {1, 2, 1}
            };
        }

        public static IEnumerable<object[]> GetCodeSignalTestData()
        {
//            yield return new object[] {122, new[] {10, 50, 100, 500}, new[] {5, 3, 2, 2}};
//            yield return new object[] {9, new[] {10, 50, 100}, new[] {1, 2, 1}};
//            yield return new object[] {50004, new[] {1, 2}, new[] {50000, 2}};
//            yield return new object[] {5, new[] {1}, new[] {5}};
//            yield return new object[] {5, new[] {1, 1}, new[] {2, 3}};
//            yield return new object[] {30008, new[] {1, 2, 3}, new[] {2, 3, 10000}};
//            yield return new object[] {521, new[] {3, 1, 1}, new[] {111, 84, 104}};
            yield return new object[] {77, new[] {1, 1, 1, 1, 1}, new[] {9, 19, 18, 12, 19}};
        }

        [Theory]
        [MemberData(nameof(GetCodeSignalTestData))]
        public void TestCodeSignalTestCases(int expected, int[] coins, int[] quantity)
        {
            var actual = GetSums(coins, quantity).Count();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetSamples))]
        public void TestHappyPaths(int[] expected, int[] coins, int[] quantity)
        {
            var actual = GetSums(coins, quantity);
            Assert.True(expected.OrderBy(_ => _).SequenceEqual(actual));
        }

        private IEnumerable<int> GetSums(int[] coins, int[] quantity)
        {
            var sums = new HashSet<int>();
            GetSums(coins, quantity, 0, sums, 0);
            return sums;
        }

        private int? GetSums(int[] coins, int[] quantity, int startIndex, HashSet<int> sums, int acc)
        {
            if (startIndex >= coins.Length) return null;

            int? sum = null;
            for (int s = startIndex; s < coins.Length; s++)
            {
                for (int q = 1; q <= quantity[startIndex]; q++)
                {
                    for (int e = s; e < coins.Length; e++)
                    {
                        var currentValue = q * coins[s];
                        if (!sums.Contains(currentValue)) sums.Add(currentValue);
                        if (!sums.Contains(currentValue + acc)) sums.Add(currentValue + acc);

                        var nextValue = (GetSums(coins, quantity, s + 1, sums, currentValue + acc) ?? 0);
                        sum = currentValue + nextValue;
                        if (!sums.Contains(sum.Value)) sums.Add(sum.Value);
                        if (!sums.Contains(sum.Value + acc)) sums.Add(sum.Value + acc);
                    }
                }
            }

            return sum;
        }
    }
}