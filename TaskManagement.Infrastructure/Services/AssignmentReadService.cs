using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Domain.Models;
using TaskManagement.Infrastructure.Context;

namespace TaskManagement.Infrastructure.Services
{
    public class AssignmentReadService : IGenericReadRepository<Assignment>
    {
        private readonly TaskManagementContext _context;
        public AssignmentReadService(TaskManagementContext context)
        {
            _context = context;
        }

        public async Task<Assignment> GetById(string Id)
        {
            if (Int64.TryParse(Id, out var assignmentId))
            {
               return await _context.Assignments.FirstOrDefaultAsync(x => x.Id == assignmentId);
            }

            return null;
        }

        //TODO add pagination
        public async Task<IEnumerable<Assignment>> GetMany()
        {
            var assignments = await _context.Assignments.ToArrayAsync();

            return assignments ?? Array.Empty<Assignment>();
        }
    }
}
