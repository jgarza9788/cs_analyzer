using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/top-scores
	/// 
	///   You created a game that is more popular than Angry Birds.
	/// 
	/// Each round, players receive a score between 0 and 100, which you use to rank them from highest to lowest. So far you're using an algorithm that sorts in O(nlgn)O(n\lg{n})O(nlgn) time, but players are complaining that their rankings aren't updated fast enough. You need a faster sorting algorithm.
	/// 
	/// Write a method that takes:
	/// 
	/// an array of unsortedScores
	/// the highestPossibleScore in the game
	/// 
	/// and returns a sorted array of scores in less than O(nlgn)O(n\lg{n})O(nlgn) time.
	/// 
	/// For example:
	/// 
	/// int[] unsortedScores = new[] { 37, 89, 41, 65, 91, 53 };
	/// const int HighestPossibleScore = 100;
	/// 
	/// // sortedScores: [91, 89, 65, 53, 41, 37]
	/// int[] sortedScores = SortScores(unsortedScores, HighestPossibleScore);
	/// 
	/// We’re defining nnn as the number of unsortedScores because we’re expecting the number of players to keep climbing.
	/// 
	/// And we'll treat highestPossibleScore as a constant instead of factoring it into our big O time and space costs, because the highest possible score isn’t going to change. Even if we do redesign the game a little, the scores will stay around the same order of magnitude. 
	/// </summary>
	public class Question032Test
	{
		[Fact]
		public void TestSampleCase()
		{
			int[] unsortedScores = { 37, 89, 41, 65, 91, 53 };
			const int highestPossibleScore = 100;

			// sortedScores: [91, 89, 65, 53, 41, 37]
			int[] actual = SortScores2(unsortedScores, highestPossibleScore);
			int[] expected = { 91, 89, 65, 53, 41, 37 };

			Assert.True(expected.SequenceEqual(actual));
		}

		[Fact]
		public void TestDuplicateValueCase()
		{
			int[] unsortedScores = { 37, 89, 41, 65, 91, 53, 91, 89 };
			const int highestPossibleScore = 100;

			int[] actual = SortScores2(unsortedScores, highestPossibleScore);
			int[] expected = { 91, 91, 89, 89, 65, 53, 41, 37 };

			Assert.True(expected.SequenceEqual(actual));
		}

		private int[] SortScores2(int[] unsortedScores, int highestPossibleScore)
		{
			// Create an array with length of "highestPossibleScore"
			int[] scores = new int[highestPossibleScore + 1];

			// Iterate "unsortedScores" and use score as the index and value as the count.
			foreach (int score in unsortedScores)
			{
				if (scores[score] == default)
					scores[score] = 0;
				scores[score]++;
			}

			// Iterate "complements" backwards.
			var result = new List<int>(unsortedScores.Length);
			for (int i = highestPossibleScore; i >= 0 ; i--)
			{
				var score = i;
				var count = scores[score];
				if (count != default)
				{
					for (int j = 0; j < count; j++)
					{
						result.Add(score);
					}
				}
			}

			return result.ToArray();
		}

		private int[] SortScores(int[] unsortedScores, int highestPossibleScore)
		{
			// Create an array with length of "highestPossibleScore"
			int[] complements = new int[highestPossibleScore + 1];

			// Iterate "unsortedScores" and store in "complements" array the score 
			// in the index of "highestPossibleScore - unsortedScores[currentIndex]"
			foreach (var score in unsortedScores)
			{
				int index = highestPossibleScore - score;
				complements[index] = score;
			}

			// Iterate the "complements" where the value is not null and save it to the list.
			var result = new List<int>(unsortedScores.Length);
			foreach (int score in complements)
			{
				if (score != default)
					result.Add(score);
			}

			return result.ToArray();
		}
	}
}
