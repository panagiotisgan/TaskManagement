using TaskManagement.Domain.Models;

namespace TaskManagement.Domain.Interfaces
{
	public interface ICommentService
	{
		public Task CreateComment(Comment comment);
	}
}
