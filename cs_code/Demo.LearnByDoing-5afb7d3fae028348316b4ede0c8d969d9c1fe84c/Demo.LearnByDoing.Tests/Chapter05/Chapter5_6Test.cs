using System;
using System.Collections.Generic;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter05
{
    /// <summary>
    /// CONVERSION:
    /// Write a function to determine the number of bits 
    /// you would need to flip to convert integer A to integer B
    /// 
    /// EXAMPLE
    /// Input:  29 (or: 11101), 15 (or 01111)
    /// Output: 2
    /// Hints: #336, #369
    /// </summary>
    public class Chapter5_6Test : BaseTest
    {
        private readonly Chapter5_6 _sut = new Chapter5_6();

        public Chapter5_6Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter5_6Data))]
        public void TestGettingNumberOfFlippedBits(int n1, int n2, int expected)
        {
            int actual = _sut.GetFlippedBitCount3(n1, n2, _output);

            Assert.Equal(expected, actual);
        }
    }

    public class Chapter5_6
    {
        public int GetFlippedBitCount3(int n1, int n2, ITestOutputHelper output)
        {
            int count = 0;

            for (int c = n1 ^ n2; c != 0; c = c & (c - 1))
            {
                count++;
            }

            return count;
        }

        public int GetFlippedBitCount2(int n1, int n2, ITestOutputHelper output)
        {
            int count = 0;
            for (int c = n1 ^ n2; c != 0; c = c >> 1)
            {
                if ((c & 1) >= 1)
                    count++;
            }
            return count;
        }

        public int GetFlippedBitCount(int n1, int n2, ITestOutputHelper output)
        {
            int bitSize = Convert.ToString(n1, 2).Length;
            int xorValue = n1 ^ n2;

            Func<int, string> toBin = v => Convert.ToString(v, 2);
            output.WriteLine("n1: {0}({1}), n2: {2}:({3})", n1, toBin(n1), n2, toBin(n2));

            int flippedBitCount = 0;
            for (int i = 0; i < bitSize; i++)
            {
                int mask = 1 << i;
                if ((xorValue & mask) >= 1)
                {
                    output.WriteLine("mask: {0} => {1}: xorValue: {2} => {3}", mask, toBin(mask), xorValue, toBin(xorValue));
                    flippedBitCount++;
                }
            }

            return flippedBitCount;
        }
    }

    public class Chapter5_6Data : BaseTestData
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] {29, 15, 2},
            new object[] {56, 7, 6},
        };
    }
}
