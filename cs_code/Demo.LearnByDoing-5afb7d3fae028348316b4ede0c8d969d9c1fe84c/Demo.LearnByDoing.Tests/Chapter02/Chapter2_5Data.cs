using System.Collections.Generic;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    public class Chapter2_5Data_Padding : Chapter2Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { 1, GetInputNode(5), GetInputNode(5) },
            new object[] { 2, GetInputNode(5), GetInputNode(0, 5) },
            new object[] { 3, GetInputNode(5), GetInputNode(0, 0, 5) },
            new object[] { 4, GetInputNode(5), GetInputNode(0, 0, 0, 5) },
            //new object[] { 2, GetInputNode(0, 5), GetInputNode(0, 5) },
            //new object[] { 3, GetInputNode(0, 5), GetInputNode(0, 0, 5) },
            //new object[] { 4, GetInputNode(0, 5), GetInputNode(0, 0, 0, 5) },
            new object[] { 3, GetInputNode(1, 5), GetInputNode(0, 1, 5) },
            new object[] { 4, GetInputNode(1, 5), GetInputNode(0, 0, 1, 5) },
            new object[] { 4, GetInputNode(2, 1, 5), GetInputNode(0, 2, 1, 5) },
        };
    }

    public class Chapter2_5Data_Length : Chapter2Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { GetInputNode(9), 1 },
            new object[] { GetInputNode(7, 1), 2 },
            new object[] { GetInputNode(9, 9, 9), 3 },
            new object[] { GetInputNode(9, 9, 1, 2), 4 },
            new object[] { GetInputNode(9, 9, 1, 2, 6), 5 },
        };
    }

    public class Chapter2_5Data_Reverse : Chapter2Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { GetInputNode(9, 1), GetInputNode(5), GetInputNode(4, 2) },
            new object[] { GetInputNode(7, 1, 6), GetInputNode(5, 9, 2), GetInputNode(2, 1, 9) },
            new object[] { GetInputNode(9, 9, 9), GetInputNode(0, 0, 1), GetInputNode(9, 9, 0, 1) },
            new object[] { GetInputNode(9, 9, 9), GetInputNode(0, 1), GetInputNode(9, 0, 0, 1) },
        };
    }

    public class Chapter2_5Data_Forward : Chapter2Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { GetInputNode(1, 9), GetInputNode(5), GetInputNode(2, 4) },
            new object[] { GetInputNode(6, 1, 7), GetInputNode(2, 9, 5), GetInputNode(9, 1, 2) },
            new object[] { GetInputNode(9, 9, 9), GetInputNode(1, 0, 0), GetInputNode(1, 0, 9, 9) },
            new object[] { GetInputNode(9, 9, 9), GetInputNode(1, 0), GetInputNode(1, 0, 0, 9) },
        };
    }
}