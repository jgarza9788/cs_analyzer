using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    /// <summary>
    /// Partition:
    /// Write code to partition a linked list around a value x, 
    /// such that all nodes less than x come before all nodes greater than or equal to x.
    /// If x is contained within the list, the values of x only need to be after the elements less than x (see below).
    /// The partition element x can appear anywhere in the "right partition";
    /// it does not need to appear between the left and right partitions.
    /// 
    /// EXAMPLE:
    /// Input:  3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1 [partition = 5]
    /// Output: 3 -> 1 -> 2 -> 10 -> 5 -> 5 -> 8
    /// </summary>
    public class Chapter2_4Test : Chapter2TestBase
    {
        private readonly Chapter2_4 _sut = new Chapter2_4();

        public Chapter2_4Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter2_4Data))]
        public void TestPartitioningNodeByValue(int partition, Node<int> input, Node<int> expected)
        {
            Node<int> actual = _sut.PartitionNode(partition, input);

            Assert.True(AreNodesEqual(expected, actual));
        }

        [Theory]
        [ClassData(typeof(Chapter2_4Data))]
        public void TestPartitioningNodeByValue2(int partition, Node<int> input, Node<int> expected)
        {
            Node<int> actual = _sut.PartitionNode2(partition, input);

            Assert.True(AreNodesEqual(expected, actual));
        }

        [Theory]
        [ClassData(typeof(Chapter2_4Data_Small))]
        public void TestPartitioningNodeByValueUsingAnswerFromBook(int partition, Node<int> input, Node<int> expected)
        {
            Node<int> actual = _sut.PartitionNode3(partition, input);

            Assert.True(AreNodesEqual(expected, actual));
        }
    }

    public class Chapter2_4
    {
        public List<T> NodeToList<T>(Node<T> node)
        {
            List<T> result = new List<T>();
            while (node != null)
            {
                result.Add(node.Data);
                node = node.Next;
            }

            return result;
        }

        public Node<int> PartitionNode3(int partition, Node<int> node)
        {
            Node<int> head = node;
            Node<int> tail = node;

            while (node != null)
            {
                var next = node.Next;

                if (node.Data < partition)
                {
                    // Insert node at head
                    node.Next = head;
                    head = node;
                }
                else
                {
                    // Insert node at tail
                    tail.Next = node;
                    tail = node;
                }

                node = next;
            }

            tail.Next = null;

            // The head has changed, so we need to return it to the user.
            return head;
        }

        public Node<int> PartitionNode2(int partition, Node<int> input)
        {
            Dictionary<int, Node<int>> map = GetNodeMap2(input);
            var sortedValueMap = (from pair in map
                                  orderby pair.Value.Data ascending
                                  select pair).ToDictionary(pair => pair.Key, pair => pair.Value);

            Node<int> result = sortedValueMap.FirstOrDefault().Value;
            Node<int> head = result;

            // Skip the first element.
            foreach (KeyValuePair<int, Node<int>> pair in sortedValueMap.Skip(1))
            {
                result.Next = new Node<int>(pair.Value.Data);
                result = result.Next;
            }

            return head;
        }

        public Node<int> PartitionNode(int partition, Node<int> input)
        {
            // int1 => index, int2 => data
            Dictionary<int, int> map = GetNodeMap(input);
            var sortedValueMap = (from pair in map
                                 orderby pair.Value ascending
                                 select pair).ToDictionary(pair => pair.Key, pair => pair.Value);

            Node<int> result = new Node<int>(sortedValueMap.FirstOrDefault().Value);
            Node<int> head = result;

            // Skip the first element.
            foreach (KeyValuePair<int, int> pair in sortedValueMap.Skip(1))
            {
                result.Next = new Node<int>(pair.Value);
                result = result.Next;
            }

            return head;
        }

        private Dictionary<int, int> GetNodeMap(Node<int> input)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();

            Node<int> head = input;
            int index = 0;
            result.Add(index, input.Data);

            input = input.Next;
            while (input != null)
            {
                index++;

                result.Add(index, input.Data);

                input = input.Next;
            }

            return result;
        }

        private Dictionary<int, Node<int>> GetNodeMap2(Node<int> input)
        {
            Dictionary<int, Node<int>> result = new Dictionary<int, Node<int>>();

            Node<int> head = input;
            int index = 0;
            result.Add(index, input);

            input = input.Next;
            while (input != null)
            {
                index++;

                result.Add(index, input);

                input = input.Next;
            }

            return result;
        }
    }

    public class Chapter2_4Data_Small : Chapter2Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { 3, GetInputNode(1, 2, 3, 4), GetInputNode(1, 2, 3, 4) },
            new object[] { 3, GetInputNode(3, 5, 8, 1), GetInputNode(1, 3, 5, 8) },
        };
    }

    public class Chapter2_4Data : Chapter2Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { 5, GetInputNode(3, 5, 8, 5, 10, 2, 1), GetInputNode(1, 2, 3, 5, 5, 8, 10) },
            new object[] { 3, GetInputNode(3, 5, 8, 5, 10, 2, 1), GetInputNode(1, 2, 3, 5, 5, 8, 10) },
        };
    }
}
