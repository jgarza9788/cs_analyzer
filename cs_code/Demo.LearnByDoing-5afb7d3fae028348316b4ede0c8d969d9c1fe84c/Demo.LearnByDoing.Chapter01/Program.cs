using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.LearnByDoing.Chapter01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Answer1_1();
            Answer1_2();

            Console.WriteLine("Press ENTER to continue...");
            Console.Read();
        }

        /// <summary>
        /// 1.2 Given two strings, write a method to decide if one is a permutation of the other.
        /// </summary>
        private static void Answer1_2()
        {
            
        }

        /// <summary>
        /// 1.1 Implement an algorithm to determine if a string has all unique characters.
        /// What if you cannot use additional data structures?
        /// </summary>
        private static void Answer1_1()
        {
            string[] texts = {"abc", "aabc", "xyz", "helloworld"};
            foreach (string text in texts)
            {
                bool hasUniqueCharacters = HasUniqueCharacters(text);
                Console.WriteLine("{0} hasUniqueCharacters {1}", text, hasUniqueCharacters);
            }
        }

        private static bool HasUniqueCharacters(string text)
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
