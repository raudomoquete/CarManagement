using CarMgmt.Core;

namespace CarMgmt.Infrastructure
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly DataContext _context;
		private readonly IVehicleRepository _vehicleRepository;
		private readonly IRepository<Brand> _brandRepository;
		private readonly IRepository<Model> _modelRepository;
		private readonly IRepository<Status> _statusRepository;

        public UnitOfWork(DataContext context)
        {
			_context = context;
		}

		public IVehicleRepository VehicleRepository => _vehicleRepository ?? new VehicleRepository(_context);

		public IRepository<Brand> BrandRepository => _brandRepository ?? new BaseRepository<Brand>(_context);

		public IRepository<Model> ModelRepository => _modelRepository ?? new BaseRepository<Model>(_context);

		public IRepository<Status> StatusRepository => _statusRepository ?? new BaseRepository<Status>(_context);


		public void Dispose()
		{
			if (_context != null) { _context.Dispose(); }
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

	}
}
