using FluentValidation;
using MediatR;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Assignments.Queries
{
	public record GetAssignment : IRequest<TaskManagement.Domain.Models.Assignment>
	{
		public string Id { get; private set; } = string.Empty;

		public static GetAssignment Create(string id)
		{
			return new GetAssignment { Id = id };
		}
	}

	public class GetAssignmentValidator : AbstractValidator<GetAssignment>
	{
		public GetAssignmentValidator()
		{
			RuleFor(x => Int64.Parse(x.Id))
				.GreaterThan(0)
				.WithMessage(x => $"{nameof(x.Id)} must be greater than zero");
		}
	}

	public class GetAssignmentHandler : IRequestHandler<GetAssignment, TaskManagement.Domain.Models.Assignment>
	{
		private readonly IGenericReadRepository<TaskManagement.Domain.Models.Assignment> _assignmentServiceRepo;

		public GetAssignmentHandler(IGenericReadRepository<Domain.Models.Assignment> assignmentServiceRepo)
		{
			_assignmentServiceRepo = assignmentServiceRepo;
		}

		public async Task<Domain.Models.Assignment> Handle(GetAssignment request, CancellationToken cancellationToken)
		{
			return await _assignmentServiceRepo.GetById(request.Id);
		}
	}
}
