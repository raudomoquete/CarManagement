using AutoMapper;
using CarMgmt.Api.Responses;
using CarMgmt.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarMgmt.Api.Controllers
{
	[Route("/api/status")]
	[ApiController]
	public class StatusController : ControllerBase
	{
		private readonly IStatus _status;
		private readonly IMapper _mapper;

        public StatusController(IStatus status, IMapper mapper)
        {
			_status = status;
			_mapper = mapper;
		}

		[HttpPost]
		public async Task<IActionResult> PostAsync(StatusDto statusDto)
		{
			var status = _mapper.Map<Status>(statusDto);

			await _status.InsertStatus(status);

			statusDto = _mapper.Map<StatusDto>(status);
			var response = new ApiResponse<StatusDto>(statusDto);
			return Ok(response);
		}
    }
}
