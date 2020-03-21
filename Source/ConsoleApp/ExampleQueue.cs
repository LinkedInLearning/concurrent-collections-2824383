using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp {
	class ExampleQueue<T> {

		private T[] _array;
		private int _head;       // First valid element in the queue
		private int _tail;       // Last valid element in the queue
		private int _size;       // Number of elements.
		private int _version;

		private const int _MinimumGrow = 4;
		private const int _ShrinkThreshold = 32;
		private const int _GrowFactor = 200;  // double each time
		private const int _DefaultCapacity = 4;
		static T[] _emptyArray = new T[0];
		public ExampleQueue() {
			_array = _emptyArray;
		}

		public void Enqueue(T item) {
			if (_size == _array.Length)
			{
				int newcapacity = (int)((long)_array.Length * (long)_GrowFactor / 100);
				if (newcapacity < _array.Length + _MinimumGrow)
				{
					newcapacity = _array.Length + _MinimumGrow;
				}
				SetCapacity(newcapacity);
			}

			_array[_tail] = item;
			_tail = (_tail + 1) % _array.Length;
			_size++;
			_version++;
		}

		public T Dequeue() {
			if (_size == 0)
				throw new Exception("No more items in the Queue");

			T removed = _array[_head];
			_array[_head] = default(T);
			_head = (_head + 1) % _array.Length;
			_size--;
			_version++;
			return removed;
		}

		// PRIVATE Grows or shrinks the buffer to hold capacity objects. Capacity
		// must be >= _size.
		private void SetCapacity(int capacity) {
			T[] newarray = new T[capacity];
			if (_size > 0)
			{
				if (_head < _tail)
				{
					Array.Copy(_array, _head, newarray, 0, _size);
				}
				else
				{
					Array.Copy(_array, _head, newarray, 0, _array.Length - _head);
					Array.Copy(_array, 0, newarray, _array.Length - _head, _tail);
				}
			}

			_array = newarray;
			_head = 0;
			_tail = (_size == capacity) ? 0 : _size;
			_version++;
		}
	}
}
