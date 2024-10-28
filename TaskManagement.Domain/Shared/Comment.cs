namespace TaskManagement.Domain.Shared
{
	public record Comment
	{
		public long AssignmentId { get; set; }
		public string UserId { get; set; } = string.Empty;
		public string CommentText { get; set; } = string.Empty;
		public bool IsHidden { get; set; }
	}
}
