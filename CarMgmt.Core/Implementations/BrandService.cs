using System.Reflection;

namespace CarMgmt.Core
{
	public class BrandService : IBrand
	{
		private readonly IUnitOfWork _unitOfWork;


		public BrandService(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}


        public async Task AddBrand(Brand brand)
		{
			await _unitOfWork.BrandRepository.Add(brand);
			await _unitOfWork.SaveChangesAsync();
		}


		public async Task<bool> DeleteBrand(int id)
		{
			await _unitOfWork.BrandRepository.Delete(id);
			return true;
		}


		public Task<Brand> GetBrandById(int id)
		{
			return _unitOfWork.BrandRepository.GetById(id);
		}


		public async Task<Brand> GetBrandWithModelsByBrandId(int id)
		{
			try
			{
				var tmpResult = _unitOfWork.ModelRepository.GetAll();

				for (int i = 0; i < tmpResult.ToList().Count; i++)
				{
					var tmpBrand = new BrandWithModelsDto()
					{
						Models = new List<ModelDto>()
						{
							new ModelDto
							{
								Name = tmpResult.First().Name,
							}
						}
					};

				}
			}
			catch
			{
				throw new NotFoundException("No se encuentran los modelos de esta marca o la marca no existe");
			}

			return await _unitOfWork.BrandRepository.GetById(id);
		}


		public IEnumerable<BrandDto> GetBrands()
		{
			var tmpResult = new List<BrandDto>();
			var brandContext = _unitOfWork.BrandRepository.GetAll();

			for (int i = 0; i < brandContext.ToList().Count; i++)
			{

				tmpResult = new List<BrandDto>()
				{
					new BrandDto
					{
						Id = brandContext.First().Id,
						Name = brandContext.First().Name,
					}
				};
			
			}

			return tmpResult;
		}


		public async Task<bool> UpdateBrand(Brand brand)
		{

			_unitOfWork.BrandRepository.Update(brand);
			await _unitOfWork.SaveChangesAsync();
			return true;
		}
	}
}
