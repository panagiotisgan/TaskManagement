using FluentValidation;
using MediatR;
using TaskManagement.Application.Mappings;
using TaskManagement.Domain.Enums;
using TaskManagement.Domain.Interfaces.Assigment;

namespace TaskManagement.Application.Assignment.Commands
{
	public class CreateAssignmentCommand : IRequest<TaskManagement.Domain.Models.Assignment>
	{
		public string Name { get; private set; } = string.Empty;
		public string? UserId { get; private set; }
		public string? Description { get; private set; }
		public Priority Priority { get; private set; }
		public Status Status { get; private set; }
		public SeverityLevel SeverityLevel { get; private set; }
		public string? NeedBy { get; private set; }
		public DateTime? StartDate { get; private set; }
		public DateTime? EndDate { get; private set; }
		public byte[]? Attachements { get; private set; }

		public static CreateAssignmentCommand Create(string name, string description, int priority, int status, int severityLevel, string needBy, DateTime? startDate, DateTime? endDate, string? userId, byte[]? attatchements)
		{
			return new CreateAssignmentCommand
			{
				Name = name,
				Description = description,
				EndDate = endDate,
				StartDate = startDate,
				NeedBy = needBy,
				Priority = Enum.Parse<Priority>(priority.ToString()),
				SeverityLevel = Enum.Parse<SeverityLevel>(severityLevel.ToString()),
				Status = Enum.Parse<Status>(status.ToString()),
				UserId = userId,
				Attachements = attatchements
			};
		}
	}

	public class CreateAssignmentValidator : AbstractValidator<CreateAssignmentCommand>
	{
		public CreateAssignmentValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage(x => $"{nameof(x.Name)} couldn't be null or white space.");

			RuleFor(x => (int)x.Priority)
				.InclusiveBetween(1, 3)
				.WithMessage("Invalid Priority range");

            RuleFor(x => (int)x.SeverityLevel)
                .InclusiveBetween(1, 5)
                .WithMessage(x=> $"Invalid {nameof(x.SeverityLevel)} range");

            RuleFor(x => (int)x.Status)
                .InclusiveBetween(1, 5)
                .WithMessage(x => $"Invalid {nameof(x.Status)} range");
        }
	}
	public class CreateAssigmentCommandHandler : IRequestHandler<CreateAssignmentCommand, TaskManagement.Domain.Models.Assignment>
	{
		private readonly IAssigmentService _assigmentService;

		public CreateAssigmentCommandHandler(IAssigmentService assigmentService)
		{
			_assigmentService = assigmentService;
		}

		public async Task<TaskManagement.Domain.Models.Assignment> Handle(CreateAssignmentCommand request, CancellationToken cancellationToken)
		{
			var assigment = request.ToModel();
			var result = await _assigmentService.Create(assigment);

			return result;
		}
	}
}
