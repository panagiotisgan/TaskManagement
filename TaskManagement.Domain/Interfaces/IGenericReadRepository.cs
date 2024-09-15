using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Interfaces
{
    public interface IGenericReadRepository<T> where T : class
    {
        //TODO add pagination
        public Task<IEnumerable<T>> GetMany();
        public Task<T> GetById(string Id);

    }
}
