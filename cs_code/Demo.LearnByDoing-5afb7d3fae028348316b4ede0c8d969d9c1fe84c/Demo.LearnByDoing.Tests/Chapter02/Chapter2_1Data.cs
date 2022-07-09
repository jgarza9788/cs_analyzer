using System.Collections;
using System.Collections.Generic;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    public class Chapter2_1Data : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new LinkedListWithInit<int> { 3, 1, 1, 2, 2, 3 },
                new LinkedListWithInit<int> { 3, 1, 2 },
            },
            new object[]
            {
                new LinkedListWithInit<int> { 4, 5, 5, 1, 2, 3, 1 },
                new LinkedListWithInit<int> { 4, 5, 1, 2, 3 },
            },
            new object[]
            {
                new LinkedListWithInit<int> { 1, 1, 2, 2, 3, 3 },
                new LinkedListWithInit<int> { 1, 2, 3 },
            },
            new object[]
            {
                new LinkedListWithInit<int> { 1, 2, 3 },
                new LinkedListWithInit<int> { 1, 2, 3 },
            },
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