using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class StatusPost
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
