using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BlogLab.Models;

namespace BlogLabModels.BlogComment
{
    public class BlogCommentCreate
    {

        public int BlogCommentId { get; set; }

        public int? ParentCommentId { get; set; }

        public int BlogId { get; set; }


        [Required(ErrorMessage = MessagesForErrors.ContentRequired)]
        [MinLength(10, ErrorMessage = MessagesForErrors.CharactersLimit10_300)]
        [MaxLength(300, ErrorMessage = MessagesForErrors.CharactersLimit10_300)]
        public string Content { get; set; }

    }
}
