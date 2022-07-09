namespace Demo.LearnByDoing.General.Search
{
	public interface IKmpSearch
	{
		/// <summary>
		/// Search the "searchWord" in "word".
		/// </summary>
		/// <param name="word">Text to be search</param>
		/// <param name="searchWord">Word sought</param>
		/// <returns>Found Indices. If none is found then returns an empty array</returns>
		int[] Search(string word, string searchWord);
	}
}