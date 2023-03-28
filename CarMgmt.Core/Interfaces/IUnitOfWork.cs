namespace CarMgmt.Core
{
	public interface IUnitOfWork : IDisposable
	{
		IVehicleRepository VehicleRepository { get; }

		IRepository<Brand> BrandRepository { get; }

		IRepository<Model> ModelRepository { get; }

		IRepository<Status> StatusRepository { get; }

		void SaveChanges();

		Task SaveChangesAsync();
	}
}
