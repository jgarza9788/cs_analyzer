using System;
using System.Collections.Generic;

namespace Demo.LearnByDoing.Tests.DataStructure.Tree
{
    public class BinaryMinHeap<T>
    {
        public class Node
        {
            public T Id { get; set; }
            public int Weight { get; set; }

            public override string ToString() => $"{Id}:{Weight}";
        }

        private int _size = 0;
        private int _capacity = 10;
        private Node[] _items;
        /// <summary>
        /// Contains a mapping of ID to the position in the array of _items
        /// </summary>
        /// <typeparam name="T">Node.Id</typeparam>
        /// <param name="int">_items index stored for Node.Id</param>
        private readonly Dictionary<T, int> _map;

        public BinaryMinHeap()
        {
            _items = new Node[_capacity];
            _map = new Dictionary<T, int>();
        }

        private void Swap(int index1, int index2)
        {
            var id1 = _items[index1].Id;
            var id2 = _items[index2].Id;
            (_map[id1], _map[id2]) = (_map[id2], _map[id1]);
            (_items[index1], _items[index2]) = (_items[index2], _items[index1]);
        }

        public void Decrease(Node node)
        {
            if (!_map.ContainsKey(node.Id)) Add(node);

            var index = _map[node.Id];
            if (HasParent(index) && GetParent(index).Weight > node.Weight) HeapifyUp(index);
            else HeapifyDown(index);
        }

        public Node ExtractMinimum()
        {
            if (_size == 0) throw new ArgumentOutOfRangeException("Heap is empty so no minimum to extract");

            // This is a MinHeap, thus the first item is always the node with minimum weight.
            var node = _items[0];
            _map.Remove(node.Id);

            // Replace the first item with the last item, and heapify down...
            _items[0] = _items[_size - 1];
            _size--;
            HeapifyDown();

            return node;
        }

        public void Add(Node node)
        {
            EnsureExtraCapacity();
            _map[node.Id] = _size;
            _items[_size] = node;
            HeapifyUp(_size);
            _size++;
        }

        /// <summary>
        /// Move the item as low in the heap tree
        /// </summary>
        private void HeapifyDown(int startingIndex = 0)
        {
            var index = startingIndex;
            var node = _items[index];

            // Swap while the biggest child is smaller than the current node

            // Heap is populated from left child to right.
            // If there is no left child, then there is no right child
            // so check only for the presence of left child.
            while (HasLeft(index))
            {
                var smallerIndex = GetLeftIndex(index);
                if (HasRight(index) && GetRight(index).Weight < GetLeft(index).Weight)
                    smallerIndex = GetRightIndex(index);

                if (node.Weight < _items[smallerIndex].Weight) break;

                Swap(index, smallerIndex);
                index = smallerIndex;
            }
        }

        private bool HasParent(int childIndex) => GetParentIndex(childIndex) >= 0;
        private Node GetParent(int childIndex) => _items[GetParentIndex(childIndex)];
        private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;

        private bool HasLeft(int index) => GetLeftIndex(index) < _size;
        private Node GetLeft(int index) => _items[GetLeftIndex(index)];
        private int GetLeftIndex(int index) => 2 * index + 1;

        private bool HasRight(int index) => GetRightIndex(index) < _size;
        private Node GetRight(int index) => _items[GetRightIndex(index)];
        private int GetRightIndex(int index) => 2 * index + 2;


        /// <summary>
        /// Move the last item as high as possible in the heap
        /// </summary>
        private void HeapifyUp(int startingIndex)
        {
            var index = startingIndex;
            var node = _items[index];

            // Swap with parents while the parent is bigger
            while (HasParent(index) && GetParent(index).Weight > node.Weight)
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }

        /// <summary>
        /// Increase items capacity if needed 
        /// </summary>
        /// <remarks>
        /// Doubling the size of items for now.
        /// </remarks>
        private void EnsureExtraCapacity()
        {
            if (_size < _capacity) return;

            _capacity *= 2;
            var items = new Node[_capacity];
            Array.Copy(_items, items, _items.Length);
            _items = items;
        }

        public Node GetNode(T id) => _items[_map[id]];
        public bool Contains(T id) => _map.ContainsKey(id);
        public bool HasItem() => _size > 0;
    }
}