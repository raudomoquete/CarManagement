namespace CarMgmt.Core
{
	public class StatusService : IStatus
	{
		private readonly IUnitOfWork _unitOfWork;

		public StatusService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task InsertStatus(Status status)
		{
			await _unitOfWork.StatusRepository.Add(status);
			await _unitOfWork.SaveChangesAsync();
		}
	}
}
