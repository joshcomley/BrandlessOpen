using System;
using System.IO;
using System.Reflection;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Brandless.EntityFrameworkCore.Migrations
{
	public class CodeFirstMigrations
	{
		private readonly DesignTimeServicesBuilder _servicesBuilder;

		public CodeFirstMigrations(string projectPath, Type dbContextType, Func<DbContext> resolveDbContext)
		{
			ProjectPath = projectPath;
			ResolveDbContext = resolveDbContext;
			var entryAssembly = dbContextType.GetTypeInfo().Assembly;
			var al = new AssemblyLoader(name => entryAssembly);
			var startupInvoker = new StartupInvoker(entryAssembly, "Debug", AppContext.BaseDirectory);
			_servicesBuilder = new DesignTimeServicesBuilder(al, startupInvoker);
		}

		public string ProjectPath { get; set; }
		public Func<DbContext> ResolveDbContext { get; set; }

		public virtual MigrationFiles Add([NotNull] string name, string @namespace = null)
		{
			// TODO: Try to find existing migration and use that namespace (maybe?)
			@namespace = @namespace ?? Path.GetDirectoryName(ProjectPath);
			using (var context = ResolveDbContext())
			{
				var services = _servicesBuilder.Build(context);
				var requiredService = services.GetRequiredService<MigrationsScaffolder>();
				var migration = requiredService.ScaffoldMigration(name, @namespace, "");
				return requiredService.Save(ProjectPath, migration);
			}
		}
	}
}