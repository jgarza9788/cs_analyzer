using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// Zero Matrix:
    /// Write an algorithm such that if an element in an MxN matrix is 0, 
    /// its entire row and column are set to 0
    /// </summary>
    public class Chapter1_8Test : BaseTest
    {
        private readonly Chapter1_8 _sut = new Chapter1_8();

        public Chapter1_8Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        //[ClassData(typeof(Chapter1_8Data))]
        //public void TestGettingZeroPositions(int[,] matrix, int matrix1)
        public void TestGettingZeroPositionCoordinates()
        {
            var matrix = new[,] { { 0, 1, 2 }, { 3, 0, 5 } };
            var expected = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 1),
            };

            var actual = _sut.GetZeroPositions(matrix).ToList();

            if (expected.Count != actual.Count)
                Assert.True(false, "length not the same");

            for (int i = 0; i < expected.Count; i++)
            {
                if (expected[i].Item1 != actual[i].Item1 || expected[i].Item2 != actual[i].Item2)
                {
                    Assert.True(false, "item not the same!");
                }
            }

            Assert.True(true, "Test passes!");
        }


        [Fact]
        public void TestZeroingOutZeroCells()
        {
            var matrix = new[,]
            {
                { 1, 2, 3, 0, 5 },
                { 1, 2, 3, 4, 5 },
                { 1, 2, 0, 4, 5 },
                { 1, 2, 3, 4, 5 },
                { 0, 2, 3, 4, 5 }
            };

            var expected = new[,]
            {
                { 0, 0, 0, 0, 0 },
                { 0, 2, 0, 0, 5 },
                { 0, 0, 0, 0, 0 },
                { 0, 2, 0, 0, 5 },
                { 0, 0, 0, 0, 0 }
            };

            var zeroPositions = _sut.GetZeroPositions(matrix);

            int[,] copy = matrix.Clone() as int[,];
            foreach (Tuple<int, int> zeroPosition in zeroPositions)
            {
                ZeroRow(copy, zeroPosition.Item1);
                ZeroColumn(copy, zeroPosition.Item2);
            }

            Assert.True(AreTwoMultidimensionalArraysSame(expected, copy));
        }

        private void ZeroRow(int[,] matrix, int rowIndex)
        {
            for (int columnIndex = 0; columnIndex < matrix.GetLength(1); columnIndex++)
            {
                matrix[rowIndex, columnIndex] = 0;
            }
        }

        private void ZeroColumn(int[,] matrix, int columnIndex)
        {
            for (int rowIndex = 0; rowIndex < matrix.GetLength(1); rowIndex++)
            {
                matrix[rowIndex, columnIndex] = 0;
            }
        }
    }
}
