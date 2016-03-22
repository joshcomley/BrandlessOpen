using System;
using Microsoft.EntityFrameworkCore;

namespace Brandless.EntityFrameworkCore.Migrations
{
	public class CodeFirstMigrations<TDbContext> : CodeFirstMigrations
		where TDbContext : DbContext
	{
		public CodeFirstMigrations(string projectPath, Func<TDbContext> resolveDbContext = null)
			: base(projectPath, typeof(TDbContext), resolveDbContext)
		{
			if (resolveDbContext == null)
			{
				ResolveDbContext = Activator.CreateInstance<TDbContext>;
			}
		}
	}
}
