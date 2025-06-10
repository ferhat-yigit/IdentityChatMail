using IdentityChatProject.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityChatProject.Context
{
	public class MailContext : IdentityDbContext<AppUser>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//MSSQL Connect
			optionsBuilder.UseSqlServer("Server=ASUS;initial Catalog=IdentityChatDb;integrated Security=true;trust server certificate=true");
		}
		public DbSet<Message> Messages { get; set; }
	}
}
