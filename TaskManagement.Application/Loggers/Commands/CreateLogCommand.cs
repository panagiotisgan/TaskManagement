using FluentValidation;
using MediatR;
using TaskManagement.Domain.Interfaces.Logger;

namespace TaskManagement.Application.Logs.Commands
{
	public class CreateLogCommand : IRequest<long>
	{
		public long AssigmentId { get; private set; }

		public static CreateLogCommand Create(long id)
		{
			return new CreateLogCommand
			{
				AssigmentId = id
			};
		}
	}

	public class CreateLogValidator : AbstractValidator<CreateLogCommand>
	{
		public CreateLogValidator()
		{
			RuleFor(x => x.AssigmentId)
				.LessThanOrEqualTo(0)
				.WithMessage("Assigment Id must be greater than zero.");
		}
	}

	public class CreateLogCommandHandler : IRequestHandler<CreateLogCommand, long>
	{
		private readonly ILogService _logService;

		public CreateLogCommandHandler(ILogService logService)
		{
			_logService = logService;
		}

		public async Task<long> Handle(CreateLogCommand request, CancellationToken cancellationToken)
		{
			return await _logService.CreateLog(request.AssigmentId);
		}
	}
}
