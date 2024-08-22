using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* 1. User
Properties:
UserId: int (Primary Key)
Username: string
Email: string
PasswordHash: string
ProfilePictureUrl: string
Bio: string
Relationships:
One User can create multiple Posts.
One User can create multiple Comments.
*/

namespace backend.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Comment> Comments { get; set; } = new List<Comment>();

    }
}