using System;
using System.Collections;
using System.Collections.Generic;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    public class Chapter2_2Data2 : IEnumerable<object[]>
    {
        private const int UPTO = 5;
        private static readonly Node<int> _input = GetInputNode(1, UPTO);

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { _input, 0, _input },
            new object[] { _input, 1, GetInputNode(2, UPTO) },
            new object[] { _input, 2, GetInputNode(3, UPTO) },
            new object[] { _input, 3, GetInputNode(4, UPTO) },
            new object[] { _input, 4, GetInputNode(5, UPTO) }
        };

        private static Node<int> GetInputNode(int from, int to)
        {
            if (from > to) throw new IndexOutOfRangeException();

            Node<int> head = new Node<int>(from);
            Node<int> result = head;
            int i = from + 1;

            while (i <= to)
            {
                result.Next = new Node<int>(i);
                result = result.Next;
                i++;
            }

            return head;
        }

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