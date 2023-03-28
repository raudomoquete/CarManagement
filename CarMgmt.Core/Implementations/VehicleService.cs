namespace CarMgmt.Core
{
	public class VehicleService : IVehicle
	{
		private readonly IUnitOfWork _unitOfWork;

        public VehicleService(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}

		public async Task AddVehicle(Vehicle vehicle)
		{
			await _unitOfWork.VehicleRepository.Add(vehicle);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task<bool> DeleteVehicle(int id)
		{
			await _unitOfWork.VehicleRepository.Delete(id);
			return true;
		}

		public Task<Vehicle> GetVehicleById(int id)
		{
			return _unitOfWork.VehicleRepository.GetById(id);
		}

		public async Task<Vehicle> GetVehicleByStatus(Status status)
		{
			return await _unitOfWork.VehicleRepository.GetByStatus(status);
		}

		public IEnumerable<Vehicle> GetVehicles()
		{
			return _unitOfWork.VehicleRepository.GetAll();
		}

		public async Task<bool> UpdateVehicle(Vehicle vehicle)
		{
			_unitOfWork.VehicleRepository.Update(vehicle);
			await _unitOfWork.SaveChangesAsync();
			return true;
		}
	}
}
