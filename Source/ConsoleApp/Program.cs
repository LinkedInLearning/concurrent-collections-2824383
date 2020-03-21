using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp {
	class Program {
		private static long _total;
		private static Queue<Robot> _robots = new Queue<Robot>();
		static async Task Main(string[] args) {
			for (int i = 0; i < 10; i++)
			{
				try
				{
					Demo1();
				} catch (Exception ex)
				{

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine($"Exception:{ex.Message}");
					Console.ResetColor();
				}
			}

		}
		private static void Demo1() {
			_robots = new Queue<Robot>();
			SetupTeam1();
			SetupTeam2();
			foreach (var robot in _robots)
			{
				Console.ForegroundColor = robot.Color;
				Console.WriteLine($"{robot.Id}: Team: {robot.Team}, {robot.Name}");
			}

			Console.ResetColor();
			Console.WriteLine("-----------------------------");
		}
		private static void SetupTeam1() {
			Thread.Sleep(1);
			_robots.Enqueue(new Robot { Id = 10, Name = "Melville", Team = "Starchasers", Color = ConsoleColor.DarkCyan });
			Thread.Sleep(1);
			_robots.Enqueue(new Robot { Id = 11, Name = "Squido", Team = "Starchasers", Color = ConsoleColor.DarkCyan });
			Thread.Sleep(1);
			_robots.Enqueue(new Robot { Id = 12, Name = "Frex", Team = "Starchasers", Color = ConsoleColor.DarkCyan });
			Thread.Sleep(1);
			_robots.Enqueue(new Robot { Id = 13, Name = "Belfor", Team = "Starchasers", Color = ConsoleColor.DarkCyan });
			Thread.Sleep(1);
			_robots.Enqueue(new Robot { Id = 14, Name = "Jeeve", Team = "Starchasers", Color = ConsoleColor.DarkCyan });
		}
		private static void SetupTeam2() {
			Thread.Sleep(1);
			_robots.Enqueue(new Robot { Id = 20, Name = "Jarm", Team = "Deltron", Color = ConsoleColor.DarkYellow });
			Thread.Sleep(1);
			_robots.Enqueue(new Robot { Id = 21, Name = "Skedle", Team = "Deltron", Color = ConsoleColor.DarkYellow });
			Thread.Sleep(1);
			_robots.Enqueue(new Robot { Id = 22, Name = "Cellki", Team = "Deltron", Color = ConsoleColor.DarkYellow });
			Thread.Sleep(1);
			_robots.Enqueue(new Robot { Id = 23, Name = "Treedo", Team = "Deltron", Color = ConsoleColor.DarkYellow });
			Thread.Sleep(1);
			_robots.Enqueue(new Robot { Id = 24, Name = "Umber", Team = "Deltron", Color = ConsoleColor.DarkYellow });
		}
	}

}
