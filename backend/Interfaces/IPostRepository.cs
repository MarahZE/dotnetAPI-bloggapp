using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Post;
using backend.Helpers;
using backend.Models;

namespace backend.Interfaces
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAllPostsAsync(QueryObject query);
        Task<Post?> GetPostByIDAsync(int id);
        Task<Post> CreatePostAsync(Post postModel);
        Task<Post?> UpdatePostAsync(int postId, UpdatePostRequestDto updatePostRequestDto);
        Task<Post?> DeletePostAsync(int postId);
    }
}