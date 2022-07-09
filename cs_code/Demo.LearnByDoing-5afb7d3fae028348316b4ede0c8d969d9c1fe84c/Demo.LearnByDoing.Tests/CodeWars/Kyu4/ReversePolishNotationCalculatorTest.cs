using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu4
{
	public class ReversePolishNotationCalculatorTest : BaseTest
	{
		public ReversePolishNotationCalculatorTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData("", 0)]
		[InlineData("3", 3)]
		[InlineData("3.5", 3.5)]
		[InlineData("1 3 +", 4)]
		[InlineData("1 3 *", 3)]
		[InlineData("1 3 -", -2)]
		[InlineData("4 2 /", 2)]
		[InlineData("5 1 2 + 4 * + 3 -", 14)]
		public void TestAllEvaluations(string input, double expected)
		{
			double actual = new Calc().evaluate(input);
			Assert.Equal(expected, actual);
		}
	}

	public class Calc
	{
		public double evaluate(String expr)
		{
			if (string.IsNullOrWhiteSpace(expr)) return 0.0;

			var items = expr.Split();
			var stack = new Stack<double>();

			Func<string, bool> isOperator = text => new[] {"+", "-", "*", "/"}.Contains(text);

			double total = 0;
			foreach (string item in items)
			{
				if (isOperator(item))
				{
					var right = stack.Pop();
					var left = stack.Pop();
					var result = Operate(left, item, right);
					total += result;
					stack.Push(result);
				}
				else
				{
					stack.Push(double.Parse(item));
				}
			}

			return stack.Count > 0 ? stack.Pop() : total;
		}

		private double Operate(double left, string op, double right)
		{
			switch (op)
			{
				case "*": return left * right;
				case "+": return left + right;
				case "-": return left - right;
				case "/": return left / right;
				default: throw new Exception("operator is invalid");
			}
		}
	}
}
