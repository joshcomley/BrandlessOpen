using System;
using System.IO;
using Brandless.EntityFrameworkCore.Migrations;
using Migrations.DataContext;

namespace Migrations
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var projectPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\Migrations.DataContext"));
			var codeFirstMigrations = new CodeFirstMigrations<AppDbContext>(projectPath);
			codeFirstMigrations.Add("Init");
		}
	}
}
