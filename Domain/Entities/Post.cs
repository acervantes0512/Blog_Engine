using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Content { get; set; }
        public int StatusPostId { get; set; }
        public int UserAuthorId { get; set; }
        public DateTime CreationDate { get; set; }
        public StatusPost StatusPost { get; set; }
        public User UserAuthor { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<EditPostUser> EditPostUsers { get; set; }
    }
}
