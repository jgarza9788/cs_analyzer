using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    public class Chapter2_7Data : Chapter2Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { GetNodes1(), true },
            new object[] { GetNodes2(), true },
            new object[] { GetNodes3(), false },
            new object[] { GetNodes4(), false },
        };

        /// <summary>
        /// node1 = 1 -> 2 -> 3 -> 4 -> 5
        /// node2 = 2 -> 3 -> 4 -> 5
        /// 
        /// where node2 intersects with node1 at value 2.
        /// </summary>
        private static Tuple<Node<int>, Node<int>>  GetNodes1()
        {
            var node1 = GetInputNode(Enumerable.Range(1, 5).ToArray());
            var node2 = node1.Next;

            return Tuple.Create(node1, node2);
        }

        /// <summary>
        /// node1 = 1 -> 2 -> 3 -> 4 -> 5
        /// node2 = 1 -> 2 -> 3 -> 4 -> 5
        /// 
        /// where node2 intersects with node1 at value 1.
        /// </summary>
        private static Tuple<Node<int>, Node<int>>  GetNodes2()
        {
            var node1 = GetInputNode(Enumerable.Range(1, 5).ToArray());
            var node2 = node1;

            return Tuple.Create(node1, node2);
        }

        /// <summary>
        /// node1 = 1 -> 2 -> 3 -> 4 -> 5
        /// node2 = 2 -> 3 -> 4 -> 5
        /// 
        /// where node2 doesn't intersect with node 1
        /// </summary>
        private static Tuple<Node<int>, Node<int>>  GetNodes3()
        {
            var node1 = GetInputNode(Enumerable.Range(1, 5).ToArray());
            var node2 = GetInputNode(Enumerable.Range(2, 4).ToArray());

            return Tuple.Create(node1, node2);
        }

        /// <summary>
        /// node1 = 1 -> 2 -> 3 -> 4 -> 5
        /// node2 = 1 -> 2 -> 3 -> 4 -> 5
        /// 
        /// where node2 doesn't intersect with node 1
        /// </summary>
        private static Tuple<Node<int>, Node<int>>  GetNodes4()
        {
            var node1 = GetInputNode(Enumerable.Range(1, 5).ToArray());
            var node2 = GetInputNode(Enumerable.Range(1, 5).ToArray());

            return Tuple.Create(node1, node2);
        }
    }
}