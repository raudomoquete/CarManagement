using CarMgmt.Core;
using Microsoft.EntityFrameworkCore;

namespace CarMgmt.Infrastructure
{
	public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
	{
		private readonly DataContext _context;

        public VehicleRepository(DataContext context) : base(context)
        {
            
        }

		public async Task<IEnumerable<Vehicle>> GetVehicleByBrand(int brandId)
		{
			return await _entities.Where(x => x.BrandId == brandId).ToListAsync();
		}
	}
}
