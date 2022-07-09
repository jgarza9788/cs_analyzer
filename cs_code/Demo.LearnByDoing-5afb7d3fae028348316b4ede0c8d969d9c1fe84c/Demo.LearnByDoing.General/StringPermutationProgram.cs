using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Demo.LearnByDoing.General
{
    /// <summary>
    /// Code based on http://www.geeksforgeeks.org/write-a-c-program-to-print-all-permutations-of-a-given-string/
    /// Youtube: https://www.youtube.com/watch?v=AfxHGNRtFac
    /// </summary>
    public class StringPermutationProgram
    {
        public static void Main(string[] args)
        {
            string value = "ABCD";
            //Permute(value, 0, value.Length - 1);

            List<string> permutations = GetPermutations(value);
            foreach (var permutation in permutations)
            {
                Console.WriteLine(permutation);
            }
        }

        /// <summary>
        /// Get permutation using algorithm used in Cracking the Coding Interview 8.7
        /// </summary>
        private static List<string> GetPermutations(string value)
        {
            List<string> result = new List<string>();
            GetPermutations("", value, result);
            return result;
        }

        private static void GetPermutations(string prefix, string remainder, List<string> result)
        {
            if (remainder.Length == 0) result.Add(prefix);

            int len = remainder.Length;
            for (int i = 0; i < len; i++)
            {
                var before = remainder.Substring(0, i);
                var after = remainder.Substring(i + 1);
                char c = remainder[i];
                GetPermutations(prefix + c, before + after, result);
            }
        }

        private static void Permute(string value, int left, int right)
        {
            if (left == right)
            {
                Console.WriteLine(value);
                return;
            }

            for (int i = left; i <= right; i++)
            {
                Swap(ref value, left, i);
                Permute(value, left + 1, right);
                Swap(ref value, left, i);   // back tracking: set the value to original value
            }
        }

        private static void Swap(ref string value, int i, int j)
        {
            var a = value.ToCharArray();
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
            value = new string(a);
        }
    }
}
