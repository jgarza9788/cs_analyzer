using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/coin
	/// </summary>
	public class Question005Test : BaseTest
	{
		public Question005Test(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestSampleData()
		{
			var amount = 4;
			var denominations = new[] {1, 2, 3};

			const int expected = 4;
			var seen = new Dictionary<Tuple<int, int[]>, int>();
			//var actual = ChangePossibilitiesTopDown_Copied(4, denominations, 0, seen);
			var actual = ChangePossibilitiesTopDown2(amount, denominations, 0);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestNoAnswer()
		{
			var amount = 1;
			var denominations = new[] {2, 3};

			const int expected = 0;
			var actual = ChangePossibilitiesTopDown2(amount, denominations, 0);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestSomethingElse()
		{
			var amount = 4;
			var denominations = new[] {1, 2};

			const int expected = 3;
			var actual = ChangePossibilitiesTopDown2(amount, denominations, 0);

			Assert.Equal(expected, actual);
		}

		public int ChangePossibilitiesTopDown2(int amountLeft, int[] denominations, int currentIndex)
		{
			if (amountLeft == 0) return 1;
			if (amountLeft < 0) return 0;
			if (currentIndex == denominations.Length) return 0;

			int possibilityCount = 0;
			int current = denominations[currentIndex];
			while (amountLeft >= 0)
			{
				possibilityCount += ChangePossibilitiesTopDown2(amountLeft, denominations, currentIndex + 1);
				amountLeft -= current;
			}

			return possibilityCount;
		}

		public int ChangePossibilitiesTopDown(int amountLeft, int[] denominations, int currentIndex, Dictionary<Tuple<int, int[]>, int> seen)
		{
			var key = Tuple.Create(amountLeft, denominations);
			if (seen.ContainsKey(key))
			{
				return seen[key];
			}

			if (amountLeft == 0)
			{
				seen.Add(key, 1);
				return 1;
			}
			if (amountLeft < 0)
			{
				seen.Add(key, 0);
				return 0;
			}
			if (currentIndex == denominations.Length) return 0;

			int current = denominations[currentIndex];
			int possibilityCount = 0;

			while (amountLeft >= 0)
			{
				if (seen.ContainsKey(key))
					possibilityCount += seen[key];
				else
					possibilityCount += ChangePossibilitiesTopDown(amountLeft, denominations, currentIndex + 1, seen);


				amountLeft -= current;
			}

			return possibilityCount;
		}

		private static int steps = 0;

		/// <summary>
		/// Copied & pasted...
		/// </summary>
		public int ChangePossibilitiesTopDown_Copied(int amountLeft, int[] denominations, int currentIndex, Dictionary<Tuple<int, int[]>, int> seen)
		{
			var key = Tuple.Create(amountLeft, denominations);
			if (seen.ContainsKey(key))
			{
				_output.WriteLine("Returning cache... on top");
				return seen[key];
			}


			var indent = new string(' ', currentIndex * 4);
			//_output.WriteLine(indent + $"#{steps++} = Currently checking ways to make {amountLeft} with " + $"[{string.Join(", ", denominations.Skip(currentIndex).Take(denominations.Length - currentIndex))}] @ currentIndex: {currentIndex}");
			
			// Base cases:
																																																						// We hit the amount spot on. Yes!
			if (amountLeft == 0)
			{
				_output.WriteLine(indent + $"=====> for ${amountLeft}, currentIndex: {currentIndex}, returning 1: " + $"[{string.Join(", ", denominations.Skip(currentIndex).Take(denominations.Length - currentIndex))}]");
				seen.Add(key, 1);
				return 1;
			}

			// We overshot the amount left (used too many coins)
			if (amountLeft < 0)
			{
				seen.Add(key, 0);
				return 0;
			}

			// We're out of denominations
			if (currentIndex == denominations.Length)
			{
				return 0;
			}

			// Choose a current coin
			int currentCoin = denominations[currentIndex];

			// Print out actual part of array
			_output.WriteLine(indent + $"currentCoin: {currentCoin} for ${amountLeft} with " + $"[{string.Join(", ", denominations.Skip(currentIndex).Take(denominations.Length - currentIndex))}]");

			// See how many possibilities we can get
			// for each number of times to use currentCoin
			int numPossibilities = 0;
			while (amountLeft >= 0)
			{
				if (seen.ContainsKey(key))
				{
					_output.WriteLine("Returning cache... in loop");
					numPossibilities += seen[key];
				}
				else
					numPossibilities += ChangePossibilitiesTopDown_Copied(amountLeft, denominations, currentIndex + 1, seen);

				amountLeft -= currentCoin;
			}

			return numPossibilities;
		}
	}
}
