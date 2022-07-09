//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Demo.LearnByDoing.Core;
//using Xunit;
//using Xunit.Abstractions;

//namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
//{
//	public class OnesAndZeroesAndWildcardsTest : BaseTest
//	{
//		public OnesAndZeroesAndWildcardsTest(ITestOutputHelper output) : base(output)
//		{
//		}

//		[Fact]
//		public void Basic1()
//		{
//			var list = new List<string> { "1001", "1011" };
//			Assert.Equal(new Kata().Possibilities("10?1").OrderBy(t => t), list.OrderBy(t => t));
//		}

//		[Fact]
//		public void Basic2()
//		{
//			var list = new List<string> { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
//			Assert.Equal(new Kata().Possibilities("????").OrderBy(t => t), list.OrderBy(t => t));
//		}

//		[Fact]
//		public void Basic3()
//		{
//			var list = new List<string> { "1010", "1110", "1011", "1111" };
//			Assert.Equal(new Kata().Possibilities("1?1?").OrderBy(t => t), list.OrderBy(t => t));
//		}
//	}

//	public partial class Kata
//	{
//		public List<string> Possibilities(string input)
//		{
//			int index = input.IndexOf('?');
//			if (index < 0) return new List<string> {input};

//			return     Possibilities(input.Substring(0, index) + "0" + input.Substring(index + 1))
//				.Union(Possibilities(input.Substring(0, index) + "1" + input.Substring(index + 1))).ToList();
//		}

//		public List<string> Possibilities2(string input)
//		{
//			var result = new List<string>();
//			int depth = GetDepth(input);
//			List<string> permutations = GetPermutations(depth).ToList();

//			foreach (string permutation in permutations)
//			{
//				char[] digits = permutation.ToCharArray();
//				var j = 0;
//				var temp = new StringBuilder(input);

//				for (int i = 0; i < input.Length; i++)
//				{
//					if (temp[i] == '?')
//					{
//						temp[i] = digits[j];
//						j++;
//					}
//				}

//				result.Add(temp.ToString());
//			}

//			return result;
//		}

//		private IEnumerable<string> GetPermutations(int depth)
//		{
//			string acc = "";
//			return GetPermutations(acc, "", depth);
//		}

//		private IEnumerable<string> GetPermutations(string acc, string prefix, int depth)
//		{
//			acc = prefix + acc;
//			if (depth <= 0)
//			{
//				yield return acc;
//				yield break;
//			}

//			foreach (string permutation in GetPermutations(acc, "0", depth - 1))
//			{
//				yield return permutation;
//			}

//			foreach (string permutation in GetPermutations(acc, "1", depth - 1))
//			{
//				yield return permutation;
//			}
//		}

//		private int GetDepth(string input)
//		{
//			return input.Count(c => c == '?');
//		}
//	}
//}
