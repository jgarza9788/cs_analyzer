using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.FEM.Algorithms.DataStructures
{
    public class HashtableTest : BaseTest
    {
        public HashtableTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TestSet()
        {
            var sut = new FemHashtable(3);
            sut.Set("1", "first");
            sut.Set("2", "second");
            sut.Set("3", "third");

            var expected = new[] {"first", "second", "third"};
            Func<string, string> self = _ => _;
            Assert.True(expected.OrderBy(self).SequenceEqual(sut.Data.OrderBy(self)));
        }

        [Fact]
        public void TestGet()
        {
            var sut = new FemHashtable(3);
            sut.Set("1", "first");
            sut.Set("2", "second");
            sut.Set("3", "third");

            Assert.Equal("first", sut.Get("1"));
            Assert.Equal("second", sut.Get("2"));
            Assert.Equal("third", sut.Get("3"));
        }
    }

    class FemHashtable
    {
        public string[] Data { get; }

        public string Get(string key)
        {
            int hash = SimpleHash(key, Data.Length);
            return Data[hash];
        }

        public void Set(string key, string value)
        {
            int hash = SimpleHash(key, Data.Length);
            Data[hash] = value;
        }

        public FemHashtable(int size)
        {
            Data = Enumerable.Repeat(0, size).Select(_ => "").ToArray();
        }

        int SimpleHash(string key, int tableSize)
        {
            // https://github.com/kuychaco/algoClass/blob/master/data-structures/hashTable.js#L61
            var hash = 0;
            for (var i = 0; i < key.Length; i++)
            {
                hash += key[i] * (i + 1);
            }
            return hash % tableSize;
        }
    }
}
