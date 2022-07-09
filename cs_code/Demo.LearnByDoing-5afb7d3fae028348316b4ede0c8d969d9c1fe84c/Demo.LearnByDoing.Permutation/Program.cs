using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.Permutation
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "abcd";
            //Permutation(input);

            //Console.WriteLine("++++++++++");

            IEnumerable<string> permutations = GetPermutations(input).ToList();
            foreach (var permutation in permutations)
            {
                Console.WriteLine(permutation);
            }
        }

        private static IEnumerable<string> GetPermutations(string str)
        {
            return GetPermutations(str, "");
        }

        private static IEnumerable<string> GetPermutations(string str, string prefix)
        {
            var indent = new string('\t', prefix.Length);
            Console.WriteLine("{0}prefix:str => '{1}':'{2}'", indent, prefix, str);

            if (str.Length == 0)
            {
                Console.WriteLine("{0}==========>   str.Length == 0: prefix: '{1}'", indent, prefix);
                yield return prefix;
            }

            for (int i = 0; i < str.Length; i++)
            {
                string remainder = str.Substring(0, i) + str.Substring(i + 1);
                Console.WriteLine("{0}'{1}' => prefix:str:remainder: '{2}':'{3}':'{4}'", indent, i, prefix, str, remainder);

                var nextPrefix = prefix + str[i];
                Console.WriteLine("{0}next prefix: prefix + str[{1}] '{2}' + '{3}' = '{4}'", indent, i, prefix, str[i], nextPrefix);
                foreach (var permutation in GetPermutations(remainder, nextPrefix).ToList())
                {
                    yield return permutation;
                }
            }
        }

        private static void Permutation(string str, string prefix = "")
        {
            if (str.Length == 0)
            {
                Console.WriteLine(prefix);
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    string remainder = str.Substring(0, i) + str.Substring(i + 1);
                    Permutation(remainder, prefix + str[i]);
                }
            }
        }
    }
}
