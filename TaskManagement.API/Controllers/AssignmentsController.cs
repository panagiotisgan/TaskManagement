using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.API.Mappings;
using TaskManagement.Application.Assignment.Commands;
using TaskManagement.Application.Assignment.Queries;
using TaskManagement.Domain.Shared;

namespace TaskManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AssignmentsController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IValidator<GetAssignment> _validator;
		private readonly IValidator<CreateAssignmentCommand> _createValidator;
		private readonly IValidator<UpdateAssignmentCommand> _updateValidator;

        public AssignmentsController(IMediator mediator, 
			IValidator<GetAssignment> validator, 
			IValidator<CreateAssignmentCommand> createValidator, 
			IValidator<UpdateAssignmentCommand> updateValidator)
        {
            _mediator = mediator;
            _validator = validator;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Domain.Shared.Assignment>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetMany()
		{
			var result = await _mediator.Send(new GetAssignments());

			return Ok(result.ToDto());
		}

		[HttpGet("assignment/{id}")]
        [ProducesResponseType(typeof(Domain.Shared.Assignment), StatusCodes.Status200OK)]
		public async Task<ActionResult> Get([FromRoute] string id)
		{
			var request = GetAssignment.Create(id);

			var validationResult = await _validator.ValidateAsync(request);

			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.ToDictionary());
            }

            var result = await _mediator.Send(request);

			return Ok(result.ToDto());
		}

        [HttpPost]
		[ProducesResponseType(typeof(Domain.Shared.Assignment), StatusCodes.Status200OK)]
		public async Task<ActionResult> Create([FromBody] Assignment assigment)
		{
			var request = CreateAssignmentCommand.Create(
				assigment.Name, assigment.Description,
				assigment.Priority, assigment.Status,
				assigment.SeverityLevel, assigment.NeedBy,
				assigment.StartDate, assigment.EndDate,
				assigment.UserId, assigment.Attachements);

			var validationResult = _createValidator.Validate(request);

			if (!validationResult.IsValid) 
			{
				return BadRequest(validationResult?.ToDictionary());
			}

			var result = await _mediator.Send(request);

			return Ok(result.ToDto());
		}

		[HttpPut("update/{id}")]
		[ProducesResponseType(typeof(Domain.Shared.Assignment), StatusCodes.Status200OK)]
		public async Task<ActionResult> Update([FromBody] Assignment assignment, string id)
		{
			var request = UpdateAssignmentCommand.Create(
				Convert.ToInt64(id), assignment.Name,
				assignment.Description, assignment.Priority,
				assignment.Status, assignment.SeverityLevel,
				assignment.NeedBy, assignment.StartDate,
				assignment.EndDate, assignment.UserId,
				assignment.Attachements);

			var validatorReults = _updateValidator.Validate(request);

            if (!validatorReults.IsValid)
            {
				return BadRequest(validatorReults?.ToDictionary());
            }

            var result = await _mediator.Send(request);

			return Ok(result.ToDto());
		}
	}
}
