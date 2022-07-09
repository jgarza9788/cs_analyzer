using System.Collections.Generic;

namespace Demo.LearnByDoing.Tests.Chapter04
{
    public class Graph<T>
    {
        public List<Node<T>> Nodes { get; set; } = new List<Node<T>>();
    }
}