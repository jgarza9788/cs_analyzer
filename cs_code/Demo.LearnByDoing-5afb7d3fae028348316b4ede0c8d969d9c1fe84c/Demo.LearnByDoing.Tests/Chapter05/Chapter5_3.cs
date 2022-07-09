using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.Tests.Chapter05
{
    public class Chapter5_3
    {
        public int GetLongestSequenceOfOnes(int number)
        {
            // Get the list containing sequential 1s.
            // e.g.) 110 1110 1111 => 2, 3, 4
            List<int> oneCount = GetOneCount(number).ToList();

            // get the sum of next adjacent item
            // get the max of the sum
            int max = 0;
            for (int i = 0; i < oneCount.Count - 1; i++)
            {
                int sum = oneCount[i] + oneCount[i + 1];
                if (sum > max)
                    max = sum;
            }

            // flipped bit size
            const int flippedBitSize = 1;
            return max + flippedBitSize;
        }

        // 32 bit integer.
        private const int INT_BIT_SIZE = 32;

        public IEnumerable<int> GetOneCount(int number)
        {
            int startValue = 1;
            int sequenceSize = 0;

            Func<int, string> toBin = value => Convert.ToString(value, 2);

            for (int i = 0; i < INT_BIT_SIZE; i++)
            {
                int mask = startValue << i;
                if ((mask & number) >= 1)
                {
                    sequenceSize++;
                }
                else
                {
                    if (sequenceSize != 0)
                        yield return sequenceSize;

                    sequenceSize = 0;
                }
            }
        }
    }
}