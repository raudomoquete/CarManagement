using AutoMapper;
using CarMgmt.Api.Responses;
using CarMgmt.Core;
using CarMgmt.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarMgmt.Api.Controllers
{
	[Route("/api/brands")]
	[ApiController]
	public class BrandsController : ControllerBase
	{
		private readonly IBrand _brand;
		private readonly IMapper _mapper;
		private readonly DataContext _context;

        public BrandsController(IBrand brand,
								IMapper mapper,
								DataContext context)
        {
			_brand = brand;
			_mapper = mapper;
			_context = context;
		}

		[HttpGet("brands")]
		public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
		{
			return await _context.Brands.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetBrand(int id)
		{
			var brand = await _brand.GetBrandById(id);
			var brandDto = _mapper.Map<BrandDto>(brand);
			var response = new ApiResponse<BrandDto>(brandDto);

			return Ok(response);
		}

		[HttpPost("addBrand")]
		public async Task<IActionResult> PostBrand(BrandDto brandDto)
		{
			var brand = _mapper.Map<Brand>(brandDto);

			await _brand.AddBrand(brand);

			brandDto = _mapper.Map<BrandDto>(brand);
			var response = new ApiResponse<BrandDto>(brandDto);
			return Ok(response);
		}

		[HttpPut("update")]
		public async Task<IActionResult> PutBrand(int id, BrandDto brandDto)
		{
			var brand = _mapper.Map<Brand>(brandDto);
			brand.Id = id;

			var result = await _brand.UpdateBrand(brand);
			var response = new ApiResponse<bool>(result);

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _brand.DeleteBrand(id);
			var response = new ApiResponse<bool>(result);
			return Ok(response);
		}
	}
}
