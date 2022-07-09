using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.FEM.Algorithms.Recursion
{
    /// <summary>
    /// https://github.com/kuychaco/algoClass/blob/master/recursion/recursionIntro.js
    /// </summary>
    public class ExerciseTest : BaseTest
    {
        public ExerciseTest(ITestOutputHelper output) : base(output)
        {
        }

        public static IEnumerable<object[]> GetSampleCaseFor1And2()
        {
            yield return new object[] { new[] { 5, 4, 3, 2, 1, 0 }, 5 };
        }

        /// <summary>
        /// 1. Write a function that loops through the numbers n down to 0.
        /// If you haven't done so try using a while loop to do this.
        /// </summary>
        [Theory]
        [MemberData(nameof(GetSampleCaseFor1And2))]
        public void TestExercise1(int[] expected, int n)
        {
            var actual = Exercise1(n);
            Assert.True(expected.SequenceEqual(actual));
        }

        private IEnumerable<int> Exercise1(int n)
        {
            for (int i = n; i >= 0; i--) yield return i;
        }

        /// <summary>
        /// 2. Next, try looping just like above except using recursion
        /// </summary>
        [Theory]
        [MemberData(nameof(GetSampleCaseFor1And2))]
        public void TestExercise2(int[] expected, int n)
        {
            var actual = Exercise2(n);
            Assert.True(expected.SequenceEqual(actual));
        }

        private IEnumerable<int> Exercise2(int n)
        {
            if (n <= 0)
            {
                yield return 0;
                yield break;
            }

            yield return n;
            foreach (var i in Exercise2(n - 1).ToList()) yield return i;
        }

        public static IEnumerable<object[]> GetSampleCaseFor3And4()
        {
            yield return new object[] { 1, 8, 0 };
            yield return new object[] { 1, 1, 0 };
            yield return new object[] { 1, 2, 0 };
            yield return new object[] { 1, 3, 0 };
            yield return new object[] { 64, 8, 2 };
            yield return new object[] { 27, 3, 3 };
            yield return new object[] { 1, 1, 3 };
            yield return new object[] { 256, 2, 8 };
            yield return new object[] { 512, 2, 9 };
            yield return new object[] { 1024, 2, 10 };
        }

        /// <summary>
        /// 3. Write a function 'exponent' that takes two arguments base, and expo,
        /// uses a while loop to return the exponenet value of the base.
        /// </summary>
        [Theory]
        [MemberData(nameof(GetSampleCaseFor3And4))]
        public void TestExercise3(int expected, int @base, int expo)
        {
            var actual = Exercise3(@base, expo);
            Assert.Equal(expected, actual);
        }

        private int Exercise3(int @base, int expo)
        {
            if (expo == 0) return 1;

            var result = @base;
            for (int i = 1; i < expo; i++)
            {
                result *= @base;
            }

            return result;
        }

        /// <summary>
        /// 4. Write a function 'RecursiveExponent' that takes two arguments 
        /// base, and expo, recursively returns exponent value of the base.
        /// </summary>
        [Theory]
        [MemberData(nameof(GetSampleCaseFor3And4))]
        public void TestExercise4(int expected, int @base, int expo)
        {
            var actual = Exercise4(@base, expo);
            Assert.Equal(expected, actual);
        }

        private int Exercise4(int @base, int expo)
        {
            if (expo == 0) return 1;

            return @base * Exercise4(@base, expo - 1);
        }

        public static IEnumerable<object[]> GetSampleCaseFor5And6()
        {
            yield return new object[] { new[] { 2, 4, 6, 8 }, new[] { 1, 2, 3, 4 }, 2 };
        }

        /// <summary>
        /// 5. Write a function 'recursiveMultiplier' that takes two arguments, 
        /// 'arr and num', and multiplies each arr value into by num and returns an array of the values.
        /// </summary>
        [Theory]
        [MemberData(nameof(GetSampleCaseFor5And6))]
        public void TestExercise5(int[] expected, int[] a, int num)
        {
            var actual = Exercise5(a, num);
            Assert.True(expected.SequenceEqual(actual));
        }

        private IEnumerable<int> Exercise5(int[] a, int num)
        {
            foreach (var val in a)
            {
                yield return val * num;
            }
        }

        /// <summary>
        /// 6. Write a function 'recursiveReverse' that takes an array 
        /// and uses recursion to return its contents in reverse
        /// </summary>
        [Theory]
        [MemberData(nameof(GetSampleCaseFor5And6))]
        public void TestExercise6(int[] expected, int[] a, int num)
        {
            var actual = Exercise6(a, num, a.Length - 1);
            Assert.True(expected.Reverse().SequenceEqual(actual));
        }

        private IEnumerable<int> Exercise6(int[] a, int num, int i)
        {
            if (i < 0) yield break;

            yield return a[i] * num;
            foreach (int n in Exercise6(a, num, i - 1)) yield return n;
        }

        /// <summary>
        /// https://github.com/kuychaco/algoClass/blob/master/recursion/factorial.js
        /// </summary>
        [Fact]
        public void TestFactorial()
        {
            const int expected = 120;
            var actual = Factorial(5);
            Assert.Equal(expected, actual);
        }

        private int Factorial(int n)
        {
            if (n <= 1) return 1;

            return n * Factorial(n - 1);
        }

        /// <summary>
        /// https://github.com/kuychaco/algoClass/blob/master/recursion/fibonacci.js
        /// </summary>
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(3, 4)]
        [InlineData(5, 5)]
        [InlineData(8, 6)]
        [InlineData(13, 7)]
        [InlineData(21, 8)]
        [InlineData(34, 9)]
        public void TestFib(int expected, int n)
        {
            var actual = Fib(n);
            Assert.Equal(expected, actual);
        }

        private int Fib(int n)
        {
            if (n <= 1) return n;

            return Fib(n - 1) + Fib(n - 2);
        }

        [Theory]
        [InlineData(5, 10, 5)]
        [InlineData(2, 10, 2)]
        [InlineData(3, 10, 1)]
        [InlineData(6, 12, 6)]
        [InlineData(4, 12, 4)]
        [InlineData(8, 12, 4)]
        public void TestGreatestCommonDivisor(int x, int y, int expected)
        {
            var actual = GetGreatestCommonDivisor(x, y);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Cheated using https://en.wikipedia.org/wiki/Greatest_common_divisor#Using_Euclid's_algorithm
        /// </summary>
        private int GetGreatestCommonDivisor(int x, int y)
        {
            if (y == 0) return x;
            if (x == 0) return y;

            return GetGreatestCommonDivisor(y, x % y);
        }

        [Theory]
        [InlineData(new []{4,3,2,1}, new [] {1,2,3,4})]
        public void TestReverseSequence(int[] expected, int[] sequence)
        {
            var actual = ReverseSequence(sequence, sequence.Length - 1);
            Assert.True(expected.SequenceEqual(actual));
        }

        private IEnumerable<int> ReverseSequence(int[] sequence, int index)
        {
            if (index < 0) yield break;

            yield return sequence[index];
            foreach (var n in ReverseSequence(sequence, index - 1)) yield return n;
        }

        [Theory]
        [InlineData(new []{"abc", "acb", "bac", "bca", "cab", "cba"}, "abc")]
        public void TestNonDupePermuntations(string[] expected, string text)
        {
            var actual = GetNonDupePermutations(text).ToList();
            Assert.True(expected.OrderBy(_=>_).SequenceEqual(actual.OrderBy(_=>_)));
        }

        private IEnumerable<string> GetNonDupePermutations(string text)
        {
            if (text.Length == 1)
            {
                yield return text;
                yield break;
            }

            if (text.Length == 2)
            {
                yield return text;
                yield return string.Concat(text[1], text[0]);
                yield break;
            }

            for (var index = 0; index < text.Length; index++)
            {
                var prefix = text[index].ToString();
                var rest = string.Concat(text.Take(index)) + string.Concat(text.Skip(index + 1));
                foreach (var perm in GetNonDupePermutations(rest).ToList())
                {
                    _output.WriteLine($"prefix + perm = {prefix + perm}");
                    yield return prefix + perm;
                }
            }
        }
    }
}
