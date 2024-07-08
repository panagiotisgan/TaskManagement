using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Assignment.Commands;
using TaskManagement.Domain.Shared;

namespace TaskManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AssigmentsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AssigmentsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<ActionResult> Create([FromBody] Assignment assigment)
		{
			var request = CreateAssigmentCommand.Create(
				assigment.Name, assigment.Description,
				assigment.Priority, assigment.Status,
				assigment.SeverityLevel, assigment.NeedBy,
				assigment.StartDate, assigment.EndDate,
				assigment.UserId, assigment.Attachements);

			var result = await _mediator.Send(request);

			return Ok(result);
		}

		[HttpPut]
		public async Task<ActionResult> Update([FromBody] UpdateAssignment assignment)
		{
			throw new NotImplementedException();
		}
	}
}
