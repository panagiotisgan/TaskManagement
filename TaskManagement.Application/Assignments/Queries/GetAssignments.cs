using MediatR;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Assignments.Queries
{
	public record GetAssignments : IRequest<IEnumerable<Domain.Models.Assignment>>
	{
	}

	public class GetAssignmentsHandler : IRequestHandler<GetAssignments, IEnumerable<Domain.Models.Assignment>>
	{
		private readonly IGenericReadRepository<Domain.Models.Assignment> _assigmentService;

		public GetAssignmentsHandler(IGenericReadRepository<Domain.Models.Assignment> assigmentService)
		{
			_assigmentService = assigmentService;
		}

		public async Task<IEnumerable<Domain.Models.Assignment>> Handle(GetAssignments request, CancellationToken cancellationToken)
		{
			try
			{
				var result = await _assigmentService.GetMany();
				return result;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
