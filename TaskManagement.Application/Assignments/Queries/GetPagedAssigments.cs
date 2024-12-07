using MediatR;
using TaskManagement.Domain.Common;
using TaskManagement.Domain.Interfaces.Assigment;

namespace TaskManagement.Application.Assignments.Queries
{
	public class GetPagedAssigments : IRequest<PagedEnumerable<Domain.Models.Assignment>>
	{
		public string? Name { get; private set; }
		public string? UserId { get; private set; }
		public string? Priority { get; private set; }
		public string? Status { get; private set; }
		public string? SeverityLevel { get; private set; }
		public int PageSize { get; private set; }
		public int Page { get; private set; }

		private GetPagedAssigments(string? name, string? userId, string? priority, string? status, string? severityLevel, int pageSize, int page)
		{
			Name = name;
			UserId = userId;
			Priority = priority;
			Status = status;
			SeverityLevel = severityLevel;
			PageSize = pageSize;
			Page = page;
		}

		public static GetPagedAssigments Create(string? name, string? userId, string? priority, string? status, string? severityLevel, int pageSize, int page)
		{
			return new GetPagedAssigments(name, userId, priority, status, severityLevel, pageSize, page);
		}
	}

	public class GetPagedAssignmentsHandler : IRequestHandler<GetPagedAssigments, PagedEnumerable<Domain.Models.Assignment>>
	{
		private readonly IAssigmentService _assigmentService;

		public GetPagedAssignmentsHandler(IAssigmentService assigmentService)
		{
			_assigmentService = assigmentService;
		}

		public async Task<PagedEnumerable<Domain.Models.Assignment>> Handle(GetPagedAssigments request, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();


			return await _assigmentService.GetPagedAssigments(request.Name, request.UserId, request.Priority, request.SeverityLevel, request.Status, request.Page, request.PageSize);
		}
	}
}
