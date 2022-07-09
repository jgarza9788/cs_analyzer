using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Demo.LearnByDoing.General
{
    public class ParsingNumbersPerDigitProgram
    {
        private const int UPTO = 1000000;

        public static void Main(string[] args)
        {
            //int val = 192837465;
            int val = 123456789;

            Stopwatch watch = new Stopwatch();

            watch.Start();
            for (int i = 0; i < UPTO; i++)
            {
                List<int> digits = GetDigits(val);
            }
            watch.Stop();
            Console.WriteLine("GetDigit took {0}ms", watch.ElapsedMilliseconds);

            watch.Start();
            for (int j = 0; j < UPTO; j++)
            {
                List<int> digits2 = GetDigitsUsingConversion(val);
            }
            
            watch.Stop();
            Console.WriteLine("GetDigitsUsingConversion took {0}ms", watch.ElapsedMilliseconds);

            //digits.ForEach(Console.WriteLine);

            Console.ReadKey();
        }

        private static List<int> GetDigitsUsingConversion(int val)
        {
            return val.ToString().ToCharArray().Select(c => (int) c).ToList();
        }

        private static List<int> GetDigits(int val)
        {
            Stack<int> stack = new Stack<int>();

            int number = val;
            while (number > 0)
            {
                var digit = number % 10;
                stack.Push(digit);

                number /= 10;
            }

            return stack.ToList();
        }
    }
}
