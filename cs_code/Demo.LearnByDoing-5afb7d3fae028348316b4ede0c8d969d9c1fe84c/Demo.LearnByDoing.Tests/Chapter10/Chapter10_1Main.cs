using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter10
{
    public class Chapter10_1Main : BaseTest
    {
        private readonly Chapter10_1 _sut = new Chapter10_1();

        public Chapter10_1Main(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter10_1Data))]
        public void TestCopyingBToA(int lastA, int lastB, int[] a, int[] b, int[] expected)
        {
            _sut.CopyBToA(_output, a, b, lastA, lastB);

            Assert.True(expected.SequenceEqual(a));
        }
    }

    public class Chapter10_1Data : BaseTestData
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] {3, 2, new [] {1,2,3,-1,-1,-1,-1}, new [] {7, 8}, new [] {1,2,3,7,8,-1,-1} },
            new object[] {3, 3, new [] {4, 8, 9,-1,-1,-1,-1}, new [] {1, 3, 5}, new [] {1,3,4,5,8,9,-1} },
        };
    }

    public class Chapter10_1
    {
        /// <summary>
        /// From Cracking the Coding Interview 10.1 solution.
        /// </summary>
        public void CopyBToA(ITestOutputHelper output, int[] a, int[] b, int lastA, int lastB)
        {
            int indexA = lastA - 1;
            int indexB = lastB - 1;
            int indexMerged = lastA + lastB - 1;

            while (indexB >= 0)
            {
                if (indexA >= 0 && a[indexA] > b[indexB])
                {
                    a[indexMerged] = a[indexA];
                    
                    indexA--;
                }
                else
                {
                    a[indexMerged] = b[indexB];
                    indexB--;
                }
                output.WriteLine("a[{0}] = {1}", indexMerged, a[indexMerged]);
                indexMerged--;
            }
        }
    }
}
