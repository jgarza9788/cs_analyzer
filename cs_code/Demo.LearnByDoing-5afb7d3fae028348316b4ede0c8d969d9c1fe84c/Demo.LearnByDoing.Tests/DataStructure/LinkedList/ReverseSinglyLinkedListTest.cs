using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.DataStructure.LinkedList
{
    public class ReverseSinglyLinkedListTest : BaseTest
    {
        public ReverseSinglyLinkedListTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TestReverse()
        {
            var input = new ListNode<int>
            {
                value = 1,
                next = new ListNode<int>
                {
                    value = 2,
                    next = new ListNode<int>
                    {
                        value = 3,
                        next = new ListNode<int>
                        {
                            value = 4,
                            next = null
                        }
                    }
                }
            };

            ListNode<int> reversed = ReverseLinkedList(input);
            for (int expected = 4; expected >= 1; expected--)
            {
                var actual = reversed.value;
                reversed = reversed.next;
                Assert.Equal(expected, actual);
            }
        }

        private ListNode<int> ReverseLinkedList(ListNode<int> l)
        {
            //var prev = new ListNode<int> { value = l.value };
            ListNode<int> prev = null;
            var curr = l;
            var next = l.next;

            while (next != null)
            {
                curr.next = prev;
                prev = curr;
                curr = next;

                next = next.next;
            }

            curr.next = prev;

            return curr;
        }
    }

    class ListNode<T>
    {
        public T value { get; set; }
        public ListNode<T> next { get; set; }
    }

}
