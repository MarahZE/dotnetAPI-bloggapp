using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.User;

namespace backend.Dtos.Post
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime DatePublished { get; set; }
        public int? AuthorId { get; set; }
        public UserDto? UserDto { get; set; }
        //public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}