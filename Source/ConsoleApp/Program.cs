using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{

	internal class Program
	{

		static ExampleQueue<int> _exampleQueue;
		private static void Main()
		{
			try
			{
				Demo1();
				// Demo2();
			} catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"Exception:{ex.Message}");
				
			}
			Console.ResetColor();
		}

		private static void Demo1()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			_exampleQueue = new ExampleQueue<int>();
			int result = 0;
			SetupExampleQueue(1,5);

			int count = _exampleQueue.Count;
			for (int i = 1; i <= count; i++)
			{
				result = _exampleQueue.Dequeue();
				Console.WriteLine($"Dequeue value: {result}");
			}
		}

		private static void Demo2()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			int result = 0;
			_exampleQueue = new ExampleQueue<int>();
			Task task1 = Task.Run(() => SetupExampleQueue(1,200));
			Task task2 = Task.Run(() => SetupExampleQueue(220,550));
			Task task3 = Task.Run(() => SetupExampleQueue(600, 1550));
			Task.WaitAll(task1, task2, task3);

			int count = _exampleQueue.Count;
			for (int i = 1; i <= count; i++)
			{
				result = _exampleQueue.Dequeue();
				Console.WriteLine($"Dequeue value: {result}");
			}
		}
		private static void DoNothing() { }
		private static void SetupExampleQueue(int startNumber, int endNumber )
		{

			for (int i = startNumber; i <= endNumber; i++)
			{
				_exampleQueue.Enqueue(i);
			}
		}
	}
}