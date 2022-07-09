using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.FEM.Algorithms.TreeAndSearching
{
    public class LinkedListTest : BaseTest
    {
        public LinkedListTest(ITestOutputHelper output) : base(output)
        {
        }

        public static IEnumerable<object[]> GetLinkedLists()
        {
            yield return new object[] { new[] { 1, 2, 3, 4, 5 } };
            yield return new object[] { new[] { 9999, 32, 23, 33, 2, 1023 } };
        }

        [Theory]
        [MemberData(nameof(GetLinkedLists)]

        public void TestLinkedList(int[] expected)
        {
            var n1 = new FemLinkedListNode {Value = 1};
            var n2 = new FemLinkedListNode {Value = 2};
            var n3 = new FemLinkedListNode {Value = 3};
            var n4 = new FemLinkedListNode {Value = 4};

        }
    }

    class FemLinkedListNode
    {
        public int Value { get; set; }
        public FemLinkedListNode Tail { get; set; }
    }
}
