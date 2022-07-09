using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter05
{
    /// <summary>
    /// Flip Bit to Win:
    /// You have an integer and you can flip exactly one bit from a 0 to a 1.
    /// Write code to find the length of the longest sequence of 1s you could create.
    /// 
    /// EXAMPLE
    /// Input:  1775 (or: 11011101111)
    /// Output: 8 => Flipping 7th bit turns 1775 to => 110 + 11111111
    /// Hints: #159, #226, #314, #352
    /// </summary>
    public class Chapter5_3Test : BaseTest
    {
        private readonly Chapter5_3 _sut = new Chapter5_3();

        public Chapter5_3Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter5_3Data_SequentialCount))]
        public void TestGettingSequentialCount(int number, List<int> expected)
        {
            var actual = _sut.GetOneCount(number).ToList();

            Assert.True(expected.SequenceEqual(actual));
        }

        [Theory]
        [ClassData(typeof(Chapter5_3Data))]
        public void TestGettingLongestSequenceOfOnes(int number, int expected)
        {
            int actual = _sut.GetLongestSequenceOfOnes(number);

            Assert.Equal(expected, actual);
        }
    }
}
