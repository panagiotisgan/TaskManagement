using TaskManagement.Domain.Common;
using TaskManagement.Domain.Enums;
using TaskManagement.Domain.Models;

namespace TaskManagement.Domain.Interfaces.Assigment
{
	public interface IAssigmentService
	{
		public Task<Assignment> Create(Assignment assignment);
		public Task<Assignment> Update(long id, Assignment assignment);
		public Task<PagedEnumerable<Assignment>> GetPagedAssigments(string? name, string? userId, string? priority, string? severityLevel, string? status, int page, int pageSize);
	}
}
