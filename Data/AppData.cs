using Microsoft.EntityFrameworkCore;
using CustomerApp.Models;

namespace CustomerApp.Data
{
	public class AppData:DbContext
	{
		public IConfiguration _config { get; set; }
        public AppData(IConfiguration config)
        {
			_config	=config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_config.GetConnectionString("DbConnection"));
		}

		public DbSet<Customer> Customers { get; set; }
	}
}
