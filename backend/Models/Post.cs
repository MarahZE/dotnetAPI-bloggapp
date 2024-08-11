using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* 2. Post
Properties:
PostId: int (Primary Key)
Title: string
Content: string
DatePublished: DateTime
AuthorId: int (Foreign Key to User)
Relationships:
One Post belongs to one User (Author).
One Post can have multiple Comments.
*/

namespace backend.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime DatePublished { get; set; }
        public int? AuthorId { get; set; }
        public User? User { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();

    }
}