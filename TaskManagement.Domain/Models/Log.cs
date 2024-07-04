namespace TaskManagement.Domain.Models
{
	public class Log : Entity
	{
		public long AssignmentId { get; set; }
		public string PreviousTaskState { get; set; } = string.Empty;
		public DateTime ModificationDate { get; set; }
	}
}
