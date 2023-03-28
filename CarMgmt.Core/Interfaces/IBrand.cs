﻿namespace CarMgmt.Core
{
	public interface IBrand
	{
		IEnumerable<Brand> GetBrands();

		Task<Brand> GetBrandById(int id);

		Task AddBrand(Brand brand);

		Task<bool> UpdateBrand(Brand brand);

		Task<bool> DeleteBrand(int id);
	}
}