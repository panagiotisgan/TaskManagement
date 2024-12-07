namespace TaskManagement.Domain.Shared
{
	public class PagedModel
	{
		public int Page { get; set; }
		public int PageSize { get; set; } = 5;
	}
}
