using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.Models;

namespace TaskManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentsController : ControllerBase
	{
		private readonly IMediator mediator;

		public CommentsController(IMediator mediator)
		{
			this.mediator = mediator;
		}


		[HttpPost]
		public async Task<ActionResult> CreateComment([FromBody] Comment comment)
		{
			throw new NotImplementedException();
		}

		[HttpGet]
		public ActionResult TestEndpoint()
		{
			return Ok("working");
		}
	}
}
