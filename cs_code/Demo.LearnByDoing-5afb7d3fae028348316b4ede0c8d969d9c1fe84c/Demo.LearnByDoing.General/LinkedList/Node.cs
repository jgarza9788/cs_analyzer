using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.General.LinkedList
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value, Node<T> next)
        {
            Value = value;
            Next = next;
        }

        public override string ToString()
        {
            List<Node<T>> nodes = new List<Node<T>>();
            Node<T> head = this;

            if (head.Next == null)
                return head.Value.ToString();

            while (head != null)
            {
                nodes.Add(head);
                head = head.Next;
            }

            return string.Join("->", nodes.Select(val => val.Value.ToString()));
        }
    }
}
