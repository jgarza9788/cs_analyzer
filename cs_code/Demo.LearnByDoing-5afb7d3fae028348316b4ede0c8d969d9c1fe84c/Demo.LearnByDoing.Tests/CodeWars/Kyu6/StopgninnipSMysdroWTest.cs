using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/stop-gninnips-my-sdrow/train/csharp
	/// </summary>
	public class StopgninnipSMysdroWTest : BaseTest
	{
		public StopgninnipSMysdroWTest(ITestOutputHelper output) : base(output)
		{
		}

		public static void Test1()
		{
			Assert.Equal("emocleW", Kata.SpinWords("Welcome"));
		}

		[Fact]
		public static void Test2()
		{
			Assert.Equal("Hey wollef sroirraw", Kata.SpinWords("Hey fellow warriors"));
		}

		[Fact]
		public static void Test3()
		{
			Assert.Equal("This is a test", Kata.SpinWords("This is a test"));
		}

		[Fact]
		public static void Test4()
		{
			Assert.Equal("This is rehtona test", Kata.SpinWords("This is another test"));
		}

		[Fact]
		public static void Test5()
		{
			Assert.Equal("You are tsomla to the last test", Kata.SpinWords("You are almost to the last test"));
		}

		[Fact]
		public static void Test6()
		{
			Assert.Equal("Just gniddik ereht is llits one more", Kata.SpinWords("Just kidding there is still one more"));
		}
	}

	public partial class Kata
	{
		public static string SpinWords(string sentence)
		{
			var splitWords = sentence.Split();
			var words = new List<string>(splitWords.Length);

			foreach (string word in splitWords)
			{
				var newWord = word;
				if (word.Length >= 5)
					newWord = new string(word.Reverse().ToArray());

				words.Add(newWord);
			}

			return string.Join(" ", words);
		}
	}
}
