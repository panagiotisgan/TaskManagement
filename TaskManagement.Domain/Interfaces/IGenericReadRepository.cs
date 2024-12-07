namespace TaskManagement.Domain.Interfaces
{
	public interface IGenericReadRepository<T> where T : class
	{
		public Task<IEnumerable<T>> GetMany();
		public Task<T> GetById(string Id);

	}
}
