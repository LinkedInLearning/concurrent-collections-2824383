using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ConsoleApp
{
	internal class Program
	{
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
			var robotGems = new ConcurrentDictionary<string, int>();
			KeyValuePair<string, int> robotKeyPair;
			for (int i = 0; i < 5; i++)
			{
				robotKeyPair = CreateRobot();
				robotGems.TryAdd(robotKeyPair.Key, robotKeyPair.Value);
			}

			WriteHeaderToConsole("Starting Values");
			Console.WriteLine($"Team count: {robotGems.Count}");
			foreach (var keyPair in robotGems)
			{
				Console.WriteLine($"{keyPair.Key}: , GemstoneCount: {keyPair.Value}");
			}

			int currentGemCount;

			// some experts consider AddOrUpdate a better choice over TryUpdate method
			// but it is more complex and you must provide one or more delegates
			// that add or update the values in the ConcurrentDictionary
			
			//if (robotGems.TryUpdate("robot2", 22, 22))
			//{
			//	// update item value in dictionary.
			//}
			//else
			//{ 
			//	// add new item to dictionary
			//}

			currentGemCount = robotGems["Robot4"];

			robotGems.AddOrUpdate(key: "Robot4",
														addValueFactory: (key) => SetDefaultGemCountForRobot(key),
														updateValueFactory: (key, oldvalue) => IncrementGemCount(key, currentGemCount));

			robotGems.AddOrUpdate(key: "Robot6",
																addValueFactory: (key) => SetDefaultGemCountForRobot(key),
																updateValueFactory: (key, oldvalue) => IncrementGemCount(key, currentGemCount));

			Console.ForegroundColor = ConsoleColor.Yellow;

			WriteHeaderToConsole("Updated values");
			Console.WriteLine($"Team count: {robotGems.Count}");

			foreach (var keyPair in robotGems)
			{
				Console.WriteLine($"{keyPair.Key}: , GemstoneCount: {keyPair.Value}");
			}

			Console.ResetColor();
		}

		private static object _lock = new object();
		private static int _counter;

		private static KeyValuePair<string, int> CreateRobot()
		{
			lock (_lock)
			{
				_counter += 1;

				return new KeyValuePair<string, int>($"Robot{_counter}", _counter * 10);
			}
		}

		private static int IncrementGemCount(string key, int originalValue)
		{
			// AddOrUpdate calls this code via a delegate,
			// we are responsible to write thread-safe code here.
			lock (_lock)
			{
				var foundCount = SearchForGems();
				Console.WriteLine();
				Console.WriteLine($"{key}, GemStones found: {foundCount}");
				return originalValue + foundCount;
			}
		}

		private static int SetDefaultGemCountForRobot(string key)
		{
			// AddOrUpdate calls this code via a delegate,
			// we are responsible to write thread-safe code here.
			return 5;
		}

		private static Random _ran = new Random();

		private static int SearchForGems()
		{
			return _ran.Next(1, 5);
		}

		private static void WriteHeaderToConsole(string headerText)
		{
			Console.WriteLine("-----------------------------");
			Console.WriteLine(headerText);
			Console.WriteLine("-----------------------------");
		}
	}
}