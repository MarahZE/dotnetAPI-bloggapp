using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Dtos.Comment;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationsDbContext _context;
        public CommentRepository(ApplicationsDbContext applicationsDbContext)
        {
            _context = applicationsDbContext;

        }

        public async Task<Comment> CreateCommentAsync(Comment commentModel)
        {
            await _context.AddAsync(commentModel);
            await _context.SaveChangesAsync();

            return commentModel;
        }

        public async Task<Comment?> DeleteCommentAsync(int commentId)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == commentId);

            if (comment == null)
            {
                return null;
            }

            _context.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> UpdateCommentAsync(int commentId, UpdateCommentRequestDto updateCommentRequestDto)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == commentId);

            if (commentModel == null)
            {
                return null;
            }

            commentModel.Content = updateCommentRequestDto.Content;
            await _context.SaveChangesAsync();

            return commentModel;
        }
    }
}