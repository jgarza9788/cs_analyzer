using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/reverse-string-in-place
	/// 
	/// Write a method to reverse a string in-place. ↴
	/// 
	/// Since strings in C# are immutable ↴ , first convert the string into an array of characters, do the in-place reversal on that array, and re-join that array into a string before returning it. This isn't technically "in-place" and the array of characters will cost O(n)O(n)O(n) additional space, but it's a reasonable way to stay within the spirit of the challenge. If you're comfortable coding in a language with mutable strings, that'd be even better!
	/// </summary>
	public class Question026Test
	{
		[Theory]
		[MemberData(nameof(GetSampleCases))]
		public void TestSampleCases(string expected, string input)
		{
			var sut = new StringReverser();
			var actual = sut.ReverseInPlace(input);
			Assert.Equal(expected, actual);

			var actual2 = sut.ReverseInPlace2(input);
			Assert.Equal(expected, actual2);
		}

		public static IEnumerable<object[]> GetSampleCases()
		{
			yield return new object[]{"fedcba", "abcdef" };
			yield return new object[]{"edcba", "abcde" };
		}

		public class StringReverser
		{
			/// <summary>
			/// Implementation using Answer on InterviewCake
			/// </summary>
			public string ReverseInPlace2(string input)
			{
				int startIndex = 0;
				int endIndex = input.Length - 1;
				var a = input.ToCharArray();

				while (startIndex < endIndex)
				{
					Swap(a, startIndex, endIndex);

					startIndex++;
					endIndex--;
				}

				return new string(a);
			}

			public string ReverseInPlace(string input)
			{
				var middleIndex = (input.Length - 1) / 2;
				var leftIndex = middleIndex;
				var rightIndex = leftIndex + (input.Length % 2 == 0 ? 1 : 0);
				var a = input.ToCharArray();

				for (; leftIndex >= 0; leftIndex--, rightIndex++)
				{
					if (leftIndex == rightIndex) continue;
					Swap(a, leftIndex, rightIndex);
				}

				return string.Concat(a);
			}

			private void Swap(char[] a, int i, int j)
			{
				var temp = a[i];
				a[i] = a[j];
				a[j] = temp;
			}
		}
	}
}
