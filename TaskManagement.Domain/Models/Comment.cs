using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Models
{
    public class Comment : Entity
    {
        public string CommentText { get; set; } = string.Empty;
        //If it's true soft delete the comment and hidde from UI list
        public bool IsHidden { get; set; }
        public ICollection<Comment>? Comments { get; set;}
    }
}
