namespace TaskManagement.API.Mappings
{
	public static class Assignments
	{
		public static Domain.Shared.Assignment ToDto(this Domain.Models.Assignment assignment)
		{
			return new Domain.Shared.Assignment()
			{
				Id = assignment.Id,
				Description = assignment.Description,
				Name = assignment.Name,
				Priority = (int)assignment.Priority,
				SeverityLevel = (int)assignment.SeverityLevel,
				Status = (int)assignment.Status,
				NeedBy = assignment.NeedBy,
				UserId = assignment.UserId,
				StartDate = assignment.StartDate,
				EndDate = assignment.EndDate,
				Attachements = assignment.Attachements
			};
		}
	}
}
