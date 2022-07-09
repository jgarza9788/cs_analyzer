using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.RandomStuff.Glassdoor.Asana
{
    /// <summary>
    /// Reference: https://www.youtube.com/watch?v=eaYX0Ee0Kcg
    /// MinHeap: https://www.youtube.com/watch?v=t0Cq6tVNRBA
    /// </summary>
    public class KClosePointsToOriginTest
    {
        [Fact]
        public void TestHappyPath()
        {
            var points = new[]
            {
                (X: -2, Y: 4),
                (X: 0, Y: -2),
                (X: -1, Y: 0),
                (X: 3, Y: 5),
                (X: -2, Y: -3),
                (X: 3, Y: 2),
            };
            var expected = new[]
            {
                (X: -2, Y: -3),
                (X: -1, Y: 0),
                (X: 0, Y: -2),
            };
            const int k = 3;
            var actual = GetKClosestPointsToOrigin(k, points).ToList();

            Assert.True(expected.SequenceEqual(actual));
        }

        private IEnumerable<(int, int)> GetKClosestPointsToOrigin(int k, (int X, int Y)[] points)
        {
            var pointToDistanceMap = BuildPointToDistanceMap(points);
            var maxHeap = BuildMaxHeapMap(k, points);
            for (int i = k; i < points.Length; i++)
            {
                // Replace the biggest with the current smallest
                if (pointToDistanceMap[points[i]] < maxHeap.Peek().Distance)
                {
                    maxHeap.Poll();
                    maxHeap.Add((points[i].X, points[i].Y, pointToDistanceMap[points[i]]));
                }
            }

            while (maxHeap.HasItem())
            {
                var (x, y, _) = maxHeap.Poll();
                yield return (x, y);
            }
        }

        private Dictionary<(int, int), double> BuildPointToDistanceMap((int x, int y)[] points)
        {
            return points.ToDictionary(point => point, CalculateDistance);
        }

        private double CalculateDistance((int X, int Y) point) => Math.Sqrt(point.X * point.X + point.Y * point.Y);

        private GenericMaxHeap<(int X, int Y, double Distance)> BuildMaxHeapMap(int k, (int X, int Y)[] points)
        {
            return points
                .Take(k)
                .Aggregate(new GenericMaxHeap<(int X, int Y, double Distance)>(new GenericMaxHeapComparer()),
                    (heap, point) =>
                    {
                        heap.Add((point.X, point.Y, CalculateDistance(point)));
                        return heap;
                    });
        }
    }

    class GenericMaxHeapComparer: IComparer<(int X, int Y, double Distance)>
    {
        public int Compare((int X, int Y, double Distance) x, (int X, int Y, double Distance) y)
        {
            return (int) (x.Distance - y.Distance);
        }
    }

    class GenericMaxHeap<T>
    {
        private T[] _items;
        private int _capacity = 10;
        private int _size;
        private readonly IComparer<T> _comparer;

        public GenericMaxHeap(IComparer<T> comparer)
        {
            _comparer = comparer;
            _items = new T[_capacity];
        }

        public T Peek()
        {
            if (_size == 0) throw new ArgumentOutOfRangeException();

            return _items[0];
        }

        public T Poll()
        {
            if (_size == 0) throw new ArgumentOutOfRangeException();

            // move last item to the front and heapify down
            var item = _items[0];
            _items[0] = _items[_size - 1];
            _size--;
            HeapifyDown();

            return item;
        }

        public bool HasItem() => _size > 0;

        public void Add(T item)
        {
            EnsuareCapacity();
            // Add it to the end and heapify up!
            _items[_size] = item;
            _size++;
            HeapifyUp();
        }

        private void EnsuareCapacity()
        {
            if (_size < _capacity) return;

            _capacity *= 2;
            var items = new T[_capacity];
            Array.Copy(_items, items, items.Length);
            _items = items;
        }

        /// <summary>
        /// Move the last item to as high as it can move up
        /// </summary>
        /// <remarks>
        /// While there is a parent, which is less than the current item,
        ///     replace the parent with the current item by moving it up.
        ///     set the current index to that of the parent.
        /// </remarks>
        private void HeapifyUp()
        {
            var index = _size - 1;
            while (HasParent(index) && _comparer.Compare(GetParentValue(index), _items[index]) < 0)
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }

        /// <summary>
        /// Move the first item to as low as it can in the tree
        /// </summary>
        /// <remarks>
        /// while the child exists (check left child only)
        ///     Get the larger child's index between Left & Right child
        ///     if the current item is bigger than the larger child's value, then break out of the loop
        ///     else swap the larger child with the current item
        /// </remarks>
        private void HeapifyDown()
        {
            var index = 0;
            // Heap always starts from "left" child so no need to check for right child.
            while (HasLeftChild(index))
            {
                int largestChildIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && _comparer.Compare(GetRightChildValue(index), GetLeftChildValue(index)) < 0)
                    largestChildIndex = GetRightChildIndex(index);

                if (_comparer.Compare(_items[index], _items[largestChildIndex]) < 0) break;

                Swap(index, largestChildIndex);
                index = largestChildIndex;
            }
        }

        private bool HasParent(int childIndex) => GetParentIndex(childIndex) >= 0;
        private bool HasLeftChild(int index) => GetLeftChildIndex(index) < _size;
        private bool HasRightChild(int index) => GetRightChildIndex(index) < _size;

        private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;
        private int GetLeftChildIndex(int index) => index * 2 + 1;
        private int GetRightChildIndex(int index) => index * 2 + 2;

        private T GetParentValue(int childIndex) => _items[GetParentIndex(childIndex)];
        private T GetLeftChildValue(int index) => _items[GetLeftChildIndex(index)];
        private T GetRightChildValue(int index) => _items[GetRightChildIndex(index)];

        private void Swap(int index1, int index2) =>
            (_items[index1], _items[index2]) = (_items[index2], _items[index1]);
    }
}
