namespace TaskManagement.Domain.Shared
{
	public class Assignment
	{
		public string Name { get; set; } = string.Empty;
		public long? UserId { get; set; }
		public string? Description { get; set; }
		public int Priority { get; set; }
		public int Status { get; set; }
		public int SeverityLevel { get; set; }
		public string? NeedBy { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public byte[]? Attachements { get; set; }
	}
}
