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

		public IEnumerable<Brand> GetBrands()
		{
			return _unitOfWork.BrandRepository.GetAll();
		}

		public async Task<bool> UpdateBrand(Brand brand)
		{
			_unitOfWork.BrandRepository.Update(brand);
			await _unitOfWork.SaveChangesAsync();
			return true;
		}
	}
}
