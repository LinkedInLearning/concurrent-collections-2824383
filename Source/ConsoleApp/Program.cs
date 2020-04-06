using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp {
	class Program {
		private static long _total;
		private static Queue<Robot> _robots = new Queue<Robot>();
		static void Main(string[] args) {
			
				try
				{
				//Demo1();	
				//Demo2();
			} catch (Exception ex)
				{

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine($"Exception:{ex.Message}");
					Console.ResetColor();
				}

		}
		private static void Demo1() {
			_robots = new Queue<Robot>();
			SetupTeam1();
			SetupTeam2();
			Robot robot;
			Console.WriteLine();
			while (_robots.Count > 0)
			{
				robot = _robots.Dequeue();
				Console.ForegroundColor = robot.TeamColor;
				Console.WriteLine($"{robot.Id}: Team: {robot.Team}, {robot.Name}");
			}

			Console.ResetColor();
			Console.WriteLine("-----------------------------");
		}

		private static void Demo2() {
			_robots = new Queue<Robot>();
			Task task1 = Task.Run(() => SetupTeam1());
			Task task2 = Task.Run(() => SetupTeam2());
			Task.WaitAll(task1, task2);
			Robot robot;
			Console.WriteLine();
			while (_robots.Count >0)
			{
				robot = _robots.Dequeue();
				Console.ForegroundColor = robot.TeamColor;
				Console.WriteLine($"{robot.Id}: Team: {robot.Team}, {robot.Name}");
			}
			

			Console.ResetColor();
			Console.WriteLine("-----------------------------");
		}
		private static void SetupTeam1() {
			Robot robot;
			
			for (int counter = 10; counter <=14; counter++)
			{
				Thread.Sleep(1);
				robot = new Robot { Id = counter, Name = $"Robot{counter}", Team = "Starchasers", TeamColor = ConsoleColor.DarkCyan };
				_robots.Enqueue(robot);
				Console.WriteLine($"Enqueue, Thread: {Thread.CurrentThread.ManagedThreadId}, Queue.Count: {_robots.Count:D2} Name: {robot.Name}");
				
			}
	
			
		}
		private static void SetupTeam2() {

			Robot robot;

			for (int counter = 20; counter <= 24; counter++)
			{
				Thread.Sleep(1);
				robot = new Robot { Id = counter, Name = $"Robot{counter}", Team = "Deltron", TeamColor = ConsoleColor.DarkYellow };
				_robots.Enqueue(robot);

				Console.WriteLine($"Enqueue, Thread: {Thread.CurrentThread.ManagedThreadId}, Queue.Count: {_robots.Count:D2} Name: {robot.Name}");

			}

		}
	}

}
