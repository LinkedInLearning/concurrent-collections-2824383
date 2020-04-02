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

			//var robots = new ConcurrentDictionary<int, Robot>();
			// to improve demos, we'll change to a simpler set of date in the dictionary

			var robotGems = new ConcurrentDictionary<string, int>();

			robotGems.TryAdd("Robot1", 10);
			robotGems.TryAdd("Robot2", 20);
			robotGems.TryAdd("Robot3", 30);
			robotGems.TryAdd("Robot1", 40);
		

			if (!robotGems.TryAdd("Robot4", 40))
			{
				// Adds item successfully when it is not already in dictionary
				// returns false if item exists in dictionary, without throwing exception
				Console.WriteLine("Cannot add, robot already in the dictionary.");
			}

			WriteHeaderToConsole("List all items in dictionary");
			Console.WriteLine($"Team count: {robotGems.Count}");
			foreach (var keyPair in robotGems)
			{
			
				Console.WriteLine($"{keyPair.Key}: , GemstoneCount: {keyPair.Value}");
			}

			// one way to update an item
			int currentGemCount = robotGems["Robot3"];
			currentGemCount += 1;
			robotGems["Robot3"] = currentGemCount;

			// TryUdate
			// 1. Key must exist in dictionary.
			// 2. Pass in the old value for comparison
			//    Update only happens if old value matches expectations.
			// useful to prevent another thread from making unexpected updates.

			currentGemCount = robotGems["Robot4"];
			currentGemCount += 1;

		//	gems.AddOrUpdate(key: "Robot4", addValue: 42, updateValueFactory: (key,oldvalue)=> IncrementGemCount(key, currentRobot));

			WriteHeaderToConsole("List after removing a robot");
			Console.WriteLine($"Team count: {robotGems.Count}");
			
			foreach (var keyPair in robotGems)
			{

				Console.WriteLine($"{keyPair.Key}: , GemstoneCount: {keyPair.Value}");

			}

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"Use .TryGetValue");

			robotGems.TryGetValue("Robot3", out currentGemCount);
			Console.WriteLine($"Robot3: GemstoneCount: {currentGemCount}");
		
		}
		private static Robot IncrementGemCount(string key, Robot robot)
		{
			robot.GemstoneCount += 1;
			return robot;
		}
		private static void WriteHeaderToConsole(string headerText)
		{
			Console.ResetColor();
			Console.WriteLine("-----------------------------");
			Console.WriteLine(headerText);
			Console.WriteLine("-----------------------------");
		}
	}
}