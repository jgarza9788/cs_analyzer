using System;
using System.Diagnostics;
using System.Linq;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    public class Chapter1_4
    {
        /// <summary>
        /// Check if the text can have a palindrome sequence.
        /// </summary>
        public bool HasPalindrome(string text)
        {
            if (text.Length == 1) return true;
            if (text.Length == 2 && text[0] == text[1]) return true;

            // It's palindrome if there exists
            // 1.) even number of characters for each character
            // 2.) even number of characters except for one character.

            // Test 1. even number of characters for each character
            var grouped = text
                .ToLower()
                .ToCharArray()
                .Where(IsNotSpace)
                .GroupBy(c => c)
                .Select(group => new 
                {
                    Character = group.Key,
                    Count = group.Count()
                })
                .ToList();

            Func<int, bool> isOdd = number => number % 2 == 1;

            var totalOddCount = grouped.Count(group => isOdd(group.Count));
            switch (totalOddCount)
            {
                case 0:
                case 1:
                    return true;
                default:
                    Debug.Assert(totalOddCount > 1);
                    return false;
            }
        }

        public bool IsPalindrome(string text)
        {
            // By definition, if one letter is a palindrome
            if (text.Length == 1) return true;

            string reverseWithoutSpace = new string(text.Where(IsNotSpace).Reverse().ToArray()).ToLower();
            string textWithoutSpace = new string(text.Where(IsNotSpace).ToArray()).ToLower();

            return textWithoutSpace == reverseWithoutSpace;
        }

        private bool IsNotSpace(char c)
        {
            return c != ' ';
        }
    }
}