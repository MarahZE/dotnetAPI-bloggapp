using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers.Interfaces;
using backend.Data;
using backend.Dtos.User;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class UserRepository : IUsersRepository
    {
        private readonly ApplicationsDbContext _context;
        public UserRepository(ApplicationsDbContext applicationsDbContext)
        {
            _context = applicationsDbContext;

        }

        public async Task<User> CreateUserAsync(User userModel)
        {
            await _context.AddAsync(userModel);
            await _context.SaveChangesAsync();

            return userModel;
        }

        public async Task<User?> DeleteUserAsync(int id)
        {
            var userModel = await _context.Users.Include(p => p.Posts).ThenInclude(c => c.Comments).FirstOrDefaultAsync(s => s.UserId == id);

            if (userModel == null)
            {
                return null;
            }
            try
            {
                // Delete related comments
                foreach (var post in userModel.Posts)
                {
                    _context.Comments.RemoveRange(post.Comments);
                }
                // Delete related posts 
                _context.Posts.RemoveRange(userModel.Posts);

                _context.Users.Remove(userModel);
                await _context.SaveChangesAsync();

                return userModel;
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("An error occurred while deleting the user.", ex);
            }


        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.Include(p => p.Posts).ThenInclude(c => c.Comments).ToListAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.Include(p => p.Posts).FirstOrDefaultAsync(i => i.UserId == id);

            if (user == null)
            {
                return null;
            }

            return user;

        }

        public async Task<User?> UpdateUsersAsync(int id, UpdateUserRequestDto updateUserDto)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(s => s.UserId == id);

            if (userModel == null)
            {
                return null;
            }

            userModel.Username = updateUserDto.Username;
            userModel.Email = updateUserDto.Email;
            userModel.Password = updateUserDto.Password;
            userModel.ProfilePictureUrl = updateUserDto.ProfilePictureUrl;
            userModel.Bio = updateUserDto.Bio;


            await _context.SaveChangesAsync();

            return userModel;
        }

        public Task<bool> UserExists(int userId)
        {
            return _context.Users.AnyAsync(u => u.UserId == userId);
        }
    }
}