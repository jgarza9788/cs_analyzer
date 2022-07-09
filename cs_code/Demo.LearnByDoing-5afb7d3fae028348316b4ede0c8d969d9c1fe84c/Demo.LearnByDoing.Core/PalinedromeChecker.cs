namespace Demo.LearnByDoing.Core
{
	public class PalinedromeChecker
	{
		public bool IsPalindrome(string word)
		{
			if (word.Length == 1) return true;
			if (string.IsNullOrEmpty(word)) return false;

			int start = 0;
			int end = word.Length - 1;
			int mid = end / 2;

			for (int i = start; i <= mid; i++)
			{
				if (word[start] != word[end]) return false;

				start++;
				end--;
			}

			return true;
		}
	}
}