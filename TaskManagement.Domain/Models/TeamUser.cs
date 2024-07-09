namespace TaskManagement.Domain.Models
{
	public class TeamUser
	{
		public long TeamId { get; set; }
		public Guid UserId { get; set; }
	}
}
