namespace TaskManagement.Domain.Shared
{
	public class PagedEnumerable<T> where T : class
	{
		public IEnumerable<T> Items { get; set; }
		public int Total { get; set; }
		public int Page { get; set; }
		public int PageSize { get; set; }
	}
}
