using TaskManagement.Application.Comments.Commands;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.Mappings
{
	public static class CommentMappings
	{
		public static Comment ToModel(this CreateCommentCommand command)
		{
			return new Comment
			{
				IsHidden = false,
				//UserId = command.UserId,
				AssignmentId = command.AssigmentId,
				CommentText = command.CommentText
			};
		}
	}
}
