using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

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
			var robots = new Dictionary<int, Robot>();
			var _robotsNew = new ConcurrentDictionary<int, Robot>();

			Robot robot;
			robot = MakeRobot(teamName: "Star-chasers", ConsoleColor.DarkYellow);
			robots.Add(robot.Id, robot);
			robot = MakeRobot(teamName: "Star-chasers", ConsoleColor.DarkYellow);
			robots.Add(robot.Id, robot);

			robot = MakeRobot(teamName: "Deltron", ConsoleColor.Cyan);
			robots.Add(robot.Id, robot);

			robot = MakeRobot(teamName: "Dark Horizon", ConsoleColor.DarkMagenta);
			robots.Add(robot.Id, robot);

			WriteHeaderToConsole("List all items in dictionary");
			foreach (var keyPair in robots)
			{
				Console.ForegroundColor = keyPair.Value.TeamColor;
				Console.WriteLine($"{keyPair.Key}: Team: {keyPair.Value.Name}, {keyPair.Value.Team}");
			}
			robots.Remove(1);

			WriteHeaderToConsole("List after removing a robot");
			foreach (var keyPair in robots)
			{
				Console.ForegroundColor = keyPair.Value.TeamColor;
				Console.WriteLine($"{keyPair.Key}: Team: {keyPair.Value.Name}, {keyPair.Value.Team}");
			}

			Console.ResetColor();
		}

		private static void WriteHeaderToConsole(string headerText)
		{
			Console.ResetColor();
			Console.WriteLine("-----------------------------");
			Console.WriteLine(headerText);
			Console.WriteLine("-----------------------------");
		}

		private static int _idCounter = 0;

		private static Robot MakeRobot(string teamName, ConsoleColor teamColor)
		{
			Thread.Sleep(20);
			_idCounter += 1;
			var robot = new Robot { Id = _idCounter, Name = $"Robot {_idCounter}", Team = teamName, TeamColor = teamColor };
			return robot;
		}

		private static List<Robot> GetRobotTeam()
		{
			var temp = new List<Robot>();
			for (int i = 0; i < 4; i++)
			{
				temp.Add(MakeRobot(teamName: "Star-chasers", ConsoleColor.DarkYellow));
			}

			for (int i = 0; i < 4; i++)
			{
				temp.Add(MakeRobot(teamName: "Deltron", ConsoleColor.Cyan));
			}

			return null;
		}
	}
}