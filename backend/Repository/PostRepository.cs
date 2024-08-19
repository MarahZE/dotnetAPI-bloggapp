using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Dtos.Post;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationsDbContext _context;

        public PostRepository(ApplicationsDbContext applicationsDbContext)
        {
            _context = applicationsDbContext;

        }

        public async Task<Post> CreatePostAsync(Post postModel)
        {
            await _context.AddAsync(postModel);
            await _context.SaveChangesAsync();

            return postModel;
        }

        public async Task<Post?> DeletePostAsync(int postId)
        {
            var postModel = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == postId);

            if (postModel == null)
            {
                return null;
            }

            _context.Remove(postModel);
            await _context.SaveChangesAsync();

            return postModel;
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _context.Posts.Include(c => c.Comments).ToListAsync();
        }

        public async Task<Post?> GetPostByIDAsync(int id)
        {
            var post = await _context.Posts.Include(c => c.Comments).FirstOrDefaultAsync(i => i.PostId == id);

            if (post == null)
            {
                return null;
            }

            return post;
        }

        public async Task<Post?> UpdatePostAsync(int postId, UpdatePostRequestDto updatePostRequestDto)
        {
            var postModel = await _context.Posts.FirstOrDefaultAsync(s => s.PostId == postId);

            if (postModel == null)
            {
                return null;
            }

            postModel.Title = updatePostRequestDto.Title;
            postModel.Content = updatePostRequestDto.Content;

            await _context.SaveChangesAsync();

            return postModel;
        }
    }
}