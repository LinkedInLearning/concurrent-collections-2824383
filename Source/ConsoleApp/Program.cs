using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp {

	internal class Program {
		private static long _total;
		private static System.Collections.Generic.Queue<int> _intQueue;

		private static void Main(string[] args) {
			Console.WriteLine($"The correct total is 2,001,000");
			try
			{

				Demo1();

				#region Multi-thread Demos
			//	Demo2();
			//	Demo3(); 
				#endregion

			} catch (Exception ex)
			{
				Console.WriteLine($"Exception {ex}");
			}
			Console.ResetColor();
		}

		private static void Demo1() {
			SetupQueue();
			CalculateTotalFromQueued();
			Console.WriteLine($"Single Thread:: \r\n\tTotal: \t{_total:N0}");
		}

		private static void SetupQueue() {
			IEnumerable<int> numbers = Enumerable.Range(1, 2000);
			_intQueue = new Queue<int>(numbers);

			_total = 0;
		}

		private static void CalculateTotalFromQueued() {
			int temp;

			while (_intQueue.TryDequeue(out temp))
			{
				//Console.Write($"{Thread.CurrentThread.ManagedThreadId}, ");
				_total += temp;
			}
		}

		#region Multi-thread Demos

		private static void Demo2() {
			SetupQueue();

			Task task1 = Task.Run(() => CalculateTotalFromQueued());
			Task task2 = Task.Run(() => CalculateTotalFromQueued());

			Task.WaitAll(task1, task2);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"Task.Run:: \r\n\tTotal: \t{_total:N0}");
		}

		private static void Demo3() {
			SetupQueue();


			Parallel.Invoke(() => CalculateTotalFromQueued(), () => CalculateTotalFromQueued());
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine($"Parallel.Invoke:: \r\n\tTotal: \t{_total:N0}");
		} 
		#endregion
	}
}