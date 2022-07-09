using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.LearnByDoing.General
{
    /// <summary>
    /// "Prime factorization of a number"
    /// https://youtu.be/6PDtgHhpCHo?list=PL2_aWCzGMAwLL-mEB4ef20f3iqWMGWa25
    /// </summary>
    public class PrimeFactorizationProgram
    {
        public static void Main(string[] args)
        {
            int[] numbers = {36, 44, 196, 2838, 100000};
            foreach (int number in numbers)
            {
                List<int> primeFactors = GetPrimeFactors(number).ToList();
                primeFactors.Sort();
                string factorsText = string.Join(", ", primeFactors.Select(n => n.ToString()));
                Console.WriteLine("{0} => {1}", number, factorsText);
            }

        }

        private static IEnumerable<int> GetPrimeFactors(int number)
        {
            int upto = (int) Math.Sqrt(number);
            for (int i = 2; i < upto; i++)
            {
                if (number % i == 0)
                {
                    while (number % i == 0)
                    {
                        yield return i;
                        number /= i;
                    }
                }
            }

            if (number != 1)
                yield return number;
        }
    }
}
