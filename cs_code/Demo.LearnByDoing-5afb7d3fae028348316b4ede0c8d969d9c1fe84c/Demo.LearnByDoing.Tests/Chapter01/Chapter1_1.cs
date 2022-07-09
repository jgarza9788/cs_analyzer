using System.Collections.Generic;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    public class Chapter1_1
    {
        public bool HasUniqueCharacters(string text)
        {
            var lookup = new HashSet<char>();
            foreach (char c in text)
            {
                if (!lookup.Contains(c))
                    lookup.Add(c);
            }
            return lookup.Count == text.Length;
        }
    }
}