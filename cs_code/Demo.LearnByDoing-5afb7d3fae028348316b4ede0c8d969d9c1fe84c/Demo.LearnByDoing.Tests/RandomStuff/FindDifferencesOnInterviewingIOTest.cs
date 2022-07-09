using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Xunit;

namespace Demo.LearnByDoing.Tests.RandomStuff
{
    /// <summary>
    /// https://start.interviewing.io/interview/9hV9r4HEONf9/replay
    /// 
    /// Find Differences
    /// 
    /// Given two arrays,
    /// [3, 6, 8, 12, 4]
    /// [4, 6, 8, 12]
    /// 
    /// Find an element that's not in both array
    /// Result => 3
    /// 
    /// Assumption: 2nd array is smaller
    /// </summary>
    public class FindDifferencesOnInterviewingIOTest
    {
        /// <summary>
        /// Using my own blog entry
        /// https://www.slightedgecoder.com/2017/10/07/filtering-stray-number-array/
        /// </summary>
        [Theory]
        [MemberData(nameof(GetInput))]
        public void TestUsingBitwiseOperation(int expected, int[] a1, int[] a2)
        {
            var actual = GetDifferenceUsingBitwiseOperation(a1, a2);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetInput))]
        public void TestUsingLookup(int expected, int[] a1, int[] a2)
        {
            var actual = GetDifferenceUsingLookup(a1, a2);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetInput))]
        public void TestUsingSorting(int expected, int[] a1, int[] a2)
        {
            var actual = GetDifferenceUsingSorting(a1, a2);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetInput))]
        public void TestUsingSum(int expected, int[] a1, int[] a2)
        {
            var actual = GetDifferenceUsingSum(a1, a2);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// This was not recommended due to a possible integer overflow
        /// so the recommendation was to use BigInteger, which might be slow
        /// 
        /// Space Complexity: O(1)
        /// Time Complexity: O(n)
        /// </summary>
        private int GetDifferenceUsingSum(int[] a1, int[] a2)
        {
            var bigA1 = new List<BigInteger>(a1.Select(_ => (BigInteger)_));
            var bigA2 = new List<BigInteger>(a2.Select(_ => (BigInteger)_));

            // Sum both big integer arrays
            var result = bigA1.Aggregate((acc, val) => acc + val) - bigA2.Aggregate((acc, val) => acc + val);

            // Use BigInteger's explicit conversion
            // https://msdn.microsoft.com/en-us/library/dd268292(v=vs.110).aspx
            return (int) result;
        }

        /// <summary>
        /// Space Complexity: O(1)
        /// Time Complexity: O(n log n)
        /// </summary>
        private int GetDifferenceUsingSorting(int[] a1, int[] a2)
        {
            // Easy way out using LINQ
            //return a1.Except(a2).First();

            // Harder way - you might do this in an interview.

            // In-place sorting: O(1) space complexity
            Array.Sort(a1);
            Array.Sort(a2);

            int upto = Math.Max(a1.Length, a2.Length);
            for (int i = 0; i < upto; i++)
            {
                var left = GetValueAt(a1, i);
                var right = GetValueAt(a2, i);
                if (left != right) return left;
            }

            throw new ArgumentException();
        }

        /// <summary>
        /// Space Complexity: O(n)
        /// Time Complexity: O(n)
        /// </summary>
        private int GetDifferenceUsingLookup(int[] a1, int[] a2)
        {
            var set = new HashSet<int>(a2);
            foreach (var n in a1)
            {
                if (!set.Contains(n)) return n;
            }
            throw new ArgumentException();
        }

        /// <summary>
        /// Space Complexity: O(1)
        /// Time Complexity: O(n)
        /// </summary>
        private int GetDifferenceUsingBitwiseOperation(int[] a1, int[] a2)
        {
            int result = 0;

            int upto = Math.Max(a1.Length, a2.Length);
            for (int i = 0; i < upto; i++)
            {
                var left = GetValueAt(a1, i);
                var right = GetValueAt(a2, i);
                result ^= left ^ right;
            }

            return result;
        }

        private int GetValueAt(int[] a, int index)
        {
            return a.Length <= index ? 0 : a[index];
        }

        public static IEnumerable<object[]> GetInput()
        {
            yield return new object[] { 3, new[] { 3, 6, 8, 12, 4 }, new[] { 4, 6, 8, 12 } };
            yield return new object[] { 1, new[] { 1, 2, 3, 4 }, new[] { 2, 3, 4 } };
            yield return new object[] { 3, new[] { 1, 2, 3, 4 }, new[] { 1, 2, 4 } };
        }
    }
}
