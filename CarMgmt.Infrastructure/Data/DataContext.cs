using CarMgmt.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMgmt.Infrastructure.Data
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
