using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class PostDto
    {
        public string Tittle { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }
    }
}
