using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
	internal class Program
	{

		private static ConcurrentQueue<Robot> _robots;

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
			_robots = new ConcurrentQueue<Robot>();
			// with standard Queue this will occasionally throw array exception!
			Task task1 = Task.Run(() => SetupTeam1());
			Task task2 = Task.Run(() => SetupTeam2());
			Task.WaitAll(task1, task2);

			// Tries to return an object from the beginning of the ConcurrentQueue
			// without removing it.
			Robot peekResult, dqResult;

			_robots.TryPeek(out peekResult);
			Console.WriteLine($"TryPeek, Name: {peekResult.Name}, Id: {peekResult}");

			if (_robots.IsEmpty == false)
			{
				if (_robots.TryDequeue(out dqResult))
				{
					Console.WriteLine($"TryDequeue, Name: {dqResult.Name}, Id: {dqResult.Id}");
				}
			}
			Console.WriteLine();
			foreach (var robot in _robots)
			{
				Console.ForegroundColor = robot.TeamColor;
				Console.WriteLine($"{robot.Id}: Team: {robot.Team}, {robot.Name}");
			}
			Console.ResetColor();
			Console.WriteLine("-----------------------------");
		}

		private static void SetupTeam1()
		{
			Robot robot;
			Thread.Sleep(1);
			robot = new Robot { Id = 10, Name = "Robot10", Team = "Starchasers", TeamColor = ConsoleColor.DarkCyan };
			_robots.Enqueue(robot);
			Thread.Sleep(1);
			_robots.Enqueue(new Robot { Id = 11, Name = "Robot11", Team = "Starchasers", TeamColor = ConsoleColor.DarkCyan });
			Thread.Sleep(1);
			_robots.Enqueue(new Robot { Id = 12, Name = "Robot12", Team = "Starchasers", TeamColor = ConsoleColor.DarkCyan });
			Thread.Sleep(1);
			_robots.Enqueue(new Robot { Id = 13, Name = "Robot13", Team = "Starchasers", TeamColor = ConsoleColor.DarkCyan });
			Thread.Sleep(1);
			_robots.Enqueue(new Robot { Id = 14, Name = "Robot14", Team = "Starchasers", TeamColor = ConsoleColor.DarkCyan });
		}

		private static void SetupTeam2()
		{
			Thread.Sleep(1);
			_robots.Enqueue(new Robot { Id = 20, Name = "Robot20", Team = "Deltron", TeamColor = ConsoleColor.DarkYellow });
			Thread.Sleep(1);
			_robots.Enqueue(new Robot { Id = 21, Name = "Robot21", Team = "Deltron", TeamColor = ConsoleColor.DarkYellow });
			Thread.Sleep(1);
			_robots.Enqueue(new Robot { Id = 22, Name = "Robot22", Team = "Deltron", TeamColor = ConsoleColor.DarkYellow });
			Thread.Sleep(1);
			_robots.Enqueue(new Robot { Id = 23, Name = "Robot23", Team = "Deltron", TeamColor = ConsoleColor.DarkYellow });
			Thread.Sleep(1);
			_robots.Enqueue(new Robot { Id = 24, Name = "Robot24", Team = "Deltron", TeamColor = ConsoleColor.DarkYellow });
		}
	}
}