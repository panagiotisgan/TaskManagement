using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Models
{
    public class User : Entity
    {
        public string Email { get; set; } = string.Empty;
        public string? DisplayName { get; set; }
        public string PasswordHashed { get; set; } = string.Empty;
        public ViewLevel ViewLevel { get; set; }
        public IEnumerable<Task> Tasks { get; set; } = Enumerable.Empty<Task>();
        public IEnumerable<Team> Teams { get; set; } = Enumerable.Empty<Team>();
        public UserTask UserTask { get; set; }
        public TeamUser TeamUser { get; set; }
    }
}
