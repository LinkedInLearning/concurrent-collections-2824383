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
			// From the Microsoft documentation
			// All public and protected members of ConcurrentDictionary<TKey,TValue> are thread-safe ...
			// However, members accessed
			// "through one of the interfaces"
			// the ConcurrentDictionary<TKey,TValue> implements,
			// including extension methods, are not guaranteed to be thread safe and may need to be synchronized by the caller.

			// ICollection<KeyValuePair<TKey, TValue>>,
			// IEnumerable<KeyValuePair<TKey, TValue>>,
			// IEnumerable,
			// IDictionary<TKey, TValue>,
			// IReadOnlyCollection<KeyValuePair<TKey, TValue>>,
			// IReadOnlyDictionary<TKey, TValue>, ICollection

			var robotGems = new ConcurrentDictionary<string, int>();

			robotGems.TryAdd(key: "Robot1", value: 10);
			robotGems.TryAdd(key: "Robot2", value: 20);
			robotGems.TryAdd(key: "Robot3", value: 30);
			robotGems.TryAdd(key: "Robot4", value: 40);

			CreateReport(robotGems, 20);

			//var collection = robotGems as ICollection<KeyValuePair<string, int>>;

			Console.ResetColor();
		}

		private static Random _ran = new Random();

		private static void CreateReport(ICollection<KeyValuePair<string, int>> candidates, int threshold)
		{
			// legacy service that produces report from an ICollection
			foreach (var item in candidates)
			{
				Console.WriteLine($"{item.Key}:  GemCount: {item.Value}");

				// .Add, .Remove are not thread-safe

				//if (item.Value <25)
				//{
				//	candidates.Remove(item);
				//}
			}
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