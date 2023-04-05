namespace CarMgmt.Core
{
	public class ModelService : IModel
	{
		private readonly IUnitOfWork _unitOfWork;

		public ModelService(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}

		public async Task AddModel(Model model)
		{
			var brand = await _unitOfWork.BrandRepository.GetById(model.BrandId);
			if (brand == null)
			{
				throw new NotFoundException($"La marca con el Id: {model.BrandId} no puede ser encontrada.");
			}
			var vehicleBrand = await _unitOfWork.BrandRepository.GetById(model.BrandId);
			_unitOfWork.BrandRepository.Update(vehicleBrand);

			await _unitOfWork.ModelRepository.Add(model);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task<bool> DeleteModel(int id)
		{
			await _unitOfWork.ModelRepository.Delete(id);
			return true;
		}

		public Task<Model> GetModelById(int id)
		{
			return _unitOfWork.ModelRepository.GetById(id);
		}

		public IEnumerable<ModelDto> GetModels()
		{
			try
			{
				var tmpModel = new List<ModelDto>();
				var modelContext = _unitOfWork.ModelRepository.GetAll();

				for (int i = 0; i < modelContext.ToList().Count; i++)
				{
					tmpModel = new List<ModelDto>()
					{
						new ModelDto()
						{
							Id = modelContext.First().Id,
							Name = modelContext.First().Name,
							BrandId = modelContext.First().BrandId,
						}
					};
				}

				return tmpModel;
			}
			catch
			{
				throw new NotFoundException("No se encuentra la marca a la que pertenecen los modelos o la marca no existe");
			}
		}

		public async Task<bool> UpdateModel(Model model)
		{
			_unitOfWork.ModelRepository.Update(model);
			await _unitOfWork.SaveChangesAsync();
			return true;
		}
	}
}
