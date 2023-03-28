using AutoMapper;
using CarMgmt.Api.Responses;
using CarMgmt.Core;
using CarMgmt.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarMgmt.Api.Controllers
{
	[Route("/api/models")]
	[ApiController]
	public class ModelsController : ControllerBase
	{
		private readonly IModel _model;
		private readonly IMapper _mapper;
		private readonly DataContext _context;


        public ModelsController(IModel model,
								IMapper mapper,
								DataContext context)
        {
			_model = model;
			_mapper = mapper;
			_context = context;
		}

		[HttpGet("models")]
		public async Task<ActionResult<IEnumerable<Model>>> GetModels()
		{
			return await _context.Models.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetModel(int id)
		{
			var model = await _model.GetModelById(id);
			var modelDto = _mapper.Map<ModelDto>(model);
			var response = new ApiResponse<ModelDto>(modelDto);

			return Ok(response);
		}

		[HttpPost("addmodel")]
		public async Task<IActionResult> PostModel(ModelDto modelDto)
		{
			var model = _mapper.Map<Model>(modelDto);

			await _model.AddModel(model);

			modelDto = _mapper.Map<ModelDto>(model);
			var response = new ApiResponse<ModelDto>(modelDto);
			return Ok(response);
		}

		[HttpPut("update")]
		public async Task<IActionResult> PutModel(int id, ModelDto modelDto)
		{
			var model = _mapper.Map<Model>(modelDto);
			model.Id = id;

			var result = await _model.UpdateModel(model);
			var response = new ApiResponse<bool>(result);

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _model.DeleteModel(id);
			var response = new ApiResponse<bool>(result);
			return Ok(response);
		}
	}
}
