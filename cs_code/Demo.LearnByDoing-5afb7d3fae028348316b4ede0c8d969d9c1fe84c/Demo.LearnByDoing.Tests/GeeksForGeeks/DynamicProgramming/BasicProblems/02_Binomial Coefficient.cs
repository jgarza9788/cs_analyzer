using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.LearnByDoing.Tests.GeeksForGeeks.DynamicProgramming.BasicProblems
{
    /// <summary>
    /// N choose K problem
    /// <see cref="https://www.geeksforgeeks.org/dynamic-programming-set-9-binomial-coefficient/"/>
    /// </summary>
    public class _02_Binomial_CoefficientTest
    {
        [Theory]
        [MemberData(nameof(GetSampleCases))]
        public void TestSampleCases(int n, int k, int expected)
        {
            var sut = new BinomialCoefficient();
            var actual = sut.GetValue(n, k);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetSampleCases()
        {
            yield return new object[] { 4, 2, 6 };
            yield return new object[] { 5, 2, 10 };
        }
    }

    class BinomialCoefficient
    {
        /// <summary>
        /// Recursively compute Binomial Coefficient
        /// <see cref="https://en.wikipedia.org/wiki/Binomial_coefficient#Recursive_formula"/>
        /// </summary>
        /// <remarks>
        /// Not sure exactly WHY this is the case though...
        /// GetValue(n, k) = GetValue(n - 1, k - 1) + GetValue(n - 1, k)
        /// GetValue(n, 0) == GetValue(n, n) = 1
        /// 
        /// It's from https://en.wikipedia.org/wiki/Binomial_coefficient#Recursive_formula
        /// </remarks>
        /// <param name="n">Total items to choose from</param>
        /// <param name="k">items to choose</param>
        /// <returns>Total number of ways to choose k from n</returns>
        public int GetValue(int n, int k)
        {
            // Base cases
            if (k == n || k == 0) return 1;

            return GetValue(n - 1, k - 1) + GetValue(n - 1, k);
        }
    }
}
