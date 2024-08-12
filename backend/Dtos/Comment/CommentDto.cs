using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Post;
using backend.Dtos.User;

namespace backend.Dtos.Comment
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime DatePublished { get; set; }
        public int? AuthorID { get; set; }
        public int? PostId { get; set; }
        public PostDto? PostDto { get; set; }
        public UserDto? UserDto { get; set; }
    }
}