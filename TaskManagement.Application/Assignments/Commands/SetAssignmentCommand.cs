using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskManagement.Domain.Interfaces.Assigment;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.Assignments.Commands
{
	public record SetAssignmentCommand : IRequest
	{
		public string AssignmentId { get; private set; } = string.Empty;
		public string AssigneeId { get; private set; } = string.Empty;

		public static SetAssignmentCommand Create(string assignmentId, string assigneeId)
		{
			return new SetAssignmentCommand
			{
				AssigneeId = assigneeId,
				AssignmentId = assignmentId
			};
		}
	}

	public class SetAssignmentCommandHanlder : IRequestHandler<SetAssignmentCommand>
	{
		private readonly IAssigmentService _assigmentService;
		private readonly IUserStore<User> _identityUserService;
		public SetAssignmentCommandHanlder(IAssigmentService assigmentService, IUserStore<User> identityUserService)
		{
			_assigmentService = assigmentService;
			_identityUserService = identityUserService;
		}

		public async Task Handle(SetAssignmentCommand request, CancellationToken cancellationToken)
		{
			var getAssignee = await _identityUserService.FindByIdAsync(request.AssigneeId, cancellationToken);

			if (getAssignee == null)
				throw new Exception($"User with Id: {request.AssigneeId} not found");

			await _assigmentService.SetAssignee(Int64.Parse(request.AssignmentId), request.AssigneeId, cancellationToken);
		}
	}
}
