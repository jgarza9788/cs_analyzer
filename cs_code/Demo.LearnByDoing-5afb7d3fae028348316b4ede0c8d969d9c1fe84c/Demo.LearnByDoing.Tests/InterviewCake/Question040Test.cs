using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/find-duplicate-optimize-for-space
	/// 
	/// 
	/// 
	/// Find a duplicate, Space Edition™.
	/// 
	/// We have an array of integers, where:
	/// 
	/// The integers are in the range 1..n
	/// The array has a length of n+1
	/// 
	/// It follows that our array has at least one integer which appears at least twice. But it may have several duplicates, and each duplicate may appear more than twice.
	/// 
	/// Write a method which finds an integer that appears more than once in our array. (If there are multiple duplicates, you only need to find one of them.)
	/// 
	/// We're going to run this method on our new, super-hip Macbook Pro With Retina Display™. Thing is, the damn thing came with the RAM soldered right to the motherboard, so we can't upgrade our RAM. So we need to optimize for space!
	/// 
	/// </summary>
	public class Question040Test
	{
		[Theory]
		[MemberData(nameof(GetSampleCases))]
		public void TestSampleCases(int expected, int[] input)
		{
			int actual = GetDuplicate(input);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[MemberData(nameof(GetSampleCases))]
		public void TestSampleCasesWithoutModifyingInput(int expected, int[] input)
		{
			int actual = GetDuplicateWithoutModifyingInput(input);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetSampleCases()
		{
			//									   0  1  2  3  4
			yield return new object[] { 2, new[] { 2, 3, 1, 2, 1 } };
			yield return new object[] { 1, new[] { 1, 2, 3, 1, 3 } };
			yield return new object[] { 2, new[] { 1, 2, 3, 2, 2 } };
			yield return new object[] { 3, new[] { 3, 1, 2, 3, 3 } };
		}

		private int GetDuplicateWithoutModifyingInput(int[] input)
		{
			return -1;
		}

		private int GetDuplicate(int[] a)
		{
			for (int i = 0; i < a.Length; i++)
			{
				var curr = a[i];
				if (a[Math.Abs(curr)] < 0) return Math.Abs(curr);
				a[Math.Abs(curr)] = -a[Math.Abs(curr)];
			}

			throw new Exception("Not found!");
		}
	}
}
