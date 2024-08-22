using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Comment;
using backend.Dtos.Post;

namespace backend.Dtos.User
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public List<PostDto> Posts { get; set; }

    }
}