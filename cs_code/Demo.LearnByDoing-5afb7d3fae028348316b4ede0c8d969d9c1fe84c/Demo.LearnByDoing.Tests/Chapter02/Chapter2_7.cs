namespace Demo.LearnByDoing.Tests.Chapter02
{
    public class Chapter2_7
    {
        public bool AreNodesIntersecting(Node<int> node1, Node<int> node2)
        {
            if (node1 == node2) return true;

            return AreIntersecting(node1, node2).AreIntersecting;
        }

        private NodeResult<int> AreIntersecting(Node<int> node1, Node<int> node2)
        {
            if (node1 == node2) return new NodeResult<int>(node1, node2, true);
            if (node1.Next != null && node2.Next == null) return new NodeResult<int>(node1, node2, false);
            if (node1.Next == null && node2.Next != null) return new NodeResult<int>(node1, node2, false);

            var areIntersecting = AreIntersecting(node1, node2.Next).AreIntersecting ||
                                  AreIntersecting(node1.Next, node2).AreIntersecting;
            return new NodeResult<int>(node1, node2, areIntersecting);
        }
    }

    internal class NodeResult<T>
    {
        public Node<T> Node1 { get; set; }
        public Node<T> Node2 { get; set; }
        public bool AreIntersecting { get; set; }

        public NodeResult(Node<T> node1, Node<T> node2, bool areIntersecting)
        {
            Node1 = node1;
            Node2 = node2;
            AreIntersecting = areIntersecting;
        }
    }
}