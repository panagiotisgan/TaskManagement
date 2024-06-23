using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Models
{
    public class TeamUser
    {
        public long TeamId { get; set; }
        public long UserId { get; set; }
    }
}
