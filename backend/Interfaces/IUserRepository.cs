using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.User;
using backend.Models;

namespace backend.Controllers.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User userModel);
        Task<User?> UpdateUsersAsync(int id, UpdateUserRequestDto updateUserRequestDto);
        Task<User?> DeleteUserAsync(int id);
        Task<bool> UserExists(int userId);


    }
}