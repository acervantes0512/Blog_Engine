using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class EditPostUser
    {
        public int Id { get; set; }        
        public string Description { get; set; }
        public int UserAuthorId { get; set; }
        public int PostId { get; set; }
        public DateTime CreationDate { get; set; }
        public Post Post { get; set; }
        public User UserAuthor { get; set; }
    }
}
