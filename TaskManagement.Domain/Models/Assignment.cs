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

	#region enums
	public enum Priority
	{
		High = 1,
		Medium = 2,
		Low = 3
	}

	public enum Status
	{
		Open = 1,
		InProgress = 2,
		Hold = 3,
		WaitingForApproval = 4,
		Closed = 5
	}

	public enum SeverityLevel
	{
		Severe = 1,
		High = 2,
		Moderate = 3,
		Low = 4,
		NA = 5
	}
	#endregion
}
