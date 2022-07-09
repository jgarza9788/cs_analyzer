using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.RandomStuff.Glassdoor.Asana
{
    /// <summary>
    /// Part of solution required to calculate k closest point
    /// 
    /// K closest point to the origin - https://www.youtube.com/watch?v=eaYX0Ee0Kcg
    /// Min Heap - https://www.youtube.com/watch?v=t0Cq6tVNRBA
    /// </summary>
    public class MaxHeapTest
    {
        [Fact]
        public void TestHeapness()
        {
            var items = new[] { 10, 15, 20, 17 };
            var expected = new[] { 20, 17, 15, 10 };
            var sut = new MaxHeap();
            sut.AddRange(items);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], sut.Poll());
                //Console.WriteLine(sut.Poll());
            }
        }

        public static IEnumerable<object[]> GetSortData()
        {
            yield return new object[] { new[] { 4, 10, 3, 5, 1 }, new[] { 1, 3, 4, 5, 10 } };
            yield return new object[] { new[] { 4, 10, 3, 5, 1, 0 }, new[] { 0, 1, 3, 4, 5, 10 } };
            yield return new object[] { new[] { 1, 2 }, new[] { 1, 2 } };
            yield return new object[] { new[] { 2, 1 }, new[] { 1, 2 } };
            yield return new object[] { new[] { 99 }, new[] { 99 } };
            yield return new object[] { new int[] { }, new int[] { } };
        }

        [Theory]
        [MemberData(nameof(GetSortData))]
        public void TestSort(int[] input, int[] expected)
        {
            var actual = Sort(input);
            Assert.True(expected.SequenceEqual(actual));
        }

        private IEnumerable<int> Sort(int[] input)
        {
            var a = new List<int>(input).ToArray();

            for (int i = a.Length / 2 - 1; i >= 0; i--)
            {
                Heapify(a, a.Length, i);
            }

            for (int i = a.Length - 1; i >= 0; i--)
            {
                Swap(a, i, 0);
                Heapify(a, i, 0);
            }

            return a;
        }

        private void Heapify(int[] a, int size, int rootIndex)
        {
            // Get largest child
            // if the largest child value is greater than the root, 
            //  then swap && heapify the largest

            var largestIndex = rootIndex;
            var leftIndex = rootIndex * 2 + 1;
            var rightIndex = rootIndex * 2 + 2;

            if (leftIndex < size && a[leftIndex] > a[largestIndex]) largestIndex = leftIndex;
            if (rightIndex < size && a[rightIndex] > a[largestIndex]) largestIndex = rightIndex;

            if (largestIndex == rootIndex) return;

            Swap(a, rootIndex, largestIndex);
            Heapify(a, size, largestIndex);
        }

        private void Swap(int[] a, int i1, int i2) => (a[i1], a[i2]) = (a[i2], a[i1]);
    }

    class MaxHeap
    {
        private int _capacity = 10;
        private int _size = 0;
        private int[] _items;

        public MaxHeap()
        {
            _items = new int[_capacity];
        }

        private void EnsureExtraCapacity()
        {
            if (_size < _capacity) return;

            var newItems = new int[_capacity * 2];
            Array.Copy(_items, newItems, _items.Length);
            _items = newItems;
        }

        public int Peek()
        {
            if (_items.Length == 0) throw new ArgumentOutOfRangeException();

            return _items[0];
        }

        public int Poll()
        {
            if (_items.Length == 0) throw new ArgumentOutOfRangeException();

            var item = _items[0];
            _items[0] = _items[_size - 1];
            _size--;
            HeapifyDown();
            return item;
        }

        public void Add(int item)
        {
            EnsureExtraCapacity();
            _items[_size] = item;
            _size++;
            HeapifyUp();
        }

        public void AddRange(IEnumerable<int> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        private void HeapifyUp()
        {
            var index = _size - 1;
            while (HasParent(index) && GetParent(index) < _items[index])
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }

        private bool HasParent(int childIndex) => GetParentIndex(childIndex) >= 0;
        private bool HasLeftChild(int index) => GetLeftChildIndex(index) < _size;
        private bool HasRightChild(int index) => GetRightChildIndex(index) < _size;

        private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;
        private int GetLeftChildIndex(int index) => index * 2 + 1;
        private int GetRightChildIndex(int index) => index * 2 + 2;

        private int GetParent(int childIndex) => _items[GetParentIndex(childIndex)];
        private int GetLeftChild(int index) => _items[GetLeftChildIndex(index)];
        private int GetRightChild(int index) => _items[GetRightChildIndex(index)];


        private void Swap(int i1, int i2) => (_items[i1], _items[i2]) = (_items[i2], _items[i1]);

        private void HeapifyDown()
        {
            var index = 0;
            // If there is no Left Child, then there is no right child.
            while (HasLeftChild(index))
            {
                // Find the larger value in the child nodes and move down the current value
                int largerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index) > GetLeftChild(index))
                {
                    largerIndex = GetRightChildIndex(index);
                }

                if (_items[index] > _items[largerIndex]) break;

                Swap(index, largerIndex);
                index = largerIndex;
            }
        }
    }
}
