using System;
using System.Linq;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    public class Chapter1_2
    {
        public bool AreStringsPermutationalUsingLinq(string text1, string text2)
        {
            if (text1.Length != text2.Length) return false;

            // Use "Join" to get a list of common elements between two lists.
            // If two texts have the same characters, then the join count and the text will be the same.
            var items = from first in text1.ToCharArray().ToList()
                join second in text2.ToCharArray().ToList()
                on first equals second
                select first;

            return items.Count() == text1.Length;
        }

        public bool AreStringsPermutational(string text1, string text2)
        {
            if (text1.Length != text2.Length) return false;

            string sortedText1 = SortAlphabetically(text1);
            string sortedText2 = SortAlphabetically(text2);

            return sortedText1 == sortedText2;
        }

        private string SortAlphabetically(string text)
        {
            var charArray = text.ToCharArray();
            Array.Sort(charArray);

            return new string(charArray);
        }
    }
}