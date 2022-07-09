using System;

namespace Demo.LearnByDoing.General.LinkedList
{
    /// <summary>
    /// Print elements of a linked list in forward and reverse order using recursion
    /// https://youtu.be/K7J3nCeRC80?list=PL2_aWCzGMAwLPEZrZIcNEq9ukGWPfLT4A
    /// </summary>
    public class PrintForwardBackwardUsingRecursion
    {
        public static void Main(string[] args)
        {
            var root = GetNodes();

            PrintForwardUsingRecursion(root);
            Console.WriteLine();

            PrintBackwardUsingRecursion(root);
            Console.WriteLine();
        }

        private static void PrintBackwardUsingRecursion(Node<int> root)
        {
            if (root == null) return;

            PrintBackwardUsingRecursion(root.Next);
            Console.Write("{0} ", root.Value);
        }

        private static void PrintForwardUsingRecursion(Node<int> root)
        {
            if (root == null) return;

            Console.Write("{0} ", root.Value);
            PrintForwardUsingRecursion(root.Next);
        }

        private static Node<int> GetNodes()
        {
            Node<int> root = new Node<int>(1, null);
            Node<int> head = root;

            root.Next = new Node<int>(2, null);
            root = root.Next;
            root.Next = new Node<int>(3, null);
            root = root.Next;
            root.Next = new Node<int>(4, null);
            root = root.Next;
            root.Next = new Node<int>(5, null);

            return head;
        }
    }
}
