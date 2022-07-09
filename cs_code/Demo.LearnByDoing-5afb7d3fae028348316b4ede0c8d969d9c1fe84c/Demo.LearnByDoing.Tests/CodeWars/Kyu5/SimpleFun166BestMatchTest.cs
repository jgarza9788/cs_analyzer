//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Demo.LearnByDoing.Core;
//using Xunit;
//using Xunit.Abstractions;

//namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
//{
//    /// <summary>
//    /// https://www.codewars.com/kata/58b38256e51f1c2af0000081/train/csharp
//    /// </summary>
//    public class SimpleFun166BestMatchTest : BaseTest
//    {
//        public SimpleFun166BestMatchTest(ITestOutputHelper output) : base(output)
//        {
//        }

//        [Fact]
//        public void BasicTests()
//        {
//            var kata=new Kata();
            
////            Assert.Equal(1,kata.BestMatch(new int[]{6, 4},new int[]{1, 2}));
////            Assert.Equal(0,kata.BestMatch(new int[]{1},new int[]{0}));
////            Assert.Equal(4,kata.BestMatch(new int[]{1, 2, 3, 4, 5},new int[]{0, 1, 2, 3, 4}));
////            Assert.Equal(2,kata.BestMatch(new int[]{3, 4, 3},new int[]{1, 1, 2}));
////            Assert.Equal(1,kata.BestMatch(new int[]{4, 3, 4},new int[]{1, 1, 1}));
////            Assert.Equal(3,kata.BestMatch(new int[]{8, 9, 10, 9, 10, 5, 8, 11, 4, 5, 8, 10, 5, 9},new int[]{0, 5, 8, 8, 6, 3, 7, 2, 1, 4, 4, 0, 1, 6}));
//            Assert.Equal(12,kata.BestMatch(new int[]{17, 9, 13, 13, 5, 18, 20, 16, 6, 5, 3, 10, 1, 10},new int[]{9, 6, 10, 4, 0, 10, 10, 7, 0, 2, 1, 4, 0, 2}));
//        }
//    }
    
//    public partial class Kata
//    {
//        public int BestMatch(int[] goals1, int[] goals2)
//        {
//            var diffMap = new Dictionary<int, Tuple<int, int>>(goals1.Length);
//            for (int i = 0; i < goals1.Length; i++)
//            {
//               diffMap[i] = Tuple.Create(goals1[i] - goals2[i], goals2[i]);
//            }

//            var min = diffMap.Where(pair => pair.Value.Item1 > 0).Min(pair => pair.Value.Item1);
//            int maxIndex = -1;
//            int maxValue = -1;
            
//            var enumerable = diffMap.OrderBy(pair => pair.Key).Where(pair => pair.Value.Item1 == min);
//            foreach (var arg in enumerable)
//            {
//                if (arg.Value.Item2 > maxValue)
//                {
//                    maxValue = arg.Value.Item2;
//                    maxIndex = arg.Key;
//                }
//            }

//            return maxIndex;
//        }
//    }
//}