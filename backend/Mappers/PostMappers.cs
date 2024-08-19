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
        public static PostDto ToPostDto(this Post postModel)
        {
            return new PostDto
            {
                PostId = postModel.PostId,
                Title = postModel.Title,
                Content = postModel.Content,
                DatePublished = postModel.DatePublished,
                UserId = postModel.UserId,

            };
        }

        public static Post ToPostFromCreateDto(this CreatePostRequestDto postDto, int userID)
        {
            return new Post
            {
                Title = postDto.Title,
                Content = postDto.Content,
                DatePublished = postDto.DatePublished,
                UserId = userID


            };
        }



    }
}