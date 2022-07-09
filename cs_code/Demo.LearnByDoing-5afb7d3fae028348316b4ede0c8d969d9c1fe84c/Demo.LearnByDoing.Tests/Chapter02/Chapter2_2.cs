using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    public class Chapter2_2
    {
        public Node<int> GetKthToLastElementsOfNode(Node<int> input, int k)
        {
            int i = 0;
            while (i < k)
            {
                input = input.Next;
                i++;
            }

            return input;
        }

        public LinkedList<int> GetKthToLastElements(LinkedList<int> input, int k)
        {
            LinkedList<int> result = new LinkedList<int>();

            for (int i = k; i < input.Count; i++)
            {
                result.AddLast(input.ElementAt(i));
            }

            return result;
        }
    }
}