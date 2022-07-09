using System.Collections.Generic;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    /// <summary>
    /// http://stackoverflow.com/a/414638/4035
    /// </summary>
    public class LinkedListWithInit<T> : LinkedList<T>
    {
        public void Add(T item)
        {
            ((ICollection<T>)this).Add(item);
        }
    }
}