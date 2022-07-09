using System;

namespace Demo.LearnByDoing.General.LinkedList
{
    /// <summary>
    /// Reverse a linked list - Iterative method
    /// https://youtu.be/sYcOK51hl-A?list=PL2_aWCzGMAwLPEZrZIcNEq9ukGWPfLT4A
    /// </summary>
    public class ReverseLinkedListIteratively
    {
        public static void Main(string[] args)
        {
            var root = GetNodes();
            Print(root);
            Console.WriteLine();

            var reversed = ReverseIteratively(root);
            Print(reversed);
        }

        private static Node<int> ReverseIteratively(Node<int> root)
        {
            var current = root;
            Node<int> prev = null;

            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            return prev;
        }

        private static void Print(Node<int> root)
        {
            if (root == null) return;

            Console.Write("{0} ", root.Value);
            Print(root.Next);
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
