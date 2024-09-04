namespace TaskManagement.Domain.Models
{
	public class Team : Entity
	{
		public string Name { get; set; } = string.Empty;
		public IEnumerable<User> Users { get; set; } = Enumerable.Empty<User>();
		public TeamUser TeamUser { get; set; }
	}
}
