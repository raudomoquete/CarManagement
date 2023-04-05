namespace CarMgmt.Core
{
	public interface IBrand
	{
		IEnumerable<BrandDto> GetBrands();

		Task<Brand> GetBrandById(int id);

		Task<Brand> GetBrandWithModelsByBrandId(int id);

		Task AddBrand(Brand brand);

		Task<bool> UpdateBrand(Brand brand);

		Task<bool> DeleteBrand(int id);
	}
}
