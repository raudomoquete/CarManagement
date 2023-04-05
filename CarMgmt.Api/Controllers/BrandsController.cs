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
		public ActionResult<IEnumerable<BrandDto>> GetBrands()
		{
			return _brand.GetBrands().ToList();

		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetBrand(int id)
		{
			var brand = await _brand.GetBrandById(id);
			var brandDto = _mapper.Map<BrandDto>(brand);
			var response = new ApiResponse<BrandDto>(brandDto);

			if (brand == null)
			{
				throw new NotFoundException($"La marca con el Id: {id} no puede ser encontrada.");
			}

			return Ok(response);
		}

		[HttpGet("GetBrandWithModels")]
		public async Task<IActionResult> GetBrandWithModels(int id)
		{
			var brand = await _brand.GetBrandWithModelsByBrandId(id);
			var brandDto = _mapper.Map<BrandWithModelsDto>(brand);
			var response = new ApiResponse<BrandWithModelsDto>(brandDto);

			return Ok(response);
		}

		[HttpPost("addBrand")]
		public async Task<IActionResult> PostBrand(BrandWithModelsDto brandDto)
		{
			var brand = _mapper.Map<Brand>(brandDto);

			await _brand.AddBrand(brand);

			brandDto = _mapper.Map<BrandWithModelsDto>(brand);
			var response = new ApiResponse<BrandWithModelsDto>(brandDto);
			return Ok(response);
		}

		[HttpPut("update")]
		public async Task<IActionResult> PutBrand(int id, BrandWithModelsDto brandDto)
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
