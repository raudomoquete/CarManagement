using CarMgmt.Core;
using Microsoft.EntityFrameworkCore;

namespace CarMgmt.Infrastructure
{
	public class DataContext : DbContext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Brand> Brands { get; set; }
		public DbSet<Model> Models { get; set; }
        public DbSet<Status> Stats { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }


	}
}
