using System.Collections;
using System.Collections.Generic;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    public class Chapter1_6Data : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "aabcccccaaa", "a2b1c5a3" },
            new object[] { "aaabcccccaaa", "a3b1c5a3" },
            new object[] { "aaabcaaa", "a3b1c1a3" },
            new object[] { "aabbcc", "a2b2c2" },
            new object[] { "abcd", "abcd" },
            new object[] { "a", "a" },
            new object[] { "aa", "a2" },
            new object[] { "", "" },
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