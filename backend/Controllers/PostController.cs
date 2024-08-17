using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public PostController(IPostRepository postRepository)
        {
            _postRepo = postRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postRepo.GetAllPostsAsync();
            var postDto = posts.Select(p => p.ToPostDto());

            return Ok(postDto);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById([FromRoute] int id)
        {
            var post = await _postRepo.GetPostByIDAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post.ToPostDto());

        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequestDto postDto)
        {
            var post = postDto.ToPostFromCreateDto();
            await _postRepo.CreatePostAsync(post);

            return CreatedAtAction(nameof(GetPostById), new { id = post.PostId }, post.ToPostDto());
        }


    }
}