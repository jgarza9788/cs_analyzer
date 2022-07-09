using System.Collections.Generic;

namespace Demo.LearnByDoing.Tests.Chapter04
{
    public class Node<T>
    {
        public T Name { get; set; }
        public List<Node<T>> Children { get; set; } = new List<Node<T>>();

        /// <summary>
        /// Used for DFS (Depth-First Search)
        /// </summary>
        public bool IsVisited { get; set; } = false;

        /// <summary>
        /// Used for BFS (Breadth-First Search)
        /// </summary>
        public bool IsMarked { get; set; } = false;

        public Node(T name)
        {
            Name = name;
        }
    }
}