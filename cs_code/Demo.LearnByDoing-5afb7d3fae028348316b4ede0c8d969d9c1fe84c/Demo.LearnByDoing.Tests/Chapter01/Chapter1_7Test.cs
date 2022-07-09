using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// Rotate Matrix:
    /// Given an image represented by an NxN matrix, 
    /// where each piexel in the image is 4 bytes, 
    /// write a method to rotate the image by 90 degrees. 
    /// Can you do this in place?
    /// </summary>
    public class Chapter1_7Test : BaseTest
    {
        public Chapter1_7Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        //[ClassData(typeof(Chapter1_7Data))]
        //public void TestRightRotation(int[,] input, int[,] expected)
        public void TestRightRotation()
        {
            // 4x4 Matrix
            var a = new[,]
            {
                //{0, 0}, {0, 1}, {0, 2}, {0, 3},
                //{1, 0}, {1, 1}, {1, 2}, {1, 3},
                //{2, 0}, {2, 1}, {2, 2}, {2, 3},
                //{3, 0}, {3, 1}, {3, 2}, {3, 3},

                {0,1,2,3},
                {4,5,6,7},
                {8,9,10,11},
                {12,13,14,15}
            };
            var expected = new[,]
            {
                //{3, 0}, {2, 0}, {1, 0}, {0, 0},
                //{3, 1}, {2, 1}, {1, 1}, {0, 1},
                //{3, 2}, {2, 2}, {1, 2}, {0, 2},
                //{3, 3}, {2, 3}, {1, 3}, {0, 3},
                {12,8,4,0},
                {13,9,5,1},
                {14,10,6,2},
                {15,11,7,3}
            };

            // offset when we process each layer.
            int offset = 1;

            var half = a.GetLength(0) / 2;
            var depth = half % 2 == 0 ? half : half + 1;
            var n = a.GetLength(1);

            for (int depthIndex = 0; depthIndex < depth; depthIndex++)
            {
                for (int index = 0, reverseIndex = n - 1; index < n - 1 - (depthIndex * 2); index++, reverseIndex--)
                {
                    // top to right layer
                    var tempRightLayer = a[index + depthIndex, n - offset];
                    a[index + depthIndex, n - offset] = a[depthIndex, index + depthIndex];

                    // right to bottom layer
                    var tempBottomLayer = a[n - 1 - depthIndex, reverseIndex - depthIndex];
                    a[n - 1 - depthIndex, reverseIndex - depthIndex] = tempRightLayer;

                    // bottom to left layer
                    var tempLeftLayer = a[reverseIndex - depthIndex, depthIndex];
                    a[reverseIndex - depthIndex, depthIndex] = tempBottomLayer;

                    // left to top layer
                    a[depthIndex, index + depthIndex] = tempLeftLayer;
                }

                offset++;
            }

            //var equal =
            //    expected.Rank == a.Rank
            //    && Enumerable.Range(0, expected.Rank)
            //        .All(dimension => expected.GetLength(dimension) == a.GetLength(dimension))
            //    && expected.Cast<int>().SequenceEqual(a.Cast<int>());

            Assert.True(AreTwoMultidimensionalArraysSame(expected, a));
        }
    }
}
