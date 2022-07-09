using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	/// <summary>
	/// https://www.codewars.com/kata/valid-parentheses
	/// </summary>
	public class ValidParenthesesTest
	{
		[Test]
		public void SampleTest1()
		{
			Assert.AreEqual(true, Parentheses.ValidParentheses("()"));
			Assert.AreEqual(true, Parentheses.ValidParentheses("(())((()())())"));
			Assert.AreEqual(true, Parentheses.ValidParentheses("hi(hi)"));
		}

		[Test]
		public void SampleTest2()
		{
			Assert.AreEqual(false, Parentheses.ValidParentheses("()(()"));
			Assert.AreEqual(false, Parentheses.ValidParentheses(")(((("));
			Assert.AreEqual(false, Parentheses.ValidParentheses(")(()))"));
			Assert.AreEqual(false, Parentheses.ValidParentheses("("));
			Assert.AreEqual(false, Parentheses.ValidParentheses(")"));
		}
	}

	public class Parentheses
	{
		public static bool ValidParentheses(string input)
		{
			// Create a map that matches the closing Parenthesis.
			Func<char, bool> isOpenParenthesis = c => c == '(';
			Func<char, bool> isCloseParenthesis = c => c == ')';
			Func<char, bool> isParenthesis = c => isOpenParenthesis(c) || isCloseParenthesis(c);

			// Stack to check if we have a matching closing parenthesis.
			// This should be empty at the end of iterations.
			var stack = new Stack<char>();

			foreach (var c in input)
			{
				if (!isParenthesis(c)) continue;

				if (isOpenParenthesis(c)) stack.Push(c);
				else if (stack.Count == 0) return false;
				else stack.Pop();
			}

			return stack.Count == 0;
		}
	}
}
