using FluentValidation;
using MediatR;
using TaskManagement.Application.Mappings;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Comments.Commands
{
	public class CreateCommentCommand : IRequest
	{
		public long AssigmentId { get; private set; }
		public long UserId { get; private set; }
		public string CommentText { get; private set; } = string.Empty;
		public long? CommentId { get; private set; }


		public static CreateCommentCommand Create(long assignmentId, long userId, string text, long? commentId = null)
		{
			return new CreateCommentCommand
			{
				AssigmentId = assignmentId,
				UserId = userId,
				CommentText = text,
				CommentId = commentId
			};
		}
	}

	public class CreateCommentValidator : AbstractValidator<CreateCommentCommand>
	{
		public CreateCommentValidator()
		{
			RuleFor(x => x.UserId)
				.LessThanOrEqualTo(0)
				.WithMessage("Comment must relate with someone user.");

			RuleFor(x => x.AssigmentId)
				.LessThanOrEqualTo(0)
				.WithMessage("Comment must relate with some task.");

			RuleFor(x => x.CommentText).NotEmpty()
			.WithMessage(x => $"{x.CommentText} cannot be empty.");
		}
	}

	public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
	{
		private readonly ICommentService _commentService;

		public CreateCommentCommandHandler(ICommentService commentService)
		{
			_commentService = commentService;
		}

		//TODO Add Logger
		//private readonly ILogger
		public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
		{
			var comment = request.ToModel();
			await _commentService.CreateComment(comment);
		}
	}
}
