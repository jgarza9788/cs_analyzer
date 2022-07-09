using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu4
{
    /// <summary>
    /// http://www.codewars.com/kata/range-extraction
    /// </summary>
    public class RangeExtractionTest
    {
        [Test(Description = "Simple tests")]
        public void SimpleTests()
        {
            Assert.AreEqual("1,2", RangeExtraction.Extract(new[] { 1, 2 }));
            Assert.AreEqual("1-3", RangeExtraction.Extract(new[] { 1, 2, 3 }));

            Assert.AreEqual(
                "-6,-3-1,3-5,7-11,14,15,17-20",
                RangeExtraction.Extract(new[] { -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20 })
            );

            Assert.AreEqual(
                "-3--1,2,10,15,16,18-20",
                RangeExtraction.Extract(new[] { -3, -2, -1, 2, 10, 15, 16, 18, 19, 20 })
            );
        }
    }

    public class RangeExtraction
    {
        public static string Extract(int[] a)
        {
            var buckets = new List<List<int>>();
            var prev = a[0];
            var bucket = new List<int> { prev };

            // Fill buckets.
            for (int i = 1; i < a.Length; i++)
            {
                var curr = a[i];
                if (prev + 1 == curr) bucket.Add(curr);
                else
                {
                    buckets.Add(bucket);
                    bucket = new List<int> { curr };
                }

                prev = curr;
            }

            // Add the last bucket to buckets.
            buckets.Add(bucket);

            // Extract buckets to form ranges.
            return string.Join(",", ExtractRanges(buckets));
        }

        private static IEnumerable<string> ExtractRanges(List<List<int>> buckets)
        {
            foreach (var bucket in buckets)
            {
                if (bucket.Count == 1) yield return bucket[0].ToString();
                else if (bucket.Count == 2) yield return $"{bucket[0]},{bucket[1]}";
                else yield return $"{bucket[0]}-{bucket.Last()}";
            }
        }

        public static string Extract_bad(int[] args)
        {
            Console.WriteLine($"args = '{string.Join(",", args)}'");

            int prev = args.First();
            var groups = new List<List<int>>();
            var inner = new List<int> { prev };

            for (int i = 1; i < args.Length; i++)
            {
                var current = args[i];
                // It's the next sequence so we add it to the list.
                if (current == prev + 1)
                {
                    inner.Add(current);
                }
                // We need to create a new list to hold next sequence.
                else
                {
                    groups.Add(inner);
                    inner = new List<int> { current };
                }
            }

            groups.Add(inner);

            // Flatten arrays in groups
            var flat = groups.SelectMany(g =>
            {
                Console.WriteLine($"'{string.Join("|", g)}' - count: {g.Count}");

                if (g.Count == 1)
                {
                    return g[0].ToString();
                }
                else if (g.Count == 2)
                {
                    return $"{g.First()},{g.Last()}";
                }
                else
                {
                    return $"{g.First()}-{g.Last()}";
                }
            });

            foreach (var n in flat) Console.WriteLine($"flat value: {n}");


            var result = string.Concat(flat);
            Console.WriteLine($"result = '{result}'");

            return result;
            //       return string.Join(",", flat);
        }
    }
}
