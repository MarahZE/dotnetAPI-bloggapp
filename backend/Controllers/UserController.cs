using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers.Interfaces;
using backend.Data;
using backend.Dtos.User;
using backend.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUsersRepository _userRepo;
        public UserController(IUsersRepository usersRepository)
        {
            _userRepo = usersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepo.GetAllUsersAsync();
            var userDTo = users.Select(s => s.ToUserDto());

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await _userRepo.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequestDto userDto)
        {
            var userModel = userDto.ToUserFromCreateDto();
            await _userRepo.CreateUserAsync(userModel);

            return CreatedAtAction(nameof(GetById), new { id = userModel.UserId }, userModel.ToUserDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequestDto updateUserDto)
        {
            var userModel = await _userRepo.UpdateUsersAsync(id, updateUserDto);

            if (userModel == null)
            {
                return NotFound();
            }


            return Ok(userModel.ToUserDto());

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var userModel = await _userRepo.DeleteUserAsync(id);

            if (userModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}