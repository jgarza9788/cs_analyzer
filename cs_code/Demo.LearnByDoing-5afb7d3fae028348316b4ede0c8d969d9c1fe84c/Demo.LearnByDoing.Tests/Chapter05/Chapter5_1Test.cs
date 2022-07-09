using System;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter05
{
    /// <summary>
    /// INSERTION:
    /// You are given two 32-bit numbers, N and M, and two bit positions, i and j.
    /// Write a method to insert M into N such that M starts at bit j and ends at bit i.
    /// You can assume that the bits j through i have enough space to fit all of M.
    /// That is, if M = 10011, you can assume that there are at least 5 bits between j and i.
    /// You would not, for example, have j = 3 and i = 2, 
    /// because M could not fully fit between bit 3 and bit 2.
    /// 
    /// EXAMPLE
    /// Input:  N = 10000000000, M = 10011, i = 2, j = 6
    /// Output: N = 10001001100
    /// 
    /// Hints: #137, #169, #215
    /// </summary>
    public class Chapter5_1Test : BaseTest
    {
        private readonly Chapter5_1 _sut = new Chapter5_1();

        public Chapter5_1Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TestUpdateBits()
        {
            const int n = 1024;
            const int m = 19;
            const int i = 2;
            const int j = 6;
            const int expected = 1100;

            int actual = _sut.UpdateBits(n, m, i, j);

            Func<int, string> toBin = value => Convert.ToString(value, 2);
            _output.WriteLine("n = {0} => m => {1} <= expected: {2} but actual = {3}", 
                toBin(n), toBin(m), toBin(expected), toBin(actual));

            Assert.Equal(expected, actual);
        }
    }

    public class Chapter5_1
    {
        private string ToBin(int value)
        {
            return Convert.ToString(value, 2);
        }

        public int UpdateBits(int n, int m, int i, int j)
        {
            int allOnes = ~0;
            int left = allOnes << (j + 1);

            int right = 0;
            for (int x = 0; x < i; x++)
            {
                right += (1 << x);
                Console.WriteLine(Convert.ToString(right, 2));
            }

            int clearedN = n & (left | right);
            int shiftedM = m << i;

            return clearedN | shiftedM;
        }
    }
}
