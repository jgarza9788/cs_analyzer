using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/word-cloud
	/// 
	/// 
	/// 
	/// You want to build a word cloud, an infographic where the size of a word corresponds to how often it appears in the body of text.
	/// 
	/// To do this, you'll need data. Write code that takes a long string and builds its word cloud data in a dictionary ↴ , where the keys are words and the values are the number of times the words occurred.
	/// 
	/// Think about capitalized words. For example, look at these sentences:
	/// 
	/// "After beating the eggs, Dana read the next step:"
	/// "Add milk and eggs, then add flour and sugar."
	/// 
	/// What do we want to do with "After", "Dana", and "add"? In this example, your final dictionary should include one "Add" or "add" with a value of 222. Make reasonable (not necessarily perfect) decisions about cases like "After" and "Dana".
	/// 
	/// Assume the input will only contain words and standard punctuation.
	/// 
	/// You could make a reasonable argument to use regex in your solution. We won't, mainly because performance is difficult to measure and can get pretty bad.
	/// </summary>
	public class Question034Test
	{
		[Fact]
		public void TestSample()
		{
			var input = "After beating the eggs, Dana read the next step:Add milk and eggs, then add flour and sugar.";
			Dictionary<string, int> expected = new Dictionary<string, int>
			{
				{"after", 1}, {"beating", 1}, {"the", 2},
				{"eggs", 2}, {"dana", 1}, {"read", 1},
				{"next", 1}, {"step", 1}, {"add", 2},
				{"milk", 1}, {"and", 2}, {"then", 1},
				{"flour", 1}, {"sugar", 1}
			};

			Dictionary<string, int> actual = BuildWordCloud(input);
			Assert.True(expected.OrderBy(pair => pair.Key).SequenceEqual(actual.OrderBy(pair => pair.Key)));

			Dictionary<string, int> actual2 = BuildWordCloud2(input);
			Assert.True(expected.OrderBy(pair => pair.Key).SequenceEqual(actual2.OrderBy(pair => pair.Key)));
		}

		private Dictionary<string, int> BuildWordCloud2(string input)
		{
			const string separators = " ,.:";
			return input
				.Split(separators.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
				.GroupBy(word => word.ToLower())
				.ToDictionary(g => g.Key, g => g.Count());
		}

		private Dictionary<string, int> BuildWordCloud(string input)
		{
			const string separators = " ,.:";
			var words = input.Split(separators.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

			Dictionary<string, int> result = new Dictionary<string, int>();
			foreach (string word in words)
			{
				var key = word.ToLower();
				if (!result.ContainsKey(key))
					result.Add(key, 0);
				result[key]++;
			}

			return result;
		}
	}
}
