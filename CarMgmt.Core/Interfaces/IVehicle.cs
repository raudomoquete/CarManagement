namespace CarMgmt.Core
{
	public interface IVehicle
	{
		IEnumerable<Vehicle> GetVehicles();

		Task<Vehicle> GetVehicleById(int id);

		Task<Vehicle> GetVehicleByStatus(Status status);

		Task AddVehicle(Vehicle vehicle);

		Task<bool> UpdateVehicle(Vehicle vehicle);

		Task<bool> DeleteVehicle(int id);
	}
}
