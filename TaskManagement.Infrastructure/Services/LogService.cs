using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TaskManagement.Domain.Interfaces.Log;
using TaskManagement.Domain.Models;
using TaskManagement.Infrastructure.Context;

namespace TaskManagement.Infrastructure.Services
{
	public class LogService : ILogService
	{
		private readonly TaskManagementContext _context;

		public LogService(TaskManagementContext context)
		{
			_context = context;
		}

		public async Task<long> CreateLog(long assigmentId)
		{
			var currentAssigmentState = await _context.Assignments.FirstOrDefaultAsync(x => x.Id == assigmentId);

			if (currentAssigmentState is null)
				throw new Exception($"The task with Id: {assigmentId} not exist");

			var logEntity = new Log { AssignmentId = assigmentId, ModificationDate = DateTime.UtcNow, PreviousTaskState = JsonConvert.SerializeObject(currentAssigmentState) };

			//_context.Logs.Add(logEntity);

			var numberOfWrites = await _context.SaveChangesAsync();

			return numberOfWrites > 0 ? assigmentId : numberOfWrites;
		}
	}
}
