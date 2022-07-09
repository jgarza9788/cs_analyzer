using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    public class Chapter2_6
    {
        public bool IsNodePalindrome(Node<int> node)
        {
            return IsPalindrome(node);
        }

        private bool IsPalindrome(Node<int> node)
        {
            int length = node.GetLength();
            if (length == 1) return true;

            Node<int> copy = node;

            Stack<int> firstHalf = new Stack<int>(length / 2);
            for (int i = 0; i < length/2; i++)
            {
                firstHalf.Push(copy.Data);
                copy = copy.Next;
            }

            Func<int, bool> isOdd = number => number % 2 == 1;

            // We skip the middle value
            if (isOdd(length))
                copy = copy.Next;

            // get latter half
            Queue<int> secondHalf = new Queue<int>(length / 2);
            for (int i = 0; i < length / 2; i++)
            {
                secondHalf.Enqueue(copy.Data);
                copy = copy.Next;
            }

            return firstHalf.SequenceEqual(secondHalf);
        }
    }
}