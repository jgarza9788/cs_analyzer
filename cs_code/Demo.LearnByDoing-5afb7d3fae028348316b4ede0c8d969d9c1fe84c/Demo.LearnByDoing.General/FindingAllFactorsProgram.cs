using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.General
{
    /// <summary>
    /// Finding all factors of a number using algorithm on
    /// https://youtu.be/dolcMgiJ7I0?list=PL2_aWCzGMAwLL-mEB4ef20f3iqWMGWa25
    /// </summary>
    public class FindingAllFactorsProgram
    {
        public static void Main(string[] args)
        {
            int[] numbers = {12, 17, 36};
            foreach (int number in numbers)
            {
                List<int> factors = GetFactors(number).ToList();
                factors.Sort();
                string factorsText = string.Join(", ", factors.Select(n => n.ToString()));
                Console.WriteLine("{0} => {1}", number, factorsText);
            }
        }

        private static IEnumerable<int> GetFactors(int number)
        {
            int upto = (int) Math.Sqrt(number);
            for (int i = 1; i <= upto; i++)
            {
                if (number % i == 0)
                {
                    yield return i;
                    if (i != upto)
                        yield return number / i;
                }
            }
        }
    }
}
