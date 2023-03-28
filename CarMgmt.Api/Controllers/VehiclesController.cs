using AutoMapper;
using CarMgmt.Api.Responses;
using CarMgmt.Core;
using CarMgmt.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CarMgmt.Api.Controllers
{
	[Route("/api/vehicles")]
	[ApiController]
	public class VehiclesController : ControllerBase
	{
		private readonly IVehicle _vehicle;
		private readonly IMapper _mapper;
		private readonly DataContext _context;

        public VehiclesController(IVehicle vehicle,
								  IMapper mapper,
								  DataContext context)
        {
			_vehicle = vehicle;
			_mapper = mapper;
			_context = context;
		}

		[HttpGet("vehicles")]
		public async Task<ActionResult<IEnumerable<Vehicle>>> GetAllVehicles()
		{
			return await _context.Vehicles.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetVehicle(int id)
		{
			var vehicle = await _vehicle.GetVehicleById(id);
			var vehicleDto = _mapper.Map<VehicleDto>(vehicle);
			var response = new ApiResponse<VehicleDto>(vehicleDto);

			return Ok(response);
		}

		[HttpPost("addVehicle")]
		public async Task<IActionResult> PostVehicle(VehicleDto vehicleDto)
		{
			var vehicle = _mapper.Map<Vehicle>(vehicleDto);

			await _vehicle.AddVehicle(vehicle);

			vehicleDto = _mapper.Map<VehicleDto>(vehicle);
			var response = new ApiResponse<VehicleDto>(vehicleDto);
			return Ok(response);
		}


		[HttpPut("update")]
		public async Task<IActionResult> PutVehicle(int id, VehicleDto vehicleDto)
		{
			var vehicle = _mapper.Map<Vehicle>(vehicleDto);
			vehicle.Id = id;

			var result = await _vehicle.UpdateVehicle(vehicle);
			var response = new ApiResponse<bool>(result);

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _vehicle.DeleteVehicle(id);
			var response = new ApiResponse<bool>(result);
			return Ok(response);
		}
	}
}
