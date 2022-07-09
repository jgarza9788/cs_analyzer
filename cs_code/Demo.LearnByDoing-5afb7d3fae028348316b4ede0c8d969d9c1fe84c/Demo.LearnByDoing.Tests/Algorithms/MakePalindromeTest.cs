using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Algorithms
{
	public class MakePalindromeTest : BaseTest
	{
		private readonly MakePalindrome _sut = new MakePalindrome();

		public MakePalindromeTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData("BAAABAAB", "AAAB")]
		[InlineData("BAABAAAB", "AAB")]
		[InlineData("abxabacab", "axba")]
		[InlineData("ABB", "A")]
		public void TestForwardLoopResult(string word, string expected)
		{
			string actual = _sut.GetForwardPrefix(word);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("BAAABAAB", "BAA")]
		[InlineData("BAABAAAB", "BAAA")]
		[InlineData("abxabacab", "bacabaxb")]
		[InlineData("ABB", "BB")]
		public void TestBackwardLoopResult(string word, string expected)
		{
			string actual = _sut.GetBackwardPrefix(word);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[ClassData(typeof(AddMinCharToMakePalindromeBaseTestData))]
		public void AddMinCharToMakePalindrome(string word, string expected)
		{
			string actual = _sut.BuildPalindrome(word);

			Assert.Equal(expected, actual);
		}

		///// <summary>
		///// Using Algorithm on http://www.programcreek.com/2014/06/leetcode-shortest-palindrome-java/
		///// "Java Solution 1"
		///// </summary>
		//[Theory]
		//[ClassData(typeof(AddMinCharToMakePalindromeBaseTestData))]
		//public void AddMinCharToMakePalindromeUsingDifferentAlgorithm(string word, string expected)
		//{
		//	string actual = _sut.GetShortestPalindrome(word);

		//	Assert.Equal(expected, actual);
		//}
	}

	public class MakePalindrome
	{
		/// <summary>
		/// this doesn't seem to return the shortest palindrome...
		/// </summary>
		/// <param name="word"></param>
		/// <returns></returns>
		public string GetShortestPalindrome(string word)
		{
			int i = 0;
			int j = word.Length - 1;

			while (j >= 0)
			{
				if (word[i] == word[j])
					i++;
				j--;
			}

			// it's already a palindrome. Return itself.
			if (i == word.Length)
				return word;

			string suffix = word.Substring(i);
			string prefix = new string(suffix.Reverse().ToArray());
			string mid = GetShortestPalindrome(word.Substring(0, i));

			return $"{prefix}{mid}{suffix}";
		}

		public string BuildPalindrome(string word)
		{
			string forwardPrefix = GetForwardPrefix(word);
			string backwardPrefix = GetBackwardPrefix(word);

			if (forwardPrefix.Length < backwardPrefix.Length)
				return word + forwardPrefix;
			return backwardPrefix + word;
		}

		public string GetForwardPrefix(string word)
		{
			var potential = new List<string>();
			var notMatched = new Stack<string>();

			int lastIndex = word.Length - 1;
			int j = lastIndex;

			for (int i = 0; i < word.Length; i++)
			{
				if (word[i] == word[j])
				{
					potential.Add(word[i].ToString());
					j--;
					if (j <= i) break;
				}
				else
				{
					PushRange(notMatched, potential);
					potential.Clear();

					if (word[i] == word[lastIndex])
						i--;
					else
						notMatched.Push(word[i].ToString());

					j = lastIndex;
				}
			}

			return string.Join("", notMatched);
		}

		public string GetBackwardPrefix(string word)
		{
			var potential = new List<string>();
			var notMatched = new List<string>();

			int firstIndex = 0;
			int j = firstIndex;

			for (int i = word.Length - 1; i >= 0; i--)
			{
				if (word[i] == word[j])
				{
					potential.Add(word[i].ToString());
					j++;
					if (j >= i) break;
				}
				else
				{
					notMatched.AddRange(potential);
					potential.Clear();

					if (word[i] == word[firstIndex])
						i++;
					else
						notMatched.Add(word[i].ToString());

					j = firstIndex;
				}
			}

			return string.Join("", notMatched);
		}

		private void PushRange<T>(Stack<T> source, IEnumerable<T> collection)
		{
			foreach (var item in collection)
				source.Push(item);
		}
	}

	public class AddMinCharToMakePalindromeBaseTestData : BaseTestData
	{
		public override List<object[]> Data { get; set; } = new List<object[]>
		{
			new object[]{ "BAAABAAB", "BAABAAABAAB" },
			new object[]{ "BAABAAAB", "BAABAAABAAB" },
			new object[]{ "abxabacab", "abxabacabaxba" },
			new object[]{ "ABB", "ABBA" },
		};
	}
}
