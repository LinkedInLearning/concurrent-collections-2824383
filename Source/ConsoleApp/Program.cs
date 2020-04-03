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
			// dictionary operations
			// Add, Remove, Update, Count
			// TryAdd, TryGetValue

			// var robots = new ConcurrentDictionary<int, Robot>();
			// to improve demos, we'll change to a simpler set of data in the dictionary

			var robotGems = new ConcurrentDictionary<string, int>();

			robotGems.TryAdd(key: "Robot1", value: 10);
			robotGems.TryAdd(key: "Robot2", value: 20);
			robotGems.TryAdd(key: "Robot3", value: 30);
			robotGems.TryAdd(key: "Robot4", value: 40);


			if (robotGems.TryAdd("Robot4", 44))
			{
				// returns true: Add the item  when the key is not in the dictionary
				Console.WriteLine("\"Robot4\" added to the dictionary.");
			}
			else
			{
				
				// returns false: Does not alter dictionary when key exists in dictionary (without throwing exception)
				Console.WriteLine("Cannot add, \"Robot4\" already in the dictionary.");
			}

			WriteHeaderToConsole("Starting Values");
			Console.WriteLine($"Team count: {robotGems.Count}");
			foreach (var keyPair in robotGems)
			{

				Console.WriteLine($"{keyPair.Key}: , GemstoneCount: {keyPair.Value}");
			}

			// one way to update an item
			int foundCount = SearchForGems();
			Console.WriteLine($"GemStones found: {foundCount}");
		
			int currentGemCount = robotGems["Robot3"];
			robotGems["Robot3"] = currentGemCount + foundCount;

			Console.ForegroundColor = ConsoleColor.Yellow;

			WriteHeaderToConsole("Updated values");
			Console.WriteLine($"Team count: {robotGems.Count}");

			foreach (var keyPair in robotGems)
			{

				Console.WriteLine($"{keyPair.Key}: , GemstoneCount: {keyPair.Value}");

			}

			Console.ResetColor();

		}
		static Random _ran = new Random();
		private static int SearchForGems()
		{
			return _ran.Next(1, 5);
		}
		private static Robot IncrementGemCount(string key, Robot robot)
		{
			robot.GemstoneCount += 1;
			return robot;
		}
		private static void WriteHeaderToConsole(string headerText)
		{
			
			Console.WriteLine("-----------------------------");
			Console.WriteLine(headerText);
			Console.WriteLine("-----------------------------");
		}
	}
}