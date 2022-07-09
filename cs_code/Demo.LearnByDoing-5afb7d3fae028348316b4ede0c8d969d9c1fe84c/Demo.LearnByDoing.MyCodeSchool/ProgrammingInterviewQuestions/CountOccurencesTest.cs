using System.Collections.Generic;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.MyCodeSchool.ProgrammingInterviewQuestions
{
    /// <summary>
    /// Count occurrences of a number in a sorted array with duplicates using Binary Search
    /// https://www.youtube.com/watch?v=pLT_9jwaPLs&list=PL2_aWCzGMAwLPEZrZIcNEq9ukGWPfLT4A&index=2
    /// </summary>
    public class CountOccurencesTest : BaseTest
    {
        private readonly CountOccurences _sut = new CountOccurences();

        public CountOccurencesTest(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(CountOccurencesFirstIndexData))]
        public void TestGettingFirstIndexes(int[] a, int value, int expected)
        {
            int actual = _sut.FindFirstIndex(a, value);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(CountOccurencesLastIndexData))]
        public void TestGettingLastIndexes(int[] a, int value, int expected)
        {
            int actual = _sut.FindLastIndex(a, value);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(CountOccurencesData))]
        public void TestCountOfElementInASortedList(int[] a, int value, int expected)
        {
            int actual = _sut.GetCountUsinBinarySearch(a, value);

            Assert.Equal(expected, actual);
        }
    }

    public class CountOccurences
    {
        public int GetCountUsinBinarySearch(int[] a, int value)
        {
            int firstIndex = FindFirstIndex(a, value);
            int lastIndex = FindLastIndex(a, value);

            return lastIndex - firstIndex + 1;
        }

        private int FindIndex(int[] a, int value, bool findFirst = true)
        {
            int low = 0;
            int high = a.Length - 1;
            int result = int.MinValue;

            while (low <= high)
            {
                int middleIndex = (low + high) / 2;
                int middleValue = a[middleIndex];

                if (value == middleValue)
                {
                    result = middleIndex;
                    if (findFirst)
                        high = middleIndex - 1;
                    else
                        low = middleIndex + 1;
                }
                else if (value < middleValue)
                {
                    high = middleIndex - 1;
                }
                else // value > middleValue
                {
                    low = middleIndex + 1;
                }
            }

            return result;
        }

        public int FindFirstIndex(int[] a, int value)
        {
            return FindIndex(a, value);
        }

        public int FindLastIndex(int[] a, int value)
        {
            return FindIndex(a, value, findFirst:false);
        }
    }

    public class CountOccurencesFirstIndexData : BaseTestData
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 1, 0},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 3, 2},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 5, 4},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 9, 9},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 11, 11},
        };
    }

    public class CountOccurencesLastIndexData : BaseTestData
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 1, 1},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 3, 3},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 5, 8},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 9, 10},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 11, 11},
        };
    }

    public class CountOccurencesData : BaseTestData
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 1, 2},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 3, 2},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 5, 5},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 9, 2},
            new object[] {new[] {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11}, 11, 1},
        };
    }
}
