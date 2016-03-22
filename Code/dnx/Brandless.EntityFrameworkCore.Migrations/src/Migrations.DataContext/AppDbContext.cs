using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Migrations.DataContext
{
	public class AppDbContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<Book> Books { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;
			optionsBuilder.UseSqlServer(
				"Server=.;Database=dummy;User ID=dummy;Password=dummy;Trusted_Connection=False;");
			base.OnConfiguring(optionsBuilder);
		}
	}
}