using System.Collections;
using System.Collections.Generic;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// Data for testing permutations
    /// </summary>
    /// <remarks>
    /// http://stackoverflow.com/a/22093968/4035
    /// </remarks>
    public class Chapter1_2Data : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "1", "1", true },
            new object[] {"abc", "bca", true },
            new object[] {"12345", "54321", true },
            new object[] {"cca", "ccc", false },
            new object[] {"a", "ab", false },
            new object[] { "hello world!", "!world hell", false },
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