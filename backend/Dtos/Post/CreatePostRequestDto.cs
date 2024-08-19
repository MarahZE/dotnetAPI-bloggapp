using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.Post
{
    public class CreatePostRequestDto
    {
        [Required]
        [MinLength(10, ErrorMessage = "Title must be 10 characters")]
        [MaxLength(50, ErrorMessage = "Title cannot be over 50 characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(50, ErrorMessage = "Content must be 50 characters")]
        [MaxLength(500, ErrorMessage = "Content cannot be over 500 characters")]
        public string Content { get; set; } = string.Empty;
        public DateTime DatePublished { get; set; }

    }
}