using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/permutation-palindrome
	/// 
	/// Write an efficient method that checks whether any permutation ↴ of an input string is a palindrome. ↴
	/// 
	/// You can assume the input string only contains lowercase letters.
	/// 
	/// Examples:
	/// 
	/// "civic" should return true
	/// "ivicc" should return true
	/// "civil" should return false
	/// "livci" should return false
	/// 
	/// "But 'ivicc' isn't a palindrome!"
	/// 
	/// If you had this thought, read the question again carefully. We're asking if any permutation of the string is a palindrome. Spend some extra time ensuring you fully understand the question before starting. Jumping in with a flawed understanding of the problem doesn't look good in an interview.
	/// </summary>
	public class Question030Test
	{
		public static IEnumerable<object[]> GetSampleCases()
		{
			yield return new object[] {true, "civic"};
			yield return new object[] {true, "ivicc" };
			yield return new object[] {false, "civil" };
			yield return new object[] {false, "livci" };
		}

		[Theory]
		[MemberData(nameof(GetSampleCases))]
		public void TestSampleCases(bool expected, string word)
		{
			var sut = new Question030();
			Assert.Equal(expected, sut.IsPermutationPalindrome(word));
			Assert.Equal(expected, sut.IsPermutationPalindrome2(word));
		}
	}

	public class Question030
	{
		public bool IsPermutationPalindrome2(string word)
		{
			var oddSet = new HashSet<char>();
			foreach (char c in word)
			{
				if (oddSet.Contains(c))
					oddSet.Remove(c);
				else
					oddSet.Add(c);
			}

			return oddSet.Count <= 1;
		}

		public bool IsPermutationPalindrome(string word)
		{
			// if XOR'ed string length is 0 or 1, then it's a palindrome.
			int xor = 0;
			foreach (char c in word)
			{
				xor ^= c;
			}

			return word.IndexOf((char) xor) > -1 && (xor == 0 || ('a' <= xor && xor <= 'z'));
		}
	}
}
