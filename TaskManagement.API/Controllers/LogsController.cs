using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Loggers.Commands;

namespace TaskManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LogsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LogsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<ActionResult> Log([FromQuery] long assigmentId)
		{
			var request = CreateLogCommand.Create(assigmentId);

			var result = await _mediator.Send(request);

			return Ok(result);
		}

	}
}
