using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.RandomStuff
{
    public class PermutateTest : BaseTest
    {
        public PermutateTest(ITestOutputHelper output) : base(output)
        {
        }

        public static IEnumerable<object[]> GetOneDimensionalData()
        {
            yield return new object[] {10, 1, new[] {10}};
            yield return new object[] {10, 2, new[] {10, 20}};
            yield return new object[] {10, 3, new[] {10, 20, 30}};
            yield return new object[] {50, 1, new[] {50}};
            yield return new object[] {50, 2, new[] {50, 100}};
            yield return new object[] {50, 3, new[] {50, 100, 150}};
        }

        [Theory]
        [MemberData(nameof(GetOneDimensionalData))]
        public void TestOneDimensionalArrayPermutationSums(int number, int count, int[] expected)
        {
            var actual = GetPermutatedSums(number, count);
            Assert.True(expected.SequenceEqual(actual));
        }

        private IEnumerable<int> GetPermutatedSums(int number, int count)
        {
            throw new NotImplementedException();
        }
    }
}