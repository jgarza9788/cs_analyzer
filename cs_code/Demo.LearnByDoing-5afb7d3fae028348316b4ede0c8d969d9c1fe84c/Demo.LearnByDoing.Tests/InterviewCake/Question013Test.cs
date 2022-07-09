using System;
using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	public class Question013Test
	{
		[Fact]
		public void TestEdgeCases()
		{
			const int expected = 0;
			var sut = new Question013();

			int actual = sut.GetRotationIndex(null);
			Assert.Equal(expected, actual);

			actual = sut.GetRotationIndex(new string[]{});
			Assert.Equal(expected, actual);

			actual = sut.GetRotationIndex(new[]{"first"});
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> SampleCases()
		{
			yield return new object[] {5, new[] { "ptolemaic", "retrograde", "supplant", "undulate", "xenoepist", "asymptote", "babka", "banoffee", "engender", "karpatka", "othellolagkage" } };
			yield return new object[] {0, new[] { "ab", "bc", "cd", "de", "ef", "fg", "gh", "hi", "ij" } };
			yield return new object[] {8, new[] { "ij", "hi", "gh", "fg", "ef", "de", "cd", "bc", "ab" } };
			yield return new object[] {8, new[] { "i", "h", "g", "f", "e", "d", "c", "b", "a" } };
			yield return new object[] {2, new[] { "s", "x", "a", "b", "c", "d", "e" } };
		}

		[Theory]
		[MemberData(nameof(SampleCases))]
		public void TestSample(int expected, string[] words)
		{
			int actual = new Question013().GetRotationIndex(words);
			Assert.Equal(expected, actual);
		}
	}

	public class Question013
	{
		public int GetRotationIndex(string[] words)
		{
			if (words == null || words.Length <= 1) return 0;

			int start = 0;
			int end = words.Length - 1;
			while (start <= end)
			{
				int mid = (start + end) / 2;
				if (mid == 0 || mid == words.Length - 1) return mid;
				var word = words[mid];

				int left = string.Compare(word, words[mid - 1]);
				int right = string.Compare(word, words[mid + 1]);

				if (left == 1 && right == 1) return mid + 1;
				if (left == -1 && right == -1) return mid;

				// move left
				if (left == 1 && right == -1) end = mid - 1;
				// move right
				if (left == -1 && right == 1) start = mid + 1;
			}

			throw new Exception("Not found!");
		}

		public int GetRotationIndex_Slow(string[] words)
		{
			if (words == null || words.Length <= 1) return 0;

			// Get previous word.
			var prev = words[0];

			// Compare the current word with the previous word.
			// If the current word comes before the previous word then that's the rotation point, so return that index.
			for (int i = 1; i < words.Length; i++)
			{
				var curr = words[i];
				if (string.CompareOrdinal(curr, prev) < 0) return i;

				prev = curr;
			}

			return 0;
		}
	}
}
