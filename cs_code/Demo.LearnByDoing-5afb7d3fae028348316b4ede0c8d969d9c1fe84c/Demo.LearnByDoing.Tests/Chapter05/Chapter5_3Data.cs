using System.Collections.Generic;
using Demo.LearnByDoing.Core;

namespace Demo.LearnByDoing.Tests.Chapter05
{
    public class Chapter5_3Data : BaseTestData
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] {1775, 8}, // 11011101111 => 8
            new object[] {1463, 6}, // 10110110111 => 6
        };
    }

    public class Chapter5_3Data_SequentialCount : BaseTestData
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] {1775, new List<int> {4, 3, 2}},
            new object[] {1463, new List<int> {3, 2, 2, 1}},
        };
    }
}