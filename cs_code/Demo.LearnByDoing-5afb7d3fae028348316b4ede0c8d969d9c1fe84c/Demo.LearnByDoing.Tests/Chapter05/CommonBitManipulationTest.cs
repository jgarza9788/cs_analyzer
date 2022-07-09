using System;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter05
{
    public class CommonBitManipulationTest : BaseTest
    {
        private readonly CommonBitManipulation _sut = new CommonBitManipulation();

        public CommonBitManipulationTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TestGettingBits()
        {
            int val8 = 8;
            for (int i = 0; i < 4; i++)
            {
                _output.WriteLine("{0} gets bit: {1} at position {2}", Convert.ToString(val8, 2), _sut.GetBit(val8, i), i);
            }

            Assert.False(_sut.GetBit(val8, 0));
            Assert.False(_sut.GetBit(val8, 1));
            Assert.False(_sut.GetBit(val8, 2));
            Assert.True(_sut.GetBit(val8, 3));
        }

        [Fact]
        public void TestSettingBits()
        {
            int value = 0;

            Assert.Equal(1, _sut.SetBit(value, 0));
            Assert.Equal(2, _sut.SetBit(value, 1));
            Assert.Equal(4, _sut.SetBit(value, 2));
            Assert.Equal(8, _sut.SetBit(value, 3));
        }

        [Fact]
        public void TestClearingBits()
        {
            int value = 239;

            Assert.Equal(238, _sut.ClearBit(value, 0));
            Assert.Equal(237, _sut.ClearBit(value, 1));
            Assert.Equal(235, _sut.ClearBit(value, 2));
            Assert.Equal(231, _sut.ClearBit(value, 3));
        }

        [Fact]
        public void TestClearingAllBitsFromTheMostSignificantBitThroughI()
        {
            int value = 15;

            // 1111 & 0111 = 01111 => 7
            Assert.Equal(7, _sut.ClearBitsMsbThroughI(value, 3));
            // 1111 & 0011 = 0011 => 3
            Assert.Equal(3, _sut.ClearBitsMsbThroughI(value, 2));
        }

        [Fact]
        public void TestUpdatingBit()
        {
            int value = 15;

            // (1111 & 1110) | (0000) = 1110 => 14
            Assert.Equal(14, _sut.UpdateBit(value, 0, false));
            // (1111 & 1110) | (0001) = 1111 => 15
            Assert.Equal(15, _sut.UpdateBit(value, 0, true));
        }
    }

    public class CommonBitManipulation
    {
        public int UpdateBit(int num, int i, bool bitIs1)
        {
            int value = bitIs1 ? 1 : 0;
            int mask = ~(1 << i);
            return (num & mask) | (value << i);
        }

        public int ClearBitsMsbThroughI(int num, int i)
        {
            int mask = (1 << i) - 1;
            return num & mask;
        }

        public int ClearBit(int num, int i)
        {
            var mask = ~(1 << i);
            return num & mask;
        }

        public bool GetBit(int num, int i)
        {
            int mask = 1 << i;
            return (num & mask) != 0;
        }

        public int SetBit(int num, int i)
        {
            int mask = 1 << i;
            return (num | mask);
        }
    }
}
