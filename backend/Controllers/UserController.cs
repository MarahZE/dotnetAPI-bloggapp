using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Dtos.User;
using backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationsDbContext _context;
        public UserController(ApplicationsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users.ToList().Select(s => s.ToUserDto());

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());

        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserRequestDto userDto)
        {
            var userModel = userDto.ToUserFromCreateDto();
            _context.Users.Add(userModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = userModel.UserId }, userModel.ToUserDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateUserRequestDto updateUserDto)
        {
            var userModel = _context.Users.FirstOrDefault(s => s.UserId == id);

            if (userModel == null) {
                return NotFound();
            }

            userModel.Username = updateUserDto.Username;
            userModel.Email = updateUserDto.Email;
            userModel.Password = updateUserDto.Password;
            userModel.ProfilePictureUrl = updateUserDto.ProfilePictureUrl;
            userModel.Bio = updateUserDto.Bio;

            _context.SaveChanges();

            return Ok(userModel.ToUserDto());

        }

    }
}