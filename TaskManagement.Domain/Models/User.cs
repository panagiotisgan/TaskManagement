using Microsoft.AspNetCore.Identity;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Models
{
	public class User : IdentityUser
	{
		public string? DisplayName { get; set; }
		public ViewLevel ViewLevel { get; set; }
		public IEnumerable<Assignment> Assignments { get; set; } = Enumerable.Empty<Assignment>();
		public IEnumerable<Team> Teams { get; set; } = Enumerable.Empty<Team>();
		public IEnumerable<Comment> Comments { get; set; } = Enumerable.Empty<Comment>();
		public TeamUser TeamUser { get; set; }
	}
}
