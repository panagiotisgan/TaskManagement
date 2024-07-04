using FluentValidation;
using MediatR;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.Comments.Commands
{
	public class CreateCommentCommand : IRequest
	{
		public Comment Comment { get; private set; }

		public static Comment Create(Comment comment)
		{
			return new Comment
			{
				CommentText = comment.CommentText,
				IsHidden = false,
				Comments = comment.Comments,
				UserId = comment.UserId,
				AssignmentId = comment.AssignmentId
			};
		}
	}

	public class CreateCommentValidator : AbstractValidator<CreateCommentCommand>
	{
		public CreateCommentValidator()
		{
			RuleFor(x => x.Comment.UserId)
				.LessThanOrEqualTo(0)
				.WithMessage("Comment must relate with someone user.");

			RuleFor(x => x.Comment.AssignmentId)
				.LessThanOrEqualTo(0)
				.WithMessage("Comment must relate with some task.");

			RuleFor(x => x.Comment.CommentText).NotEmpty()
			.WithMessage(x => $"{x.Comment} cannot be empty.");
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
			await _commentService.CreateComment(request.Comment);
		}
	}
}
