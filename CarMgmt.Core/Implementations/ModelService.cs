﻿namespace CarMgmt.Core
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
				throw new NotFoundException("Esta marca no existe");
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

		public IEnumerable<Model> GetModels()
		{
			return _unitOfWork.ModelRepository.GetAll();
		}

		public async Task<bool> UpdateModel(Model model)
		{
			_unitOfWork.ModelRepository.Update(model);
			await _unitOfWork.SaveChangesAsync();
			return true;
		}
	}
}
