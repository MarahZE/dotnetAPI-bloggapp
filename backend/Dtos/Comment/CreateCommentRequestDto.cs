using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.Comment
{
    public class CreateCommentRequestDto
    {
        public string Content { get; set; } = string.Empty;
        public DateTime DatePublished { get; set; }
    }
}