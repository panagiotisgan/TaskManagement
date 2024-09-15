using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Domain.Interfaces.Assigment;

namespace TaskManagement.Application.Assignment.Queries
{
    public record GetAssignments : IRequest<IEnumerable<TaskManagement.Domain.Models.Assignment>>
    {
    }

    public class GetAssignmentsHandler : IRequestHandler<GetAssignments, IEnumerable<TaskManagement.Domain.Models.Assignment>>
    {
        private readonly IGenericReadRepository<TaskManagement.Domain.Models.Assignment> _assigmentService;

        public GetAssignmentsHandler(IGenericReadRepository<TaskManagement.Domain.Models.Assignment> assigmentService)
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
