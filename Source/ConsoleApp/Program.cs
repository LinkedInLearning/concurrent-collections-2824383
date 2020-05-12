using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.InteropServices;
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
				Maximize();
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
			_numbers = new BlockingCollection<int>();
		
			Task produceTask = Task.Run(() => ProduceItems());
			Task consumeTask = Task.Run(() => ConsumeItems());
			Task.WaitAll(produceTask, consumeTask);

			Console.ResetColor();
			Console.WriteLine("-----------------------------");
		}

		private static void ProduceItems()
		{
		
			int counter = 0;

			while (true)
			{
				Thread.Sleep(1100);
				counter += 1;
				// .Add thread is blocked when collection reached bounded capacity
				_numbers.Add(counter);
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine($"Add: {counter}, Capacity: {_numbers.Count}");
			}
			
		}

		private static void ConsumeItems()
		{
			int counter = 0;
			while (true)
			{
				Thread.Sleep(800);
		
				// .Take method is blocked when collection is empty.
				counter =  _numbers.Take();

				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine($"Take: {counter}");
			}
		}

		#region MaximizeWindowCode
		[DllImport("user32.dll", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);
		[DllImport("kernel32.dll")]
		static extern IntPtr GetConsoleWindow();

		private static void Maximize()
		{
			Process p = Process.GetCurrentProcess();
			ShowWindow(GetConsoleWindow(), 3); //SW_MAXIMIZE = 3
		} 
		#endregion
	}
}