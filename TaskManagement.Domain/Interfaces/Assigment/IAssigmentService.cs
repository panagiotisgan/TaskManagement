using TaskManagement.Domain.Models;

namespace TaskManagement.Domain.Interfaces.Assigment
{
	public interface IAssigmentService
	{
		public Task<Assignment> Create(Assignment assignment);
	}
}
