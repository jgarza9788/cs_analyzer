using System;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    public class Chapter2_3
    {
        const int MINIMUM_LENGTH = 3;

        public Node<string> RemoveMiddelValue(string middleValue, Node<string> input)
        {
            int nodeCount = GetNodeCount(input);

            Node<string> head = input;
            
            for (int i = 0; i <= nodeCount - MINIMUM_LENGTH; i++)
            {
                if (input.Next.Data == middleValue)
                {
                    input.Next = input.Next.Next;
                    break;
                }

                input = input.Next;
            }

            return head;
        }

        public Node<string> GetMiddleNodes(Node<string> input)
        {
            int nodeCount = GetNodeCount(input);
            if (nodeCount < MINIMUM_LENGTH) throw new ArgumentOutOfRangeException(nameof(input), "Input should have at least 3 nodes!");

            // skip the first node and start from the 2nd node.
            input = input.Next;
            Node<string> tempNode = new Node<string>(input.Data);
            Node<string> head = tempNode;

            for (int i = 0; i < nodeCount - MINIMUM_LENGTH; i++)
            {
                input = input.Next;
                tempNode.Next = new Node<string>(input.Data);

                tempNode = tempNode.Next;
            }

            return head;
        }

        public int GetNodeCount(Node<string> input)
        {
            if (input == null) return 0;

            int count = 0;
            while (input != null)
            {
                input = input.Next;

                count++;
            }

            return count;
        }
    }
}