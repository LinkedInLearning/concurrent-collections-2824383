using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
	internal class Program
	{

		private static ConcurrentBag<Robot> _robots;

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
			_robots = new ConcurrentBag<Robot>();
			// with standard Queue this will occasionally throw array exception!
			Task task1 = Task.Run(() => SetupTeam1());
			Task task2 = Task.Run(() => SetupTeam2());
			Task.WaitAll(task1, task2);

			// Tries to return an item from the of the ConcurrentBag
			// without removing it.
			Robot peekResult, takeResult;

			_robots.TryPeek(out peekResult);
			Console.WriteLine($"TryPeek, Name: {peekResult.Name}, Id: {peekResult}");

			if (_robots.IsEmpty == false)
			{
				if (_robots.TryTake(out takeResult))
				{
					Console.WriteLine($"TryTake, Name: {takeResult.Name}, Id: {takeResult.Id}");
				}
			}
			task1 = Task.Run(() => TakeItems());
			task2 = Task.Run(() => TakeItems());

			Task.WaitAll(task1, task2);
			//TakeItems();
			Console.ResetColor();
			Console.WriteLine("-----------------------------");
		}

		private static void TakeItems()
		{
			Console.WriteLine();
			Robot robot;
			while (_robots.TryTake(out robot))
			{
				Console.ForegroundColor = robot.TeamColor;
				Console.WriteLine($"Thread:{ Thread.CurrentThread.ManagedThreadId} \t{ robot.Id}: Team: {robot.Team}, {robot.Name}");
			}
			
		

		}

		private static void SetupTeam1()
		{
			Robot tempRobot;
			Thread.Sleep(50);
			for (int counter = 10; counter < 16; counter++)
			{

				tempRobot = new Robot { Id = counter, Name = $"Robot{counter}", Team = "Starchasers", TeamColor = ConsoleColor.DarkCyan };
				_robots.Add(tempRobot);

				Thread.Sleep(1);

				Console.WriteLine($"Thread:{Thread.CurrentThread.ManagedThreadId} \tAdd: ID {tempRobot.Id}: Team: {tempRobot.Team}, {tempRobot.Name}");
			}

			//_robots.Add(new Robot { Id = 11, Name = "Robot11", Team = "Starchasers", TeamColor = ConsoleColor.DarkCyan });
			//Thread.Sleep(1);
			//_robots.Add(new Robot { Id = 12, Name = "Robot12", Team = "Starchasers", TeamColor = ConsoleColor.DarkCyan });
			//Thread.Sleep(1);
			//_robots.Add(new Robot { Id = 13, Name = "Robot13", Team = "Starchasers", TeamColor = ConsoleColor.DarkCyan });
			//Thread.Sleep(1);
			//_robots.Add(new Robot { Id = 14, Name = "Robot14", Team = "Starchasers", TeamColor = ConsoleColor.DarkCyan });

			Robot robot;
			_robots.TryTake(out robot);

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"Thread:{Thread.CurrentThread.ManagedThreadId} \tTryTake: ID {robot.Id}: Team: {robot.Team}, {robot.Name}");
		}

		private static void SetupTeam2()
		{
			Robot tempRobot;
			for (int counter = 20; counter < 26; counter++)
			{

				tempRobot = new Robot { Id = counter, Name = $"Robot{counter}", Team = "Deltron", TeamColor = ConsoleColor.DarkYellow };
				_robots.Add(tempRobot);

				Thread.Sleep(70);

				Console.WriteLine($"Thread::{Thread.CurrentThread.ManagedThreadId} \tAdd: ID {tempRobot.Id}: Team: {tempRobot.Team}, {tempRobot.Name}");
			}


			Robot robot;
			_robots.TryTake(out robot);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"Thread:{Thread.CurrentThread.ManagedThreadId} \tTryTake: ID {robot.Id}: Team: {robot.Team}, {robot.Name}");

		}
	}
}