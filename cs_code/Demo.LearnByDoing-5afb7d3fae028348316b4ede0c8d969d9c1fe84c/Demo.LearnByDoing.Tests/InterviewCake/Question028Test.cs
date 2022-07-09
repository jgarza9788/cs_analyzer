using System;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/matching-parens
	/// 
	/// I like parentheticals(a lot).
	/// "Sometimes (when I nest them (my parentheticals) too much (like this (and this))) they get confusing."
	/// Write a method that, given a sentence like the one above, along with the position of an opening parenthesis, finds the corresponding closing parenthesis.
	/// Example: if the example string above is input with the number 10 (position of the first parenthesis), the output should be 79 (position of the last parenthesis).
	/// </summary>
	public class Question028Test
	{
		[Fact]
		public void TestSampleCase()
		{
			var sentence = "Sometimes (when I nest them (my parentheticals) too much (like this (and this))) they get confusing.";
			var sut = new Question028();

			var position1 = 10;
			var expected1 = 79;
			var actual1 = sut.GetMatchingIndex(sentence, position1);
			Assert.Equal(expected1, actual1);

			var position2 = 28;
			var expected2 = 46;
			var actual2 = sut.GetMatchingIndex(sentence, position2);
			Assert.Equal(expected2, actual2);

			var position3 = 57;
			var expected3 = 78;
			var actual3 = sut.GetMatchingIndex(sentence, position3);
			Assert.Equal(expected3, actual3);

			var position4 = 68;
			var expected4 = 77;
			var actual4 = sut.GetMatchingIndex(sentence, position4);
			Assert.Equal(expected4, actual4);
		}

		class Question028
		{
			public int GetMatchingIndex(string sentence, int position)
			{
				// if next char after position is ( then increase counter.
				// else if next char after position is ) 
				//		if counter <= 0 then return that position.
				//		else counter--
				// else throw an exception

				int counter = 0;
				for (int i = position + 1; i < sentence.Length; i++)
				{
					char c = sentence[i];

					if (c == '(') counter++;
					else if (c == ')')
					{
						if (counter <= 0) return i;
						counter--;
					}
				}

				throw new InvalidOperationException();
			}
		}
	}
}
