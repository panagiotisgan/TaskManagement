using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Common;
using TaskManagement.Domain.Enums;
using TaskManagement.Domain.Interfaces.Assigment;
using TaskManagement.Domain.Models;
using TaskManagement.Infrastructure.Context;

namespace TaskManagement.Infrastructure.Services
{
	public class AssignmentService : IAssigmentService
	{
		private readonly TaskManagementContext _context;

		public AssignmentService(TaskManagementContext context)
		{
			_context = context;
		}

		public async Task<Assignment> Create(Assignment assignment)
		{
			_context.Assignments.Add(assignment);
			await _context.SaveChangesAsync();

			return assignment;
		}

		public async Task<Assignment> Update(long id, Assignment assignment)
		{
			var result = await _context.Assignments.SingleOrDefaultAsync(x => x.Id == id);

			if (result == null)
				throw new Exception($"The assignment with Id: {assignment.Id} does not exist");

			result.Status = Enum.Equals(assignment.Status, result.Status) || (int)assignment.Status == 0 ? result.Status : assignment.Status;
			result.SeverityLevel = Enum.Equals(assignment.SeverityLevel, result.SeverityLevel) || (int)assignment.SeverityLevel == 0 ? result.SeverityLevel : assignment.SeverityLevel;
			result.Priority = Enum.Equals(assignment.Priority, result.Priority) || (int)assignment.Priority == 0 ? result.Priority : assignment.Priority;
			result.Attachements = assignment.Attachements ?? result.Attachements;
			result.Description = assignment.Description ?? result.Description;
			result.EndDate = assignment.EndDate ?? result.EndDate;
			result.StartDate = assignment.StartDate ?? result.StartDate;
			result.NeedBy = assignment.NeedBy ?? result.NeedBy;
			result.UserId = assignment.UserId ?? result.UserId;
			result.Name = assignment.Name ?? result.Name;

			await _context.SaveChangesAsync();

			return result;
		}

		public async Task<PagedEnumerable<Assignment>> GetPagedAssigments(string? name, string? userId, string? priority, string? severityLevel, string? status, int page, int pageSize)
		{
			int total = 0;
			var dbSet = _context.Assignments.AsQueryable();
			var baseQuery = !string.IsNullOrWhiteSpace(name) ? dbSet.Where(x => x.Name == name) : dbSet;
			baseQuery = !string.IsNullOrWhiteSpace(userId) ? baseQuery.Where(x => x.UserId == userId) : baseQuery;
			baseQuery = Enum.TryParse(priority, true, out Priority priorityValue) ? baseQuery.Where(x => x.Priority == priorityValue) : baseQuery;
			baseQuery = Enum.TryParse(severityLevel, true, out SeverityLevel severityValue) ? baseQuery.Where(x => x.SeverityLevel == severityValue) : baseQuery;
			baseQuery = Enum.TryParse(status, true, out Status statusValue) ? baseQuery.Where(x => x.Status == statusValue) : baseQuery;

			total = await baseQuery
							.CountAsync();

			int pageCalculate = (page - 1) * pageSize;

			return new PagedEnumerable<Assignment>
			{
				Items = await baseQuery
						.Skip(pageCalculate)
						.Take(pageSize)
						.OrderByDescending(x => x.Id)
						.ToArrayAsync(),
				Total = total,
				Page = (page + 1),
				PageSize = pageSize
			};
		}
	}
}
