using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BlogLab.Models;

namespace BlogLabModels.Blog
{
    public class BlogCreate
    {
        public int BlogId { get; set; }


        [Required(ErrorMessage = MessagesForErrors.TitleRequired)]
        [MinLength(10, ErrorMessage = MessagesForErrors.TitleLength)]
        [MaxLength(50,ErrorMessage = MessagesForErrors.TitleLength)]
        public string Titel { get; set; }


        [Required(ErrorMessage = MessagesForErrors.ContentRequired)]
        [MinLength(300,ErrorMessage = MessagesForErrors.ContentTextLimits)]
        [MaxLength(3000, ErrorMessage = MessagesForErrors.ContentTextLimits)]
        public string Content { get; set; }
        
        public int?  PhotoId { get; set; }

    }
}
