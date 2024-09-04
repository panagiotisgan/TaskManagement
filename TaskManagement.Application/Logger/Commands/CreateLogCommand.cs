using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Logger.Commands
{
    public class CreateLogCommand : IRequest<long>
    {
        public long Id { get; private set; }

        public static CreateLogCommand Create(long id) { return new CreateLogCommand() { Id = id }; }
    }
}
