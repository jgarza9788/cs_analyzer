using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/bracket-validator
	/// 
	/// You're working with an intern that keeps coming to you with JavaScript code 
	/// that won't run because the braces, brackets, and parentheses are off.
	/// To save you both some time, you decide to write a braces/brackets/parentheses validator.
	/// 
	/// Let's say:
	/// 
	/// '(', '{', '[' are called "openers."
	/// ')', '}', ']' are called "closers."
	/// 
	/// Write an efficient method that tells us whether or not an input string's openers and closers are properly nested.
	/// 
	/// Examples:
	/// 
	/// "{ [ ] ( ) }" should return true
	/// "{ [ ( ] ) }" should return false
	/// "{ [ }" should return false
	/// </summary>
	public class Question029Test
	{
		[Theory]
		[MemberData(nameof(GetSampleCases))]
		public void TestSampleCases(bool expected, string input)
		{
			var sut = new Question029();
			var actual = sut.IsBracketMatching(input);

			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetSampleCases()
		{
			yield return new object[] { true, "{ [ ] ( ) }" };
			yield return new object[] { true, "{()[]([])}" };
			yield return new object[] { false, "{ [ ( ] ) }" };
			yield return new object[] { false, "{ [ }" };
		}
	}

	public class Question029
	{
		public bool IsBracketMatching(string input)
		{
			// if you see an opener, push the matching closer into the stack.
			// if you run into a closer, then pop the stack. If the closer does not match, return false else carry on.

			var openMap = new Dictionary<char, char> { { '{', '}' }, { '(', ')' }, { '[', ']' } };
			var closeMap = new HashSet<char>(openMap.Values);
			var bracketStack = new Stack<char>();

			foreach (var c in input)
			{
				if (openMap.ContainsKey(c))
				{
					bracketStack.Push(openMap[c]);
				}
				else if (closeMap.Contains(c))
				{
					var closingBracket = bracketStack.Pop();
					if (c != closingBracket) return false;
				}
			}

			return bracketStack.Count == 0;
		}
	}
}
