using TaskManagement.Domain.Models;

namespace TaskManagement.Domain.Interfaces
{
	public interface ICommentService
	{
		public Task CreateComment(Comment comment);
		public Task<Comment> GetComment(long id);
		public Task HideComment(long commentId);

	}
}
