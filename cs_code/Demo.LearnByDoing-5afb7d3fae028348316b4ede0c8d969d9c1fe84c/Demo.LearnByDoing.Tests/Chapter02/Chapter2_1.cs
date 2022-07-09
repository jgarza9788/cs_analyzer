using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    public class Chapter2_1
    {
        /// <summary>
        /// Second attempt without using a temporary buffer.
        /// </summary>
        /// <remarks>Looked at two hints at this point.</remarks>
        public LinkedList<int> RemoveDuplicatesWithoutTemporaryBuffer(LinkedList<int> input)
        {
            // Pointer 1
            for (int i = 0; i < input.Count; i++)
            {
                // Poiner 2
                for (int j = i + 1; j < input.Count; j++)
                {
                    var currentValue = input.ElementAt(i);
                    var firstNode = input.Find(currentValue);
                    var lastNode = input.FindLast(currentValue);

                    if (firstNode != lastNode)
                        input.Remove(lastNode);
                }
            }

            return input;
        }

        /// <summary>
        /// First try: Remove duplicates using a temporary buffer.
        /// </summary>
        public LinkedList<int> RemoveDuplicates(LinkedList<int> input)
        {
            LinkedList<int> result = new LinkedList<int>();

            foreach (var value in input)
            {
                if (!result.Contains(value))
                    result.AddLast(value);
            }

            return result;;
        }
    }
}