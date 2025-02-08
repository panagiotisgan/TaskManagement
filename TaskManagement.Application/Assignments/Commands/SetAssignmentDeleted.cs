using MediatR;
using TaskManagement.Domain.Interfaces.Assigment;

namespace TaskManagement.Application.Assignments.Commands
{
	public record SetAssignmentDeleted : IRequest
	{
		public string Id { get; private set; } = string.Empty;

		public static SetAssignmentDeleted Create(string id)
		{
			return new SetAssignmentDeleted { Id = id };
		}
	}

	public class SetAssignmentDeletedCommandHandler : IRequestHandler<SetAssignmentDeleted>
	{
		private readonly IAssigmentService _assigmentService;

		public SetAssignmentDeletedCommandHandler(IAssigmentService assigmentService)
		{
			_assigmentService = assigmentService;
		}

		public async Task Handle(SetAssignmentDeleted request, CancellationToken cancellationToken)
		{
			await _assigmentService.SetAssignmentAsDeleted(Int64.Parse(request.Id), cancellationToken);
		}
	}
}
