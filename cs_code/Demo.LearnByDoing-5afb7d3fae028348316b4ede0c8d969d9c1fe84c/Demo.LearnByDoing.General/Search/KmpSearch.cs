using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.General.Search
{
	/// <summary>
	/// Knuth–Morris–Pratt (KMP) string searching algorithm Using Wikipedia Algorithm.
	/// </summary>
	/// <see cref="https://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm"/>
	public class KmpSearch
	{
		public bool SearchUsingKmp(string word, string searchWord)
		{
			int[] prefixTable = BuildPrefixTable(searchWord);
			int[] foundIndices = SearchByKmp(word, searchWord, prefixTable);

			if (foundIndices.Any(a => a == -1) || foundIndices.Length == 0)
				return false;
			return true;
		}

		private int[] SearchByKmp(string S, string W, int[] T)
		{
			List<int> foundIndices = new List<int>();

			// the beginning of the current match in S.
			int m = 0;
			// the position of the current character in W.
			int i = 0;

			while (m + i < S.Length)
			{
				if (W[i] == S[m + i])
				{
					if (i + 1 == W.Length)
					{
						//return m;	// or store/user occurrence.
						foundIndices.Add(m);
						//if (i >= T.Length) break;

						m = m + i - T[i];
						// preparing for search next occurence, T[w.length] can't be -1)
						i = T[i];
					}
					i++;
				}
				else
				{
					if (T[i] > -1)
					{
						m = m + i - T[i];
						i = T[i];
					}
					else
					{
						m = m + i + 1;
						i = 0;
					}
				}
			}

			return foundIndices.ToArray();
		}

		/// <summary>
		/// https://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm
		/// </summary>
		private int[] BuildPrefixTable(string word)
		{
			int[] T = Enumerable.Repeat(0, word.Length).ToArray();
			// the current position we are computing in T.
			int pos = 1;
			// the zero-based index in search word of the next character of the current candidate substring.
			int cnd = 0;

			T[0] = -1;

			while (pos < word.Length)
			{
				if (word[pos] == word[cnd])
				{
					T[pos] = T[cnd];
					pos++;
					cnd++;
				}
				else
				{
					T[pos] = cnd;
					// to increase performance.
					cnd = T[cnd];

					while (cnd >= 0 && word[pos] != word[cnd])
					{
						cnd = T[cnd];
					}

					pos++;
					cnd++;
				}
			}

			return T;
		}
	}
}