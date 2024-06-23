using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Models
{
    public class UserTask
    {
        public long UserId { get; set; }
        public long TaskId { get; set; }
    }
}
