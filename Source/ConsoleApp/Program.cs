using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp {

	internal class Program {

		static ExampleQueue<int> _exampleQueue;
		private static void Main() {


			
				try
				{
					Demo2();
				} catch (Exception ex)
				{

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine($"Exception:{ex.Message}");
					Console.ResetColor();
				}
		
		}

		private static void Demo1() {
			_exampleQueue = new ExampleQueue<int>();
			int result = 0;
			SetupExampleQueue();


			result = _exampleQueue.Dequeue();
			Console.WriteLine($"Dequeue value:{result}");
		
			result = _exampleQueue.Dequeue();
			Console.WriteLine($"Dequeue value:{result}");
			result = _exampleQueue.Dequeue();
			Console.WriteLine($"Dequeue value:{result}");

			Console.ResetColor();

		}

		private static void Demo2() {
			int result = 0;
			_exampleQueue = new ExampleQueue<int>();
			Task task1 = Task.Run(() => SetupExampleQueue());
			Task task2 = Task.Run(() => SetupExampleQueue());
			Task.WaitAll(task1, task2);

			result = _exampleQueue.Dequeue();
			Console.WriteLine($"Dequeue value:{result}");

			result = _exampleQueue.Dequeue();
			Console.WriteLine($"Dequeue value:{result}");
			result = _exampleQueue.Dequeue();
			Console.WriteLine($"Dequeue value:{result}");
		}
		private static void DoNothing() { }
			private static void SetupExampleQueue() {

			for (int i = 0; i < 30; i++)
			{
				_exampleQueue.Enqueue(i);
			}
		}
	}
}