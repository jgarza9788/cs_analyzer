using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.RandomStuff.Glassdoor.Asana
{
    /// <summary>
    /// https://www.glassdoor.com/Interview/Find-max-numbers-in-sqaures-to-travel-QTN_2082127.htm
    /// 
    /// https://www.youtube.com/watch?v=g8bSdXCG-lA
    /// </summary>
    public class MaxNumbersInSquaresToTravelTest : BaseTest
    {
        public MaxNumbersInSquaresToTravelTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TestHappyPath()
        {
            var matrix = new[,]
            {
                {1, 0, 0, 1, 1, 1},
                {1, 0, 1, 1, 0, 1},
                {0, 1, 1, 1, 1, 1},
                {0, 0, 1, 1, 1, 1}
            };

            const int expected = 8;
            var actual = GetMaxNumbersInSquares(matrix);
            Assert.Equal(expected, actual);
        }

        private int GetMaxNumbersInSquares(int[,] m)
        {
            int max = 0;
            var row = Enumerable.Repeat(-1, m.GetLength(1)).ToArray();

            for (int r = 0; r < m.GetLength(0); r++)
            {
                for (int c = 0; c < m.GetLength(1); c++)
                {
                    var curr = m[r, c];
                    if (r == 0) row[c] = curr;
                    else
                    {
                        row[c] = curr == 0 ? 0 : row[c] + curr;
                    }
                }

                var rowMax = GetRowMax(row);
                if (rowMax > max)
                    max = rowMax;
            }

            return max;
        }

        private int GetRowMax(IEnumerable<int> row)
        {
            var group = row.Aggregate("", (acc, n) =>
            {
                acc += n;
                return acc;
            }).Split(new []{ '0' }, StringSplitOptions.RemoveEmptyEntries);

            int max = 0;
            foreach (var text in group)
            {
                var curr = text.Select(c => c - '0').Min() * text.Length;
                if (curr > max)
                    max = curr;
            }
            return max;
        }
    }
}
