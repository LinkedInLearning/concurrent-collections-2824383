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

			#region Wrong way to update #1
			// wrong way to update an item
			int foundCount = SearchForGems();
			Console.WriteLine($"Robot3, GemStones found: {foundCount}");

			int currentGemCount = robotGems["Robot3"];
			// while current thread is running, the currentGemCount == 30	
			// what happens if another thread is scheduled between these 2 lines of code?
			// for example it updates "Robot3" gem count to 34.
			robotGems["Robot3"] = currentGemCount + foundCount;

			// what we want to happen
			// thread 1, sets dictionary value == 30 + 2
			// thread 2 sets dictionary value == 32 + 4
			// expected result is 36.

			// what really happened, result is 32.  A race condition broke our application!

			#endregion

			// better way, but still needs work
			int foundCount2 = SearchForGems();
			Console.WriteLine($"Robot4, GemStones found: {foundCount2}");

			currentGemCount = robotGems["Robot4"];
		
			
			// what action should happen when the value cannot be updated?
			// Try again?
			while (robotGems.TryUpdate(key: "Robot4", newValue: currentGemCount + foundCount2, comparisonValue: currentGemCount)== false)
			{
			currentGemCount =	robotGems["Robot4"];
			}
			

			currentGemCount += 1;

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