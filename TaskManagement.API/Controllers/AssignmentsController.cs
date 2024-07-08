using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.API.Mappings;
using TaskManagement.Application.Assignment.Commands;
using TaskManagement.Domain.Shared;

namespace TaskManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AssignmentsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AssignmentsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		[ProducesResponseType(typeof(Domain.Shared.Assignment), StatusCodes.Status200OK)]
		public async Task<ActionResult> Create([FromBody] Assignment assigment)
		{
			var request = CreateAssigmentCommand.Create(
				assigment.Name, assigment.Description,
				assigment.Priority, assigment.Status,
				assigment.SeverityLevel, assigment.NeedBy,
				assigment.StartDate, assigment.EndDate,
				assigment.UserId, assigment.Attachements);

			var result = await _mediator.Send(request);

			return Ok(result.ToDto());
		}

		[HttpPut]
		[ProducesResponseType(typeof(Domain.Shared.Assignment), StatusCodes.Status200OK)]
		public async Task<ActionResult> Update([FromBody] Assignment assignment)
		{
			var request = UpdateAssignmentCommand.Create(
				assignment.Id, assignment.Name,
				assignment.Description, assignment.Priority,
				assignment.Status, assignment.SeverityLevel,
				assignment.NeedBy, assignment.StartDate,
				assignment.EndDate, assignment.UserId,
				assignment.Attachements);

			var result = await _mediator.Send(request);

			return Ok(result.ToDto());
		}
	}
}
