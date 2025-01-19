using TaskManagement.Application.Assignments.Commands;

namespace TaskManagement.Application.Mappings
{
	public static class AssignmentMappings
	{
		public static TaskManagement.Domain.Models.Assignment ToModel(this CreateAssignmentCommand request)
		{
			return new Domain.Models.Assignment
			{
				Name = request.Name,
				Attachements = request.Attachements,
				Description = request.Description,
				EndDate = request.EndDate,
				StartDate = request.StartDate,
				NeedBy = request.NeedBy,
				UserId = request.UserId,
				Priority = request.Priority,
				SeverityLevel = request.SeverityLevel,
				Status = request.Status
			};
		}

		public static TaskManagement.Domain.Models.Assignment ToModel(this UpdateAssignmentCommand request)
		{
			return new TaskManagement.Domain.Models.Assignment
			{
				Id = request.Id,
				Name = request.Name,
				Attachements = request.Attachements,
				Description = request.Description,
				EndDate = request.EndDate,
				StartDate = request.StartDate,
				NeedBy = request.NeedBy,
				UserId = request.UserId,
				Priority = request.Priority,
				SeverityLevel = request.SeverityLevel,
				Status = request.Status
			};
		}
	}
}
