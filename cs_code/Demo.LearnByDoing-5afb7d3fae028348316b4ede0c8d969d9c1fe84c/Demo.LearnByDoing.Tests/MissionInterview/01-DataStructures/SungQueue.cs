using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.Tests.MissionInterview._01_DataStructures
{
	public class SungQueue<T>
	{
		private int _count = 0;
		private readonly DoublySungLinkedList<T> _list = new DoublySungLinkedList<T>();

		public void Enqueue(T value)
		{
			_count++;
			_list.Append(value);
		}

		public IEnumerable<T> Traverse()
		{
			return _list.Traverse().Select(a => a.Value);
		}

		public T Dequeue()
		{
			if (_count == 0)
				throw new InvalidOperationException("Queue empty.");

			_count--;
			var result = _list.Head;
			_list.Remove(_list.Head);
			return result.Value;
		}

		public T Peek()
		{
			return _list.Head == null ? default(T) : _list.Head.Value;
		}
	}
}