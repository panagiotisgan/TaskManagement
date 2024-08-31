using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Models
{
	public class Assignment : Entity
	{
		public string Name { get; set; } = string.Empty;
		public string? UserId { get; set; }
		public string? Description { get; set; }
		public Priority Priority { get; set; }
		public Status Status { get; set; }
		public SeverityLevel SeverityLevel { get; set; }
		//Deadline
		public string? NeedBy { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public byte[]? Attachements { get; set; }
		public IEnumerable<Comment>? Comments { get; set; }
		public IEnumerable<Log>? Logs { get; set; }
		public User User { get; set; }

	}
}
