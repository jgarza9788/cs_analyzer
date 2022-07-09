using System;
using System.Linq;

namespace Demo.LearnByDoing.General
{
    /// <summary>
    /// Find if all elements from an array of strings exists in another array of strings
    /// </summary>
    public class FindAllArrayElementsExistInAnotherArrayProgram
    {
        public static void Main(string[] args)
        {
            int[] a1 = {1, 2, 3};
            int[] a2 = {1, 2, 3, 4, 5, 6};
            int[] a3 = {2, 20, 200};

            bool hasAll1 = CheckIfAllElementsExistInAnotherArray(a1, a2);
            Console.WriteLine(hasAll1);

            bool hasAll2 = CheckIfAllElementsExistInAnotherArray(a3, a2);
            Console.WriteLine(hasAll2);
        }

        private static bool CheckIfAllElementsExistInAnotherArray(int[] subA, int[] fullA)
        {
            var intersect = fullA.Intersect(subA);
            return intersect.Count() == subA.Length;
        }
    }
}
