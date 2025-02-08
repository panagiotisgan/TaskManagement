using TaskManagement.Domain.Common;
using TaskManagement.Domain.Models;

namespace TaskManagement.Domain.Interfaces.Assigment
{
	public interface IAssigmentService
	{
		public Task<Assignment> Create(Assignment assignment);
		public Task<Assignment> Update(long id, Assignment assignment);
		public Task SetAssignee(long assignmentId, string assigneeId, CancellationToken cancellationToken);
		public Task SetAssignmentAsDeleted(long assignmentId, CancellationToken cancellationToken);
		public Task<PagedEnumerable<Assignment>> GetPagedAssigments(string? name, string? userId, string? priority, string? severityLevel, string? status, int page, int pageSize);
	}
}
