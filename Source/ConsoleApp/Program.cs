using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
	internal class Program
	{
		private static Queue<Robot> _robots = new Queue<Robot>();

		private static void Main(string[] args)
		{
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

		
		private static void Demo2()
		{
			_robots = new Queue<Robot>();
			Task task1 = Task.Run(() => SetupTeam1());
			Task task2 = Task.Run(() => SetupTeam2());
			Task.WaitAll(task1, task2);

			foreach (var robot in _robots)
			{
				Console.ForegroundColor = robot.TeamColor;
				Console.WriteLine($"{robot.Id}: Team: {robot.Team}, {robot.Name}");
			}
			Console.ResetColor();
			Console.WriteLine("-----------------------------");
		}

		private static int _idCounter = 0;
		private static object _lock = new object();
		private static Mutex _mutex = new Mutex();

		private static void MakeRobot(string teamName, ConsoleColor teamColor)
		{

		
			Thread.Sleep(20);
			_idCounter += 1;
			var robot = new Robot { Id = _idCounter, Name = $"Robot {_idCounter}", Team = teamName, TeamColor = teamColor };
			_robots.Enqueue(robot);

		
		}

		private static void SetupTeam1()
		{
			for (int i = 0; i < 4; i++)
			{

				MakeRobot(teamName: "Starchasers", ConsoleColor.DarkYellow);
			}
		}

		private static void SetupTeam2()
		{
			for (int i = 0; i < 4; i++)
			{

				MakeRobot(teamName: "Deltron", ConsoleColor.Cyan);
			}
		}
	}
}