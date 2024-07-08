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
	}
}
