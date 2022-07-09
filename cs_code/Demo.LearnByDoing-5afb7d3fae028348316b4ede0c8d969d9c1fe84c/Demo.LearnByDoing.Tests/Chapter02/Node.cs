namespace Demo.LearnByDoing.Tests.Chapter02
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T data)
        {
            Data = data;
        }

        public void AddLast<T>(T data)
        {
            Node<T> currentNode = this as Node<T>;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            Node<T> newNode = new Node<T>(data);
            currentNode.Next = newNode;
        }

        public override string ToString()
        {
            var head = this;
            string result = "Start";
            while (head != null)
            {
                result += " -> " + head.Data;

                head = head.Next;
            }

            return result;
        }

        /// <summary>
        /// Get Node's length
        /// </summary>
        /// <remarks>
        /// Copied from Chapter2_5
        /// </remarks>
        public int GetLength()
        {
            Node<T> copy = this;
            int count = 0;

            while (copy != null)
            {
                count++;
                copy = copy.Next;
            }

            return count;
        }
    }
}