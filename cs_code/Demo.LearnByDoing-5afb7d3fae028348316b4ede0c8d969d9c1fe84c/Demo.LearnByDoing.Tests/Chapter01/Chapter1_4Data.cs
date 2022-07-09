using System.Collections;
using System.Collections.Generic;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    public class Chapter1_4Data : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            // Taco Cat or Atco Cta
            new object[] {"Tact Coa", true},
            new object[] {"aab", true},
            new object[] {"aabbcc", true},
            // Racecar
            new object[] {"raccear", true},
            // Kayak
            new object[] {"yakka", true},
            new object[] {"ybbakka", true},
            new object[] {"abcab", true},
            new object[] {"abbbc", false},
            new object[] {"ab", false},
            new object[] {"abc", false},
            new object[] {"abcd", false},
            new object[] {"abcde", false},
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