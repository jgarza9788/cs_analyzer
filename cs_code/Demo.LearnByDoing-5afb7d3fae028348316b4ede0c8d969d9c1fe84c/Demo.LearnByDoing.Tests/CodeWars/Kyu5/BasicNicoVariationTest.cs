using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
    /// <summary>
    /// https://www.codewars.com/kata/basic-nico-variation/csharp
    /// </summary>
    public class BasicNicoVariationTest : BaseTest
    {
        public BasicNicoVariationTest(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData("crazy", "secretinformation", "cseerntiofarmit on  ")]
        [InlineData("abc", "abcd", "abcd  ")]
        [InlineData("ba", "1234567890", "2143658709")]
        [InlineData("a", "message", "message")]
        [InlineData("key", "key", "eky")]
        public void TestSampleNico(string key, string message, string expected)
        {
            string actual = Kata.Nico(key, message);
            Assert.Equal(expected, actual);
        }
    }
    
    public partial class Kata 
    {
        public static string Nico(string key, string message)
        {
            Dictionary<char, char[]> map = BuildMessageMap(key, message);
//            var orderedValues = map.OrderBy(pair => pair.Key).SelectMany(pair => pair.Value).ToArray();

            StringBuilder buffer = new StringBuilder();
            for (int i = 0; i < map.Values.FirstOrDefault().Length; i++)
            {
                foreach (var obj in map.OrderBy(pair => pair.Key).Select((pair, index) => new {pair.Value, index}))
                {
                    buffer.Append(obj.Value[i]);
                }
            }

            return buffer.ToString();
        }

        private static Dictionary<char, char[]> BuildMessageMap(string key, string message)
        {
            Dictionary<char, char[]> result = new Dictionary<char, char[]>(key.Length);
            int rowCount = (int) Math.Ceiling((double)message.Length / key.Length);

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    var k = key[j];
                
                    if (!result.ContainsKey(k))
                        result.Add(k, new char[rowCount]);

                    var messageIndex = j + (i * key.Length);
                    result[k][i] = messageIndex > message.Length - 1 ? ' ' : message[messageIndex];
                }
            }
           
            return result;
        }

        private static Dictionary<int, List<string>> BuildMap(List<int> keyOrder, string message)
        {
            var map = new Dictionary<int, List<string>>();
            int arrayLength = (int) Math.Ceiling((double) (message.Length / keyOrder.Count));

            
            return map;
        }
    }
}