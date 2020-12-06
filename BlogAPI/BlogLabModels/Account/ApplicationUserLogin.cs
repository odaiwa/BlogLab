using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogLabModels.Account
{
    public class ApplicationUserLogin
    {
        [Required(ErrorMessage = MessagesForErrors.UsernameRequired)]
        [MinLength(5, ErrorMessage = MessagesForErrors.UsernameLengthLimit)]
        [MaxLength(20, ErrorMessage = MessagesForErrors.UsernameLengthLimit)]
        public string Username { get; set; }



        [Required(ErrorMessage = MessagesForErrors.PasswordRequired)]
        [MinLength(10, ErrorMessage = MessagesForErrors.PasswordLengthLimit)]
        [MaxLength(50, ErrorMessage = MessagesForErrors.PasswordLengthLimit)]
        public string Password { get; set; }



    }
}
