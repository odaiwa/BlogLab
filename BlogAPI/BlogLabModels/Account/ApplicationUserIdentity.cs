using System;
using System.Collections.Generic;
using System.Text;

namespace BlogLabModels.Account
{
    public class ApplicationUserIdentity
    {
        public int ApplicationUserId { get; set; }

        public string Username { get; set; }

        public string NormlizedUsername { get; set; }

        public string Email { get; set; }

        public string NormlizedEmail { get; set; }

        public string Fullname { get; set; }

        public string PasswordHash { get; set; }


    }
}
