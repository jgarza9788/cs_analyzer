using System;
using System.Collections.Generic;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    public class Chapter1_8
    {
        public IEnumerable<Tuple<int, int>> GetZeroPositions(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                        yield return new Tuple<int, int>(i, j);
                }
            }
        }
    }
}