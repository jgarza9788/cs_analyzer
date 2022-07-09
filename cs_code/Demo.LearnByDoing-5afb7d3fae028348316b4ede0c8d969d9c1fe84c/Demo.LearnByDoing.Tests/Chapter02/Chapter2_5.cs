using System;
using System.Linq;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    public class Chapter2_5
    {
        public Node<int> AddNodesForwards(Node<int> left, Node<int> right)
        {
            int leftLength = GetNodeLength(left);
            int rightLength = GetNodeLength(right);

            if (leftLength > rightLength)
                right = PadZeroNodes(leftLength, right);

            if (leftLength < rightLength)
                left = PadZeroNodes(rightLength, left);


            int startDigit = (int) Math.Pow(10.0, Math.Max(leftLength, rightLength) - 1);
            const int startNumber = 0;
            return ConvertToForwardNode(SumNodesForward(left, right, startDigit, startNumber));
        }

        private int SumNodesForward(Node<int> left, Node<int> right, int digit, int accum)
        {
            int nextDigit = digit / 10;
            var zeroNode = new Node<int>(0);

            if (left == null && right == null) return accum;

            var sum = (left.Data + right.Data) * digit;
            if (left.Next == null && right.Next == null) return accum + sum;
            if (left.Next != null && right.Next == null) return SumNodesForward(left.Next, zeroNode, nextDigit, accum + sum);
            if (left.Next == null && right.Next != null) return SumNodesForward(zeroNode, right.Next, nextDigit, accum + sum);
            if (left.Next != null && right.Next != null) return SumNodesForward(left.Next, right.Next, nextDigit, accum + sum);

            return SumNodesForward(left.Next, right.Next, nextDigit, accum + sum);
        }

        public Node<int> AddNodesReverse(Node<int> left, Node<int> right)
        {
            const int startDigit = 1;
            const int startNumber = 0;
            return ConvertToReverseNode(SumNodes(left, right, startDigit, startNumber));
        }

        public int GetNodeLength(Node<int> node)
        {
            Node<int> copy = node;
            int count = 0;
            while (copy != null)
            {
                count++;

                copy = copy.Next;
            }

            return count;
        }

        /// <param name="length">It's 1-based!</param>
        public Node<int> PadZeroNodes(int length, Node<int> node)
        {
            Node<int> head = node;

            for (int i = 1; i < length; i++)
            {
                node = node?.Next;
                if (node == null)
                {
                    var zeroNode = new Node<int>(0);
                    zeroNode.Next = head;
                    head = zeroNode;
                }

            }

            return head;
        }

        private int SumNodes(Node<int> left, Node<int> right, int digit, int accum)
        {
            int nextDigit = digit * 10;
            var zeroNode = new Node<int>(0);

            if (left == null && right == null) return accum;

            var sum = (left.Data + right.Data) * digit;
            if (left.Next == null && right.Next == null) return accum + sum;
            if (left.Next != null && right.Next == null) return SumNodes(left.Next, zeroNode, nextDigit, accum + sum);
            if (left.Next == null && right.Next != null) return SumNodes(zeroNode, right.Next, nextDigit, accum + sum);
            if (left.Next != null && right.Next != null) return SumNodes(left.Next, right.Next, nextDigit, accum + sum);

            return SumNodes(left.Next, right.Next, nextDigit, accum + sum);
        }

        private Node<int> ConvertToReverseNode(int value)
        {
            var numbers = value.ToString().ToCharArray().Select(c => int.Parse(c.ToString())).Reverse().ToList();
            Node<int> result = new Node<int>(numbers.FirstOrDefault());
            Node<int> head = result;

            foreach (int number in numbers.Skip(1))
            {
                result.Next = new Node<int>(number);
                result = result.Next;
            }

            return head;
        }

        private Node<int> ConvertToForwardNode(int value)
        {
            var numbers = value.ToString().ToCharArray().Select(c => int.Parse(c.ToString())).ToList();
            Node<int> result = new Node<int>(numbers.FirstOrDefault());
            Node<int> head = result;

            foreach (int number in numbers.Skip(1))
            {
                result.Next = new Node<int>(number);
                result = result.Next;
            }

            return head;
        }
    }
}