using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.GeeksForGeeks.DynamicProgramming.BasicConcepts
{
    /// <summary>
    /// Refer to https://www.geeksforgeeks.org/dynamic-programming-set-1/
    /// </summary>
    public class _01_Overlapping_Subproblems_Property
    {
        [Theory]
        [MemberData(nameof(GetSampleCases))]
        public void TestFibonacciMemoization(int upto, int expected)
        {
            var sut = new GfgFibonacci();
            int actual = sut.GetFibonacciUptoUsingRecursiveMemoization(upto);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetSampleCases))]
        public void TestFibonacciTabulation(int upto, int expected)
        {
            var sut = new GfgFibonacci();
            int actual = sut.GetFibonacciUptoUsingTabulation(upto);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetSampleCases()
        {
            yield return new object[] { 1, 1 };
            yield return new object[] { 2, 1 };
            yield return new object[] { 3, 2 };
            yield return new object[] { 4, 3 };
            yield return new object[] { 40, 102334155 };
            yield return new object[] { 45, 1134903170 };
        }
    }

    public class GfgFibonacci
    {
        private List<int> _memoization;
        private const int NIL = -1;

        /// <summary>
        /// Build from bottom up.
        /// </summary>
        public int GetFibonacciUptoUsingTabulation(int upto)
        {
            int[] table = new int[upto + 1];
            table[0] = 0;
            table[1] = 1;

            for (int i = 2; i <= upto; i++)
            {
                table[i] = table[i - 1] + table[i - 2];
            }

            return table[upto];
        }

        /// <summary>
        /// Build from Top to bottom
        /// </summary>
        public int GetFibonacciUptoUsingRecursiveMemoization(int upto)
        {
            if (_memoization == null)
                _memoization = Enumerable.Repeat(NIL, upto + 1).ToList();

            if (_memoization[upto] == NIL)
            {
                if (upto <= 1)
                    _memoization[upto] = upto;
                else
                    _memoization[upto] = GetFibonacciUptoUsingRecursiveMemoization(upto - 1) + GetFibonacciUptoUsingRecursiveMemoization(upto - 2);
            }

            return _memoization[upto];
        }
    }
}
