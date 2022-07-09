using System.Collections.Generic;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.LeetCode.Hard
{
    /// <summary>
    /// https://leetcode.com/problems/lru-cache/description/
    /// </summary>
    public class LruCacheTest : BaseTest
    {
        private const int CACHE_SIZE = 3;

        public LruCacheTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void IntegrationTest()
        {
            var sut = new LRUCache(2 /* capacity */ );

            sut.Put(1, 1);
            sut.Put(2, 2);
            Assert.Equal(1, sut.Get(1));       
            // evicts key 2
            sut.Put(3, 3);
            Assert.Equal(-1, sut.Get(2));
            // evicts key 1
            sut.Put(4, 4);    
            Assert.Equal(-1, sut.Get(1));
            Assert.Equal(3, sut.Get(3));
            Assert.Equal(4, sut.Get(4));
        }

        public static IEnumerable<object[]> GetEmptyCache()
        {
            yield return new object[] { -1, new LRUCache(CACHE_SIZE) };
        }

        [Theory]
        [MemberData(nameof(GetEmptyCache))]
        public void TestGetEmpty(int expected, LRUCache emptyCache)
        {
            var actual = emptyCache.Get(111);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPutInEmptyCahce()
        {

        }

        [Fact]
        public void TestPutInNotFullCahce()
        {

        }

        [Fact]
        public void TestPutInFullCahce()
        {

        }

        [Fact]
        public void TestGetInCache()
        {

        }
    }

    public class LRUCache
    {
        private const int NOT_IN_CACHE = -1;
        private readonly Dictionary<int, LRUNode> _map;
        private LRUNode _start = null;
        private LRUNode _end = null;

        public int Capacity { get; set; }

        public LRUCache(int capacity)
        {
            Capacity = capacity;
            _map = new Dictionary<int, LRUNode>(capacity);
        }

        public int Get(int key)
        {
            if (!InCache(key)) return NOT_IN_CACHE;

            var node = GetNode(key);
            RemoveNode(node);
            AppendNode(node);
            return node.Value;
        }

        public void Put(int key, int value)
        {
            if (InCache(key))
            {
                var node = GetNode(key);
                node.Value = value;
                RemoveNode(node);
                AppendNode(node);
            }
            else
            {
                var node = new LRUNode(key, value);
                if (IsFull())
                {
                    RemoveKey(_end.Key);
                    RemoveNode(_end);
                    AppendNode(node);
                }
                else
                {
                    AppendNode(node);
                }

                AddKey(key, node);
            }
        }

        private void RemoveNode(LRUNode node)
        {
            if (node.Previous == null)
                _start = node.Next;
            else
                node.Previous.Next = node.Next;

            if (node.Next == null)
                _end = node.Previous;
            else
                node.Next.Previous = node.Previous;
        }

        private void AppendNode(LRUNode node)
        {
            node.Next = _start;
            node.Previous = null;
            if (_start != null)
            {
                _start.Previous = node;
            }

            _start = node;

            if (_end == null)
            {
                _end = _start;
            }
        }

        private void AddKey(int key, LRUNode value)
        {
            if (!InCache(key)) _map.Add(key, value);
        }

        private void RemoveKey(int key)
        {
            if (InCache(key)) _map.Remove(key);
        }

        private LRUNode GetNode(int key)
        {
            return _map[key];
        }

        private bool IsFull()
        {
            return _map.Count == Capacity;
        }

        private bool InCache(int key)
        {
            return _map.ContainsKey(key);
        }
    }

    public class LRUNode
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public LRUNode Previous { get; set; } = null;
        public LRUNode Next { get; set; } = null;

        public LRUNode(int key, int value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Key}=>{Value} {Previous?.Key}<=>{Next?.Key}";
        }
    }
}
