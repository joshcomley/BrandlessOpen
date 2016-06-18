using System;
using System.IO;
using Brandless.EntityFrameworkCore.Migrations;
using Microsoft.DotNet.Cli.Utils;
using Migrations.DataContext;
using System.Linq;

namespace Migrations
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//var projectPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\Migrations.DataContext"));
            string[] possibleProjectPaths =
            {
                @"D:\B\BrandlessOpen\Code\dnx\Brandless.EntityFrameworkCore.Migrations\src\Migrations.DataContext",
                @"D:\Code\Git\Brandless\BrandlessOpen\Code\dnx\Brandless.EntityFrameworkCore.Migrations\src\Migrations.DataContext"
            };
            var projectPath = possibleProjectPaths.First(Directory.Exists);
            Console.WriteLine("Running in " + projectPath.Yellow());
			var codeFirstMigrations = new CodeFirstMigrations<AppDbContext>(projectPath);
			codeFirstMigrations.Add("Init");
		}
	}
}
