using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ConsoleApp
{
	internal class Program
	{
		//private static Dictionary<int, Robot> _robots;
		//private static ConcurrentDictionary<int, Robot> _robotsNew;

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

			//		var robots = new Dictionary<int, Robot>();
			var robots = new ConcurrentDictionary<int, Robot>();

			Robot robot1, robot2, robot3, robot4, currentRobot, tryRobot;

			#region CreateRobots

			robot1 = new Robot()
			{
				Id = 1,
				Name = "Robot 1",
				Team = "Star-chasers",
				TeamColor = ConsoleColor.DarkYellow,
				GemstoneCount = 10
			};
			robot2 = new Robot()
			{
				Id = 2,
				Name = "Robot 2",
				Team = "Star-chasers",
				TeamColor = ConsoleColor.DarkYellow,
				GemstoneCount = 10
			};

			robot3 = new Robot()
			{
				Id = 3,
				Name = "Robot 3",
				Team = "Deltron",
				TeamColor = ConsoleColor.Cyan,
				GemstoneCount = 10
			};
			robot4 = new Robot()
			{
				Id = 4,
				Name = "Robot 4",
				Team = "Deltron",
				TeamColor = ConsoleColor.Magenta,
				GemstoneCount = 10
			};

			#endregion CreateRobots

			robots.TryAdd(robot1.Id, robot1);
			robots.TryAdd(robot2.Id, robot2);
			robots.TryAdd(robot3.Id, robot3);
			robots.TryAdd(robot4.Id, robot4);

			if (!robots.TryAdd(robot4.Id, robot4))
			{
				// Adds robot successfully when it is not already in dictionary
				// returns false if robot exists in dictionary, without throwing exception
				Console.WriteLine("Cannot add, robot already in the dictionary.");
			}

			WriteHeaderToConsole("List all items in dictionary");
			Console.WriteLine($"Team count: {robots.Count}");
			foreach (var keyPair in robots)
			{
				Console.ForegroundColor = keyPair.Value.TeamColor;
				Console.WriteLine($"{keyPair.Key}: Team: {keyPair.Value.Name}, " +
													$"{keyPair.Value.Team}, GemstoneCount: {keyPair.Value.GemstoneCount}");
			}
			//robots.Remove(1);

			//if (robots.TryRemove (robot1.Id, out robot1)
			//{

			//}
			//if (robots.TryRemove(robot1.Id, out _))
			//{

			//}
			currentRobot = robots[3];
			currentRobot.GemstoneCount += 1;
			robots[3] = currentRobot;

			WriteHeaderToConsole("List after removing a robot");
			Console.WriteLine($"Team count: {robots.Count}");
			foreach (var keyPair in robots)
			{
				Console.ForegroundColor = keyPair.Value.TeamColor;
				Console.WriteLine($"{keyPair.Key}: Team: {keyPair.Value.Name}," +
													$" {keyPair.Value.Team}, GemstoneCount: {keyPair.Value.GemstoneCount}");

			}

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"Use .TryGetValue");

			robots.TryGetValue(3, out tryRobot);
			Console.WriteLine($"{tryRobot.Id}: Team: {tryRobot.Name}, {tryRobot.Team}, GemstoneCount: {tryRobot.GemstoneCount}");
			Console.ResetColor();
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