using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* 3. Comment
Properties:
CommentId: int (Primary Key)
Content: string
DatePublished: DateTime
AuthorId: int (Foreign Key to User)
PostId: int (Foreign Key to Post)
Relationships:
One Comment belongs to one Post.
One Comment belongs to one User (Author).
*/

namespace backend.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime DatePublished { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }
        public Post? Post { get; set; }
        public User? User { get; set; }
    }
}