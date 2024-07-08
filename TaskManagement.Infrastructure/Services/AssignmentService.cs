using Microsoft.EntityFrameworkCore;
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

			result.Status = Enum.Parse<Status>(assignment.Status.ToString());
			result.SeverityLevel = Enum.Parse<SeverityLevel>(assignment.SeverityLevel.ToString());
			result.Priority = Enum.Parse<Priority>(assignment.Priority.ToString());
			result.Attachements = assignment.Attachements;
			result.Description = assignment.Description;
			result.EndDate = assignment.EndDate;
			result.StartDate = assignment.StartDate;
			result.NeedBy = assignment.NeedBy;
			result.UserId = assignment.UserId;
			result.Name = assignment.Name;

			await _context.SaveChangesAsync();

			return result;
		}
	}
}
