using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Comment;
using backend.Models;

namespace backend.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                CommentId = commentModel.CommentId,
                Content = commentModel.Content,
                DatePublished = commentModel.DatePublished,
                UserId = commentModel.UserId,
                PostId = commentModel.PostId,

            };
        }

    }
}