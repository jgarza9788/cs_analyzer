using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Demo.LearnByDoing.Tests.DataStructure.Tree;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.RandomStuff.Glassdoor.Asana
{
    /// <summary>
    /// Part of solution required to calculate k closest point
    /// 
    /// K closest point to the origin - https://www.youtube.com/watch?v=eaYX0Ee0Kcg
    /// Min Heap - https://www.youtube.com/watch?v=t0Cq6tVNRBA
    /// </summary>
    public class MinHeapTest : BaseTest
    {
        [Fact]
        public void TestHeapness()
        {
            var items = new[] { 10, 15, 20, 17 };
            var expected = new[] { 10, 15, 17, 20 };
            var sut = new MinHeap();
            sut.AddRange(items);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], sut.Poll());
                //Console.WriteLine(sut.Poll());
            }
        }

        [Fact]
        public void ThrowExceptionWhenExtractingAnEmptyBinaryMinHeap()
        {
            var sut = new BinaryMinHeap<char>();
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.ExtractMinimum());
        }

        public static IEnumerable<object[]> GetSampleBinaryHeap()
        {
            var sut = new BinaryMinHeap<char>();
            var a = new BinaryMinHeap<char>.Node { Id = 'a', Weight = -1 };
            var b = new BinaryMinHeap<char>.Node { Id = 'b', Weight = 2 };
            var c = new BinaryMinHeap<char>.Node { Id = 'c', Weight = 6 };
            var d = new BinaryMinHeap<char>.Node { Id = 'd', Weight = 4 };
            var e = new BinaryMinHeap<char>.Node { Id = 'e', Weight = 5 };
            var f = new BinaryMinHeap<char>.Node { Id = 'f', Weight = 7 };
            var g = new BinaryMinHeap<char>.Node { Id = 'g', Weight = 8 };

            sut.Add(a);
            sut.Add(b);
            sut.Add(c);
            sut.Add(d);
            sut.Add(e);
            sut.Add(f);
            sut.Add(g);

            yield return new object[] { sut };
        }

        [Theory]
        [MemberData(nameof(GetSampleBinaryHeap))]
        public void TestBinaryMinHeapContains(BinaryMinHeap<char> sut)
        {
            Assert.True(sut.Contains('a'));
            Assert.True(sut.Contains('b'));
            Assert.True(sut.Contains('c'));
            Assert.True(sut.Contains('d'));
            Assert.True(sut.Contains('e'));
            Assert.True(sut.Contains('f'));
            Assert.True(sut.Contains('g'));

            Assert.False(sut.Contains('1'));
            Assert.False(sut.Contains('x'));
            Assert.False(sut.Contains('3'));
            Assert.False(sut.Contains('y'));
            Assert.False(sut.Contains('z'));
        }

        [Theory]
        [MemberData(nameof(GetSampleBinaryHeap))]
        public void TestBinaryMinHeap(BinaryMinHeap<char> sut)
        {
            var expected = new[] { 'a', 'b', 'd', 'e', 'c', 'f', 'g' };
            var actual = expected.Select(_ => sut.ExtractMinimum());
            
            Assert.True(expected.SequenceEqual(actual.Select(_ => _.Id)));
        }

        [Fact]
        public void TestBinaryMinHeapDecrease()
        {
            var sut = new BinaryMinHeap<char>();
            var a = new BinaryMinHeap<char>.Node { Id = 'a', Weight = -1 };
            var b = new BinaryMinHeap<char>.Node { Id = 'b', Weight = 2 };
            var c = new BinaryMinHeap<char>.Node { Id = 'c', Weight = 6 };
            var d = new BinaryMinHeap<char>.Node { Id = 'd', Weight = 4 };
            var e = new BinaryMinHeap<char>.Node { Id = 'e', Weight = 5 };
            var f = new BinaryMinHeap<char>.Node { Id = 'f', Weight = 7 };
            var g = new BinaryMinHeap<char>.Node { Id = 'g', Weight = 8 };

            sut.Add(a);
            sut.Add(b);
            sut.Add(c);
            sut.Add(d);
            sut.Add(e);
            sut.Add(f);
            sut.Add(g);

            f.Weight = -2;
            sut.Decrease(f);

            g.Weight = -3;
            sut.Decrease(g);

            var expected = new[] { 'g', 'f', 'a', 'b', 'd', 'e', 'c' };

            var actual = expected.Select(_ => sut.ExtractMinimum());
            //foreach (BinaryMinHeap<char>.Node node in actual)
            //{
            //    _output.WriteLine(node.ToString());
            //}
            Assert.True(expected.SequenceEqual(actual.Select(_ => _.Id)));
        }

        public MinHeapTest(ITestOutputHelper output) : base(output)
        {
        }
    }

    class MinHeap
    {
        private int Capacity { get; } = 10;
        private int Size { get; set; }

        public int[] Items { get; set; }

        public MinHeap()
        {
            Items = new int[Capacity];
        }

        private int GetLeftChildIndex(int parentIndex) => (2 * parentIndex) + 1;
        private int GetRightChildIndex(int parentIndex) => (2 * parentIndex) + 2;
        private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;

        private bool HasLeftChild(int parentIndex) => GetLeftChildIndex(parentIndex) < Size;
        private bool HasRightChild(int parentIndex) => GetRightChildIndex(parentIndex) < Size;
        private bool HashParent(int childIndex) => GetParentIndex(childIndex) >= 0;

        private int LeftChild(int index) => Items[GetLeftChildIndex(index)];
        private int RightChild(int index) => Items[GetRightChildIndex(index)];
        private int Parent(int index) => Items[GetParentIndex(index)];

        private void Swap(int indexOne, int indexTwo)
        {
            (Items[indexTwo], Items[indexOne]) = (Items[indexOne], Items[indexTwo]);
        }

        private void EnsureExtraCapacity()
        {
            if (Size < Capacity) return;

            var newItems = new int[Capacity * 2];
            Array.Copy(Items, newItems, Items.Length);
            Items = newItems;
        }

        /// <summary>
        /// Get the minimum value without adjusting the heap
        /// </summary>
        public int Peek()
        {
            if (Size == 0) throw new ArgumentOutOfRangeException();

            // First item contains the minimum value.
            return Items[0];
        }

        /// <summary>
        /// Get the minimum value and re-adjust the heap
        /// </summary>
        public int Poll()
        {
            if (Size == 0) throw new ArgumentOutOfRangeException();

            int item = Items[0];
            Items[0] = Items[Size - 1];
            Size--;
            HeapifyDown();
            return item;
        }

        public void Add(int item)
        {
            EnsureExtraCapacity();
            Items[Size] = item;
            Size++;
            HeapifyUp();
        }

        public void AddRange(IEnumerable<int> items)
        {
            foreach (var item in items) Add(item);
        }

        private void HeapifyUp()
        {
            var index = Size - 1;
            while (HashParent(index) && Parent(index) > Items[index])
            {
                Swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }

        private void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int smallerChildIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && RightChild(index) < LeftChild(index))
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }

                if (Items[index] < Items[smallerChildIndex]) break;

                Swap(index, smallerChildIndex);
                index = smallerChildIndex;
            }
        }
    }
}
