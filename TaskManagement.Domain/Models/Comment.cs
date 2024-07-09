namespace TaskManagement.Domain.Models
{
	//represent the comments-conversetion under one task
	public class Comment : Entity
	{
		public long AssignmentId { get; set; }
		public Guid UserId { get; set; }
		public string CommentText { get; set; } = string.Empty;
		//If it's true soft delete the comment and hidde from UI list
		public bool IsHidden { get; set; }
		public ICollection<Comment>? Comments { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public Assignment Assignment { get; set; }
		public User User { get; set; }
	}
}
