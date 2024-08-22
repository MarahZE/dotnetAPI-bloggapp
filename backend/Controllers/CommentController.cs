using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Comment;
using backend.Interfaces;
using backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepo = commentRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _commentRepo.GetAllCommentsAsync();
            var commentDto = comments.Select(c => c.ToCommentDto());

            return Ok(commentDto);
        }

        [HttpPost("{userId}, {postId}")]
        public async Task<IActionResult> CreateComment([FromRoute] int userId, int postId, [FromBody] CreateCommentRequestDto createCommentRequestDto)
        {
            var comment = createCommentRequestDto.ToCommentFromCreateDto(userId, postId);
            await _commentRepo.CreateCommentAsync(comment);

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateCommentRequestDto)
        {
            var comment = await _commentRepo.UpdateCommentAsync(id, updateCommentRequestDto);

            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            var comment = await _commentRepo.DeleteCommentAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}