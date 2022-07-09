using System.Collections;
using System.Collections.Generic;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    public class Chapter2_2Data : IEnumerable<object[]>
    {
        private static readonly LinkedListWithInit<int> _input = new LinkedListWithInit<int> { 1, 2, 3, 4, 5 };

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { _input, 0, _input },
            new object[] { _input, 1, new LinkedListWithInit<int> { 2, 3, 4, 5 } },
            new object[] { _input, 2, new LinkedListWithInit<int> { 3, 4, 5 } },
            new object[] { _input, 3, new LinkedListWithInit<int> { 4, 5 } },
            new object[] { _input, 4, new LinkedListWithInit<int> { 5 } },
            new object[] { _input, 5, new LinkedListWithInit<int> { } }
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}