using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeSignal.Hashtable
{
    public class ProductExceptSelfTest : BaseTest
    {
        public static IEnumerable<object[]> GetTestCases()
        {
            yield return new object[] {2, new []{1, 2, 3, 4}, 12};
            yield return new object[] {6, new []{2, 100}, 24};
            yield return new object[] {4, new []{5, 8, 6, 3, 2}, 8};
            yield return new object[] {16, new []{3, 3, 9, 5, 5, 4, 2, 8, 5, 9}, 17};
            yield return new object[] {0, new []{27, 37, 47, 30, 17, 6, 20, 17, 21, 43, 5, 49, 49, 50, 20, 42, 45, 1, 22, 44}, 40};
            yield return new object[] {0, new []{28, 27, 11, 17, 19, 49, 19, 46, 41, 21, 1, 49, 18, 26, 16, 24, 16, 36, 19, 49, 31, 39, 11, 21, 29, 37, 34, 34, 6, 16, 26, 31, 6, 48, 38, 36, 26, 36, 38, 18}, 5040};
            yield return new object[] {220, new []{52, 40, 2, 78, 49, 70, 39, 26, 58, 58, 52, 93, 80, 64, 33, 72, 29, 17, 81, 83, 48, 9, 49, 82, 67, 76, 54, 64, 6, 48, 16, 82, 67, 56, 32, 98, 14, 47, 48, 26, 56, 54, 80, 13, 32, 18, 4, 73, 45, 65}, 530};
            yield return new object[] {55, new []{37, 50, 50, 6, 8, 54, 7, 64, 2, 64, 67, 59, 22, 73, 33, 53, 43, 77, 56, 76, 59, 96, 64, 100, 89, 38, 64, 73, 85, 96, 65, 50, 62, 4, 82, 57, 98, 61, 92, 55, 80, 53, 80, 55, 94, 9, 73, 89, 83, 80}, 67};
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void TestSampleCases(int expected, int[] nums, int m)
        {
            var actual = productExceptSelf(nums, m);
            _output.WriteLine($"expected={expected}, actual={actual}");
            Assert.Equal(expected, actual);
        }

        private int productExceptSelf(int[] nums, int m)
        {
            var products = GetProducts(nums, m).ToArray();
            return products.Sum() % m;
//            var moduloSum = GetModuloSum(products, m);
//
//            return (int) (moduloSum % m);
        }

        private IEnumerable<int> GetProducts(int[] nums, int m)
        {
            var forward = new double[nums.Length];
            var backward = new double[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                forward[i] = 1;
                backward[i] = 1;
            }
            
            // forward 
            for (int i = 0; i < nums.Length - 1; i++)
            {
                forward[i + 1] = (nums[i] * forward[i]) % m;
            }
            
            // backward
            for (int i = nums.Length - 1; i > 0; i--)
            {
                backward[i - 1] = (nums[i] * backward[i]) % m;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                yield return (int)(forward[i] * backward[i]);
            }
        }

        public ProductExceptSelfTest(ITestOutputHelper output) : base(output)
        {
        }
    }
}