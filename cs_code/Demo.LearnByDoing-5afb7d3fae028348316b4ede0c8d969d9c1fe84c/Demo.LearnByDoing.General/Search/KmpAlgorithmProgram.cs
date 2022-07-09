using System;
using System.Linq;

namespace Demo.LearnByDoing.General.Search
{
	public class KmpAlgorithmProgram
	{
		public static void Main(string[] args)
		{
			string word = "abxabcabcabyabcaby";
			string searchWord = "abcaby";
			//searchWord = "abcdabca";
			//searchWord = "acacabacacabacacac";
			//searchWord = "abxc";
			//searchWord = "abcdabd";

			//KmpSearch kmpSearch = new KmpSearch();
			KmpSearchYouTube kmpSearchYouTube = new KmpSearchYouTube();

			word = "abcabcabc";

			word = "abxabxabxabx";
			word = "cxabcabcxabc";
			word = "cxabcabcabcxabcabc";

			searchWord = "abcabc";

			//bool isFound = kmpSearch.SearchUsingKmp(word, searchWord);
			var foundIndices = kmpSearchYouTube.Search(word, searchWord);
			bool isFound = !(foundIndices.Any(a => a == -1) || foundIndices.Length == 0);


			Console.WriteLine($"{searchWord} is found within {word}? {isFound}");
		}
	}
}
