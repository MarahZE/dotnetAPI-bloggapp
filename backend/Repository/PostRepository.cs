using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
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

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post?> GetPostByIDAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return null;
            }

            return post;
        }
    }
}