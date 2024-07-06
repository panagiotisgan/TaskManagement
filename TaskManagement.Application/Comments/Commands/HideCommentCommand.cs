using FluentValidation;
using MediatR;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Comments.Commands
{
	public class HideCommentCommand : IRequest
	{
		public long Id { get; private set; }

		public static HideCommentCommand Create(long id)
		{
			return new HideCommentCommand
			{
				Id = id
			};
		}
	}

	public class HideCommentValidator : AbstractValidator<HideCommentCommand>
	{
		public HideCommentValidator()
		{
			RuleFor(x => x.Id)
				.LessThanOrEqualTo(0)
				.WithMessage("Comment Id must be greater than zero");
		}
	}

	public class HideCommentCommandHandler : IRequestHandler<HideCommentCommand>
	{
		private readonly ICommentService _commentService;


		public HideCommentCommandHandler(ICommentService commentService)
		{
			_commentService = commentService;
		}

		public async Task Handle(HideCommentCommand request, CancellationToken cancellationToken)
		{
			await _commentService.HideComment(request.Id);
		}
	}
}
