using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeSignal.Arrays
{
	/// <summary>
	/// https://codefights.com/interview-practice/task/uX5iLwhc6L5ckSyNC
	/// </summary>
	public class FirstNotRepeatingCharacterTest
	{
		char firstNotRepeatingCharacter(string s)
		{
			var map = Enumerable.Range('a', 'z' - 'a' + 1).ToDictionary(n => (char) n, n => -1);
			for (int i = 0; i < s.Length; i++)
			{
				char c = s[i];
				if (map[c] >= 0) map[c] = int.MinValue;
				else if (map[c] < 0 && map[c] != int.MinValue) map[c] = i;
			}

			var hasUnique = map.Any(pair => pair.Value >= 0 && pair.Value != int.MinValue);
			if (hasUnique)
			{
				var minIndex = map.Where(pair => pair.Value >= 0 && pair.Value != int.MinValue).Min(pair => pair.Value);
				return map.FirstOrDefault(pair => pair.Value == minIndex).Key;
			}
			return '_';
		}

		[Theory]
		[InlineData('c', "bcb")]
		[InlineData('c', "bbcdda")]
		[InlineData('c', "abacabad")]
		[InlineData('_', "abacabaabacaba")]
		[InlineData('d', "abcdefghijklmnopqrstuvwxyziflskecznslkjfabe")]
		[InlineData('_', "zzz")]
		[InlineData('d', "xdnxxlvupzuwgigeqjggosgljuhliybkjpibyatofcjbfxwtalc")]
		[InlineData('g', "ngrhhqbhnsipkcoqjyviikvxbxyphsnjpdxkhtadltsuxbfbrkof")]
		[InlineData('z', "z")]
		[InlineData('_', "bcccccccb")]
		[InlineData('y', "bcccccccccccccyb")]
		public void SampleTests(char expected, string input)
		{
			char actual = firstNotRepeatingCharacter(input);
			Assert.Equal(expected, actual);
		}
	}
}
