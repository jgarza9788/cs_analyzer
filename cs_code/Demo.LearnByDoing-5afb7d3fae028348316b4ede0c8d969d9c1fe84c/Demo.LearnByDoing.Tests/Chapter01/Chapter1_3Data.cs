using System.Collections;
using System.Collections.Generic;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    public class Chapter1_3Data : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "Mr John Smith    ", 13, "Mr%20John%20Smith" },
            new object[] { "Mr  John  Smith    ", 15, "Mr%20%20John%20%20Smith" },
            new object[] { "Hello World    ", 11, "Hello%20World" },
            new object[] { "Hello World    ", 12, "Hello%20World%20" },
            new object[] { "Hello World    ", 13, "Hello%20World%20%20" },
            new object[] { " Hello World    ", 14, "%20Hello%20World%20%20" },
            new object[] { " Hello  World    ", 13, "%20Hello%20%20World" },
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