using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Shared
{
    public class GetComment
    {
        public string UserId { get; set; } = string.Empty; 
        public long AssignmentId { get; set; }
        public long? CommentId { get; set; }
        public string CommentText { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsHidden { get; set; }
    }
}
