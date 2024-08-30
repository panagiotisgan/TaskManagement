namespace TaskManagement.Domain.Interfaces.Log
{
	public interface ILogService
	{
		public Task<long> CreateLog(long assigmentId);
	}
}
