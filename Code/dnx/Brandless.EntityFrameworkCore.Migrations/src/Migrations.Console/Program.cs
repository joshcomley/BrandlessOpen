using System;
using System.IO;
using Brandless.EntityFrameworkCore.Migrations;
using Microsoft.DotNet.Cli.Utils;
using Migrations.DataContext;

namespace Migrations
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//var projectPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\Migrations.DataContext"));
			var projectPath =
				@"D:\B\BrandlessOpen\Code\dnx\Brandless.EntityFrameworkCore.Migrations\src\Migrations.DataContext";
			Console.WriteLine("Running in " + projectPath.Yellow());
			var codeFirstMigrations = new CodeFirstMigrations<AppDbContext>(projectPath);
			codeFirstMigrations.Add("Init");
		}
	}
}
