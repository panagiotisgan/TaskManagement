namespace TaskManagement.Domain.Shared
{
	public record Comment
	{
		public long AssignmentId { get; set; }
		public long UserId { get; set; }
		public string CommentText { get; set; } = string.Empty;
		public bool IsHidden { get; set; }
	}
}
