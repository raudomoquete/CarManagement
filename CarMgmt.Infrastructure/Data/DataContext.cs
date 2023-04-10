using CarMgmt.Core;
using Microsoft.EntityFrameworkCore;

namespace CarMgmt.Infrastructure
{
	public class DataContext : DbContext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

		public DbSet<Accessory> Accessories { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<Engine> Engines { get; set; }
		public DbSet<Fuel> Fuels { get; set; }
		public DbSet<Model> Models { get; set; }
        public DbSet<Status> Stats { get; set; }
		public DbSet<Traction> Tractions { get; set; }
		public DbSet<Transmission> Transmissions { get; set; }
		public DbSet<Vehicle> Vehicles { get; set; }
		public DbSet<VehicleType> VehicleTypes { get; set; }
		public DbSet<Year> Years { get; set; }

	}
}
