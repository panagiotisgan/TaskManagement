using TaskManagement.Domain.Models;

namespace TaskManagement.API.Mappings
{
    public static class CommentsMappings
    {
        public static Domain.Shared.GetComment ToDto(this Comment comment)
        {
            return new Domain.Shared.GetComment
            {
                UserId = comment.UserId,
                CommentId = comment.Id,
                AssignmentId = comment.AssignmentId,
                CommentText = comment.CommentText,
                CreatedAt = comment.CreatedAt,
                UpdatedAt = comment.UpdatedAt,
                IsHidden = comment.IsHidden
            };
        }
    }
}
