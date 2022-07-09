using System;
using Demo.LearnByDoing.General.Graph;

namespace Demo.LearnByDoing.General
{
    /// <summary>
    /// Cracking the Coding Interview Question 4.2
    /// </summary>
    public class MinimalTreeGenerationProgram
    {
        public static void Main(string[] args)
        {
            int[] a = {1, 2, 3, 4, 5, 6, 7, 8};
            Node node = CreateMinimalTreeBst(a);
            Console.WriteLine(node);
        }

        private static Node CreateMinimalTreeBst(int[] a)
        {
            return CreateMinimalTreeBst(a, 0, a.Length - 1);
        }

        private static Node CreateMinimalTreeBst(int[] a, int start, int end)
        {
            if (end < start) return null;

            int mid = (start + end) / 2;
            Node node = new Node
            {
                Value = a[mid],
                Left = CreateMinimalTreeBst(a, start, mid - 1),
                Right = CreateMinimalTreeBst(a, mid + 1, end)
            };

            return node;
        }
    }
}
