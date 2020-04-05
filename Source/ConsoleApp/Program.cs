using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
	internal class Program
	{
		private static BlockingCollection<int> _numbers;

		private static void Main(string[] args)
		{
			try
			{
				Demo();
			} catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"Exception:{ex.Message}");
				Console.ResetColor();
			}
		}

		private static void Demo()
		{
			_numbers = new BlockingCollection<int>(new ConcurrentQueue<int>());

			Task produceTask1 = Task.Run(() => ProduceItems());
			Task produceTask2 = Task.Run(() => ProduceItems());
			Task consumeTask1 = Task.Run(() => ConsumeItems());
			Task consumeTask2 = Task.Run(() => ConsumeItems());
			
			Task.WaitAll(produceTask1, produceTask2, consumeTask1, consumeTask2);

			Console.ResetColor();
			Console.WriteLine("------------ Done -----------------");
		}

		private static void ProduceItems()
		{
			int counter = 0;

			while (true)
			{
				Thread.Sleep(50);
				counter += 1;
				// .Add blocks when collection is full
				if (_numbers.IsAddingCompleted)
				{
					return;
				}
				_numbers.Add(counter);
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine($"Add: {counter:D2}, Capacity: {+_numbers.Count}");
				if (counter >= 20)
				{
					_numbers.CompleteAdding();

					return;
				}
			}
		}

		private static void ConsumeItems()
		{
			int counter = 0;
			while (true)
			{
				Thread.Sleep(700);

				if (_numbers.IsCompleted)
				{
					return;
				}
				counter = _numbers.Take();

				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine($"Take: {counter:D2}, Thread: {Thread.CurrentThread.ManagedThreadId}");
			}
		}
	}
}