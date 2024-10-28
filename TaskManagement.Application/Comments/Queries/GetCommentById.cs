using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.Comments.Queries
{
    public record GetCommentById : IRequest<Comment>
    {
        public long CommentId { get; private set; }

        private GetCommentById() { }

        public static GetCommentById Create(long id)
        {
            return new GetCommentById { CommentId = id };
        }
    }

    public class GetCommentIdValidator : AbstractValidator<GetCommentById>
    {
        public GetCommentIdValidator()
        {
            RuleFor(x => x.CommentId)
                .LessThanOrEqualTo(0)
                .WithMessage(x=>$"{nameof(x.CommentId)} must be greater than zero");

        }
    }

    public class GetCommentByIdHandler : IRequestHandler<GetCommentById, Comment>
    {
        private readonly ICommentService _commentService;

        public GetCommentByIdHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }


        public async Task<Comment> Handle(GetCommentById request, CancellationToken cancellationToken)
        {
            var comment = await _commentService.GetComment(request.CommentId);

            return comment;
        }
    }
}
