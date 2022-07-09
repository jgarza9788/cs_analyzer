using System.Collections.Generic;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    public class Chapter2_6Data : Chapter2Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { GetInputNode(1), true },
            new object[] { GetInputNode(1, 2, 1), true },
            new object[] { GetInputNode(1, 2, 2, 1), true },
            new object[] { GetInputNode(1, 2, 3, 2, 1), true },
            new object[] { GetInputNode(1, 2), false },
            new object[] { GetInputNode(1, 2, 3), false },
            new object[] { GetInputNode(1, 2, 3, 2), false },
        };
    }
}