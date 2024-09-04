using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Interfaces.Logger
{
    public interface ILogService
    {
        public Task<long> CreateLog(long assigmentId);
    }
}
