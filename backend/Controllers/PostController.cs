using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers.Interfaces;
using backend.Dtos.Post;
using backend.Interfaces;
using backend.Mappers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{

    [Microsoft.AspNetCore.Mvc.Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepo;
        private readonly IUsersRepository _userRepo;

        public PostController(IPostRepository postRepository, IUsersRepository usersRepository)
        {
            _postRepo = postRepository;
            _userRepo = usersRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postRepo.GetAllPostsAsync();
            var postDto = posts.Select(p => p.ToPostDto());

            return Ok(postDto);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPostById([FromRoute] int id)
        {
            var post = await _postRepo.GetPostByIDAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post.ToPostDto());

        }

        [HttpPost("{userId:int}")]
        public async Task<IActionResult> CreatePost([FromRoute] int userId, [FromBody] CreatePostRequestDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _userRepo.UserExists(userId))
            {
                return BadRequest("User dose not exists");
            }
            var post = postDto.ToPostFromCreateDto(userId);
            await _postRepo.CreatePostAsync(post);

            return CreatedAtAction(nameof(GetPostById), new { id = post.PostId }, post.ToPostDto());
        }

        [HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("{id:int}")]
        public async Task<IActionResult> UpdatePost([FromRoute] int id, [FromBody] UpdatePostRequestDto updatePostRequestDto)
        {
            var postModel = await _postRepo.UpdatePostAsync(id, updatePostRequestDto);

            if (postModel == null)
            {
                return NotFound();
            }

            return Ok(postModel.ToPostDto());

        }

        [HttpDelete]
        [Microsoft.AspNetCore.Mvc.Route("{id:int}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            var postModel = await _postRepo.DeletePostAsync(id);

            if (postModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}