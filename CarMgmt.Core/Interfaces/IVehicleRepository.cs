namespace CarMgmt.Core
{
	public interface IVehicleRepository : IRepository<Vehicle>
	{
		Task<IEnumerable<Vehicle>> GetVehicleByBrand(int brandId);
	}
}
