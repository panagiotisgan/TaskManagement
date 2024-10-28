using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.API.Mappings;
using TaskManagement.Application.Comments.Commands;
using TaskManagement.Application.Comments.Queries;
using TaskManagement.Domain.Shared;

namespace TaskManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CommentsController(IMediator mediator)
		{
			_mediator = mediator;
		}



		[HttpGet("GetComments/{assignmentId}")]
        [ProducesResponseType(typeof(IEnumerable<Comment>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetComments(long assignmentId)
		{
			throw new NotImplementedException();
		}

		[HttpPut("hideComment/{commentId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> HideComment([FromRoute] long commentId)
		{
			var request = HideCommentCommand.Create(commentId);

			await _mediator.Send(request);

			return Ok();
		}

		[HttpPost]
		public async Task<ActionResult> CreateComment([FromBody] TaskManagement.Domain.Shared.Comment comment, [FromQuery] long? commentId)
		{
			var command = CreateCommentCommand.Create(comment.AssignmentId, comment.UserId, comment.CommentText, commentId);
			await _mediator.Send(command);

			return Ok();
		}

		[HttpGet("{commentId}")]
        [ProducesResponseType(typeof(Domain.Shared.GetComment),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetComment([FromRoute]long commentId)
		{
			var request = GetCommentById.Create(commentId);

			var result = await _mediator.Send(request);

			return Ok(result.ToDto());
        }
	}
}
