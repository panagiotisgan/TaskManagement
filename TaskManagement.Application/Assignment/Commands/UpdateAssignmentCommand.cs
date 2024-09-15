using FluentValidation;
using MediatR;
using TaskManagement.Application.Mappings;
using TaskManagement.Domain.Enums;
using TaskManagement.Domain.Interfaces.Assigment;

namespace TaskManagement.Application.Assignment.Commands
{
	public class UpdateAssignmentCommand : IRequest<TaskManagement.Domain.Models.Assignment>
	{
		public long Id { get; private set; }
		public string? Name { get; private set; }
		public string? UserId { get; private set; }
		public string? Description { get; private set; }
		public Priority Priority { get; private set; }
		public Status Status { get; private set; }
		public SeverityLevel SeverityLevel { get; private set; }
		public string? NeedBy { get; private set; }
		public DateTime? StartDate { get; private set; }
		public DateTime? EndDate { get; private set; }
		public byte[]? Attachements { get; private set; }

		private UpdateAssignmentCommand(long id, string? name, string? userId, string? description, int priority, int status, int severityLevel, string? needBy, DateTime? startDate, DateTime? endDate, byte[] attachements)
		{
			Id = id;
			Name = name;
			UserId = userId;
			Description = description;
			Attachements = attachements;
			Priority = Enum.Parse<Priority>(priority.ToString());
			Status = Enum.Parse<Status>(status.ToString());
			SeverityLevel = Enum.Parse<SeverityLevel>(severityLevel.ToString());
			StartDate = startDate;
			EndDate = endDate;
		}

		public static UpdateAssignmentCommand Create(long id, string? name, string? description, int priority, int status, int severityLevel, string? needBy, DateTime? startDate, DateTime? endDate, string? userId, byte[]? attatchements)
		{
			return new UpdateAssignmentCommand(id, name, userId, description, priority, status, severityLevel, needBy, startDate, endDate, attatchements);
		}

	}

	public class UpdateAssignmentValidatror : AbstractValidator<UpdateAssignmentCommand>
	{
		public UpdateAssignmentValidatror()
		{
			RuleFor(x => (int)x.Priority)
				.GreaterThan(3)
				.WithMessage("Invalid Priority range");

			RuleFor(x => (int)x.SeverityLevel)
				.GreaterThan(5)
				.WithMessage(x => $"Invalid {nameof(x.SeverityLevel)} range");

			RuleFor(x => (int)x.Status)
				.GreaterThan(5)
				.WithMessage(x => $"Invalid {nameof(x.Status)} range");
		}
	}


	public class UpdateAssignmentCommandHandler : IRequestHandler<UpdateAssignmentCommand, TaskManagement.Domain.Models.Assignment>
	{
		private readonly IAssigmentService _assigmentService;

		public UpdateAssignmentCommandHandler(IAssigmentService assigmentService)
		{
			_assigmentService = assigmentService;
		}

		public async Task<Domain.Models.Assignment> Handle(UpdateAssignmentCommand request, CancellationToken cancellationToken)
		{
			var model = request.ToModel();
			return await _assigmentService.Update(request.Id, model);
		}
	}
}
