using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Models
{
    public class Log : Entity
    {
        public long TaskId { get; set; }
        public string PreviousTaskState { get; set; } = string.Empty;
        public DateTime ModificationDate { get; set; }
    }
}
