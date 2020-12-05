using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogLabModels.Account
{
    public class ApplicationUserCreate : ApplicationUserLogin
    {
        [MinLength(10, ErrorMessage = "Must be at least 10-30 characters")]
        [MaxLength(30, ErrorMessage = "Must be at least 10-30 characters")]
        public string Fullname { get; set; }



        [Required(ErrorMessage = "Email is required")]
        [EmailAddress( ErrorMessage = "InValid Email Format")]
        [MaxLength(30, ErrorMessage = "Can be at must 30 characters")]
        public string Email { get; set; }
    }
}
