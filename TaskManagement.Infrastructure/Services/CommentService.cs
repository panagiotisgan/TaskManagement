using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Domain.Models;
using TaskManagement.Infrastructure.Context;

namespace TaskManagement.Infrastructure.Services
{
	public class CommentService : ICommentService
	{
		private readonly TaskManagementContext _taskManagementContext;

		public CommentService(TaskManagementContext context)
		{
			_taskManagementContext = context;
		}

		public async Task CreateComment(Comment comment)
		{
			_taskManagementContext.Comments.Add(comment);
			await _taskManagementContext.SaveChangesAsync();
		}

		public async Task HideComment(long commentId)
		{
			var result = await _taskManagementContext.Comments.FirstOrDefaultAsync(c => c.Id == commentId);

			if (result == null)
				throw new Exception($"The comment with id:{commentId} not found");

			result.IsHidden = true;

			await _taskManagementContext.SaveChangesAsync();
		}
	}
}
