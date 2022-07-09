using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.General.Search
{
	/// <summary>
	/// Text search using KMP (Knuth-Morris-Pratt) Algorithm
	/// </summary>
	/// <remarks>
	/// This version uses algorithm discussed in YouTube video by Tushar Roy
	/// <see cref="https://youtu.be/GTJr8OvyEVQ"/>
	/// </remarks>
	public class KmpSearchYouTube : IKmpSearch
	{
		/// <summary>
		/// Searches the "word" for "searchWord"
		/// </summary>
		/// <returns>Found Indices. If none is found then returns an empty array</returns>
		public int[] Search(string word, string searchWord)
		{
			int[] prefixTable = BuildPrefixTable(searchWord);
			return SearchByKmp(word, searchWord, prefixTable);
		}

		/// <summary>
		/// Search "S" with "W" using index table "T"
		/// </summary>
		/// <param name="S">Text to be search</param>
		/// <param name="W">Word sought</param>
		/// <param name="T">KMP Table</param>
		/// <returns>Found Indices. If none is found then returns an empty array</returns>
		private int[] SearchByKmp(string S, string W, int[] T)
		{
			int i = 0;	// index position for W
			int m = 0;	// index position for S
			List<int> found = new List<int>();

			while (m + i < S.Length)
			{
				if (S[m + i] == W[i])
				{
					i++;
					if (i == W.Length)
					{
						found.Add(m);
						m = m + i - T[i - 1];
						i = T[i - 1];
					}
				}
				else
				{
					if (T[i] == 0)
					{
						m = m + i + 1;
						i = 0;
					}
					else
					{
						m = m + i;
						i = (i - 1) < 0 ? 0 : T[i - 1];
					}
				}
			}

			return found.ToArray();
		}

		/// <summary>
		/// Build Prefix table using Algorithm in YouTube video
		/// https://youtu.be/GTJr8OvyEVQ
		/// </summary>
		/// <remarks>
		/// The result table contains a bit different values compared to using algorithm in Wikipedia.
		/// The result table contains values bigger than 0 while Wikipedia version contains -1 as a starting index.
		/// <see cref="https://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm#Description_of_pseudocode_for_the_table-building_algorithm"/>
		/// </remarks>
		private int[] BuildPrefixTable(string searchWord)
		{
			int j = 0;
			int i = j + 1;
			int[] T = Enumerable.Repeat(0, searchWord.Length).ToArray();
			T[0] = 0;

			while (i < searchWord.Length)
			{
				if (searchWord[i] == searchWord[j])
				{
					T[i] = j + 1;
					j++;
					i++;
				}
				else
				{
					while (j >= 1 && searchWord[j] != searchWord[i])
					{
						j = T[j - 1];
						if (j == 0) break;
					}

					if (searchWord[j] == searchWord[i])
						T[i] = j + 1;

					i++;
				}
			}

			return T;
		}
	}
}