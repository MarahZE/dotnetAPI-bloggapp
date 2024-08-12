using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.User;
using backend.Models;

namespace backend.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                UserId = userModel.UserId,
                Username = userModel.Username,
                Email = userModel.Email,
                Password = userModel.Password,
                ProfilePictureUrl = userModel.ProfilePictureUrl,
                Bio = userModel.Bio
            };
        }

        public static User ToUserFromCreateDto(this CreateUserRequestDto userDto)
        {
            return new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                Password = userDto.Password,
                ProfilePictureUrl = userDto.ProfilePictureUrl,
                Bio = userDto.Bio
            };
        }

    }
}