using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Post;
using backend.Models;

namespace backend.Mappers
{
    public static class PostMappers
    {
        public static PostDto ToUserDto(this Post postModel)
        {
            return new PostDto
            {
                PostId = postModel.PostId,
                Title = postModel.Title,
                Content = postModel.Content,
                DatePublished = postModel.DatePublished,
                AuthorId = postModel.AuthorId,

            };
        }

    }
}