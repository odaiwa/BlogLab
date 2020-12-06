using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogLabModels.Account
{
    public class ApplicationUserCreate : ApplicationUserLogin
    {

        [MinLength(10, ErrorMessage = MessagesForErrors.CharactersLimit)]
        [MaxLength(30, ErrorMessage = MessagesForErrors.CharactersLimit)]
        public string Fullname { get; set; }



        [Required(ErrorMessage = MessagesForErrors.EmailRequired)]
        [EmailAddress(ErrorMessage = MessagesForErrors.InValidEmailRegex)]
        [MaxLength(30, ErrorMessage = MessagesForErrors.MaxCharactersLimit30)]
        public string Email { get; set; }


    }
}
