using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeSignal.Hashtable
{
    /// <summary>
    /// https://app.codesignal.com/interview-practice/task/izLStwkDr5sMS9CEm
    /// </summary>
    public class FindLongestSubArrayBySumTest
    {
        public static IEnumerable<object[]> GetTestCases()
        {
            yield return new object[] {new[] {1, 5}, 15, new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}};
            yield return new object[] {new[] {2, 4}, 12, new[] {1, 2, 3, 7, 5}};
            yield return new object[] {new[] {1, 8}, 15, new[] {1, 2, 3, 4, 5, 0, 0, 0, 6, 7, 8, 9, 10}};
            yield return new object[] {new[] {1, 3}, 3, new[] {0, 3, 0}};
            yield return new object[] {new[] {1, 1}, 3, new[] {3}};
            yield return new object[] {new[] {-1}, 3, new[] {2}};
            yield return new object[]
            {
                new[] {42, 46}, 468,
                new[]
                {
                    135, 101, 170, 125, 79, 159, 163, 65, 106, 146, 82, 28, 162, 92, 196, 143, 28, 37, 192, 5, 103, 154,
                    93, 183, 22, 117, 119, 96, 48, 127, 0, 172, 0, 139, 0, 0, 70, 113, 68, 100, 36, 95, 104, 12, 123,
                    134
                }
            };
            yield return new object[]
            {
                new[] {-1}, 665,
                new[]
                {
                    142, 112, 54, 69, 148, 45, 63, 158, 38, 60, 124, 142, 130, 179, 117, 36, 191, 43, 89, 107, 41, 143,
                    65, 49, 47, 6, 91, 130, 171, 151, 7, 102, 194, 149, 30, 24, 85, 155, 157, 41, 167, 177, 132, 109,
                    145, 40, 27, 124, 138, 139, 119, 83, 130, 142, 34, 116, 40, 59, 105, 131, 178, 107, 74, 187, 22,
                    146, 125, 73, 71, 30, 178, 174, 98, 113
                }
            };
            yield return new object[]
            {
                new[] {-1}, 1291,
                new[]
                {
                    162, 37, 156, 168, 56, 175, 32, 53, 151, 151, 142, 125, 167, 31, 108, 192, 8, 138, 58, 88, 154, 184,
                    146, 110, 10, 159, 22, 189, 23, 147, 107, 31, 14, 169, 101, 192, 163, 56, 11, 160, 25, 138, 149, 84,
                    196, 42, 3, 151, 92, 37, 175, 21, 197, 22, 149, 200, 69, 85, 82, 135, 54, 200, 19, 139, 101, 189,
                    128, 68, 129, 94, 49, 84, 8, 22, 111, 18, 14, 115, 110, 17, 136, 52, 1, 50, 120, 157, 199
                }
            };
            yield return new object[] {new[] {-1}, 225, new[] {9, 45, 10, 190}};
            yield return new object[] {new[] {-1}, 1196, new[] {86, 94, 144}};
            yield return new object[] {new[] {2, 2}, 0, new[] {1, 0, 2}};
            yield return new object[]
            {
                new[] {-1}, 1588,
                new[]
                {
                    115, 104, 49, 1, 59, 19, 181, 197, 199, 82, 190, 199, 10, 158, 73, 23, 139, 93, 39, 180, 191, 58,
                    159, 192
                }
            };
            yield return new object[]
                {new[] {-1}, 889, new[] {157, 112, 3, 35, 73, 56, 129, 47, 163, 87, 76, 34, 70, 143, 45, 17}};
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void TestAllCases(int[] expected, int s, int[] arr)
        {
            var actual = findLongestSubarrayBySum(s, arr);
            Assert.True(expected.SequenceEqual(actual));
        }

        int[] findLongestSubarrayBySum(int s, int[] arr)
        {
            if (arr == null || arr.Length <= 0) return new[] {-1};
            if (arr[0] == s) return new[] {1, 1};

            var map = new Dictionary<int, List<int>>{{0, new List<int>{0}}};
            var acc = 0;
            // build accumulation map
            for (int i = 0; i < arr.Length; i++)
            {
                var curr = arr[i];
                acc += curr;
                if (map.ContainsKey(acc))
                    map[acc].Add(i + 1);
                else
                    map.Add(acc, new List<int> {i + 1});
            }

            // Find max sub array
            var res = new int[2];
            var isTouched = false;
            foreach (int current in map.Keys)
            {
                var compliment = s + current;
                if (!map.ContainsKey(compliment)) continue;

                var minIndex = map[current].Min();
                var maxIndex = map[compliment].Max();
                if (res[1] - res[0] < maxIndex - minIndex)
                {
                    isTouched = true;
                    res[0] = minIndex + 1;
                    res[1] = maxIndex;
                }
            }

            return isTouched ? res : new[] {-1};
        }

        int[] findLongestSubarrayBySum2(int s, int[] arr)
        {
            if (arr == null || arr.Length <= 0) return new[] {-1};
            if (arr[0] == s) return new[] {1, 1};

            var accs = new Dictionary<int, int>();
            var distance = 0;
            accs[distance] = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                distance += arr[i];
                accs[distance] = i + 1;

                // Console.WriteLine($"i={i}, arr[i]={arr[i]}, distance={distance}, accs[distance]={accs[distance]}");
            }

            foreach (var key in accs.Keys)
            {
                Console.WriteLine($"{key} = {accs[key]}");
            }

            var result = new List<int>();

            foreach (var key in accs.Keys)
            {
                var nextKey = key + s;
                Console.WriteLine($"key={key}, nextKey={nextKey}");
                if (!accs.ContainsKey(nextKey)) continue;

                if (result.Count == 0)
                {
                    result.Add(accs[key] + 1);
                    result.Add(accs[nextKey]);
                }
                else if (result[1] - result[0] < accs[nextKey] - accs[key])
                {
                    result.Clear();
                    result.Add(accs[key]);
                    result.Add(accs[nextKey]);
                }
            }

            if (result.Count > 0) return result.ToArray();

            return new[] {-1};
        }
    }
}